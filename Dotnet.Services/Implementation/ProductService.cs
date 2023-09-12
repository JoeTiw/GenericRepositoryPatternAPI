using Dotnet.core.Entities;
using Dotnet.core.Interfaces;
using Dotnet.Services.Interfaces;

namespace Dotnet.Services.Implementation;

public class ProductService : IProductService
{
    public IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Product>> GetProductList()
    {
        return await _unitOfWork.Products.GetAllAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
        if (id > 0)
        {
            var product = await _unitOfWork.Products.GetIdByAsync(id);
            if (product != null)
                return product;

        }

        return null;
    }

    public async Task<bool> AddProduct(Product product)
    {
        if (product == null)
        {
            return false;
        }

        await _unitOfWork.Products.Add(product);
        var result = _unitOfWork.Save();
        if (result > 0)
            return true;
        else
            return false;
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        if (product == null)
        {
            return false;
        }

        var _product = await _unitOfWork.Products.GetIdByAsync(product.Id);
        if (_product != null)
        {
            _unitOfWork.Products.Update(product);
            var result = _unitOfWork.Save();
            if (result > 0)
                return true;
            else
                return false;
        }

        return false;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        if (id > 0)
        {


            var product = await _unitOfWork.Products.GetIdByAsync(id);
            if (product != null)
            {
                _unitOfWork.Products.Delete(product);
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