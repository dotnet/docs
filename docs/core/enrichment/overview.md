---
title: Log enrichment overview
description: Learn about log enrichment in .NET and how to enhance your logs with contextual information.
ms.date: 10/13/2025
---

# Overview

Log enrichment is a powerful feature that automatically attaches contextual information to your application's logs. Instead of manually adding metadata to each log, enrichment provides a systematic way to inject relevant context automatically across your entire application.

## What is enrichment?

Enrichment augments telemetry objects with additional information that provides valuable context about the environment, application state, and execution context when the telemetry was generated. This contextual data helps with debugging, monitoring, performance analysis, and understanding application behavior in production environments.

## How enrichment works

The enrichment framework operates through a collection of enrichers that are registered with the dependency injection container. When telemetry is generated, all registered enrichers automatically contribute their contextual information to the telemetry payload. You just register the specific set of enrichers you want into
an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection> instance. The enrichers run automatically without requiring changes to your application code. You simply configure which enrichers you want to use during application startup.

## Dimension names and tags

Enrichers add information to telemetry using standardized dimension names (also called tags or keys).

## Setting up enrichment

To use log enrichment in your application, you need to:

1. **Enable enrichment** for logging
2. **Register specific enrichers** you want to use
3. **Configure options** for each enricher (optional)

### Basic setup example

Here's a simple example showing how to set up log enrichment with process information:

:::code language="csharp" source="snippets/enrichment/Program.cs" range="3-34" highlight="15,16":::

This configuration:

- Enables enrichment for logging via `EnableEnrichment()`
- Registers the process log enricher via `AddProcessLogEnricher()`
- Configures JSON console output to display the enriched data

### Output example

With enrichment enabled, your log output will automatically include additional contextual information:

:::code language="json" source="json-output.json" highlight="8":::

## Available enrichers

The .NET enrichment framework provides some built-in enrichers, like:

- **[Process enricher](process-log-enricher.md)**: Process and thread information

## Custom enrichers

If the built-in enrichers don't meet your specific needs, you can create custom enrichers to add application-specific context. For more information, check [custom enrichment](custom-enricher.md).
