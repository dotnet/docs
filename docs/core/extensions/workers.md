---
title: Worker Services in .NET
description: Learn how to implement a custom IHostedService and use existing implementations with .NET.
author: IEvangelist
ms.author: dapine
ms.date: 12/13/2021
ms.topic: overview
---

# Worker Services in .NET

There are numerous reasons for creating long-running services such as:

- Processing CPU intensive data.
- Queuing work items in the background.
- Performing a time-based operation on a schedule.

Background service processing usually doesn't involve a user interface (UI), but UIs can be built around them. In the early days with .NET Framework, Windows developers could create Windows Services for these reasons. Now with .NET, you can use the <xref:Microsoft.Extensions.Hosting.BackgroundService> &mdash; which is an implementation of <xref:Microsoft.Extensions.Hosting.IHostedService>, or implement your own.

With .NET, you're no longer restricted to Windows. You can develop cross-platform background services. Hosted services are logging, configuration, and dependency injection (DI) ready. They're a part of the extensions suite of libraries, meaning they're fundamental to all .NET workloads that work with the [generic host](generic-host.md).

## Terminology

Many terms are mistakenly used synonymously. In this section, there are definitions for some of these terms to make their intent more apparent.

- **Background Service**: Refers to the <xref:Microsoft.Extensions.Hosting.BackgroundService> type.
- **Hosted Service**: Implementations of <xref:Microsoft.Extensions.Hosting.IHostedService>, or referring to the <xref:Microsoft.Extensions.Hosting.IHostedService> itself.
- **Long-running Service:** Any service that runs continuously.
- **Windows Service**: The *Windows Service* infrastructure, originally .NET Framework centric but now accessible via .NET.
- **Worker Service**: Refers to the *Worker Service* template.

## Worker Service template

