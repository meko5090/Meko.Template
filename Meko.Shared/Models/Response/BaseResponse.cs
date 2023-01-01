namespace Meko.Models.Response;

using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class BaseResponse : IActionResult
{
    private const string _messageResponseParameter = "message";

    public string Message { get; private set; }

    public HttpStatusCode StatusCode { get; private set; }

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }
    public bool IsSuccess { get; private set; }

    public BaseResponse(
        string message,
        HttpStatusCode statusCode,
        bool isSuccess
    )
    {
        Message = message;
        StatusCode = statusCode;
        IsSuccess = isSuccess;
    }

    public static BaseResponse Success(string message)
    {
        return new BaseResponse(message, HttpStatusCode.OK, true);
    }

    public static BaseResponse NoContent(string message)
    {
        return new BaseResponse(message, HttpStatusCode.NoContent, true);
    }

    public static BaseResponse Error(string message)
    {
        return new BaseResponse(message, HttpStatusCode.BadRequest, false);
    }

    protected virtual Dictionary<string, object> GetResponseBodyContent()
    {
        return new Dictionary<string, object>
        {
            { _messageResponseParameter, Message },
        };
    }

    public virtual Task ExecuteResultAsync(ActionContext context)
    {
        var httpContext = context.HttpContext;

        httpContext.Response.StatusCode = (int)StatusCode;

        if (StatusCode != HttpStatusCode.NoContent)
        {
            return httpContext.Response.WriteAsJsonAsync(
                GetResponseBodyContent()
            );
        }
        else
        {
            return Task.CompletedTask;
        }
    }
}
