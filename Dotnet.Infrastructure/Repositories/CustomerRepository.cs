using Dotnet.core.Entities;
using Dotnet.core.Interfaces;
using Dotnet.Infrastructure.DataContext;

namespace Dotnet.Infrastructure.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}