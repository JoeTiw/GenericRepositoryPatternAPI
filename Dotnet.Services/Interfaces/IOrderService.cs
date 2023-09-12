using Dotnet.core.Entities;

namespace Dotnet.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetOrderList();
    
    Task<Order> GetOrderById(int id);
    
    Task <bool> AddOrder(Order order);
    
    Task <bool> UpdateOrder(Order order);
    
    Task <bool> DeleteOrder(int id);
    
}