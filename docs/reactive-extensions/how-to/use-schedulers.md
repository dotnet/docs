---
title: Use schedulers with observables
description: Learn how to use a scheduler to control when notifications are published with Reactive Extensions for .NET.
author: IEvangelist
ms.date: 11/05/2020
ms.author: dapine
ms.topic: how-to
---

# Use schedulers with observables

A scheduler controls when a subscription starts and when notifications are published. It consists of three components. It is first a data structure. When you schedule for tasks to be completed, they are put into the scheduler for queueing based on priority or other criteria. It also offers an execution context which denotes where the task is executed, for example: in the thread pool, current thread, or in another app domain. Lastly, it has a clock which provides a notion of time for itself. Units of work being scheduled on a particular scheduler will adhere to the time denoted by that clock only.

Schedulers also introduce the notion of virtual time (denoted by the `VirtualTimeScheduler<TAbsolute, TRelative>` type), which does not correlate with real time that is used in our daily life. For example, a sequence that is specified to take 100 years to complete can be scheduled to complete in virtual time in a mere 5 minutes. For more information, see [Test and debug Observable sequences](../tutorials/testing-observable-sequences.md)

## Scheduler types

The various `Scheduler` types all implement the `IScheduler` interface. Several of these are available as static properties of the `Scheduler` type.

| Scheduler type | Singleton property | Description |
|--|--|--|
| `CurrentThreadScheduler` | `Scheduler.CurrentThread` | Schedules units of work on the current thread. |
| `DefaultScheduler` | `Scheduler.Default` | Schedules units of work on the platform's default scheduler. |
| `ImmediateScheduler` | `Scheduler.Immediate` | Schedules units of work to run immediately on the current thread. |

Additional `IScheduler` implementations exist, but are not part of the `Scheduler` type.

| Scheduler type | Description |
|--|--|
| `EventLoopScheduler` | Schedules units of work on a designated thread. |
| `HistoricalScheduler` | Schedules units of work on the platform's default scheduler. |
| `NewThreadScheduler` | Schedules units of work to run immediately on the current thread. |
| `SynchronizationContextScheduler` | Schedules units of work on a provided <xref:System.Threading.SynchronizationContext>. |

## Scheduler specificity

You may have already used schedulers in your Rx code without explicitly stating the type of schedulers to be used. This is because all `Observable` operators that deal with concurrency have multiple overloads. If you do not use the overload which takes a scheduler as an argument, Rx will pick a default scheduler by using the principle of least concurrency. This means that the scheduler which introduces the least amount of concurrency that satisfies the needs of the operator is chosen. For example, for operators returning an observable with a finite and small number of messages, Rx calls `Immediate`. For operators returning a potentially large or infinite number of messages, `CurrentThread` is called. For operators which use timers, `ThreadPool` is used.

Because Rx uses the least concurrency scheduler, you can pick a different scheduler if you want to introduce concurrency for performance purpose, or when you have a thread-affinity issue. An example of the former is that when you do not want to block a particular thread, in this case, you should use `ThreadPool`. An example of the latter is that when you want a timer to run on the UI, in this case, you should use `Dispatcher`. To specify a particular scheduler, you can use those operator overloads that take a scheduler, for example, `Timer(TimeSpan.FromSeconds(10), Scheduler.Immediate)`.

In the following example, the source observable sequence is producing values at a frantic pace. The default overload of the `Timer` operator would place `OnNext` messages on the `ThreadPool`.

```csharp
Observable.Timer(Timespan.FromSeconds(0.01))
    .Subscribe(value => Console.WriteLine($"OnNext {value}"));
```

This will queue up on the observer quickly. You improve this code by using the `ObserveOn` operator, which allows you to specify the context that you want to use to send pushed notifications (`OnNext`) to observers. By default, the `ObserveOn` operator ensures that `OnNext` will be called as many times as possible on the current thread. You can use its overloads and redirect the `OnNext` outputs to a different context. In addition, you can use the `SubscribeOn` operator to return a proxy observable that delegates actions to a specific scheduler. For example, for a UI-intensive application, you can delegate all background operations to be performed on a scheduler running in the background by using `SubscribeOn` and passing to it a `ThreadPoolScheduler`. To receive notifications being pushed out and access any UI element, you can pass an instance of the `DispatcherScheduler` to the `ObserveOn` operator.

The following example will schedule any `OnNext` notifications on the current `Dispatcher`, so that any value pushed out is sent on the UI thread. This is especially beneficial to Silverlight developers who use Rx.

```csharp
Observable.Timer(Timespan.FromSeconds(0.01))
    .ObserveOn(Scheduler.DispatcherScheduler)
    .Subscribe(…);
```

Instead of using the `ObserveOn` operator to change the execution context on which the observable sequence produces messages, we can create concurrency in the right place to begin with. As operators parameterize introduction of concurrency by providing a scheduler argument overload, passing the right scheduler will lead to fewer places where the `ObserveOn` operator has to be used. For example, we can unblock the observer and subscribe to the UI thread directly by changing the scheduler used by the source, as in the following example. In this code, by using the Timer overload which takes a scheduler, and providing the `Scheduler.Dispatcher` instance, all values pushed out from this observable sequence will originate on the UI thread.

```csharp
Observable.Timer(Timespan.FromSeconds(0.01), Scheduler.DispatcherScheduler)
    .Subscribe(…);
```

You should also note that by using the `ObserveOn` operator, an action is scheduled for each message that comes through the original observable sequence. This potentially changes timing information as well as puts additional stress on the system. If you have a query that composes various observable sequences running on many different execution contexts, and you are doing filtering in the query, it is best to place `ObserveOn` later in the query. This is because a query will potentially filter out a lot of messages, and placing the `ObserveOn` operator earlier in the query would do extra work on messages that would be filtered out anyway. Calling the `ObserveOn` operator at the end of the query will create the least performance impact.

Another advantage of specifying a scheduler type explicitly is that you can introduce concurrency for performance purpose, as illustrated by the following code.

```csharp
seq.GroupBy(...)
        .Select(x=>x.ObserveOn(Scheduler.NewThread))
        .Select(x=>expensive(x))  // perform operations that are expensive on resources
```

## See also

- [Query event-based observable sequences in .NET](query-event-sequences.md)
- [Query observable sequences using LINQ operators](query-sequences-linq.md)
- [Query asynchronous observable sequences](query-async-sources.md)
