---
title: Implement the IHostedService interface
description: Learn how to implement a custom IHostedService interface with .NET.
author: IEvangelist
ms.author: dapine
ms.date: 12/17/2021
ms.topic: tutorial
---

# Implement the `IHostedService` interface

When you need finite control beyond the provided <xref:Microsoft.Extensions.Hosting.BackgroundService>, you can implement your own <xref:Microsoft.Extensions.Hosting.IHostedService>. The <xref:Microsoft.Extensions.Hosting.IHostedService> interface is the basis for all long running services in .NET. Custom implementations are registered with the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%60%601(Microsoft.Extensions.DependencyInjection.IServiceCollection)> extension method.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Implement the <xref:Microsoft.Extensions.Hosting.IHostedService>, and <xref:System.IAsyncDisposable> interfaces.
> - Create a timer-based service.
> - Register the custom implementation with dependency injection and logging.

[!INCLUDE [workers-samples-browser](includes/workers-samples-browser.md)]

## Prerequisites

- The [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- A .NET integrated development environment (IDE)
  - Feel free to use [Visual Studio](https://visualstudio.microsoft.com)

<!-- ## Create a new project -->
[!INCLUDE [file-new-worker](includes/file-new-worker.md)]

## Create timer service

The timer-based background service makes use of the <xref:System.Threading.Timer?displayProperty=fullName> class. The timer triggers the `DoWork` method. The timer is disabled on <xref:Microsoft.Extensions.Hosting.IHostLifetime.StopAsync(System.Threading.CancellationToken)?displayProperty=nameWithType> and disposed when the service container is disposed on <xref:System.IAsyncDisposable.DisposeAsync?displayProperty=nameWithType>:

Replace the contents of the `Worker` from the template with the following C# code, and rename the file to *TimerService.cs*:

:::code source="snippets/workers/timer-service/TimerService.cs" highlight="35,42-45":::

> [!IMPORTANT]
> The `Worker` was a subclass of <xref:Microsoft.Extensions.Hosting.BackgroundService>. Now, the `TimerService` implements both the <xref:Microsoft.Extensions.Hosting.IHostedService>, and <xref:System.IAsyncDisposable> interfaces.

The `TimerService` is `sealed`, and cascades the `DisposeAsync` call from its `_timer` instance. For more information on the "cascading dispose pattern", see [Implement a `DisposeAsync` method](../../standard/garbage-collection/implementing-disposeasync.md).

When <xref:Microsoft.Extensions.Hosting.IHostedService.StartAsync%2A> is called, the timer is instantiated, thus starting the timer.

> [!TIP]
> The <xref:System.Threading.Timer> doesn't wait for previous executions of `DoWork` to finish, so the approach shown might not be suitable for every scenario. <xref:System.Threading.Interlocked.Increment%2A?displayProperty=nameWithType> is used to increment the execution counter as an atomic operation, which ensures that multiple threads don't update `_executionCount` concurrently.

Replace the existing `Program` contents with the following C# code:

:::code source="snippets/workers/timer-service/Program.cs" highlight="6":::

The service is registered in `IHostBuilder.ConfigureServices` (*Program.cs*) with the `AddHostedService` extension method. This is the same extension method you use when registering <xref:Microsoft.Extensions.Hosting.BackgroundService> subclasses, as they both implement the <xref:Microsoft.Extensions.Hosting.IHostedService> interface.

For more information on registering services, see [Dependency injection in .NET](dependency-injection.md).

## Verify service functionality

[!INCLUDE [run-app](includes/run-app.md)]

Let the application run for a bit to generate several execution count increments. You will see output similar to the following:

```Output
info: App.TimerHostedService.TimerService[0]
      TimerHostedService is running.
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: .\timer-service
info: App.TimerHostedService.TimerService[0]
      TimerHostedService is working, execution count: 1
info: App.TimerHostedService.TimerService[0]
      TimerHostedService is working, execution count: 2
info: App.TimerHostedService.TimerService[0]
      TimerHostedService is working, execution count: 3
info: App.TimerHostedService.TimerService[0]
      TimerHostedService is working, execution count: 4
info: Microsoft.Hosting.Lifetime[0]
      Application is shutting down...
info: App.TimerHostedService.TimerService[0]
      TimerHostedService is stopping.
```

[!INCLUDE [stop-app](includes/stop-app.md)]

## See also

There are several related tutorials to consider:

- [Worker Services in .NET](workers.md)
- [Create a Queue Service](queue-service.md)
- [Use scoped services within a `BackgroundService`](scoped-service.md)
- [Create a Windows Service using `BackgroundService`](windows-service.md)
