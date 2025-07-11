using System.Diagnostics.Metrics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Spectre.Console;

// <setup>
var app = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddLogging(static builder => builder.AddConsole())
                .AddResourceMonitoring();
    })
    .Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
await app.StartAsync();
// </setup>

using var cancellationTokenSource = new CancellationTokenSource();
var token = cancellationTokenSource.Token;
Console.CancelKeyPress += (_, e) =>
{
    e.Cancel = true;
    cancellationTokenSource.Cancel();
};

// <monitor>
await StartMonitoringAsync(logger, token);

async Task StartMonitoringAsync(ILogger logger, CancellationToken cancellationToken)
{
    var table = new Table()
        .Centered()
        .Title("Resource Monitoring", new Style(foreground: Color.Purple, decoration: Decoration.Bold))
        .RoundedBorder()
        .BorderColor(Color.Cyan1)
        .AddColumns(
        [
            new TableColumn("Time").Centered(),
            new TableColumn("CPU limit %").Centered(),
            new TableColumn("CPU request %").Centered(),
            new TableColumn("Memory limit %").Centered(),
        ]);

    const string rmMeterName = "Microsoft.Extensions.Diagnostics.ResourceMonitoring";
    using var meter = new Meter(rmMeterName);
    using var meterListener = new MeterListener
    {
        InstrumentPublished = (instrument, listener) =>
        {
            if (instrument.Meter.Name == rmMeterName &&
                instrument.Name.StartsWith("container."))
            {
                listener.EnableMeasurementEvents(instrument, null);
            }
        }
    };
    
    var samples = new Dictionary<string, double>();
    meterListener.SetMeasurementEventCallback<double>((instrument, value, _, _) =>
    {
        if (instrument.Meter.Name == rmMeterName)
        {
            samples[instrument.Name] = value;
        }
    });
    meterListener.Start();

    await AnsiConsole.Live(table)
        .StartAsync(async ctx =>
        {
            var window = TimeSpan.FromSeconds(5);
            while (cancellationToken.IsCancellationRequested is false)
            {
                meterListener.RecordObservableInstruments();

                table.AddRow(
                    [
                        $"{DateTime.Now:T}",
                        $"{samples["container.cpu.limit.utilization"]:p}",
                        $"{samples["container.cpu.request.utilization"]:p}",
                        $"{samples["container.memory.limit.utilization"]:p}",
                    ]);

                ctx.Refresh();

                await Task.Delay(window);
            }
        });
}
// </monitor>
