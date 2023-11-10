using KvotzatShekel.Database.Interfaces;
using KvotzatShekel.Database.Interfaces.Repositories;
using KvotzatShekel.Database.Interfaces.WorkUnits;
using KvotzatShekel.Database.Models;
using KvotzatShekel.Database.Repositories;
using KvotzatShekel.Database.Repositories.Abstract;
using KvotzatShekel.Models;

namespace KvotzatShekel.Database.WorkUnits;

public sealed class CustomerWorkUnit(IEntityContext context) : ICustomerWorkUnit
{
    private readonly ICustomerRepository _customerRepository = new CustomerRepository(context);
    private readonly IFactoryToCustomerRepository _factoryToCustomerRepository = new FactoryToCustomerRepository(context);
    private readonly IGroupRepository _groupRepository = new GroupRepository(context);
    private readonly IFactoryRepository _factoryRepository = new FactoryRepository(context);

    public async Task CreateAsync(CustomerCreationRequestDTO request, CancellationToken cancellationToken = default)
    {
        var group = await _groupRepository.FindAsync(new object[] { request.GroupId }, cancellationToken);
        
        if (group is null)
            throw new ArgumentException("Group does not exist");
        
        var factory = await _factoryRepository.FindAsync(new object[] { request.FactoryId }, cancellationToken);
        
        if (factory is null)
            throw new ArgumentException("Factory does not exist");
        
        var customer = new Customer
        {
            Id = request.Customer.Id,
            Name = request.Customer.Name,
            Address = request.Customer.Address,
            PhoneNumber = request.Customer.PhoneNumber
        };
        
        _customerRepository.Add(customer);
        
        var relation = new FactoryToCustomer
        {
            Customer = customer,
            Factory = factory,
            Group = group
        };
        
        _factoryToCustomerRepository.Add(relation);

        await context.SaveChangesAsync(CancellationToken.None);
    }
}