using _3_Data.Models;

namespace _3_Data;

public interface IProductData
{
    List<Product> GetAll();
    
    Product GetById(int id);
    
    bool Save(Product data);
    
    bool Update(Product data, int id);
    
    bool Delete(int id);
    
}