using _3_Data.Models;

namespace _3_Data;

public interface IProductData
{
    Task<List<Product>> GetAllAsync();
    
    Product GetById(int id);
    
    Task<Product> GetByNameAsync(string name);
    
    Task<int> SaveAsync(Product data);

    Task<bool> UpdateAsync(Product data, int id);

    Task<bool> DeleteAsync(int id);
    
}