using record_idea.Models;
using record_idea.Repositories;

namespace record_idea.Services;

public class IdeaService
{
    private readonly IIdeaRepository _ideaRepository;

    public IdeaService(IIdeaRepository ideaRepository)
    {
        _ideaRepository = ideaRepository;
    }

    public async Task<List<Idea>> GetAsync() =>
        await _ideaRepository.GetAsync();

    public async Task<Idea?> GetAsync(string id) =>
        await _ideaRepository.GetAsync(id);

    public async Task CreateAsync(Idea newIdea) =>
        await _ideaRepository.CreateAsync(newIdea);

    public async Task UpdateAsync(string id, Idea updatedIdea) =>
        await _ideaRepository.UpdateAsync(id, updatedIdea);

    public async Task RemoveAsync(string id) =>
        await _ideaRepository.RemoveAsync(id);
}