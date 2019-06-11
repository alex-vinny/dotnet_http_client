using System;
using System.Collections.Generic;

namespace SomeHttpCli
{
    public class SimpleGetRequest : SimpleRequest, IBaseRequest
    {
        public SimpleGetRequest(string resource)
            :base(resource)
        {            
        }
    }
}