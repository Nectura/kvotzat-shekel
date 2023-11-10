using KvotzatShekel.Database.Interfaces;
using KvotzatShekel.Database.Interfaces.Repositories;
using KvotzatShekel.Database.Models;
using KvotzatShekel.Database.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KvotzatShekel.Database.Repositories;

public sealed class FactoryRepository : EntityRepository<Factory>, IFactoryRepository
{
    public FactoryRepository(IEntityContext context) : base((DbContext)context)
    {
    }
}