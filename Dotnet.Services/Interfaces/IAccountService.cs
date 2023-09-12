using Dotnet.core.Entities;

namespace Dotnet.Services.Interfaces;

public interface IAccountService
{
    Task<bool> AddUser(UserRegister userRegister);

    Task<bool> LoginUser(UserLogin userLogin);
}