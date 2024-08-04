using record_idea.Models;

namespace record_idea.Repositories;

public interface IIdeaRepository
{
    Task<List<Idea>> GetAsync();
    Task<Idea?> GetAsync(string id);
    Task CreateAsync(Idea newIdea);
    Task UpdateAsync(string id, Idea updatedIdea);
    Task RemoveAsync(string id);
}