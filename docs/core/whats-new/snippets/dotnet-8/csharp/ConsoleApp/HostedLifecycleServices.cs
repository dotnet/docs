using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class HostedLifecycleServices
{
    public async static void RunIt()
    {
        IHostBuilder hostBuilder = new HostBuilder();
        hostBuilder.ConfigureServices(services =>
        {
            services.AddHostedService<MyService>();
        });

        using (IHost host = hostBuilder.Build())
        {
            await host.StartAsync();
        }
    }

    public class MyService : IHostedLifecycleService
    {
        public Task StartingAsync(CancellationToken cancellationToken) => /* add logic here */ Task.CompletedTask;
        public Task StartAsync(CancellationToken cancellationToken) => /* add logic here */ Task.CompletedTask;
        public Task StartedAsync(CancellationToken cancellationToken) => /* add logic here */ Task.CompletedTask;
        public Task StopAsync(CancellationToken cancellationToken) => /* add logic here */ Task.CompletedTask;
        public Task StoppedAsync(CancellationToken cancellationToken) => /* add logic here */ Task.CompletedTask;
        public Task StoppingAsync(CancellationToken cancellationToken) => /* add logic here */ Task.CompletedTask;
    }
}
