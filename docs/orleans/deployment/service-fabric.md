---
title: Host with Service Fabric
description: Learn how to host an Orleans app with Service Fabric.
ms.date: 12/02/2022
---

# Host with Service Fabric

Orleans can be hosted on [Azure Service Fabric](/azure/service-fabric) using the [Microsoft.ServiceFabric.Services](https://www.nuget.org/packages/Microsoft.ServiceFabric.Services) and [Microsoft.Orleans.Server](https://www.nuget.org/packages/Microsoft.Orleans.Server) NuGet packages. Silos should be hosted as unpartitioned, stateless services since Orleans manages the distribution of grains itself. Other hosting options, such as, partitioned and stateful, are more complex and yield no benefits. It's recommended to host Orleans unpartitioned and stateless.

## Service Fabric stateless service as a Silo

Whether you're creating a new Service Fabric Application or adding Orleans to an existing one, you'll need both the `Microsoft.ServiceFabric.Services` and `Microsoft.Orleans.Server` package references in your project. The stateless service project, needs an implementation on the <xref:Microsoft.ServiceFabric.Services.Communication.Runtime.ICommunicationListener> and a subclass of the <xref:Microsoft.ServiceFabric.Services.Runtime.StatelessService>.

The Silo lifecycle follows the typical communication listener lifecycle:

- It's initialized with <xref:Microsoft.ServiceFabric.Services.Communication.Runtime.ICommunicationListener.OpenAsync%2A?displayProperty=nameWithType>.
- It's gracefully terminated with <xref:Microsoft.ServiceFabric.Services.Communication.Runtime.ICommunicationListener.CloseAsync%2A?displayProperty=nameWithType>.
- Or it's abruptly terminated with <xref:Microsoft.ServiceFabric.Services.Communication.Runtime.ICommunicationListener.Abort%2A?displayProperty=nameWithType>.

Since Orleans Silos are capable of living within the confines of the <xref:Microsoft.Extensions.Hosting.IHost>, the implementation of the `ICommunicationListener` is a wrapper around the `IHost`. The `IHost` is initialized in the `OpenAsync` method and gracefully terminated in the `CloseAsync` method:

| `ICommunicationListener` | `IHost` interactions |
|---------|---------|
| <xref:Microsoft.ServiceFabric.Services.Communication.Runtime.ICommunicationListener.OpenAsync%2A> | The `IHost` instance is created and a call to <xref:Microsoft.Extensions.Hosting.IHost.StartAsync%2A> is made. |
| <xref:Microsoft.ServiceFabric.Services.Communication.Runtime.ICommunicationListener.CloseAsync%2A> | A call to <xref:Microsoft.Extensions.Hosting.IHost.StopAsync%2A> on the host instance is awaited. |
| <xref:Microsoft.ServiceFabric.Services.Communication.Runtime.ICommunicationListener.Abort%2A> | A call to <xref:Microsoft.Extensions.Hosting.IHost.StopAsync%2A> is forcefully evaluated, with `GetAwaiter().GetResult()`. |

## Cluster support

Official clustering support is available from various packages including:

* `Microsoft.Orleans.Clustering.AzureStorage`
* `Microsoft.Orleans.Clustering.AdoNet`
* `Microsoft.Orleans.Clustering.DynamoDB`

There are also several third-party packages available for other services such as CosmosDB, Kubernetes, Redis, and Aerospike. For more information, see [Cluster management in Orleans](../implementation/cluster-management.md).

## Example project

In the stateless service project, implement the `ICommunicationListener` interface as shown in the following example:

:::code source="snippets/service-fabric/stateless/HostedServiceCommunicationListener.cs":::

The `HostedServiceCommunicationListener` class accepts a `Func<Task<IHost>> createHost` constructor parameter. This is later used to create the `IHost` instance in the `OpenAsync` method.

The next part of the stateless service project is to implement the `StatelessService` class. The following example shows the subclass of the `StatelessService` class:

:::code source="snippets/service-fabric/stateless/OrleansHostedStatelessService.cs":::

In the preceding example, the `OrleansHostedStatelessService` class is responsible for yielding an `ICommunicationListener` instance. The `CreateServiceInstanceListeners` method is called by the Service Fabric runtime when the service is initialized.

Pulling these two classes together, the following example shows the complete stateless service project _Program.cs_ file:

:::code source="snippets/service-fabric/stateless/Program.cs":::

In the preceding  code:

- The <xref:Microsoft.ServiceFabric.Services.Runtime.ServiceRuntime.RegisterServiceAsync%2A?displayProperty=nameWithType> method registers the `OrleansHostedStatelessService` class with the Service Fabric runtime.
- The `CreateHostAsync` delegate is used to create the `IHost` instance.
