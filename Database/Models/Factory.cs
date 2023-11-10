namespace KvotzatShekel.Database.Models;

public sealed record Factory
{
    public uint Id { get; init; }
    public required string Name { get; init; }
    
    public required uint GroupId { get; init; }
    public Group Group { get; init; } = null!;
}