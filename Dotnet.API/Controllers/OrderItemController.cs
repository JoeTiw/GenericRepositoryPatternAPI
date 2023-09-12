using Dotnet.core.Entities;
using Dotnet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Learning_API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class OrderItemController : Controller
{
    public readonly IOrderItemService _orderItemService;

    public OrderItemController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrderItemList()
    {
        var orderItemList = await _orderItemService.GetOrderItemList();
        if (orderItemList == null)
        {
            return NotFound();
        }

        return Ok(orderItemList);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderItemById(int id)
    {
        var orderItem = await _orderItemService.GetOrderItemById(id);
        if (orderItem == null)
        {
            return NotFound();
        }

        return Ok(orderItem);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> AddOrder(OrderItem orderItem)
    {
        var response = await _orderItemService.AddOrderItem(orderItem);
        if (response)
            return Ok(new { success = true, message = "Added Successfully" });
        else
            return BadRequest();

    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateOrderItem(OrderItem orderItem)
    {
        var response = await _orderItemService.UpdateOrderItem(orderItem);
        if (response)
            return Ok(new { success = true, message = "Updated Successfully" });
        else
            return BadRequest();

    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteOrderItem(int id)
    {
        var response = await _orderItemService.DeleteOrderItem(id);
        if (response)
            return Ok(new { success = true, message = "Deleted Successfully" });
        else
            return BadRequest();

    }
}