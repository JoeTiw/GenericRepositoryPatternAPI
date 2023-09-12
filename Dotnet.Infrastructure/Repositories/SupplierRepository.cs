using Dotnet.core.Entities;
using Dotnet.core.Interfaces;
using Dotnet.Infrastructure.DataContext;

namespace Dotnet.Infrastructure.Repositories;

public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
{
    public SupplierRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}