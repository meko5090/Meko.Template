using System.Text.Json.Serialization;

namespace Meko.Identity.Models;

public class LoginModel
{
    [JsonPropertyName("email")]
    public string UserName { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }
}
