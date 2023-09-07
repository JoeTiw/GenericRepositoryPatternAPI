namespace Dotnet.core.Interfaces;

public interface IUnitOfWork
{
    int Save();

    ICustomerRepository Customers { get; }
}