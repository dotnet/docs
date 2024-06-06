---
title: Service discovery 
description: Cloud-native service to service communication patterns | Service discovery
author: 
ms.date: 04/25/2024
---

# Service discovery

[!INCLUDE [download-alert](../includes/download-alert.md)]

## What Is Service Discovery?

Service discovery refers to the process by which services dynamically locate and connect to each other. As your application scales and evolves, the IP addresses and endpoints of components and services change dynamically. Service discovery ensures that these components can find each other without hardcoding IP addresses or relying on static configurations.

## Service discovery using a load balancer

Service discovery could be achieved by using a server-side load balancer (LB). The LB points to the services and clients point to the LB. The downside of using an LB for service discovery is the need to maintain addresses in the LB and the LB becoming a single point of failure.

## Service discovery in .NET

To get started with service discovery in .NET, install the [Microsoft.Extensions.ServiceDiscovery](https://www.nuget.org/packages/Microsoft.Extensions.ServiceDiscovery) NuGet package.

In the Program.cs file of your project, call the AddServiceDiscovery extension method to add service discovery to the host, configuring default service endpoint resolvers.

```csharp
builder.Services.AddServiceDiscovery();
```

Alternatively, service discovery can be added to an individual HttpClient instance.

## Resolve service endpoints using platform-provided service discovery

Certain platforms, like Azure Container Apps and Kubernetes (when configured accordingly), offer service discovery capabilities without necessitating a service discovery client library. In cases where an application is deployed in such environments, using the platform's built-in functionality can be advantageous. The pass-through resolver is designed to facilitate this scenario. It enables the utilization of alternative resolvers, such as configuration, in different environments, such as a developer's machine. Importantly, this flexibility is achieved without the need for any code modifications or the implementation of conditional guards.

>[!div class="step-by-step"]
>[Previous](introduction.md)
>[Next](front-end-client-communication.md)