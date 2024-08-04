using Microsoft.AspNetCore.Mvc;
using record_idea.Models;
using record_idea.Services;

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
    public async Task<List<Idea>> Get() =>
        await _ideaService.GetAsync();

    [HttpGet("get-idea/{id}")]
    public async Task<ActionResult<Idea>> Get(string id)
    {
        var idea = await _ideaService.GetAsync(id);

        if (idea is null)
        {
            return NotFound();
        }

        return idea;
    }

    [HttpPost("create-idea")]
    public async Task<IActionResult> Post(Idea newIdea)
    {
        var category = await _categoryService.GetAsync(newIdea.CategoryId);

        if (category == null)
        {
            return BadRequest("Invalid CategoryId");
        }
        
        if (string.IsNullOrEmpty(newIdea.Id))
        {
            newIdea.Id = Guid.NewGuid().ToString();
        }

        newIdea.CategoryName = category.Name;
        newIdea.SetCreatedAt();
        await _ideaService.CreateAsync(newIdea);

        return CreatedAtAction(nameof(Get), new { id = newIdea.Id }, newIdea);
    }

    [HttpPut("update-idea/{id}")]
    public async Task<IActionResult> Update(string id, Idea updatedIdea)
    {
        var idea = await _ideaService.GetAsync(id);

        if (idea is null)
        {
            return NotFound();
        }

        var category = await _categoryService.GetAsync(updatedIdea.CategoryId);

        if (category == null)
        {
            return BadRequest("Invalid CategoryId");
        }

        updatedIdea.CategoryName = category.Name;
        updatedIdea.Id = idea.Id;

        await _ideaService.UpdateAsync(id, updatedIdea);

        return NoContent();
    }

    [HttpDelete("delete-idea/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var idea = await _ideaService.GetAsync(id);

        if (idea is null)
        {
            return NotFound();
        }

        await _ideaService.RemoveAsync(id);

        return NoContent();
    }
}