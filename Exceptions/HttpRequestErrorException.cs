namespace KvotzatShekel.Exceptions;

public sealed class HttpRequestErrorException(int statusCode, string message) : Exception(message)
{
    public int StatusCode { get; } = statusCode;
}