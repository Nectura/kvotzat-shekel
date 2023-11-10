using KvotzatShekel.Models;

namespace KvotzatShekel.Database.Interfaces.WorkUnits;

public interface ICustomerWorkUnit
{
    Task CreateAsync(CustomerCreationRequestDTO request, CancellationToken cancellationToken = default);
}