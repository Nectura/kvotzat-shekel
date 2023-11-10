using KvotzatShekel.Database.Interfaces;
using KvotzatShekel.Database.Interfaces.Repositories;
using KvotzatShekel.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace KvotzatShekel.Database.Repositories.Abstract;

public sealed class FactoryToCustomerRepository : EntityRepository<FactoryToCustomer>, IFactoryToCustomerRepository
{
    public FactoryToCustomerRepository(IEntityContext context) : base((DbContext)context)
    {
    }
}