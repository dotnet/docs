// <setup>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.ResourceMonitoring;
using Microsoft.Extensions.Logging;
using Spectre.Console;

var services = new ServiceCollection()
    .AddLogging(static builder => builder.AddConsole())
    .AddResourceMonitoring();

var provider = services.BuildServiceProvider();

var monitor = provider.GetRequiredService<IResourceMonitor>();
// </setup>

// <monitor>
await StartMonitoringAsync(monitor);

static async Task StartMonitoringAsync(IResourceMonitor monitor)
{
    using var cancellationTokenSource = new CancellationTokenSource();
    var token = cancellationTokenSource.Token;

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
            var window = TimeSpan.FromSeconds(1);
            while (token.IsCancellationRequested is false)
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
// <monitor>

// <output>
// Sample output:
//                                              Resource Monitoring
// ┌─────────────┬───────┬──────────┬────────────────┬─────────────────────────────────┬───────────────────────┐
// │    Time     │ CPU % │ Memory % │ Memory (bytes) │    GTD / Max Memory (bytes)     │ GTD / Max CPU (units) │
// ├─────────────┼───────┼──────────┼────────────────┼─────────────────────────────────┼───────────────────────┤
// │ 10:18:50 AM │ 0.00% │  4.88%   │   33,419,264   │ 68,412,022,784 / 68,412,022,784 │        20 / 20        │
// │ 10:18:53 AM │ 0.00% │  4.88%   │   33,419,264   │ 68,412,022,784 / 68,412,022,784 │        20 / 20        │
// │ 10:18:56 AM │ 0.00% │  4.88%   │   33,419,264   │ 68,412,022,784 / 68,412,022,784 │        20 / 20        │
// └─────────────┴───────┴──────────┴────────────────┴─────────────────────────────────┴───────────────────────┘
//                                Updates every three seconds. *GTD: Guaranteed
// </output>
