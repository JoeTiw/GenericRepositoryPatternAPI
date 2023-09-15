using Dotnet.core.Entities;

namespace Dotnet.core.Interfaces;

public interface IAccountRepository : IGenericRepository<Login>
{
   // Task<bool> UserRegistration(UserRegister userRegister);
    Task<bool> Login(string username, string password);

    Task<Login> GetUserByUsername(string username);
}