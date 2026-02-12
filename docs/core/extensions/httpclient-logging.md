---
title: HTTP client logging in .NET
description: Learn how to enable enhanced logging for HTTP clients with redaction, enrichment, and compliance features in your .NET workloads.
ms.date: 02/12/2026
---

# HTTP client logging in .NET

When you build applications that make HTTP requests, structured logging helps you monitor, troubleshoot, and analyze outgoing traffic. The <xref:Microsoft.Extensions.DependencyInjection.HttpClientLoggingServiceCollectionExtensions.AddExtendedHttpClientLogging*> extension provides enhanced logging for all HTTP clients created with `IHttpClientFactory`, with built-in support for:

- **Configurable logging** - Control what gets logged (headers, body, query parameters, route parameters)
- **Data redaction** - Apply data classification and redaction policies for privacy and compliance
- **Log enrichment** - Add custom context to HTTP request logs
- **Minimal overhead** - Opt-in features with performance-conscious defaults

Enable enhanced HTTP client logging by calling the <xref:Microsoft.Extensions.DependencyInjection.HttpClientLoggingServiceCollectionExtensions.AddExtendedHttpClientLogging*> extension method. This replaces the default HTTP client logger with an extended logger that supports fine-grained configuration and data compliance features.

## Add the package

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.Http.Diagnostics
```

Or, if you're using .NET 10+ SDK:

```dotnetcli
dotnet package add Microsoft.Extensions.Http.Diagnostics
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.Http.Diagnostics"
                  Version="*" /> <!-- Adjust version -->
```

---

For more information, see [dotnet package add](../tools/dotnet-package-add.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## Enable HTTP client logging

To add enhanced HTTP client logging to your application, call the <xref:Microsoft.Extensions.DependencyInjection.HttpClientLoggingServiceCollectionExtensions.AddExtendedHttpClientLogging*> extension method when configuring your services:

```csharp
using Microsoft.Extensions.DependencyInjection;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// Register redaction services (required)
builder.Services.AddRedaction();

// Add enhanced HTTP client logging
builder.Services.AddExtendedHttpClientLogging();

// Add your HTTP clients
builder.Services.AddHttpClient<MyApiClient>();

using IHost host = builder.Build();

await host.RunAsync();
```

This registration adds an enhanced logger to all HTTP clients created through <xref:System.Net.Http.IHttpClientFactory>, replacing the default logger with one that supports advanced configuration.

> [!IMPORTANT]
> `AddExtendedHttpClientLogging()` removes all other loggers, including the default one registered via `AddDefaultLogger()`. This ensures consistent logging behavior across all HTTP clients.

> [!IMPORTANT]
> You must register redaction services by calling <xref:Microsoft.Extensions.DependencyInjection.RedactionServiceCollectionExtensions.AddRedaction*> from the `Microsoft.Extensions.Compliance.Redaction` package. The HTTP client logging feature redacts sensitive information by default (such as route parameters) and requires a redactor provider in the dependency injection container.

### Apply logging to specific HTTP clients

You can also apply enhanced logging to specific named or typed HTTP clients using the `IHttpClientBuilder` extension methods:

```csharp
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// Register redaction services (required)
builder.Services.AddRedaction();

// Apply to a named client
builder.Services.AddHttpClient("MyNamedClient")
    .AddExtendedHttpClientLogging();

// Apply to a typed client with configuration
builder.Services.AddHttpClient<MyApiClient>()
    .AddExtendedHttpClientLogging(options =>
    {
        options.LogBody = true;
        options.ResponseBodyContentTypes.Add("application/json");
    });

using IHost host = builder.Build();

await host.RunAsync();    
```

When using the `IHttpClientBuilder` overloads, logging is applied only to that specific client, not globally.

### Viewing enriched log data

Enhanced HTTP client logging adds information to logs using *enrichment*, which means data is added as tags to structured logs rather than to the console message. To view the enriched information, use a logging provider that supports structured logs.

For quick testing, use <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddJsonConsole*> to print structured logs to the console:

```csharp
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Logging.AddJsonConsole();

builder.Services.AddRedaction();

builder.Services.AddHttpClient("MyClient")
    .AddExtendedHttpClientLogging(options =>
    {
        options.LogBody = true;
        options.ResponseBodyContentTypes.Add("application/json");
    });
