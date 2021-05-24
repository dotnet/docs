---
title: Worker Services in .NET
description: Learn how to implement a custom IHostedService and use existing implementations with .NET.
author: IEvangelist
ms.author: dapine
ms.date: 05/24/2021
ms.topic: overview
---

# Worker Services in .NET

There are numerous reasons for creating long running services such as, processing CPU intensive data, queuing work items in the background, or performing a time-based operation on a schedule. Background service processing usually doesn't involve a user interface (UI), but UIs can be built around them. In the early days with .NET Framework, Windows developers could create Windows Services for these reasons. Now with .NET, you can use the <xref:Microsoft.Extensions.Hosting.BackgroundService> - which is an implementation of <xref:Microsoft.Extensions.Hosting.IHostedService>, or even implement your own.

With .NET, you're no longer restricted to Windows. You can develop background services that are cross-platform. Hosted services are logging, configuration, and dependency injection (DI) ready. They're a part of the extensions suite of libraries, meaning they're fundamental to all .NET workloads that work with the [generic host](generic-host.md).

## Terminology

There are many terms that are mistakenly used synonymously. In this section, there are definitions for some of these terms to make their intent more apparent.

- **Background Service**: Refers to the <xref:Microsoft.Extensions.Hosting.BackgroundService> type.
- **Hosted Service**: Implementations of <xref:Microsoft.Extensions.Hosting.IHostedService>, or referring to the <xref:Microsoft.Extensions.Hosting.IHostedService> itself.
- **Windows Service**: The *Windows Service*infrastructure, originally .NET Framework centric but now accessible via .NET.
- **Worker Service**: Refers to the *Worker Service* template.

## Worker Service template

The Worker Service template is available to the .NET CLI, and Visual Studio. For more information, see [.NET CLI, `dotnet new worker` - template](/dotnet/core/tools/dotnet-new#web-others). The template is rather simple, consisting of two primary components.

:::code language="csharp" source="snippets/workers/background-service/Program.cs":::

The preceding `Program` class:

- Creates the default <xref:Microsoft.Extensions.Hosting.IHostBuilder>.
- Calls <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureServices%2A> to add the `Worker` class as a hosted service with <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%2A>.
- Builds an <xref:Microsoft.Extensions.Hosting.IHost> from the builder.
- Calls `Run` on the `host` instance, which runs the app.

:::code language="csharp" source="snippets/workers/background-service/Worker.cs":::

The preceding `Worker` class ss a subclass of <xref:Microsoft.Extensions.Hosting.BackgroundService>, which implements <xref:Microsoft.Extensions.Hosting.IHostedService>. The <xref:Microsoft.Extensions.Hosting.BackgroundService> is an `abstract class` and requires the subclass to implement <xref:Microsoft.Extensions.Hosting.BackgroundService.ExecuteAsync(System.Threading.CancellationToken)?displayProperty=nameWithType>. The implementation of `ExecuteAsync` loops once per second, logging the current date and time until the process is signaled to cancel.

## Hosted Service extensibility

The <xref:Microsoft.Extensions.Hosting.IHostedService> interface defines two methods, <xref:Microsoft.Extensions.Hosting.IHostedService.StartAsync(System.Threading.CancellationToken)?displayProperty=nameWithType> and <xref:Microsoft.Extensions.Hosting.IHostedService.StopAsync(System.Threading.CancellationToken)?displayProperty=nameWithType>. These serve as lifecycle methods triggering start and stop respectively. The interface also serves as a generic-type parameter constraint on the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%60%601(Microsoft.Extensions.DependencyInjection.IServiceCollection)> extension method, meaning only implementations are permitted. You're free to use the provided <xref:Microsoft.Extensions.Hosting.BackgroundService> with subclasses, or implement your own entirely.

## See also

There are several related tutorials to consider:

- `BackgroundService` subclass tutorials:
  - Queue Service
  - Windows Service
  - Scoped Service
- Custom IHostedService implementation:
  - Timer Service
