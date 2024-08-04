using MediatR;
using record_idea.Models;
using record_idea.Utilities;

namespace record_idea.Commands;

public record UpdateIdeaCommand(string Id, Idea UpdatedIdea) : IRequest<Result<Idea>>;