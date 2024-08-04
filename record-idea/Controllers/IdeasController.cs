using Microsoft.AspNetCore.Mvc;
using record_idea.Models;
using record_idea.Services;
using record_idea.Utilities;

namespace record_idea.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdeasController : ControllerBase
{
    private readonly IdeaService _ideaService;
    private readonly CategoryService _categoryService;

    public IdeasController(IdeaService ideaService, CategoryService categoryService)
    {
        _ideaService = ideaService;
        _categoryService = categoryService;
    }

    [HttpGet("get-all-ideas")]
    public async Task<ActionResult<Result<List<Idea>>>> Get()
    {
        var result = await _ideaService.GetAsync();
        return Ok(result);
    }

    [HttpGet("get-idea/{id}")]
    public async Task<ActionResult<Result<Idea>>> Get(string id)
    {
        var result = await _ideaService.GetAsync(id);
        if (!result.IsSuccess)
        {
            return NotFound(result);
        }
        return Ok(result);
    }

    [HttpPost("create-idea")]
    public async Task<ActionResult<Result<Idea>>> Post(Idea newIdea)
    {
        var categoryResult = await _categoryService.GetAsync(newIdea.CategoryId);

        if (!categoryResult.IsSuccess)
        {
            return BadRequest(categoryResult);
        }

        if (string.IsNullOrEmpty(newIdea.Id))
        {
            newIdea.Id = Guid.NewGuid().ToString();
        }

        newIdea.CategoryName = categoryResult.Value.Name;
        newIdea.SetCreatedAt();
        var result = await _ideaService.CreateAsync(newIdea);

        return CreatedAtAction(nameof(Get), new { id = newIdea.Id }, result);
    }

    [HttpPut("update-idea/{id}")]
    public async Task<ActionResult<Result>> Update(string id, Idea updatedIdea)
    {
        var ideaResult = await _ideaService.GetAsync(id);

        if (!ideaResult.IsSuccess)
        {
            return NotFound(ideaResult);
        }

        var categoryResult = await _categoryService.GetAsync(updatedIdea.CategoryId);

        if (!categoryResult.IsSuccess)
        {
            return BadRequest(categoryResult);
        }

        updatedIdea.CategoryName = categoryResult.Value.Name;
        updatedIdea.Id = ideaResult.Value.Id;

        var result = await _ideaService.UpdateAsync(id, updatedIdea);

        return NoContent();
    }

    [HttpDelete("delete-idea/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var ideaResult = await _ideaService.GetAsync(id);

        if (!ideaResult.IsSuccess)
        {
            return NotFound(ideaResult);
        }

        var result = await _ideaService.RemoveAsync(id);

        return NoContent();
    }
}
