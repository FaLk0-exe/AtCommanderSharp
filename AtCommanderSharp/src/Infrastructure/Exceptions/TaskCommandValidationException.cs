namespace AtCommanderSharp.Infrastructure.Exceptions;

public class TaskCommandValidationException : Exception
{
    public TaskCommandValidationException(int errorCode, string errorMessage)
        : base($"Scheduling was completed with error code: {errorCode}. Message: {errorMessage}")
    {}
}
