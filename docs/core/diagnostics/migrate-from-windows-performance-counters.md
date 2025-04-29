---
title: Migrate from .NET Windows Performance Counters to .NET Core metrics
description: Learn how to migrate from .NET Framework Windows Performance Counters to .NET Core/NET 5+ metrics using EventCounters and Meters.
ms.date: 04/27/2025
---

# Migrate from .NET Windows Performance Counters to .NET Core metrics

.NET Framework applications running on Windows can use Windows Performance Counters for monitoring application health and performance. However, in .NET Core and later versions, the platform provides [cross-platform alternatives](compare-metric-apis.md) through the [EventCounters](./event-counters.md) and [System.Diagnostics.Metrics](./metrics.md) APIs.

This article provides guidance on migrating from Windows Performance Counters to the newer metrics systems available in modern .NET versions.

## A short history of .NET metrics

.NET applications can be monitored using different mechanisms depending on the .NET version and platform:

- **.NET Framework**: Primarily uses Windows Performance Counters (Windows only)
- **.NET Core 3.0-3.1, .NET 5+**: Introduced EventCounters (cross-platform) and built-in [runtime metrics](./available-counters.md#systemruntime-counters), [networking metrics](./available-counters.md#systemnethttp-counters), and [ASP.NET metrics](./available-counters.md#microsoft-aspnetcore-server-kestrel-counters) using these APIs
- **.NET 6+**: Added System.Diagnostics.Metrics API (cross-platform, OpenTelemetry compatible)
- **.NET 8+**: Added built-in [networking metrics](./built-in-metrics-system-net.md) and [ASP.NET metrics](/aspnet/core/log-mon/metrics/built-in) using the new System.Diagnostics.Metrics API
- **.NET 9+**: Added built-in [runtime metrics](./built-in-metrics-runtime.md) using the new System.Diagnostics.Metrics API

The newer metrics systems offer several advantages:

- **Cross-platform operation**: Works on Windows, Linux, macOS
- **Container-friendly**: Works in containerized environments
- **Modern tooling**: Integration with OpenTelemetry and observability platforms
- **Supports xcopy install**: No additional installation steps or privileges are required

See the [Metrics API comparison](compare-metric-apis.md) for more details.

## Collecting metrics in modern .NET applications

See the [System.Diagnostics.Metrics](./metrics-collection.md) and [EventCounters](./event-counters.md) guides to collect and analyze metrics.

## Mapping common Windows Performance Counters to modern metrics

If the monitoring system for your .NET Framework application is using runtime provided Windows Performance Counters, you will need to select alternative [EventCounters](./event-counters.md)
or [System.Diagnostics.Metrics](./metrics.md) based metrics instead. The tables below show alternatives for many common counters. Not all .NET Framework counters have been ported to new alternatives.
In some cases infrequently used counters were discontinued and in other cases implementation changes in the platform have made certain counters irrelevant.

### Memory counters

| Windows Performance Counter | EventCounter equivalent | Metrics API equivalent |
|----------------------------|--------------------------|------------------------|
| `.NET CLR Memory\# Bytes in all Heaps` | `System.Runtime\GC Heap Size` (`gc-heap-size`) | `System.Runtime\dotnet.gc.last_collection.heap.size` |
| `.NET CLR Memory\# Gen 0 Collections` | `System.Runtime\Gen 0 GC Count` (`gen-0-gc-count`) | `System.Runtime\dotnet.gc.collections` with attribute `gc.heap.generation=gen0` |
| `.NET CLR Memory\# Gen 1 Collections` | `System.Runtime\Gen 1 GC Count` (`gen-1-gc-count`) | `System.Runtime\dotnet.gc.collections` with attribute `gc.heap.generation=gen1` |
| `.NET CLR Memory\# Gen 2 Collections` | `System.Runtime\Gen 2 GC Count` (`gen-2-gc-count`) | `System.Runtime\dotnet.gc.collections` with attribute `gc.heap.generation=gen2` |
| `.NET CLR Memory\% Time in GC` | `System.Runtime\% Time in GC since last GC` (`time-in-gc`) | `System.Runtime\dotnet.gc.pause.time` (calculate as percentage of total time) |
| `.NET CLR Memory\# Total committed Bytes` | None | `System.Runtime\dotnet.gc.last_collection.memory.committed_size` |
| `.NET CLR Memory\Large Object Heap Size` | `System.Runtime\LOH Size` (`loh-size`) | `System.Runtime\dotnet.gc.last_collection.heap.size` with attribute `gc.heap.generation=loh` |
| `.NET CLR Memory\Allocated Bytes/sec` | `System.Runtime\Allocation Rate` (`alloc-rate`) | Calculate rate from `System.Runtime\dotnet.gc.heap.total_allocated` |

> [!NOTE]
> dotnet.gc.pause.time allows an improved calculation that avoids some undesirable behavior in the older `% Time in GC` metric. `% Time in GC` computed
> 100 * `pause_time_in_most_recent_GC` / `time_between_most_recent_two_GCs`. In some cases two GCs would occur very close together producing a high value
> based on a tiny non-representative portion of the overall time interval. `gc.heap.pause.time` accumulates the total time the GC has paused application threads
> so far in a process which allows computing the GC pause time during any measured time interval. This is a truer measurement of GC overhead but the change in calculation
> means the metrics may not match even when the underlying GC behavior is unchanged.

### JIT and Loading counters

| Windows Performance Counter | EventCounter equivalent | Metrics API equivalent |
|----------------------------|--------------------------|------------------------|
| `.NET CLR Jit\# of Methods Jitted` | `System.Runtime\Methods Jitted Count` (`methods-jitted-count`) | `System.Runtime\dotnet.jit.compiled_methods` |
| `.NET CLR Jit\IL Bytes Jitted` | `System.Runtime\IL Bytes Jitted` (`il-bytes-jitted`) | `System.Runtime\dotnet.jit.compiled_il.size` |
| `.NET CLR Loading\Current Assemblies` | `System.Runtime\Number of Assemblies Loaded` (`assembly-count`) | `System.Runtime\dotnet.assembly.count` |
| `.NET CLR Jit\Total # of IL Bytes Jitted` | `System.Runtime\IL Bytes Jitted` (`il-bytes-jitted`) | `System.Runtime\dotnet.jit.compiled_il.size` |

### Threading counters

| Windows Performance Counter | EventCounter equivalent | Metrics API equivalent |
|----------------------------|--------------------------|------------------------|
| `.NET CLR LocksAndThreads\Current Queue Length` | `System.Runtime\ThreadPool Queue Length` (`threadpool-queue-length`) | `System.Runtime\dotnet.thread_pool.queue.length` |
| `.NET CLR LocksAndThreads\Contention Rate / sec` | `System.Runtime\Monitor Lock Contention Count` (`monitor-lock-contention-count`) | Calculate rate from `System.Runtime\dotnet.monitor.lock_contentions` |

### Exceptions counters

| Windows Performance Counter | EventCounter equivalent | Metrics API equivalent |
|----------------------------|--------------------------|------------------------|
| `.NET CLR Exceptions\# of Exceps Thrown / sec` | `System.Runtime\Exception Count` (`exception-count`) | Calculate rate from `System.Runtime\dotnet.exceptions` |
| `.NET CLR Exceptions\# of Exceps Thrown` | None | `System.Runtime\dotnet.exceptions` |

### Socket networking counters

| Windows Performance Counter | EventCounter equivalent | Metrics API equivalent |
|----------------------------|--------------------------|------------------------|
| `.NET CLR Networking\Bytes Received` | `System.Net.Sockets\Bytes Received` (`bytes-received`) | None |
| `.NET CLR Networking\Bytes Sent` | `System.Net.Sockets\Bytes Sent` (`bytes-sent`) | None |
| `.NET CLR Networking\Connections Established` | `System.Net.Sockets\Outgoing Connections Established` (`outgoing-connections-established`) | None |
| `.NET CLR Networking\Datagrams Received` | `System.Net.Sockets\Datagrams Received` (`datagrams-received`) | None |
| `.NET CLR Networking\Datagrams Sent` | `System.Net.Sockets\Datagrams Sent` (`datagrams-sent`) | None |

### DNS networking counters

| Windows Performance Counter | EventCounter equivalent | Metrics API equivalent |
|----------------------------|--------------------------|------------------------|
| `.NET CLR Networking\DNS Lookups` | `System.Net.NameResolution\DNS Lookups Requested` (`dns-lookups-requested`) | Sum the histogram buckets in `System.Net.NameResolution\dns.lookup.duration` |
| `.NET CLR Networking\DNS Resolution Time` | `System.Net.NameResolution\Average DNS Lookup Duration` (`dns-lookups-duration`) | `System.Net.NameResolution\dns.lookup.duration` |

### HttpWebRequest counters

HttpWebRequest has been superceded by HttpClient. See the HttpClient [EventCounters](./available-counters.md#systemnethttp-counters) and [System.Diagnostics.Metrics](./built-in-metrics-system-net.md#systemnethttp) to learn what metrics are built-in.

### ASP.NET counters

ASP.NET has changed dramatically between .NET Framework and .NET Core. Many counters are obsolete or are measured differently than in the past. See the ASP.NET [EventCounters](./available-counters.md#microsoftaspnetcorehosting-counters) and [System.Diagnostics.Metrics](/aspnet/core/log-mon/metrics/built-in) to learn what metrics are built-in.

## Next steps

- Learn more about [EventCounters in .NET](./event-counters.md)
- Explore the [System.Diagnostics.Metrics API](./metrics.md)
- Understand how to [collect metrics](./metrics-collection.md)
- Review [well-known EventCounters](./available-counters.md) and [built-in metrics](./built-in-metrics.md)
