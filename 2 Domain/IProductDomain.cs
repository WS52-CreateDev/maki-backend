using _3_Data.Models;

namespace _2_Domain;

public interface IProductDomain
{
    Task<bool> SaveAsync(Product data);
    /*
    bool Update(Product data, int id);

    bool Delete(int id);
    */
    Task<bool> UpdateAsync(Product data, int id);

    Task<bool> DeleteAsync(int id);
    
}