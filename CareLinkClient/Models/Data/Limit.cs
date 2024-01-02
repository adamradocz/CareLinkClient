using System.Text.Json.Serialization;
using UnitsNet;

namespace CareLinkClient.Models.Data;

public class Limit
{
    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("highLimit")]
    public MassConcentration HighLimit { get; set; }

    [JsonPropertyName("lowLimit")]
    public MassConcentration LowLimit { get; set; }

    [JsonPropertyName("kind")]
    public string Kind { get; set; } = string.Empty;

    [JsonPropertyName("version")]
    public float Version { get; set; }
}
