
using _3_Data;
using _3_Data.Models;

namespace _2_Domain;

public class ProductDomain : IProductDomain
{
    private IProductData _productData;
    
    public ProductDomain(IProductData productData)
    {
        _productData = productData;
    }

    public bool Save(Product data)
    {
        return _productData.Save(data);
    }
    
    public bool Update(Product data, int id)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}