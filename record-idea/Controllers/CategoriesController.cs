using Microsoft.AspNetCore.Mvc;
using record_idea.Models;
using record_idea.Services;

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
    public async Task<List<Category>> Get() =>
        await _categoryService.GetAsync();

    [HttpGet("get-category/{id}")]
    public async Task<ActionResult<Category>> Get(string id)
    {
        var category = await _categoryService.GetAsync(id);

        if (category is null)
        {
            return NotFound();
        }

        return category;
    }
    
    [HttpPost("create-category")]
    public async Task<IActionResult> Post(Category newCategory)
    {
        if (string.IsNullOrEmpty(newCategory.Id))
        {
            newCategory.Id = Guid.NewGuid().ToString();
        }

        await _categoryService.CreateAsync(newCategory);

        return CreatedAtAction(nameof(Get), new { id = newCategory.Id }, newCategory);
    }

    [HttpPut("update-category/{id}")]
    public async Task<IActionResult> Update(string id, Category updatedCategory) 
    {
        var category = await _categoryService.GetAsync(id);

        if (category is null) 
        {
            return NotFound();
        }

        updatedCategory.Id = category.Id;

        await _categoryService.UpdateAsync(id, updatedCategory);

        return NoContent();
    }

    [HttpDelete("delete-category/{id}")]
    public async Task<IActionResult> Delete(string id) 
    {
        var category = await _categoryService.GetAsync(id);

        if (category is null) 
        {
            return NotFound();
        }

        await _categoryService.RemoveAsync(id);

        return NoContent();
    }
}
