using System;
using Xunit;
using Xunit.Abstractions;
using SimpleValidation;
using System.Collections.Generic;

namespace HttpTests
{
    public class SomeValidationsUnitTests
    {
        readonly ITestOutputHelper output;
        public SomeValidationsUnitTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void NotNullValidationRuleOnNullObject()
        {
            Person person = null;

            var validator = new Validator();

            var result = validator
                .AddRule<NotNullValidationRule<Person>, Person>(person)
                .Validate()
                .Valid;           
            
            Assert.True(result);
            Assert.Null(person);
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class NotNullValidationRule<T> : IValidationRule<T>
    {
        public NotNullValidationRule()
        {
            Error = new ValidationError
            {
                Code = 100,
                Message = "Null reference of object find."
            };
        }

        public ValidationError Error {get; private set;}

        public bool Validate(object arg) => NotNull(arg);
        public bool Validate(T arg) => NotNull(arg);

        private bool NotNull(object arg)
        {
            return arg != null;
        }
    }
}
