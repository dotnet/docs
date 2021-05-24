---
title: Use scoped services within a BackgroundService in .NET
description: Learn how to use scoped services within a BackgroundService in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 05/24/2021
ms.topic: tutorial
---

# Use scoped services within a `BackgroundService` in .NET

When you register implementations of <xref:Microsoft.Extensions.Hosting.IHostedService> using any of the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%2A> extension methods - the service is registered as a singleton. There may be scenarios where you'd like to rely on scoped service. For more information, see [Dependency injection in .NET: Service lifetimes](dependency-injection.md#service-lifetimes).

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Resolve scoped dependencies in a singleton <xref:Microsoft.Extensions.Hosting.BackgroundService>.
> - Delegate work to a scoped service.
> - `override` the <xref:Microsoft.Extensions.Hosting.BackgroundService.StopAsync(System.Threading.CancellationToken)?displayProperty=nameWithType>.

## Prerequisites

- The [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- A .NET integrated development environment (IDE)
  - Feel free to use the [Visual Studio IDE](https://visualstudio.microsoft.com)

## Scoped service

To use [scoped services](dependency-injection.md#scoped) within a `BackgroundService`, create a scope. No scope is created for a hosted service by default. The scoped background service contains the background task's logic. In the following example:

- The service is asynchronous. The `DoWorkAsync` method returns a `Task`. For demonstration purposes, a delay of ten seconds is awaited in the `DoWorkAsync` method.
- An <xref:Microsoft.Extensions.Logging.ILogger> is injected into the service.

:::code source="snippets/workers/scoped-service/IScopedProcessingService.cs":::

The preceding interface defines a single `DoWorkAsync` method, the default implementation is defined as:

:::code source="snippets/workers/scoped-service/DefaultScopedProcessingService.cs":::

The hosted service creates a scope to resolve the scoped background service to call its `DoWorkAsync` method. `DoWorkAsync` returns a `Task`, which is awaited in `ExecuteAsync`:

:::code source="snippets/workers/scoped-service/ScopedBackgroundService.cs" highlight="33-39":::

In the preceding code, an explicit scope is created and the `IScopedProcessingService` implementation is resolved from the dependency injection service provider. The resolved service instance is scoped, and it's `DoWorkAsync` method is awaited.

The services are registered in `IHostBuilder.ConfigureServices` (*Program.cs*). The hosted service is registered with the `AddHostedService` extension method:

:::code source="snippets/workers/scoped-service/Program.cs" highlight="8-9":::

## See also

There are several related tutorials to consider:

- <xref:Microsoft.Extensions.Hosting.BackgroundService> subclass tutorials:
  - Queue Service
  - Scoped Service
  - Windows Service
- Custom <xref:Microsoft.Extensions.Hosting.IHostedService> implementation:
  - Timer Service
