using Microsoft.AspNetCore.Mvc;
using record_idea.Models;
using record_idea.Services;
using record_idea.Utilities;

namespace record_idea.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly CategoryService _categoryService;

    public CategoriesController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("get-all-categories")]
    public async Task<ActionResult<Result<List<Category>>>> Get()
    {
        var result = await _categoryService.GetAsync();
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        return Ok(result);
    }

    [HttpGet("get-category/{id}")]
    public async Task<ActionResult<Result<Category>>> Get(string id)
    {
        var result = await _categoryService.GetAsync(id);
        if (!result.IsSuccess)
        {
            return NotFound(result.Message);
        }
        return Ok(result);
    }

    [HttpPost("create-category")]
    public async Task<ActionResult<Result<Category>>> Post(Category newCategory)
    {
        if (string.IsNullOrEmpty(newCategory.Id))
        {
            newCategory.Id = Guid.NewGuid().ToString();
        }

        var result = await _categoryService.CreateAsync(newCategory);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return CreatedAtAction(nameof(Get), new { id = newCategory.Id }, result);
    }

    [HttpPut("update-category/{id}")]
    public async Task<ActionResult<Result>> Update(string id, Category updatedCategory)
    {
        updatedCategory.Id = id;
        var result = await _categoryService.UpdateAsync(id, updatedCategory);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }

    [HttpDelete("delete-category/{id}")]
    public async Task<ActionResult<Result>> Delete(string id)
    {
        var result = await _categoryService.RemoveAsync(id);
        if (!result.IsSuccess)
        {
            return NotFound(result.Message);
        }

        return NoContent();
    }
}
