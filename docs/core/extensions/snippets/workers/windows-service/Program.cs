using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using App.WindowsService;

using IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options => options.ServiceName = ".NET 6 - Queue processor")
    .ConfigureServices(services => services.AddHostedService<WindowsBackgroundService>())
    .Build();

await host.RunAsync();
