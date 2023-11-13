using FluentValidation;

namespace AtCommanderSharp.Extensions;

public static class ValidationExceptionExtension
{
    public static void ValidateAndThrow<T>(this AbstractValidator<T> validator, T instance)
    {
        var validationResult = validator.Validate(instance);
        if (!validationResult.IsValid)
        {
            var errorMessages = string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException($"Validation of {typeof(T)} failed: {errorMessages}");
        }
    }
}