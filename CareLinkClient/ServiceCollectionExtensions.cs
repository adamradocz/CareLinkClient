using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Contrib.WaitAndRetry;

namespace CareLinkClient;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCareLinkClient(this IServiceCollection services)
    {
        _ = services.AddTransient<Client>()
            .AddHttpClient<Client>()
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(2), 5)));

        _ = services.AddOptions<CareLinkClientOptions>().BindConfiguration(nameof(CareLinkClientOptions));

        return services;
    }

    public static IServiceCollection AddCareLinkClient(this IServiceCollection services, Action<CareLinkClientOptions> options)
    {
        return services.AddCareLinkClient()
            .Configure(options);
    }
}
