using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans.Configuration;

try
{
    var host = await StartSiloAsync();
    Console.WriteLine("\n\n Press Enter to terminate...\n\n");
    Console.ReadLine();

    await host.StopAsync();

    return 0;
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    return 1;
}

static async Task<IHost> StartSiloAsync()
{
    var builder = new HostBuilder()
        .UseOrleans(c =>
        {
            c.UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "OrleansBasics";
                })
                .ConfigureLogging(logging => logging.AddConsole());
        });

    var host = builder.Build();
    await host.StartAsync();

    return host;
}
