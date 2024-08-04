using MediatR;
using record_idea.Models;
using record_idea.Utilities;

namespace record_idea.Commands;

public record CreateIdeaCommand(Idea NewIdea) : IRequest<Result<Idea>>;