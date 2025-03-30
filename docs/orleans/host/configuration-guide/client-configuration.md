---
title: Client configuration
description: Learn about client configurations in .NET Orleans.
ms.date: 05/23/2025
ms.topic: how-to
ms.service: orleans
zone_pivot_groups: orleans-version
---

# Client configuration

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

Configure a client for connecting to a cluster of silos and sending requests to grains programmatically via an <xref:Microsoft.Extensions.Hosting.IHostBuilder> and several supplemental option classes. Like silo options, client option classes follow the [Options pattern in .NET](../../../core/extensions/options.md).

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

Configure a client for connecting to a cluster of silos and sending requests to grains programmatically via an <xref:Orleans.ClientBuilder> and several supplemental option classes. Like silo options, client option classes follow the [Options pattern in .NET](../../../core/extensions/options.md).

:::zone-end

> [!TIP]
> If you just want to start a local silo and a local client for development purposes, see [Local development configuration](local-development-configuration.md).

Add the [Microsoft.Orleans.Clustering.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.AzureStorage) NuGet package to your client project.

There are several key aspects of client configuration:

- Orleans clustering information
- Clustering provider
- Application parts

Example of a client configuration:

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

```csharp
var client = new HostBuilder()
    .UseOrleansClient((context, clientBuilder) =>
    {
        clientBuilder.Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "my-first-cluster";
            options.ServiceId = "MyOrleansService";
        })
        .UseAzureStorageClustering(
            options => options.ConfigureTableServiceClient(
                context.Configuration["ORLEANS_AZURE_STORAGE_CONNECTION_STRING"]));
    })
    .Build();
```

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

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

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

```csharp
.UseAzureStorageClustering(
    options => options.ConfigureTableServiceClient(connectionString);
```

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

```csharp
.UseAzureStorageClustering(
    options => options.ConnectionString = connectionString)
```

:::zone-end

The client discovers all available gateways in the cluster using this provider. Several providers are available; here, we use the Azure Table provider.

For more information, see [Server configuration](server-configuration.md).

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

## Application parts

```csharp
.ConfigureApplicationParts(
    parts => parts.AddApplicationPart(
        typeof(IValueGrain).Assembly))
        .WithReferences())
```

For more information, see [Server configuration](server-configuration.md).

:::zone-end
