using System;
using System.Collections.Generic;

namespace SomeHttpCli
{
    public interface IBaseRequest
    {
        string Resource { get;}
        bool HasSegmentOnResource {get; }

        Verbs Verb {get; }        
        ICollection<KeyValuePair<string, string>> Segments {get; }
        ICollection<KeyValuePair<string, string>> Headers {get; }
        ICollection<KeyValuePair<string, string>> Parameters {get; }
    }
}