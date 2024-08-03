using System.Diagnostics;
using System.Diagnostics.Metrics;

internal class Diagnostics
{
    public static void RunIt()
    {
        // <AddLink>
        ActivityContext activityContext = new(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.None);
        ActivityLink activityLink = new(activityContext);

        Activity activity = new("LinkTest");
        activity.AddLink(activityLink);
        // </AddLink>

        // <Gauge>
        Meter meter = new("MeasurementLibrary.Sound");
        Gauge<int> gauge = meter.CreateGauge<int>(
            name: "NoiseLevel",
            unit: "dB", // Decibels.
            description: "Background Noise Level"
            );
        gauge.Record(10, new TagList() { { "Room1", "dB" } } );
        // </Gauge>
    }
}
