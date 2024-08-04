using MediatR;
using record_idea.Models;
using record_idea.Utilities;

namespace record_idea.Commands;

public class UpdateCategoryCommand : IRequest<Result>
{
    public string Id { get; set; }
    public Category Category { get; set; }
}