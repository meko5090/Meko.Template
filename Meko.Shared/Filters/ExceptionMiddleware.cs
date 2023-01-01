using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MekoResponse = Meko.Models.Response;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger
    )
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                "Error while processing request. {Type}: {Message}",
                exception.GetType(),
                exception.Message
            );
            await HandleExceptionAsync(httpContext, exception);
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception
    )
    {
        var statusCode = (int)HttpStatusCode.InternalServerError;
        var responseContent = new MekoResponse.ErrorDetails(
            description: "Unexpected error",
            code: MekoResponse.ErrorCodes.Generic.UnexpectedError
        );

        switch (exception)
        {
            case BadHttpRequestException ex:
                statusCode = (int)HttpStatusCode.BadRequest;
                responseContent.Code = MekoResponse
                    .ErrorCodes
                    .Generic
                    .BadRequest;
                responseContent.Description = ex.Message;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsJsonAsync(responseContent);
    }
}
