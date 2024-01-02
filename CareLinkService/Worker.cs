using CareLinkClient;

namespace CareLinkService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly Client _client;

    public Worker(ILogger<Worker> logger, Client client)
    {
        _logger = logger;
        _client = client;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            var data = await _client.GetPatientDataAsync(stoppingToken).ConfigureAwait(false);
            var sensoreGlucose = data.LastSensorGlucose.Value.ToMolarity(CareLinkClient.Utilities.UnitsUtility.GlucoseMolecularWeight);
            Console.WriteLine($"DateTime: {data.LastSensorGlucose.Datetime} - Value: {Math.Round(sensoreGlucose.MillimolesPerLiter, 2)} mmol/L - TimeChange: {data.LastSensorGlucose.TimeChange}");


            if (_client.TokenExpirationUtc <= DateTimeOffset.Now + TimeSpan.FromMinutes(5))
            {
                Console.WriteLine("Refreshing token...");
                await _client.RefreshTokenAsync(stoppingToken).ConfigureAwait(false);
            }
            
            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken).ConfigureAwait(false);
        }
    }
}
