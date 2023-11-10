using System.Net;
using KvotzatShekel.Exceptions;
using KvotzatShekel.Models;

namespace KvotzatShekel.Extensions;

public static class WebApplicationExtensions
{
    private static async Task WriteRequestErrorDTOAsync(HttpContext httpContext, HttpRequestErrorDTO DTO)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = DTO.Status;
        await httpContext.Response.WriteAsJsonAsync(DTO);
    }

    public static void UseGlobalExceptionHandling(this WebApplication webApp)
    {
        webApp.Use(async (httpContext, pipelineHttpRequest) =>
        {
            var logger = httpContext.RequestServices.GetRequiredService<ILogger<WebApplication>>();
            try
            {
                await pipelineHttpRequest();
            }
            catch (HttpRequestErrorException ex)
            {
                await WriteRequestErrorDTOAsync(httpContext, new HttpRequestErrorDTO
                {
                    Error = Enum.GetName(typeof(HttpStatusCode), ex.StatusCode) ?? "Unknown",
                    Status = ex.StatusCode,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                if (ex is OperationCanceledException) return;
                logger.LogError(ex, "An unhandled exception has occurred while executing the request");
                await WriteRequestErrorDTOAsync(httpContext, new HttpRequestErrorDTO
                {
                    Error = Enum.GetName(HttpStatusCode.InternalServerError)!,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "The server encountered an internal error while processing the request."
                });
            }
        });
    }
}