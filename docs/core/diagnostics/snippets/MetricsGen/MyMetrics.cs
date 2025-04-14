using System.Diagnostics.Metrics;
using Microsoft.Extensions.Diagnostics.Metrics;

namespace MetricsGen;
//<snippet_SimpleMetricTag>
public struct RequestTags
{
    public string Region { get; set; }
}

public static partial class MyMetrics
{
    [Counter<int>(typeof(RequestTags))]
    public static partial RequestCount CreateRequestCount(Meter meter);
}
//</snippet_SimpleMetricTag>
