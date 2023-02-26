namespace CookBookHub.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string entityName, Guid id)
        : base($"{entityName} with ID {id} was not found")
    {
    }

    public NotFoundException(string message)
        : base(message)
    {
    }
}

public class BusinessRuleException : Exception
{
    public BusinessRuleException(string message)
        : base(message)
    {
    }
}

public class DuplicateEntityException : Exception
{
    public DuplicateEntityException(string entityName, string fieldName, string value)
        : base($"{entityName} with {fieldName} '{value}' already exists")
    {
    }

    public DuplicateEntityException(string message)
        : base(message)
    {
    }
}

public class ValidationException : Exception
{
    public IDictionary<string, string[]> Errors { get; }

    public ValidationException(IDictionary<string, string[]> errors)
        : base("One or more validation errors occurred")
    {
        Errors = errors;
    }
}
