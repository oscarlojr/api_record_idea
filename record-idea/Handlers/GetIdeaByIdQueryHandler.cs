using MediatR;
using record_idea.Models;
using record_idea.Queries;
using record_idea.Repositories;
using record_idea.Utilities;

namespace record_idea.Handlers;

public class GetIdeaByIdQueryHandler : IRequestHandler<GetIdeaByIdQuery, Result<Idea>>
{
    private readonly IIdeaRepository _ideaRepository;

    public GetIdeaByIdQueryHandler(IIdeaRepository ideaRepository)
    {
        _ideaRepository = ideaRepository;
    }

    public async Task<Result<Idea>> Handle(GetIdeaByIdQuery request, CancellationToken cancellationToken)
    {
        var idea = await _ideaRepository.GetAsync(request.Id);
        if (idea == null)
        {
            return Result<Idea>.Failure("Idea not found");
        }

        return Result<Idea>.Success(idea);
    }
}