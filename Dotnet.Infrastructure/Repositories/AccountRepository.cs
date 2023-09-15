using Dotnet.core.Entities;
using Dotnet.core.Interfaces;
using Dotnet.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Infrastructure.Repositories;

public class AccountRepository : GenericRepository<Login>, IAccountRepository
{
    public AccountRepository(ApplicationDbContext dbContext) : base(dbContext) { 
    }
        
    public async Task<bool> Login(string username, string password)
    {
        var result = await _dbContext.Login.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        if (result == null)
            return false;
        else
            return true;
    }

    public async Task<Login> GetUserByUsername(string username)
    {
        var result = await _dbContext.Login.FirstOrDefaultAsync(x => x.Username == username );
        if (result == null)
            return null;
        else
            return result;
    }
}