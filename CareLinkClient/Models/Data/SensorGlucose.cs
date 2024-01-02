using System.Text.Json.Serialization;
using UnitsNet;

namespace CareLinkClient.Models.Data;

public class SensorGlucose
{
    [JsonPropertyName("sg")]
    public MassConcentration Value { get; set; }

    [JsonPropertyName("datetime")]
    public DateTimeOffset Datetime { get; set; }

    [JsonPropertyName("timeChange")]
    public bool TimeChange { get; set; }

    [JsonPropertyName("kind")]
    public string Kind { get; set; }

    [JsonPropertyName("version")]
    public float Version { get; set; }
}
