using record_idea.Models;
using record_idea.Repositories;
using record_idea.Utilities;

namespace record_idea.Services;

public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<List<Category>>> GetAsync()
    {
        try
        {
            var categories = await _categoryRepository.GetAsync();
            return Result<List<Category>>.Success(categories);
        }
        catch (Exception ex)
        {
            return Result<List<Category>>.Failure($"Error retrieving categories: {ex.Message}");
        }
    }

    public async Task<Result<Category>> GetAsync(string id)
    {
        try
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
            {
                return Result<Category>.Failure("Category not found");
            }
            return Result<Category>.Success(category);
        }
        catch (Exception ex)
        {
            return Result<Category>.Failure($"Error retrieving category: {ex.Message}");
        }
    }

    public async Task<Result<Category>> CreateAsync(Category newCategory)
    {
        try
        {
            await _categoryRepository.CreateAsync(newCategory);
            return Result<Category>.Success(newCategory);
        }
        catch (Exception ex)
        {
            return Result<Category>.Failure($"Error creating category: {ex.Message}");
        }
    }

    public async Task<Result> UpdateAsync(string id, Category updatedCategory)
    {
        try
        {
            var existingCategory = await _categoryRepository.GetAsync(id);
            if (existingCategory == null)
            {
                return Result.Failure("Category not found");
            }

            await _categoryRepository.UpdateAsync(id, updatedCategory);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Error updating category: {ex.Message}");
        }
    }

    public async Task<Result> RemoveAsync(string id)
    {
        try
        {
            var existingCategory = await _categoryRepository.GetAsync(id);
            if (existingCategory == null)
            {
                return Result.Failure("Category not found");
            }

            await _categoryRepository.RemoveAsync(id);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Error deleting category: {ex.Message}");
        }
    }
}
