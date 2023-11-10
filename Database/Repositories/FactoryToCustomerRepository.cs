using KvotzatShekel.Database.Interfaces;
using KvotzatShekel.Database.Interfaces.Repositories;
using KvotzatShekel.Database.Models;
using KvotzatShekel.Database.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KvotzatShekel.Database.Repositories;

public sealed class FactoryToCustomerRepository : EntityRepository<FactoryToCustomer>, IFactoryToCustomerRepository
{
    public FactoryToCustomerRepository(IEntityContext context) : base((DbContext)context)
    {
    }
}