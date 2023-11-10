using KvotzatShekel.Database.Interfaces;
using KvotzatShekel.Database.Interfaces.Repositories;
using KvotzatShekel.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace KvotzatShekel.Database.Repositories.Abstract;

public sealed class GroupRepository : EntityRepository<Group>, IGroupRepository
{
    public GroupRepository(IEntityContext context) : base((DbContext)context)
    {
    }
}