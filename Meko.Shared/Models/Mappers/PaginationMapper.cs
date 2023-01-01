using Meko.Models.Request;

namespace Meko.Models.Mappers;

/// <summary>
/// Mapper between PaginatedRequest and PaginationDescriptor
/// </summary>
public class PaginationMapper
{
    /// <summary>
    /// Map paginated request to paginated descriptor
    /// </summary>
    /// <param name="request">Request to map. If null, pagination is
    /// set to default start page and given defaultPageSize</param>
    /// <param name="defaultPageSize">Used to set the size when the value is
    /// invalid</param>
    /// <returns>PaginationDescriptor</returns>
    public static PaginationDescriptor Map(
        PaginatedRequest? request,
        int defaultPageSize
    )
    {
        if (request is null)
        {
            return new PaginationDescriptor(defaultPageSize);
        }

        var page = request.PageNo - 1;
        var size = request.Size;

        return new PaginationDescriptor(page, size, defaultPageSize);
    }
}
