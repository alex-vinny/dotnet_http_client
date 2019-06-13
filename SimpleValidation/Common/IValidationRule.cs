using System;

namespace SimpleValidation
{
    public interface IValidationRule
    {
        ValidationError Error {get;}
        bool Validate(object arg);
    }
    public interface IValidationRule<T> : IValidationRule
    {
        bool Validate(T arg);
    }
}
