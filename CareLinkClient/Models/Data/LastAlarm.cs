using System.Text.Json.Serialization;

namespace CareLinkClient.Models.Data;

public class LastAlarm
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("datetime")]
    public DateTimeOffset DateTime { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("flash")]
    public bool Flash { get; set; }

    [JsonPropertyName("kind")]
    public string Kind { get; set; } = string.Empty;

    [JsonPropertyName("version")]
    public float Version { get; set; }
}
