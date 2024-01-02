namespace CareLinkClient;

public class CareLinkClientOptions
{
    public string InitialBearerToken { get; set; } = string.Empty;
    public DateTimeOffset TokenExpirationUtc { get; set; }
    public string CountryCode { get; set; } = "GB";
    public string Language { get; set; } = "en";
}
