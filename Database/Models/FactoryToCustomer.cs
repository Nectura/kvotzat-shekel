namespace KvotzatShekel.Database.Models;

public sealed record FactoryToCustomer
{
    public uint CustomerId { get; init; }
    public uint FactoryId { get; init; }
    public uint GroupId { get; init; }
    
    public required Customer Customer { get; init; } = null!;
    public required Factory Factory { get; init; } = null!;
    public required Group Group { get; init; } = null!;
}