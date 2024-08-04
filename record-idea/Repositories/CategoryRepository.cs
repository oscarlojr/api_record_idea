using Microsoft.Extensions.Options;
using MongoDB.Driver;
using record_idea.Models;
using record_idea.Configurations;

namespace record_idea.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IMongoCollection<Category> _categoriesCollection;

    public CategoryRepository(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _categoriesCollection = mongoDatabase.GetCollection<Category>(databaseSettings.Value.CategoriesCollectionName);
    }

    public async Task<List<Category>> GetAllAsync() =>
        await _categoriesCollection.Find(_ => true).ToListAsync();

    public async Task<Category> GetByIdAsync(string id) =>
        await _categoriesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task AddAsync(Category category) =>
        await _categoriesCollection.InsertOneAsync(category);

    public async Task UpdateAsync(Category category) =>
        await _categoriesCollection.ReplaceOneAsync(x => x.Id == category.Id, category);

    public async Task DeleteAsync(string id) =>
        await _categoriesCollection.DeleteOneAsync(x => x.Id == id);
}