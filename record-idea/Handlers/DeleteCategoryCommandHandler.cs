using MediatR;
using record_idea.Commands;
using record_idea.Services;
using record_idea.Utilities;

namespace record_idea.Handlers;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result>
{
    private readonly CategoryService _categoryService;

    public DeleteCategoryCommandHandler(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _categoryService.RemoveAsync(request.Id);
    }
}