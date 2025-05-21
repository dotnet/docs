---
title: Server configuration
description: Learn how to configure .NET Orleans server settings.
ms.date: 07/03/2024
zone_pivot_groups: orleans-version
ms.topic: article
---

# Server configuration

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

A silo is configured programmatically with the <xref:Microsoft.Extensions.Hosting.GenericHostExtensions.UseOrleans(Microsoft.Extensions.Hosting.IHostBuilder,System.Action{Microsoft.Extensions.Hosting.HostBuilderContext,Orleans.Hosting.ISiloBuilder})> extension method and several supplemental option classes. Option classes in Orleans follow the [Options pattern in .NET](../../../core/extensions/options.md), and can be loaded via files, environment variables, and any valid configuration provider.

There are several key aspects of silo configuration:

- Clustering provider
- (Optional) Orleans clustering information
- (Optional) Endpoints to use for silo-to-silo and client-to-silo communications

This is an example of a silo configuration that defines cluster information, uses Azure clustering, and configures the application parts:

```csharp
using IHost host = Host.CreateDefaultBuilder(args)
    .UseOrleans(builder =>
    {
        builder.UseAzureStorageClustering(
            options => options.ConfigureTableServiceClient(connectionString));
    })
    .UseConsoleLifetime()
    .Build();
```

> [!TIP]
> When developing for Orleans, you can call <xref:Orleans.Hosting.CoreHostingExtensions.UseLocalhostClustering(Orleans.Hosting.ISiloBuilder,System.Int32,System.Int32,System.Net.IPEndPoint,System.String,System.String)> to configure a local cluster. In production environments, you should use a clustering provider that is suitable for your deployment.

## Clustering provider

```csharp
siloBuilder.UseAzureStorageClustering(
    options => options.ConfigureTableServiceClient(connectionString))
```

Usually, a service built on Orleans is deployed on a cluster of nodes, either on dedicated hardware or in the cloud. For development and basic testing, Orleans can be deployed in a single-node configuration. When deployed to a cluster of nodes, Orleans internally implements a set of protocols to discover and maintain membership of Orleans silos in the cluster, including detection of node failures and automatic reconfiguration.

For reliable management of cluster membership, Orleans uses Azure Table, SQL Server, or Apache ZooKeeper for the synchronization of nodes.

In this sample, Azure Table as the membership provider is used.

## Orleans clustering information

To optionally configure clustering, use `ClusterOptions` as the type parameter for the <xref:Orleans.Hosting.SiloBuilderExtensions.Configure%2A> method on the `ISiloBuilder` instance.

```csharp
siloBuilder.Configure<ClusterOptions>(options =>
{
    options.ClusterId = "my-first-cluster";
    options.ServiceId = "SampleApp";
})
```

Here you specify two options:

- Set the `ClusterId` to `"my-first-cluster"`: this is a unique ID for the Orleans cluster. All clients and silos that use this ID will be able to talk directly to each other. You can choose to use a different `ClusterId` for different deployments, though.
- Set the `ServiceId` to `"SampleApp"`: this is a unique ID for your application that will be used by some providers, such as persistence providers. **This ID should remain stable and not change across deployments**.

By default, Orleans will use a value of `"default"` for both the `ServiceId` and the `ClusterId`. These values don't need to be changed in most cases. `ServiceId` is the more significant of the two, and is used to distinguish different logical services from each other so that they can share backend storage systems without interfering with each other. `ClusterId` is used to determine which hosts will connect to each other and form a cluster.

Within each cluster, all hosts must use the same `ServiceId`. Multiple clusters can share a `ServiceId`, however. This enables blue/green deployment scenarios where a new deployment (cluster) is started before another is shut down. This is typical for systems hosted in Azure App Service.

The more common case is that `ServiceId` and `ClusterId` remain fixed for the lifetime of the application and a rolling deployment strategy is used. This is typical for systems hosted in Kubernetes and Service Fabric.

## Endpoints

By default, Orleans will listen on all interfaces on port `11111` for silo-to-silo communication and on port `30000` for client-to-silo communication. To override this behavior, call <xref:Orleans.Hosting.EndpointOptionsExtensions.ConfigureEndpoints(Orleans.Hosting.ISiloBuilder,System.Int32,System.Int32,System.Net.Sockets.AddressFamily,System.Boolean)> and pass in the port numbers you want to use.

```csharp
siloBuilder.ConfigureEndpoints(siloPort: 17_256, gatewayPort: 34_512)
```

