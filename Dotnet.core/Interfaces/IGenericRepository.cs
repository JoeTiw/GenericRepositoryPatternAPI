namespace Dotnet.core.Interfaces;

public interface IGenericRepository<T> where T : class 
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T?> GetIdByAsync(int id);

    Task Add(T entity);

    void Update(T entity);
   void Delete(T entity);
    
}