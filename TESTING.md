# Testing Guide

## Overview
This guide covers testing strategies for CookBook Hub.

## Test Structure

```
CookBookHub.Tests/
├── Unit/
│   ├── Services/
│   ├── Validators/
│   └── Repositories/
├── Integration/
│   ├── API/
│   └── Database/
└── E2E/
    └── UI/
```

## Unit Tests

### Testing Services

```csharp
using Xunit;
using Moq;
using CookBookHub.Application.Services;

public class RecipeServiceTests
{
    [Fact]
    public async Task CreateRecipe_ValidData_ReturnsRecipeDto()
    {
        // Arrange
        var mockRepository = new Mock<IRepository<Recipe>>();
        var service = new RecipeService(mockRepository.Object);
        var dto = new CreateRecipeDto { Title = "Test Recipe" };

        // Act
        var result = await service.CreateRecipeAsync(dto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test Recipe", result.Title);
    }
}
```

### Testing Validators

```csharp
using FluentValidation.TestHelper;
using Xunit;

public class CreateRecipeDtoValidatorTests
{
    private readonly CreateRecipeDtoValidator _validator;

    public CreateRecipeDtoValidatorTests()
    {
        _validator = new CreateRecipeDtoValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Title_Is_Empty()
    {
        var model = new CreateRecipeDto { Title = "" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Title);
    }
}
```

## Integration Tests

### Testing API Endpoints

```csharp
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class RecipesControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public RecipesControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetRecipes_ReturnsSuccessStatusCode()
    {
        var response = await _client.GetAsync("/api/recipes");
        response.EnsureSuccessStatusCode();
    }
}
```

### Testing Database Operations

```csharp
using Microsoft.EntityFrameworkCore;
using Xunit;

public class RecipeRepositoryTests
{
    [Fact]
    public async Task AddRecipe_SavesToDatabase()
    {
        var options = new DbContextOptionsBuilder<CookBookDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        using var context = new CookBookDbContext(options);
        var repository = new Repository<Recipe>(context);
        
        var recipe = new Recipe { Title = "Test" };
        await repository.AddAsync(recipe);
        await context.SaveChangesAsync();

        Assert.Equal(1, await context.Recipes.CountAsync());
    }
}
```

## E2E Tests

### Using Playwright

```csharp
using Microsoft.Playwright;
using Xunit;

public class RecipeFlowTests
{
    [Fact]
    public async Task CreateRecipe_FullFlow_Success()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync();
        var page = await browser.NewPageAsync();

        await page.GotoAsync("http://localhost:5001");
        await page.ClickAsync("text=Create Recipe");
        await page.FillAsync("#title", "Test Recipe");
        await page.ClickAsync("text=Publish");

        await page.WaitForSelectorAsync("text=Recipe created successfully");
    }
}
```

## Running Tests

### All Tests
```bash
dotnet test
```

### Specific Category
```bash
dotnet test --filter Category=Unit
dotnet test --filter Category=Integration
```

### With Coverage
```bash
dotnet test /p:CollectCoverage=true /p:CoverageReportFormat=opencover
```

## Best Practices

1. **AAA Pattern**: Arrange, Act, Assert
2. **One Assert Per Test**: Keep tests focused
3. **Descriptive Names**: Use clear test method names
4. **Test Data Builders**: Use builders for complex test data
5. **Mock External Dependencies**: Isolate unit tests
6. **Clean Up**: Dispose resources properly
7. **Async Tests**: Use async/await for async code

## CI/CD Integration

Tests run automatically on:
- Pull requests
- Pushes to main branch
- Scheduled nightly builds

## Code Coverage Goals

- Overall: 80%+
- Services: 90%+
- Validators: 95%+
- Controllers: 70%+
