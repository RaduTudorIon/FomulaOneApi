using DataService;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public readonly ILogger logger;
    protected AppDbContext context;
    internal DbSet<T> dbSet;

    public GenericRepository(AppDbContext context, ILogger logger)
    {
        this.logger = logger;
        this.context = context;
        dbSet = context.Set<T>();
    }

    public virtual async Task<bool> Add(T entity)
    {
        await dbSet.AddAsync(entity);
        return true;
    }

    public virtual Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T?> GetById(Guid id)
    {
        return await dbSet.FindAsync(id);
    }

    public virtual Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }
}
