---
title: Monitor and analyze HTTP client performance
description: Learn how to use the HttpClientLatency with dependency injection in your .NET workloads.
author: IEvangelist
ms.author: dapine
ms.date: 09/29/2025
ai-usage: ai-assisted
---

# HTTP client latency telemetry in .NET

When you build applications that communicate over HTTP, it's important to observe request performance characteristics.
The <xref:Microsoft.Extensions.DependencyInjection.HttpClientLatencyTelemetryExtensions.AddHttpClientLatencyTelemetry*>
extension enables collection of detailed timing information for outgoing HTTP calls with no changes to calling code.
It plugs into the existing `HttpClientFactory` pipeline to capture stage timings across the request lifecycle, record
HTTP protocol details, measure garbage collection impact where the runtime exposes that data, and emit a uniform
telemetry shape suitable for performance analysis and tuning.Enable them by calling `AddHttpClientLatencyTelemetry()` extension method.
The built‑in handler creates an `ILatencyContext` per outbound request and populates measures by the time the inner
pipeline completes. Consume them after `await base.SendAsync(...)` in a later delegating handler (added after telemetry)
and export to your metrics backend. Example:

Register extension method:

:::code language="csharp" source="snippets/http/latency/RegisterHandler.cs" range="3-24" highlight="11":::

Access the context:

:::code language="csharp" source="snippets/http/latency/HttpLatencyExportHandler.cs" range="4-23" highlight="12,15":::

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.Http.Diagnostics --version 9.10.0
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.Http.Diagnostics" Version="9.10.0" />
```

---

For more information, see [dotnet package add](../tools/dotnet-package-add.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

### Register HTTP client latency telemetry

To add HTTP client latency telemetry to your application, call the <xref:Microsoft.Extensions.DependencyInjection.HttpClientLatencyTelemetryExtensions.AddHttpClientLatencyTelemetry*> extension method when configuring your services:

:::code language="csharp" source="snippets/http/latency/Program.cs" id="extensions" highlight="7":::

This registration adds a `DelegatingHandler` to all HTTP clients created through <xref:System.Net.Http.IHttpClientFactory>, collecting detailed latency information for each request.

### Configure telemetry options

You configure telemetry collection through the <xref:Microsoft.Extensions.Http.Latency.HttpClientLatencyTelemetryOptions> ([standard options pattern](options.md)).
You can supply values either with a delegate or by binding configuration (for example, `appsettings.json`).
The options instance is resolved once per handler pipeline so changes apply to new clients/handlers.

:::code language="csharp" source="snippets/http/latency/Program.cs" range="23-31" highlight="1-5,8,9":::

### Configuration options

The <xref:Microsoft.Extensions.Http.Latency.HttpClientLatencyTelemetryOptions> class offers the following settings:

| Option                         | Type    | Default | Description                                                                                                                                                                                                                                          | When to disable                                                                                                                  |
|--------------------------------|---------|---------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------|
| EnableDetailedLatencyBreakdown | Boolean | `true`  | Enables fine-grained phase timing for each HttpClient request (for example, connection establishment, headers sent, first byte, completion) to produce a breakdown of total latency. Adds a small extra CPU/time measurement cost, no wire overhead. | Set to `false` only in very high-throughput scenarios where minimal overhead is required and total duration alone is sufficient. |

### Collected telemetry data

When HTTP client latency telemetry is enabled, it captures phase timestamps, selected measures (where supported), and protocol attributes used for performance analysis.

#### Timing checkpoints

Timestamps are recorded for key stages of the HTTP request lifecycle:

| Phase                   | Start Event                | End Event                  | Notes                                                   |
|-------------------------|----------------------------|----------------------------|---------------------------------------------------------|
| DNS resolution          | Http.NameResolutionStart   | Http.NameResolutionEnd     | Host name lookup (may be cached and skipped).           |
| Socket connection       | Http.SocketConnectStart    | Http.SocketConnectEnd      | CP (and TLS handshake if combined by handler).          |
| Connection establishment|                            | Http.ConnectionEstablished | Marks usable connection after handshake.                |
| Request headers         | Http.RequestHeadersStart   | Http.RequestHeadersEnd     | Writing request headers to the wire/buffer.             |
| Request content         | Http.RequestContentStart   | Http.RequestContentEnd     | Streaming or buffering request body.                    |
| Response headers        | Http.ResponseHeadersStart  | Http.ResponseHeadersEnd    | First byte to completion of header parsing.             |
| Response content        | Http.ResponseContentStart  | Http.ResponseContentEnd    | Reading full response body (to completion or disposal). |

#### Measures (platform dependent)

Measures quantify latency contributors that raw phase checkpoints cannot (GC pause overlap, connection churn, other
accumulated counts or durations). They are collected in an in‑memory latency context created when you call
`AddHttpClientLatencyTelemetry()`. Nothing is emitted automatically: the context simply accumulates checkpoints, measures,
and tags until the request completes. If you also enable HTTP client logging enrichment with `AddExtendedHttpClientLogging()`,
the completed context is flattened into a single structured log field named `LatencyInfo` (version marker, server name if available, then tag, checkpoint, and measure name/value sequences).

That log field is the only built‑in output artifact; no metrics or traces are produced unless you add your own exporter.
To surface them as metrics, read the context after the request pipeline returns and record (for example) GC pause overlap
to a histogram and connection initiations to a counter, optionally dimensioned by protocol version.

| Name                     | Description                                                             |
|--------------------------|-------------------------------------------------------------------------|
| Http.GCPauseTime         | Total GC pause duration overlapping the request.                        |
| Http.ConnectionInitiated | Emitted when a new underlying connection (not pooled reuse) is created. |

#### Tags

Use tags to attach stable categorical dimensions to each request so you can segment, filter, and aggregate metrics
and logs without reprocessing raw data. They are low‑cardinality classification labels (not timings) captured
in the latency context and, if HTTP client log enrichment is enabled, serialized into a single LatencyInfo log field.
Enable enrichment at application startup by adding the logging extension (for all clients or per client) along with
latency telemetry, for example:

:::code language="csharp" source="snippets/http/latency/Program.cs" range="36-39" highlight="2,3":::

After this, outbound requests logged through the structured logging pipeline will include the `LatencyInfo` property
containing the flattened tags, checkpoints, and measures. No metrics or traces are emitted automatically for tags;
export them yourself (e.g., turn tag values into metric dimensions or `Activity` tags) if you need them outside logs.

| Tag          | Description                                                     |
|--------------|-----------------------------------------------------------------|
| Http.Version | HTTP protocol version negotiated/used (for example, 1.1, 2, 3). |

## Usage example

These components enable tracking and reporting the latency of HTTP client request processing.

You can register the services using the following methods:

:::code language="csharp" source="snippets/http/latency/Program.cs" range="44-53" highlight="1,2,4-6, 8-10":::

For example:

:::code language="csharp" source="snippets/http/latency/Program.cs" range="58-75" highlight="10,13,16":::

### Platform considerations

HTTP client latency telemetry runs on all supported targets (.NET 9, .NET 8, .NET Standard 2.0, and .NET Framework 4.6.2).
Core timing checkpoints are always collected. The GC pause metric (Http.GCPauseTime) is emitted only when running on .NET 8 or .NET 9.
The implementation detects platform capabilities at run time and enables what is supported without additional configuration.
