using Dotnet.core.Interfaces;
using Dotnet.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;


namespace Dotnet.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ApplicationDbContext _dbContext; //declaring

    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
       
    }

    public async Task Add(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetIdByAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);

    }
}
