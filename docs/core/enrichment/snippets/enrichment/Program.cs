#define first
#if first
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Enrichment
{
    internal class Program
    {
        public static async Task Main()
        {
            var builder = Host.CreateApplicationBuilder();
            builder.Logging.EnableEnrichment();
            builder.Logging.AddJsonConsole(op =>
            {
                op.JsonWriterOptions = new JsonWriterOptions
                {
                    Indented = true
                };
            });
            builder.Services.AddProcessLogEnricher();
            var hostBuilder = builder.Build();
            var logger =
               hostBuilder.Services.GetRequiredService<ILoggerFactory>().CreateLogger<Program>();

            logger.LogInformation("This is a sample log message");

            await hostBuilder.RunAsync();

        }
    }
}
#endif