```

For production scenarios, consider using structured logging providers like Application Insights, Seq, or Elasticsearch that can query and visualize the enriched tag data.

## Configure logging options

You configure HTTP client logging through the <xref:Microsoft.Extensions.Http.Logging.LoggingOptions> class using the [standard options pattern](options.md). You can configure options in code or bind them from configuration (for example, `appsettings.json`).

### Configure with a delegate

```csharp
builder.Services.AddExtendedHttpClientLogging(options =>
{
    // Log request headers with data classification
    options.RequestHeadersDataClasses.Add("User-Agent", DataClassification.None);
    options.RequestHeadersDataClasses.Add("Authorization", DataClassification.Unknown);

    // Log response headers
    options.ResponseHeadersDataClasses.Add("Content-Type", DataClassification.None);

    // Enable request/response body logging (use carefully in production)
    options.LogBody = true;
    options.BodySizeLimit = 4096; // Limit to 4KB
    options.RequestBodyContentTypes.Add("application/json");
    options.ResponseBodyContentTypes.Add("application/json");
});
```

### Configure from appsettings.json

```json
{
  "HttpClientLogging": {
    "LogRequestStart": false,
    "LogBody": false,
    "BodySizeLimit": 32768,
    "BodyReadTimeout": "00:00:01",
    "RequestHeadersDataClasses": {
      "User-Agent": "None",
      "Content-Type": "None"
    },
    "ResponseHeadersDataClasses": {
      "Content-Type": "None"
    },
    "RequestPathLoggingMode": "Formatted",
    "RequestPathParameterRedactionMode": "Strict"
  }
}
```

```csharp
builder.Services.AddExtendedHttpClientLogging(
    builder.Configuration.GetSection("HttpClientLogging"));
```

## Configuration options

The <xref:Microsoft.Extensions.Http.Logging.LoggingOptions> class provides the following configuration options:

### Basic logging options

| Option | Type | Default | Description |
|--------|------|---------|-------------|
| `LogRequestStart` | `bool` | `false` | When `true`, logs the request before processing starts. When `false`, logs a single entry with both request and response data. |
| `LogBody` | `bool` | `false` | Enable logging of HTTP request and response bodies. **Warning**: Avoid enabling in production as it may leak privacy information. |
| `BodySizeLimit` | `int` | 32,768 (≈32KB) | Maximum number of bytes to read from request or response body. Keep below 85,000 bytes to avoid [large object heap](../../standard/garbage-collection/large-object-heap.md) allocation. |
| `BodyReadTimeout` | `TimeSpan` | 1 second | Maximum time to wait when reading request or response body. Must be between 1 millisecond and 1 minute. |
| `RequestBodyContentTypes` | `ISet<string>` | Empty | HTTP request content types considered text and eligible for serialization. |
| `ResponseBodyContentTypes` | `ISet<string>` | Empty | HTTP response content types considered text and eligible for serialization. |

### Header and query parameter logging

| Option | Type | Default | Description |
|--------|------|---------|-------------|
| `RequestHeadersDataClasses` | `IDictionary<string, DataClassification>` | Empty | HTTP request headers to log with their data classifications for redaction. If empty, no request headers are logged. |
| `ResponseHeadersDataClasses` | `IDictionary<string, DataClassification>` | Empty | HTTP response headers to log with their data classifications for redaction. If empty, no response headers are logged. |
| `RequestQueryParametersDataClasses` | `IDictionary<string, DataClassification>` | Empty | HTTP request query parameters to log with their data classifications. If empty, no query parameters are logged. Experimental feature. |
| `LogContentHeaders` | `bool` | `false` | Enable logging of HTTP content headers (for example, `Content-Type`). Only enable if content headers are in `RequestHeadersDataClasses` or `ResponseHeadersDataClasses`. Experimental feature. |

### Path and route parameter logging

| Option | Type | Default | Description |
|--------|------|---------|-------------|
| `RequestPathLoggingMode` | `OutgoingPathLoggingMode` | `Formatted` | How to log the outgoing HTTP request path. Applied only when `RequestPathParameterRedactionMode` is not `None`. |
| `RequestPathParameterRedactionMode` | `HttpRouteParameterRedactionMode` | `Strict` | How to redact path parameters in outgoing HTTP requests. |
| `RouteParameterDataClasses` | `IDictionary<string, DataClassification>` | Empty | Route parameters to redact with their corresponding data classifications. |

## Add log enrichers

HTTP client log enrichers allow you to add custom contextual information to HTTP client logs based on the request, response, and any exceptions. Unlike general-purpose log enrichers, HTTP client enrichers specifically target outgoing HTTP requests and have access to HTTP-specific context.

Here's a quick example:

```csharp
public class CustomHttpLogEnricher : IHttpClientLogEnricher
{
    public void Enrich(IEnrichmentTagCollector collector,
        HttpRequestMessage request, HttpResponseMessage? response, Exception? exception)
    {
        // Add tags based on the exception (if available)
        if (exception is not null)
        {
            collector.Add("error_type", exception.GetType().Name);
        }
    }
}