In the preceding code:

- The silo port is set to `17_256`.
- The gateway port is set to `34_512`.

An Orleans silo has two typical types of endpoint configuration:

- Silo-to-silo endpoints are used for communication between silos in the same cluster.
- Client-to-silo (or gateway) endpoints are used for communication between clients and silos in the same cluster.

This method should be sufficient in most cases, but you can customize it further if you need to.
Here is an example of how to use an external IP address with some port-forwarding:

```csharp
siloBuilder.Configure<EndpointOptions>(options =>
{
    // Port to use for silo-to-silo
    options.SiloPort = 11_111;
    // Port to use for the gateway
    options.GatewayPort = 30_000;
    // IP Address to advertise in the cluster
    options.AdvertisedIPAddress = IPAddress.Parse("172.16.0.42");
    // The socket used for client-to-silo will bind to this endpoint
    options.GatewayListeningEndpoint = new IPEndPoint(IPAddress.Any, 40_000);
    // The socket used by the gateway will bind to this endpoint
    options.SiloListeningEndpoint = new IPEndPoint(IPAddress.Any, 50_000);
})
```

Internally, the silo will listen on `0.0.0.0:40000` and `0.0.0.0:50000`, but the value published in the membership provider will be `172.16.0.42:11111` and `172.16.0.42:30000`.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

A silo is configured programmatically via <xref:Orleans.Hosting.SiloHostBuilder> and several supplemental option classes. Option classes in Orleans follow the [Options pattern in .NET](../../../core/extensions/options.md), and can be loaded via files, environment variables, and any valid configuration provider.

There are several key aspects of silo configuration:

- Orleans clustering information
- Clustering provider
- Endpoints to use for silo-to-silo and client-to-silo communications
- Application parts

This is an example of a silo configuration that defines cluster information, uses Azure clustering, and configures the application parts:

```csharp
var silo = Host.CreateDefaultBuilder(args)
    .UseOrleans(builder =>
    {
        builder
            .UseAzureStorageClustering(
                options => options.ConnectionString = connectionString)
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "my-first-cluster";
                options.ServiceId = "AspNetSampleApp";
            })
            .ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000)
            .ConfigureApplicationParts(
                parts => parts.AddApplicationPart(typeof(ValueGrain).Assembly).WithReferences())
    })
    .UseConsoleLifetime()
    .Build();
```

Let's breakdown the steps used in this sample:

## Clustering provider

```csharp
siloBuilder.UseAzureStorageClustering(
    options => options.ConnectionString = connectionString)
```

Usually, a service built on Orleans is deployed on a cluster of nodes, either on dedicated hardware or in the cloud. For development and basic testing, Orleans can be deployed in a single-node configuration. When deployed to a cluster of nodes, Orleans internally implements a set of protocols to discover and maintain membership of Orleans silos in the cluster, including detection of node failures and automatic reconfiguration.

For reliable management of cluster membership, Orleans uses Azure Table, SQL Server, or Apache ZooKeeper for the synchronization of nodes.

In this sample, we are using Azure Table as the membership provider.

## Orleans clustering information

```csharp
.Configure<ClusterOptions>(options =>
{
    options.ClusterId = "my-first-cluster";
    options.ServiceId = "AspNetSampleApp";
})
```

Here we do two things:

- Set the `ClusterId` to `"my-first-cluster"`: this is a unique ID for the Orleans cluster. All clients and silos that use this ID will be able to talk directly to each other. You can choose to use a different `ClusterId` for different deployments, though.
- Set the `ServiceId` to `"AspNetSampleApp"`: this is a unique ID for your application that will be used by some providers, such as persistence providers. **This ID should remain stable and not change across deployments**.

By default, Orleans will use a value of `"default"` for both the `ServiceId` and the `ClusterId`. These values don't need to be changed in most cases. `ServiceId` is the more significant of the two, and is used to distinguish different logical services from each other so that they can share backend storage systems without interfering with each other. `ClusterId` is used to determine which hosts will connect to each other and form a cluster.

Within each cluster, all hosts must use the same `ServiceId`. Multiple clusters can share a `ServiceId`, however. This enables blue/green deployment scenarios where a new deployment (cluster) is started before another is shut down. This is typical for systems hosted in Azure App Service.

The more common case is that `ServiceId` and `ClusterId` remain fixed for the lifetime of the application and a rolling deployment strategy is used. This is typical for systems hosted in Kubernetes and Service Fabric.

