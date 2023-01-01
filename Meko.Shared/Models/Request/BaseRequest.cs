using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Meko.Models.Request;

public class BaseRequest
{
    [FromQuery(Name = "current_latitude")]
    [Range(-90, 90, ErrorMessage = "Please enter valid current latitude")]
    public double? CurrentLatitude { get; set; }

    [FromQuery(Name = "current_longitude")]
    [Range(-180, 180, ErrorMessage = "Please enter valid current longitude")]
    public double? CurrentLongitude { get; set; }

    [FromQuery(Name = "change_latitude")]
    [Range(-90, 90, ErrorMessage = "Please enter valid change latitude")]
    public double ChangeLatitude { get; set; }

    [FromQuery(Name = "change_longitude")]
    [Range(-180, 180, ErrorMessage = "Please enter valid change longitude")]
    public double ChangeLongitude { get; set; }

    [FromQuery(Name = "exploring_city_id")]
    public int ExploringCityId { get; set; }
}
