namespace KvotzatShekel.Models;

public readonly record struct CustomerCreationRequestDTO
{
    public required CustomerDTO Customer { get; init; }
    public required uint GroupId { get; init; }
    public required uint FactoryId { get; init; }
}