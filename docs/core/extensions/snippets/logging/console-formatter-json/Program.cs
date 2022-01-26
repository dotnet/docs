using System.Text.Json;

namespace Console.ExampleFormatters.Json;

class Program
{
    static Task Main(string[] args) =>
        CreateHostBuilder(args).Build().RunAsync();

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(builder => builder.UseStartup<Startup>())
            .ConfigureLogging(builder =>
                builder.AddJsonConsole(options =>
                {
                    options.IncludeScopes = false;
                    options.TimestampFormat = "hh:mm:ss ";
                    options.JsonWriterOptions = new JsonWriterOptions
                    {
                        Indented = true
                    };
                }));
}
