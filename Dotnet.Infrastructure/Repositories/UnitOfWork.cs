using Dotnet.core.Interfaces;
using Dotnet.Infrastructure.DataContext;

namespace Dotnet.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{

    private readonly ApplicationDbContext _dbContext;
    public ICustomerRepository Customers { get; }

    public UnitOfWork(ApplicationDbContext dbContext, CustomerRepository customerRepository)
    {
        _dbContext = dbContext;
        Customers = customerRepository;
    }

    public int Save()
    {
        return _dbContext.SaveChanges();
    }
   
}