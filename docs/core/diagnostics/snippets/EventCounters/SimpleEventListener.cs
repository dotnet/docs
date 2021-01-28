using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

public class SimpleEventListener : EventListener
{
    private int _intervalSec;
    private bool _fullyInitialized = false;
    private bool _receivedCallback = false;

    private EventSource _systemRuntime;

    // used to lock the fields _intervalSec, _fullyInitialized, and _receivedCallback
    private object _lock = new object();

    public SimpleEventListener(int intervalSec)
    {
        lock (_lock)
        {
            _intervalSec = intervalSec <= 0
                ? throw new ArgumentException("Interval must be at least 1 second.", nameof(intervalSec))
                : intervalSec;

            if (_receivedCallback)
            {
                EnableEvents(_systemRuntime, EventLevel.Verbose, EventKeywords.All, new Dictionary<string, string>()
                {
                    ["EventCounterIntervalSec"] = _intervalSec.ToString()
                });
            }
            _fullyInitialized = true;
        }
    }

    protected override void OnEventSourceCreated(EventSource source)
    {
        if (!source.Name.Equals("System.Runtime"))
        {
            return;
        }

        lock (_lock)
        {
            if (_fullyInitialized)
            {
                EnableEvents(source, EventLevel.Verbose, EventKeywords.All, new Dictionary<string, string>()
                {
                    ["EventCounterIntervalSec"] = _intervalSec.ToString()
                });
            }
            _systemRuntime = source;
            _receivedCallback = true;
        }
    }

    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        if (!eventData.EventName.Equals("EventCounters"))
        {
            return;
        }

        for (int i = 0; i < eventData.Payload.Count; ++ i)
        {
            if (eventData.Payload[i] is IDictionary<string, object> eventPayload)
            {
                var (counterName, counterValue) = GetRelevantMetric(eventPayload);
                Console.WriteLine($"{counterName} : {counterValue}");
            }
        }
    }

    private static (string counterName, string counterValue) GetRelevantMetric(
        IDictionary<string, object> eventPayload)
    {
        var counterName = "";
        var counterValue = "";

        if (eventPayload.TryGetValue("DisplayName", out object displayValue))
        {
            counterName = displayValue.ToString();
        }
        if (eventPayload.TryGetValue("Mean", out object value) ||
            eventPayload.TryGetValue("Increment", out value))
        {
            counterValue = value.ToString();
        }

        return (counterName, counterValue);
    }
}
