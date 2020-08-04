---
title: Measure performance using EventCounters in .NET Core
description: In this tutorial, you'll learn how to measure performance using EventCounters.
ms.date: 08/04/2020
ms.topic: tutorial
---

# Tutorial: Measure performance using EventCounters in .NET Core

**This article applies to: ✔️** .NET Core 3.0 SDK and later versions

In this tutorial, you'll learn how an <xref:System.Diagnostics.Tracing.EventCounter> can be used to measure performance with a high frequency events. You can use the [available counters](event-counters.md#available-counters) published by various official .NET Core packages, third-party providers, or create your own metrics for monitoring.

In this tutorial, you will:

> [!div class="checklist"]
>
> - Implement an <xref:System.Diagnostics.Tracing.EventSource>.
> - Monitor counters with [dotnet-counters](dotnet-counters.md).

## Prerequisites

The tutorial uses:

- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core) or a later version.
- [dotnet-counters](dotnet-counters.md) to monitor event counters.

## Implement an EventSource

For events that happen every few milliseconds, you'll want the overhead per event to be low (less than a millisecond). Otherwise, the impact on performance will be significant. Logging an event means you're going to write something to disk. If the disk is not fast enough, you will lose events. You need a solution other than logging the event itself.

When dealing with a large number of events, knowing the measure per event is not useful either. Most of the time all you need is just some statistics out of it. So you could get the statistics within the process itself and then write an event once in a while to report the statistics, that's what <xref:System.Diagnostics.Tracing.EventCounter> will do. Below is an example of how to implement an <xref:System.Diagnostics.Tracing.EventSource?displayProperty=fullName>.

:::code language="csharp" source="snippets/EventCounters/MinimalEventCounterSource.cs":::

The <xref:System.Diagnostics.Tracing.EventSource.WriteEvent%2A?displayProperty=nameWithType> line is the <xref:System.Diagnostics.Tracing.EventSource> part and is not part of <xref:System.Diagnostics.Tracing.EventCounter>, it was written to show that you can log a message together with the event counter.

You logged the metric to the <xref:System.Diagnostics.Tracing.EventCounter>, but unless you access the statistics from of it, it is not useful. To get the statistics, you need to enable the <xref:System.Diagnostics.Tracing.EventCounter> by creating a timer that fires as frequently as you want the events, as well as a listener to capture the events. To do that, you can use [dotnet-counters](dotnet-counters.md).

Use the [dotnet-counters ps](dotnet-counters.md#dotnet-counters-ps) command, to display a list of .NET processes that can be monitored.

```console
dotnet-counters ps
```

Using the process identifier from the output of the `dotnet-counters ps` command, start monitoring the event counter interval.

```console
dotnet-counters monitor --process-id 20184 Sample.EventCounter.Minimal
```

> [!NOTE]
> The `EventCounterIntervalSec` segment is used to indicate the frequency of the sampling.

Turn on PerfView, and then run the sample code - we get have something like this.

:::image type="content" source="media/perfview-counters.png" lightbox="media/perfview-counters.png" alt-text="PerfView of EventCounter traces":::

Examine the captured data. When you copy from PerfView, it looks like this:

```
ThreadID="17,800" ProcessorNumber="5" Payload="{ Name:"request", Mean:142.0735, StandardDeviation:42.07355, Count:2, Min:100, Max:184.1471, IntervalSec:1.000588 }"
```

Within a sampling period, there are nine events and all the other statistics.

Notice that this command also logs the events, so we will get both the events and the counter statistics.

:::image type="content" source="media/perfview-events.png" lightbox="media/perfview-events.png" alt-text="PerfView of event traces":::

As we mentioned, to avoid overhead, sometimes we will want just the counters. This command can be used to log _only_ the counters:

```
PerfView /onlyProviders=*Samples.EventCounterDemos.Minimal:*:Critical:EventCounterIntervalSec=1 collect
```

> [!TIP]
> The `Critical` keyword is used to filter out the other events with lower priorities.

In the next release of PerfView (> 2.0.26), we can visualize the counters using PerfView. To do so, you can right-click on the event like this and choose the show event counter graph item:

:::image type="content" source="media/perfview-menu.png" lightbox="media/perfview-menu.png" alt-text="Show EventCounter graph menu item":::

Then it will show you a line graph showing the mean of the data like this. If you have multiple event counters, it can show multiple plots. You can also filter out a particular subset of counters using the filter text option:

:::image type="content" source="media/perfview-plot.png" lightbox="media/perfview-plot.png" alt-text="EventCounter graph":::

## Next steps

> [!div class="nextstepaction"]
> [Tutorial: Debug a memory leak](debug-memory-leak.md)
