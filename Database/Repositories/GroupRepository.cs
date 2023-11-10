using KvotzatShekel.Database.Interfaces;
using KvotzatShekel.Database.Interfaces.Repositories;
using KvotzatShekel.Database.Models;
using KvotzatShekel.Database.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KvotzatShekel.Database.Repositories;

public sealed class GroupRepository : EntityRepository<Group>, IGroupRepository
{
    public GroupRepository(IEntityContext context) : base((DbContext)context)
    {
    }
}