using Dotnet.core.Entities;
using Dotnet.core.Interfaces;
using Dotnet.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AccountRepository(ApplicationDbContext applicationDbContext)
    {
        _dbContext = applicationDbContext;
    }
    
    public async Task<bool> UserRegistration(UserRegister userRegister)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Login(UserLogin userLogin)
    {
        var result = await _dbContext.UserLogin.FirstOrDefaultAsync(x => x.Username == userLogin.Username
                                                         && x.Password == userLogin.Password);
        if (result == null)
            return false;
        else
            return true;
    }
}