---
title: .NET Aspire integration
description: Learn how to integrate Orleans with .NET Aspire for cloud-native development.
ms.date: 01/21/2026
ms.topic: how-to
zone_pivot_groups: orleans-version
---

# .NET Aspire integration

[!INCLUDE [orleans-version-note](../includes/orleans-version-note.md)]

:::zone target="docs" pivot="orleans-10-0,orleans-9-0,orleans-8-0"

[.NET Aspire](/dotnet/aspire/get-started/aspire-overview) provides a streamlined development experience for building distributed cloud-native applications. Orleans integrates with .NET Aspire through the `Aspire.Hosting.Orleans` package, which enables you to model Orleans resources in your AppHost and automatically configure silos and clients.

## Benefits of using Aspire with Orleans

- **Simplified configuration**: Aspire automatically injects connection strings and service discovery
- **Resource orchestration**: Define Orleans dependencies (Redis, Azure Storage, etc.) declaratively
- **Development experience**: Integrated dashboard, logging, and telemetry
- **Container support**: Easy local development with containerized dependencies
- **Production-ready patterns**: Built-in health checks, OpenTelemetry, and resilience

## Required NuGet packages

### AppHost project

In your Aspire AppHost project, add the following packages:

```xml
<ItemGroup>
  <PackageReference Include="Aspire.Hosting.AppHost" />
  <PackageReference Include="Aspire.Hosting.Orleans" />
  <PackageReference Include="Aspire.Hosting.Redis" />  <!-- For Redis clustering -->
</ItemGroup>
```

> [!TIP]
> Use the `Aspire.AppHost.Sdk` for simplified project configuration:
> ```xml
> <Project Sdk="Microsoft.NET.Sdk">
>   <Sdk Name="Aspire.AppHost.Sdk" Version="9.0.0" />
>   <PropertyGroup>
>     <IsAspireHost>true</IsAspireHost>
>   </PropertyGroup>
> </Project>
> ```

### Service projects (silos and clients)

In your Orleans silo and client projects, add the appropriate Aspire client integrations:

```xml
<ItemGroup>
  <PackageReference Include="Aspire.StackExchange.Redis" />  <!-- For Redis -->
  <PackageReference Include="Microsoft.Orleans.Server" />     <!-- For silos -->
  <!-- Or for client-only projects: -->
  <PackageReference Include="Microsoft.Orleans.Client" />
</ItemGroup>
```

## Configure Orleans in the AppHost

The AppHost project defines your distributed application's resources and their relationships. Use the `AddOrleans` extension method to create an Orleans resource.

### Basic configuration with Redis clustering

```csharp
using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// Add Redis for Orleans clustering
var redis = builder.AddRedis("orleans-redis");

// Add Orleans resource with Redis clustering
var orleans = builder.AddOrleans("cluster")
    .WithClustering(redis);

// Add your Orleans silo project
builder.AddProject<Projects.MySilo>("silo")
    .WithReference(orleans)
    .WaitFor(redis)
    .WithReplicas(3);

builder.Build().Run();
```

### Separate silo and client pattern

When you have separate silo (backend) and client (frontend) projects, use the `AsClient()` method to create a client-only reference:

```csharp
using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("orleans-redis");

var orleans = builder.AddOrleans("cluster")
    .WithClustering(redis);

// Backend silos - full Orleans participation
var backend = builder.AddProject<Projects.OrleansBackend>("backend")
    .WithReference(orleans)
    .WaitFor(redis)
    .WithReplicas(5);

// Frontend - Orleans client only
builder.AddProject<Projects.OrleansFrontend>("frontend")
    .WithReference(orleans.AsClient())
    .WaitFor(backend);

builder.Build().Run();
```

## Orleans AppHost extension methods

The `Aspire.Hosting.Orleans` package provides the following extension methods:

| Method | Description |
|--------|-------------|
| `AddOrleans(name)` | Adds an Orleans resource to the distributed application. |
| `WithClustering(resource)` | Configures clustering using the specified resource (e.g., Redis). |
| `WithGrainStorage(name, resource)` | Configures a named grain storage provider using the specified resource. |
| `WithReminders(resource)` | Configures the reminders provider using the specified resource. |
| `WithGrainDirectory(name, resource)` | Configures a named grain directory using the specified resource. |
| `AsClient()` | Returns a client-only reference to the Orleans resource. |

### Complete configuration example

```csharp
var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("orleans-redis");

var orleans = builder.AddOrleans("cluster")
    .WithClustering(redis)
    .WithGrainStorage("default", redis)
    .WithGrainStorage("archive", redis)
    .WithReminders(redis)
    .WithGrainDirectory("default", redis);

builder.AddProject<Projects.MySilo>("silo")
    .WithReference(orleans)
    .WaitFor(redis);

builder.Build().Run();
```

## Configure Orleans in service projects

### Silo configuration

In your Orleans silo project, use the standard Orleans configuration pattern. Aspire automatically injects connection strings through configuration:

```csharp
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Add the Aspire Redis client integration
builder.AddKeyedRedisClient("orleans-redis");

// Configure Orleans - it will pick up configuration from Aspire
builder.UseOrleans();

var host = builder.Build();
await host.RunAsync();
```

