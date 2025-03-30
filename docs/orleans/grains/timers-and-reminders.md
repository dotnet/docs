---
title: Timers and reminders
description: Learn how to use timers and reminders in .NET Orleans.
ms.date: 05/23/2025
ms.topic: conceptual
ms.service: orleans
---

# Timers and reminders

The Orleans runtime provides two mechanisms, timers and reminders, that enable you to specify periodic behavior for grains.

## Timers

Use **timers** to create periodic grain behavior that isn't required to span multiple activations (instantiations of the grain). A timer is identical to the standard .NET <xref:System.Threading.Timer?displayProperty=fullName> class. Additionally, timers are subject to single-threaded execution guarantees within the grain activation they operate on.

Each activation can have zero or more timers associated with it. The runtime executes each timer routine within the runtime context of its associated activation.

## Timer usage

To start a timer, use the `RegisterGrainTimer` method, which returns an <xref:Orleans.Runtime.IGrainTimer> reference:

```csharp
protected IGrainTimer RegisterGrainTimer<TState>(
    Func<TState, CancellationToken, Task> callback, // function invoked when the timer ticks
    TState state,                                   // object to pass to callback
    GrainTimerCreationOptions options)              // timer creation options
```

To cancel the timer, dispose of it.

A timer stops triggering if the grain deactivates or when a fault occurs and its silo crashes.

***Important considerations:***

- When activation collection is enabled, executing a timer callback doesn't change the activation's state from idle to in-use. This means you can't use a timer to postpone the deactivation of otherwise idle activations.
- The period passed to `Grain.RegisterGrainTimer` is the amount of time passing from the moment the `Task` returned by `callback` resolves to the moment the next invocation of `callback` should occur. This not only prevents successive calls to `callback` from overlapping but also means the time `callback` takes to complete affects the frequency at which `callback` is invoked. This is an important deviation from the semantics of <xref:System.Threading.Timer?displayProperty=fullName>.
- Each invocation of `callback` is delivered to an activation on a separate turn and never runs concurrently with other turns on the same activation.
- Callbacks don't interleave by default. You can enable interleaving by setting `Interleave` to `true` on `GrainTimerCreationOptions`.
- You can update grain timers using the `Change(TimeSpan, TimeSpan)` method on the returned `IGrainTimer` instance.
- Callbacks can keep the grain active, preventing collection if the timer period is relatively short. Enable this by setting `KeepAlive` to `true` on `GrainTimerCreationOptions`.
- Callbacks can receive a `CancellationToken` that is canceled when the timer is disposed or the grain starts to deactivate.
- Callbacks can dispose of the grain timer that fired them.
- Callbacks are subject to grain call filters.
- Callbacks are visible in distributed tracing when distributed tracing is enabled.
- POCO grains (grain classes that don't inherit from `Grain`) can register grain timers using the `RegisterGrainTimer` extension method.

## Reminders

Reminders are similar to timers, with a few important differences:

- Reminders are persistent and continue to trigger in almost all situations (including partial or full cluster restarts) unless explicitly canceled.
- Reminder "definitions" are written to storage. However, each specific occurrence with its specific time isn't stored. This has the side effect that if the cluster is down when a specific reminder tick is due, it will be missed, and only the next tick of the reminder occurs.
- Reminders are associated with a grain, not any specific activation.
- If a grain has no activation associated with it when a reminder ticks, Orleans creates the grain activation. If an activation becomes idle and is deactivated, a reminder associated with the same grain reactivates the grain when it ticks next.
- Reminder delivery occurs via message and is subject to the same interleaving semantics as all other grain methods.
- You shouldn't use reminders for high-frequency timers; their period should be measured in minutes, hours, or days.

## Configuration

Since reminders are persistent, they rely on storage to function. You must specify which storage backing to use before the reminder subsystem can function. Do this by configuring one of the reminder providers via `Use{X}ReminderService` extension methods, where `X` is the name of the provider (for example, <xref:Orleans.Hosting.SiloHostBuilderReminderExtensions.UseAzureTableReminderService%2A>).

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

 If you just want a placeholder implementation of reminders to work without needing to set up an Azure account or SQL database, this provides a development-only implementation of the reminder system:

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

A grain using reminders must implement the <xref:Orleans.IRemindable.ReceiveReminder%2A?displayProperty=nameWithType> method.

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

- `reminderName`: is a string that must uniquely identify the reminder within the scope of the contextual grain.
- `dueTime`: specifies a quantity of time to wait before issuing the first-timer tick.
- `period`: specifies the period of the timer.

Since reminders survive the lifetime of any single activation, you must explicitly cancel them (as opposed to disposing of them). Cancel a reminder by calling <xref:Orleans.Grain.UnregisterReminder%2A?displayProperty=nameWithType>:

```csharp
protected Task UnregisterReminder(IGrainReminder reminder)
```

The `reminder` is the handle object returned by <xref:Orleans.Grain.RegisterOrUpdateReminder%2A?displayProperty=nameWithType>.

Instances of `IGrainReminder` aren't guaranteed to be valid beyond the lifespan of an activation. If you wish to identify a reminder persistently, use a string containing the reminder's name.

If you only have the reminder's name and need the corresponding `IGrainReminder` instance, call the <xref:Orleans.Grain.GetReminder%2A?displayProperty=nameWithType> method:

```csharp
protected Task<IGrainReminder> GetReminder(string reminderName)
```

## Decide which to use

We recommend using timers in the following circumstances:

- If it doesn't matter (or is desirable) that the timer stops functioning when the activation deactivates or failures occur.
- The timer's resolution is small (e.g., reasonably expressible in seconds or minutes).
- You can start the timer callback from <xref:Orleans.Grain.OnActivateAsync?displayProperty=nameWithType> or when a grain method is invoked.

We recommend using reminders in the following circumstances:

- When the periodic behavior needs to survive activation and any failures.
- Performing infrequent tasks (e.g., reasonably expressible in minutes, hours, or days).

## Combine timers and reminders

You might consider using a combination of reminders and timers to accomplish your goal. For example, if you need a timer with a small resolution that must survive across activations, you can use a reminder running every five minutes. Its purpose would be to wake up a grain that restarts a local timer possibly lost due to deactivation.

## POCO grain registrations

To register a timer or reminder with [a POCO grain](../migration-guide.md#poco-grains-and-igrainbase), implement the <xref:Orleans.IGrainBase> interface and inject <xref:Orleans.Timers.ITimerRegistry> or <xref:Orleans.Timers.IReminderRegistry> into the grain's constructor.

:::code source="./snippets/timers/PingGrain.cs":::

The preceding code does the following:

- Defines a POCO grain implementing <xref:Orleans.IGrainBase>, `IPingGrain`, and <xref:System.IDisposable>.
- Registers a timer invoked every 10 seconds, starting 3 seconds after registration.
- When `Ping` is called, registers a reminder invoked every hour, starting immediately after registration.
- The `Dispose` method cancels the reminder if it's registered.
