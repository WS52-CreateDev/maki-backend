
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

    public async Task<int> SaveAsync(Product data)
    {
        
        var existingProduct = await _productData.GetByNameAsync(data.Name);
        if (existingProduct!= null)
        {
            throw new Exception("Name already exists.");
        }
        if(data.CategoryId == 0)
        {
            throw new Exception("Category is required.");
        }
        
        return await _productData.SaveAsync(data);
    }
    
    public async Task<bool> UpdateAsync(Product data, int id)
    {
        return await _productData.UpdateAsync(data, id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingProduct = _productData.GetById(id);
        if(existingProduct == null)
        {
            throw new Exception("Product not found.");
        }
        
        return await _productData.DeleteAsync(id);
    }
    
}