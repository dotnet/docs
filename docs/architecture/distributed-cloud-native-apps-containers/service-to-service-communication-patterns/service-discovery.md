---
title: Service discovery 
description: Cloud-native service to service communication patterns | Service discovery
author: 
ms.date: 04/25/2024
---

# Service discovery

[!INCLUDE [download-alert](../includes/download-alert.md)]

## What is service discovery?

Service discovery refers to the process by which services dynamically locate and connect to each other. As your application scales and evolves, the IP addresses and endpoints of components and services change dynamically. Service discovery ensures that these components can find each other without hardcoding IP addresses or relying on static configurations.

## Service discovery using a load balancer

Service discovery could be achieved by using a server-side load balancer (LB). The LB points to the services and clients point to the LB. The downside of using an LB for service discovery is the need to maintain addresses in the LB and the possibility that the LB becomes a single point of failure.

## Service discovery in .NET

To get started with service discovery in .NET, install the [Microsoft.Extensions.ServiceDiscovery](https://www.nuget.org/packages/Microsoft.Extensions.ServiceDiscovery) NuGet package.

In the Program.cs file of your project, call the AddServiceDiscovery extension method to add service discovery to the host, configuring default service endpoint resolvers.

```csharp
builder.Services.AddServiceDiscovery();
```

Then, you can add service discovery to client services by calling the `AddServiceDiscovery` method:

```csharp
builder.Services.AddHttpClient<ProductServiceClient>(static client =>
    {
        client.BaseAddress = new("https://products");
    })
    .AddServiceDiscovery();
```

## Resolve service endpoints using platform-provided service discovery

Certain platforms, like Azure Container Apps and Kubernetes when configured accordingly, offer service discovery capabilities without necessitating a service discovery client library. In cases where an application is deployed in such environments, using the platform's built-in functionality can be advantageous. The pass-through resolver is designed to facilitate this scenario. It enables the utilization of alternative resolvers, such as configuration, in different environments, such as a developer's machine. Importantly, this flexibility is achieved without the need for any code modifications or the implementation of conditional guards.

## Service discovery in .NET Aspire

In .NET Aspire, service discovery features are built-in and easy to use. In any project that you've based on the .NET Aspire solution templates, or that you've added .NET Aspire orchestration to, .NET service discovery is already set up and configured. All you have to do is create the services in the App Host project, and then pass them to the other services that use them.

For example, this code creates two microservices called `catalog` and `basket`, each of which is a project in the .NET Aspire solution. It uses the `WithReference` extension method to pass these microservices to the `frontend` microservice:

```csharp
var builder = DistributedApplication.CreateBuilder(args);

var catalog = builder.AddProject<Projects.CatalogService>("catalog");
var basket = builder.AddProject<Projects.BasketService>("basket");

var frontend = builder.AddProject<Projects.Frontend>("frontend")
                      .WithReference(basket)
                      .WithReference(catalog);
```

>[!div class="step-by-step"]
>[Previous](introduction.md)
>[Next](service-to-service-communication.md)
