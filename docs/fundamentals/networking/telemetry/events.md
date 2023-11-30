---
title: Networking events
description: Learn how to consume and correlate .NET networking telemetry events.
author: MihaZupan
ms.author: mizupan
ms.date: 10/18/2022
---

# Networking events in .NET

Events give you access to:

- Accurate timestamps throughout the lifetime of an operation. For example, how long it took to connect to the server and how long it took an HTTP request to receive response headers.
- Debug/trace information that may not be obtainable by other means. For example, what kind of decisions the connection pool made and why.

The instrumentation is based on [EventSource], allowing you to collect this information from both inside and outside the process.

## Event providers

Networking information is split across the following event providers:

- `System.Net.Http` (`HttpClient` and `SocketsHttpHandler`)
- `System.Net.NameResolution` (`Dns`)
- `System.Net.Security` (`SslStream`)
- `System.Net.Sockets`
- `Microsoft.AspNetCore.Hosting`
- `Microsoft-AspNetCore-Server-Kestrel`

The telemetry has some performance overhead when enabled, so make sure to subscribe only to event providers you're actually interested in.

## Consume events in-process

Prefer in-process collection when possible for easier event correlation and analysis.

### EventListener

[EventListener] is an API that allows you to listen to [EventSource] events from within the same process that produced them.

```C#
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

The preceding code prints output similar to the following:

```output
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

### Yarp.Telemetry.Consumption

While the `EventListener` approach outlined above is useful for quick experimentation and debugging, the APIs aren't strongly typed and force you to depend on implementation details of the instrumented library.

To address this, .NET created a library that makes it easy to consume networking events in-process: [`Yarp.Telemetry.Consumption`].
While the package is currently maintained as part of the [YARP] project, it can be used in any .NET application.

To use it, implement the interfaces and methods (events) that you're interested in:

```C#
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

```C#
services.AddTelemetryConsumer<MyTelemetryConsumer>();
```

The library provides the following strongly typed interfaces:

- [`IHttpTelemetryConsumer`]
- [`INameResolutionTelemetryConsumer`]
- [`INetSecurityTelemetryConsumer`]
- [`ISocketsTelemetryConsumer`]
- [`IKestrelTelemetryConsumer`]

These callbacks are called as part of the instrumented operation, so the general logging guidance applies. You should avoid blocking or performing any expensive calculations as part of the callback. Offload any post-processing work to different threads to avoid adding latency to the underlying operation.

## Consume events from outside the process

### dotnet-trace

[`dotnet-trace`][dotnet-trace docs] is a cross-platform tool that enables the collection of .NET Core traces of a running process without a native profiler.

```console
dotnet tool install --global dotnet-trace
```

```console
dotnet-trace collect --providers System.Net.Http,System.Net.Security,System.Threading.Tasks.TplEventSource:0x80:4 --process-id 1234
```

For all the available commands and parameters, see the [dotnet-trace docs].

You can analyze the captured `.nettrace` file in Visual Studio or [PerfView].
For more information, see the [dotnet-trace analysis docs].

### PerfView

[PerfView] is a free, advanced performance analysis tool. It runs on Windows but can also analyze traces captured on Linux.

To configure the list of events to capture, specify them under `Advanced Options / Additional Providers`:

```txt
*System.Net.Sockets,*System.Net.NameResolution,*System.Net.Http,*System.Net.Security
```

### TraceEvent

[`TraceEvent`] is a library that allows you to consume events from different processes in real time. `dotnet-trace` and `PerfView` both rely on it.

If you want to process events programmatically and in real time, see the [`TraceEvent`] docs.

## Start and Stop events

Larger operations often start with a `Start` event and end with a `Stop` event.
For example, you'll see `RequestStart`/`RequestStop` events from `System.Net.Http` or `ConnectStart`/`ConnectStop` events from `System.Net.Sockets`.

While large operations such as these often guarantee that a `Stop` event will always be present, this is not always the case. For example, seeing the `RequestHeadersStart` event from `System.Net.Http` does not guarantee that `RequestHeadersStop` will also be logged.

## Event correlation

Now that you know how to observe these events, you often need to correlate them together, generally to the originating HTTP request.

Prefer in-process collection when possible for easier event correlation and analysis.

### In-process correlation

As networking uses asynchronous I/O, you can't assume that the thread that completed a given request is also the thread that started it.
This means you can't use `[ThreadLocal]` statics to correlate events, but you can use an [`AsyncLocal`].
Get familiar with [`AsyncLocal`] as this type is key to correlating work across different threads.

`AsyncLocal` allows you to access the same state deeper into the async flow of an operation. `AsyncLocal` values only flow down (deeper into the async call stack), and don't propagate changes up to the caller.

Consider the following example:

```C#
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

