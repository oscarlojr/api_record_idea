using MediatR;
using record_idea.Commands;
using record_idea.Models;
using record_idea.Services;
using record_idea.Utilities;

namespace record_idea.Handlers;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<Category>>
{
    private readonly CategoryService _categoryService;

    public CreateCategoryCommandHandler(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<Result<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _categoryService.CreateAsync(request.Category);
    }
}