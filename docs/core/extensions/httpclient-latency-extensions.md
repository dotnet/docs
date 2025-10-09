---
title: Monitor and analyze HTTP client performance
description: Learn how to use the HttpClientLatency with dependency injection in your .NET workloads.
author: IEvangelist
ms.author: dapine
ms.date: 09/29/2025
---

# HTTP client latency telemetry in .NET

### Get started

When building applications that communicate over HTTP it is important to observe request performance characteristics. 
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

You can customize how telemetry is collected by configuring the `HttpClientLatencyTelemetryOptions`:

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

The <xref:Microsoft.Extensions.Http.Latency.HttpClientLatencyTelemetryOptions*> class offers the following settings:

| Option                         | Type | Default | Description                                                                                                                                                                                                                                  | When to disable                                                                                                                |
|--------------------------------|------|---------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------|
| EnableDetailedLatencyBreakdown | bool | true    | Enables fine‑grained phase timing for each HttpClient request (e.g. connection establishment, headers sent, first byte, completion) to produce a breakdown of total latency. Adds a small extra CPU/time measurement cost, no wire overhead. | Set to false only in very high‑throughput scenarios where minimal overhead is required and total duration alone is sufficient. |

### Collected telemetry data

When HTTP client latency telemetry is enabled, the following information is collected:

#### Timing checkpoints

Timestamps are recorded for key stages of the HTTP request lifecycle:

* DNS resolution (Http.NameResolutionStart, Http.NameResolutionEnd)
* Socket connection (Http.SocketConnectStart, Http.SocketConnectEnd)
* Connection establishment (Http.ConnectionEstablished)
* Request headers (Http.RequestHeadersStart, Http.RequestHeadersEnd)
* Request content (Http.RequestContentStart, Http.RequestContentEnd)
* Response headers (Http.ResponseHeadersStart, Http.ResponseHeadersEnd)
* Response content (Http.ResponseContentStart, Http.ResponseContentEnd)

#### Measures

On supported platforms:

* Http.GCPauseTime - Records garbage collection pause duration during HTTP operations
* Http.ConnectionInitiated - Indicates when a new connection is established

#### Tags

* Http.Version - Records the HTTP protocol version used for the request

### Accessing telemetry data

The collected telemetry data can be accessed through the standard `ILatencyContextAccessor`:

```csharp
public class ApiService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILatencyContextAccessor _latencyContextAccessor;
    
    public ApiService(
        IHttpClientFactory httpClientFactory,
        ILatencyContextAccessor latencyContextAccessor)
    {
        _httpClientFactory = httpClientFactory;
        _latencyContextAccessor = latencyContextAccessor;
    }
    
    public async Task<object> GetDataAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://api.example.com/data");
        
        // Access latency information
        var context = _latencyContextAccessor.Current;
        if (context != null)
        {
            // Calculate DNS resolution time
            var dnsStart = context.GetCheckpoint(HttpCheckpoints.NameResolutionStart);
            var dnsEnd = context.GetCheckpoint(HttpCheckpoints.NameResolutionEnd);
            if (dnsStart != null && dnsEnd != null)
            {
                var dnsTime = dnsEnd.Value - dnsStart.Value;
                Console.WriteLine($"DNS resolution took: {dnsTime.TotalMilliseconds}ms");
            }
            
            // Get HTTP version used
            var httpVersion = context.GetTag(HttpTags.HttpVersion);
            if (httpVersion != null)
            {
                Console.WriteLine($"HTTP protocol version: {httpVersion}");
            }
        }
        
        return await response.Content.ReadFromJsonAsync<object>();
    }
}
```

### Platform considerations

HTTP client latency telemetry works across all supported .NET platforms with the following considerations:

* Core timing metrics are available on all platforms (.NET 9, .NET 8, .NET Standard 2.0, .NET Framework 4.6.2)
* Garbage collection metrics (Http.GCPauseTime) are only available on .NET 8 and .NET 9
* The implementation automatically adapts to the capabilities of the target platform
