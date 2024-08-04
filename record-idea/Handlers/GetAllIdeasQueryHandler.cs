using MediatR;
using record_idea.Models;
using record_idea.Queries;
using record_idea.Repositories;
using record_idea.Utilities;

namespace record_idea.Handlers;

public class GetAllIdeasQueryHandler : IRequestHandler<GetAllIdeasQuery, Result<List<Idea>>>
{
    private readonly IIdeaRepository _ideaRepository;

    public GetAllIdeasQueryHandler(IIdeaRepository ideaRepository)
    {
        _ideaRepository = ideaRepository;
    }

    public async Task<Result<List<Idea>>> Handle(GetAllIdeasQuery request, CancellationToken cancellationToken)
    {
        var ideas = await _ideaRepository.GetAsync();
        return Result<List<Idea>>.Success(ideas);
    }
}