using ConsoleDI.IEnumerableExample;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleDI.Example;

class Program
{
    static Task Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();

        _ = host.Services.GetService<ExampleService>();

        return host.RunAsync();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                services.AddSingleton<IMessageWriter, ConsoleMessageWriter>()
                        .AddSingleton<IMessageWriter, LoggingMessageWriter>()
                        .AddSingleton<ExampleService>());
}
