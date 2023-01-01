using System.Text.Json.Serialization;

namespace Meko.Infrastructure.IntegrationService.ElasticsearchIntegration;

/// <summary>
/// Object represents elasticsearch request structure for elasticsearch service
/// </summary>
public class ElasticsearchRequest
{
    /// <summary>
    /// The search keyword
    /// </summary>
    [JsonPropertyName("query")]
    public string? Query { get; set; }

    /// <summary>
    /// The size
    /// </summary>
    [JsonPropertyName("size")]
    public int Size { get; set; }

    /// <summary>
    /// The name of city to search
    /// </summary>
    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// The categories names
    /// </summary>
    [JsonPropertyName("categories")]
    public string[]? Categories { get; set; }

    /// <summary>
    /// For pagination settings : The first index to fetch
    /// </summary>
    [JsonPropertyName("from")]
    public int From { get; set; }

    [JsonIgnore]
    public double Latitude { get; set; }

    [JsonIgnore]
    public double Longitude { get; set; }

    /// <summary>
    /// The location coordinates
    /// </summary>
    [JsonPropertyName("location")]
    public double[] LocationCoordinates
    {
        get { return new double[] { Latitude, Longitude }; }
    }

    /// <summary>
    /// Flag to specify if search results should include venues in other
    /// cities
    /// </summary>
    [JsonPropertyName("include_other_cities")]
    public bool IncludeOtherCities { get; set; }
}
