using Dotnet.core.Interfaces;
using Dotnet.Infrastructure.DataContext;

namespace Dotnet.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{

    private readonly ApplicationDbContext _dbContext;
    public ICustomerRepository Customers { get; }

    public ISupplierRepository Suppliers { get; }
    
    public IOrderRepository Orders { get; }

    public IOrderItemRepository OrderItems { get; }

    public IProductRepository Products { get; }

    public IAccountRepository Accounts { get; }

    public UnitOfWork(ApplicationDbContext dbContext, ICustomerRepository customerRepository, 
        ISupplierRepository supplierRepository, IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, 
        IProductRepository productRepository, IAccountRepository accountRepository)
    {
        _dbContext = dbContext;
        Customers = customerRepository;
        Suppliers = supplierRepository;
        Orders = orderRepository;
        OrderItems = orderItemRepository;
        Products = productRepository;
        Accounts = accountRepository;
    }

    public int Save()
    {
        return _dbContext.SaveChanges();
    }
   
}