using _3_Data;
using _3_Data.Models;


namespace _2_Domain;

public class CustomerDomain:ICustomerDomain
{
    private ICustomerData _customerData;

    public CustomerDomain(ICustomerData customerData)
    {
        _customerData = customerData;
    }
    
    public async Task<bool> RegisterCustomerAsync(Customer data)
    {
        var existingCustomer = await _customerData.GetByEmailAsync(data.Email);
        if (existingCustomer != null)
        {
            throw new Exception("Email already exists.");
        }
        return await _customerData.SaveAsync(data);

    }

    public async Task<Customer> AuthenticateCustomerAsync(string email, string password)
    {
        var customer = await _customerData.GetByEmailAsync(email);
        if (customer != null && customer.Password == password)
        {
            return customer;
        }

        return null;

    }

    public async Task<bool> UpdateCustomerAsync(int id, Customer data)
    {
        return await _customerData.UpdateAsync(data, id);
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        return await _customerData.DeleteAsync(id);
    }
}