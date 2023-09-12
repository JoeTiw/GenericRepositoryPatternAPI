using Dotnet.core.Entities;
using Dotnet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Learning_API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class OrderController : Controller
{
    public readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrderList()
    {
        var orderList = await _orderService.GetOrderList();
        if (orderList == null)
        {
            return NotFound();
        }

        return Ok(orderList);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await _orderService.GetOrderById(id);
        if (order == null)
        {
            return NotFound();
        }

        return Ok(order);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> AddOrder(Order order)
    {
        var response = await _orderService.AddOrder(order);
        if (response)
            return Ok(new { success = true, message = "Added Successfully" });
        else
            return BadRequest();

    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateOrder(Order order)
    {
        var response = await _orderService.UpdateOrder(order);
        if (response)
            return Ok(new { success = true, message = "Updated Successfully" });
        else
            return BadRequest();

    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var response = await _orderService.DeleteOrder(id);
        if (response)
            return Ok(new { success = true, message = "Deleted Successfully" });
        else
            return BadRequest();

    }
}