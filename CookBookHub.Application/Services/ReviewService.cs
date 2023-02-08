using Microsoft.EntityFrameworkCore;
using CookBookHub.Application.DTOs;
using CookBookHub.Application.Interfaces;
using CookBookHub.Domain.Entities;
using CookBookHub.Domain.Interfaces;
using CookBookHub.Infrastructure.Data;

namespace CookBookHub.Application.Services;

public class ReviewService : IReviewService
{
    private readonly CookBookDbContext _context;
    private readonly IRepository<Review> _reviewRepository;

    public ReviewService(CookBookDbContext context, IRepository<Review> reviewRepository)
    {
        _context = context;
        _reviewRepository = reviewRepository;
    }

    public async Task<IEnumerable<ReviewDto>> GetReviewsByRecipeAsync(Guid recipeId, CancellationToken cancellationToken = default)
    {
        var reviews = await _context.Reviews
            .Include(r => r.User)
            .Where(r => r.RecipeId == recipeId)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync(cancellationToken);

        return reviews.Select(MapToDto);
    }

    public async Task<ReviewDto?> GetReviewByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var review = await _context.Reviews
            .Include(r => r.User)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

        return review == null ? null : MapToDto(review);
    }

    public async Task<ReviewDto> CreateReviewAsync(CreateReviewDto dto, CancellationToken cancellationToken = default)
    {
        var existingReview = await _context.Reviews
            .FirstOrDefaultAsync(r => r.RecipeId == dto.RecipeId && r.UserId == dto.UserId, cancellationToken);

        if (existingReview != null)
            throw new InvalidOperationException("User has already reviewed this recipe");

        var review = new Review
        {
            Id = Guid.NewGuid(),
            RecipeId = dto.RecipeId,
            UserId = dto.UserId,
            Rating = dto.Rating,
            Comment = dto.Comment,
            CreatedAt = DateTime.UtcNow
        };

        await _reviewRepository.AddAsync(review, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return await GetReviewByIdAsync(review.Id, cancellationToken)
            ?? throw new Exception("Failed to retrieve created review");
    }

    public async Task UpdateReviewAsync(Guid id, CreateReviewDto dto, CancellationToken cancellationToken = default)
    {
        var review = await _reviewRepository.GetByIdAsync(id, cancellationToken);
        if (review == null)
            throw new KeyNotFoundException($"Review with ID {id} not found");

        review.Rating = dto.Rating;
        review.Comment = dto.Comment;

        await _reviewRepository.UpdateAsync(review, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteReviewAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var review = await _reviewRepository.GetByIdAsync(id, cancellationToken);
        if (review == null)
            throw new KeyNotFoundException($"Review with ID {id} not found");

        await _reviewRepository.DeleteAsync(review, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    private static ReviewDto MapToDto(Review review)
    {
        return new ReviewDto(
            review.Id,
            review.RecipeId,
            review.UserId,
            review.User?.Username ?? string.Empty,
            review.Rating,
            review.Comment,
            review.CreatedAt
        );
    }
}
