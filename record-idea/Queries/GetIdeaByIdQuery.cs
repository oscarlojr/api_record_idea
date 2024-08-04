using MediatR;
using record_idea.Models;
using record_idea.Utilities;

namespace record_idea.Queries;

public record GetIdeaByIdQuery(string Id) : IRequest<Result<Idea>>;