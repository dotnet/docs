---
title: Client configuration
description: Learn about client configurations in .NET Orleans.
ms.date: 01/21/2026
ms.topic: how-to
zone_pivot_groups: orleans-version
ms.custom: sfi-ropc-nochange
---

# Client configuration

:::zone target="docs" pivot="orleans-7-0,orleans-8-0,orleans-9-0,orleans-10-0"

Configure a client for connecting to a cluster of silos and sending requests to grains programmatically via an <xref:Microsoft.Extensions.Hosting.IHostBuilder> and several supplemental option classes. Like silo options, client option classes follow the [Options pattern in .NET](../../../core/extensions/options.md).

:::zone-end

:::zone target="docs" pivot="orleans-3-x"

Configure a client for connecting to a cluster of silos and sending requests to grains programmatically via an <xref:Orleans.ClientBuilder> and several supplemental option classes. Like silo options, client option classes follow the [Options pattern in .NET](../../../core/extensions/options.md).

:::zone-end

> [!TIP]
> If you just want to start a local silo and a local client for development purposes, see [Local development configuration](local-development-configuration.md).

:::zone target="docs" pivot="orleans-8-0,orleans-9-0,orleans-10-0"

> [!TIP]
> If you're using [.NET Aspire](../aspire-integration.md), client configuration is handled automatically. Aspire injects `ClusterId`, `ServiceId`, and clustering provider settings via environment variables, so you can use the simpler parameterless `UseOrleansClient()` method. See [Orleans and .NET Aspire integration](../aspire-integration.md) for the recommended approach.

:::zone-end

Add the [Microsoft.Orleans.Clustering.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.AzureStorage) NuGet package to your client project.

There are several key aspects of client configuration:

- Orleans clustering information
- Clustering provider
- Application parts

Example of a client configuration:

:::zone target="docs" pivot="orleans-7-0,orleans-8-0,orleans-9-0,orleans-10-0"

### [Managed identity (recommended)](#tab/managed-identity)

Using a `TokenCredential` with a URI endpoint is the recommended approach for production environments. This pattern avoids storing secrets in configuration and leverages Azure managed identities for secure authentication.

[!INCLUDE [credential-chain-guidance](../../includes/credential-chain-guidance.md)]

```csharp
using Azure.Identity;

var endpoint = new Uri(configuration["AZURE_TABLE_STORAGE_ENDPOINT"]!);
var credential = new ManagedIdentityCredential();

var builder = Host.CreateApplicationBuilder(args);
builder.UseOrleansClient(clientBuilder =>
{
    clientBuilder.Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "my-first-cluster";
        options.ServiceId = "MyOrleansService";
    })
    .UseAzureStorageClustering(options =>
    {
        options.ConfigureTableServiceClient(endpoint, credential);
    });
});

using var host = builder.Build();
await host.StartAsync();
```

### [Connection string](#tab/connection-string)

```csharp
var builder = Host.CreateApplicationBuilder(args);
builder.UseOrleansClient(clientBuilder =>
{
    clientBuilder.Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "my-first-cluster";
        options.ServiceId = "MyOrleansService";
    })
    .UseAzureStorageClustering(
        options => options.ConfigureTableServiceClient(
            builder.Configuration["ORLEANS_AZURE_STORAGE_CONNECTION_STRING"]));
});

using var host = builder.Build();
await host.StartAsync();
```

---

:::zone-end

:::zone target="docs" pivot="orleans-3-x"

```csharp
using Orleans.Hosting;

var client = new ClientBuilder()
    .Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "my-first-cluster";
        options.ServiceId = "MyOrleansService";
    })
    .UseAzureStorageClustering(
        options => options.ConnectionString = connectionString)
    .ConfigureApplicationParts(
        parts => parts.AddApplicationPart(
            typeof(IValueGrain).Assembly))
    .Build();
```

:::zone-end

Let's break down the steps used in this sample:

## Orleans clustering information

```csharp
    .Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "orleans-docker";
        options.ServiceId = "AspNetSampleApp";
    })
```

Here, we set two things:

- The <xref:Orleans.Configuration.ClusterOptions.ClusterId?displayProperty=nameWithType> to `"my-first-cluster"`: This is a unique ID for the Orleans cluster. All clients and silos using this ID can directly talk to each other. Some might choose to use a different `ClusterId` for each deployment, for example.
- The <xref:Orleans.Configuration.ClusterOptions.ServiceId?displayProperty=nameWithType> to `"AspNetSampleApp"`: This is a unique ID for your application, used by some providers (e.g., persistence providers). This ID should remain stable across deployments.

## Clustering provider

:::zone target="docs" pivot="orleans-7-0,orleans-8-0,orleans-9-0,orleans-10-0"

### [Managed identity (recommended)](#tab/managed-identity)

[!INCLUDE [credential-chain-guidance](../../includes/credential-chain-guidance.md)]

```csharp
var endpoint = new Uri(configuration["AZURE_TABLE_STORAGE_ENDPOINT"]!);
var credential = new ManagedIdentityCredential();

clientBuilder.UseAzureStorageClustering(options =>
{
    options.ConfigureTableServiceClient(endpoint, credential);
});
```

### [Connection string](#tab/connection-string)

```csharp
.UseAzureStorageClustering(
    options => options.ConfigureTableServiceClient(connectionString));
```

---

:::zone-end

:::zone target="docs" pivot="orleans-3-x"

```csharp
.UseAzureStorageClustering(
    options => options.ConnectionString = connectionString)
```

:::zone-end

The client discovers all available gateways in the cluster using this provider. Several providers are available; here, we use the Azure Table provider.

For more information, see [Server configuration](server-configuration.md).

:::zone target="docs" pivot="orleans-3-x"

## Application parts

```csharp
.ConfigureApplicationParts(
    parts => parts.AddApplicationPart(
        typeof(IValueGrain).Assembly))
        .WithReferences())
```

For more information, see [Server configuration](server-configuration.md).

:::zone-end
