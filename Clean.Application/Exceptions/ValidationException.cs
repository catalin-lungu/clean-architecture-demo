using FluentValidation.Results;

namespace Clean.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public Dictionary<string, string> ValidationErrors { get; set; }
        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new Dictionary<string, string>();
            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
