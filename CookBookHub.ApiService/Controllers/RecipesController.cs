using Microsoft.AspNetCore.Mvc;
using CookBookHub.Application.DTOs;
using CookBookHub.Application.Interfaces;

namespace CookBookHub.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly IRecipeService _recipeService;

    public RecipesController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecipeDto>>> GetAll(CancellationToken cancellationToken)
    {
        var recipes = await _recipeService.GetAllRecipesAsync(cancellationToken);
        return Ok(recipes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RecipeDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var recipe = await _recipeService.GetRecipeByIdAsync(id, cancellationToken);
        if (recipe == null)
            return NotFound();

        return Ok(recipe);
    }

    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult<IEnumerable<RecipeDto>>> GetByCategory(Guid categoryId, CancellationToken cancellationToken)
    {
        var recipes = await _recipeService.GetRecipesByCategoryAsync(categoryId, cancellationToken);
        return Ok(recipes);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<RecipeDto>>> GetByUser(Guid userId, CancellationToken cancellationToken)
    {
        var recipes = await _recipeService.GetRecipesByUserAsync(userId, cancellationToken);
        return Ok(recipes);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<RecipeDto>>> Search([FromQuery] string q, CancellationToken cancellationToken)
    {
        var recipes = await _recipeService.SearchRecipesAsync(q, cancellationToken);
        return Ok(recipes);
    }

    [HttpPost]
    public async Task<ActionResult<RecipeDto>> Create([FromBody] CreateRecipeDto dto, CancellationToken cancellationToken)
    {
        var recipe = await _recipeService.CreateRecipeAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = recipe.Id }, recipe);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRecipeDto dto, CancellationToken cancellationToken)
    {
        await _recipeService.UpdateRecipeAsync(id, dto, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _recipeService.DeleteRecipeAsync(id, cancellationToken);
        return NoContent();
    }
}