This code produces the following output:

```output
Value in WorkAsync: 1
Value in WorkAsync: 2
Value after WorkAsync: 1
```

The value `1` flowed down from the caller into `WorkAsync`, but the modification in `WorkAsync` (`2`) did not flow back up to the caller.

As telemetry events (and their corresponding callbacks) occur as part of the underlying operation, they happen within the same async scope as the caller that initiated the request.
This means that you can observe `asyncLocal.Value` from within the callback, but if you set the value in the callback, nothing will be able to observe it further up the stack.

The following steps show the general pattern.

1. Create a mutable class that can be updated from inside event callbacks.

    ```C#
    public sealed class RequestInfo
    {
        public DateTime StartTime, HeadersSent;
    }
    ```

1. Set the `AsyncLocal.Value` *before* the main operation so that the state will flow into the operation.

    ```C#
    private static readonly AsyncLocal<RequestInfo> _requestInfo = new();

    public async Task SendRequestAsync(string url)
    {
        var info = new RequestInfo();
        _requestInfo.Value = info;

        info.StartTime = DateTime.UtcNow;
        await _client.GetStringAsync(url);
    ```

1. Inside the event callbacks, check if the shared state is available and update it. `AsyncLocal.Value` will be `null` if the request was sent by a component that didn't set the `AsyncLocal.Value` in the first place.

    ```C#
    public void OnRequestHeadersStop(DateTime timestamp)
    {
        if (_requestInfo.Value is { } info) info.HeadersSent = timestamp;
    }
    ```

1. Process the collected information after finishing the operation.

    ```C#
    await _client.GetStringAsync(url);

    Log($"Time until headers were sent {url} was {info.HeadersSent - info.StartTime}");
    ```

