using System;
using System.Collections.Generic;

namespace SomeHttpCli
{
   public class SimpleBodyRequest<TBody> : SimpleRequest, IBaseRequest, IBaseRequestWithBody<TBody>
    where TBody : class, new()
   {
       public SimpleBodyRequest(string resource, Verbs verb, TBody body)
        :base(resource, verb)
       {
           Body = body;
       }

        public TBody Body {get; private set;}
    }
}