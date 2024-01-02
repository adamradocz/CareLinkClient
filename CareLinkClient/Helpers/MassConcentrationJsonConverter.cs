using System.Text.Json;
using UnitsNet.Units;
using UnitsNet;
using System.Text.Json.Serialization;

namespace CareLinkClient.Helpers;

internal class MassConcentrationJsonConverter : JsonConverter<MassConcentration>
{
    public override bool CanConvert(Type t) => t == typeof(MassConcentration);

    public override MassConcentration Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => new(reader.GetDouble(), MassConcentrationUnit.MilligramPerDeciliter);

    public override void Write(Utf8JsonWriter writer, MassConcentration value, JsonSerializerOptions options)
        => writer.WriteNumberValue(value.MilligramsPerDeciliter);
}

