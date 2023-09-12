using Dotnet.core.Entities;

namespace Dotnet.Services.Interfaces;

public interface IOrderItemService
{
    Task<IEnumerable<OrderItem>> GetOrderItemList();
    
    Task<OrderItem> GetOrderItemById(int id);
    
    Task <bool> AddOrderItem(OrderItem orderItem);
    
    Task <bool> UpdateOrderItem(OrderItem orderItem);
    
    Task <bool> DeleteOrderItem(int id);
}