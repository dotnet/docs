---
title: Well-known EventCounters in .NET
description: Review EventCounters published by the .NET runtime and libraries.
ms.topic: reference
ms.date: 12/17/2020
---

# Well-known EventCounters in .NET

The .NET runtime and libraries implement and publish several [EventCounters](./event-counters.md) that can be used to identify and diagnose various performance issues. This article is a reference on the providers that can be used to monitor these counters and their descriptions.

## System.Runtime counters

The following counters are published as part of .NET runtime (CoreCLR) and are maintained in the [`RuntimeEventSource.cs`](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Diagnostics/Tracing/RuntimeEventSource.cs).

| Counter | Description | First available in |
|--|--|--|
| :::no-loc text="% Time in GC since last GC"::: (`time-in-gc`) | The percent of time in GC since the last GC | .NET Core 3.1 |
| :::no-loc text="Allocation Rate"::: (`alloc-rate`) | The number of bytes allocated per update interval | .NET Core 3.1 |
| :::no-loc text="CPU Usage"::: (`cpu-usage`) | The percent of the process's CPU usage relative to all of the system CPU resources | .NET Core 3.1 |
| :::no-loc text="Exception Count"::: (`exception-count`) | The number of exceptions that have occurred | .NET Core 3.1 |
| :::no-loc text="GC Heap Size"::: (`gc-heap-size`) | The number of bytes thought to be allocated based on <xref:System.GC.GetTotalMemory(System.Boolean)?displayProperty=nameWithType> | .NET Core 3.1 |
| :::no-loc text="Gen 0 GC Count"::: (`gen-0-gc-count`) | The number of times GC has occurred for Gen 0 per update interval | .NET Core 3.1 |
| :::no-loc text="Gen 0 Size"::: (`gen-0-size`) | The number of bytes for Gen 0 GC | .NET Core 3.1 |
| :::no-loc text="Gen 1 GC Count"::: (`gen-1-gc-count`) | The number of times GC has occurred for Gen 1 per update interval | .NET Core 3.1 |
| :::no-loc text="Gen 1 Size"::: (`gen-1-size`) | The number of bytes for Gen 1 GC | .NET Core 3.1 |
| :::no-loc text="Gen 2 GC Count"::: (`gen-2-gc-count`) | The number of times GC has occurred for Gen 2 per update interval | .NET Core 3.1 |
| :::no-loc text="Gen 2 Size"::: (`gen-2-size`) | The number of bytes for Gen 2 GC | .NET Core 3.1 |
| :::no-loc text="LOH Size"::: (`loh-size`) | The number of bytes for the large object heap | .NET Core 3.1 |
| :::no-loc text="POH Size"::: (`poh-size`) | The number of bytes for the pinned object heap (available on .NET 5 and later versions) | .NET Core 3.1 |
| :::no-loc text="GC Fragmentation"::: (`gc-fragmentation`) | The GC Heap Fragmentation (available on .NET 5 and later versions) | .NET Core 3.1 |
| :::no-loc text="Monitor Lock Contention Count"::: (`monitor-lock-contention-count`) | The number of times there was contention when trying to take the monitor's lock, based on <xref:System.Threading.Monitor.LockContentionCount?displayProperty=nameWithType> | .NET Core 3.1 |
| :::no-loc text="Number of Active Timers"::: (`active-timer-count`) | The number of <xref:System.Threading.Timer> instances that are currently active, based on <xref:System.Threading.Timer.ActiveCount?displayProperty=nameWithType> | .NET Core 3.1 |
| :::no-loc text="Number of Assemblies Loaded"::: (`assembly-count`) | The number of <xref:System.Reflection.Assembly> instances loaded into a process at a point in time | .NET Core 3.1 |
| :::no-loc text="ThreadPool Completed Work Item Count"::: (`threadpool-completed-items-count`) | The number of work items that have been processed so far in the <xref:System.Threading.ThreadPool> | .NET Core 3.1 |
| :::no-loc text="ThreadPool Queue Length"::: (`threadpool-queue-length`) | The number of work items that are currently queued to be processed in the <xref:System.Threading.ThreadPool> | .NET Core 3.1 |
| :::no-loc text="ThreadPool Thread Count"::: (`threadpool-thread-count`) | The number of thread pool threads that currently exist in the <xref:System.Threading.ThreadPool>, based on <xref:System.Threading.ThreadPool.ThreadCount?displayProperty=nameWithType> | .NET Core 3.1 |
| :::no-loc text="Working Set"::: (`working-set`) | The amount of physical memory mapped to the process context at a point in time base on <xref:System.Environment.WorkingSet?displayProperty=nameWithType> | .NET Core 3.1 |
| :::no-loc text="IL Bytes Jitted"::: (`il-bytes-jitted`) | The total size of ILs that are JIT-compiled, in bytes | .NET 5 |
| :::no-loc text="Method Jitted Count"::: (`method-jitted-count`) | The number of methods that are JIT-compiled | .NET 5 |
| :::no-loc text="GC Committed Bytes"::: (`gc-committed-bytes`) | The number of bytes committed by the GC | .NET 6 |

