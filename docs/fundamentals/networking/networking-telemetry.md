---
title: Networking Telemetry in .NET
description: Learn how to consume and correlate .NET telemetry events.
author: MihaZupan
ms.author: mizupan
ms.date: 10/18/2022
---

# Networking Telemetry in .NET

If you are looking for information on tracking HTTP operations across different services, see the [distributed tracing documentation].

The .NET networking stack is instrumented at various layers, giving you the option to collect accurate timings throughout the lifetime of an HTTP request, and event counters to monitor overall process statistics.

Networking information is split across several groups:
- `System.Net.Http` (`HttpClient` and `SocketsHttpHandler`)
- `System.Net.NameResolution` (`Dns`)
- `System.Net.Security` (`SslStream`)
- `System.Net.Sockets`
- `Microsoft.AspNetCore.Hosting`
- `Microsoft-AspNetCore-Server-Kestrel`

The telemetry has some performance overhead when enabled, so make sure to subscribe only to groups you are actually interested in.

## Event Counters (metrics)

[EventCounters] are .NET APIs used for lightweight, cross-platform, and near real-time performance metric collection.

Networking components are instrumented to publish basic diagnostics information using EventCounters.
They include information like
- `System.Net.Http` > `requests-started`
- `System.Net.Http` > `requests-failed`
- `System.Net.Http` > `http11-connections-current-total`
- `System.Net.Security` > `all-tls-sessions-open`
- `System.Net.Sockets` > `outgoing-connections-established`
- `System.Net.NameResolution` > `dns-lookups-duration`

**For the whole list, check out [well-known counters].**

### Monitor metrics from outside the process

#### dotnet-counters

[`dotnet-counters`][dotnet-counter docs] is a cross-platform performance monitoring tool for ad-hoc health monitoring and first-level performance investigation.

```console
dotnet tool install --global dotnet-counters
```
```console
dotnet-counters monitor --counters System.Net.Http,System.Net.Security --process-id 1234
```
The command will keep refreshing the console with the latest numbers
```txt
[System.Net.Http]
    Current Http 1.1 Connections                       3
    Current Http 2.0 Connections                       1
    Current Http 3.0 Connections                       0
    Current Requests                                   4
    HTTP 1.1 Requests Queue Duration (ms)              0
    HTTP 2.0 Requests Queue Duration (ms)              0
    HTTP 3.0 Requests Queue Duration (ms)              0
    Requests Failed                                    0
    Requests Failed Rate (Count / 1 sec)               0
    Requests Started                                 470
    Requests Started Rate (Count / 1 sec)             18
```


See [dotnet-counter docs] for all the available commands and parameters.

#### Application Insights

Application Insights does not collect event counters by default.
See [AppInsights EventCounters docs] on customizing the set of counters you are interested in.

