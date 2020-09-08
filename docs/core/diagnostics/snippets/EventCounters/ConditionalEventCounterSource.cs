using System.Diagnostics.Tracing;

[EventSource(Name = "Sample.EventCounter.Conditional")]
public sealed class ConditionalEventCounterSource : EventSource
{
    public static readonly ConditionalEventCounterSource Log = new ConditionalEventCounterSource();

    private EventCounter _requestCounter;

    private ConditionalEventCounterSource() { }

    protected override void OnEventCommand(EventCommandEventArgs args)
    {
        if (args.Command == EventCommand.Enable)
        {
            _requestCounter ??= new EventCounter("request-time", this)
            {
                DisplayName = "Request Processing Time",
                DisplayUnits = "ms"
            };
        }
    }

    public void Request(string url, float elapsedMilliseconds)
    {
        if (IsEnabled())
        {
            _requestCounter?.WriteMetric(elapsedMilliseconds);
        }
    }

    protected override void Dispose(bool disposing)
    {
        _requestCounter?.Dispose();
        _requestCounter = null;

        base.Dispose(disposing);
    }
}
