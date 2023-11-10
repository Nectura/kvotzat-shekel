using KvotzatShekel.Database.Interfaces;
using KvotzatShekel.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace KvotzatShekel.Database;

public sealed class EntityContext : DbContext, IEntityContext
{
    public DbSet<Customer> Customer => Set<Customer>();
    public DbSet<Factory> Factory => Set<Factory>();
    public DbSet<Group> Group => Set<Group>();
    public DbSet<FactoryToCustomer> FactoryToCustomer => Set<FactoryToCustomer>();

    public EntityContext(DbContextOptions<EntityContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Customer>()
            .Property(m => m.Id)
            .ValueGeneratedNever();
            
        builder.Entity<FactoryToCustomer>()
            .HasKey(m => new { m.CustomerId, m.FactoryId, m.GroupId });
    }
    
    public async Task<bool> CanConnectAsync(CancellationToken cancellationToken = default)
    {
        return await Database.CanConnectAsync(cancellationToken);
    }
}