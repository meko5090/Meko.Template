using System.Text.Json.Serialization;

namespace Meko.Models.Response
{
    public class ErrorDetails
    {
        [JsonPropertyName("error")]
        public string Code { get; set; }

        [JsonPropertyName("error_description")]
        public string Description { get; set; }

        public ErrorDetails(string description, string code)
        {
            Description = description;
            Code = code;
        }
    }
}
