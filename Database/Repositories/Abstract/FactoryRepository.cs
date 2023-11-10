using KvotzatShekel.Database.Interfaces;
using KvotzatShekel.Database.Interfaces.Repositories;
using KvotzatShekel.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace KvotzatShekel.Database.Repositories.Abstract;

public sealed class FactoryRepository : EntityRepository<Factory>, IFactoryRepository
{
    public FactoryRepository(IEntityContext context) : base((DbContext)context)
    {
    }
}