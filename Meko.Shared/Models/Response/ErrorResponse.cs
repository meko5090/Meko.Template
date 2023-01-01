namespace Meko.Models.Response;

using System.Net;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class ErrorResponse : BaseResponse
{
    [JsonPropertyName("error")]
    public ErrorDetails ErrorDetails { get; private set; }

    public ErrorResponse(
        string message,
        string errorDescription,
        string errorCode
    ) : base(message, HttpStatusCode.BadRequest, false)
    {
        ErrorDetails = new ErrorDetails(errorDescription, errorCode);
    }

    public ErrorResponse(
        string message,
        HttpStatusCode statusCode,
        string errorDescription,
        string errorCode
    ) : base(message, statusCode, false)
    {
        ErrorDetails = new ErrorDetails(errorDescription, errorCode);
    }

    public ErrorResponse(string message, ErrorDetails errorDetails)
        : base(message, HttpStatusCode.BadRequest, false)
    {
        ErrorDetails = errorDetails;
    }

    public ErrorResponse(
        string message,
        ErrorDetails errorDetails,
        HttpStatusCode statusCode
    ) : base(message, statusCode, false)
    {
        ErrorDetails = errorDetails;
    }

    public override Task ExecuteResultAsync(ActionContext context)
    {
        var httpContext = context.HttpContext;
        httpContext.Response.StatusCode = (int)StatusCode;
        var content = ErrorDetails;
        return httpContext.Response.WriteAsJsonAsync(content);
    }
}
