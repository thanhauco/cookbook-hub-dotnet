namespace CookBookHub.Domain.Enums;

public enum RecipeStatus
{
    Draft = 0,
    Published = 1,
    Archived = 2
}

public enum UserRole
{
    User = 0,
    Chef = 1,
    Admin = 2
}

public enum NotificationType
{
    RecipePublished = 0,
    ReviewReceived = 1,
    NewFollower = 2,
    RecipeLiked = 3
}
