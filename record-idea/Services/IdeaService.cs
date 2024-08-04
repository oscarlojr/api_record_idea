using record_idea.Models;
using record_idea.Repositories;
using record_idea.Utilities;

namespace record_idea.Services;

public class IdeaService
{
    private readonly IIdeaRepository _ideaRepository;

    public IdeaService(IIdeaRepository ideaRepository)
    {
        _ideaRepository = ideaRepository;
    }

    public async Task<Result<List<Idea>>> GetAsync()
    {
        var ideas = await _ideaRepository.GetAsync();
        return Result<List<Idea>>.Success(ideas);
    }

    public async Task<Result<Idea>> GetAsync(string id)
    {
        var idea = await _ideaRepository.GetAsync(id);
        if (idea == null)
        {
            return Result<Idea>.Failure("Idea not found.");
        }
        return Result<Idea>.Success(idea);
    }

    public async Task<Result<Idea>> CreateAsync(Idea newIdea)
    {
        await _ideaRepository.CreateAsync(newIdea);
        return Result<Idea>.Success(newIdea);
    }

    public async Task<Result> UpdateAsync(string id, Idea updatedIdea)
    {
        var idea = await _ideaRepository.GetAsync(id);
        if (idea == null)
        {
            return Result.Failure("Idea not found.");
        }
        await _ideaRepository.UpdateAsync(id, updatedIdea);
        return Result.Success();
    }

    public async Task<Result> RemoveAsync(string id)
    {
        var idea = await _ideaRepository.GetAsync(id);
        if (idea == null)
        {
            return Result.Failure("Idea not found.");
        }
        await _ideaRepository.RemoveAsync(id);
        return Result.Success();
    }
}