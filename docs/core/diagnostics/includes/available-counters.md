## Available counters

Throughout various .NET packages, basic metrics on Garbage Collection (GC), Just-in-Time (JIT), assemblies, exceptions, threading, networking, and web requests are published using EventCounters.

### "System.Runtime" counters

The following counters are published as part of .NET runtime, and are maintained in the [`RuntimeEventSource.cs`](https://github.com/dotnet/coreclr/blob/master/src/System.Private.CoreLib/src/System/Diagnostics/Eventing/RuntimeEventSource.cs).

| Counter | Description |
|--|--|
| :::no-loc text="% Time in GC since last GC"::: (`time-in-gc`) | The percent of time in GC since the last GC |
| :::no-loc text="Allocation Rate"::: (`alloc-rate`) | The rate of allocation in bytes |
| :::no-loc text="CPU Usage"::: (`cpu-usage`) | The percent of CPU usage |
| :::no-loc text="Exception Count"::: (`exception-count`) | The number of exceptions that have occurred |
| :::no-loc text="GC Heap Size"::: (`gc-heap-size`) | The number of bytes thought to be allocated based on <xref:System.GC.GetTotalMemory(System.Boolean)?displayProperty=nameWithType> |
| :::no-loc text="Gen 0 GC Count"::: (`gen-0-gc-count`) | The number of times GC has occurred for Gen 0 |
| :::no-loc text="Gen 0 Size"::: (`gen-0-size`) | The number of bytes for Gen 0 GC |
| :::no-loc text="Gen 1 GC Count"::: (`gen-1-gc-count`) | The number of times GC has occurred for Gen 1 |
| :::no-loc text="Gen 1 Size"::: (`gen-1-size`) | The number of bytes for Gen 1 GC |
| :::no-loc text="Gen 2 GC Count"::: (`gen-2-gc-count`) | The number of times GC has occurred for Gen 2 |
| :::no-loc text="Gen 2 Size"::: (`gen-2-size`) | The number of bytes for Gen 2 GC |
| :::no-loc text="LOH Size"::: (`loh-size`) | The number of bytes for Gen 3 GC |
| :::no-loc text="Monitor Lock Contention Count"::: (`monitor-lock-contention-count`) | The number of times there was contention when trying to take the monitor's lock, based on <xref:System.Threading.Monitor.LockContentionCount?displayProperty=nameWithType> |
| :::no-loc text="Number of Active Timers"::: (`active-timer-count`) | The number of <xref:System.Threading.Timer> instances that are currently active, based on <xref:System.Threading.Timer.ActiveCount?displayProperty=nameWithType> |
| :::no-loc text="Number of Assemblies Loaded"::: (`assembly-count`) | The number of <xref:System.Reflection.Assembly> instances loaded into a process at a point in time |
| :::no-loc text="ThreadPool Completed Work Item Count"::: (`threadpool-completed-items-count`) | The number of work items that have been processed so far in the <xref:System.Threading.ThreadPool> |
| :::no-loc text="ThreadPool Queue Length"::: (`threadpool-queue-length`) | The number of work items that are currently queued to be processed in the <xref:System.Threading.ThreadPool> |
| :::no-loc text="ThreadPool Thread Count"::: (`threadpool-thread-count`) | The number of thread pool threads that currently exist in the <xref:System.Threading.ThreadPool>, based on <xref:System.Threading.ThreadPool.ThreadCount?displayProperty=nameWithType> |
| :::no-loc text="Working Set"::: (`working-set`) | The amount of physical memory mapped to the process context at a point in time base on <xref:System.Environment.WorkingSet?displayProperty=nameWithType> |

### "Microsoft.AspNetCore.Hosting" counters

The following counters are published as part of [ASP.NET Core](/aspnet/core) and are maintained in [`HostingEventSource.cs`](https://github.com/dotnet/aspnetcore/blob/master/src/Hosting/Hosting/src/Internal/HostingEventSource.cs).

| Counter | Description |
|--|--|
| :::no-loc text="Current Requests"::: (`current-requests`) | The total number of requests the have started, but not yet stopped |
| :::no-loc text="Failed Requests"::: (`failed-requests`) | The total number of failed requests that have occurred for the life of the app |
| :::no-loc text="Request Rate"::: (`requests-per-second`) | The number of requests that occur per second |
| :::no-loc text="Total Requests"::: (`total-requests`) | The total number of requests that have occurred for the life of the app |

### "Microsoft.AspNetCore.Http.Connections" counters

The following counters are published as part of [ASP.NET Core SignalR](/aspnet/core/signalr/introduction) and are maintained in [`HttpConnectionsEventSource.cs`](https://github.com/dotnet/aspnetcore/blob/master/src/SignalR/common/Http.Connections/src/Internal/HttpConnectionsEventSource.cs).

| Counter | Description |
|--|--|
| :::no-loc text="Average Connection Duration"::: (`connections-duration`) | The average duration of a connection in milliseconds |
| :::no-loc text="Current Connections"::: (`current-connections`) | The number of active connections that have started, but not yet stopped |
| :::no-loc text="Total Connections Started"::: (`connections-started`) | The total number of connections that have started |
| :::no-loc text="Total Connections Stopped"::: (`connections-stopped`) | The total number of connections that have stopped |
| :::no-loc text="Total Connections Timed Out"::: (`connections-timed-out`) | The total number of connections that have timed out |

### "Microsoft-AspNetCore-Server-Kestrel" counters

The following counters are published as part of the [ASP.NET Core Kestrel web server](/aspnet/core/fundamentals/servers/kestrel) and are maintained in [`KestrelEventSource.cs`](https://github.com/dotnet/aspnetcore/blob/master/src/Servers/Kestrel/Core/src/Internal/Infrastructure/KestrelEventSource.cs).

| Counter | Description |
|--|--|
| :::no-loc text="Connection Queue Length"::: (`connection-queue-length`) | The current length of the connection queue |
| :::no-loc text="Connection Rate"::: (`connections-per-second`) | The number of connections per second to the web server |
| :::no-loc text="Current Connections"::: (`current-connections`) | The current number of active connections to the web server |
| :::no-loc text="Current TLS Handshakes"::: (`current-tls-handshakes`) | The current number of TLS handshakes |
| :::no-loc text="Current Upgraded Requests (WebSockets)"::: (`current-upgraded-requests`) | The current number of upgraded requests (WebSockets) |
| :::no-loc text="Failed TLS Handshakes"::: (`failed-tls-handshakes`) | The total number of failed TLS handshakes |
| :::no-loc text="Request Queue Length"::: (`request-queue-length`) | The current length of the request queue |
| :::no-loc text="TLS Handshake Rate"::: (`tls-handshakes-per-second`) | The number of TLS handshakes per second |
| :::no-loc text="Total Connections"::: (`total-connections`) | The total number of connections to the web server |
| :::no-loc text="Total TLS Handshakes"::: (`total-tls-handshakes`) | The total number of TLS handshakes with the web server |
