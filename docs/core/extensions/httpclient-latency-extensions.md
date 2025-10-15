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
telemetry shape suitable for performance analysis and tuning.

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.Http.Diagnostics --version 10.0.0
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.Http.Diagnostics" Version="10.0.0" />
```

---

For more information, see [dotnet package add](../tools/dotnet-package-add.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

### Register HTTP client latency telemetry

To add HTTP client latency telemetry to your application, call the <xref:Microsoft.Extensions.DependencyInjection.HttpClientLatencyTelemetryExtensions.AddHttpClientLatencyTelemetry*> extension method when configuring your services:

```csharp
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add HTTP client factory
builder.Services.AddHttpClient();

// Add HTTP client latency telemetry
builder.Services.AddHttpClientLatencyTelemetry();
```

This registration adds a `DelegatingHandler` to all HTTP clients created through <xref:System.Net.Http.IHttpClientFactory>, collecting detailed latency information for each request.

### Configure telemetry options

You configure telemetry collection through the `HttpClientLatencyTelemetryOptions` (standard options pattern).
You can supply values either with a delegate or by binding configuration (for example, appsettings.json).
The options instance is resolved once per handler pipeline so changes apply to new clients/handlers.

```csharp
// Configure with delegate
builder.Services.AddHttpClientLatencyTelemetry(options =>
{
    options.EnableDetailedLatencyBreakdown = true;
});

// Or configure from configuration
builder.Services.AddHttpClientLatencyTelemetry(
builder.Configuration.GetSection("HttpClientTelemetry"));
```

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

| Name                     | Description                                                             |
|--------------------------|-------------------------------------------------------------------------|
| Http.GCPauseTime         | Total GC pause duration overlapping the request.                        |
| Http.ConnectionInitiated | Emitted when a new underlying connection (not pooled reuse) is created. |

#### Tags

| Tag          | Description                                                     |
|--------------|-----------------------------------------------------------------|
| Http.Version | HTTP protocol version negotiated/used (for example, 1.1, 2, 3). |

## Usage example

### Track HTTP request client latency

These components enable tracking and reporting the latency of HTTP client request processing.

You can register the services using the following methods:

```csharp
public static IServiceCollection AddHttpClientLatencyTelemetry(
    this IServiceCollection services);

public static IServiceCollection AddHttpClientLatencyTelemetry(
    this IServiceCollection services,
    IConfigurationSection section);

public static IServiceCollection AddHttpClientLatencyTelemetry(
    this IServiceCollection services,
    Action<HttpClientLatencyTelemetryOptions> configure);
```

For example:

```csharp
var builder = Host.CreateApplicationBuilder(args);

// Register IHttpClientFactory:
builder.Services.AddHttpClient();

// Register redaction services:
builder.Services.AddRedaction();

// Register latency context services:
builder.Services.AddLatencyContext();

// Register HttpClient logging enrichment & redaction services:
builder.Services.AddExtendedHttpClientLogging();

// Register HttpClient latency telemetry services:
builder.Services.AddHttpClientLatencyTelemetry();

var host = builder.Build();
```

### Platform considerations

HTTP client latency telemetry runs on all supported targets (.NET 9, .NET 8, .NET Standard 2.0, and .NET Framework 4.6.2).
Core timing checkpoints are always collected. The GC pause metric (Http.GCPauseTime) is emitted only when running on .NET 8 or .NET 9.
The implementation detects platform capabilities at run time and enables what is supported without additional configuration.
