using Dotnet.Web.Models;
using Dotnet.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.Web.Controllers;

public class CustomerController : Controller
{

    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    
    // GET
    public async Task<IActionResult> Index()
    {

        var customerList = await _customerService.GetCustomerList();
        return View(customerList);
    }
}