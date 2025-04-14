using System.Diagnostics.Metrics;

namespace MetricsGen;
internal class Program
{
    static void main()
    {
        var meter = new Meter("metrictest");
        var myclass = new MyClass(meter);
        myclass.ReportSampleLatency();
        myclass.ReportSampleRequestCount();
        myclass.ReportSampleFailuresCount();
    }
}
