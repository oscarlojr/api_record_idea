using MediatR;
using record_idea.Models;
using record_idea.Utilities;

namespace record_idea.Queries;

public record GetAllIdeasQuery : IRequest<Result<List<Idea>>>;