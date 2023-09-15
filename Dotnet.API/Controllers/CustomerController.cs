using Dotnet.core.Entities;
using Dotnet.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Learning_API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{

    public readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomerList()
    {
        var customerlist = await _customerService.GetCustomerList();
        if (customerlist == null)
        {
            return NotFound();
        }

        return Ok(customerlist);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _customerService.GetCustomerById(id);
        if (customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> AddCustomer(Customer customer)
    {
        var response = await _customerService.AddCustomer(customer);
        if (response)
            return Ok(new { success = true, message = "Added Successfully" });
        else
            return BadRequest();

    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCustomer(Customer customer)
    {
        var response = await _customerService.UpdateCustomer(customer);
        if (response)
            return Ok(new { success = true, message = "Updated Successfully" });
        else
            return BadRequest();

    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var response = await _customerService.DeleteCustomer(id);
        if (response)
            return Ok(new { success = true, message = "Deleted Successfully" });
        else
            return BadRequest();

    }
    
    

}