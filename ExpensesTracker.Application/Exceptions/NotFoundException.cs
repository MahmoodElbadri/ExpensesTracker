namespace ExpensesTracker.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string resourceType, string resourceId) : base($"The {resourceType} with {resourceId} was not found")
    {
    }
}