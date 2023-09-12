using Dotnet.core.Entities;
using Dotnet.core.Interfaces;
using Dotnet.Services.Interfaces;

namespace Dotnet.Services.Implementation;

public class OrderItemService : IOrderItemService
{
    public IUnitOfWork _unitOfWork;

    public OrderItemService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<OrderItem>> GetOrderItemList()
    {
        return await _unitOfWork.OrderItems.GetAllAsync();
    }

    public async Task<OrderItem> GetOrderItemById(int id)
    {
        if (id > 0)
        {
            var orderItem = await _unitOfWork.OrderItems.GetIdByAsync(id);
            if (orderItem  != null)
                return orderItem ;

        }

        return null;
    }

    public async Task<bool> AddOrderItem(OrderItem orderItem )
    {
        if (orderItem  == null)
        {
            return false;
        }

        await _unitOfWork.OrderItems.Add(orderItem );
        var result = _unitOfWork.Save();
        if (result > 0)
            return true;
        else
            return false;
    }

    public async Task<bool> UpdateOrderItem (OrderItem  orderItem )
    {
        if (orderItem  == null)
        {
            return false;
        }

        var _order = await _unitOfWork.OrderItems.GetIdByAsync(orderItem .Id);
        if (_order != null)
        {
            _unitOfWork.OrderItems.Update(orderItem );
            var result = _unitOfWork.Save();
            if (result > 0)
                return true;
            else
                return false;
        }

        return false;
    }

    public async Task<bool> DeleteOrderItem (int id)
    {
        if (id > 0)
        {


            var orderItem  = await _unitOfWork.OrderItems.GetIdByAsync(id);
            if (orderItem  != null)
            {
                _unitOfWork.OrderItems.Delete( orderItem );
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