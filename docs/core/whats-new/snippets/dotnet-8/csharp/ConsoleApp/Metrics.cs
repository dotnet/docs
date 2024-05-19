using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.DependencyInjection;

internal class Metrics
{
    public static void RunMetrics()
    {
        ServiceCollection services = new();
        ServiceProvider serviceProvider = services.BuildServiceProvider();
        IMeterFactory? meterFactory = serviceProvider.GetService<IMeterFactory>();

        // <MetricsTags>
        var options = new MeterOptions("name")
        {
            Version = "version",
            // Attach these tags to the created meter.
            Tags = new TagList()
            {
                { "MeterKey1", "MeterValue1" },
                { "MeterKey2", "MeterValue2" }
            }
        };

        Meter meter = meterFactory!.Create(options);

        Counter<int> counterInstrument = meter.CreateCounter<int>(
            "counter", null, null, new TagList() { { "counterKey1", "counterValue1" } }
        );
        counterInstrument.Add(1);
        // </MetricsTags>
    }
}
