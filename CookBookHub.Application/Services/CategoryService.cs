using Microsoft.EntityFrameworkCore;
using CookBookHub.Application.DTOs;
using CookBookHub.Application.Interfaces;
using CookBookHub.Domain.Entities;
using CookBookHub.Domain.Interfaces;
using CookBookHub.Infrastructure.Data;

namespace CookBookHub.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly CookBookDbContext _context;
    private readonly IRepository<Category> _categoryRepository;

    public CategoryService(CookBookDbContext context, IRepository<Category> categoryRepository)
    {
        _context = context;
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _context.Categories
            .Include(c => c.Recipes)
            .ToListAsync(cancellationToken);

        return categories.Select(c => new CategoryDto(
            c.Id,
            c.Name,
            c.Description,
            c.IconUrl,
            c.Recipes.Count
        ));
    }

    public async Task<CategoryDto?> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await _context.Categories
            .Include(c => c.Recipes)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (category == null)
            return null;

        return new CategoryDto(
            category.Id,
            category.Name,
            category.Description,
            category.IconUrl,
            category.Recipes.Count
        );
    }

    public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto, CancellationToken cancellationToken = default)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            IconUrl = dto.IconUrl,
            CreatedAt = DateTime.UtcNow
        };

        await _categoryRepository.AddAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CategoryDto(category.Id, category.Name, category.Description, category.IconUrl, 0);
    }

    public async Task UpdateCategoryAsync(Guid id, CreateCategoryDto dto, CancellationToken cancellationToken = default)
    {
        var category = await _categoryRepository.GetByIdAsync(id, cancellationToken);
        if (category == null)
            throw new KeyNotFoundException($"Category with ID {id} not found");

        category.Name = dto.Name;
        category.Description = dto.Description;
        category.IconUrl = dto.IconUrl;

        await _categoryRepository.UpdateAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await _categoryRepository.GetByIdAsync(id, cancellationToken);
        if (category == null)
            throw new KeyNotFoundException($"Category with ID {id} not found");

        await _categoryRepository.DeleteAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
