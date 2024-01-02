using System.Text.Json.Serialization;

namespace CareLinkClient.Models.Data;

public class ActiveInsulin
{
    [JsonPropertyName("amount")]
    public double Amount { get; set; }

    [JsonPropertyName("kind")]
    public string Kind { get; set; } = string.Empty;

    [JsonPropertyName("version")]
    public float Version { get; set; }
}
