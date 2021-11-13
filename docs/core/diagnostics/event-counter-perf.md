---
title: Measure performance using EventCounters in .NET Core
description: In this tutorial, you'll learn how to measure performance using EventCounters.
ms.date: 08/07/2020
ms.topic: tutorial
recommendations: false
---

# Tutorial: Measure performance using EventCounters in .NET Core

**This article applies to: ✔️** .NET Core 3.0 SDK and later versions

In this tutorial, you'll learn how an <xref:System.Diagnostics.Tracing.EventCounter> can be used to measure performance with a high frequency of events. You can use the [available counters](available-counters.md) published by various official .NET Core packages, third-party providers, or create your own metrics for monitoring.

In this tutorial, you will:

> [!div class="checklist"]
>
> - Implement an <xref:System.Diagnostics.Tracing.EventSource>.
> - Monitor counters with [dotnet-counters](dotnet-counters.md).

## Prerequisites

The tutorial uses:

- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet) or a later version.
- [dotnet-counters](dotnet-counters.md) to monitor event counters.
- A [sample debug target](/samples/dotnet/samples/diagnostic-scenarios) app to diagnose.

## Get the source

The sample application will be used as a basis for monitoring. The [sample ASP.NET Core repository](/samples/dotnet/samples/diagnostic-scenarios) is available from the samples browser. You download the zip file, extract it once downloaded, and open it in your favorite IDE. Build and run the application to ensure that it works properly, then stop the application.

## Implement an EventSource

For events that happen every few milliseconds, you'll want the overhead per event to be low (less than a millisecond). Otherwise, the impact on performance will be significant. Logging an event means you're going to write something to disk. If the disk is not fast enough, you will lose events. You need a solution other than logging the event itself.

When dealing with a large number of events, knowing the measure per event is not useful either. Most of the time all you need is just some statistics out of it. So you could get the statistics within the process itself and then write an event once in a while to report the statistics, that's what <xref:System.Diagnostics.Tracing.EventCounter> will do.

Below is an example of how to implement an <xref:System.Diagnostics.Tracing.EventSource?displayProperty=fullName>. Create a new file named *MinimalEventCounterSource.cs* and use the code snippet as its source:

:::code language="csharp" source="snippets/EventCounters/MinimalEventCounterSource.cs":::

The <xref:System.Diagnostics.Tracing.EventSource.WriteEvent%2A?displayProperty=nameWithType> line is the <xref:System.Diagnostics.Tracing.EventSource> part and is not part of <xref:System.Diagnostics.Tracing.EventCounter>, it was written to show that you can log a message together with the event counter.

## Add an action filter

