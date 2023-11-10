namespace KvotzatShekel.Database.Interfaces;

public interface IEntityContext
{
    Task<bool> CanConnectAsync(CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}