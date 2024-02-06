using System;
using System.Diagnostics.Metrics;
using System.Linq;
using Microsoft.Extensions.Diagnostics.Metrics.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Project;
internal class MetricCollector
{
    static void RunIt()
    {
        // <MetricCollector>
        const string CounterName = "MyCounter";
        DateTimeOffset now = DateTimeOffset.Now;

        var timeProvider = new FakeTimeProvider(now);
        using var meter = new Meter(Guid.NewGuid().ToString());
        Counter<long> counter = meter.CreateCounter<long>(CounterName);
        using var collector = new MetricCollector<long>(counter, timeProvider);

        Assert.IsNull(collector.LastMeasurement);

        counter.Add(3);

        // Verify the update was recorded.
        Assert.AreEqual(counter, collector.Instrument);
        Assert.IsNotNull(collector.LastMeasurement);

        Assert.AreSame(collector.GetMeasurementSnapshot().Last(), collector.LastMeasurement);
        Assert.AreEqual(3, collector.LastMeasurement.Value);
        Assert.AreEqual(now, collector.LastMeasurement.Timestamp);
        // </MetricCollector>
    }

    private class FakeTimeProvider(DateTimeOffset offset) : TimeProvider()
    {
        // ...
    }
}
