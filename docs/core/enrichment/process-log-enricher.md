---
title: Process log enricher
description: Learn how to use the process log enricher in .NET.
ms.date: 10/10/2025
---

# Process log enricher

The process enricher augments telemetry logs with process-specific information.

You can register the enrichers in an IoC container. Then, all registered enrichers are picked up automatically by the respective telemetry instances, such as logs or metrics, where they enrich the telemetry information.

## Usage

To be able to use the process log enricher, first you need to enable enrichment like this:
:::code language="csharp" source="snippets/enrichment/Program.cs" highlight="15":::

then you can add the <xref:Microsoft.Extensions.DependencyInjection.ProcessEnricherServiceCollectionExtensions.AddProcessLogEnricher*> with default properties, like this:

:::code language="csharp" source="snippets/enrichment/Program.cs" highlight="16":::

or alternatively:

```cs
var hostApplicationBuilder = WebApplication.CreateBuilder();
hostApplicationBuilder.Services.AddProcessLogEnricher();
```

Or, optionally, enable or disable individual options of the enricher using <xref:Microsoft.Extensions.DependencyInjection.ProcessEnricherServiceCollectionExtensions.AddProcessLogEnricher(Microsoft.Extensions.Configuration.IConfigurationSection)>:

```cs
serviceCollection.AddProcessLogEnricher(options =>
{
    options.ThreadId = true;
    options.ProcessId = true;
});
```

You may also disable or enable individual options using `appsettings.json` file configuration, for example:

```json
{
    "ProcessLogEnricherOptions": {
        "ThreadId": true,
        "ProcessId": true
    }
}
```

and apply it accordingly using <xref:Microsoft.Extensions.DependencyInjection.ProcessEnricherServiceCollectionExtensions.AddProcessLogEnricher(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{Microsoft.Extensions.Diagnostics.Enrichment.ProcessLogEnricherOptions})>:

```cs
serviceCollection.AddProcessLogEnricher(hostBuilder.Configuration.GetSection("ProcessLogEnricherOptions"));
```

## Default configuration

Although default properties are supplied by the process enricher, you can customize them by initializing an instance of <xref:Microsoft.Extensions.Diagnostics.Enrichment.ProcessLogEnricherOptions> and providing it when registering the enricher.

The default configuration for log enrichment is:

| Property   | Default Value   | Description                                          |
| -----------| ----------------|------------------------------------------------------|
| `ProcessId`     | true            | If true, logs are enriched with the current process ID.        |
| `ThreadId`      | false           | If true, logs are enriched with the current thread ID          |