## Endpoints

```csharp
siloBuilder.ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000)
```

An Orleans silo has two typical types of endpoint configuration:

- Silo-to-silo endpoints, used for communication between silos in the same cluster
- Client-to-silo endpoints (or gateway), used for communication between clients and silos in the same cluster

In the sample, we are using the helper method `.ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000)` which sets the port used for silo-to-silo communication to `11111` and the port for the gateway to `30000`.
This method will detect which interface to listen to.

This method should be sufficient in most cases, but you can customize it further if you need to.
Here is an example of how to use an external IP address with some port-forwarding:

```csharp
siloBuilder.Configure<EndpointOptions>(options =>
{
    // Port to use for silo-to-silo
    options.SiloPort = 11111;
    // Port to use for the gateway
    options.GatewayPort = 30000;
    // IP Address to advertise in the cluster
    options.AdvertisedIPAddress = IPAddress.Parse("172.16.0.42");
    // The socket used for client-to-silo will bind to this endpoint
    options.GatewayListeningEndpoint = new IPEndPoint(IPAddress.Any, 40000);
    // The socket used by the gateway will bind to this endpoint
    options.SiloListeningEndpoint = new IPEndPoint(IPAddress.Any, 50000);
})
```

Internally, the silo will listen on `0.0.0.0:40000` and `0.0.0.0:50000`, but the value published in the membership provider will be `172.16.0.42:11111` and `172.16.0.42:30000`.

## Application parts

```csharp
siloBuilder.ConfigureApplicationParts(
    parts => parts.AddApplicationPart(
        typeof(ValueGrain).Assembly)
        .WithReferences())
```

Although this step is not technically required (if not configured, Orleans will scan all assemblies in the current folder), developers are encouraged to configure this. This step will help Orleans to load user assemblies and types. These assemblies are referred to as Application Parts. All Grains, Grain Interfaces, and Serializers are discovered using Application Parts.

Application Parts are configured using <xref:Orleans.ApplicationParts.IApplicationPartManager>, which can be accessed using the `ConfigureApplicationParts` extension method on <xref:Orleans.IClientBuilder> and <xref:Orleans.Hosting.ISiloHostBuilder>. The `ConfigureApplicationParts` method accepts a delegate, `Action<IApplicationPartManager>`.

The following extension methods on <xref:Orleans.ApplicationParts.IApplicationPartManager> support common uses:

- <xref:Orleans.ApplicationPartManagerExtensions.AddApplicationPart%2A?displayProperty=nameWithType> a single assembly can be added using this extension method.
- <xref:Orleans.ApplicationPartManagerExtensions.AddFromAppDomain%2A?displayProperty=nameWithType> adds all assemblies currently loaded in the `AppDomain`.
- <xref:Orleans.ApplicationPartManagerExtensions.AddFromApplicationBaseDirectory%2A?displayProperty=nameWithType> loads and adds all assemblies in the current base path (see <xref:System.AppDomain.BaseDirectory?displayProperty=nameWithType>).

Assemblies added by the above methods can be supplemented using the following extension methods on their return type, <xref:Orleans.ApplicationParts.IApplicationPartManagerWithAssemblies>:

- <xref:Orleans.ApplicationPartManagerExtensions.WithReferences%2A?displayProperty=nameWithType> adds all referenced assemblies from the added parts. This immediately loads any transitively referenced assemblies. Assembly loading errors are ignored.
- <xref:Orleans.Hosting.ApplicationPartManagerCodeGenExtensions.WithCodeGeneration%2A?displayProperty=nameWithType> generates support code for the added parts and adds it to the part manager. Note that this requires the `Microsoft.Orleans.OrleansCodeGenerator` package to be installed and is commonly referred to as runtime code generation.

Type discovery requires that the provided Application Parts include specific attributes. Adding the build-time code generation package (`Microsoft.Orleans.CodeGenerator.MSBuild` or `Microsoft.Orleans.OrleansCodeGenerator.Build`) to each project containing Grains, Grain Interfaces, or Serializers is the recommended approach for ensuring that these attributes are present. Build-time code generation only supports C#. For F#, Visual Basic, and other .NET languages, code can be generated during configuration time via the <xref:Orleans.Hosting.ApplicationPartManagerCodeGenExtensions.WithCodeGeneration%2A> method described above. More info regarding code generation could be found in [the corresponding section](../../grains/code-generation.md).

:::zone-end
