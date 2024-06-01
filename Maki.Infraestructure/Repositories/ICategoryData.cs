namespace _3_Data.Models;

public interface ICategoryData
{
    Task<List<Category>> GetAllAsync();
    
    Category GetById(int id);
    
    Task<Category> GetByNameAsync(string name);
    
    Task<List<Product>> GetProductsByCategoryAsync(string name);
    
    Task<int> SaveAsync(Category data);
    
    Task<bool> UpdateAsync(Category data, int id);
    
    Task<bool> DeleteAsync(int id);
}