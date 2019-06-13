using System;

namespace SimpleValidation
{
    public interface IValidator
    {
        IValidator AddRule<TRule, T>(T arg)
            where TRule : IValidationRule, new();
        ValidationResult Validate();
    }
}
