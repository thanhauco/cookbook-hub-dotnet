namespace CookBookHub.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
    
    // Navigation properties
    public List<Recipe> Recipes { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
    public List<RecipeFavorite> FavoriteRecipes { get; set; } = new();
}
