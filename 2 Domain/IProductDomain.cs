using _3_Data.Models;

namespace _2_Domain;

public interface IProductDomain
{
    bool Save(Product data);

    bool Update(Product data, int id);
    
    bool Delete(int id);
}