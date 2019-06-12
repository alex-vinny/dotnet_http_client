using System;
using System.Collections.Generic;

namespace SomeHttpCli
{
    public class SimpleResponse<T> : IBaseResponse<T>
        where T : class, new()
    {
        public SimpleResponse(T resultValue)
        {
            Response = resultValue;
        }
        public bool Success {get; private set; }
        public string Errors {get; private set; }
        public T Response { get; private set; }      
    }
}