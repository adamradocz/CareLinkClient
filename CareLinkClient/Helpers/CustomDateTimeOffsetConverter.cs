using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CareLinkClient.Helpers;

internal class CustomDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    private const string _format = "yyyy-MM-ddTHH:mm:sszzz";

    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => DateTimeOffset.ParseExact(reader.GetString()!, _format, CultureInfo.InvariantCulture);

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(_format, CultureInfo.InvariantCulture));
}