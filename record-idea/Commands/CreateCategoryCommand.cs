using MediatR;
using record_idea.Models;
using record_idea.Utilities;

namespace record_idea.Commands;

public class CreateCategoryCommand : IRequest<Result<Category>>
{
    public Category Category { get; set; }
}