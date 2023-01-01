namespace Meko.Models.Response;
using System.Net;

public class PaginatedResponse<T> : SuccessResponse<T>
{
    private int CurrentPage { get; set; }
    private int TotalPages { get; set; }

    public PaginatedResponse(
        string message,
        T data,
        HttpStatusCode statusCode,
        int currentPage,
        int totalPages
    ) : base(message, data, statusCode)
    {
        CurrentPage = currentPage;
        TotalPages = totalPages;
    }

    protected override Dictionary<string, object> GetResponseBodyContent()
    {
        var content = base.GetResponseBodyContent();
        content.Add("current_page", CurrentPage);
        content.Add("total_pages", TotalPages);
        return content;
    }
}
