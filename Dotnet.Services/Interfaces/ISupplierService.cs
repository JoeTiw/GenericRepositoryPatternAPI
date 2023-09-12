using Dotnet.core.Entities;

namespace Dotnet.Services.Interfaces;

public interface ISupplierService
{
    Task<IEnumerable<Supplier>> GetSupplierList();
    
    Task<Supplier> GetSupplierById(int id);
    
    Task <bool> AddSupplier(Supplier supplier);
    
    Task <bool> UpdateSupplier(Supplier supplier);
    
    Task <bool> DeleteSupplier(int id);
}