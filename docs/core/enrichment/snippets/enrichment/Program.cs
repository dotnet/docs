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
            var host = new HostBuilder()
               .ConfigureLogging((hostingContext, loggingBuilder) =>
               {
                   loggingBuilder.EnableEnrichment();
                   loggingBuilder.Services.AddProcessLogEnricher();
                   loggingBuilder.AddJsonConsole(op =>
                   {
                       op.JsonWriterOptions = new JsonWriterOptions
                       {
                           Indented = true
                       };
                   });
               });

            var hostBuilder = host.Build();
            var logger =
               hostBuilder.Services
                   .GetRequiredService<ILoggerFactory>()
                   .CreateLogger<Program>();

            logger.LogInformation("This is a sample log message");

            await hostBuilder.RunAsync();

        }
    }
}
