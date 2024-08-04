using MediatR;
using record_idea.Commands;
using record_idea.Models;
using record_idea.Repositories;
using record_idea.Utilities;

namespace record_idea.Handlers;

public class UpdateIdeaCommandHandler : IRequestHandler<UpdateIdeaCommand, Result<Idea>>
{
    private readonly IIdeaRepository _ideaRepository;

    public UpdateIdeaCommandHandler(IIdeaRepository ideaRepository)
    {
        _ideaRepository = ideaRepository;
    }

    public async Task<Result<Idea>> Handle(UpdateIdeaCommand request, CancellationToken cancellationToken)
    {
        var updatedIdea = request.UpdatedIdea;
        updatedIdea.Id = request.Id;

        await _ideaRepository.UpdateAsync(request.Id, updatedIdea);
        return Result<Idea>.Success(updatedIdea);
    }
}