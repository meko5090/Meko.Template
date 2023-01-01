using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Meko.Models.JsonConverters;

/// <summary>
/// Converts a DateTime object to or from JSON
/// </summary>
public class IsoDateTimeConverter : JsonConverter<DateTime>
{
    /// <summary>
    /// The DateTime format to be used for conversion
    /// </summary>
    private readonly string SerializationFormat;

    /// <summary>
    /// Default datetime format.
    /// </summary>
    private readonly string DefaultSerializationFormat =
        "yyyy-MM-ddTHH\\:mm\\:ssZ";

    public IsoDateTimeConverter() : this(null) { }

    /// <summary>
    /// Creates a converter with the given date time format.
    /// </summary>
    /// <param name="serializationFormat">The datetime format to use for
    /// conversion. If omitted, the default is used yyyy-MM-ddTHH:mm:ssZ</param>
    public IsoDateTimeConverter(string? serializationFormat)
    {
        SerializationFormat = serializationFormat ?? DefaultSerializationFormat;
    }

    /// <inheritdoc />
    public override DateTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var value = reader.GetString();
        return DateTime.Parse(value!, CultureInfo.InvariantCulture);
    }

    /// <inheritdoc />
    public override void Write(
        Utf8JsonWriter writer,
        DateTime value,
        JsonSerializerOptions options
    ) =>
        writer.WriteStringValue(
            value.ToString(SerializationFormat, CultureInfo.InvariantCulture)
        );
}
