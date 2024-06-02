using _3_Data.Models;

namespace _3_Data;

public interface ICustomerData
{
    Task<bool> SaveAsync(Customer data);
    Task<Customer> GetByEmailAsync(string name);
    Task<bool> UpdateAsync(Customer data, int id);
    Task<bool> DeleteAsync(int id);
    Task<Customer> GetByIdAsync(int id);
    Task<IEnumerable<Customer>> GetAllAsync();
}