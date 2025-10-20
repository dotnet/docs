---
title: Dependency injection auto-activation
description: Learn how to use auto-activation for singleton services in .NET to ensure services are instantiated at startup rather than on first use.
author: IEvangelist
ms.author: dapine
ms.date: 10/20/2025
ms.topic: concept-article
ai-usage: ai-assisted
---

# Dependency injection auto-activation

The [`Microsoft.Extensions.DependencyInjection.AutoActivation`](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.AutoActivation) NuGet package provides functionality to automatically activate singleton services at application startup, rather than waiting for their first use. This approach can help minimize latency for initial requests by ensuring services are ready to handle requests immediately when the application starts.

## When to use auto-activation

Auto-activation is beneficial in scenarios where:

- You want to minimize the latency of the first request by avoiding the overhead of lazy initialization.
- Services need to perform initialization work at startup, such as warming up caches or establishing connections.
- You want consistent response times from the start of your application's lifetime.
- Services have expensive constructors that you want to execute during startup rather than during request processing.

## Get started

To get started with auto-activation, install the [`Microsoft.Extensions.DependencyInjection.AutoActivation`](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.AutoActivation) NuGet package.

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.DependencyInjection.AutoActivation
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.DependencyInjection.AutoActivation" Version="9.8.0" />
```

---

For more information, see [dotnet add package](../tools/dotnet-add-package.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## Register services for auto-activation

The auto-activation package provides extension methods to register services that are automatically activated when the service provider is built. There are several ways to register services for auto-activation:

### AddActivatedSingleton

The <xref:Microsoft.Extensions.DependencyInjection.AutoActivationExtensions.AddActivatedSingleton%2A> method registers a service as a singleton and ensures it's activated at startup:

```csharp
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddActivatedSingleton<MyService>();

var provider = services.BuildServiceProvider();

// MyService is already instantiated at this point
```

In this example, `MyService` is instantiated when `BuildServiceProvider()` is called, not when it's first requested from the service provider.

### ActivateSingleton

The <xref:Microsoft.Extensions.DependencyInjection.AutoActivationExtensions.ActivateSingleton%2A> method marks an already-registered singleton service for activation at startup:

```csharp
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<MyService>();
services.ActivateSingleton<MyService>();

var provider = services.BuildServiceProvider();

// MyService is already instantiated at this point
```

This approach is useful when you have existing service registrations that you want to activate at startup without changing the registration code.

### TryAddActivatedSingleton

The <xref:Microsoft.Extensions.DependencyInjection.AutoActivationExtensions.TryAddActivatedSingleton%2A> method conditionally registers a service for auto-activation only if it hasn't been registered already:

```csharp
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.TryAddActivatedSingleton<MyService>();
services.TryAddActivatedSingleton<MyService>(); // This has no effect

var provider = services.BuildServiceProvider();
```

This method follows the same pattern as other `TryAdd*` methods in the dependency injection framework, ensuring services are only registered once.

## Complete example

Here's a complete example showing how to use auto-activation in a console application:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Register service with auto-activation
builder.Services.AddActivatedSingleton<CacheWarmer>();

var host = builder.Build();

// CacheWarmer is already instantiated and initialized at this point
await host.RunAsync();

public class CacheWarmer
{
    public CacheWarmer()
    {
        Console.WriteLine("Warming up cache at startup...");
        // Perform expensive initialization
        WarmUpCache();
    }

    private void WarmUpCache()
    {
        // Cache warming logic here
        Console.WriteLine("Cache warmed up successfully!");
    }
}
```

When this application starts, you'll see the messages from the `CacheWarmer` constructor printed before the application begins processing requests, confirming that the service was activated at startup.

## Auto-activation with dependencies

Auto-activated services can depend on other services through dependency injection:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();

services.AddLogging();
services.AddActivatedSingleton<StartupTaskRunner>();

var provider = services.BuildServiceProvider();

public class StartupTaskRunner
{
    private readonly ILogger<StartupTaskRunner> _logger;

    public StartupTaskRunner(ILogger<StartupTaskRunner> logger)
    {
        _logger = logger;
        _logger.LogInformation("Running startup tasks...");
        RunTasks();
    }

    private void RunTasks()
    {
        // Execute startup tasks
        _logger.LogInformation("Startup tasks completed.");
    }
}
```

In this example, the `StartupTaskRunner` service depends on `ILogger<StartupTaskRunner>`, which is automatically provided by the dependency injection container.

## Best practices

When using auto-activation, consider the following best practices:

- **Use for singletons only**: Auto-activation is designed for singleton services. Services with shorter lifetimes (scoped or transient) should not be auto-activated.
- **Keep startup fast**: Auto-activated services should complete their initialization quickly to avoid delaying application startup. For longer-running initialization, consider using background services or hosted services.
- **Handle errors gracefully**: Exceptions thrown during the construction of auto-activated services will prevent the application from starting. Ensure robust error handling in service constructors.
- **Consider hosted services**: For services that need to perform ongoing work or asynchronous initialization, consider using <xref:Microsoft.Extensions.Hosting.IHostedService> instead of auto-activation.

## See also

- [Dependency injection in .NET](dependency-injection.md)
- [Dependency injection guidelines](dependency-injection-guidelines.md)
- [Worker Services in .NET](workers.md)