The sample source code is an ASP.NET Core project. You can add an [action filter](/aspnet/core/mvc/controllers/filters#action-filters) globally that will log the total request time. Create a new file named *LogRequestTimeFilterAttribute.cs*, and use the following code:

```csharp
using System.Diagnostics;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DiagnosticScenarios
{
    public class LogRequestTimeFilterAttribute : ActionFilterAttribute
    {
        readonly Stopwatch _stopwatch = new Stopwatch();

        public override void OnActionExecuting(ActionExecutingContext context) => _stopwatch.Start();

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();

            MinimalEventCounterSource.Log.Request(
                context.HttpContext.Request.GetDisplayUrl(), _stopwatch.ElapsedMilliseconds);
        }
    }
}
```

The action filter starts a <xref:System.Diagnostics.Stopwatch> as the request begins, and stops after it has completed, capturing the elapsed time. The total milliseconds is logged to the `MinimalEventCounterSource` singleton instance. In order for this filter to be applied, you need to add it to the filters collection. In the *Startup.cs* file, update the `ConfigureServices` method in include this filter.

```csharp
public void ConfigureServices(IServiceCollection services) =>
    services.AddControllers(options => options.Filters.Add<LogRequestTimeFilterAttribute>())
            .AddNewtonsoftJson();
```

## Monitor event counter

With the implementation on an <xref:System.Diagnostics.Tracing.EventSource> and the custom action filter, build and launch the application.
You logged the metric to the <xref:System.Diagnostics.Tracing.EventCounter>, but unless you access the statistics from of it, it is not useful. To get the statistics, you need to enable the <xref:System.Diagnostics.Tracing.EventCounter> by creating a timer that fires as frequently as you want the events, as well as a listener to capture the events. To do that, you can use [dotnet-counters](dotnet-counters.md).

Use the [dotnet-counters ps](dotnet-counters.md#dotnet-counters-ps) command to display a list of .NET processes that can be monitored.

```console
dotnet-counters ps
```

Using the process identifier from the output of the `dotnet-counters ps` command, you can start monitoring the event counter with the following `dotnet-counters monitor` command:

```console
dotnet-counters monitor --process-id 2196 --counters Sample.EventCounter.Minimal,Microsoft.AspNetCore.Hosting[total-requests,requests-per-second],System.Runtime[cpu-usage]
```

While the `dotnet-counters monitor` command is running, hold <kbd>F5</kbd> on the browser to start issuing continuous requests to the `https://localhost:5001/api/values` endpoint. After a few seconds stop by pressing <kbd>q</kbd>

```console
Press p to pause, r to resume, q to quit.
    Status: Running

[Microsoft.AspNetCore.Hosting]
    Request Rate / 1 sec                               9
    Total Requests                                   134
[System.Runtime]
    CPU Usage (%)                                     13
[Sample.EventCounter.Minimal]
    Request Processing Time (ms)                      34.5
```

The `dotnet-counters monitor` command is great for active monitoring. However, you may want to collect these diagnostic metrics for post processing and analysis. For that, use the `dotnet-counters collect` command. The `collect` switch command is similar to the `monitor` command, but accepts a few additional parameters. You can specify the desired output file name and format. For a JSON file named *diagnostics.json* use the following command:

```console
dotnet-counters collect --process-id 2196 --format json -o diagnostics.json --counters Sample.EventCounter.Minimal,Microsoft.AspNetCore.Hosting[total-requests,requests-per-second],System.Runtime[cpu-usage]
```

Again, while the command is running, hold <kbd>F5</kbd> on the browser to start issuing continuous requests to the `https://localhost:5001/api/values` endpoint. After a few seconds stop by pressing <kbd>q</kbd>. The *diagnostics.json* file is written. The JSON file that is written is not indented, however; for readability it is indented here.

```json
{
  "TargetProcess": "DiagnosticScenarios",
  "StartTime": "8/5/2020 3:02:45 PM",
  "Events": [
    {
      "timestamp": "2020-08-05 15:02:47Z",
      "provider": "System.Runtime",
      "name": "CPU Usage (%)",
      "counterType": "Metric",
      "value": 0
    },
    {
      "timestamp": "2020-08-05 15:02:47Z",
      "provider": "Microsoft.AspNetCore.Hosting",
      "name": "Request Rate / 1 sec",
      "counterType": "Rate",
      "value": 0
    },
    {
      "timestamp": "2020-08-05 15:02:47Z",
      "provider": "Microsoft.AspNetCore.Hosting",
      "name": "Total Requests",
      "counterType": "Metric",
      "value": 134
    },
    {
      "timestamp": "2020-08-05 15:02:47Z",
      "provider": "Sample.EventCounter.Minimal",
      "name": "Request Processing Time (ms)",
      "counterType": "Metric",
      "value": 0
    },
    {
      "timestamp": "2020-08-05 15:02:47Z",
      "provider": "System.Runtime",
      "name": "CPU Usage (%)",
      "counterType": "Metric",
      "value": 0
    },
    {
      "timestamp": "2020-08-05 15:02:48Z",
      "provider": "Microsoft.AspNetCore.Hosting",
      "name": "Request Rate / 1 sec",
      "counterType": "Rate",
      "value": 0
    },
    {
      "timestamp": "2020-08-05 15:02:48Z",
      "provider": "Microsoft.AspNetCore.Hosting",
      "name": "Total Requests",
      "counterType": "Metric",
      "value": 134
    },
    {
      "timestamp": "2020-08-05 15:02:48Z",
      "provider": "Sample.EventCounter.Minimal",
      "name": "Request Processing Time (ms)",
      "counterType": "Metric",
      "value": 0
    },
    {
      "timestamp": "2020-08-05 15:02:48Z",
      "provider": "System.Runtime",
      "name": "CPU Usage (%)",
      "counterType": "Metric",
      "value": 0
    },
    {
      "timestamp": "2020-08-05 15:02:50Z",
      "provider": "Microsoft.AspNetCore.Hosting",
      "name": "Request Rate / 1 sec",
      "counterType": "Rate",
      "value": 0
    },
    {
      "timestamp": "2020-08-05 15:02:50Z",
      "provider": "Microsoft.AspNetCore.Hosting",
      "name": "Total Requests",
      "counterType": "Metric",
      "value": 134
    },
    {
      "timestamp": "2020-08-05 15:02:50Z",
      "provider": "Sample.EventCounter.Minimal",
      "name": "Request Processing Time (ms)",
      "counterType": "Metric",
      "value": 0
    }
  ]
}
```

## Next steps

> [!div class="nextstepaction"]
> [EventCounters](event-counters.md)
