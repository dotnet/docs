---
title: "IncrementingPollingCounter initial callback is asynchronous"
description: Learn about the .NET 9 breaking change in core .NET libraries where the IncrementingPollingCounter initial callback is no longer synchronous.
ms.date: 09/05/2024
---
# IncrementingPollingCounter initial callback is asynchronous

<xref:System.Diagnostics.Tracing.IncrementingPollingCounter> uses a callback to retrieve current values of a metric and reports it via <xref:System.Diagnostics.Tracing.EventSource> events. In the past, the first invocation of the callback might have occurred synchronously on whatever thread was enabling the `EventSource`; future invocations occurred on a dedicated timer thread. Starting in .NET 9, the first callback always occurs asynchronously on the timer thread. This might result in counter changes that occurred just after the counter was enabled going unobserved because the first callback happens later.

This change is most likely to impact tests that use <xref:System.Diagnostics.Tracing.EventListener> to validate an `IncrementingPollingCounter`. If tests enable the counter and then immediately modify the state that's being polled by the counter, that modification might now occur prior to the first time the callback is invoked (and go unnoticed).

## Previous behavior

Previously, when an `IncrementingPollingCounter` was enabled, the first invocation of the callback might have occurred synchronously on the thread that performed the enable operation.

This sample app calls the delegate `() => SomeInterestingValue` on the `Main` thread within the call to `EnableEvents()`. That callback will observe `log.SomeInterestingValue` is 0. A later call from a dedicated timer thread will observe `log.SomeInterestingValue` changed to 1, and an event will be sent with `Increment value = 1`.

```csharp
using System.Diagnostics.Tracing;

var log = MyEventSource.Log;
using var listener = new Listener();

log.SomeInterestingValue++;

Console.ReadKey();

class MyEventSource : EventSource
{
    public static MyEventSource Log { get; } = new();
    private IncrementingPollingCounter? _counter;
    public int SomeInterestingValue;

    private MyEventSource() : base(nameof(MyEventSource))
    {
        _counter = new IncrementingPollingCounter("counter", this, () => SomeInterestingValue);
    }
}

class Listener : EventListener
{
    protected override void OnEventSourceCreated(EventSource eventSource)
    {
        if (eventSource.Name == nameof(MyEventSource))
        {
            EnableEvents(eventSource, EventLevel.Informational, EventKeywords.None,
                new Dictionary<string, string?> { { "EventCounterIntervalSec", "1.0" } });
        }
    }

    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        if (eventData.EventSource.Name == "EventCounters")
        {
            var counters = (IDictionary<string, object>)eventData.Payload![0]!;
            Console.WriteLine($"Increment: {counters["Increment"]}");
        }
    }
}
```

## New behavior

Using the same code snippet as the [Previous behavior](#previous-behavior) section, the first invocation of the callback occurs asynchronously on the timer thread. It might or might not occur prior to the `Main` thread running `log.SomeInterestingValue++` depending on how the OS schedules multiple threads.

Depending on that timing, the app either outputs "Increment=0" or "Increment=1".

## Version introduced

.NET 9 RC 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The change was made to resolve a potential deadlock that can occur running callback functions while the `EventListener` lock is held.

## Recommended action

No action is required for scenarios that use `IncrementingPollingCounters` to visualize metrics in external monitoring tools. These scenarios should continue to work normally.

For scenarios that do in-process testing or other consumption of counter data via `EventListener`, check if your code expects to observe a specific modification to the counter value made on the same thread that called `EnableEvents()`. If it does, we recommend waiting to observe at least one counter event from the `EventListener`, then modifying the counter value. For example, to ensure that the [example code snippet](#previous-behavior) prints "Increment=1", you could add a `ManualResetEvent` to the `EventListener`, signal it when the first counter event is received, and wait for it prior to calling `log.SomeInterestingValue++`.

## Affected APIs

- <xref:System.Diagnostics.Tracing.IncrementingPollingCounter?displayProperty=fullName>
