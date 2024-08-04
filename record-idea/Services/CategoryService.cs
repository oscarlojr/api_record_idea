using record_idea.Models;
using record_idea.Repositories;

namespace record_idea.Services;

public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> GetAsync() =>
        await _categoryRepository.GetAllAsync();

    public async Task<Category?> GetAsync(string id) =>
        await _categoryRepository.GetByIdAsync(id);

    public async Task CreateAsync(Category newCategory)
    {
        await _categoryRepository.AddAsync(newCategory);
    }

    public async Task UpdateAsync(string id, Category updatedCategory) =>
        await _categoryRepository.UpdateAsync(updatedCategory);

    public async Task RemoveAsync(string id) =>
        await _categoryRepository.DeleteAsync(id);
}