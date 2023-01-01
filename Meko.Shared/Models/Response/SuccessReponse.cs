namespace Meko.Models.Response;

using System.Net;
using System.Text.Json.Serialization;

public class SuccessResponse<T> : BaseResponse
{
    private const string _dataResponseParameter = "data";

    [JsonPropertyName(_dataResponseParameter)]
    public T Data { get; private set; }

    public SuccessResponse(string message, T data, HttpStatusCode statusCode)
        : base(message, statusCode, true)
    {
        Data = data;
    }

    public SuccessResponse(string message, T data)
        : base(message, HttpStatusCode.OK, true)
    {
        Data = data;
    }

    public SuccessResponse(string message, T data, string? nextCursor)
        : base(message, HttpStatusCode.OK, true)
    {
        Data = data;
        NextCursor = nextCursor;
    }

    protected override Dictionary<string, object> GetResponseBodyContent()
    {
        var content = new Dictionary<string, object>();
        if (Data is not null)
        {
            content.Add(_dataResponseParameter, Data);
        }
        return content;
    }
}
