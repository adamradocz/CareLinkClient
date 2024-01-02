using CareLinkClient;

namespace CareLinkService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        _ = builder.Services.AddHostedService<Worker>()
            .AddCareLinkClient(option =>
            {
                option.CountryCode = "HU";
                option.Language = "hu";
                option.TokenExpirationUtc = DateTimeOffset.Parse("2023-12-29 20:32:14", null, System.Globalization.DateTimeStyles.AssumeUniversal);
                option.InitialBearerToken = "";
            });

        var host = builder.Build();
        host.Run();
    }
}