---
title: Application metadata
description: Learn how to use the application metadata to add service-specific information to your service in .NET.
ms.date: 10/14/2025
---

# Application ambient metadata

The [`Microsoft.Extensions.AmbientMetadata.Application`](https://www.nuget.org/packages/Microsoft.Extensions.AmbientMetadata.Application) NuGet package provides functionality to capture and flow application-level ambient metadata throughout your application. This metadata includes information such as the application name, version, deployment environment, and deployment ring, which is valuable for enriching telemetry, troubleshooting, and analysis.

## Why use application metadata

Application metadata provides essential context about your running application that can enhance observability:

- **Telemetry enrichment**: Automatically add application details to logs, metrics, and traces.
- **Troubleshooting**: Quickly identify which version of your application is experiencing issues.
- **Environment identification**: Distinguish between different environments in your telemetry.
- **Deployment tracking**: Track issues across different deployment rings or regions.
- **Consistent metadata**: Ensure all components in your application use the same metadata values.

## Install the package

To get started, install the [📦 Microsoft.Extensions.AmbientMetadata.Application](https://www.nuget.org/packages/Microsoft.Extensions.AmbientMetadata.Application) NuGet package:

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.AmbientMetadata.Application
```

Or, if you're using .NET 10+ SDK:

```dotnetcli
dotnet package add Microsoft.Extensions.AmbientMetadata.Application
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.AmbientMetadata.Application"
                  Version="*" /> <!-- Adjust version -->
```

---

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

Use the <xref:Microsoft.Extensions.Hosting.ApplicationMetadataHostBuilderExtensions.UseApplicationMetadata%2A> extensions method to register application metadata, which populates `ApplicationName` and `EnvironmentName` values automatically from `IHostEnvironment`.
Optionally, you can provide values for `BuildVersion` and `DeploymentRing` via the `appsettings.json` file.

The following table shows the metadata made available by the provider via <xref:Microsoft.Extensions.Configuration.IConfiguration>:

| Key | Required? | Where the value comes from| Value Example | Description|
|-|-|-|-|-|
| `ambientmetadata:application:applicationname` | yes | automatically from `IHostEnvironment` |`myApp`                     | The application name.|
| `ambientmetadata:application:environmentname` | yes | automatically from `IHostEnvironment` | `Production`, `Development`| The environment the application is deployed to.|
| `ambientmetadata:application:buildversion`    | no  | configure it in `IConfiguration`      | `1.0.0-rc1`                | The application's build version.|
| `ambientmetadata:application:deploymentring`  | no  | configure it in `IConfiguration`      | `r0`, `public`             | The deployment ring from where the application is running.|

```cs
var builder = Host.CreateDefaultBuilder()
    // ApplicationName and EnvironmentName will be imported from `IHostEnvironment` 
    // BuildVersion and DeploymentRing will be imported from the "appsettings.json" file.
builder.UseApplicationMetadata();

var host = builder.Build();
await host.StartAsync();

var metadataOptions = host.Services.GetRequiredService<IOptions<ApplicationMetadata>>();
var buildVersion = metadataOptions.Value.BuildVersion;
```

Alternatively, you can achieve the same result as above by doing this:

```cs
var host = Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) => configurationBuilder
      .AddApplicationMetadata(hostBuilderContext.HostingEnvironment))
    .ConfigureServices((hostBuilderContext, serviceCollection) => serviceCollection
      .AddApplicationMetadata(hostBuilderContext.Configuration.GetSection("ambientmetadata:application")))
    .Build();

var metadataOptions = host.Services.GetRequiredService<IOptions<ApplicationMetadata>>();
var buildVersion = metadataOptions.Value.BuildVersion;
```

Your `appsettings.json` can have a section as follows :

:::code language="json" source="snippets/servicelogenricher/appsettings.json" range="2-7":::

### Configure with IHostApplicationBuilder

For applications using <xref:Microsoft.Extensions.Hosting.IHostApplicationBuilder>:

```csharp
```cs
var builder = Host.CreateApplicationBuilder()
    // ApplicationName and EnvironmentName will be imported from `IHostEnvironment` 
    // BuildVersion and DeploymentRing will be imported from the "appsettings.json" file.
builder.UseApplicationMetadata();

var host = builder.Build();
await host.StartAsync();

var metadataOptions = host.Services.GetRequiredService<IOptions<ApplicationMetadata>>();
var buildVersion = metadataOptions.Value.BuildVersion;
```

Your `appsettings.json` can have a section as follows :

:::code language="json" source="snippets/servicelogenricher/appsettings.json" range="2-7":::

## Access application metadata

Once configured, you can inject and use the <xref:Microsoft.Extensions.AmbientMetadata.ApplicationMetadata> type:

```csharp
using Microsoft.Extensions.AmbientMetadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var builder = Host.CreateApplicationBuilder(args);
builder.UseApplicationMetadata();

var host = builder.Build();

var _metadata = host.Services.GetRequiredService<IOptions<ApplicationMetadata>>().Value;
Console.WriteLine($"Application: {_metadata.ApplicationName}");
Console.WriteLine($"Version: {_metadata.BuildVersion}");
Console.WriteLine($"Environment: {_metadata.EnvironmentName}");
Console.WriteLine($"Deployment Ring: {_metadata.DeploymentRing}");
await host.RunAsync();
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
using Microsoft.Extensions.Options;

var builder = Host.CreateApplicationBuilder();

builder.UseApplicationMetadata();
builder.ConfigureServices(services =>
{
    services.AddSingleton<LoggingService>();
});

var host = builder.Build();

var loggingService = host.Services.GetRequiredService<LoggingService>();
loggingService.LogWithMetadata();

await host.RunAsync();

public class LoggingService
{
    private readonly ILogger<LoggingService> _logger;
    private readonly ApplicationMetadata _metadata;

    public LoggingService(ILogger<LoggingService> logger, IOptions<ApplicationMetadata> metadata)
    {
        _logger = logger;
        _metadata = metadata.Value;
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

If you prefer to use a different configuration section name, specify it when calling <xref:Microsoft.Extensions.Hosting.applicationmetadatahostbuilderextensions.UseApplicationMetadata``1(System.String)>:

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
      "ApplicationName": "MyWebApi", // Your ApplicationName will be imported from `IHostEnvironment` 
      "BuildVersion": "1.0.0",
      "DeploymentRing": "Production",
      "EnvironmentName": "Production" // Your EnvironmentName will be imported from `IHostEnvironment` 
    }
  }
}
```
