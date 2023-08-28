---
title: Timers and reminders
description: Learn how to use timers and reminders in .NET Orleans.
ms.date: 08/28/2023
---

# Timers and reminders

The Orleans runtime provides two mechanisms, called timers and reminders, that enable the developer to specify periodic behavior for grains.

## Timers

**Timers** are used to create periodic grain behavior that isn't required to span multiple activations (instantiations of the grain). A timer is identical to the standard .NET <xref:System.Threading.Timer?displayProperty=fullName> class. In addition, timers are subject to single-threaded execution guarantees within the grain activation that it operates on, and their executions are interleaved with other requests, as though the timer callback was a grain method marked with <xref:Orleans.Concurrency.AlwaysInterleaveAttribute>.

Each activation may have zero or more timers associated with it. The runtime executes each timer routine within the runtime context of the activation that it's associated with.

## Timer usage

To start a timer, use the <xref:Orleans.Grain.RegisterTimer%2A?displayProperty=nameWithType> method, which returns an <xref:System.IDisposable> reference:

```csharp
public IDisposable RegisterTimer(
    Func<object, Task> asyncCallback, // function invoked when the timer ticks
    object state,                     // object to pass to asyncCallback
    TimeSpan dueTime,                 // time to wait before the first timer tick
    TimeSpan period)                  // the period of the timer
```

To cancel the timer, you dispose of it.

A timer ceases to trigger if the grain is deactivated or when a fault occurs and its silo crashes.

***Important considerations:***

* When activation collection is enabled, the execution of a timer callback doesn't change the activation's state from idle to in-use. This means that a timer can't be used to postpone the deactivation of otherwise idle activations.
* The period passed to `Grain.RegisterTimer` is the amount of time that passes from the moment the Task returned by `asyncCallback` is resolved to the moment that the next invocation of `asyncCallback` should occur. This not only makes it impossible for successive calls to `asyncCallback` to overlap, but also makes it so that the length of time `asyncCallback` takes to complete affects the frequency at which `asyncCallback` is invoked. This is an important deviation from the semantics of <xref:System.Threading.Timer?displayProperty=fullName>.
* Each invocation of `asyncCallback` is delivered to an activation on a separate turn, and never runs concurrently with other turns on the same activation. However, `asyncCallback` invocations aren't delivered as messages and thus aren't subject to message interleaving semantics. This means that invocations of `asyncCallback` behave as if the grain is re-entrant and executes concurrently with other grain requests. In order to use the grain's request scheduling semantics, you can call a grain method to perform the work you would have done within `asyncCallback`. Another alternative is to use an `AsyncLock` or a <xref:System.Threading.SemaphoreSlim>. A more detailed explanation is available in [Orleans GitHub issue #2574](https://github.com/dotnet/orleans/issues/2574).

## Reminders

Reminders are similar to timers, with a few important differences:

* Reminders are persistent and continue to trigger in almost all situations (including partial or full cluster restarts) unless explicitly canceled.
* Reminder "definitions" are written to storage. However, each specific occurrence, with its specific time, isn't. This has the side effect that if the cluster is down at the time of a specific reminder tick, it will be missed and only the next tick of the reminder happens.
* Reminders are associated with a grain, not any specific activation.
* If a grain has no activation associated with it when a reminder ticks, the grain is created. If an activation becomes idle and is deactivated, a reminder associated with the same grain reactivates the grain when it ticks next.
* Reminder delivery occurs via message and is subject to the same interleaving semantics as all other grain methods.
* Reminders shouldn't be used for high-frequency timers- their period should be measured in minutes, hours, or days.

## Configuration

Reminders, being persistent, rely upon storage to function.
You must specify which storage backing to use before the reminder subsystem functions.
This is done by configuring one of the reminder providers via `Use{X}ReminderService` extension methods, where `X` is the name of the provider, for example, <xref:Orleans.Hosting.SiloHostBuilderReminderExtensions.UseAzureTableReminderService%2A>.

Azure Table configuration:

```csharp
// TODO replace with your connection string
const string connectionString = "YOUR_CONNECTION_STRING_HERE";
var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.UseAzureTableReminderService(connectionString)
    })
    .Build();
```

