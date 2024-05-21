using _3_Data.Contexts;
using _3_Data.Models;

namespace _3_Data;

public class ProductData : IProductData
{
    private MakiContext _makiContext;

    public ProductData(MakiContext makiContext)
    {
        _makiContext = makiContext;
    }

    public List<Product> GetAll()
    {
        return _makiContext.Products.ToList();
    }

    public Product GetById(int id)
    {
        return _makiContext.Products.Where(p => p.Id == id).FirstOrDefault();
    }
    
    public bool Save(Product data)
    {
        return true;
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