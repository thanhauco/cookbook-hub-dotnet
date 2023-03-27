# Performance Optimization Guide

## Overview
This guide covers performance optimization strategies for CookBook Hub.

## Database Optimization

### Indexing
```csharp
// Add indexes for frequently queried fields
modelBuilder.Entity<Recipe>(entity =>
{
    entity.HasIndex(e => e.Title);
    entity.HasIndex(e => e.CategoryId);
    entity.HasIndex(e => e.UserId);
    entity.HasIndex(e => e.CreatedAt);
});
```

### Query Optimization
```csharp
// Use AsNoTracking for read-only queries
var recipes = await _context.Recipes
    .AsNoTracking()
    .Include(r => r.Category)
    .ToListAsync();

// Use projection to select only needed fields
var recipeTitles = await _context.Recipes
    .Select(r => new { r.Id, r.Title })
    .ToListAsync();
```

### Pagination
```csharp
public async Task<PagedResult<RecipeDto>> GetRecipesAsync(int page, int pageSize)
{
    var query = _context.Recipes.AsQueryable();
    var total = await query.CountAsync();
    
    var recipes = await query
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();
    
    return new PagedResult<RecipeDto>
    {
        Items = recipes.Select(MapToDto),
        TotalCount = total,
        Page = page,
        PageSize = pageSize
    };
}
```

## API Optimization

### Response Caching
```csharp
[ResponseCache(Duration = 300)] // Cache for 5 minutes
[HttpGet]
public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
{
    return Ok(await _categoryService.GetAllCategoriesAsync());
}
```

### Compression
```csharp
// In Program.cs
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<GzipCompressionProvider>();
});
```

### Rate Limiting
```csharp
builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: context.User.Identity?.Name ?? context.Request.Headers.Host.ToString(),
            factory: partition => new FixedWindowRateLimiterOptions
            {
                AutoReplenishment = true,
                PermitLimit = 100,
                Window = TimeSpan.FromMinutes(1)
            }));
});
```

## Frontend Optimization

### Lazy Loading
```razor
@* Load components only when needed *@
<LazyLoad>
    <RecipeList />
</LazyLoad>
```

### Image Optimization
- Use WebP format
- Implement lazy loading
- Use responsive images
- Compress images before upload

### Bundle Optimization
```xml
<PropertyGroup>
    <BlazorWebAssemblyEnableLinking>true</BlazorWebAssemblyEnableLinking>
    <BlazorWebAssemblyLoadAllGlobalizationData>false</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

## Caching Strategies

### Memory Cache
```csharp
public class CachedRecipeService : IRecipeService
{
    private readonly IRecipeService _inner;
    private readonly IMemoryCache _cache;

    public async Task<RecipeDto> GetRecipeByIdAsync(Guid id)
    {
        return await _cache.GetOrCreateAsync($"recipe_{id}", async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
            return await _inner.GetRecipeByIdAsync(id);
        });
    }
}
```

### Distributed Cache (Redis)
```csharp
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "CookBookHub_";
});
```

## Monitoring

### Application Insights
```csharp
builder.Services.AddApplicationInsightsTelemetry();
```

### Custom Metrics
```csharp
public class PerformanceMetrics
{
    private static readonly Counter RecipeCreated = Metrics.CreateCounter(
        "recipes_created_total",
        "Total number of recipes created");

    public void TrackRecipeCreation()
    {
        RecipeCreated.Inc();
    }
}
```

## Best Practices

1. **Use async/await** throughout
2. **Implement pagination** for large datasets
3. **Add database indexes** for frequently queried fields
4. **Use caching** for expensive operations
5. **Optimize images** and static assets
6. **Enable compression** for API responses
7. **Monitor performance** with Application Insights
8. **Use CDN** for static content
9. **Implement rate limiting** to prevent abuse
10. **Profile regularly** to identify bottlenecks

## Performance Goals

- API response time: < 200ms (p95)
- Page load time: < 2s
- Database query time: < 50ms (p95)
- Time to Interactive: < 3s
