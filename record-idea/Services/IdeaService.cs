using Microsoft.Extensions.Options;
using MongoDB.Driver;
using record_idea.Configurations;
using record_idea.Models;

namespace record_idea.Services;

public class IdeaService
{
    private readonly IMongoCollection<Idea> _ideasCollection;

    public IdeaService(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);

        _ideasCollection = mongoDatabase.GetCollection<Idea>(
            databaseSettings.Value.IdeasCollectionName);
    }

    public async Task<List<Idea>> GetAsync() =>
        await _ideasCollection.Find(_ => true).ToListAsync();

    public async Task<Idea?> GetAsync(string id) =>
        await _ideasCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Idea newIdea) =>
        await _ideasCollection.InsertOneAsync(newIdea);

    public async Task UpdateAsync(string id, Idea updatedIdea) =>
        await _ideasCollection.ReplaceOneAsync(x => x.Id == id, updatedIdea);

    public async Task RemoveAsync(string id) =>
        await _ideasCollection.DeleteOneAsync(x => x.Id == id);
}