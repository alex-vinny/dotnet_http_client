using System;
using RestSharp;

namespace SomeHttpCli
{
    public class Client
    {
        IRestClient client;

        public Client(string baseUrl)
        {
            client = new RestClient(baseUrl);
        }

        public IBaseResponse<TResponse> Execute<TResponse>(IBaseRequest dto)
            where TResponse : class, new()
        {
            var request = PrepareRequest(dto);
            
            return PrepareResponse<TResponse>(client.Execute<TResponse>(request));
        }

        public IBaseResponse<TResponse> Execute<TResponse, TRequest>(IBaseRequestWithBody<TRequest> dto)
            where TRequest : class, new()
            where TResponse : class, new()
        {
            var request = PrepareRequest(dto);

            AdjustVerbAndBody(dto.Verb, dto.Body, request);

            return PrepareResponse<TResponse>(client.Execute<TResponse>(request));
        }

        private RestRequest PrepareRequest(IBaseRequest dto)
        {
            var request = new RestRequest(dto.Resource);

            if (dto.HasSegmentOnResource)
                foreach (var segment in dto.Segments)
                    request.AddUrlSegment(segment.Key, segment.Value);

            foreach (var header in dto.Headers)
                request.AddHeader(header.Key, header.Value);

            foreach (var parameter in dto.Parameters)
                request.AddOrUpdateParameter(parameter.Key, parameter.Value);

            return request;
        }

        private void AdjustVerbAndBody<TBody>(Verbs verb, TBody body, RestRequest request)
        {
            switch (verb)
            {
                case Verbs.Post:
                    request.Method = Method.POST;
                    request.AddJsonBody(body);
                    break;
                case Verbs.Put:
                    request.Method = Method.PUT;
                    request.AddJsonBody(body);
                    break;
                case Verbs.Delete:
                    request.Method = Method.DELETE;
                    break;
                case Verbs.Get:
                default:
                    request.Method = Method.GET;
                    break;
            }
        }

        private IBaseResponse<T> PrepareResponse<T>(IRestResponse<T> restResponse)
            where T : class, new()
        {
            if(restResponse.IsSuccessful)
            {
                return new SimpleResponse<T>(restResponse.Data);
            }
            else
            {
                return 
                    new ErrorResponse<T>(restResponse.ErrorException)
                    {
                        Errors = restResponse.ErrorMessage
                    };
            }
        }
    }
}
