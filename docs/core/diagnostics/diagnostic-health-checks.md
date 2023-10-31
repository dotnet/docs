---
title: App health checks in C#
description: Learn how to use resource utilization and application lifetime health checks in .NET app development.
ms.date: 10/30/2023
---

# .NET app health checks in C\#

In a distributed system, health checks are periodic assessments of the status, availability, and performance of individual nodes or services. These checks ensure that the system functions correctly and efficiently. Health checks are essential for system reliability, and they are typically performed at regular intervals with the results analyzed for decision-making and corrective actions.

The following heath check status results are possible:

- <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Healthy?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Degraded?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy?displayProperty=nameWithType>

## Resource utilization health checks

To perform health checks on the resource utilization of your .NET apps, add a package reference to [Microsoft.Extensions.Diagnostics.HealthChecks.ResourceUtilization](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks.ResourceUtilization). On an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection> instance, chain a call from <xref:Microsoft.Extensions.DependencyInjection.HealthCheckServiceCollectionExtensions.AddHealthChecks%2A> to <xref:Microsoft.Extensions.Diagnostics.HealthChecks.ResourceUtilizationHealthCheckExtensions.AddResourceUtilizationHealthCheck%2A>. The following example demonstrates how to use the `AddResourceUtilizationHealthCheck` extension method to add a resource utilization health check to an `IServiceCollection` instance:

:::code source="snippets/health-checks/Program.cs":::

The preceding code:

- Creates a new <xref:Microsoft.Extensions.Hosting.HostApplicationBuilder> instance.
- Adds resource monitoring by calling <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceMonitoringExtensions.AddResourceMonitoring%2A>.
- Adds a health check for resource utilization by chaining a call from the <xref:Microsoft.Extensions.DependencyInjection.HealthCheckServiceCollectionExtensions.AddHealthChecks%2A> call to the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.ResourceUtilizationHealthCheckExtensions.AddResourceUtilizationHealthCheck%2A> extension method.
- Builds the <xref:Microsoft.Extensions.Hosting.IHost> instance as the `app` variable.
- Gets an instance of the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckService> class from the service provider.
- Performs a health check and displays the result.
- Runs the application.

> [!NOTE]
> The `Microsoft.Extensions.Diagnostics.HealthChecks.ResourceUtilization` library assumes that the consumer will register the dependent call to <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceMonitoringExtensions.AddResourceMonitoring%2A>. If you don't register this, when resolving the `HealthCheckService` an exception is thrown.

## Application lifetime health checks

To perform health checks on the application lifetime events of <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime>, use the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.CommonHealthChecksExtensions.AddApplicationLifecycleHealthCheck%2A> extension method available in the [Microsoft.Extensions.Diagnostics.HealthChecks.Common](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks.Common) NuGet package.

This provider will indicate that the application is healthy only when it is fully active. Until the lifetime object indicates the application has started, the provider will report the application as not healthy. When the application starts shutting down, the provider will report the application as unhealthy.

The library exposes a <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckService> enabling consumers to request a health check at any time. Consider the following `ExampleService` implementation:

:::code source="snippets/lifetime-health-checks/ExampleLifecycle.cs":::

The preceding code:

- Defines a new `ExampleLifecycle` class that implements the <xref:Microsoft.Extensions.Hosting.IHostedService> interface.
- Defines a primary constructor accepting the following parameters:
  - An instance of the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckService> class.
  - An instance of the <xref:Microsoft.Extensions.Logging.ILogger%601> class.
- Implements the <xref:Microsoft.Extensions.Hosting.IHostedLifecycleService> interface, with each method invoking the `CheckHealthAsync` method.
- Defines a `ReadyAsync` method that invokes the `CheckHealthAsync` method.
- Defines a custom `CheckHealthAsync` method that captures the caller name and cancellation token, then requests a health check from the `HealthCheckService` instance. The `result` is then logged.

The only time that the health check service will report a status of <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Healthy?displayProperty=nameWithType> is after the app has started and before stopping is called. Please consider the following _Program.cs_:

:::code source="snippets/lifetime-health-checks/Program.cs":::

The preceding code:

- Creates a new <xref:Microsoft.Extensions.Hosting.HostApplicationBuilder> instance assigning to as the `builder` variable.
- Registers the `ExampleService` as the app's only <xref:Microsoft.Extensions.Hosting.IHostedService>.
- Adds a health check for the application lifetime events of <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime> by chaining a call from the <xref:Microsoft.Extensions.DependencyInjection.IHealthChecksBuilder> instance returned by the <xref:Microsoft.Extensions.DependencyInjection.HealthCheckServiceCollectionExtensions.AddHealthChecks%2A> call to the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.CommonHealthChecksExtensions.AddApplicationLifecycleHealthCheck%2A> extension method.
  - The `healthChecksBuilder` instance can be used to add more health checks.
- Builds the <xref:Microsoft.Extensions.Hosting.IHost> instance as the `app` variable.
- Gets an `IHostedService` from the service provider, this is the `ExampleService` instance.
- Calls <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType> given two task references:
  - The `DelayAndReportAsync` method, which delays for 500 milliseconds and then invokes the `ReadyAsync` method on the `ExampleService` instance, will evaluate the health check.
  - The <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.RunAsync(Microsoft.Extensions.Hosting.IHost,System.Threading.CancellationToken)> method, starts the `app`.

The app outputs logs in the following order, reporting the health check status as it relates to the lifecycle events:

1. `StartingAsync`: Unhealthy
1. `StartAsync`: Unhealthy
1. `StartedAsync`: Unhealthy
1. `ReadyAsync`: Healthy
1. `StoppingAsync`: Unhealthy
1. `StopAsync`: Unhealthy
1. `StoppedAsync`: Unhealthy

In other words, this provider ensures that the application instance only receives traffic when it's ready. If you're developing web apps with ASP.NET Core, there's health checks middleware available. For more information, [Health checks in ASP.NET Core](/aspnet/core/host-and-deploy/health-checks).
