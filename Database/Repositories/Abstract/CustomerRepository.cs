using KvotzatShekel.Database.Interfaces;
using KvotzatShekel.Database.Interfaces.Repositories;
using KvotzatShekel.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace KvotzatShekel.Database.Repositories.Abstract;

public sealed class CustomerRepository : EntityRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(IEntityContext context) : base((DbContext)context)
    {
    }
}