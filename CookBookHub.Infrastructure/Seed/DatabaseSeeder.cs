using CookBookHub.Domain.Entities;
using CookBookHub.Infrastructure.Data;

namespace CookBookHub.Infrastructure.Seed;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(CookBookDbContext context)
    {
        if (context.Categories.Any())
            return;

        // Seed Categories
        var categories = new List<Category>
        {
            new() { Id = Guid.NewGuid(), Name = "Italian", Description = "Classic Italian cuisine", IconUrl = "🍝", CreatedAt = DateTime.UtcNow },
            new() { Id = Guid.NewGuid(), Name = "Asian", Description = "Flavors from Asia", IconUrl = "🍜", CreatedAt = DateTime.UtcNow },
            new() { Id = Guid.NewGuid(), Name = "Healthy", Description = "Nutritious and delicious", IconUrl = "🥗", CreatedAt = DateTime.UtcNow },
            new() { Id = Guid.NewGuid(), Name = "Desserts", Description = "Sweet treats", IconUrl = "🍰", CreatedAt = DateTime.UtcNow },
            new() { Id = Guid.NewGuid(), Name = "Mexican", Description = "Spicy and flavorful", IconUrl = "🌮", CreatedAt = DateTime.UtcNow },
            new() { Id = Guid.NewGuid(), Name = "American", Description = "Classic comfort food", IconUrl = "🍔", CreatedAt = DateTime.UtcNow }
        };

        await context.Categories.AddRangeAsync(categories);
        await context.SaveChangesAsync();

        // Seed Users
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Username = "chef_mario", Email = "mario@cookbook.com", FullName = "Mario Rossi", Bio = "Italian chef", AvatarUrl = "", CreatedAt = DateTime.UtcNow, IsActive = true },
            new() { Id = Guid.NewGuid(), Username = "thai_kitchen", Email = "thai@cookbook.com", FullName = "Somchai Lee", Bio = "Thai cuisine expert", AvatarUrl = "", CreatedAt = DateTime.UtcNow, IsActive = true },
            new() { Id = Guid.NewGuid(), Username = "sweet_treats", Email = "sweet@cookbook.com", FullName = "Emma Baker", Bio = "Pastry chef", AvatarUrl = "", CreatedAt = DateTime.UtcNow, IsActive = true }
        };

        await context.Users.AddRangeAsync(users);
        await context.SaveChangesAsync();

        // Seed Recipes
        var italianCategory = categories.First(c => c.Name == "Italian");
        var asianCategory = categories.First(c => c.Name == "Asian");
        var dessertCategory = categories.First(c => c.Name == "Desserts");

        var chefMario = users.First(u => u.Username == "chef_mario");
        var thaiKitchen = users.First(u => u.Username == "thai_kitchen");
        var sweetTreats = users.First(u => u.Username == "sweet_treats");

        var recipes = new List<Recipe>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Classic Spaghetti Carbonara",
                Description = "Authentic Italian pasta with eggs, cheese, and pancetta",
                Instructions = "1. Cook pasta\n2. Fry pancetta\n3. Mix eggs and cheese\n4. Combine all",
                PrepTimeMinutes = 10,
                CookTimeMinutes = 20,
                Servings = 4,
                Difficulty = DifficultyLevel.Easy,
                ImageUrl = "https://via.placeholder.com/800x500",
                CategoryId = italianCategory.Id,
                UserId = chefMario.Id,
                CreatedAt = DateTime.UtcNow,
                IsPublished = true
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Thai Green Curry",
                Description = "Spicy and aromatic Thai curry with coconut milk",
                Instructions = "1. Prepare curry paste\n2. Cook chicken\n3. Add vegetables\n4. Simmer with coconut milk",
                PrepTimeMinutes = 15,
                CookTimeMinutes = 30,
                Servings = 4,
                Difficulty = DifficultyLevel.Medium,
                ImageUrl = "https://via.placeholder.com/800x500",
                CategoryId = asianCategory.Id,
                UserId = thaiKitchen.Id,
                CreatedAt = DateTime.UtcNow,
                IsPublished = true
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Chocolate Lava Cake",
                Description = "Decadent chocolate cake with molten center",
                Instructions = "1. Melt chocolate and butter\n2. Mix with eggs and sugar\n3. Bake until edges are set\n4. Serve warm",
                PrepTimeMinutes = 15,
                CookTimeMinutes = 12,
                Servings = 2,
                Difficulty = DifficultyLevel.Medium,
                ImageUrl = "https://via.placeholder.com/800x500",
                CategoryId = dessertCategory.Id,
                UserId = sweetTreats.Id,
                CreatedAt = DateTime.UtcNow,
                IsPublished = true
            }
        };

        await context.Recipes.AddRangeAsync(recipes);
        await context.SaveChangesAsync();

        // Seed Ingredients
        var carbonara = recipes.First(r => r.Title.Contains("Carbonara"));
        var ingredients = new List<Ingredient>
        {
            new() { Id = Guid.NewGuid(), RecipeId = carbonara.Id, Name = "Spaghetti", Quantity = 400, Unit = "g", DisplayOrder = 1, Notes = "" },
            new() { Id = Guid.NewGuid(), RecipeId = carbonara.Id, Name = "Pancetta", Quantity = 200, Unit = "g", DisplayOrder = 2, Notes = "diced" },
            new() { Id = Guid.NewGuid(), RecipeId = carbonara.Id, Name = "Eggs", Quantity = 4, Unit = "large", DisplayOrder = 3, Notes = "" },
            new() { Id = Guid.NewGuid(), RecipeId = carbonara.Id, Name = "Pecorino Romano", Quantity = 100, Unit = "g", DisplayOrder = 4, Notes = "grated" }
        };

        await context.Ingredients.AddRangeAsync(ingredients);
        await context.SaveChangesAsync();
    }
}
