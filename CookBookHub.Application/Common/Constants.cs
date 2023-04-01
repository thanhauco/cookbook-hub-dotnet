namespace CookBookHub.Application.Common;

public static class Constants
{
    public static class Validation
    {
        public const int RecipeTitleMaxLength = 200;
        public const int RecipeDescriptionMaxLength = 1000;
        public const int RecipeInstructionsMaxLength = 5000;
        public const int UserNameMaxLength = 50;
        public const int UserBioMaxLength = 500;
        public const int CategoryNameMaxLength = 100;
        public const int ReviewCommentMaxLength = 1000;
        public const int MinRating = 1;
        public const int MaxRating = 5;
    }

    public static class Defaults
    {
        public const int DefaultPageSize = 10;
        public const int MaxPageSize = 50;
        public const int SearchResultsLimit = 100;
    }

    public static class CacheKeys
    {
        public const string AllCategories = "categories_all";
        public const string RecipePrefix = "recipe_";
        public const string UserPrefix = "user_";
        public const int CacheDurationMinutes = 10;
    }

    public static class ErrorMessages
    {
        public const string RecipeNotFound = "Recipe not found";
        public const string UserNotFound = "User not found";
        public const string CategoryNotFound = "Category not found";
        public const string ReviewNotFound = "Review not found";
        public const string DuplicateReview = "You have already reviewed this recipe";
        public const string DuplicateUsername = "Username already exists";
        public const string DuplicateEmail = "Email already exists";
    }
}
