namespace KvotzatShekel.Models;

public sealed record HttpRequestErrorDTO
{
    public required string Error { get; init; }
    public required int Status { get; init; }
    public string Message { get; init; } = string.Empty;
}