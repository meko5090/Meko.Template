using System.Text.Json.Serialization;

namespace Meko.Infrastructure.IntegrationService.ElasticsearchIntegration;

public class ElasticSearchVenuesResponse
{
    /// <summary>
    /// The identified category
    /// </summary>
    [JsonPropertyName("identified_category")]
    public VenueIdentifiedCategory? IdentifiedCategory { get; set; }

    /// <summary>
    /// The search results
    /// </summary>
    [JsonPropertyName("results")]
    public VenueResult[] Results { get; set; } = Array.Empty<VenueResult>();

    /// <summary>
    /// Other city search results
    /// </summary>
    [JsonPropertyName("otherCitiesResults")]
    public VenueResult[] OtherCitiesResults { get; set; } =
        Array.Empty<VenueResult>();

    /// <summary>
    /// The total count of search results
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }
}

/// <summary>
/// Object represents the identified category
/// </summary>
public class VenueIdentifiedCategory
{
    /// <summary>
    /// The cities names
    /// </summary>
    [JsonPropertyName("cities")]
    public VenueCity[] Cities { get; set; } = Array.Empty<VenueCity>();

    /// <summary>
    /// The categories names
    /// </summary>
    [JsonPropertyName("categories")]
    public string[] Categories { get; set; } = Array.Empty<string>();
}

/// <summary>
/// Object represents search result
/// </summary>
public class VenueResult
{
    /// <summary>
    /// The ID of location
    /// </summary>
    [JsonPropertyName("location_id")]
    public long LocationId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("location")]
    public ElasticCoordinates? Location { get; set; }
}

public class ElasticCoordinates
{
    [JsonPropertyName("lat")]
    public double Latitude { get; set; }

    [JsonPropertyName("lon")]
    public double Longitude { get; set; }
}

public class VenueCity
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
