namespace CookBookHub.Domain.Entities;

public class Ingredient
{
    public Guid Id { get; set; }
    public Guid RecipeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
    
    // Navigation properties
    public Recipe Recipe { get; set; } = null!;
}

public class Review
{
    public Guid Id { get; set; }
    public Guid RecipeId { get; set; }
    public Guid UserId { get; set; }
    public int Rating { get; set; } // 1-5 stars
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    
    // Navigation properties
    public Recipe Recipe { get; set; } = null!;
    public User User { get; set; } = null!;
}

public class RecipeFavorite
{
    public Guid Id { get; set; }
    public Guid RecipeId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    
    // Navigation properties
    public Recipe Recipe { get; set; } = null!;
    public User User { get; set; } = null!;
}
