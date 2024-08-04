using MediatR;
using record_idea.Utilities;

namespace record_idea.Commands;

public record DeleteIdeaCommand(string Id) : IRequest<Result<bool>>;