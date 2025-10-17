using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Diagnostics;


internal partial class Program
{
    private static void ConfigureHttpClientLatency(HostApplicationBuilder builder)
    {
        // <extensions>
        var builder = WebApplication.CreateBuilder(args);

		// Add HTTP client factory
		builder.Services.AddHttpClient();

		// Add HTTP client latency telemetry
		builder.Services.AddHttpClientLatencyTelemetry();
        // </extensions>
    }

    private static void ConfigureWithDelegate(HostApplicationBuilder builder)
    {
        // <register-handler>
        // Configure with delegate
        builder.Services.AddHttpClientLatencyTelemetry(options =>
        {
            options.EnableDetailedLatencyBreakdown = true;
        });

        // Or configure from configuration
        builder.Services.AddHttpClientLatencyTelemetry(
        builder.Configuration.GetSection("HttpClientTelemetry"));
        // </register-handler>
    }

    private static void EnableLatencyContext(HostApplicationBuilder builder)
    {
        // <enable-context>
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddHttpClientLatencyTelemetry(); // enables latency context + measures/tags
        builder.Services.AddExtendedHttpClientLogging();
        var app = builder.Build();
        // </enable-context>
    }

    private static void RegistrationOptions(HostApplicationBuilder builder)
    {
        // <registration-options>
        public static IServiceCollection AddHttpClientLatencyTelemetry(
            this IServiceCollection services);

        public static IServiceCollection AddHttpClientLatencyTelemetry(
            this IServiceCollection services,
            IConfigurationSection section);

        public static IServiceCollection AddHttpClientLatencyTelemetry(
            this IServiceCollection services,
            Action<HttpClientLatencyTelemetryOptions> configure);
        // </registration-options>
    }

    private static void HttpClientLatency(HostApplicationBuilder builder)
    {
        // <http-client>
        var builder = Host.CreateApplicationBuilder(args);

        // Register IHttpClientFactory:
        builder.Services.AddHttpClient();

        // Register redaction services:
        builder.Services.AddRedaction();

        // Register latency context services:
        builder.Services.AddLatencyContext();

        // Register HttpClient logging enrichment & redaction services:
        builder.Services.AddExtendedHttpClientLogging();

        // Register HttpClient latency telemetry services:
        builder.Services.AddHttpClientLatencyTelemetry();

        var host = builder.Build();
        // </http-client>
    }
}
