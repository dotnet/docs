---
title: Orleans and .NET Aspire integration
description: Learn how to integrate Orleans with .NET Aspire for cloud-native development.
ms.date: 01/21/2026
ms.topic: conceptual
zone_pivot_groups: orleans-version
---

# Orleans and .NET Aspire integration

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-8-0,orleans-9-0,orleans-10-0"
<!-- markdownlint-enable MD044 -->

[.NET Aspire](/dotnet/aspire/get-started/aspire-overview) provides a streamlined approach to building cloud-native applications with built-in support for Orleans. Starting with Orleans 8.0, you can use Aspire to orchestrate your Orleans cluster, manage backing resources (like Redis or Azure Storage), and automatically configure service discovery, observability, and health checks.

## Overview

Orleans integration with .NET Aspire uses the `Aspire.Hosting.Orleans` package in your AppHost project. This package provides extension methods to:

- Define Orleans as a distributed resource
- Configure clustering providers (Redis, Azure Storage, ADO.NET)
- Configure grain storage providers
- Configure reminder providers
- Configure grain directory providers
- Model silo and client relationships

## Prerequisites

Before using Orleans with Aspire, ensure you have:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [.NET Aspire workload](/dotnet/aspire/fundamentals/setup-tooling)
- An IDE with Aspire support (Visual Studio 2022 17.9+, VS Code with C# Dev Kit, or JetBrains Rider)

## Required packages

Your solution needs the following package references:

### AppHost project

```xml
<ItemGroup>
  <PackageReference Include="Aspire.Hosting.AppHost" Version="9.0.0" />
  <PackageReference Include="Aspire.Hosting.Orleans" Version="9.0.0" />
  <PackageReference Include="Aspire.Hosting.Redis" Version="9.0.0" />
</ItemGroup>
```

### Orleans silo project

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Orleans.Server" Version="10.0.0" />
  <PackageReference Include="Microsoft.Orleans.Clustering.Redis" Version="10.0.0" />
  <PackageReference Include="Aspire.StackExchange.Redis" Version="9.0.0" />
</ItemGroup>
```

### Orleans client project (if separate from silo)

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Orleans.Client" Version="10.0.0" />
  <PackageReference Include="Microsoft.Orleans.Clustering.Redis" Version="10.0.0" />
  <PackageReference Include="Aspire.StackExchange.Redis" Version="9.0.0" />
</ItemGroup>
```

## Configure the AppHost

The AppHost project orchestrates your Orleans cluster and its dependencies.

### Basic Orleans cluster with Redis clustering

```csharp
using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// Add Redis for Orleans clustering
var redis = builder.AddRedis("orleans-redis");

// Define the Orleans resource with Redis clustering
var orleans = builder.AddOrleans("cluster")
    .WithClustering(redis);

// Add the Orleans silo project
builder.AddProject<Projects.MyOrleansSilo>("silo")
    .WithReference(orleans)
    .WaitFor(redis)
    .WithReplicas(3);

builder.Build().Run();
```

### Orleans with grain storage and reminders

```csharp
using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("orleans-redis");

var orleans = builder.AddOrleans("cluster")
    .WithClustering(redis)
    .WithGrainStorage("Default", redis)
    .WithGrainStorage("PubSubStore", redis)
    .WithReminders(redis);

builder.AddProject<Projects.MyOrleansSilo>("silo")
    .WithReference(orleans)
    .WaitFor(redis)
    .WithReplicas(3);

builder.Build().Run();
```

### Separate silo and client projects

When your Orleans client runs in a separate process (such as a web frontend), use the `.AsClient()` method:

```csharp
using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("orleans-redis");

var orleans = builder.AddOrleans("cluster")
    .WithClustering(redis)
    .WithGrainStorage("Default", redis);

// Backend Orleans silo cluster
var silo = builder.AddProject<Projects.OrleansBackend>("backend")
    .WithReference(orleans)
    .WaitFor(redis)
    .WithReplicas(5);

// Frontend web project as Orleans client
builder.AddProject<Projects.WebFrontend>("frontend")
    .WithReference(orleans.AsClient())  // Client-only reference
    .WaitFor(silo);

builder.Build().Run();
```

## Configure the Orleans silo project

In your Orleans silo project, configure Orleans to use the Aspire-provided resources:

```csharp
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Add Aspire service defaults (OpenTelemetry, health checks, etc.)
builder.AddServiceDefaults();

// Add the Aspire Redis client for Orleans
builder.AddKeyedRedisClient("orleans-redis");

builder.UseOrleans(siloBuilder =>
{
    // Orleans will automatically use Redis clustering
    // based on the Aspire configuration injection
});

builder.Build().Run();
```

### Configure with explicit connection string

If you need explicit control over the connection string, you can read it from configuration:

```csharp
builder.UseOrleans(siloBuilder =>
{
    var redisConnectionString = builder.Configuration.GetConnectionString("orleans-redis");
    
    siloBuilder.UseRedisClustering(options =>
    {
        options.ConfigurationOptions = 
            StackExchange.Redis.ConfigurationOptions.Parse(redisConnectionString!);
    });
    
    siloBuilder.AddRedisGrainStorageAsDefault(options =>
    {
        options.ConfigurationOptions = 
            StackExchange.Redis.ConfigurationOptions.Parse(redisConnectionString!);
    });
});
```

## Configure the Orleans client project

For separate client projects, configure the Orleans client similarly:

```csharp
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.AddKeyedRedisClient("orleans-redis");

builder.UseOrleansClient(clientBuilder =>
{
    var redisConnectionString = builder.Configuration.GetConnectionString("orleans-redis");
    
    clientBuilder.UseRedisClustering(options =>
    {
        options.ConfigurationOptions = 
            StackExchange.Redis.ConfigurationOptions.Parse(redisConnectionString!);
    });
});

builder.Build().Run();
```

## AppHost extension methods reference

The `Aspire.Hosting.Orleans` package provides these extension methods:

| Method | Description |
|--------|-------------|
| `builder.AddOrleans(name)` | Adds an Orleans resource to the distributed application with the specified name. |
| `.WithClustering(resource)` | Configures Orleans clustering to use the specified resource (Redis, Azure Storage, etc.). |
| `.WithGrainStorage(name, resource)` | Configures a named grain storage provider using the specified resource. |
| `.WithReminders(resource)` | Configures the Orleans reminder service using the specified resource. |
| `.WithGrainDirectory(name, resource)` | Configures a named grain directory using the specified resource. |
| `.AsClient()` | Returns a client-only reference to the Orleans resource (doesn't include silo capabilities). |
| `project.WithReference(orleans)` | Adds the Orleans resource reference to a project, enabling configuration injection. |

## Service defaults pattern

Aspire uses a ServiceDefaults project pattern to share common configuration across all projects. For Orleans, this typically includes:

### OpenTelemetry configuration

```csharp
// In ServiceDefaults/Extensions.cs
public static IHostApplicationBuilder AddServiceDefaults(
    this IHostApplicationBuilder builder)
{
    builder.ConfigureOpenTelemetry();
    builder.AddDefaultHealthChecks();
    
    return builder;
}

public static IHostApplicationBuilder ConfigureOpenTelemetry(
    this IHostApplicationBuilder builder)
{
    builder.Logging.AddOpenTelemetry(logging =>
    {
        logging.IncludeFormattedMessage = true;
        logging.IncludeScopes = true;
    });

    builder.Services.AddOpenTelemetry()
        .WithMetrics(metrics =>
        {
            metrics.AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddRuntimeInstrumentation()
                .AddMeter("Microsoft.Orleans");  // Orleans metrics
        })
        .WithTracing(tracing =>
        {
            tracing.AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddSource("Microsoft.Orleans.Runtime")
                .AddSource("Microsoft.Orleans.Application");
        });

    return builder;
}
```

## Azure Storage with Aspire

You can use Azure Storage resources for Orleans clustering and persistence:

```csharp
using Aspire.Hosting;
using Aspire.Hosting.Azure;

var builder = DistributedApplication.CreateBuilder(args);

// Add Azure Storage for Orleans
var storage = builder.AddAzureStorage("orleans-storage")
    .RunAsEmulator();  // Use Azurite emulator for local development

var tables = storage.AddTables("orleans-tables");
var blobs = storage.AddBlobs("orleans-blobs");

var orleans = builder.AddOrleans("cluster")
    .WithClustering(tables)
    .WithGrainStorage("Default", blobs)
    .WithReminders(tables);

builder.AddProject<Projects.MyOrleansSilo>("silo")
    .WithReference(orleans)
    .WithReference(tables)
    .WithReference(blobs)
    .WithReplicas(3);

builder.Build().Run();
```

## Development vs. production configuration

Aspire makes it easy to switch between development and production configurations:

### Local development (using emulators)

```csharp
var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("orleans-redis");
// Redis container runs automatically during development

var orleans = builder.AddOrleans("cluster")
    .WithClustering(redis);

// ...
```

### Production (using managed services)

```csharp
var builder = DistributedApplication.CreateBuilder(args);

// Use existing Azure Cache for Redis
var redis = builder.AddConnectionString("orleans-redis");

var orleans = builder.AddOrleans("cluster")
    .WithClustering(redis);

// ...
```

## Health checks

Aspire automatically configures health check endpoints. You can add Orleans-specific health checks:

```csharp
builder.Services.AddHealthChecks()
    .AddCheck<GrainHealthCheck>("orleans-grains")
    .AddCheck<SiloHealthCheck>("orleans-silo");
```

## Best practices

1. **Use ServiceDefaults**: Share common configuration (OpenTelemetry, health checks) across all projects using a ServiceDefaults project.

2. **Wait for dependencies**: Always use `.WaitFor()` to ensure backing resources (Redis, databases) are ready before Orleans silos start.

3. **Configure replicas**: Use `.WithReplicas()` to run multiple silo instances for fault tolerance and scalability.

4. **Separate client projects**: For web frontends, use `.AsClient()` to configure Orleans client-only mode.

5. **Use emulators for development**: Aspire can run Redis, Azure Storage (Azurite), and other dependencies locally using containers.

6. **Enable distributed tracing**: Configure OpenTelemetry with Orleans source names to trace grain calls across the cluster.

## See also

- [.NET Aspire overview](/dotnet/aspire/get-started/aspire-overview)
- [.NET Aspire setup and tooling](/dotnet/aspire/fundamentals/setup-tooling)
- [Orleans configuration guide](configuration-guide/index.md)
- [Orleans Redis providers](../grains/grain-persistence/index.md#redis-grain-persistence)
- [Orleans Azure Storage providers](../grains/grain-persistence/azure-storage.md)

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

.NET Aspire integration was introduced in Orleans 8.0. For Orleans 7.0, you can still deploy to Aspire-orchestrated environments, but the dedicated `Aspire.Hosting.Orleans` package and its extension methods are not available.

Consider upgrading to Orleans 8.0 or later to take advantage of the Aspire integration features.

:::zone-end

:::zone target="docs" pivot="Orleans-3-x"

.NET Aspire integration is available in Orleans 8.0 and later. Orleans 3.x does not support .NET Aspire.

:::zone-end