### Client configuration

For Orleans client-only projects:

```csharp
using Microsoft.Extensions.Hosting;
using Orleans.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add the Aspire Redis client integration
builder.AddKeyedRedisClient("orleans-redis");

// Configure Orleans client
builder.UseOrleansClient();

var app = builder.Build();
// ... configure web application
await app.RunAsync();
```

## Configuration-based provider selection

Aspire injects connection strings that Orleans can consume through the configuration system. Configure your providers using `appsettings.json`:

```json
{
  "Orleans": {
    "ClusterId": "my-cluster",
    "ServiceId": "my-service",
    "Clustering": {
      "ProviderType": "Redis",
      "ServiceKey": "orleans-redis"
    },
    "GrainStorage": {
      "default": {
        "ProviderType": "Redis",
        "ServiceKey": "orleans-redis"
      }
    },
    "Reminders": {
      "ProviderType": "Redis",
      "ServiceKey": "orleans-redis"
    }
  }
}
```

## Add ServiceDefaults for observability

Create a shared `ServiceDefaults` project to configure OpenTelemetry, health checks, and service discovery:

```csharp
public static class Extensions
{
    public static IHostApplicationBuilder AddServiceDefaults(
        this IHostApplicationBuilder builder)
    {
        builder.ConfigureOpenTelemetry();
        builder.AddDefaultHealthChecks();
        builder.Services.AddServiceDiscovery();
        
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
            });

        return builder;
    }

    public static IHostApplicationBuilder AddDefaultHealthChecks(
        this IHostApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);

        return builder;
    }
}
```

Use the service defaults in your silo project:

```csharp
var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();  // Add OpenTelemetry and health checks
builder.AddKeyedRedisClient("orleans-redis");
builder.UseOrleans();

var host = builder.Build();
await host.RunAsync();
```

## Use Azure Storage with Aspire

When using Azure Storage for clustering, persistence, or reminders, configure managed identity authentication:

### AppHost configuration

```csharp
var builder = DistributedApplication.CreateBuilder(args);

var storage = builder.AddAzureStorage("storage")
    .RunAsEmulator();  // Use Azurite for local development

var tables = storage.AddTables("tables");
var blobs = storage.AddBlobs("blobs");

builder.AddProject<Projects.MySilo>("silo")
    .WithReference(tables)
    .WithReference(blobs);

builder.Build().Run();
```

### Silo configuration

```csharp
var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

// Orleans configuration uses Aspire-injected endpoints
builder.UseOrleans(siloBuilder =>
{
    var tableEndpoint = builder.Configuration["ConnectionStrings:tables"];
    var blobEndpoint = builder.Configuration["ConnectionStrings:blobs"];
    
    if (!string.IsNullOrEmpty(tableEndpoint))
    {
        siloBuilder.UseAzureStorageClustering(options =>
        {
            options.ConfigureTableServiceClient(
                new Uri(tableEndpoint), 
                new DefaultAzureCredential());
        });
    }
});

await builder.Build().RunAsync();
```

## Complete example: Orleans with Aspire

Here's a complete example showing an Orleans application with Aspire:

### AppHost/Program.cs

```csharp
using Aspire.Hosting;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("orleans-redis");

var orleans = builder.AddOrleans("cluster")
    .WithClustering(redis)
    .WithGrainStorage("default", redis);

var silo = builder.AddProject<OrleansServer>("silo")
    .WithReference(orleans)
    .WaitFor(redis)
    .WithReplicas(3);

builder.AddProject<OrleansWebFrontend>("frontend")
    .WithReference(orleans.AsClient())
    .WaitFor(silo);

builder.Build().Run();
```

### OrleansServer/Program.cs

```csharp
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.AddKeyedRedisClient("orleans-redis");
builder.UseOrleans();

await builder.Build().RunAsync();
```

### OrleansWebFrontend/Program.cs

```csharp
using Orleans.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddKeyedRedisClient("orleans-redis");
builder.UseOrleansClient();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();
```

## See also

- [.NET Aspire overview](/dotnet/aspire/get-started/aspire-overview)
- [Server configuration](../host/configuration-guide/server-configuration.md)
- [Client configuration](../host/configuration-guide/client-configuration.md)
- [Kubernetes hosting](kubernetes.md)
- [Azure Container Apps deployment](deploy-to-azure-container-apps.md)

:::zone-end

:::zone target="docs" pivot="orleans-7-0"

.NET Aspire integration was introduced in Orleans 8.0. To use Aspire with Orleans, upgrade to Orleans 8.0 or later.

> [!TIP]
> For Orleans 7.0 deployments, consider using:
> - [Kubernetes hosting](kubernetes.md) for container orchestration
> - [Azure Container Apps](deploy-to-azure-container-apps.md) for serverless container hosting
> - [Azure App Service](deploy-to-azure-app-service.md) for PaaS deployments

For information about upgrading to Orleans 8.0 or later, see the [migration guide](../migration-guide.md).

:::zone-end

:::zone target="docs" pivot="orleans-3-x"

.NET Aspire integration requires Orleans 8.0 or later. Orleans 3.x is no longer supported.

For information about upgrading to a supported Orleans version, see the [migration guide](../migration-guide.md).

:::zone-end
