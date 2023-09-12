using Dotnet.core.Entities;
using Dotnet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Learning_API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
 
    public readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductItemList()
    {
        var productList = await _productService.GetProductList();
        if (productList == null)
        {
            return NotFound();
        }

        return Ok(productList);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductItemById(int id)
    {
        var product = await _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        var response = await _productService.AddProduct(product);
        if (response)
            return Ok(new { success = true, message = "Added Successfully" });
        else
            return BadRequest();

    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateProductItem(Product product)
    {
        var response = await _productService.UpdateProduct(product);
        if (response)
            return Ok(new { success = true, message = "Updated Successfully" });
        else
            return BadRequest();

    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var response = await _productService.DeleteProduct(id);
        if (response)
            return Ok(new { success = true, message = "Deleted Successfully" });
        else
            return BadRequest();

    }
}