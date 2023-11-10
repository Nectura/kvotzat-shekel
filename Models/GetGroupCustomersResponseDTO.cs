namespace KvotzatShekel.Models;

public readonly record struct GetGroupCustomersResponseDTO
{
    public required IEnumerable<GroupDTO> Groups { get; init; }
}
