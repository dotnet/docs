#define FIRST // FIRST SECOND THIRD
#if FIRST
using System.Diagnostics.Metrics;

namespace MetricsGen;

// <creation>
internal class MyClass
{
    private string envName = "envValue";
    private string regionName = "regionValue";
    private string requestName = "requestNameValue";
    private string status = "requestStatusValue";
    private string duration = "1:00:00";

    private readonly Latency _latencyMetric;
    private readonly TotalCount _totalCountMetric;
    private readonly TotalFailures _totalFailuresMetric;

    public MyClass(Meter meter)
    {
        // Create metric instances using the source-generated factory methods
        _latencyMetric = Metric.CreateLatency(meter);
        _totalCountMetric = Metric.CreateTotalCount(meter);
        // This syntax is available since `CreateTotalFailures` is defined as an extension method
        _totalFailuresMetric = meter.CreateTotalFailures();
    }

    public void ReportSampleRequestCount()
    {
        // method logic ...

        // Invoke Add on the counter and pass the dimension values you need.
        _totalCountMetric.Add(1, envName, regionName, requestName, status);
    }

    public void ReportSampleLatency()
    {
        // method logic ...

        // Invoke Record on the histogram and pass the dimension values you need.
        _latencyMetric.Record(1, requestName, duration);
    }

    public void ReportSampleFailuresCount()
    {
        // method logic ...

        // Invoke Add on the counter and pass the dimension values you need.
        _totalFailuresMetric.Add(1);
    }
}
// </creation>

#elif SECOND

using System.Diagnostics;
using System.Diagnostics.Metrics;
using MetricsGen;

// <creationwithtags>
internal class MyClass
{
    private readonly Latency _latencyMetric;
    private readonly TotalCount _totalCountMetric;
    private readonly TotalFailures _totalFailuresMetric;

    public MyClass(Meter meter)
    {
        // Create metric instances using the source-generated factory methods
        _latencyMetric = Metric.CreateLatency(meter);
        _totalCountMetric = Metric.CreateTotalCount(meter);
        _totalFailuresMetric = Metric.CreateTotalFailures(meter);
    }

    public void DoWork()
    {
        var startingTimestamp = Stopwatch.GetTimestamp();
        bool requestSuccessful = true;
        // Perform some operation to measure
        var elapsedTime = Stopwatch.GetElapsedTime(startingTimestamp);

        // Create a tag object with values for all tags
        var tags = new MetricTags
        {
            Dim1 = "Dim1Value",
            Operation = Operations.Operation1,
            ParentOperationName = "ParentOpValue",
            ChildTagsObject = new MetricChildTags
            {
                Dim2 = "Dim2Value",
            },
            ChildTagsStruct = new MetricTagsStruct
            {
                Dim3 = "Dim3Value"
            }
        };

        // Record the metric values with the associated tags
        _latencyMetric.Record(elapsedTime.ElapsedMilliseconds, tags);
        _totalCountMetric.Add(1, tags);
        if (!requestSuccessful)
        {
            _totalFailuresMetric.Add(1, tags);
        }
    }
}
// </creationwithtags>
#elif THIRD

using MetricsGen;
using System.Diagnostics.Metrics;

// <tag>
Meter meter = new("MyCompany.MyApp", "1.0");
RequestCount requestCountMetric = MyMetrics.CreateRequestCount(meter);

// Create a tag object with the relevant tag value
var tags = new RequestTags { Region = "NorthAmerica" };

// Record a metric value with the associated tag
requestCountMetric.Add(1, tags);

// </tag>
#endif
