---
title: Use schedulers
description: Learn how to use a scheduler to control when notifications are published with Reactive Extensions for .NET.
author: IEvangelist
ms.date: 11/05/2020
ms.author: dapine
ms.topic: how-to
---

# Use schedulers

A scheduler controls when a subscription starts and when notifications are published. It consists of three components. It is first a data structure. When you schedule for tasks to be completed, they are put into the scheduler for queueing based on priority or other criteria. It also offers an execution context which denotes where the task is executed (e.g., in the thread pool, current thread, or in another app domain). Lastly, it has a clock which provides a notion of time for itself (by accessing the `Now` property of a scheduler). Tasks being scheduled on a particular scheduler will adhere to the time denoted by that clock only.

Schedulers also introduce the notion of virtual time (denoted by the VirtualScheduler type), which does not correlate with real time that is used in our daily life. For example, a sequence that is specified to take 100 years to complete can be scheduled to complete in virtual time in a mere 5 minutes. This will be covered in the [Testing and Debugging Observable Sequences](hh242967\(v=vs.103\).md) topic.

## Scheduler types

The various `Scheduler` types provided by Rx all implement the `IScheduler` interface. Each of these can be created and returned by using static properties of the `Scheduler` type.

| Scheduler type | Singleton property | Description |
|--|--|--|
| `ImmediateScheduler` | `ImmediateScheduler.Immediate` | Start the specified action immediately. |
| `CurrentThreadScheduler` | `CurrentThreadScheduler.CurrentThread` | Schedule actions to be performed on the thread that makes the original call. |
| `DispatcherScheduler` | `DispatcherScheduler.Dispatcher` | Schedule actions on the current `Dispatcher`, which is beneficial to WPF, and UMP developers who use Rx. |
| `NewThreadScheduler` | `NewThreadScheduler.NewThread` | Schedules actions on a new thread, and is optimal for scheduling long running or blocking actions. |
| <sup>*</sup> `TaskPoolScheduler` | `TaskPoolScheduler.TaskPool` | Schedules actions on a specific task factory. |
| <sup>*</sup> `ThreadPoolScheduler` | `ThreadPoolScheduler.ThreadPool` | Schedules actions on the thread pool. |

<sup>*</sup> Both pool schedulers are optimized for short-running actions.

## Scheduler specificity

You may have already used schedulers in your Rx code without explicitly stating the type of schedulers to be used. This is because all Observable operators that deal with concurrency have multiple overloads. If you do not use the overload which takes a scheduler as an argument, Rx will pick a default scheduler by using the principle of least concurrency. This means that the scheduler which introduces the least amount of concurrency that satisfies the needs of the operator is chosen. For example, for operators returning an observable with a finite and small number of messages, Rx calls `Immediate`. For operators returning a potentially large or infinite number of messages, `CurrentThread` is called. For operators which use timers, `ThreadPool` is used.

Because Rx uses the least concurrency scheduler, you can pick a different scheduler if you want to introduce concurrency for performance purpose, or when you have a thread-affinity issue. An example of the former is that when you do not want to block a particular thread, in this case, you should use `ThreadPool`. An example of the latter is that when you want a timer to run on the UI, in this case, you should use `Dispatcher`. To specify a particular scheduler, you can use those operator overloads that take a scheduler, e.g., `Timer(TimeSpan.FromSeconds(10), Scheduler.DispatcherScheduler())`.

In the following example, the source observable sequence is producing values at a frantic pace. The default overload of the Timer operator would place OnNext messages on the ThreadPool.

```csharp
Observable.Timer(Timespan.FromSeconds(0.01))
    .Subscribe(…);
```

This will queue up on the observer quickly. We can improve this code by using the `ObserveOn` operator, which allows you to specify the context that you want to use to send pushed notifications (`OnNext`) to observers. By default, the `ObserveOn` operator ensures that `OnNext` will be called as many times as possible on the current thread. You can use its overloads and redirect the `OnNext` outputs to a different context. In addition, you can use the SubscribeOn operator to return a proxy observable that delegates actions to a specific scheduler. For example, for a UI-intensive application, you can delegate all background operations to be performed on a scheduler running in the background by using `SubscribeOn` and passing to it a `ThreadPoolScheduler`. To receive notifications being pushed out and access any UI element, you can pass an instance of the `DispatcherScheduler` to the `ObserveOn` operator.

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

You should also note that by using the ObserveOn operator, an action is scheduled for each message that comes through the original observable sequence. This potentially changes timing information as well as puts additional stress on the system. If you have a query that composes various observable sequences running on many different execution contexts, and you are doing filtering in the query, it is best to place ObserveOn later in the query. This is because a query will potentially filter out a lot of messages, and placing the ObserveOn operator earlier in the query would do extra work on messages that would be filtered out anyway. Calling the ObserveOn operator at the end of the query will create the least performance impact.

Another advantage of specifying a scheduler type explicitly is that you can introduce concurrency for performance purpose, as illustrated by the following code.

```csharp
seq.GroupBy(...)
        .Select(x=>x.ObserveOn(Scheduler.NewThread))
        .Select(x=>expensive(x))  // perform operations that are expensive on resources
```
