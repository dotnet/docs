---
title: Runtime monitoring and logs
description: Explore the various runtime monitoring and logs values in .NET Orleans.
ms.date: 02/01/2022
---

# Orleans logs

Orleans leverages [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging) for all silo and client logs. For more information, see [Logging in .NET](../../../core/extensions/logging.md).

## Runtime monitoring

Orleans outputs its runtime statistics and metrics through the `ITelemetryConsumer` interface. The application can register one or more telemetry consumers for their silos and clients, to receive statistics and metrics that the Orleans runtime periodically publishes. These can be consumers for popular telemetry analytics solutions or custom ones for any other destination and purpose. Three telemetry consumers are currently included in the Orleans codebase.

They are released as separate NuGet packages:

- `Microsoft.Orleans.OrleansTelemetryConsumers.AI` for publishing to [Azure Application Insights](/azure/azure-monitor/app/app-insights-overview).

- `Microsoft.Orleans.OrleansTelemetryConsumers.Counters` for publishing to Windows performance counters.
The Orleans runtime continually updates a number of them. The _CounterControl.exe_ tool, included in the [`Microsoft.Orleans.CounterControl`](https://www.nuget.org/packages/Microsoft.Orleans.CounterControl/) NuGet package, helps register necessary performance counter categories. It has to run with elevated privileges. The performance counters can be monitored using any of the standard monitoring tools.

- `Microsoft.Orleans.OrleansTelemetryConsumers.NewRelic`, for publishing to [New Relic](https://newrelic.com/).

To configure your silo and client to use telemetry consumers, silo configuration code looks like this:

```csharp
var siloHostBuilder = new SiloHostBuilder();
siloHostBuilder.AddApplicationInsightsTelemetryConsumer("INSTRUMENTATION_KEY");
```

Client configuration code look like this:

```csharp
var clientBuilder = new ClientBuilder();
clientBuilder.AddApplicationInsightsTelemetryConsumer("INSTRUMENTATION_KEY");
```

To use a custom defined TelemetryConfiguration (which may have `TelemetryProcessors`, `TelemetrySinks`, and so on), silo configuration code looks like this:

```csharp
var siloHostBuilder = new SiloHostBuilder();
var telemetryConfiguration = TelemetryConfiguration.CreateDefault();
siloHostBuilder.AddApplicationInsightsTelemetryConsumer(telemetryConfiguration);
```

Client configuration code look like this:

```csharp
var clientBuilder = new ClientBuilder();
var telemetryConfiguration = TelemetryConfiguration.CreateDefault();
clientBuilder.AddApplicationInsightsTelemetryConsumer(telemetryConfiguration);
```
