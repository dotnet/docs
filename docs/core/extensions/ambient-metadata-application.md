---
title: Application ambient metadata
description: Learn how to capture and flow application metadata for telemetry enrichment using Microsoft.Extensions.AmbientMetadata.Application in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 10/20/2025
ms.topic: concept-article
ai-usage: ai-assisted
---

# Application ambient metadata

The [`Microsoft.Extensions.AmbientMetadata.Application`](https://www.nuget.org/packages/Microsoft.Extensions.AmbientMetadata.Application) NuGet package provides functionality to capture and flow application-level ambient metadata throughout your application. This metadata includes information such as the application name, version, deployment environment, and deployment ring, which is valuable for enriching telemetry, troubleshooting, and analysis.

## Why use application metadata

Application metadata provides essential context about your running application that can enhance observability:

- **Telemetry enrichment**: Automatically add application details to logs, metrics, and traces.
- **Troubleshooting**: Quickly identify which version of your application is experiencing issues.
- **Environment identification**: Distinguish between Development, Staging, and Production environments in your telemetry.
- **Deployment tracking**: Track issues across different deployment rings or regions.
- **Consistent metadata**: Ensure all components in your application use the same metadata values.

## Get started

To get started with application metadata, install the [`Microsoft.Extensions.AmbientMetadata.Application`](https://www.nuget.org/packages/Microsoft.Extensions.AmbientMetadata.Application) NuGet package.

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.AmbientMetadata.Application
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.AmbientMetadata.Application" Version="9.10.0" />
```

---

For more information, see [dotnet add package](../tools/dotnet-add-package.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## Configure application metadata

Application metadata can be configured through your application's configuration system. The package looks for metadata under the `ambientmetadata:application` configuration section by default.

### Configure with appsettings.json

Add the application metadata to your `appsettings.json` file:

```json
{
  "ambientmetadata": {
    "application": {
      "ApplicationName": "MyWebApi",
      "BuildVersion": "1.0.0",
      "DeploymentRing": "Production",
      "EnvironmentName": "Production"
    }
  }
}
```

### Configure with IHostBuilder

Use the <xref:Microsoft.Extensions.Hosting.ApplicationMetadataHostBuilderExtensions.UseApplicationMetadata%2A> extension method to register application metadata:

```csharp
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.UseApplicationMetadata();

var host = builder.Build();

await host.RunAsync();
```

### Configure with IHostApplicationBuilder

For applications using <xref:Microsoft.Extensions.Hosting.IHostApplicationBuilder>, such as ASP.NET Core applications:

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.UseApplicationMetadata();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
```

## Access application metadata

Once configured, you can inject and use the <xref:Microsoft.Extensions.AmbientMetadata.ApplicationMetadata> type:

```csharp
using Microsoft.Extensions.AmbientMetadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.UseApplicationMetadata();
builder.Services.AddSingleton<MetadataService>();

var host = builder.Build();

var metadataService = host.Services.GetRequiredService<MetadataService>();
metadataService.DisplayMetadata();

public class MetadataService
{
    private readonly ApplicationMetadata _metadata;

    public MetadataService(ApplicationMetadata metadata)
    {
        _metadata = metadata;
    }

    public void DisplayMetadata()
    {
        Console.WriteLine($"Application: {_metadata.ApplicationName}");
        Console.WriteLine($"Version: {_metadata.BuildVersion}");
        Console.WriteLine($"Environment: {_metadata.EnvironmentName}");
        Console.WriteLine($"Deployment Ring: {_metadata.DeploymentRing}");
    }
}
```

## ApplicationMetadata properties

The <xref:Microsoft.Extensions.AmbientMetadata.ApplicationMetadata> class includes the following properties:

| Property | Description |
|----------|-------------|
| `ApplicationName` | The name of the application. |
| `BuildVersion` | The version of the application build. |
| `DeploymentRing` | The deployment ring or stage (for example, Canary, Production). |
| `EnvironmentName` | The environment where the application is running (for example, Development, Staging, Production). |

## Use with logging

Application metadata is particularly useful for enriching log messages:

```csharp
using Microsoft.Extensions.AmbientMetadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);

builder.UseApplicationMetadata();
builder.Services.AddSingleton<LoggingService>();

var host = builder.Build();

var loggingService = host.Services.GetRequiredService<LoggingService>();
loggingService.LogWithMetadata();

public class LoggingService
{
    private readonly ILogger<LoggingService> _logger;
    private readonly ApplicationMetadata _metadata;

    public LoggingService(ILogger<LoggingService> logger, ApplicationMetadata metadata)
    {
        _logger = logger;
        _metadata = metadata;
    }

    public void LogWithMetadata()
    {
        _logger.LogInformation(
            "Processing request in {ApplicationName} v{Version} ({Environment})",
            _metadata.ApplicationName,
            _metadata.BuildVersion,
            _metadata.EnvironmentName);
    }
}
```

## Custom configuration section

If you prefer to use a different configuration section name, specify it when calling `UseApplicationMetadata`:

```csharp
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Use custom configuration section
builder.UseApplicationMetadata("myapp:metadata");

var host = builder.Build();

await host.RunAsync();
```

With this configuration, your settings would look like:

```json
{
  "myapp": {
    "metadata": {
      "ApplicationName": "MyWebApi",
      "BuildVersion": "1.0.0",
      "DeploymentRing": "Production",
      "EnvironmentName": "Production"
    }
  }
}
```

## Environment-specific configuration

You can provide different metadata for different environments using environment-specific configuration files:

**appsettings.Development.json**:

```json
{
  "ambientmetadata": {
    "application": {
      "ApplicationName": "MyWebApi",
      "BuildVersion": "1.0.0-dev",
      "DeploymentRing": "Development",
      "EnvironmentName": "Development"
    }
  }
}
```

**appsettings.Production.json**:

```json
{
  "ambientmetadata": {
    "application": {
      "ApplicationName": "MyWebApi",
      "BuildVersion": "1.0.0",
      "DeploymentRing": "Production",
      "EnvironmentName": "Production"
    }
  }
}
```

## Practical example: Telemetry enrichment

Here's a complete example showing how to use application metadata to enrich telemetry in an ASP.NET Core application:

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.AmbientMetadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.UseApplicationMetadata();
builder.Services.AddSingleton<TelemetryEnricher>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    var enricher = context.RequestServices.GetRequiredService<TelemetryEnricher>();
    enricher.EnrichRequest(context);
    await next();
});

