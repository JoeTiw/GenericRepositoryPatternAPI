using Dotnet.core.Entities;
using Dotnet.core.Interfaces;
using Dotnet.Services.Interfaces;

namespace Dotnet.Services.Implementation;

public class SupplierService : ISupplierService
{
    public IUnitOfWork _unitOfWork;

    public SupplierService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Supplier>> GetSupplierList()
    {
        return await _unitOfWork.Suppliers.GetAllAsync();
    }

    public async Task<Supplier> GetSupplierById(int id)
    {
        if (id > 0)
        {
            var supplier = await _unitOfWork.Suppliers.GetIdByAsync(id);
            if (supplier != null)
                return supplier;

        }

        return null;
    }

    public async Task<bool> AddSupplier(Supplier supplier)
    {
        if (supplier == null)
        {
            return false;
        }

        await _unitOfWork.Suppliers.Add(supplier);
        var result = _unitOfWork.Save();
        if (result > 0)
            return true;
        else
            return false;
    }

    public async Task<bool> UpdateSupplier(Supplier supplier)
    {
        if (supplier == null)
        {
            return false;
        }

        var _supplier = await _unitOfWork.Suppliers.GetIdByAsync(supplier.Id);
        if (_supplier != null)
        {
            _unitOfWork.Suppliers.Update(supplier);
            var result = _unitOfWork.Save();
            if (result > 0)
                return true;
            else
                return false;
        }

        return false;
    }

    public async Task<bool> DeleteSupplier(int id)
    {
        if (id > 0)
        {


            var supplier = await _unitOfWork.Suppliers.GetIdByAsync(id);
            if (supplier != null)
            {
                _unitOfWork.Suppliers.Delete(supplier);
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