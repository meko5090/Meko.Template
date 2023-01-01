namespace Meko.Models;

/// <summary>
/// Struct with pagination information
/// </summary>
public struct PaginationDescriptor
{
    private static int PageStart => 0;

    /// <summary>
    /// Pagination page
    /// </summary>
    public int Page { get; private set; }

    /// <summary>
    /// Number of items in a page
    /// </summary>
    public int Size { get; private set; }

    /// <summary>
    /// Number of items to skip
    /// </summary>
    public int Skip => Page * Size;

    /// <summary>
    /// Constructor to set the page and size
    /// </summary>
    /// <param name="page">Pagination page</param>
    /// <param name="size">Number of items in a page</param>
    /// <param name="defaultPageSize">Default size used when size is invalid
    /// </param>
    public PaginationDescriptor(int page, int size, int defaultPageSize)
    {
        Page = page < PageStart ? PageStart : page;
        Size = size < 1 ? defaultPageSize : size;
    }

    /// <summary>
    /// Constructor to set the size and default start page
    /// </summary>
    /// <param name="size">Number of items in a page</param>
    public PaginationDescriptor(int size)
    {
        Page = PageStart;
        Size = size < 1 ? 1 : size;
    }
}
