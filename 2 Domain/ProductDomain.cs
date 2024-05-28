
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

    public async Task<bool> SaveAsync(Product data)
    {
        //add business rules
        var product = await _productData.GetByNameAsync(data.Name);
        if (product!= null)
        {
            throw new Exception("Name already exists.");
        }
        
        return await _productData.SaveAsync(data);
    }
    
    public async Task<bool> UpdateAsync(Product data, int id)
    {
        return await _productData.UpdateAsync(data, id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _productData.DeleteAsync(id);
    }
    
}