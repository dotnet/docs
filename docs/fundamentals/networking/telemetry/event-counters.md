---
title: Networking Event Counters
description: Learn how to consume .NET networking event counters.
author: MihaZupan
ms.author: mizupan
ms.date: 10/18/2022
ms.topic: concept-article
---

# Networking event counters in .NET

[EventCounters] are .NET APIs used for lightweight, cross-platform, and near real-time performance metric collection.

Networking components are instrumented to publish basic diagnostic information using EventCounters.
They include information like the following:

- `System.Net.Http` > `requests-started`
- `System.Net.Http` > `requests-failed`
- `System.Net.Http` > `http11-connections-current-total`
- `System.Net.Security` > `all-tls-sessions-open`
- `System.Net.Sockets` > `outgoing-connections-established`
- `System.Net.NameResolution` > `dns-lookups-duration`

> [!TIP]
> For the full list, see [well-known counters].

> [!TIP]
> On projects targeting .NET 8+, consider using the newer and more feature-rich [networking metrics] instead of EventCounters.

## Providers

Networking information is split across the following providers:

- `System.Net.Http` (`HttpClient` and `SocketsHttpHandler`)
- `System.Net.NameResolution` (`Dns`)
- `System.Net.Security` (`SslStream`)
- `System.Net.Sockets`
- `Microsoft.AspNetCore.Hosting`
- `Microsoft-AspNetCore-Server-Kestrel`

The telemetry has some performance overhead when enabled, so make sure to subscribe only to providers you're actually interested in.

## Monitor event counters from outside the process

### dotnet-counters

[`dotnet-counters`][dotnet-counter docs] is a cross-platform performance monitoring tool for ad-hoc health monitoring and first-level performance investigation.

```dotnetcli
dotnet tool install --global dotnet-counters
```

```dotnetcli
dotnet-counters monitor --counters System.Net.Http,System.Net.Security --process-id 1234
```

The command continually refreshes the console with the latest numbers.

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

For all the available commands and parameters, see the [dotnet-counter docs].

### Application Insights

Application Insights does not collect event counters by default.
For information on customizing the set of counters you're interested in, see the [AppInsights EventCounters docs].

For example:

```C#
services.ConfigureTelemetryModule<EventCounterCollectionModule>((module, options) =>
{
    module.Counters.Add(new EventCounterCollectionRequest("System.Net.Http", "current-requests"));
    module.Counters.Add(new EventCounterCollectionRequest("System.Net.Http", "requests-failed"));
    module.Counters.Add(new EventCounterCollectionRequest("System.Net.Http", "http11-connections-current-total"));
    module.Counters.Add(new EventCounterCollectionRequest("System.Net.Security", "all-tls-sessions-open"));
});
```

For an example of how to subscribe to many runtime and ASP.NET event counters, see the [RuntimeEventCounters sample](https://github.com/dotnet/docs/tree/main/docs/fundamentals/networking/snippets/misc/RuntimeEventCounters.cs). Simply add an `EventCounterCollectionRequest` for every entry.

```C#
foreach (var (eventSource, counters) in RuntimeEventCounters.EventCounters)
{
    foreach (string counter in counters)
    {
        module.Counters.Add(new EventCounterCollectionRequest(eventSource, counter));
    }
}
```

## Consume event counters in-process

The [`Yarp.Telemetry.Consumption`] library makes it easy to consume event counters from within the process.
While the package is currently maintained as part of the [YARP] project, it can be used in any .NET application.

To use it, implement the `IMetricsConsumer<TMetrics>` interface:

```C#
public sealed class MyMetricsConsumer : IMetricsConsumer<SocketsMetrics>
{
    public void OnMetrics(SocketsMetrics previous, SocketsMetrics current)
    {
        var elapsedTime = (current.Timestamp - previous.Timestamp).TotalMilliseconds;
        Console.WriteLine($"Received {current.BytesReceived - previous.BytesReceived} bytes in the last {elapsedTime:N2} ms");
    }
}
```

Then register the implementations with your DI container:

```C#
services.AddSingleton<IMetricsConsumer<SocketsMetrics>, MyMetricsConsumer>();
services.AddTelemetryListeners();
```

The library provides the following strongly typed metrics types:

- [`HttpMetrics`]
- [`NameResolutionMetrics`]
- [`NetSecurityMetrics`]
- [`SocketsMetrics`]
- [`KestrelMetrics`]

## Need more telemetry?

If you have suggestions for other useful information that could be exposed via events or metrics, create a [dotnet/runtime issue](https://github.com/dotnet/runtime/issues/new).

If you're using the [`Yarp.Telemetry.Consumption`] library and have any suggestions, create a [microsoft/reverse-proxy issue].

[networking metrics]: ./metrics.md
[EventCounters]: ../../../core/diagnostics/event-counters.md
[well-known counters]: ../../../core/diagnostics/available-counters.md
[dotnet-counter docs]: ../../../core/diagnostics/dotnet-counters.md
[AppInsights EventCounters docs]: /azure/azure-monitor/app/eventcounters
[YARP]: https://github.com/microsoft/reverse-proxy
[`Yarp.Telemetry.Consumption`]: https://www.nuget.org/packages/Yarp.Telemetry.Consumption
[`HttpMetrics`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/Http/HttpMetrics.cs
[`NameResolutionMetrics`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/NameResolution/NameResolutionMetrics.cs
[`NetSecurityMetrics`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/NetSecurity/NetSecurityMetrics.cs
[`SocketsMetrics`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/Sockets/SocketsMetrics.cs
[`KestrelMetrics`]: https://github.com/microsoft/reverse-proxy/blob/main/src/TelemetryConsumption/Kestrel/KestrelMetrics.cs
[microsoft/reverse-proxy issue]: https://github.com/microsoft/reverse-proxy/issues/new
