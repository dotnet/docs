---
title: Activation garbage collection
description: Learn about activation garbage collection in .NET Orleans.
ms.date: 03/16/2022
---

# Activation garbage collection

As described in the Core Concepts section, a *grain activation* is an in-memory instance of a grain class that gets automatically created by the Orleans runtime on an as-needed basis as a temporary physical embodiment of a grain.

Activation Garbage Collection (Activation GC) is the process of removal from memory of unused grain activations. It is conceptually similar to how garbage collection of memory works in .NET. However, Activation GC only takes into consideration how long a particular grain activation has been idle. Memory usage is not used as a factor.

## How activation GC works

The general process of Activation GC involves Orleans runtime in a silo periodically scanning for grain activations that have not been used at all for the configured period (Collection Age Limit). Once a grain activation has been idle for that long, it gets deactivated. The deactivation process begins by the runtime calling the grain's <xref:Orleans.Grain.OnDeactivateAsync> method, and completes by removing references to the grain activation object from all data structures of the silo, so that the memory is reclaimed by the .NET GC.

As a result, with no burden put on the application code, only recently used grain activations stay in memory while activations that aren't used anymore get automatically removed, and system resources used by them get reclaimed by the runtime.

**What counts as "being active" for grain activation collection**

* Receiving a method call.
* Receiving a reminder.
* Receiving an event via streaming.

**What does NOT count as "being active" for grain activation collection**

* Performing a call (to another grain or an Orleans client).
* Timer events.
* Arbitrary IO operations or external calls not involving Orleans framework.

**Collection Age Limit**

This time after which an idle grain activation becomes subject to Activation GC is called Collection Age Limit. The default Collection Age Limit is 2 hours, but it can be changed globally or for individual grain classes.

## Explicit control of activation garbage collection

### Delay activation GC

A grain activation can delay its own Activation GC, by calling <xref:Orleans.Grain.DelayDeactivation%2A> method:

```csharp
protected void DelayDeactivation(TimeSpan timeSpan)
```

This call will ensure that this activation is not deactivated for at least the specified time duration. It takes priority over Activation Garbage Collection settings specified in the config, but does not cancel them. Therefore, this call provides an additional hook to **delay the deactivation beyond what is specified in the Activation Garbage Collection settings**. This call can not be used to expedite Activation Garbage Collection.

A positive `timeSpan` value means "prevent GC of this activation for that time".

A negative `timeSpan` value means "cancel the previous setting of the `DelayDeactivation` call and make this activation behave based on the regular Activation Garbage Collection settings".

**Scenarios:**

1. Activation Garbage Collection settings specify an age limit of 10 minutes and the grain is making a call to `DelayDeactivation(TimeSpan.FromMinutes(20))`, it will cause this activation to not be collected for at least 20 min.

1. Activation Garbage Collection settings specify an age limit of 10 minutes and the grain is making a call to `DelayDeactivation(TimeSpan.FromMinutes(5))`, the activation will be collected after 10 min, if no extra calls were made.

1. Activation Garbage Collection settings specify an age limit of 10 minutes and the grain is making a call to `DelayDeactivation(TimeSpan.FromMinutes(5))`, and after 7 minutes there is another call on this grain, the activation will be collected after 17 min from time zero, if no extra calls were made.

1. Activation Garbage Collection settings specify an age limit of 10 minutes and the grain is making a call to `DelayDeactivation(TimeSpan.FromMinutes(20))`, and after 7 minutes there is another call on this grain, the activation will be collected after 20 min from time zero, if no extra calls were made.

Note that `DelayDeactivation` does not 100% guarantee that the grain activation will not get deactivated before the specified time expires. Certain failure cases may cause 'premature' deactivation of grains. That means that `DelayDeactivation` **can not be used as a means to 'pin' a grain activation in memory forever or to a specific silo**. `DelayDeactivation` is merely an optimization mechanism that can help reduce the aggregate cost of a grain getting deactivated and reactivated over time, if that matters. In most cases, there should be no need to use `DelayDeactivation` at all.

### Expedite activation GC

A grain activation can also instruct the runtime to deactivate it next time it becomes idle by calling <xref:Orleans.Grain.DeactivateOnIdle> method:

```csharp
protected void DeactivateOnIdle()
```

A grain activation is considered idle if it is not processing any message at the moment. If you call `DeactivateOnIdle` while a grain is processing a message, it will get deactivated as soon as the processing of the current message is finished. If there are any requests queued for the grain, they will be forwarded to the next activation.

`DeactivateOnIdle` takes priority over any Activation Garbage Collection settings specified in the config or `DelayDeactivation`.

> [!NOTE]
> Setting only applies to the grain activation from which it has been called and it does not apply to other grain activation of this type.

## Configuration

Grain garbage collection can be configured using the <xref:Orleans.Configuration.GrainCollectionOptions>:

```csharp
mySiloHostBuilder.Configure<GrainCollectionOptions>(options =>
{
    // Set the value of CollectionAge to 10 minutes for all grain
    options.CollectionAge = TimeSpan.FromMinutes(10);

    // Override the value of CollectionAge to 5 minutes for MyGrainImplementation
    options.ClassSpecificCollectionAge[typeof(MyGrainImplementation).FullName] =
        TimeSpan.FromMinutes(5);
})
```
