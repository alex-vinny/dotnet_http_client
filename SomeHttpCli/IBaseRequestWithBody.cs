using System;
using System.Collections.Generic;

namespace SomeHttpCli
{
    public interface IBaseRequestWithBody<out T> : IBaseRequest
        where T : class, new()
    {
        T Body {get; }
    }
}