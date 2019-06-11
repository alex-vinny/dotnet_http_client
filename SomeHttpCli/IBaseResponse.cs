using System;
using System.Collections.Generic;

namespace SomeHttpCli
{
    public interface IBaseResponse<T>
        where T : class, new()
    {
        bool Success {get; }
        string Errors {get; }
        T Response {get; }
    }
}