SQL:

```csharp
const string connectionString = "YOUR_CONNECTION_STRING_HERE";
const string invariant = "YOUR_INVARIANT";
var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.UseAdoNetReminderService(options =>
        {
            options.ConnectionString = connectionString; // Redacted
            options.Invariant = invariant;
        });
    })
    .Build();
```

 If you just want a placeholder implementation of reminders to work without needing to set up an Azure account or SQL database, then this gives you a development-only implementation of the reminder system:

```csharp
var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.UseInMemoryReminderService();
    })
    .Build();
```

## Reminder usage

A grain that uses reminders must implement the <xref:Orleans.IRemindable.ReceiveReminder%2A?displayProperty=nameWithType> method.

```csharp
Task IRemindable.ReceiveReminder(string reminderName, TickStatus status)
{
    Console.WriteLine("Thanks for reminding me-- I almost forgot!");
    return Task.CompletedTask;
}
```

 To start a reminder, use the <xref:Orleans.Grain.RegisterOrUpdateReminder%2A?displayProperty=nameWithType> method, which returns an <xref:Orleans.Runtime.IGrainReminder> object:

```csharp
protected Task<IGrainReminder> RegisterOrUpdateReminder(
    string reminderName,
    TimeSpan dueTime,
    TimeSpan period)
```

* `reminderName`: is a string that must uniquely identify the reminder within the scope of the contextual grain.
* `dueTime`: specifies a quantity of time to wait before issuing the first-timer tick.
* `period`: specifies the period of the timer.

Since reminders survive the lifetime of any single activation, they must be explicitly canceled (as opposed to being disposed). You cancel a reminder by calling <xref:Orleans.Grain.UnregisterReminder%2A?displayProperty=nameWithType>:

```csharp
protected Task UnregisterReminder(IGrainReminder reminder)
```

The `reminder` is the handle object returned by <xref:Orleans.Grain.RegisterOrUpdateReminder%2A?displayProperty=nameWithType>.

Instances of `IGrainReminder` aren't guaranteed to be valid beyond the lifespan of an activation. If you wish to identify a reminder in a way that persists, use a string containing the reminder's name.

If you only have the reminder's name and need the corresponding instance of  `IGrainReminder`, call the <xref:Orleans.Grain.GetReminder%2A?displayProperty=nameWithType> method:

```csharp
protected Task<IGrainReminder> GetReminder(string reminderName)
```

## Decide which to use

We recommend that you use timers in the following circumstances:

* If it doesn't matter (or is desirable) that the timer ceases to function when the activation is deactivated or failures occur.
* The resolution of the timer is small (for example, reasonably expressible in seconds or minutes).
* The timer callback can be started from <xref:Orleans.Grain.OnActivateAsync?displayProperty=nameWithType> or when a grain method is invoked.

We recommend that you use reminders in the following circumstances:

* When the periodic behavior needs to survive the activation and any failures.
* Performing infrequent tasks (for example, reasonably expressible in minutes, hours, or days).

## Combine timers and reminders

You might consider using a combination of reminders and timers to accomplish your goal. For example, if you need a timer with a small resolution that needs to survive across activations, you can use a reminder that runs every five minutes, whose purpose is to wake up a grain that restarts a local timer that may have been lost due to deactivation.

## POCO grain registrations

To register a timer or reminder with [a POCO grain](../migration-guide.md#poco-grains-and-igrainbase), you implement the <xref:Orleans.IGrainBase> interface and inject the <xref:Orleans.Timers.ITimerRegistry> or <xref:Orleans.Timers.IReminderRegistry> into the grain's constructor.

```csharp
public sealed class PingGrain : IGrainBase, IPingGrain
{
    private readonly ITimerRegistry _timerRegistry;
    private readonly IReminderRegistry _reminderRegistry;

    public PingGrain(ITimerRegistry timerRegistry, IReminderRegistry reminderRegistry)
    {
        _timerRegistry = timerRegistry;
        _reminderRegistry = reminderRegistry;
    }

    // Omitted for brevity...
}
```
