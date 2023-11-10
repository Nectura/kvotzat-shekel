namespace KvotzatShekel.Models;

public readonly record struct GroupCustomerDTO
{
    public required uint Id { get; init; }
    public required string Name { get; init; }
}