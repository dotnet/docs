---
title: EventCounters Overview - .NET Core
description: Learn about EventCounters, how to work with them, how to implement them, and consume them.
ms.date: 07/22/2020
---

# EventCounters in .NET Core

**This article applies to: ✔️** .NET Core 3.0 SDK and later versions

EventCounters are .NET Core APIs used for lightweight, cross-platform, and near real-time performance metric collection. EventCounters were added as a cross-platform alternative to the "performance counters" on the .NET Framework on Windows. This article serves as a guide on what they are, how to implement them, and how to consume them.

The .NET Core runtime and few .NET libraries publish basic diagnostics information using EventCounters starting in .NET Core 3.0.

Apart from the EventCounters that are already provided by the .NET runtime or the rest of the framework (that is; ASP.NET, gRPC, etc.), you may choose to implement your own EventCounters to keep track of various metrics for your service.

EventCounters live as a part of an <xref:System.Diagnostics.Tracing.EventSource>, and are automatically pushed to listener tools on a regular basis. Like all other events on an <xref:System.Diagnostics.Tracing.EventSource>, they can be consumed both in-proc and out-of-proc via <xref:System.Diagnostics.Tracing.EventListener> and EventPipe/ETW (Event Tracing for Windows).

[![EventCounters in-proc and out-of-proc diagram image](media/eventcounters.jpg)](media/eventcounters.jpg#lightbox)

## Runtime Counters

The .NET runtime publishes the following list of counters:
`System.Runtime` provider

- CPU usage
- Working Set Size
- GC Heap Size
- Gen 0 GC Rate
- Gen 1 GC Rate
- Gen 2 GC Rate
- % Time in GC
- Gen 0 Heap Size
- Gen 1 Heap Size
- Gen 2 Heap Size
- LOH Heap Size
- Allocation Rate
- Assembly Count
- Exception Rate
- ThreadPool Thread Count
- Monitor Lock Contention Rate
- ThreadPool Queue Length
- ThreadPool Completed Items Rate
- Active Timer Count

Other components of .NET Core also publish counters:
ASP.NET Core `Microsoft.AspNetCore.Hosting` provider

- Requests per second
- Total Requests Count
- Current Requests Count
- Failed Requests Count

SignalR `Microsoft.AspNetCore.Http.Connections` provider

- Total Connections Started
- Total Connections Stopped
- Total Connections Timed Out
- Average Connection Duration

## EventCounters API Overview

At a high level, there are two types of counters in terms of their _purpose_ - counters for ever-increasing values (that is, Total # of exceptions, Total # of GCs, Total # of requests, etc.) and "snapshot" values (heap usage, CPU usage, working set size, etc.). Within each of these categories of counters, there are also two types of counters depending on how they get their value - polling counters (value retrieved via a callback) and non-polling counters (value directly set on the counter). That gives us a total of four different counters, and each of these are implemented by <xref:System.Diagnostics.Tracing.EventCounter>, <xref:System.Diagnostics.Tracing.IncrementingEventCounter>, and <xref:System.Diagnostics.Tracing.IncrementingPollingCounter>, and <xref:System.Diagnostics.Tracing.PollingCounter>.

The runtime supports four different types of counters for different situations:

1. <xref:System.Diagnostics.Tracing.EventCounter> records a set of values. The <xref:System.Diagnostics.Tracing.EventCounter.WriteMetric%2A?displayProperty=nameWithType> method adds a new value to the set. At the end of each time interval, summary statistics for the set are computed such as the min, max, and mean. dotnet-counters will always display the mean value. EventCounter is useful to describe a discrete set of operations such as the average size in bytes of recent IO operations or the average monetary value of a set of financial transactions.

1. <xref:System.Diagnostics.Tracing.IncrementingEventCounter> records a running total. The <xref:System.Diagnostics.Tracing.IncrementingEventCounter.Increment%2A?displayProperty=nameWithType> method increases this total. At the end of each time period the difference between the total value for that period and the total of the previous period is reported as an increment. dotnet-counters will display this as a rate, the recorded total / time. This counter is useful to measure how frequently an action is occurring such as the number of requests processed each second.

1. <xref:System.Diagnostics.Tracing.IncrementingPollingCounter> is a customizable counter that has no state and uses a callback to determine the increment that is reported. At the end of each time interval the callback is invoked and then the difference between the current invocation and the last invocation is the reported value. [dotnet-counters](dotnet-counters.md) always displays this as a rate, the reported value / time. This is useful to measure the rate at which some action is occurring when it isn't feasible to call an API on each occurrence, but it is possible to query the total number of times it has occurred. For example, you could report the number of bytes written to a file / sec even if there is no notification each time a byte is written.

1. <xref:System.Diagnostics.Tracing.PollingCounter> is a customizable counter that doesn't have any state and uses a callback to determine the value that is reported. At the end of each time interval the user provided callback function is invoked and whatever value it returns is reported as the current value of the counter. This counter can be used to query a metric from an external source, for example getting the current free bytes on a disk. It can also be used to report custom statistics that can be computed on demand by an application such as 95th percentile of recent request latencies or the current hit/miss ratio of a cache.

## Writing EventCounters

The following code implements a sample <xref:System.Diagnostics.Tracing.EventSource> exposed as the named `"Samples-EventCounterDemos-Minimal"` provider. This source contains an <xref:System.Diagnostics.Tracing.EventCounter> representing request processing time. Such a counter has a name (that is, its unique ID in the source) and a display name both used by listener tools such as [dotnet-counter](dotnet-counters.md).

```csharp
using System;
using System.Diagnostics.Tracing;

[EventSource(Name = "Samples-EventCounterDemos-Minimal")]
public sealed class MinimalEventCounterSource : EventSource
{
    // Define the singleton instance of the event source
    public static MinimalEventCounterSource Log = new MinimalEventCounterSource();
    public EventCounter RequestTimeCounter;

    private MinimalEventCounterSource() : base(EventSourceSettings.EtwSelfDescribingEventFormat)
    {
        RequestTimeCounter = new EventCounter("request-time", this)
        {
            DisplayName = "Request Processing Time",
            DisplayUnits = "MSec"
        };
    }

    public static void Main()
    {
        var rand = new Random();
        while(true)
        {
            MinimalEventCounterSource.Log.RequestTimeCounter.WriteMetric(rand.NextDouble());
        }
    }
}
```

Create a new dotnet console app using the code above and run it. Then use `dotnet-counters ps` to see what its process ID is:

```console
dotnet-counters ps
   1398652 dotnet     C:\Program Files\dotnet\dotnet.exe
   1399072 dotnet     C:\Program Files\dotnet\dotnet.exe
   1399112 dotnet     C:\Program Files\dotnet\dotnet.exe
   1401880 dotnet     C:\Program Files\dotnet\dotnet.exe
   1400180 sample-counters C:\sample-counters\bin\Debug\netcoreapp3.1\sample-counters.exe
```

You need to pass the <xref:System.Diagnostics.Tracing.EventSource> name as an argument to `--providers` to start monitoring your counter with the following command:

```console
dotnet-counters monitor --process-id 1400180 --providers Samples-EventCounterDemos-Minimal
```

Then you will see the following screen in your console:

```console
Press p to pause, r to resume, q to quit.
    Status: Running

[Samples-EventCounterDemos-Minimal]
    Request Processing Time (MSec)                            0.445
```

Let's take a look at a couple of sample implementations in the .NET Core runtime. Here is the runtime implementation for the counter that tracks the working set size of the application.

```csharp
var workingSetCounter = new PollingCounter(
    "working-set",
    this,
    () => (double)(Environment.WorkingSet / 1_000_000)
)
{
    DisplayName = "Working Set",
    DisplayUnits = "MB"
};
```

This counter reports the current working set of the app. It is a <xref:System.Diagnostics.Tracing.PollingCounter>, since it captures a metric at a moment in time. The callback for polling a value is the provided lambda expression , which is just a call to the <xref:System.Environment.WorkingSet?displayProperty=fullName> API. The <xref:System.Diagnostics.Tracing.DiagnosticCounter.DisplayName> and <xref:System.Diagnostics.Tracing.DiagnosticCounter.DisplayUnits> is an optional property that can be set to help the consumer side of the counter to display the value more easily/accurately. For example [dotnet-counters](dotnet-counters.md) uses these properties to display the more "pretty" version of the counter names.

And that's it! For <xref:System.Diagnostics.Tracing.PollingCounter> (or <xref:System.Diagnostics.Tracing.IncrementingPollingCounter>), there is nothing else that needs to be done since they poll the values themselves at the interval requested by the consumer.

Here is another example of runtime counter implemented using <xref:System.Diagnostics.Tracing.IncrementingPollingCounter>.

```csharp
var monitorContentionCounter = new IncrementingPollingCounter(
    "monitor-lock-contention-count",
    this,
    () => Monitor.LockContentionCount
)
{
    DisplayName = "Monitor Lock Contention Count",
    DisplayRateTimeScale = TimeSpan.FromSeconds(1)
};
```

This counter uses the <xref:System.Threading.Monitor.LockContentionCount?displayProperty=nameWithType> API to report the increment of the total lock contention count. The <xref:System.Diagnostics.Tracing.IncrementingPollingCounter.DisplayRateTimeScale> property is an optional that can be set to provide a hint of what time interval this counter is best displayed at. For example, the lock contention count is best displayed as _count per second_, so its <xref:System.Diagnostics.Tracing.IncrementingPollingCounter.DisplayRateTimeScale> is set to 1 second. This can be adjusted for different types of rate counters.

There are more counter implementations to use as a reference in the [.NET runtime](https://github.com/dotnet/runtime/blob/master/src/libraries/System.Private.CoreLib/src/System/Diagnostics/Tracing/RuntimeEventSource.cs) repo.

## Concurrency

It is important to note that if the delegates passed to the <xref:System.Diagnostics.Tracing.PollingCounter>/<xref:System.Diagnostics.Tracing.IncrementingPollingCounter> instances are called by multiple threads at once, the EventCounters API does not guarantee thread safety. It is the author's responsibility to guarantee the thread-safety of the delegates being passed to the counter APIs.

For example, let's suppose we have the following <xref:System.Diagnostics.Tracing.EventSource> to keep track of requests.

```csharp
public class RequestEventSource : EventSource
{
    // Define a singleton instance of the request EventSource.
    public static RequestEventSource Log = new RequestEventSource();

    public IncrementingPollingCounter RequestRateCounter;
    private int _requestCount = 0;

    private RequestEventSource() : base(EventSourceSettings.EtwSelfDescribingEventFormat)
    {
        RequestRateCounter = new IncrementingPollingCounter("request-rate", this, () => _requestCnt)
        {
            DisplayName = "Request Rate",
            DisplayRateTimeScale = TimeSpan.FromSeconds(1)
        };
    }

    // Method being called from request handlers to log that a request happened
    public void AddRequest()
    {
        _requestCount++;
    }
}
```

`RequestEventSource.AddRequest()` can be called from a request handler, and `RequestRateCounter` simply polls this value at the interval specified by the consumer of this counter. However, this method can be called by multiple threads at once, putting a race condition on `_requestCount`.

Therefore, this method should be modified to update the value in a thread-safe way.

```csharp
public void AddRequest()
{
    Interlocked.Increment(ref _requestCount);
}
```

## Consuming EventCounters

There are two primary ways of consuming EventCounters, either in-proc, or out-of-proc.

### Consuming in-proc

You can consume the counter values via the `EventListener` API. `EventListener` is an in-proc way of consuming any Events written by all instances of <xref:System.Diagnostics.Tracing.EventSource> in your application. For more information on how to use the EventListener API, see to <xref:System.Diagnostics.Tracing.EventListener>.

First, the <xref:System.Diagnostics.Tracing.EventSource> that produces the counter value needs to be enabled. To do this, you can override the `OnEventSourceCreated` method to get a notification when an <xref:System.Diagnostics.Tracing.EventSource> is created, and if this is the correct <xref:System.Diagnostics.Tracing.EventSource> with your EventCounters, then you can call Enable on it. Here is an example of such override:

```csharp
protected override void OnEventSourceCreated(EventSource source)
{
    if (source.Name.Equals("System.Runtime"))
    {
        var refreshInterval = new Dictionary<string, string>()
        {
            ["EventCounterIntervalSec"] = "1"
        };

        EnableEvents(source, 1, 1, refreshInterval);
    }
}
```

#### Sample Code

This is a sample <xref:System.Diagnostics.Tracing.EventListener> class that simply prints out all the counter names and values from the .NET runtime's <xref:System.Diagnostics.Tracing.EventSource> for publishing its internal counters (`System.Runtime`) at some interval.

```csharp
public class SimpleEventListener : EventListener
{
    private readonly EventLevel _level = EventLevel.Verbose;
    private int _intervalSec;

    public int EventCount { get; private set; }

    public SimpleEventListener(int intervalSec)
    {
        _intervalSec = intervalSec;
    }

    protected override void OnEventSourceCreated(EventSource source)
    {
        if (source.Name.Equals("System.Runtime"))
        {
            var refreshInterval = new Dictionary<string, string>()
            {
                ["EventCounterIntervalSec"] = "1"
            };

            EnableEvents(source, _level, (EventKeywords)(-1), refreshInterval);
        }
    }

    private (string counterName, string counterValue) GetRelevantMetric(
        IDictionary<string, object> eventPayload)
    {
        string counterName = "";
        string counterValue = "";

        foreach ((string key, object value) in eventPayload)
        {
            if (key.Equals("DisplayName"))
            {
                counterName = value.ToString();
            }
            else if (key.Equals("Mean") || key.Equals("Increment"))
            {
                counterValue = value.ToString();
            }
        }

        return (counterName, counterValue);
    }

    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        if (eventData.EventName.Equals("EventCounters"))
        {
            for (int i = 0; i < eventData.Payload.Count; i++)
            {
                if (eventData.Payload[i] is IDictionary<string, object> eventPayload)
                {
                    (string counterName, string counterValue) = GetRelevantMetric(eventPayload);
                    Console.WriteLine($"{counterName} : {counterValue}");
                }
            }
        }
    }
}
```

As shown above, you _must_ make sure the `"EventCounterIntervalSec"` argument is set in the `filterPayload` argument when calling <xref:System.Diagnostics.Tracing.EventListener.EnableEvents%2A>. Otherwise the counters will not be able to flush out values since it doesn't know at which interval it should be getting flushed out.

### Consuming out-of-proc

Consuming EventCounters out-of-proc is also possible. For those that are familiar with ETW, you can use ETW to capture counter data as events and view them on your ETW trace viewer (PerfView, WPA, etc.). You may also use `dotnet-counters` to consume it cross-platform via EventPipe. You can also use TraceEvent to consume these.

#### dotnet-counters

dotnet-counters is a cross-platform dotnet CLI tool that can be used to monitor the counter values. To find out how to use `dotnet-counters` to monitor your counters, see [dotnet-counters](dotnet-counters.md).

#### ETW/PerfView

Since <xref:System.Diagnostics.Tracing.EventCounter> payloads are reported as <xref:System.Diagnostics.Tracing.EventSource> events, you can use PerfView to collect/view these counter-data.

Here is a command that can be passed to PerfView to collect an ETW trace with the counters.

```
PerfView.exe /onlyProviders=*Samples-EventCounterDemos-Minimal:EventCounterIntervalSec=1 collect
```

#### dotnet-trace

Similar to how PerfView can be used to consume the counter data through ETW, dotnet-trace can be used to consume the counter data through EventPipe.

Here is an example of using dotnet-trace to get the same counter data.

```
dotnet-trace collect --process-id <pid> --providers Samples-EventCounterDemos-Minimal:0:0:EventCounterIntervalSec=1
```

For more information on how to collect counter values over time, see the corresponding [dotnet-trace](dotnet-trace.md#use-dotnet-trace-to-collect-counter-values-over-time) section.

#### TraceEvent

TraceEvent is a managed library that makes it easy to consume ETW and EventPipe events. For more information, see the [TraceEvent Library Programmers Guide](https://github.com/Microsoft/perfview/blob/master/documentation/TraceEvent/TraceEventProgrammersGuide.md).

For additional code samples, see [Criteo Labs blog](https://medium.com/criteo-labs/net-core-counters-internals-how-to-integrate-counters-in-your-monitoring-pipeline-5354cd61b42e).
