---
title: Application enricher
description: Learn how to use the application log enricher to add application-specific information to your telemetry in .NET.
ms.date: 10/14/2025
---

# Application enricher

The application log enricher augments telemetry logs with application-specific information such as service host details and application metadata. This enricher provides essential context about your application's deployment environment, version information, and service identity that helps with monitoring, debugging, and operational visibility.

You can register the enrichers in an IoC container, and all registered enrichers are automatically picked up by respective telemetry logs, where they enrich the telemetry information.

## Prerequisites

To function properly, this enricher requires that [application metadata](xref:application-metadata) is configured and available. The application metadata provides the foundational information that the enricher uses to populate telemetry dimensions.

## Install the package

To get started, install the [📦 Microsoft.Extensions.Telemetry](https://www.nuget.org/packages/Microsoft.Extensions.Telemetry) NuGet package:

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.Telemetry
```

Or, if you're using .NET 10+ SDK:

```dotnetcli
dotnet package add Microsoft.Extensions.Telemetry
```

## Application log enricher

The application log enricher provides application-specific enrichment. The log enricher specifically targets log telemetry and adds standardized dimensions that help identify and categorize log entries by service characteristics.

### Step-by-step configuration

Follow these steps to configure the application log enricher in your application:

#### 1. Configure Application Metadata

First, configure the [Application Metadata](xref:application-metadata) by calling the <xref:Microsoft.Extensions.Hosting.ApplicationMetadataHostBuilderExtensions.UseApplicationMetadata> method:

```csharp
var builder = Host.CreateDefaultBuilder();
builder.UseApplicationMetadata()
```

This method automatically picks up values from the <xref:Microsoft.Extensions.Hosting.IHostEnvironment> and saves them to the default configuration section `ambientmetadata:application`.

Alternatively, you can use this method <xref:Microsoft.Extensions.Configuration.ApplicationMetadataConfigurationBuilderExtensions.AddApplicationMetadata(Microsoft.Extensions.Configuration.IConfigurationBuilder,Microsoft.Extensions.Hosting.IHostEnvironment,System.String)>, which registers a configuration provider for application metadata by picking up the values from the <xref:Microsoft.Extensions.Hosting.IHostEnvironment> and adds it to the given configuration section name. Then you use <xref:Microsoft.Extensions.DependencyInjection.ApplicationMetadataServiceCollectionExtensions.AddApplicationMetadata(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfigurationSection)> method to register the metadata in the dependency injection container, which allow you to pass <xref:Microsoft.Extensions.Configuration.IConfigurationSection> separately:

```csharp
var hostBuilder = Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration((context, builder) =>
        builder.AddApplicationMetadata(context.HostingEnvironment))
    .ConfigureServices((context, services) =>
        services.AddApplicationMetadata(context.Configuration.GetSection("ambientmetadata:application")));
```

#### 2. Provide additional configuration (optional)

You can provide additional configuration via `appsettings.json`. There are two properties in the [Application Metadata](xref:application-metadata) that don't get values automatically: `BuildVersion` and `DeploymentRing`. If you want to use them, provide values manually:

:::code language="json" source="snippets/servicelogenricher/appsettings.json" range="2-7":::

#### 3. Register the service log enricher

Register the log enricher into the dependency injection container using <xref:Microsoft.Extensions.DependencyInjection.ApplicationEnricherServiceCollectionExtensions.AddServiceLogEnricher>:

```csharp
serviceCollection.AddServiceLogEnricher();
```

You can enable or disable individual options of the enricher using <xref:Microsoft.Extensions.DependencyInjection.ApplicationEnricherServiceCollectionExtensions.AddServiceLogEnricher(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action(Microsoft.Extensions.Diagnostics.Enrichment.ApplicationLogEnricherOptions))>:

```csharp
serviceCollection.AddServiceLogEnricher(options =>
{
    options.BuildVersion = true;
    options.DeploymentRing = true;
});
```

Alternatively, configure options using `appsettings.json`:

:::code language="json" source="snippets/servicelogenricher/appsettings.json" range="9-12":::

And apply the configuration using <xref:Microsoft.Extensions.DependencyInjection.ApplicationEnricherServiceCollectionExtensions.AddServiceLogEnricher(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfigurationSection)>:

```csharp
var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices((context, services) =>
{
    services.AddServiceLogEnricher(context.Configuration.GetSection("applicationlogenricheroptions"));
});
```

### `ApplicationLogEnricherOptions` Configuration options

The service log enricher supports several configuration options through the <xref:Microsoft.Extensions.Diagnostics.Enrichment.ApplicationLogEnricherOptions> class:

| Property | Default Value | Dimension Name | Description |
|----------|---------------|----------------|-------------|
| `EnvironmentName` | true | `deployment.environment` | Environment name from hosting environment or configuration |
| `ApplicationName` | true | `service.name` | Application name from hosting environment or configuration |
| `BuildVersion` | false | `service.version` | Build version from configuration |
| `DeploymentRing` | false | `DeploymentRing` | Deployment ring from configuration |

By default, the enricher includes `EnvironmentName` and `ApplicationName` in log entries. The `BuildVersion` and `DeploymentRing` properties are disabled by default and must be explicitly enabled if needed.

### Complete example

Here's a complete example showing how to set up the service log enricher:

**appsettings.json:**

:::code language="json" source="snippets/servicelogenricher/appsettings.json":::

**Program.cs:**

:::code language="csharp" source="snippets/servicelogenricher/Program.cs" :::

### Enriched log output

With the service log enricher configured, your log output will include service-specific dimensions:

:::code language="csharp" source="snippets/servicelogenricher/output-full.json" highlight="9-11" :::

## Next steps

- Learn about [application metadata configuration](xref:application-metadata)