The Worker Service template is available to the .NET CLI, and Visual Studio. For more information, see [.NET CLI, `dotnet new worker` - template](../tools/dotnet-new-sdk-templates.md#web-others). The template consists of a `Program` and `Worker` class.

:::code language="csharp" source="snippets/workers/background-service/Program.cs":::

The preceding `Program` class:

- Creates the default <xref:Microsoft.Extensions.Hosting.IHostBuilder>.
- Calls <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureServices%2A> to add the `Worker` class as a hosted service with <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%2A>.
- Builds an <xref:Microsoft.Extensions.Hosting.IHost> from the builder.
- Calls `Run` on the `host` instance, which runs the app.

The *Program.cs* file from the template can be rewritten using top-level statements:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using App.WorkerService;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
```

This is functionally equivalent to the original template. For more information on C# 9 features, see [What's new in C# 9.0](../../csharp/whats-new/csharp-9.md).

As for the `Worker`, the template provides a simple implementation.

:::code language="csharp" source="snippets/workers/background-service/Worker.cs":::

The preceding `Worker` class is a subclass of <xref:Microsoft.Extensions.Hosting.BackgroundService>, which implements <xref:Microsoft.Extensions.Hosting.IHostedService>. The <xref:Microsoft.Extensions.Hosting.BackgroundService> is an `abstract class` and requires the subclass to implement <xref:Microsoft.Extensions.Hosting.BackgroundService.ExecuteAsync(System.Threading.CancellationToken)?displayProperty=nameWithType>. In the template implementation the `ExecuteAsync` loops once per second, logging the current date and time until the process is signaled to cancel.

### The project file

The Worker Service template relies on the following project file `Sdk`:

```xml
<Project Sdk="Microsoft.NET.Sdk.Worker">
```

For more information, see [.NET project SDKs](../project-sdk/overview.md).

### NuGet package

An app based on the Worker Service template uses the `Microsoft.NET.Sdk.Worker` SDK and has an explicit package reference to the [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) package.

### Containers and cloud adoptability

With most modern .NET workloads, containers are a viable option. When creating a long-running service from the Worker Service template in Visual Studio, you can opt-in to **Docker support**. Doing so will create a *Dockerfile* that will containerize your .NET app. A [*Dockerfile*](https://docs.docker.com/engine/reference/builder) is a set of instructions to build an image. For .NET apps, the *Dockerfile* usually sits in the root of the directory next to a solution file.

:::code language="dockerfile" source="snippets/workers/background-service/Dockerfile":::

The preceding *Dockerfile* steps include:

- Setting the base image from `mcr.microsoft.com/dotnet/runtime:6.0` as the alias `base`.
- Changing the working directory to */app*.
- Setting the `build` alias from the `mcr.microsoft.com/dotnet/sdk:6.0` image.
- Changing the working directory to */src*.
- Copying the contents and publishing the .NET app:
  - The app is published using the [`dotnet publish`](../tools/dotnet-publish.md) command.
- Relayering the .NET SDK image from `mcr.microsoft.com/dotnet/runtime:6.0` (the `base` alias).
- Copying the published build output from the */publish*.
- Defining the entry point, which delegates to [`dotnet App.BackgroundService.dll`](../tools/dotnet.md).

> [!TIP]
> The MCR in `mcr.microsoft.com` stands for "Microsoft Container Registry", and is Microsoft's syndicated container catalog from the official Docker hub. The [Microsoft syndicates container catalog](https://azure.microsoft.com/blog/microsoft-syndicates-container-catalog) article contains additional details.

When targeting Docker as a deployment strategy for your .NET Worker Service, there are a few considerations in the project file:

:::code language="xml" source="snippets/workers/background-service/App.WorkerService.csproj" highlight="8,13":::

In the preceding project file, the `<DockerDefaultTargetOS>` element specifies `Linux` as its target. To target Windows containers, use `Windows` instead. The [`Microsoft.VisualStudio.Azure.Containers.Tools.Targets` NuGet package](https://www.nuget.org/packages/Microsoft.VisualStudio.Azure.Containers.Tools.Targets) is automatically added as a package reference when **Docker support** is selected from the template.

For more information on Docker with .NET, see [Tutorial: Containerize a .NET app](../docker/build-container.md). For more information on deploying to Azure, see [Tutorial: Deploy a Worker Service to Azure](cloud-service.md).

> [!IMPORTANT]
> If you want to leverage _User Secrets_ with the Worker Service template, you'd have to explicitly reference the `Microsoft.Extensions.Configuration.UserSecrets` NuGet package.

## Hosted Service extensibility

The <xref:Microsoft.Extensions.Hosting.IHostedService> interface defines two methods:

- <xref:Microsoft.Extensions.Hosting.IHostedService.StartAsync(System.Threading.CancellationToken)?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Hosting.IHostedService.StopAsync(System.Threading.CancellationToken)?displayProperty=nameWithType>

These two methods serve as *lifecycle* methods - they're called during host start and stop events respectively.

> [!NOTE]
> When overriding either <xref:Microsoft.Extensions.Hosting.BackgroundService.StartAsync%2A> or <xref:Microsoft.Extensions.Hosting.BackgroundService.StopAsync%2A> methods, you must call and `await` the `base` class method to ensure the service starts and/or shuts down properly.

> [!IMPORTANT]
> The interface serves as a generic-type parameter constraint on the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService%60%601(Microsoft.Extensions.DependencyInjection.IServiceCollection)> extension method, meaning only implementations are permitted. You're free to use the provided <xref:Microsoft.Extensions.Hosting.BackgroundService> with a subclass, or implement your own entirely.

## See also

- <xref:Microsoft.Extensions.Hosting.BackgroundService> subclass tutorials:
  - [Create a Queue Service in .NET](queue-service.md)
  - [Use scoped services within a `BackgroundService` in .NET](scoped-service.md)
  - [Create a Windows Service using `BackgroundService` in .NET](windows-service.md)
- Custom <xref:Microsoft.Extensions.Hosting.IHostedService> implementation:
  - [Implement the `IHostedService` interface in .NET](timer-service.md)
