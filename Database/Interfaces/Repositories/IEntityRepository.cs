using System.Linq.Expressions;

namespace KvotzatShekel.Database.Interfaces.Repositories;

public interface IEntityRepository<T> where T : class
{
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<T?> FindAsync(object[] primaryKeyComponents, CancellationToken cancellationToken = default);
    IQueryable<T> Query(Expression<Func<T, bool>> expression);
    T Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}