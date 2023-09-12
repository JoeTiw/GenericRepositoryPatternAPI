using Dotnet.core.Entities;

namespace Dotnet.core.Interfaces;

public interface IAccountRepository
{
    Task<bool> UserRegistration(UserRegister userRegister);
    Task<bool> Login(UserLogin userLogin);
}