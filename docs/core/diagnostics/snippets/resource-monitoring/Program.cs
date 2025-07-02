// <setup>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.ResourceMonitoring;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Spectre.Console;

var app = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddLogging(static builder => builder.AddConsole())
                .AddResourceMonitoring();
    })
    .Build();

var monitor = app.Services.GetRequiredService<IResourceMonitor>();
await app.StartAsync();
// </setup>

using var cancellationTokenSource = new CancellationTokenSource();
var token = cancellationTokenSource.Token;

// <monitor>
await StartMonitoringAsync(monitor, token);

async Task StartMonitoringAsync(IResourceMonitor monitor, CancellationToken cancellationToken)
{
    var table = new Table()
        .Centered()
        .Title("Resource Monitoring", new Style(foreground: Color.Purple, decoration: Decoration.Bold))
        .Caption("Updates every three seconds. *GTD: Guaranteed ", new Style(decoration: Decoration.Dim))
        .RoundedBorder()
        .BorderColor(Color.Cyan1)
        .AddColumns(
        [
            new TableColumn("Time").Centered(),
            new TableColumn("CPU %").Centered(),
            new TableColumn("Memory %").Centered(),
            new TableColumn("Memory (bytes)").Centered(),
            new TableColumn("GTD / Max Memory (bytes)").Centered(),
            new TableColumn("GTD / Max CPU (units)").Centered(),
        ]);

    await AnsiConsole.Live(table)
        .StartAsync(async ctx =>
        {
            var window = TimeSpan.FromSeconds(3);
            while (cancellationToken.IsCancellationRequested is false)
            {
                var utilization = monitor.GetUtilization(window);
                var resources = utilization.SystemResources;

                table.AddRow(
                    [
                        $"{DateTime.Now:T}",
                        $"{utilization.CpuUsedPercentage:p}",
                        $"{utilization.MemoryUsedPercentage:p}",
                        $"{utilization.MemoryUsedInBytes:#,#}",
                        $"{resources.GuaranteedMemoryInBytes:#,#} / {resources.MaximumMemoryInBytes:#,#}",
                        $"{resources.GuaranteedCpuUnits} / {resources.MaximumCpuUnits}",
                    ]);

                ctx.Refresh();
                await Task.Delay(window);
            }
        });

    Console.CancelKeyPress += (_, e) =>
    {
        e.Cancel = true;
        cancellationTokenSource.Cancel();
    };
}
// </monitor>
