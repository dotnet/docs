---
title: Implement the IHostedService interface in .NET
description: Learn how to implement a custom IHostedService interface with .NET.
author: IEvangelist
ms.author: dapine
ms.date: 05/25/2021
ms.topic: tutorial
---

# Implement the `IHostedService` interface in .NET

When you need finite control beyond the provided <xref:Microsoft.Extensions.Hosting.BackgroundService>, you can implement your own <xref:Microsoft.Extensions.Hosting.IHostedService>. The <xref:Microsoft.Extensions.Hosting.IHostedService> interface is the basis for all long running services in .NET. Custom implementations are registered with the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%60%601(Microsoft.Extensions.DependencyInjection.IServiceCollection)> extension method.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Implement the <xref:Microsoft.Extensions.Hosting.IHostedService>, and <xref:System.IAsyncDisposable> interfaces.
> - Create a timer-based service.
> - Register the custom implemenation with dependency injection and logging.

## Prerequisites

- The [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- A .NET integrated development environment (IDE)
  - Feel free to use [Visual Studio](https://visualstudio.microsoft.com)

## Timer service

The timer-based background service makes use of the <xref:System.Threading.Timer?displayProperty=fullName> class. The timer triggers the task's `DoWork` method. The timer is disabled on <xref:Microsoft.Extensions.Hosting.IHostLifetime.StopAsync(System.Threading.CancellationToken)?displayProperty=nameWithType> and disposed when the service container is disposed on <xref:System.IAsyncDisposable.DisposeAsync?displayProperty=fullName>:

:::code source="snippets/workers/timer-service/TimerService.cs" highlight="40,47-50":::

The `TimerService` implements both the <xref:Microsoft.Extensions.Hosting.IHostedService>, and <xref:System.IAsyncDisposable> interfaces.

> [!TIP]
> The <xref:System.Threading.Timer> doesn't wait for previous executions of `DoWork` to finish, so the approach shown might not be suitable for every scenario. <xref:System.Threading.Interlocked.Increment%2A?displayProperty=nameWithType> is used to increment the execution counter as an atomic operation, which ensures that multiple threads don't update `_executionCount` concurrently.

The service is registered in `IHostBuilder.ConfigureServices` (*Program.cs*) with the `AddHostedService` extension method:

:::code source="snippets/workers/timer-service/Program.cs" highlight="8":::

## See also

There are several related tutorials to consider:

- <xref:Microsoft.Extensions.Hosting.BackgroundService> subclass tutorials:
  - Queue Service
  - Scoped Service
  - Windows Service
- Custom <xref:Microsoft.Extensions.Hosting.IHostedService> implementation:
  - Timer Service
