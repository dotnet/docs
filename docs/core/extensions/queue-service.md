---
title: Create a Queue Service
description: Learn how to create a queue service subclass of BackgroundService in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 11/12/2021
ms.topic: tutorial
---

# Create a Queue Service

A queue service is a great example of a long-running service, where work items can be queued and worked on sequentially as previous work items are completed. Relying on the Worker Service template, you'll build out new functionality on top of the <xref:Microsoft.Extensions.Hosting.BackgroundService>.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Create a queue service.
> - Delegate work to a task queue.
> - Register a console key-listener from <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime> events.

[!INCLUDE [workers-samples-browser](includes/workers-samples-browser.md)]

## Prerequisites

- The [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- A .NET integrated development environment (IDE)
  - Feel free to use [Visual Studio](https://visualstudio.microsoft.com)

<!-- ## Create a new project -->
[!INCLUDE [file-new-worker](includes/file-new-worker.md)]

## Create queuing services

You may be familiar with the <xref:System.Web.Hosting.HostingEnvironment.QueueBackgroundWorkItem(System.Func{System.Threading.CancellationToken,System.Threading.Tasks.Task})> functionality from the `System.Web.Hosting` namespace. To model a service that is inspired by this functionality, start by adding an `IBackgroundTaskQueue` interface to the project:

:::code source="snippets/workers/queue-service/IBackgroundTaskQueue.cs":::

There are two methods, one that exposes queuing functionality, and another that dequeues previously queued work items. A *work item* is a `Func<CancellationToken, ValueTask>`. Next, add the default implementation to the project.

:::code source="snippets/workers/queue-service/DefaultBackgroundTaskQueue.cs":::

The preceding implementation relies on a <xref:System.Threading.Channels.Channel%601> as a queue. The <xref:System.Threading.Channels.BoundedChannelOptions.%23ctor(System.Int32)> is called with an explicit capacity. Capacity should be set based on the expected application load and number of concurrent threads accessing the queue. <xref:System.Threading.Channels.BoundedChannelFullMode.Wait?displayProperty=nameWithType> will cause calls to <xref:System.Threading.Channels.ChannelWriter%601.WriteAsync%2A?displayProperty=nameWithType> to return a task, which completes only when space becomes available. This leads to backpressure, in case too many publishers/calls start accumulating.

## Rewrite the Worker class

In the following `QueueHostedService` example:

- The `ProcessTaskQueueAsync` method returns a <xref:System.Threading.Tasks.Task> in `ExecuteAsync`.
- Background tasks in the queue are dequeued and executed in `ProcessTaskQueueAsync`.
- Work items are awaited before the service stops in `StopAsync`.

Replace the existing `Worker` class with the following C# code, and rename the file to *QueueHostedService.cs*.

:::code source="snippets/workers/queue-service/QueuedHostedService.cs" highlight="29-30,32":::

A `MonitorLoop` service handles enqueuing tasks for the hosted service whenever the `w` key is selected on an input device:

- The `IBackgroundTaskQueue` is injected into the `MonitorLoop` service.
- `IBackgroundTaskQueue.QueueBackgroundWorkItemAsync` is called to enqueue a work item.
- The work item simulates a long-running background task:
  - Three 5-second delays are executed <xref:System.Threading.Tasks.Task.Delay%2A>.
  - A `try-catch` statement traps <xref:System.OperationCanceledException> if the task is canceled.

:::code source="snippets/workers/queue-service/MonitorLoop.cs" highlight="5,10,35":::

Replace the existing `Program` contents with the following C# code:

:::code source="snippets/workers/queue-service/Program.cs" highlight="6-16":::

The services are registered in `IHostBuilder.ConfigureServices` (*Program.cs*). The hosted service is registered with the `AddHostedService` extension method. `MonitorLoop` is started in *Program.cs* top-level statement:

:::code source="snippets/workers/queue-service/Program.cs" range="20-21":::

For more information on registering services, see [Dependency injection in .NET](dependency-injection.md).

## Verify service functionality

[!INCLUDE [run-app](includes/run-app.md)]

When prompted enter the `w` (or `W`) at least once to queue an emulated work item. You will see output similar to the following:

```Output
info: App.QueueService.MonitorLoop[0]
      MonitorAsync loop is starting.
info: App.QueueService.QueuedHostedService[0]
      QueuedHostedService is running.

      Tap W to add a work item to the background queue.

info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: .\queue-service
winfo: App.QueueService.MonitorLoop[0]
      Queued work item 8453f845-ea4a-4bcb-b26e-c76c0d89303e is starting.
info: App.QueueService.MonitorLoop[0]
      Queued work item 8453f845-ea4a-4bcb-b26e-c76c0d89303e is running. 1/3
info: App.QueueService.MonitorLoop[0]
      Queued work item 8453f845-ea4a-4bcb-b26e-c76c0d89303e is running. 2/3
info: App.QueueService.MonitorLoop[0]
      Queued work item 8453f845-ea4a-4bcb-b26e-c76c0d89303e is running. 3/3
info: App.QueueService.MonitorLoop[0]
      Queued Background Task 8453f845-ea4a-4bcb-b26e-c76c0d89303e is complete.
info: Microsoft.Hosting.Lifetime[0]
      Application is shutting down...
info: App.QueueService.QueuedHostedService[0]
      QueuedHostedService is stopping.
```

[!INCLUDE [stop-app](includes/stop-app.md)]

## See also

- [Worker Services in .NET](workers.md)
- [Use scoped services within a `BackgroundService`](scoped-service.md)
- [Create a Windows Service using `BackgroundService`](windows-service.md)
- [Implement the `IHostedService` interface](timer-service.md)
