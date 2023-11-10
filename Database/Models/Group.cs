namespace KvotzatShekel.Database.Models;

public sealed record Group
{
    public uint Id { get; init; }
    public required string Name { get; init; }
}