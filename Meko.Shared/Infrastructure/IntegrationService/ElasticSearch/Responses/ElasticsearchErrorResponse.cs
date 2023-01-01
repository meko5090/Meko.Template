using System.Text.Json.Serialization;

namespace Meko.Infrastructure.IntegrationService.ElasticsearchIntegration;

/// <summary>
/// Object represents elasticsearch error response structure for elasticsearch service
/// </summary>
public class ElasticsearchErrorResponse
{
    /// <summary>
    /// The error message
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
