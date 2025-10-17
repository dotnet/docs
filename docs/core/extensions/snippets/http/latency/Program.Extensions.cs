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
}
