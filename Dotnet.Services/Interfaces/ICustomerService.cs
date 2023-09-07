using Dotnet.core.Entities;

namespace Dotnet.Services.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetCustomerList();
    
    Task<Customer> GetCustomerById(int id);
    
    Task <bool> AddCustomer(Customer customer);
    
    Task <bool> UpdateCustomer(Customer customer);
    
    Task <bool> DeleteCustomer(int id);
    
    
}