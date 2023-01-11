namespace CookBookHub.Application.DTOs;

public record RecipeDto(
    Guid Id,
    string Title,
    string Description,
    string Instructions,
    int PrepTimeMinutes,
    int CookTimeMinutes,
    int Servings,
    string Difficulty,
    string ImageUrl,
    Guid CategoryId,
    string CategoryName,
    Guid UserId,
    string UserName,
    DateTime CreatedAt,
    bool IsPublished,
    double AverageRating,
    int ReviewCount
);

public record CreateRecipeDto(
    string Title,
    string Description,
    string Instructions,
    int PrepTimeMinutes,
    int CookTimeMinutes,
    int Servings,
    int Difficulty,
    string ImageUrl,
    Guid CategoryId,
    Guid UserId,
    List<CreateIngredientDto> Ingredients
);

public record UpdateRecipeDto(
    string Title,
    string Description,
    string Instructions,
    int PrepTimeMinutes,
    int CookTimeMinutes,
    int Servings,
    int Difficulty,
    string ImageUrl,
    Guid CategoryId,
    bool IsPublished
);

public record IngredientDto(
    Guid Id,
    string Name,
    decimal Quantity,
    string Unit,
    string Notes,
    int DisplayOrder
);

public record CreateIngredientDto(
    string Name,
    decimal Quantity,
    string Unit,
    string Notes,
    int DisplayOrder
);

public record CategoryDto(
    Guid Id,
    string Name,
    string Description,
    string IconUrl,
    int RecipeCount
);

public record CreateCategoryDto(
    string Name,
    string Description,
    string IconUrl
);

public record UserDto(
    Guid Id,
    string Username,
    string Email,
    string FullName,
    string Bio,
    string AvatarUrl,
    int RecipeCount,
    int ReviewCount
);

public record CreateUserDto(
    string Username,
    string Email,
    string FullName,
    string Bio,
    string AvatarUrl
);

public record ReviewDto(
    Guid Id,
    Guid RecipeId,
    Guid UserId,
    string UserName,
    int Rating,
    string Comment,
    DateTime CreatedAt
);

public record CreateReviewDto(
    Guid RecipeId,
    Guid UserId,
    int Rating,
    string Comment
);
