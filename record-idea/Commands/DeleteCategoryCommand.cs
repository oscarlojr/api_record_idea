using MediatR;
using record_idea.Utilities;

namespace record_idea.Commands;

public class DeleteCategoryCommand : IRequest<Result>
{
    public string Id { get; set; }
}