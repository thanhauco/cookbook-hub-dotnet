using CookBookHub.Domain.Entities;

namespace CookBookHub.Domain.Specifications;

public class RecipeWithDetailsSpecification : BaseSpecification<Recipe>
{
    public RecipeWithDetailsSpecification(Guid id)
    {
        ApplyCriteria(r => r.Id == id);
        AddInclude(r => r.Category);
        AddInclude(r => r.User);
        AddInclude(r => r.Ingredients);
        AddInclude(r => r.Reviews);
    }
}

public class PublishedRecipesSpecification : BaseSpecification<Recipe>
{
    public PublishedRecipesSpecification()
    {
        ApplyCriteria(r => r.IsPublished);
        ApplyOrderByDescending(r => r.CreatedAt);
        AddInclude(r => r.Category);
        AddInclude(r => r.User);
    }
}

public class RecipesByCategorySpecification : BaseSpecification<Recipe>
{
    public RecipesByCategorySpecification(Guid categoryId)
    {
        ApplyCriteria(r => r.CategoryId == categoryId && r.IsPublished);
        ApplyOrderByDescending(r => r.CreatedAt);
        AddInclude(r => r.User);
    }
}

public class RecipesByUserSpecification : BaseSpecification<Recipe>
{
    public RecipesByUserSpecification(Guid userId)
    {
        ApplyCriteria(r => r.UserId == userId);
        ApplyOrderByDescending(r => r.CreatedAt);
        AddInclude(r => r.Category);
    }
}
