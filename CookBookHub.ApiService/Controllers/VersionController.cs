using Microsoft.AspNetCore.Mvc;

namespace CookBookHub.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VersionController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            version = "1.0.0",
            releaseDate = "2023-03-31",
            environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production",
            features = new[]
            {
                "Recipe CRUD",
                "User Profiles",
                "Categories",
                "Reviews & Ratings",
                "Search",
                "Favorites"
            }
        });
    }
}