## Microsoft.AspNetCore.Hosting counters

The following counters are published as part of [ASP.NET Core](/aspnet/core) and are maintained in [`HostingEventSource.cs`](https://github.com/dotnet/aspnetcore/blob/main/src/Hosting/Hosting/src/Internal/HostingEventSource.cs).

| Counter | Description | First available in |
|--|--|--|
| :::no-loc text="Current Requests"::: (`current-requests`) | The total number of requests that have started, but not yet stopped | .NET Core 3.1 |
| :::no-loc text="Failed Requests"::: (`failed-requests`) | The total number of failed requests that have occurred for the life of the app | .NET Core 3.1 |
| :::no-loc text="Request Rate"::: (`requests-per-second`) | The number of requests that occur per update interval | .NET Core 3.1 |
| :::no-loc text="Total Requests"::: (`total-requests`) | The total number of requests that have occurred for the life of the app | .NET Core 3.1 |

## Microsoft.AspNetCore.Http.Connections counters

The following counters are published as part of [ASP.NET Core SignalR](/aspnet/core/signalr/introduction) and are maintained in [`HttpConnectionsEventSource.cs`](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/common/Http.Connections/src/Internal/HttpConnectionsEventSource.cs).

| Counter | Description | First available in |
|--|--|--|
| :::no-loc text="Average Connection Duration"::: (`connections-duration`) | The average duration of a connection in milliseconds | .NET Core 3.1 |
| :::no-loc text="Current Connections"::: (`current-connections`) | The number of active connections that have started, but not yet stopped | .NET Core 3.1 |
| :::no-loc text="Total Connections Started"::: (`connections-started`) | The total number of connections that have started | .NET Core 3.1 |
| :::no-loc text="Total Connections Stopped"::: (`connections-stopped`) | The total number of connections that have stopped | .NET Core 3.1 |
| :::no-loc text="Total Connections Timed Out"::: (`connections-timed-out`) | The total number of connections that have timed out | .NET Core 3.1 |

## Microsoft-AspNetCore-Server-Kestrel counters

The following counters are published as part of the [ASP.NET Core Kestrel web server](/aspnet/core/fundamentals/servers/kestrel) and are maintained in [`KestrelEventSource.cs`](https://github.com/dotnet/aspnetcore/blob/main/src/Servers/Kestrel/Core/src/Internal/Infrastructure/KestrelEventSource.cs).

| Counter | Description | First available in |
|--|--|--|
| :::no-loc text="Connection Queue Length"::: (`connection-queue-length`) | The current length of the connection queue | .NET 5 |
| :::no-loc text="Connection Rate"::: (`connections-per-second`) | The number of connections per update interval to the web server | .NET 5 |
| :::no-loc text="Current Connections"::: (`current-connections`) | The current number of active connections to the web server | .NET 5 |
| :::no-loc text="Current TLS Handshakes"::: (`current-tls-handshakes`) | The current number of TLS handshakes | .NET 5 |
| :::no-loc text="Current Upgraded Requests (WebSockets)"::: (`current-upgraded-requests`) | The current number of upgraded requests (WebSockets) | .NET 5 |
| :::no-loc text="Failed TLS Handshakes"::: (`failed-tls-handshakes`) | The total number of failed TLS handshakes | .NET 5 |
| :::no-loc text="Request Queue Length"::: (`request-queue-length`) | The current length of the request queue | .NET 5 |
| :::no-loc text="TLS Handshake Rate"::: (`tls-handshakes-per-second`) | The number of TLS handshakes per update interval | .NET 5 |
| :::no-loc text="Total Connections"::: (`total-connections`) | The total number of connections to the web server | .NET 5 |
| :::no-loc text="Total TLS Handshakes"::: (`total-tls-handshakes`) | The total number of TLS handshakes with the web server | .NET 5 |

## System.Net.Http counters

The following counters are published by the HTTP stack.

| Counter | Description | First available in |
|--|--|--|
| :::no-loc text="Requests Started"::: (`requests-started`) | The number of requests started since the process started | .NET 5 |
| :::no-loc text="Requests Started Rate"::: (`requests-started-rate`) | The number of requests started per update interval | .NET 5 |
| :::no-loc text="Requests Failed"::: (`requests-failed`) | The number of failed requests since the process started | .NET 5 |
| :::no-loc text="Requests Failed Rate"::: (`requests-failed-rate`) | The number of failed requests per update interval | .NET 5 |
| :::no-loc text="Current Requests"::: (`current-requests`) | Current number of active HTTP requests that have started but not yet completed or failed | .NET 5 |
| :::no-loc text="Current HTTP 1.1 Connections"::: (`http11-connections-current-total`) | The current number of HTTP 1.1 connections that have started but not yet completed or failed | .NET 5 |
| :::no-loc text="Current HTTP 2.0 Connections"::: (`http20-connections-current-total`) | The current number of HTTP 2.0 connections that have started but not yet completed or failed | .NET 5 |
| :::no-loc text="HTTP 1.1 Requests Queue Duration"::: (`http11-requests-queue-duration`) | The average duration of the time HTTP 1.1 requests spent in the request queue | .NET 5 |
| :::no-loc text="HTTP 2.0 Requests Queue Duration"::: (`http20-requests-queue-duration`) | The average duration of the time HTTP 2.0 requests spent in the request queue | .NET 5 |

## System.Net.NameResolution counters

The following counters track metrics related to DNS lookups.

| Counter | Description | First available in |
|--|--|--|
| :::no-loc text="DNS Lookups Requested"::: (`dns-lookups-requested`) | The number of DNS lookups requested since the process started | .NET 5 |
| :::no-loc text="Average DNS Lookup Duration"::: (`dns-lookups-duration`) | The average time taken for a DNS lookup | .NET 5 |

## System.Net.Security counters

The following counters track metrics related to the Transport Layer Security protocol.

| Counter | Description | First available in |
|--|--|--|
| :::no-loc text="TLS handshakes completed"::: (`tls-handshake-rate`) | The number of TLS handshakes completed per update interval | .NET 5 |
| :::no-loc text="Total TLS handshakes completed"::: (`total-tls-handshakes`) | The total number of TLS handshakes completed since the process started | .NET 5 |
| :::no-loc text="Current TLS handshakes"::: (`current-tls-handshakes`) | The current number of TLS handshakes that have started but not yet completed | .NET 5 |
| :::no-loc text="Total TLS handshakes failed"::: (`failed-tls-handshakes`) | The total number of failed TLS handshakes since the process started | .NET 5 |
| :::no-loc text="All TLS Sessions Active"::: (`all-tls-sessions-open`) | The number of active TLS sessions of any version | .NET 5 |
| :::no-loc text="TLS 1.0 Sessions Active"::: (`tls10-sessions-open`) | The number of active TLS 1.0 sessions | .NET 5 |
| :::no-loc text="TLS 1.1 Sessions Active"::: (`tls11-sessions-open`) | The number of active TLS 1.1 sessions | .NET 5 |
| :::no-loc text="TLS 1.2 Sessions Active"::: (`tls12-sessions-open`) | The number of active TLS 1.2 sessions | .NET 5 |
| :::no-loc text="TLS 1.3 Sessions Active"::: (`tls13-sessions-open`) | The number of active TLS 1.3 sessions | .NET 5 |
| :::no-loc text="TLS Handshake Duration"::: (`all-tls-handshake-duration`) | The average duration of all TLS handshakes | .NET 5 |
| :::no-loc text="TLS 1.0 Handshake Duration"::: (`tls10-handshake-duration`) | The average duration of TLS 1.0 handshakes | .NET 5 |
| :::no-loc text="TLS 1.1 Handshake Duration"::: (`tls11-handshake-duration`) | The average duration of TLS 1.1 handshakes | .NET 5 |
| :::no-loc text="TLS 1.2 Handshake Duration"::: (`tls12-handshake-duration`) | The average duration of TLS 1.2 handshakes | .NET 5 |
| :::no-loc text="TLS 1.3 Handshake Duration"::: (`tls13-handshake-duration`) | The average duration of TLS 1.3 handshakes | .NET 5 |

## System.Net.Sockets counters

The following counters track metrics related to <xref:System.Net.Sockets.Socket>.

| Counter | Description | First available in |
|--|--|--|
| :::no-loc text="Outgoing Connections Established"::: (`outgoing-connections-established`) | The total number of outgoing connections established since the process started | .NET 5 |
| :::no-loc text="Incoming Connections Established"::: (`incoming-connections-established`) | The total number of incoming connections established since the process started | .NET 5 |
| :::no-loc text="Bytes Received"::: (`bytes-received`) | The total number of bytes received since the process started | .NET 5 |
| :::no-loc text="Bytes Sent"::: (`bytes-sent`) | The total number of bytes sent since the process started | .NET 5 |
| :::no-loc text="Datagrams Received"::: (`datagrams-received`) | The total number of datagrams received since the process started | .NET 5 |
| :::no-loc text="Datagrams Sent"::: (`datagrams-sent`) | The total number of datagrams sent since the process started | .NET 5 |
