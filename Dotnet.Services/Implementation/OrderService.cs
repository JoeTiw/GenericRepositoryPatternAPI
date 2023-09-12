using Dotnet.core.Entities;
using Dotnet.core.Interfaces;
using Dotnet.Services.Interfaces;

namespace Dotnet.Services.Implementation;

public class OrderService : IOrderService
{
    public IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Order>> GetOrderList()
    {
        return await _unitOfWork.Orders.GetAllAsync();
    }

    public async Task<Order> GetOrderById(int id)
    {
        if (id > 0)
        {
            var order = await _unitOfWork.Orders.GetIdByAsync(id);
            if (order != null)
                return order;

        }

        return null;
    }

    public async Task<bool> AddOrder(Order order)
    {
        if (order == null)
        {
            return false;
        }

        await _unitOfWork.Orders.Add(order);
        var result = _unitOfWork.Save();
        if (result > 0)
            return true;
        else
            return false;
    }

    public async Task<bool> UpdateOrder(Order order)
    {
        if (order == null)
        {
            return false;
        }

        var _order = await _unitOfWork.Orders.GetIdByAsync(order.Id);
        if (_order != null)
        {
            _unitOfWork.Orders.Update(order);
            var result = _unitOfWork.Save();
            if (result > 0)
                return true;
            else
                return false;
        }

        return false;
    }

    public async Task<bool> DeleteOrder(int id)
    {
        if (id > 0)
        {


            var order = await _unitOfWork.Orders.GetIdByAsync(id);
            if (order != null)
            {
                _unitOfWork.Orders.Delete(order);
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