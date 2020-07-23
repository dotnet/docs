---
title: Measure performance using EventCounters in .NET Core
description: Installing and using the dotnet-trace command-line tool.
ms.date: 07/22/2020
---

# Tutorial: Measure performance using EventCounters in .NET Core

**This article applies to: ✔️** .NET Core 3.0 SDK and later versions

While an <xref:System.Diagnostics.Tracing.EventSource> is fast, logging too many events for frequent events is still a performance consideration. In this tutorial, you'll learn how an <xref:System.Diagnostics.Tracing.EventCounter> can be used to measure performance of a high frequency of events.

For events that happen every few milliseconds, you'll want the performance per event to be low (less than a millisecond). Otherwise, it is going to cost a significant performance overhead. Logging an event means you're going to write something to disk. If the disk is not fast enough, you will lose events. You need a solution other than logging the event itself.

When dealing with a large number of events, knowing the measure per event is not useful either. Most of the time all you need is just some statistics out of it. So you could crank the statistics within the process itself and then write an event once in a while to report the statistics, that's what <xref:System.Diagnostics.Tracing.EventCounter> will do. Let's take a look at an example how to do this in <xref:System.Diagnostics.Tracing.EventSource?displayProperty=fullName>.

```csharp
// Give your event sources a descriptive name using the EventSourceAttribute, otherwise the name of the class is used.
[EventSource(Name = "Samples-EventCounterDemos-Minimal")]
public sealed class MinimalEventCounterSource : EventSource
{
    // Define the singleton instance of the event source
    public static MinimalEventCounterSource Log = new MinimalEventCounterSource();
    private EventCounter RequestCounter;

    private MinimalEventCounterSource() : base(EventSourceSettings.EtwSelfDescribingEventFormat)
    {
        RequestCounter = new EventCounter("request", this);
    }

    // Indicate that a request for a URL was made which took a particular amount of time
    public void Request(string url, float elapsedMSec)
    {
        // Notes:
        //   1. the event ID passed to WriteEvent (1) corresponds to the (implied) event ID
        //      assigned to this method. The event ID could have been explicitly declared
        //      using an EventAttribute for this method
        //   2. Each counter supports a single float value, so conceptually it maps to a single
        //      measurement in the code.
        //   3. You don't have to have log with WriteEvent if you don't think you will ever care about details
        //       of individual requests (that counter data is sufficient).

        // This logs it to the event stream if events are on.
        WriteEvent(1, url, elapsedMSec);
        // This adds it to the PerfCounter called 'Request' if PerfCounters are on
        RequestCounter.WriteMetric(elapsedMSec);
    }
}
```

The <xref:System.Diagnostics.Tracing.EventSource.WriteEvent%2A?displayProperty=nameWithType> line is the <xref:System.Diagnostics.Tracing.EventSource> part and is not part of <xref:System.Diagnostics.Tracing.EventCounter>, it was written to show that you can log a message together with the event counter.

You logged the metric to the <xref:System.Diagnostics.Tracing.EventCounter>, but unless you can actually get the statistics out of it, it is not useful. To get the statistics, you need to enable the <xref:System.Diagnostics.Tracing.EventCounter> by setting off a timer how frequently you want the events, as well as a listener to capture the events, to do that, you can use PerfView.

There is an extra keyword that you will need to specify the turn on the EventCounters.

```
PerfView /onlyProviders=*Samples-EventCounterDemos-Minimal:EventCounterIntervalSec=1 collect
```

> [!IMPORTANT]
> The `EventCounterIntervalSec` segment is used to indicate the frequency of the sampling.

As usual, turn on PerfView, and then run the sample code - we get have something like this.

:::image type="content" source="media/perfview-counters.png" lightbox="media/perfview-counters.png" alt-text="PerfView of EventCounter traces":::

Now let's drill into what the data captured means - when I copied from PerfView, it looks like this

```
ThreadID="17,800" ProcessorNumber="5" Payload="{ Name:"request", Mean:142.0735, StandardDeviation:42.07355, Count:2, Min:100, Max:184.1471, IntervalSec:1.000588 }"
```

Now it is obvious that within a sampling period, we have nine events, and all the other statistics.

Notice that this command also logs the events, so we will get both the events and the counter statistics.

:::image type="content" source="media/perfview-events.png" lightbox="media/perfview-events.png" alt-text="PerfView of event traces":::

As we mentioned, to avoid overhead, sometimes we will want just the counters. This command can be used to log _only_ the counters:

```
PerfView /onlyProviders=*Samples-EventCounterDemos-Minimal:*:Critical:EventCounterIntervalSec=1 collect
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
