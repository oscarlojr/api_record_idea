using MediatR;
using record_idea.Commands;
using record_idea.Models;
using record_idea.Repositories;
using record_idea.Utilities;

namespace record_idea.Handlers;

public class CreateIdeaCommandHandler : IRequestHandler<CreateIdeaCommand, Result<Idea>>
{
    private readonly IIdeaRepository _ideaRepository;

    public CreateIdeaCommandHandler(IIdeaRepository ideaRepository)
    {
        _ideaRepository = ideaRepository;
    }

    public async Task<Result<Idea>> Handle(CreateIdeaCommand request, CancellationToken cancellationToken)
    {
        var newIdea = request.NewIdea;

        if (string.IsNullOrEmpty(newIdea.Id))
        {
            newIdea.Id = Guid.NewGuid().ToString();
        }

        await _ideaRepository.CreateAsync(newIdea);
        return Result<Idea>.Success(newIdea);
    }
}