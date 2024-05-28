using _3_Data.Models;

namespace _2_Domain;

public class CategoryDomain : ICategoryDomain
{
    private ICategoryData _categoryData;
    
    public CategoryDomain(ICategoryData categoryData)
    {
        _categoryData = categoryData;
    }

    public async Task<bool> SaveAsync(Category data)
    {
        //add business rules
        var product = await _categoryData.GetByNameAsync(data.Name);
        if (product!= null)
        {
            throw new Exception("Name already exists.");
        }
        
        return await _categoryData.SaveAsync(data);
    }

    public async Task<bool> UpdateAsync(Category data, int id)
    {
        return await _categoryData.UpdateAsync(data, id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _categoryData.DeleteAsync(id);
    }
    
}