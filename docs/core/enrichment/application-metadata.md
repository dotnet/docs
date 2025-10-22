---
title: Application metadata
description: Learn how to use the application metadata to add service-specific information to your service in .NET.
ms.date: 10/14/2025
---

# Application metadata

The [Application metadata provider](xref:Microsoft.Extensions.Configuration.ApplicationMetadataConfigurationBuilderExtensions.AddApplicationMetadata*) supplies service runtime information for application-level ambient metadata such as the version, deployment ring, environment, and name. This information can be useful to enrich any telemetry your service is emitting.

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

The following shows the information made available by the provider via <xref:Microsoft.Extensions.Configuration.IConfiguration>:

| Key | Required? | Where the value comes from| Value Example | Description|
|-|-|-|-|-|
| `ambientmetadata:application:applicationname` | yes | automatically from `IHostEnvironment` |`myApp` | The application name.|
| `ambientmetadata:application:environmentname` | yes | automatically from `IHostEnvironment` | `Production`, `Staging`, `Development` | The environment the application is deployed to.|
| `ambientmetadata:application:buildversion` | no | configure it in `IConfiguration` | `1.0.0-rc1` | The application's build version.|
| `ambientmetadata:application:deploymentring` | no | configure it in `IConfiguration` | `r0`, `public` | The deployment ring from where the application is running.|

## Example

To use this provider, you need to use the <xref:Microsoft.Extensions.Hosting.ApplicationMetadataHostBuilderExtensions.UseApplicationMetadata(Microsoft.Extensions.Hosting.IHostBuilder,System.String)> method,
which populates `ApplicationName` and `EnvironmentName` values automatically from `IHostEnvironment`.
Optionally, you can provide values for `BuildVersion` and `DeploymentRing` via the `appsettings.json` file.

Your `appsettings.json` should have a section as follows :

:::code language="json" source="snippets/servicelogenricher/appsettings.json" range="2-7":::

```cs
var host = Host.CreateDefaultBuilder()
    // ApplicationName and EnvironmentName will be imported from `IHostEnvironment` 
    // BuildVersion and DeploymentRing will be imported from the "appsettings.json" file.
    .UseApplicationMetadata()
    .Build()
    .StartAsync();

var metadataOptions = host.Services.GetRequiredService<IOptions<ApplicationMetadata>>();
var buildVersion = metadataOptions.Value.BuildVersion;
```

Alternatively, you can achieve the same result as above by doing this:

```cs
var hostBuilder = Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) => configurationBuilder
      .AddApplicationMetadata(hostBuilderContext.HostingEnvironment))
    .ConfigureServices((hostBuilderContext, serviceCollection) => serviceCollection
      .AddApplicationMetadata(hostBuilderContext.Configuration.GetSection("ambientmetadata:application")))
    .Build();

var metadataOptions = host.Services.GetRequiredService<IOptions<ApplicationMetadata>>();
var buildVersion = metadataOptions.Value.BuildVersion;
```
