using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CookBookHub.Application.Exceptions;

namespace CookBookHub.ApiService.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    private readonly ILogger<GlobalExceptionFilter> _logger;

    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        _logger.LogError(exception, "An error occurred: {Message}", exception.Message);

        var response = exception switch
        {
            NotFoundException notFoundEx => new
            {
                error = "Not Found",
                message = notFoundEx.Message,
                statusCode = 404
            },
            BusinessRuleException businessEx => new
            {
                error = "Business Rule Violation",
                message = businessEx.Message,
                statusCode = 400
            },
            DuplicateEntityException duplicateEx => new
            {
                error = "Duplicate Entity",
                message = duplicateEx.Message,
                statusCode = 409
            },
            ValidationException validationEx => new
            {
                error = "Validation Failed",
                message = validationEx.Message,
                errors = validationEx.Errors,
                statusCode = 400
            },
            _ => new
            {
                error = "Internal Server Error",
                message = "An unexpected error occurred",
                statusCode = 500
            }
        };

        context.Result = new ObjectResult(response)
        {
            StatusCode = response.statusCode
        };

        context.ExceptionHandled = true;
    }
}
