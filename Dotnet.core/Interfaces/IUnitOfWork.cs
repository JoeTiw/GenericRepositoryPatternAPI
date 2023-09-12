namespace Dotnet.core.Interfaces;

public interface IUnitOfWork
{
    int Save();

    ICustomerRepository Customers { get; }

    ISupplierRepository Suppliers { get; }

    IOrderRepository Orders { get; }

    IOrderItemRepository OrderItems { get; }

    IProductRepository Products { get; }

    IAccountRepository Accounts { get; }

}