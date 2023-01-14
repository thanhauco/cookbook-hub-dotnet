using CookBookHub.Application.DTOs;

namespace CookBookHub.Application.Interfaces;

public interface IRecipeService
{
    Task<IEnumerable<RecipeDto>> GetAllRecipesAsync(CancellationToken cancellationToken = default);
    Task<RecipeDto?> GetRecipeByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<RecipeDto>> GetRecipesByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default);
    Task<IEnumerable<RecipeDto>> GetRecipesByUserAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<RecipeDto>> SearchRecipesAsync(string searchTerm, CancellationToken cancellationToken = default);
    Task<RecipeDto> CreateRecipeAsync(CreateRecipeDto dto, CancellationToken cancellationToken = default);
    Task UpdateRecipeAsync(Guid id, UpdateRecipeDto dto, CancellationToken cancellationToken = default);
    Task DeleteRecipeAsync(Guid id, CancellationToken cancellationToken = default);
}

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
    Task<CategoryDto?> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto, CancellationToken cancellationToken = default);
    Task UpdateCategoryAsync(Guid id, CreateCategoryDto dto, CancellationToken cancellationToken = default);
    Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken = default);
}

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    Task<UserDto?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UserDto?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default);
    Task<UserDto> CreateUserAsync(CreateUserDto dto, CancellationToken cancellationToken = default);
    Task UpdateUserAsync(Guid id, CreateUserDto dto, CancellationToken cancellationToken = default);
    Task DeleteUserAsync(Guid id, CancellationToken cancellationToken = default);
}

public interface IReviewService
{
    Task<IEnumerable<ReviewDto>> GetReviewsByRecipeAsync(Guid recipeId, CancellationToken cancellationToken = default);
    Task<ReviewDto?> GetReviewByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<ReviewDto> CreateReviewAsync(CreateReviewDto dto, CancellationToken cancellationToken = default);
    Task UpdateReviewAsync(Guid id, CreateReviewDto dto, CancellationToken cancellationToken = default);
    Task DeleteReviewAsync(Guid id, CancellationToken cancellationToken = default);
}
