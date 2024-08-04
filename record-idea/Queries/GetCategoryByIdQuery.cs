using MediatR;
using record_idea.Models;
using record_idea.Utilities;

namespace record_idea.Queries;
    
public class GetCategoryByIdQuery : IRequest<Result<Category>>
{
    public string Id { get; set; }
}