For example:
```c#
services.ConfigureTelemetryModule<EventCounterCollectionModule>((module, options) =>
{
    module.Counters.Add(new EventCounterCollectionRequest("System.Net.Http", "current-requests"));
    module.Counters.Add(new EventCounterCollectionRequest("System.Net.Http", "requests-failed"));
    module.Counters.Add(new EventCounterCollectionRequest("System.Net.Http", "http11-connections-current-total"));
    module.Counters.Add(new EventCounterCollectionRequest("System.Net.Security", "all-tls-sessions-open"));
});
```
See [this sample](https://gist.github.com/MihaZupan/02ec402fa34880df129351b92e18e86c) for subscribing to many runtime and ASP.NET event counters.

### Consume metrics in-process

The [`Yarp.Telemetry.Consumption`] library makes it easy to consume metrics from within the process.
While the package is currently maintained as part of the [YARP] project, it can be used in any .NET application.

To use it, implement the `IMetricsConsumer<TMetrics>` interface:
```c#
public sealed class MyMetricsConsumer : IMetricsConsumer<SocketsMetrics>
{
    public void OnMetrics(SocketsMetrics previous, SocketsMetrics current)
    {
        var elapsedTime = (current.Timestamp - previous.Timestamp).TotalMilliseconds;
        Console.WriteLine($"Received {current.BytesReceived - previous.BytesReceived} bytes in the last {elapsedTime:N2} ms");
    }
}
```
And register the implementations with your DI container:
```c#
services.AddSingleton<IMetricsConsumer<SocketsMetrics>, MyMetricsConsumer>();
services.AddTelemetryListeners();
```

The library provides the following strongly-typed metrics types: [`HttpMetrics`], [`NameResolutionMetrics`], [`NetSecurityMetrics`], [`SocketsMetrics`] and [`KestrelMetrics`].

## Events

Events give you access to
- accurate timestamps throughout the lifetime of an operation
  - E.g. how long it took to connect to the server and how long it took to receive response headers
- debug/trace information that may not be obtainable by other means
  - E.g. what kind of decisions did the connection pool make and why

The instrumentation is based on [EventSource], allowing you to collect this information from both inside and outside the process.

### Consume events in-process

Prefer in-process collection when possible for easier event correlation and analysis.

#### EventListener

[EventListener] is an API that allows you to listen to [EventSource] events from within the same process that produced them.
```c#
using System.Diagnostics.Tracing;

using var listener = new MyListener();

using var client = new HttpClient();
await client.GetStringAsync("https://httpbin.org/get");

public sealed class MyListener : EventListener
{
    protected override void OnEventSourceCreated(EventSource eventSource)
    {
        if (eventSource.Name == "System.Net.Http")
        {
            EnableEvents(eventSource, EventLevel.Informational);
        }
    }

    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        Console.WriteLine($"{DateTime.UtcNow:ss:fff} {eventData.EventName}: " +
            string.Join(' ', eventData.PayloadNames!.Zip(eventData.Payload!).Select(pair => $"{pair.First}={pair.Second}")));
    }
}
```
Will print something like the following:
```txt
00:598 RequestStart: scheme=https host=httpbin.org port=443 pathAndQuery=/get versionMajor=1 versionMinor=1 versionPolicy=0
01:470 ConnectionEstablished: versionMajor=1 versionMinor=1
01:474 RequestLeftQueue: timeOnQueueMilliseconds=470,6214 versionMajor=1 versionMinor=1
01:476 RequestHeadersStart:
01:477 RequestHeadersStop:
01:592 ResponseHeadersStart:
01:593 ResponseHeadersStop:
01:633 ResponseContentStart:
01:635 ResponseContentStop:
01:635 RequestStop:
01:637 ConnectionClosed: versionMajor=1 versionMinor=1
```

#### Yarp.Telemetry.Consumption

While the `EventListener` approach outlined above is useful for quick experimentation and debugging, the APIs are not strongly-typed and force you into depending on implementation details of the instrumented library.

To address this, we created a library that makes it easy to consume networking events in-process: [`Yarp.Telemetry.Consumption`].
While the package is currently maintained as part of the [YARP] project, it can be used in any .NET application.

To use it, implement the interfaces and methods (events) you are interested in:
```c#
public sealed class MyTelemetryConsumer : IHttpTelemetryConsumer, INetSecurityTelemetryConsumer
{
    public void OnRequestStart(DateTime timestamp, string scheme, string host, int port, string pathAndQuery, int versionMajor, int versionMinor, HttpVersionPolicy versionPolicy)
    {
        Console.WriteLine($"Request to {host} started at {timestamp}");
    }

    public void OnHandshakeStart(DateTime timestamp, bool isServer, string targetHost)
    {
        Console.WriteLine($"Starting TLS handshake with {targetHost}");
    }
}
```
And register the implementations with your DI container:
```c#
services.AddTelemetryConsumer<MyTelemetryConsumer>();
```

The library provides the following strongly-typed interfaces: [`IHttpTelemetryConsumer`], [`INameResolutionTelemetryConsumer`], [`INetSecurityTelemetryConsumer`], [`ISocketsTelemetryConsumer`] and [`IKestrelTelemetryConsumer`].

Note that these callbacks are called as part of the instrumented operation, so the general logging guidance applies. You should avoid blocking or performing any expensive calculations as part of the callback. Offload any post-processing work to different threads to avoid adding latency to the underlying operation.

### Consume events from outside the process

#### dotnet-trace

[`dotnet-trace`][dotnet-trace docs] is a cross-platform tool that enables the collection of .NET Core traces of a running process without a native profiler.

```console
dotnet tool install --global dotnet-trace
```
```console
dotnet-trace collect --providers System.Net.Http,System.Net.Security,System.Threading.Tasks.TplEventSource:0x80:4 --process-id 1234
```

See [dotnet-trace docs] for all the available commands and parameters.

You can analyze the captured `.nettrace` file in Visual Studio or [PerfView].
See [dotnet-trace analysis docs].

#### PerfView

[PerfView] is a free, advanced performance-analysis tool. It runs on Windows, but can also analyze traces captured on Linux.

To configure the list of events to capture, specify them under `Advanced Options / Additional Providers`:
```txt
*System.Net.Sockets,*System.Net.NameResolution,*System.Net.Http,*System.Net.Security
```

#### TraceEvent

[`TraceEvent`] is a library that allows you to consume events from different processes in real-time. `dotnet-trace` and `PerfView` both rely on it.

If you wish to process events programmatically and in real-time, see [`TraceEvent`] docs.

## Event Correlation

Now that you know how to observe these events, you often need to correlate them together, generally to the originating HTTP request.

Prefer in-process collection when possible for easier event correlation and analysis.

### In-process correlation

As networking makes use async I/O, we can't assume that the thread which completed a given request is also the thread that started it.
This means we can't use `[ThreadLocal]` statics to correlate events, but we can use an [`AsyncLocal`].
Get familiar with [`AsyncLocal`] as this type is key to correlating work across different threads.

`AsyncLocal` allows you to access the same state deeper into the async flow of an operation. `AsyncLocal` values only flow down (deeper into the async call stack), and don't propagate changes up to the caller.

Consider the following example:
```c#
AsyncLocal<int> asyncLocal = new();
asyncLocal.Value = 1;

await WorkAsync();
Console.WriteLine($"Value after WorkAsync: {asyncLocal.Value}");

async Task WorkAsync()
{
    Console.WriteLine($"Value in WorkAsync: {asyncLocal.Value}");
    asyncLocal.Value = 2;
    Console.WriteLine($"Value in WorkAsync: {asyncLocal.Value}");
}
```
which prints
```txt
Value in WorkAsync: 1
Value in WorkAsync: 2
Value after WorkAsync: 1
```
The value `1` flowed down from the caller into `WorkAsync`, but the modification in `WorkAsync` (`2`) did not flow back up to the caller.

As telemetry events (and their corresponding callbacks) occur as part of the underlying operation, they happen within the same async scope as the caller that initiated the request.
This means that you can observe `asyncLocal.Value` from within the callback, but if you set the value, nothing will be able to observe it further up the stack.

The general pattern is therefore to:
1. Create a mutable class that can be updated from inside event callbacks
    ```c#
    public sealed class RequestInfo
    {
        public DateTime StartTime, HeadersSent;
    }
    ```
1. Set the `AsyncLocal.Value` *before* the main operation so that the state will flow into it the operation.
    ```c#
    private static readonly AsyncLocal<RequestInfo> _requestInfo = new();
    
    public async Task SendRequestAsync(string url)
    {
        var info = new RequestInfo();
        _requestInfo.Value = info;
        
        info.StartTime = DateTime.UtcNow;
        await _client.GetStringAsync(url);
    ```
1. Inside the event callbacks, check if the shared state is available and update it. `AsyncLocal.Value` will be `null` if the request was sent by a component that didn't set the `AsyncLocal.Value` in the first place.
    ```c#
    public void OnRequestHeadersStop(DateTime timestamp)
    {
        if (_requestInfo.Value is { } info) info.HeadersSent = timestamp;
    }
    ```
1. Process the collected information after finishing the operation
    ```c#
    await _client.GetStringAsync(url);
    
    Log($"Time until headers were sent {url} was {info.HeadersSent - info.StartTime}");
    ```

See the samples section below for more ways to do this.

### Correlation outside the process

Every event has a piece of data attached to it called [`ActivityID`]. This ID encodes the async hierarchy at the time the event was produced.

If you look at a trace file in PerfView, you will see events like:
```txt
System.Net.Http/Request/Start           ActivityID="/#14396/1/1/"
System.Net.Http/RequestHeaders/Start    ActivityID="/#14396/1/1/2/"
System.Net.Http/RequestHeaders/Stop     ActivityID="/#14396/1/1/2/"
System.Net.Http/ResponseHeaders/Start   ActivityID="/#14396/1/1/3/"
System.Net.Http/ResponseHeaders/Stop    ActivityID="/#14396/1/1/3/"
System.Net.Http/Request/Stop            ActivityID="/#14396/1/1/"
```
You will know that these events belong to the same request because they share the `/#14396/1/1/` prefix.

When doing manual investigations, a useful trick is to look for the `System.Net.Http/Request/Start` event of a request you are interested in, then pasting its `ActivityID` in the `Text Filter` text box. If you now select all available providers, you will see the list of all events that were produced as part of that request.

PerfView will automatically collect the `ActivityID`, but if you use tools like `dotnet-trace`, you must explicitly enable the `System.Threading.Tasks.TplEventSource:0x80:4` provider (see `dotnet-trace` example above).

## HttpClient Request vs Connection lifetime

Since .NET 6, an HTTP request is no longer tied to a specific connection.
Instead, the request will be serviced as soon as any connection is available.

This means you may see the order of events such as:
1. Request start
1. Dns start
1. Request stop
1. Dns stop

This indicates that the request did trigger a DNS resolution, but was processed by a different connection before the DNS call completed. The same goes for socket connects or TLS handshakes - the originating request may complete before they do.

You should think about such events separately - monitoring DNS resolutions or TLS handshakes on their own, without tying them to the timeline of a specific request.

## Internal diagnostics

Some components in .NET are instrumented with additional debug-level events that provide a lot of insight into exactly what is happening internally.
These events come with high performance overhead and their shape is constantly changing. As the name suggests, they are not part of the public API and you should therefore not rely on their behavior or existence.

Regardless, these events can offer a lot of insights when all else fails.
The `System.Net` stack emits such events from `Private.InternalDiagnostics.System.Net.*` namespaces.

If you change the condition in the `EventListener` example above to `eventSource.Name.Contains("System.Net")`, you will see 100+ events from different layers in the stack.
See [full example](https://gist.github.com/MihaZupan/4bed7333bcafde39e8b86beef2006475).

## Feedback

If you have suggestions for other useful information that could be exposed via events or metrics, please [let us know](https://github.com/dotnet/runtime/issues/new).

If you are using the [`Yarp.Telemetry.Consumption`] library and have any suggestions, please [let us know](https://github.com/microsoft/reverse-proxy/issues/new).

## Samples

### Measuring DNS resolutions for a given endpoint

```c#
services.AddTelemetryConsumer(new DnsMonitor("httpbin.org"));

public sealed class DnsMonitor : INameResolutionTelemetryConsumer
{
    private static readonly AsyncLocal<DateTime?> _startTimestamp = new();
    private readonly string _hostname;

    public DnsMonitor(string hostname) => _hostname = hostname;

    public void OnResolutionStart(DateTime timestamp, string hostNameOrAddress)
    {
        if (hostNameOrAddress.Equals(_hostname, StringComparison.OrdinalIgnoreCase))
        {
            _startTimestamp.Value = timestamp;
        }
    }

    public void OnResolutionStop(DateTime timestamp)
    {
        if (_startTimestamp.Value is { } start)
        {
            Console.WriteLine($"DNS resolution for {_hostname} took {(timestamp - start).TotalMilliseconds} ms");
        }
    }
}
```

### Measuring time-to-headers when using HttpClient

```c#
var info = RequestState.Current; // Initialize the AsyncLocal's value ahead of time

var response = await client.GetStringAsync("http://httpbin.org/get");

var requestTime = (info.RequestStop - info.RequestStart).TotalMilliseconds;
var serverLatency = (info.HeadersReceived - info.HeadersSent).TotalMilliseconds;
Console.WriteLine($"Request took {requestTime:N2} ms, server request latency was {serverLatency:N2} ms");

public sealed class RequestState
{
    private static readonly AsyncLocal<RequestState> _asyncLocal = new();
    public static RequestState Current => _asyncLocal.Value ??= new();

    public DateTime RequestStart;
    public DateTime HeadersSent;
    public DateTime HeadersReceived;
    public DateTime RequestStop;
}

public sealed class TelemetryConsumer : IHttpTelemetryConsumer
{
    public void OnRequestStart(DateTime timestamp, string scheme, string host, int port, string pathAndQuery, int versionMajor, int versionMinor, HttpVersionPolicy versionPolicy) =>
        RequestState.Current.RequestStart = timestamp;

    public void OnRequestStop(DateTime timestamp) =>
        RequestState.Current.RequestStop = timestamp;

    public void OnRequestHeadersStop(DateTime timestamp) =>
        RequestState.Current.HeadersSent = timestamp;

    public void OnResponseHeadersStop(DateTime timestamp) =>
        RequestState.Current.HeadersReceived = timestamp;
}
```

### Time to process a request in ASP.NET Core running Kestrel

This is currently the most accurate way to measure the duration of a given request.
```c#
public sealed class KestrelTelemetryConsumer : IKestrelTelemetryConsumer
{
    private static readonly AsyncLocal<DateTime?> _startTimestamp = new();
    private readonly ILogger<KestrelTelemetryConsumer> _logger;

    public KestrelTelemetryConsumer(ILogger<KestrelTelemetryConsumer> logger) => _logger = logger;

    public void OnRequestStart(DateTime timestamp, string connectionId, string requestId, string httpVersion, string path, string method)
    {
        _startTimestamp.Value = timestamp;
    }

    public void OnRequestStop(DateTime timestamp, string connectionId, string requestId, string httpVersion, string path, string method)
    {
        if (_startTimestamp.Value is { } startTime)
        {
            var elapsed = timestamp - startTime;
            _logger.LogInformation("Request {requestId} to {path} took {elapsedMs} ms", requestId, path, elapsed.TotalMilliseconds);
        }
    }
}
```

### Measuring the latency of a .NET reverse proxy

Applicable if you have a reverse proxy that receives inbound requests via Kestrel and makes outbound requests via HttpClient (e.g. [YARP]).

Time from receiving request headers until we sent out the headers to the backend server.

```c#
public sealed class InternalLatencyMonitor : IKestrelTelemetryConsumer, IHttpTelemetryConsumer
{
    private record RequestInfo(DateTime StartTimestamp, string RequestId, string Path);

    private static readonly AsyncLocal<RequestInfo> _requestInfo = new();
    private readonly ILogger<InternalLatencyMonitor> _logger;

    public InternalLatencyMonitor(ILogger<InternalLatencyMonitor> logger) => _logger = logger;

    public void OnRequestStart(DateTime timestamp, string connectionId, string requestId, string httpVersion, string path, string method)
    {
        _requestInfo.Value = new RequestInfo(timestamp, requestId, path);
    }

    public void OnRequestHeadersStop(DateTime timestamp)
    {
        if (_requestInfo.Value is { } requestInfo)
        {
            var elapsed = (timestamp - requestInfo.StartTimestamp).TotalMilliseconds;
            _logger.LogInformation("Internal latency for {requestId} to {path} was {duration} ms", requestInfo.RequestId, requestInfo.Path, elapsed);
        }
    }
}
```

[distributed tracing documentation]: https://learn.microsoft.com/dotnet/core/diagnostics/distributed-tracing
[EventCounters]: https://learn.microsoft.com/dotnet/core/diagnostics/event-counters
[well-known counters]: https://learn.microsoft.com/dotnet/core/diagnostics/available-counters
[dotnet-counter docs]: https://learn.microsoft.com/dotnet/core/diagnostics/dotnet-counters
[dotnet-trace docs]: https://learn.microsoft.com/dotnet/core/diagnostics/dotnet-trace
[dotnet-trace analysis docs]: https://learn.microsoft.com/dotnet/core/diagnostics/dotnet-trace#view-the-trace-captured-from-dotnet-trace
[PerfView]: https://github.com/microsoft/perfview
[AppInsights EventCounters docs]: https://learn.microsoft.com/azure/azure-monitor/app/eventcounters
[`TraceEvent`]: https://github.com/microsoft/perfview/blob/main/documentation/TraceEvent/TraceEventLibrary.md
[YARP]: https://github.com/microsoft/reverse-proxy
[EventSource]: https://learn.microsoft.com/dotnet/api/system.diagnostics.tracing.eventsource
[EventListener]: https://learn.microsoft.com/dotnet/api/system.diagnostics.tracing.eventlistener
[`Yarp.Telemetry.Consumption`]: https://www.nuget.org/packages/Yarp.Telemetry.Consumption
[`HttpMetrics`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/Http/HttpMetrics.cs
[`NameResolutionMetrics`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/NameResolution/NameResolutionMetrics.cs
[`NetSecurityMetrics`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/NetSecurity/NetSecurityMetrics.cs
[`SocketsMetrics`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/Sockets/SocketsMetrics.cs
[`KestrelMetrics`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/Kestrel/KestrelMetrics.cs
[`IHttpTelemetryConsumer`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/Http/IHttpTelemetryConsumer.cs
[`INameResolutionTelemetryConsumer`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/NameResolution/INameResolutionTelemetryConsumer.cs
[`INetSecurityTelemetryConsumer`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/NetSecurity/INetSecurityTelemetryConsumer.cs
[`ISocketsTelemetryConsumer`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/Sockets/ISocketsTelemetryConsumer.cs
[`IKestrelTelemetryConsumer`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/Kestrel/IKestrelTelemetryConsumer.cs
[`AsyncLocal`]: https://learn.microsoft.com/dotnet/api/system.threading.asynclocal-1
[`ActivityID`]: https://learn.microsoft.com/dotnet/core/diagnostics/eventsource-activity-ids