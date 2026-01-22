using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace Orleans.Docs.Snippets.Aspire.Silo;

// This class contains example code for Orleans silo configuration with Aspire
public static class SiloProgram
{
    // <silo_basic_config>
    public static void BasicSiloConfiguration(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        // Add Aspire service defaults (OpenTelemetry, health checks, etc.)
        builder.AddServiceDefaults();

        // Add the Aspire Redis client for Orleans
        builder.AddKeyedRedisClient("orleans-redis");

        // Configure Orleans - Aspire injects all configuration automatically
        builder.UseOrleans();

        builder.Build().Run();
    }
    // </silo_basic_config>

    // <silo_explicit_connection>
    public static void ExplicitConnectionConfiguration(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        builder.AddServiceDefaults();
        builder.AddKeyedRedisClient("orleans-redis");

        builder.UseOrleans(siloBuilder =>
        {
            var redisConnectionString = builder.Configuration.GetConnectionString("orleans-redis");

            siloBuilder.UseRedisClustering(options =>
            {
                options.ConfigurationOptions =
                    ConfigurationOptions.Parse(redisConnectionString!);
            });

            siloBuilder.AddRedisGrainStorageAsDefault(options =>
            {
                options.ConfigurationOptions =
                    ConfigurationOptions.Parse(redisConnectionString!);
            });
        });

        builder.Build().Run();
    }
    // </silo_explicit_connection>

    // <health_checks>
    public static void ConfigureHealthChecks(IHostApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks()
            .AddCheck<GrainHealthCheck>("orleans-grains")
            .AddCheck<SiloHealthCheck>("orleans-silo");
    }
    // </health_checks>
}

// Stub health check classes for documentation examples
// In a real application, you would implement actual health check logic
#pragma warning disable CS1998 // Async method lacks 'await' operators

internal class GrainHealthCheck : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
        => HealthCheckResult.Healthy();
}

internal class SiloHealthCheck : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
        => HealthCheckResult.Healthy();
}

#pragma warning restore CS1998
