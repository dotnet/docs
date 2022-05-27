---
title: Use scoped services within a BackgroundService
description: Learn how to use scoped services within a BackgroundService in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 11/12/2021
ms.topic: tutorial
---

# Use scoped services within a `BackgroundService`

When you register implementations of <xref:Microsoft.Extensions.Hosting.IHostedService> using any of the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%2A> extension methods - the service is registered as a singleton. There may be scenarios where you'd like to rely on a scoped service. For more information, see [Dependency injection in .NET: Service lifetimes](dependency-injection.md#service-lifetimes).

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Resolve scoped dependencies in a singleton <xref:Microsoft.Extensions.Hosting.BackgroundService>.
> - Delegate work to a scoped service.
> - Implement an `override` of <xref:Microsoft.Extensions.Hosting.BackgroundService.StopAsync(System.Threading.CancellationToken)?displayProperty=nameWithType>.

[!INCLUDE [workers-samples-browser](includes/workers-samples-browser.md)]

## Prerequisites

- The [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- A .NET integrated development environment (IDE)
  - Feel free to use [Visual Studio](https://visualstudio.microsoft.com)

<!-- ## Create a new project -->
[!INCLUDE [file-new-worker](includes/file-new-worker.md)]

## Create scoped services

To use [scoped services](dependency-injection.md#scoped) within a `BackgroundService`, create a scope. No scope is created for a hosted service by default. The scoped background service contains the background task's logic.

:::code source="snippets/workers/scoped-service/IScopedProcessingService.cs":::

The preceding interface defines a single `DoWorkAsync` method. To define the default implementation:

- The service is asynchronous. The `DoWorkAsync` method returns a `Task`. For demonstration purposes, a delay of ten seconds is awaited in the `DoWorkAsync` method.
- An <xref:Microsoft.Extensions.Logging.ILogger> is injected into the service.:

:::code source="snippets/workers/scoped-service/DefaultScopedProcessingService.cs":::

The hosted service creates a scope to resolve the scoped background service to call its `DoWorkAsync` method. `DoWorkAsync` returns a `Task`, which is awaited in `ExecuteAsync`:

## Rewrite the Worker class

Replace the existing `Worker` class with the following C# code, and rename the file to *ScopedBackgroundService.cs*:

:::code source="snippets/workers/scoped-service/ScopedBackgroundService.cs" highlight="26-32":::

In the preceding code, an explicit scope is created and the `IScopedProcessingService` implementation is resolved from the dependency injection service provider. The resolved service instance is scoped, and its `DoWorkAsync` method is awaited.

Replace the template *Program.cs* file contents with the following C# code:

:::code source="snippets/workers/scoped-service/Program.cs" highlight="6-7":::

The services are registered in `IHostBuilder.ConfigureServices` (*Program.cs*). The hosted service is registered with the `AddHostedService` extension method.

For more information on registering services, see [Dependency injection in .NET](dependency-injection.md).

## Verify service functionality

[!INCLUDE [run-app](includes/run-app.md)]

Let the application run for a bit to generate several execution count increments. You will see output similar to the following:

```Output
info: App.ScopedService.ScopedBackgroundService[0]
      ScopedBackgroundService is running.
info: App.ScopedService.ScopedBackgroundService[0]
      ScopedBackgroundService is working.
info: App.ScopedService.DefaultScopedProcessingService[0]
      DefaultScopedProcessingService working, execution count: 1
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: .\scoped-service
info: App.ScopedService.DefaultScopedProcessingService[0]
      DefaultScopedProcessingService working, execution count: 2
info: App.ScopedService.DefaultScopedProcessingService[0]
      DefaultScopedProcessingService working, execution count: 3
info: App.ScopedService.DefaultScopedProcessingService[0]
      DefaultScopedProcessingService working, execution count: 4
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
