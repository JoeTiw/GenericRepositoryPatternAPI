using Dotnet.core.Entities;

namespace Dotnet.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductList();
    
    Task<Product> GetProductById(int id);
    
    Task <bool> AddProduct(Product product);
    
    Task <bool> UpdateProduct(Product product);
    
    Task <bool> DeleteProduct(int id);
}