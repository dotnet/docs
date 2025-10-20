---
title: Process log enricher
description: Learn how to use the process log enricher in .NET.
ms.date: 10/10/2025
---

# Process log enricher

The process enricher augments telemetry logs with process-specific information.

You can register the enrichers in an IoC container. Then, all registered enrichers are picked up automatically by the respective telemetry instances, such as logs or metrics, where they enrich the telemetry information.

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

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.Telemetry"
                  Version="*" /> <!-- Adjust version -->
```

---

## Usage

To be able to use the process log enricher, first you need to enable enrichment. Then you can add the <xref:Microsoft.Extensions.DependencyInjection.ProcessEnricherServiceCollectionExtensions.AddProcessLogEnricher*> with default properties, like this:

:::code language="csharp" source="snippets/enrichment/Program.cs" range="3-34" highlight="13,14":::

Given this code sample, the output should be like this:

:::code language="json" source="json-output.json" highlight="8":::

## `ProcessLogEnricherOptions`

The <xref:Microsoft.Extensions.Diagnostics.Enrichment.ProcessLogEnricherOptions> class provides fine-grained control over which process-related properties are included in your log enrichment. This options class allows you to selectively enable or disable specific enrichment features such as process ID and thread ID information. Although default properties are supplied by the process enricher, you can customize them by initializing an instance of <xref:Microsoft.Extensions.Diagnostics.Enrichment.ProcessLogEnricherOptions> and providing it when registering the enricher.

You can enable or disable individual options of the enricher using <xref:Microsoft.Extensions.DependencyInjection.ProcessEnricherServiceCollectionExtensions.AddProcessLogEnricher(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{Microsoft.Extensions.Diagnostics.Enrichment.ProcessLogEnricherOptions})>:

```csharp
serviceCollection.AddProcessLogEnricher(options =>
{
    options.ThreadId = true;
    options.ProcessId = true;
});
```

You may also disable or enable individual options using _appsettings.json_ file configuration, for example:

```json
{
    "ProcessLogEnricherOptions": {
        "ThreadId": true,
        "ProcessId": true
    }
}
```

and apply it accordingly using <xref:Microsoft.Extensions.DependencyInjection.ProcessEnricherServiceCollectionExtensions.AddProcessLogEnricher(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfigurationSection)>:

```csharp
serviceCollection.AddProcessLogEnricher(
    hostBuilder.Configuration.GetSection("ProcessLogEnricherOptions"));
```

The console output after enabling both options should look like this:

:::code language="json" source="json-output-all-enabled.json" highlight="8,9":::

## Default configuration

The default configuration for process log enrichment is:

| Property    | Default Value | Description                                             |
|-------------|---------------|---------------------------------------------------------|
| `ProcessId` | `true`        | If true, logs are enriched with the current process ID. |
| `ThreadId`  | `false`       | If true, logs are enriched with the current thread ID   |
