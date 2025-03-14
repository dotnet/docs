---
title: Use scoped services within a BackgroundService
description: Learn how to use scoped services within a BackgroundService in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 11/06/2024
ms.topic: tutorial
---

# Use scoped services within a `BackgroundService`

When you register implementations of <xref:Microsoft.Extensions.Hosting.IHostedService> using any of the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%2A> extension methods—the service is registered as a singleton. There might be scenarios where you'd like to rely on a scoped service. For more information, see [Dependency injection in .NET: Service lifetimes](dependency-injection.md#service-lifetimes).

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Resolve scoped dependencies in a singleton <xref:Microsoft.Extensions.Hosting.BackgroundService>.
> - Delegate work to a scoped service.
> - Implement an `override` of <xref:Microsoft.Extensions.Hosting.BackgroundService.StopAsync(System.Threading.CancellationToken)?displayProperty=nameWithType>.

[!INCLUDE [workers-samples-browser](includes/workers-samples-browser.md)]

## Prerequisites

- The [.NET 8.0 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- A .NET integrated development environment (IDE)
  - Feel free to use [Visual Studio](https://visualstudio.microsoft.com)

<!-- ## Create a new project -->
[!INCLUDE [file-new-worker](includes/file-new-worker.md)]

## Create scoped services

To use [scoped services](dependency-injection.md#scoped) within a `BackgroundService`, create a scope with the <xref:Microsoft.Extensions.DependencyInjection.IServiceScopeFactory.CreateScope?displayProperty=nameWithType> API. No scope is created for a hosted service by default. The scoped background service contains the background task's logic.

:::code source="snippets/workers/scoped-service/IScopedProcessingService.cs":::

The preceding interface defines a single `DoWorkAsync` method. Create an implementation in a new class named *DefaultScopedProcessingService.cs*:

:::code source="snippets/workers/scoped-service/DefaultScopedProcessingService.cs":::

- An <xref:Microsoft.Extensions.Logging.ILogger> is injected into the service using a primary constructor.
- The `DoWorkAsync` method returns a `Task` and accepts the <xref:System.Threading.CancellationToken>.
  - The method logs the instance identifier—the `_instanceId` is assigned whenever the class is instantiated.

## Rewrite the Worker class

Replace the existing `Worker` class with the following C# code, and rename the file to *ScopedBackgroundService.cs*:

:::code source="snippets/workers/scoped-service/ScopedBackgroundService.cs" highlight="14-24":::

In the preceding code, while the `stoppingToken` isn't canceled, the `IServiceScopeFactory` is used to create a scope. From the `IServiceScope`, the `IScopedProcessingService` is resolved. The `DoWorkAsync` method is awaited, and the `stoppingToken` is passed to the method. Finally, the execution is delayed for 10 seconds and the loop continues. Each time the `DoWorkAsync` method is called, a new instance of the `DefaultScopedProcessingService` is created and the instance identifier is logged.

Replace the template *Program.cs* file contents with the following C# code:

:::code source="snippets/workers/scoped-service/Program.cs" highlight="4-5":::

The services are registered in (*Program.cs*). The hosted service is registered with the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService*> extension method.

For more information on registering services, see [Dependency injection in .NET](dependency-injection.md).

## Verify service functionality

[!INCLUDE [run-app](includes/run-app.md)]

Let the application run for a bit to generate several calls to `DoWorkAsync`, thus logging new instance identifiers. You see output similar to the following logs:

```Output
info: App.ScopedService.ScopedBackgroundService[0]
      ScopedBackgroundService is running.
info: App.ScopedService.DefaultScopedProcessingService[0]
      DefaultScopedProcessingService doing work, instance ID: 8986a86f-b444-4139-b9ea-587daae4a6dd
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: .\scoped-service
info: App.ScopedService.DefaultScopedProcessingService[0]
      DefaultScopedProcessingService doing work, instance ID: 07a4a760-8e5a-4c0a-9e73-fcb2f93157d3
info: App.ScopedService.DefaultScopedProcessingService[0]
      DefaultScopedProcessingService doing work, instance ID: c847f432-acca-47ee-8720-1030859ce354
info: Microsoft.Hosting.Lifetime[0]
      Application is shutting down...
info: App.ScopedService.ScopedBackgroundService[0]
      ScopedBackgroundService is stopping.
```

[!INCLUDE [stop-app](includes/stop-app.md)]

## See also

- [Worker Services in .NET](workers.md)
- [Create a Queue Service](queue-service.md)
- [Create a Windows Service using `BackgroundService`](windows-service.md)
- [Implement the `IHostedService` interface](timer-service.md)
