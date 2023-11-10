namespace KvotzatShekel.Models;

public readonly record struct GroupDTO
{
    public required uint Id { get; init; }
    public required string Name { get; init; }
    
    public IEnumerable<GroupCustomerDTO>? GroupCustomers { get; init; }
}