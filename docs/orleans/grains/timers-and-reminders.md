---
title: Timers and reminders
description: Learn how to use timers and reminders in .NET Orleans.
ms.date: 08/01/2024
---

# Timers and reminders

The Orleans runtime provides two mechanisms, called timers and reminders, that enable the developer to specify periodic behavior for grains.

## Timers

**Timers** are used to create periodic grain behavior that isn't required to span multiple activations (instantiations of the grain). A timer is identical to the standard .NET <xref:System.Threading.Timer?displayProperty=fullName> class. In addition, timers are subject to single-threaded execution guarantees within the grain activation that they operate on.

Each activation may have zero or more timers associated with it. The runtime executes each timer routine within the runtime context of the activation that it's associated with.

## Timer usage

To start a timer, use the `RegisterGrainTimer` method, which returns an <xref:Orleans.Runtime.IGrainTimer> reference:

```csharp
protected IGrainTimer RegisterGrainTimer<TState>(
    Func<TState, CancellationToken, Task> callback, // function invoked when the timer ticks
    TState state,                                   // object to pass to callback
    GrainTimerCreationOptions options)              // timer creation options
```

To cancel the timer, you dispose of it.

A timer ceases to trigger if the grain is deactivated or when a fault occurs and its silo crashes.

***Important considerations:***

* When activation collection is enabled, the execution of a timer callback doesn't change the activation's state from idle to in-use. This means that a timer can't be used to postpone the deactivation of otherwise idle activations.
* The period passed to `Grain.RegisterGrainTimer` is the amount of time that passes from the moment the `Task` returned by `callback` is resolved to the moment that the next invocation of `callback` should occur. This not only makes it impossible for successive calls to `callback` to overlap, but also makes it so that the length of time `callback` takes to complete affects the frequency at which `callback` is invoked. This is an important deviation from the semantics of <xref:System.Threading.Timer?displayProperty=fullName>.
* Each invocation of `callback` is delivered to an activation on a separate turn, and never runs concurrently with other turns on the same activation.
* Callbacks do not interleave by default. Interleaving can be enabled by setting Interleave to true on GrainTimerCreationOptions.
* Grain timers can be updated using the Change(TimeSpan, TimeSpan) method on the returned IGrainTimer instance.
* Callbacks can keep the grain active, preventing it from being collected if the timer period is relatively short. This can be enabled by setting KeepAlive to true on GrainTimerCreationOptions.
* Callbacks can receive a CancellationToken which is canceled when the timer is disposed or the grain starts to deactivate.
* Callbacks can dispose the grain timer which fired them.
* Callbacks are subject to grain call filters.
* Callbacks are visible in distributed tracing, when distributed tracing is enabled.
* POCO grains (grain classes which do not inherit from Grain) can register grain timers using the RegisterGrainTimer extension method.

## Reminders

Reminders are similar to timers, with a few important differences:

* Reminders are persistent and continue to trigger in almost all situations (including partial or full cluster restarts) unless explicitly canceled.
* Reminder "definitions" are written to storage. However, each specific occurrence, with its specific time, isn't. This has the side effect that if the cluster is down at the time of a specific reminder tick, it will be missed and only the next tick of the reminder happens.
* Reminders are associated with a grain, not any specific activation.
* If a grain has no activation associated with it when a reminder ticks, the grain is created. If an activation becomes idle and is deactivated, a reminder associated with the same grain reactivates the grain when it ticks next.
* Reminder delivery occurs via message and is subject to the same interleaving semantics as all other grain methods.
* Reminders shouldn't be used for high-frequency timers- their period should be measured in minutes, hours, or days.

## Configuration

Reminders, being persistent, rely upon storage to function. You must specify which storage backing to use before the reminder subsystem functions. This is done by configuring one of the reminder providers via `Use{X}ReminderService` extension methods, where `X` is the name of the provider, for example, <xref:Orleans.Hosting.SiloHostBuilderReminderExtensions.UseAzureTableReminderService%2A>.

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

> [!IMPORTANT]
> If you have a heterogenous cluster, where the silos handle different grain types (implement different interfaces), every silo must add the configuration for Reminders, even if the silo itself doesn't handle any reminders.

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

:::code source="./snippets/timers/PingGrain.cs":::

The preceding code:

- Defines a POCO grain that implements <xref:Orleans.IGrainBase>, `IPingGrain`, and <xref:System.IDisposable>.
- Registers a timer that is invoked every 10 seconds, and starts 3 seconds after registration.
- When `Ping` is called, registers a reminder that is invoked every hour, and starts immediately following registration.
- The `Dispose` method cancels the reminder if it's registered.
