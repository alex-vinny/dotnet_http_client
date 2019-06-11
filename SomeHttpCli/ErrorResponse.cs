using System;
using System.Collections.Generic;

namespace SomeHttpCli
{
    public class ErrorResponse<T> : IBaseResponse<T>
        where T : class, new()
    {
        public ErrorResponse(Exception exception)
        {
        }
        public bool Success => false;
        public string Errors {get; set; }
        public T Response { get; private set; }      
    }
}