// Register the enricher
builder.Services.AddHttpClientLogEnricher<CustomHttpLogEnricher>();
```

For detailed information on creating and using HTTP client log enrichers, including best practices and advanced scenarios, see [HTTP client log enricher](../enrichment/http-client-log-enricher.md).

## Data classification and redaction

HTTP client logging integrates with the [data redaction](data-redaction.md) and [data classification](data-classification.md) features to protect sensitive information. When you specify a `DataClassification` for headers, query parameters, or route parameters, the redaction system applies appropriate redaction based on your configured redactors.

### Example: Redacting sensitive headers

```csharp
using Microsoft.Extensions.Compliance.Classification;

builder.Services.AddExtendedHttpClientLogging(options =>
{
    // Public headers - no redaction
    options.RequestHeadersDataClasses.Add("User-Agent", DataClassification.None);
    options.RequestHeadersDataClasses.Add("Content-Type", DataClassification.None);

    // Sensitive headers - apply redaction
    options.RequestHeadersDataClasses.Add("Authorization", DataClassification.Unknown);
    options.RequestHeadersDataClasses.Add("X-API-Key", DataClassification.Unknown);
});
```

For more information about configuring redactors, see [Data redaction in .NET](data-redaction.md).

## Path and route parameter redaction

By default, HTTP client logging redacts request and response paths to protect privacy. When logging HTTP request paths, you can control how route parameters are redacted using the `RequestPathParameterRedactionMode` option:

| Mode | Description | Example |
|------|-------------|---------|
| `None` | No redaction, full path is logged | `/api/users/12345/orders/67890` |
| `Strict` | All path parameters are redacted | `/api/users/{userId}/orders/{orderId}` |
| `Loose` | Only parameters in `RouteParameterDataClasses` are redacted | `/api/users/12345/orders/{orderId}` |

The `RequestPathLoggingMode` option controls the format of the logged path:

| Mode | Description | Example |
|------|-------------|---------|
| `Formatted` | Uses route template format with parameter names | `/api/users/{userId}/orders/{orderId}` |
| `Structured` | Logs path and parameters separately | Path: `/api/users/*/orders/*`, Params: `{userId, orderId}` |

### Example: Disable path redaction

To log full, unredacted paths (for example, in development environments), set `RequestPathParameterRedactionMode` to `None`:

```csharp
builder.Services.AddExtendedHttpClientLogging(options =>
{
    // Disable redaction of request/response paths
    options.RequestPathParameterRedactionMode = HttpRouteParameterRedactionMode.None;
});
```

> [!CAUTION]
> Disabling path redaction may expose sensitive information in logs. Only use `HttpRouteParameterRedactionMode.None` in development or when you're certain paths don't contain sensitive data.

## Performance considerations

Enhanced HTTP client logging is designed with performance in mind, but there are trade-offs to consider:

- **Body logging**: Enabling `LogBody` adds overhead for buffering and reading request/response bodies. Use `BodySizeLimit` and `BodyReadTimeout` to control resource usage.
- **Header logging**: Only log headers you need. Empty `RequestHeadersDataClasses` and `ResponseHeadersDataClasses` avoid header processing overhead.
- **Enrichers**: Each registered enricher is called for every request. Keep enricher logic lightweight.
- **Redaction**: Data classification and redaction add minimal overhead but scale with the number of classified items.

> [!TIP]
> In production environments, start with minimal logging (no body, limited headers) and enable additional logging only for troubleshooting.

## See also

- [HTTP client factory in .NET](httpclient-factory.md)
- [HTTP client log enricher](../enrichment/http-client-log-enricher.md)
- [Monitor and analyze HTTP client performance](httpclient-latency-extensions.md)
- [Data redaction in .NET](data-redaction.md)
- [Data classification in .NET](data-classification.md)
- [Logging in .NET](logging/overview.md)
