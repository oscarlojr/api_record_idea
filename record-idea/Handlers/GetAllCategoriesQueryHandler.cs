using MediatR;
using record_idea.Models;
using record_idea.Queries;
using record_idea.Services;
using record_idea.Utilities;

namespace record_idea.Handlers;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, Result<List<Category>>>
{
    private readonly CategoryService _categoryService;

    public GetAllCategoriesQueryHandler(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<Result<List<Category>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _categoryService.GetAsync();
    }
}