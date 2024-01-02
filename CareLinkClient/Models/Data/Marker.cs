using System.Text.Json.Serialization;
using UnitsNet;

namespace CareLinkClient.Models.Data;

public class Marker
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("value")]
    public MassConcentration? Value { get; set; }

    [JsonPropertyName("kind")]
    public string Kind { get; set; }

    [JsonPropertyName("version")]
    public float Version { get; set; }
}
