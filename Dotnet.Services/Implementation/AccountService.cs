using Dotnet.core.Entities;
using Dotnet.core.Interfaces;
using Dotnet.Services.Interfaces;

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
        //return await _unitOfWork.Accounts.UserRegistration(userRegister);
        if (userRegister == null)
        {
            return false;
        }
        await _unitOfWork.Accounts.UserRegistration(userRegister);
        var result = _unitOfWork.Save();

        if (result > 0)
            return false;
        else
            return true;
    }

    public async Task<bool> LoginUser(UserLogin userLogin)
    {
        return await _unitOfWork.Accounts.Login(userLogin);
    }
}