For more ways to do this, see the [samples section](#samples).

### Correlation outside the process

Every event has a piece of data attached to it called [`ActivityID`]. This ID encodes the async hierarchy at the time the event was produced.

If you look at a trace file in PerfView, you'll see events like:

```txt
System.Net.Http/Request/Start           ActivityID="/#14396/1/1/"
System.Net.Http/RequestHeaders/Start    ActivityID="/#14396/1/1/2/"
System.Net.Http/RequestHeaders/Stop     ActivityID="/#14396/1/1/2/"
System.Net.Http/ResponseHeaders/Start   ActivityID="/#14396/1/1/3/"
System.Net.Http/ResponseHeaders/Stop    ActivityID="/#14396/1/1/3/"
System.Net.Http/Request/Stop            ActivityID="/#14396/1/1/"
```

You'll know that these events belong to the same request because they share the `/#14396/1/1/` prefix.

When doing manual investigations, a useful trick is to look for the `System.Net.Http/Request/Start` event of a request you're interested in, then paste its `ActivityID` in the `Text Filter` text box. If you now select all available providers, you'll see the list of all events that were produced as part of that request.

PerfView automatically collects the `ActivityID`, but if you use tools like `dotnet-trace`, you must explicitly enable the `System.Threading.Tasks.TplEventSource:0x80:4` provider (see `dotnet-trace` example above).

## HttpClient request vs. connection lifetime

Since .NET 6, an HTTP request is no longer tied to a specific connection.
Instead, the request will be serviced as soon as any connection is available.

This means you may see the following order of events:

1. Request start
1. Dns start
1. Request stop
1. Dns stop

This indicates that the request did trigger a DNS resolution, but was processed by a different connection before the DNS call completed. The same goes for socket connects or TLS handshakes - the originating request may complete before they do.

You should think about such events separately. Monitor DNS resolutions or TLS handshakes on their own without tying them to the timeline of a specific request.

## Internal diagnostics

Some components in .NET are instrumented with additional debug-level events that provide more insight into exactly what's happening internally.
These events come with high performance overhead and their shape is constantly changing. As the name suggests, they are not part of the public API and you should therefore not rely on their behavior or existence.

Regardless, these events can offer a lot of insights when all else fails.
The `System.Net` stack emits such events from `Private.InternalDiagnostics.System.Net.*` namespaces.

If you change the condition in the `EventListener` example above to `eventSource.Name.Contains("System.Net")`, you will see 100+ events from different layers in the stack.
For more information, see the [full example](https://github.com/dotnet/docs/tree/main/docs/fundamentals/networking/snippets/internal-diag-telemetry/Program.cs).

## Samples

- [Measure DNS resolutions for a given endpoint](#measure-dns-resolutions-for-a-given-endpoint)
- [Measure time-to-headers when using HttpClient](#measure-time-to-headers-when-using-httpclient)
- [Time to process a request in ASP.NET Core running Kestrel](#time-to-process-a-request-in-aspnet-core-running-kestrel)
- [Measure the latency of a .NET reverse proxy](#measure-the-latency-of-a-net-reverse-proxy)

### Measure DNS resolutions for a given endpoint

```C#
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

### Measure time-to-headers when using HttpClient

```C#
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

```C#
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

### Measure the latency of a .NET reverse proxy

This sample is applicable if you have a reverse proxy that receives inbound requests via Kestrel and makes outbound requests via HttpClient (for example, [YARP]).

This sample measures the time from receiving the request headers until they're sent out to the backend server.

```C#
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

## Need more telemetry?

If you have suggestions for other useful information that could be exposed via events or metrics, create a [dotnet/runtime issue](https://github.com/dotnet/runtime/issues/new).

If you're using the [`Yarp.Telemetry.Consumption`] library and have any suggestions, create a [microsoft/reverse-proxy issue].

[dotnet-trace docs]: ../../../core/diagnostics/dotnet-trace.md
[dotnet-trace analysis docs]: ../../../core/diagnostics/dotnet-trace.md#view-the-trace-captured-from-dotnet-trace
[PerfView]: https://github.com/microsoft/perfview
[`TraceEvent`]: https://github.com/microsoft/perfview/blob/main/documentation/TraceEvent/TraceEventLibrary.md
[YARP]: https://github.com/microsoft/reverse-proxy
[EventSource]: xref:System.Diagnostics.Tracing.EventSource
[EventListener]: xref:System.Diagnostics.Tracing.EventListener
[`Yarp.Telemetry.Consumption`]: https://www.nuget.org/packages/Yarp.Telemetry.Consumption
[`IHttpTelemetryConsumer`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/Http/IHttpTelemetryConsumer.cs
[`INameResolutionTelemetryConsumer`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/NameResolution/INameResolutionTelemetryConsumer.cs
[`INetSecurityTelemetryConsumer`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/NetSecurity/INetSecurityTelemetryConsumer.cs
[`ISocketsTelemetryConsumer`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/Sockets/ISocketsTelemetryConsumer.cs
[`IKestrelTelemetryConsumer`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/Kestrel/IKestrelTelemetryConsumer.cs
[`AsyncLocal`]: xref:System.Threading.AsyncLocal%601
[`ActivityID`]: ../../../core/diagnostics/eventsource-activity-ids.md
[microsoft/reverse-proxy issue]: https://github.com/microsoft/reverse-proxy/issues/new
