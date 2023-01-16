using Microsoft.EntityFrameworkCore;
using CookBookHub.Application.DTOs;
using CookBookHub.Application.Interfaces;
using CookBookHub.Domain.Entities;
using CookBookHub.Domain.Interfaces;
using CookBookHub.Infrastructure.Data;

namespace CookBookHub.Application.Services;

public class RecipeService : IRecipeService
{
    private readonly CookBookDbContext _context;
    private readonly IRepository<Recipe> _recipeRepository;

    public RecipeService(CookBookDbContext context, IRepository<Recipe> recipeRepository)
    {
        _context = context;
        _recipeRepository = recipeRepository;
    }

    public async Task<IEnumerable<RecipeDto>> GetAllRecipesAsync(CancellationToken cancellationToken = default)
    {
        var recipes = await _context.Recipes
            .Include(r => r.Category)
            .Include(r => r.User)
            .Include(r => r.Reviews)
            .Where(r => r.IsPublished)
            .ToListAsync(cancellationToken);

        return recipes.Select(MapToDto);
    }

    public async Task<RecipeDto?> GetRecipeByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var recipe = await _context.Recipes
            .Include(r => r.Category)
            .Include(r => r.User)
            .Include(r => r.Reviews)
            .Include(r => r.Ingredients)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

        return recipe == null ? null : MapToDto(recipe);
    }

    public async Task<IEnumerable<RecipeDto>> GetRecipesByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        var recipes = await _context.Recipes
            .Include(r => r.Category)
            .Include(r => r.User)
            .Include(r => r.Reviews)
            .Where(r => r.CategoryId == categoryId && r.IsPublished)
            .ToListAsync(cancellationToken);

        return recipes.Select(MapToDto);
    }

    public async Task<IEnumerable<RecipeDto>> GetRecipesByUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var recipes = await _context.Recipes
            .Include(r => r.Category)
            .Include(r => r.User)
            .Include(r => r.Reviews)
            .Where(r => r.UserId == userId)
            .ToListAsync(cancellationToken);

        return recipes.Select(MapToDto);
    }

    public async Task<IEnumerable<RecipeDto>> SearchRecipesAsync(string searchTerm, CancellationToken cancellationToken = default)
    {
        var recipes = await _context.Recipes
            .Include(r => r.Category)
            .Include(r => r.User)
            .Include(r => r.Reviews)
            .Where(r => r.IsPublished && 
                (r.Title.Contains(searchTerm) || r.Description.Contains(searchTerm)))
            .ToListAsync(cancellationToken);

        return recipes.Select(MapToDto);
    }

    public async Task<RecipeDto> CreateRecipeAsync(CreateRecipeDto dto, CancellationToken cancellationToken = default)
    {
        var recipe = new Recipe
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            Instructions = dto.Instructions,
            PrepTimeMinutes = dto.PrepTimeMinutes,
            CookTimeMinutes = dto.CookTimeMinutes,
            Servings = dto.Servings,
            Difficulty = (DifficultyLevel)dto.Difficulty,
            ImageUrl = dto.ImageUrl,
            CategoryId = dto.CategoryId,
            UserId = dto.UserId,
            CreatedAt = DateTime.UtcNow,
            IsPublished = false
        };

        foreach (var ingredientDto in dto.Ingredients)
        {
            recipe.Ingredients.Add(new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = ingredientDto.Name,
                Quantity = ingredientDto.Quantity,
                Unit = ingredientDto.Unit,
                Notes = ingredientDto.Notes,
                DisplayOrder = ingredientDto.DisplayOrder
            });
        }

        await _recipeRepository.AddAsync(recipe, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return await GetRecipeByIdAsync(recipe.Id, cancellationToken) 
            ?? throw new Exception("Failed to retrieve created recipe");
    }

    public async Task UpdateRecipeAsync(Guid id, UpdateRecipeDto dto, CancellationToken cancellationToken = default)
    {
        var recipe = await _recipeRepository.GetByIdAsync(id, cancellationToken);
        if (recipe == null)
            throw new KeyNotFoundException($"Recipe with ID {id} not found");

        recipe.Title = dto.Title;
        recipe.Description = dto.Description;
        recipe.Instructions = dto.Instructions;
        recipe.PrepTimeMinutes = dto.PrepTimeMinutes;
        recipe.CookTimeMinutes = dto.CookTimeMinutes;
        recipe.Servings = dto.Servings;
        recipe.Difficulty = (DifficultyLevel)dto.Difficulty;
        recipe.ImageUrl = dto.ImageUrl;
        recipe.CategoryId = dto.CategoryId;
        recipe.IsPublished = dto.IsPublished;
        recipe.UpdatedAt = DateTime.UtcNow;

        await _recipeRepository.UpdateAsync(recipe, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRecipeAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var recipe = await _recipeRepository.GetByIdAsync(id, cancellationToken);
        if (recipe == null)
            throw new KeyNotFoundException($"Recipe with ID {id} not found");

        await _recipeRepository.DeleteAsync(recipe, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    private static RecipeDto MapToDto(Recipe recipe)
    {
        var averageRating = recipe.Reviews.Any() 
            ? recipe.Reviews.Average(r => r.Rating) 
            : 0;

        return new RecipeDto(
            recipe.Id,
            recipe.Title,
            recipe.Description,
            recipe.Instructions,
            recipe.PrepTimeMinutes,
            recipe.CookTimeMinutes,
            recipe.Servings,
            recipe.Difficulty.ToString(),
            recipe.ImageUrl,
            recipe.CategoryId,
            recipe.Category?.Name ?? string.Empty,
            recipe.UserId,
            recipe.User?.Username ?? string.Empty,
            recipe.CreatedAt,
            recipe.IsPublished,
            averageRating,
            recipe.Reviews.Count
        );
    }
}
