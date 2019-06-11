using System;
using System.Collections.Generic;

namespace SomeHttpCli
{
    public abstract class SimpleRequest : IBaseRequest
    {
        public SimpleRequest(string resource)
            :this(resource, Verbs.Get)
        {
        }
        public SimpleRequest(string resource, Verbs verb)
        {
            Resource = resource;
            Verb = verb;
            Segments = new Dictionary<string, string>();
            Headers = new Dictionary<string, string>();
            Parameters = new Dictionary<string, string>();
        }       
        public string Resource { get;protected set;}
        public bool HasSegmentOnResource {get {return false;} }

        public Verbs Verb {get; protected set;}        
        public ICollection<KeyValuePair<string, string>> Segments {get; protected set;}
        public ICollection<KeyValuePair<string, string>> Headers {get; protected set;}
        public ICollection<KeyValuePair<string, string>> Parameters {get;protected set; }
    }
}