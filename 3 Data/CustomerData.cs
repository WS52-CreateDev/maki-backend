using _3_Data.Contexts;
using _3_Data.Models;
using Microsoft.EntityFrameworkCore;
namespace _3_Data;

public class CustomerData:ICustomerData

{
    
    private  MakiContext _makiContext;
    
    public CustomerData(MakiContext makiContext)
    {
        _makiContext = makiContext;
    }
    
    public async Task<bool> SaveAsync(Customer data)
    {
        var strategy = _makiContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _makiContext.Database.BeginTransactionAsync();
            await _makiContext.Customers.AddAsync(data);
            await _makiContext.SaveChangesAsync();
            await transaction.CommitAsync();
        });
        return true;
    }

    public async Task<Customer> GetByEmailAsync(string email)
    {
        return await _makiContext.Customers.FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<bool> UpdateAsync(Customer data, int id)
    {
        var existingCustomer = await _makiContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
        if (existingCustomer == null)
            return false;

        existingCustomer.Name = data.Name;
        existingCustomer.Surname = data.Surname;
        existingCustomer.Phone = data.Phone;
        existingCustomer.Address = data.Address;
        existingCustomer.Email = data.Email;
        existingCustomer.Photo = data.Photo;
        existingCustomer.Age = data.Age;
        existingCustomer.Province = data.Province;
        existingCustomer.Info = data.Info;
        existingCustomer.Password = data.Password;
            
        await _makiContext.SaveChangesAsync();
        return true;
    }

    public  async Task<bool> DeleteAsync(int id)
    {
        var existingCustomer = await _makiContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
        if (existingCustomer == null)
            return false;

        _makiContext.Customers.Remove(existingCustomer);
        await _makiContext.SaveChangesAsync();
        return true;
    }

    public  async Task<Customer> GetByIdAsync(int id)
    {
        return await _makiContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _makiContext.Customers.ToListAsync();
    }
}