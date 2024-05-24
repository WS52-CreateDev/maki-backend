
using _3_Data.Contexts;
using _3_Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace _3_Data;

public class ProductData : IProductData
{
    private MakiContext _makiContext;

    public ProductData(MakiContext makiContext)
    {
        _makiContext = makiContext;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        var result = await _makiContext.Products.Where(p=> p.IsActive).ToListAsync();
        return result;
    }

    public Product GetById(int id)
    {
        return _makiContext.Products.Where(p => p.Id == id && p.IsActive).FirstOrDefault();
    }

    public async Task<Product> GetByNameAsync(string name)
    {
        return await _makiContext.Products.Where(p=> p.Name == name && p.IsActive).FirstOrDefaultAsync();
    }
    
    public async Task<bool> SaveAsync(Product data)
    {
        var strategy = _makiContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _makiContext.Database.BeginTransactionAsync();
            await _makiContext.Products.AddAsync(data);
            await _makiContext.SaveChangesAsync();
            await transaction.CommitAsync();
        });
        return true;
    }
    /*
    public bool Update(Product data, int id)
    {
        var existingProduct = _makiContext.Products.Where(p => p.Id == id).FirstOrDefault();
        existingProduct.Name = data.Name;
        existingProduct.Description = data.Description;
        existingProduct.Price = data.Price;
        existingProduct.Image = data.Image;
        existingProduct.Width = data.Width;
        existingProduct.Height = data.Height;
        existingProduct.Depth = data.Depth;
        existingProduct.Material = data.Material;
        existingProduct.Category = data.Category;

        _makiContext.Products.Update(existingProduct);
        _makiContext.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var existingProduct = _makiContext.Products.Where(p => p.Id == id).FirstOrDefault();
        existingProduct.IsActive = false;
        _makiContext.Products.Update(existingProduct);
        _makiContext.SaveChanges();
        return true;
    }
    */
    
    public async Task<bool> UpdateAsync(Product data, int id)
    {
        var existingProduct = await _makiContext.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        existingProduct.Name = data.Name;
        existingProduct.Description = data.Description;
        existingProduct.Price = data.Price;
        existingProduct.Image = data.Image;
        existingProduct.Width = data.Width;
        existingProduct.Height = data.Height;
        existingProduct.Depth = data.Depth;
        existingProduct.Material = data.Material;
        existingProduct.Category = data.Category;
        
        _makiContext.Products.Update(existingProduct);
        await _makiContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingProduct = await _makiContext.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        existingProduct.IsActive = false;
        _makiContext.Products.Update(existingProduct);
        await _makiContext.SaveChangesAsync();
        return true;
    }
    
}