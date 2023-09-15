using Dotnet.core.Entities;
using UserLogin = Dotnet.Services.DTO.UserLogin;
using UserRegister = Dotnet.Services.DTO.UserRegister;

namespace Dotnet.Services.Interfaces;

public interface IAccountService
{
    Task<bool> AddUser(UserRegister userRegister);

    Task<bool> LoginUser(UserLogin userLogin);

    Task<UserRegister> GetUserByUsername(string username);
}