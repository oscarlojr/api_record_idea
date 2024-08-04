using MediatR;
using record_idea.Commands;
using record_idea.Services;
using record_idea.Utilities;

namespace record_idea.Handlers;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result>
{
    private readonly CategoryService _categoryService;

    public UpdateCategoryCommandHandler(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _categoryService.UpdateAsync(request.Id, request.Category);
    }
}