using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Meko.Models.Request;

public class PaginatedRequest
{
    private const int PageStart = 1;

    private int _pageNo = PageStart;

    [FromQuery(Name = "page")]
    public int PageNo
    {
        get { return _pageNo; }
        set { _pageNo = value < PageStart ? PageStart : value; }
    }

    [FromQuery(Name = "size")]
    [Range(0, 1000, ErrorMessage = "Please enter a valid PageSize<1000")]
    public int Size { get; set; }
}
