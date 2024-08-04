using MediatR;
using record_idea.Commands;
using record_idea.Repositories;
using record_idea.Utilities;

namespace record_idea.Handlers;

public class DeleteIdeaCommandHandler : IRequestHandler<DeleteIdeaCommand, Result<bool>>
{
    private readonly IIdeaRepository _ideaRepository;

    public DeleteIdeaCommandHandler(IIdeaRepository ideaRepository)
    {
        _ideaRepository = ideaRepository;
    }

    public async Task<Result<bool>> Handle(DeleteIdeaCommand request, CancellationToken cancellationToken)
    {
        await _ideaRepository.RemoveAsync(request.Id);
        return Result<bool>.Success(true);
    }
}