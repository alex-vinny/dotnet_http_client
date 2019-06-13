using System;

namespace SimpleValidation
{
    public class ValidationResult : ValidationError
    {
        public ValidationResult()
        {
            Valid = true;
        }
        public ValidationResult(ValidationError error)
        {
            Message = error.Message;
            Code = error.Code;
        }
        public bool Valid {get;}
    }
}
