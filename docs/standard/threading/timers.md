---
title: "Timers"
description: Learn what .NET timers to use in a multithreaded environment.
ms.date: "07/03/2018"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "threading [.NET], timers"
  - "timers, about timers"
author: "pkulikov"
ms.topic: article
---
# Timers

.NET provides three timers to use in a multithreaded environment:

- <xref:System.Threading.Timer?displayProperty=nameWithType>, which executes a single callback method on a <xref:System.Threading.ThreadPool> thread at regular intervals.
- <xref:System.Timers.Timer?displayProperty=nameWithType>, which by default raises an event on a <xref:System.Threading.ThreadPool> thread at regular intervals.
- <xref:System.Threading.PeriodicTimer?displayProperty=nameWithType>, which allows the caller to perform work after awaiting individual ticks of the timer.

> [!NOTE]
> Some .NET implementations may include additional timers:
>
> - <xref:System.Windows.Forms.Timer?displayProperty=nameWithType>: a Windows Forms component that fires an event at regular intervals. The component has no user interface and is designed for use in a single-threaded environment.
> - <xref:System.Web.UI.Timer?displayProperty=nameWithType>: an ASP.NET component that performs asynchronous or synchronous web page postbacks at a regular interval.
> - <xref:System.Windows.Threading.DispatcherTimer?displayProperty=nameWithType>: a timer that is integrated into the <xref:System.Windows.Threading.Dispatcher> queue which is processed at a specified interval of time and at a specified priority.

## The System.Threading.Timer class

The <xref:System.Threading.Timer?displayProperty=nameWithType> class enables you to continuously call a delegate at specified time intervals. You can also use this class to schedule a single call to a delegate in a specified time interval. The delegate is executed on a <xref:System.Threading.ThreadPool> thread.

When you create a <xref:System.Threading.Timer?displayProperty=nameWithType> object, you specify a <xref:System.Threading.TimerCallback> delegate that defines the callback method, an optional state object that is passed to the callback, the amount of time to delay before the first invocation of the callback, and the time interval between callback invocations. To cancel a pending timer, call the <xref:System.Threading.Timer.Dispose%2A?displayProperty=nameWithType> method.

The following example creates a timer that calls the provided delegate for the first time after one second (1000 milliseconds) and then calls it every two seconds. The state object in the example is used to count how many times the delegate is called. The timer is stopped when the delegate has been called at least 10 times.
[!code-csharp[System.Threading.Timer#2](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.Threading.Timer/CS/source2.cs#2)]
[!code-vb[System.Threading.Timer#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.Threading.Timer/VB/source2.vb#2)]

For more information and examples, see <xref:System.Threading.Timer?displayProperty=nameWithType>.

## The System.Timers.Timer class

Another timer that can be used in a multithreaded environment is <xref:System.Timers.Timer?displayProperty=nameWithType> that by default raises an event on a <xref:System.Threading.ThreadPool> thread.

When you create a <xref:System.Timers.Timer?displayProperty=nameWithType> object, you may specify the time interval in which to raise an <xref:System.Timers.Timer.Elapsed> event. Use the <xref:System.Timers.Timer.Enabled%2A> property to indicate if a timer should raise an <xref:System.Timers.Timer.Elapsed> event. If you need an <xref:System.Timers.Timer.Elapsed> event to be raised only once after the specified interval has elapsed, set the <xref:System.Timers.Timer.AutoReset%2A> to `false`. The default value of the <xref:System.Timers.Timer.AutoReset%2A> property is `true`, which means that an <xref:System.Timers.Timer.Elapsed> event is raised regularly at the interval defined by the <xref:System.Timers.Timer.Interval%2A> property.

For more information and examples, see <xref:System.Timers.Timer?displayProperty=nameWithType>.

## The System.Threading.PeriodicTimer class

The <xref:System.Threading.PeriodicTimer?displayProperty=nameWithType> class enables you to await individual ticks of a specified interval, performing work after calling <xref:System.Threading.PeriodicTimer.WaitForNextTickAsync%2A?displayProperty=nameWithType>.

When you create a <xref:System.Threading.PeriodicTimer?displayProperty=nameWithType> object, you specify a <xref:System.TimeSpan> that determines the length of time between each tick of the timer. Instead of passing a callback or setting an event handler as in the previous timer classes, you perform work directly in scope, awaiting <xref:System.Threading.PeriodicTimer.WaitForNextTickAsync%2A> to advance the timer by the specified interval.

The <xref:System.Threading.PeriodicTimer.WaitForNextTickAsync%2A> method returns a [`ValueTask<bool>`](xref:System.Threading.Tasks.ValueTask%601); `true` upon successful firing of the timer, and `false` when the timer has been canceled by calling <xref:System.Threading.PeriodicTimer.Dispose%2A?displayProperty=nameWithType>. <xref:System.Threading.PeriodicTimer.WaitForNextTickAsync%2A> optionally accepts a <xref:System.Threading.CancellationToken>, which results in a <xref:System.Threading.Tasks.TaskCanceledException> when a cancellation has been requested.

For more information, see <xref:System.Threading.PeriodicTimer?displayProperty=nameWithType>.

## See also

- <xref:System.Threading.Timer?displayProperty=nameWithType>
- <xref:System.Timers.Timer?displayProperty=nameWithType>
- <xref:System.Threading.PeriodicTimer?displayProperty=nameWithType>
- [Threading Objects and Features](threading-objects-and-features.md)
