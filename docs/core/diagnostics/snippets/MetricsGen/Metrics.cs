#define FIRST // FIRST SECOND

#if FIRST
//<snippet_Metrics>
using System.Diagnostics.Metrics;
using Microsoft.Extensions.Diagnostics.Metrics;

namespace MetricsGen;

internal static partial class Metric
{
    // an explicit metric name is given
    [Histogram<long>("requestName", "duration", Name = "MyCustomMetricName")]
    public static partial Latency CreateLatency(Meter meter);

    // no explicit metric name given, it is auto-generated from the method name
    [Counter<int>(MetricConstants.EnvironmentName, MetricConstants.Region, MetricConstants.RequestName, MetricConstants.RequestStatus)]
    public static partial TotalCount CreateTotalCount(Meter meter);

    [Counter<int>]
    public static partial TotalFailures CreateTotalFailures(this Meter meter);
}
//</snippet_Metrics>
#elif SECOND

using MetricsGen;
//<snippet_MetricTags>
using System.Diagnostics.Metrics;
using Microsoft.Extensions.Diagnostics.Metrics;

public static partial class Metric
{
    [Histogram<long>(typeof(MetricTags))]
    public static partial Latency CreateLatency(Meter meter);

    [Counter<long>(typeof(MetricTags))]
    public static partial TotalCount CreateTotalCount(Meter meter);

    [Counter<int>(typeof(MetricTags))]
    public static partial TotalFailures CreateTotalFailures(Meter meter);
}
//</snippet_MetricTags>
#endif
