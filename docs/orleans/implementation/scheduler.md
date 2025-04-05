---
title: Scheduling overview
description: Explore the scheduling overview in .NET Orleans.
ms.date: 07/03/2024
---

# Scheduling overview

There are two forms of scheduling in Orleans which are relevant to grains:

1. Request scheduling, the scheduling of incoming grain calls for execution according to scheduling rules discussed [in Request scheduling](../grains/request-scheduling.md).
1. Task scheduling, the scheduling of synchronous blocks of code to be executed in a *single-threaded* manner

All grain code is executed on the grain's task scheduler, which means that requests are also executed on the grain's task scheduler.
Even if the request scheduling rules allow multiple requests to execute *concurrently*, they will not execute *in parallel* because the grain's task scheduler always executes tasks one-by-one and hence never executes multiple tasks in parallel.

## Task scheduling

To better understand scheduling, consider the following grain, `MyGrain`, which has a method called `DelayExecution()` which logs a message, waits some time, then logs another message before returning.

```csharp
public interface IMyGrain : IGrain
{
    Task DelayExecution();
}

public class MyGrain : Grain, IMyGrain
{
    private readonly ILogger<MyGrain> _logger;

    public MyGrain(ILogger<MyGrain> logger) => _logger = logger;

    public async Task DelayExecution()
    {
        _logger.LogInformation("Executing first task");

        await Task.Delay(1_000);

        _logger.LogInformation("Executing second task");
    }
}
```

When this method is executed, the method body will be executed in two parts:

1. The first `_logger.LogInformation(...)` call and the call to `Task.Delay(1_000)`.
1. The second `_logger.LogInformation(...)` call.

The second task will not be scheduled on the grain's task scheduler until the `Task.Delay(1_000)` call completes, at which point it will schedule the *continuation* of the grain method.

Here is a graphical representation of how a request is scheduled and executed as two tasks:

:::image type="content" source="media/scheduler/scheduling-1.png" alt-text="Two-Task-based request execution example.":::

The above description is not specific to Orleans; it describes how task scheduling in .NET works: the compiler converts asynchronous methods in C# into an asynchronous state machine, and execution progresses through the asynchronous state machine in discrete steps. Each step is scheduled on the current <xref:System.Threading.Tasks.TaskScheduler> (accessed via <xref:System.Threading.Tasks.TaskScheduler.Current?displayProperty=nameWithType>, defaulting to <xref:System.Threading.Tasks.TaskScheduler.Default?displayProperty=nameWithType>) or the current <xref:System.Threading.SynchronizationContext>. If a `TaskScheduler` is being used, each step in the method represents a `Task` instance, which is passed to that `TaskScheduler`. Therefore, a `Task` in .NET can represent two conceptual things:

1. An asynchronous operation that can be waited on. The execution of the `DelayExecution()` method above is represented by a `Task` which can be awaited.
1. In a synchronous block of work, each stage within the `DelayExecution()` method above is represented by a `Task`.

When `TaskScheduler.Default` is in use, continuations are scheduled directly onto the .NET <xref:System.Threading.ThreadPool> and are not wrapped in a `Task` object. The wrapping of continuations in `Task` instances occurs transparently and therefore developers rarely need to be aware of these implementation details.

### Task scheduling in Orleans

Each grain activation has its own `TaskScheduler` instance which is responsible for enforcing the *single-threaded* execution model of grains. Internally, this `TaskScheduler` is implemented via `ActivationTaskScheduler` and `WorkItemGroup`. `WorkItemGroup` keeps enqueued tasks in a <xref:System.Collections.Generic.Queue%601> where `T` is a `Task` internally and implements <xref:System.Threading.IThreadPoolWorkItem>. To execute each currently enqueued `Task`, `WorkItemGroup` schedules *itself* on the .NET `ThreadPool`. When the .NET `ThreadPool` invokes the `WorkItemGroup`'s `IThreadPoolWorkItem.Execute()` method, the `WorkItemGroup` executes the enqueued `Task` instances one-by-one.

Each grain has a scheduler which executes by scheduling itself on the .NET `ThreadPool`:

:::image type="content" source="media/scheduler/scheduling-2.png" alt-text="Orleans grains scheduling themselves on the .NET ThreadPool.":::

Each scheduler contains a queue of tasks:

:::image type="content" source="media/scheduler/scheduling-3.png" alt-text="Scheduler queue of scheduled tasks.":::

The .NET `ThreadPool` executes each work item enqueued to it. This includes *grain schedulers* as well as other work items, such as work items scheduled via `Task.Run(...)`:

:::image type="content" source="media/scheduler/scheduling-4.png" alt-text="Visualization of the all schedulers running in the .NET ThreadPool.":::

> [!NOTE]
> A grain's scheduler can only execute on one thread at a time, but it does not always execute on the same thread. The .NET `ThreadPool` is free to use a different thread each time the grain's scheduler is executed. The grain's scheduler is responsible for making sure that it only executes on one thread at a time and this is how the *single-threaded* execution model of grains is implemented.
