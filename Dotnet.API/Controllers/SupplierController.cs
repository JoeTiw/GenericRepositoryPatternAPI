using Dotnet.core.Entities;
using Dotnet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Learning_API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class SupplierController : Controller
{
    public readonly ISupplierService _supplierService;

    public SupplierController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSupplierList()
    {
        var supplierlist = await _supplierService.GetSupplierList();
        if (supplierlist == null)
        {
            return NotFound();
        }

        return Ok(supplierlist);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSupplierById(int id)
    {
        var supplier = await _supplierService.GetSupplierById(id);
        if (supplier == null)
        {
            return NotFound();
        }

        return Ok(supplier);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> AddSupplier(Supplier supplier)
    {
        var response = await _supplierService.AddSupplier(supplier);
        if (response)
            return Ok(new { success = true, message = "Added Successfully" });
        else
            return BadRequest();

    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateSupplier(Supplier supplier)
    {
        var response = await _supplierService.UpdateSupplier(supplier);
        if (response)
            return Ok(new { success = true, message = "Updated Successfully" });
        else
            return BadRequest();

    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteSupplier(int id)
    {
        var response = await _supplierService.DeleteSupplier(id);
        if (response)
            return Ok(new { success = true, message = "Deleted Successfully" });
        else
            return BadRequest();

    }
}