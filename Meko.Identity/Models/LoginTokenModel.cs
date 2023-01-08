using System.Text.Json.Serialization;

namespace Meko.Identity.Models;

public class LoginTokenModel
{
    [JsonPropertyName("token")]
    public string Token { get; set; } = null!;
}
