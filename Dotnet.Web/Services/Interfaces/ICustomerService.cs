using Dotnet.Web.Models;

namespace Dotnet.Web.Services.Interfaces;

public interface ICustomerService
{
    Task <List<CustomerModel>> GetCustomerList();
    Task<CustomerModel> GetCustomerById(int id);
    Task<bool> CreateCustomer(CustomerModel customerModel);
    Task<bool> UpdateCustomer(CustomerModel customerModel);
    Task<bool> DeleteCustomer(int id);
}