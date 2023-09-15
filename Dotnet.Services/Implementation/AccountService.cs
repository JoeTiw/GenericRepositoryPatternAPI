using Dotnet.core.Entities;
using Dotnet.core.Interfaces;
using Dotnet.Services.Interfaces;
using Dotnet.Services.DTO;
using UserLogin = Dotnet.Services.DTO.UserLogin;
using UserRegister = Dotnet.Services.DTO.UserRegister;

namespace Dotnet.Services.Implementation;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork;

    public AccountService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<bool> AddUser(UserRegister userRegister)
    {
        if (userRegister == null)
        {
            return false;
        }
        
        
        var _user = new Login()
        {
            Username = userRegister.Username,
            Password = userRegister.Password,
            Email = userRegister.Email,
            FirstName = userRegister.FirstName,
            LastName = userRegister.LastName,
            PasswordSalt = userRegister.PasswordSalt,
            Phone = userRegister.Phone,
            Address = userRegister.Address,
            Active = true
        };
             
        await _unitOfWork.Accounts.Add(_user);
        var result = _unitOfWork.Save();
        if (result > 0)
            return true;
        else
            return false;
    }

    public async Task<bool> LoginUser(UserLogin userLogin)
    {
        return await _unitOfWork.Accounts.Login(userLogin.Username, userLogin.Password);
    }

    public async Task<UserRegister> GetUserByUsername(string username)
    {
        var user = await _unitOfWork.Accounts.GetUserByUsername(username);
        if (user == null)
            return null;
        var userRegister = new UserRegister()
        {
            Username = user.Username,
            Password = user.Password,
            PasswordSalt = user.PasswordSalt,
            Phone = user.Phone,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Address = user.Address
        };
            return userRegister;

    }
}