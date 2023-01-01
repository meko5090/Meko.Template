using System.Text.Json;
using System.Text.Json.Serialization;
using Meko.Models.JsonConverters;

namespace Meko.Shared;

public static class CustomJsonSerializerOptions
{
    public static JsonSerializerOptions GetSerializerOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(
            new JsonStringEnumConverter(
                namingPolicy: JsonNamingPolicy.CamelCase
            )
        );
        options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        return options;
    }

    /// <summary>
    /// Returns JSON serializer options used by APIs
    /// </summary>
    /// <returns>JsonSerializerOptions</returns>
    public static JsonSerializerOptions GetAPISerializerOptions()
    {
        var jsonSerializerOptions = GetSerializerOptions();

        jsonSerializerOptions.Converters.Add(new TimeOnlyConverter());
        jsonSerializerOptions.Converters.Add(new IsoDateTimeConverter());

        return jsonSerializerOptions;
    }
}
