using _3_Data.Models;

namespace _3_Data;

public interface IProductData
{
    Task<List<Product>> GetAllAsync();
    
    Product GetById(int id);
    
    Task<Product> GetByNameAsync(string name);
    
    Task<bool> SaveAsync(Product data);
    /*
    bool Update(Product data, int id);

    bool Delete(int id);
    */
    Task<bool> UpdateAsync(Product data, int id);

    Task<bool> DeleteAsync(int id);
    
}