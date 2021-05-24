---
title: Create a Queue Service in .NET
description: Learn how to create a queue service subclass of BackgroundService in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 05/24/2021
ms.topic: tutorial
---

# Create a Queue Service in .NET

A queue service is a great example of a long-running service, where work items can be queued and worked on sequentially as previous work items are completed. Relying on the Worker Service template, you'll build out a bit more functionality on top of the <xref:Microsoft.Extensions.Hosting.BackgroundService>.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Create a queue service.
> - Delegate work to a task queue.
> - Register a console key-listener from <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime> events.

## Prerequisites

- The [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- A .NET integrated development environment (IDE)
  - Feel free to use the [Visual Studio IDE](https://visualstudio.microsoft.com)

## Queue service

You may be familiar with the <xref:System.Web.Hosting.HostingEnvironment.QueueBackgroundWorkItem> functionality from the `System.Web.Hosting` namespace. This service implementation is inspired by it, start be defining an `IBackgroundTaskQueue` interface:

:::code source="snippets/workers/queue-service/IBackgroundTaskQueue.cs":::

There are two methods, one which exposing queuing functionality and the other that dequeues previously queued work items. A work item is `Func<CancellationToken, ValueTask>`.

:::code source="snippets/workers/queue-service/DefaultBackgroundTaskQueue.cs":::

The preceding implementation relies on a <xref:System.Threading.Channels.Channel%601> as a queue.

In the following `QueueHostedService` example:

- The `BackgroundProcessing` method returns a `Task`, which is awaited in `ExecuteAsync`.
- Background tasks in the queue are dequeued and executed in `BackgroundProcessing`.
- Work items are awaited before the service stops in `StopAsync`.

:::code source="snippets/workers/queue-service/QueuedHostedService.cs" highlight="35-36,38":::

A `MonitorLoop` service handles enqueuing tasks for the hosted service whenever the `w` key is selected on an input device:

- The `IBackgroundTaskQueue` is injected into the `MonitorLoop` service.
- `IBackgroundTaskQueue.QueueBackgroundWorkItem` is called to enqueue a work item.
- The work item simulates a long-running background task:
  - Three 5-second delays are executed (`Task.Delay`).
  - A `try-catch` statement traps <xref:System.OperationCanceledException> if the task is cancelled.

:::code source="snippets/workers/queue-service/MonitorLoop.cs" highlight="11,16,41":::

The services are registered in `IHostBuilder.ConfigureServices` (*Program.cs*). The hosted service is registered with the `AddHostedService` extension method:

:::code source="snippets/workers/queue-service/Program.cs" highlight="8-18":::

`MonitorLoop` is started in *Program.cs* top-level statement:

:::code source="snippets/workers/queue-service/Program.cs" range="22-23":::

## See also

There are several related tutorials to consider:

- <xref:Microsoft.Extensions.Hosting.BackgroundService> subclass tutorials:
  - Queue Service
  - Scoped Service
  - Windows Service
- Custom <xref:Microsoft.Extensions.Hosting.IHostedService> implementation:
  - Timer Service
