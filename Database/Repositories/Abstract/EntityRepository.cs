using System.Linq.Expressions;
using KvotzatShekel.Database.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KvotzatShekel.Database.Repositories.Abstract;

public abstract class EntityRepository<T>(DbContext context) : IEntityRepository<T> where T : class
{
    public Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        return context.Set<T>().AnyAsync(expression, cancellationToken);
    }

    public async Task<T?> FindAsync(object[] primaryKeyComponents, CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().FindAsync(primaryKeyComponents, cancellationToken: cancellationToken);
    }

    public IQueryable<T> Query(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>().Where(expression);
    }
    
    public T Add(T entity)
    {
        return context.Set<T>().Add(entity).Entity;
    }
    
    public void AddRange(IEnumerable<T> entities)
    {
        context.Set<T>().AddRange(entities);
    }

    public void Remove(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        context.Set<T>().RemoveRange(entities);
    }
    
    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}