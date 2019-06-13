using System;
using System.Collections.Generic;

namespace SimpleValidation
{
    public class Validator : IValidator
    {
        IDictionary<IValidationRule, object> validations;

        public Validator()
        {            
            validations = new Dictionary<IValidationRule, object>();            
        }
        
        public IValidator AddRule<TRule, T>(T arg)
            where TRule : IValidationRule, new()
        {
            validations.Add(new TRule(), arg);
            return this;
        }
        
        public ValidationResult Validate()
        {            
            foreach (var pair in validations)
            {
                var rule = pair.Key;
                var obj = pair.Value;

                if(!rule.Validate(obj))                
                    return new ValidationResult(rule.Error);
            }

            return new ValidationResult();            
        }
    }
}
