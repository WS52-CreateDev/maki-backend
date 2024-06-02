using _3_Data.Models;

namespace _2_Domain;

public interface ICustomerDomain
{
    Task<bool> RegisterCustomerAsync(Customer data);
    Task<Customer> AuthenticateCustomerAsync(string email, string password);
    Task<bool> UpdateCustomerAsync(int id, Customer data);
    Task<bool> DeleteCustomerAsync(int id);

}

