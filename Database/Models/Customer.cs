namespace KvotzatShekel.Database.Models;

public sealed record Customer
{
    public required uint Id { get; init; }
    public required string Name { get; init; }
    public required string Address { get; init; }
    public required string PhoneNumber { get; init; }
}