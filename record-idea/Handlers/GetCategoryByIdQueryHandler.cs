using MediatR;
using record_idea.Models;
using record_idea.Queries;
using record_idea.Services;
using record_idea.Utilities;

namespace record_idea.Handlers;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<Category>>
{
    private readonly CategoryService _categoryService;

    public GetCategoryByIdQueryHandler(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<Result<Category>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        return await _categoryService.GetAsync(request.Id);
    }
}