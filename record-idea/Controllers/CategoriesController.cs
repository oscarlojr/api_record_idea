using MediatR;
using Microsoft.AspNetCore.Mvc;
using record_idea.Commands;
using record_idea.Models;
using record_idea.Queries;
using record_idea.Utilities;

namespace record_idea.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all-categories")]
    public async Task<ActionResult<Result<List<Category>>>> Get()
    {
        var result = await _mediator.Send(new GetAllCategoriesQuery());
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        return Ok(result);
    }

    [HttpGet("get-category/{id}")]
    public async Task<ActionResult<Result<Category>>> Get(string id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery { Id = id });
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

        var result = await _mediator.Send(new CreateCategoryCommand { Category = newCategory });
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
        var result = await _mediator.Send(new UpdateCategoryCommand { Id = id, Category = updatedCategory });
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }

    [HttpDelete("delete-category/{id}")]
    public async Task<ActionResult<Result>> Delete(string id)
    {
        var result = await _mediator.Send(new DeleteCategoryCommand { Id = id });
        if (!result.IsSuccess)
        {
            return NotFound(result.Message);
        }

        return NoContent();
    }
}
