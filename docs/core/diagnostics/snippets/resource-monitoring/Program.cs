using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.ResourceMonitoring;
using Microsoft.Extensions.Logging;
using Spectre.Console;

var services = new ServiceCollection()
    .AddLogging(static builder => builder.AddConsole())
    .AddResourceMonitoring();

var provider = services.BuildServiceProvider();

var monitor = provider.GetRequiredService<IResourceMonitor>();

using var cancellationTokenSource = new CancellationTokenSource();
var token = cancellationTokenSource.Token;

var table = new Table()
    .Centered()
    .Title("Resource Monitoring", new Style(foreground: Color.Purple, decoration: Decoration.Bold))
    .Caption("Updates every three seconds...")
    .RoundedBorder()
    .BorderColor(Color.Cyan1)
    .AddColumns(
    [
        new TableColumn("CPU").Centered(),
        new TableColumn("Memory %").Centered(),
        new TableColumn("Memory (bytes)").Centered(),
        new TableColumn("Guaranteed / Max Memory (bytes)").Centered(),
        new TableColumn("Guaranteed / Max CPU (units)").Centered(),
    ]);

await AnsiConsole.Live(table)
    .StartAsync(async ctx =>
    {
        var window = TimeSpan.FromSeconds(3);
        while (token.IsCancellationRequested is false)
        {
            var utilization = monitor.GetUtilization(window);
            var resources = utilization.SystemResources;

            table.AddRow(
                [
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

Console.ReadLine();

// Sample output:
//                                           Resource Monitoring
//   ┌───────┬──────────┬────────────────┬─────────────────────────────────┬──────────────────────────────┐
//   │  CPU  │ Memory % │ Memory (bytes) │ Guaranteed / Max Memory (bytes) │ Guaranteed / Max CPU (units) │
//   ├───────┼──────────┼────────────────┼─────────────────────────────────┼──────────────────────────────┤
//   │ 0.00% │  5.09%   │   34,832,384   │ 68,412,022,784 / 68,412,022,784 │           20 / 20            │
//   │ 0.00% │  5.09%   │   34,832,384   │ 68,412,022,784 / 68,412,022,784 │           20 / 20            │
//   │ 0.00% │  5.09%   │   34,832,384   │ 68,412,022,784 / 68,412,022,784 │           20 / 20            │
//   └───────┴──────────┴────────────────┴─────────────────────────────────┴──────────────────────────────┘
//                                       Updates every three seconds...
