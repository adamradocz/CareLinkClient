using CareLinkClient.Helpers;
using System.Text.Json.Serialization;

namespace CareLinkClient.Models;

public class Patient
{
    [JsonPropertyName("loginDateUTC")]
    [JsonConverter(typeof(CustomDateTimeOffsetConverter))]
    public DateTimeOffset LoginDateUtc { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    [JsonPropertyName("language")]
    public string Language { get; set; } = string.Empty;

    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("accountId")]
    public int AccountId { get; set; }

    [JsonPropertyName("role")]
    public string Role { get; set; } = string.Empty;

    [JsonPropertyName("cpRegistrationStatus")]
    public object CpRegistrationStatus { get; set; }

    [JsonPropertyName("accountSuspended")]
    public object AccountSuspended { get; set; }

    [JsonPropertyName("needToReconsent")]
    public bool NeedToReconsent { get; set; }

    [JsonPropertyName("mfaRequired")]
    public bool MfaRequired { get; set; }

    [JsonPropertyName("mfaEnabled")]
    public bool MfaEnabled { get; set; }
}