app.MapGet("/api/health", (ApplicationMetadata metadata) =>
{
    return Results.Ok(new
    {
        Status = "Healthy",
        Application = metadata.ApplicationName,
        Version = metadata.BuildVersion,
        Environment = metadata.EnvironmentName
    });
});

app.Run();

public class TelemetryEnricher
{
    private readonly ILogger<TelemetryEnricher> _logger;
    private readonly ApplicationMetadata _metadata;

    public TelemetryEnricher(
        ILogger<TelemetryEnricher> logger,
        ApplicationMetadata metadata)
    {
        _logger = logger;
        _metadata = metadata;
    }

    public void EnrichRequest(HttpContext context)
    {
        using var scope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["ApplicationName"] = _metadata.ApplicationName ?? "Unknown",
            ["BuildVersion"] = _metadata.BuildVersion ?? "Unknown",
            ["Environment"] = _metadata.EnvironmentName ?? "Unknown",
            ["DeploymentRing"] = _metadata.DeploymentRing ?? "Unknown",
            ["RequestPath"] = context.Request.Path.Value ?? "Unknown"
        });

        _logger.LogInformation("Request received");
    }
}
```

## Best practices

When using application metadata, consider the following best practices:

- **Automate version setting**: Use your CI/CD pipeline to automatically set the `BuildVersion` from your version control system or build number.
- **Environment consistency**: Ensure environment names are consistent across all your applications for easier querying and filtering in telemetry systems.
- **Configuration management**: Use environment-specific configuration files or environment variables to manage different metadata values across environments.
- **Validate metadata**: Ensure required metadata fields are present during application startup to catch configuration issues early.
- **Telemetry integration**: Integrate application metadata with your telemetry system (such as Application Insights or OpenTelemetry) for comprehensive observability.

## See also

- [Configuration in .NET](configuration.md)
- [Configuration providers in .NET](configuration-providers.md)
- [Logging in .NET](logging.md)
- [Options pattern in .NET](options.md)
