using Dotnet.core.Entities;
using Dotnet.core.Interfaces;
using Dotnet.Services.Interfaces;

namespace Dotnet.Services.Implementation;

public class CustomerService : ICustomerService
{

    public IUnitOfWork _unitOfWork; //variable declare.....and then define constructor...then inject the interface....

    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Customer>> GetCustomerList()
    {
        return await _unitOfWork.Customers.GetAllAsync();
    }

    public async Task<Customer> GetCustomerById(int id)
    {
        if (id > 0)
        {
            var customer = await _unitOfWork.Customers.GetIdByAsync(id);
            if (customer != null)
                return customer;

        }

        return null;
    }

    public async Task<bool> AddCustomer(Customer customer)
    {
        if (customer == null)
        {
            return false;
        }

        await _unitOfWork.Customers.Add(customer);
        var result = _unitOfWork.Save();
        if (result > 0)
            return true;
        else
            return false;
    }

    public async Task<bool> UpdateCustomer(Customer customer)
    {
        if (customer == null)
        {
            return false;
        }

        var _customer = await _unitOfWork.Customers.GetIdByAsync(customer.Id);
        if (_customer != null)
        {
            _unitOfWork.Customers.Update(customer);
            var result = _unitOfWork.Save();
            if (result > 0)
                return true;
            else
                return false;
        }

        return false;
    }

    public async Task<bool> DeleteCustomer(int id)
    {
        if (id > 0)
        {


            var customer = await _unitOfWork.Customers.GetIdByAsync(id);
            if (customer != null)
            {
                _unitOfWork.Customers.Delete(customer);
                var result = _unitOfWork.Save();
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        return false;
    }
    
    
    
    
    
    
    
    
}

