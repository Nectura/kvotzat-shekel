namespace KvotzatShekel.Models;

public readonly record struct CustomerDTO
{
    public required uint Id { get; init; }
    public required string Name { get; init; }
    public required string Address { get; init; }
    public required string PhoneNumber { get; init; }
}