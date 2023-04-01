using Microsoft.Extensions.Logging;

namespace CookBookHub.Application.Common;

public static class LoggerExtensions
{
    public static void LogRecipeCreated(this ILogger logger, Guid recipeId, string title)
    {
        logger.LogInformation("Recipe created: {RecipeId} - {Title}", recipeId, title);
    }

    public static void LogRecipeUpdated(this ILogger logger, Guid recipeId)
    {
        logger.LogInformation("Recipe updated: {RecipeId}", recipeId);
    }

    public static void LogRecipeDeleted(this ILogger logger, Guid recipeId)
    {
        logger.LogInformation("Recipe deleted: {RecipeId}", recipeId);
    }

    public static void LogUserCreated(this ILogger logger, Guid userId, string username)
    {
        logger.LogInformation("User created: {UserId} - {Username}", userId, username);
    }

    public static void LogReviewCreated(this ILogger logger, Guid reviewId, Guid recipeId, int rating)
    {
        logger.LogInformation("Review created: {ReviewId} for Recipe: {RecipeId} with Rating: {Rating}", reviewId, recipeId, rating);
    }

    public static void LogSearchPerformed(this ILogger logger, string query, int resultCount)
    {
        logger.LogInformation("Search performed: '{Query}' - {ResultCount} results", query, resultCount);
    }
}
