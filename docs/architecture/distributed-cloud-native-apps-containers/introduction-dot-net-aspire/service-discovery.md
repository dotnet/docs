---
title: Service discovery
description: Architecture for Distributed Cloud-Native Apps with .NET Aspire & Containers | Service discovery
author: 
ms.date: 04/25/2024
---

# Service discovery

[!INCLUDE [download-alert](../includes/download-alert.md)]

![A diagram showing some aspects of .NET Aspire service discovery.](media/service-discovery.png)

**Figure 3-4**. Service discovery in .NET Aspire.

In the world of distributed applications, services often need to communicate with each other over the network. Whether you're developing locally or in the cloud, ensuring that services can find and connect to each other is crucial. **.NET Aspire** provides a powerful service discovery mechanism that simplifies this process.

## Why Service Discovery Matters

Imagine a microservices-based application with multiple components: authentication, catalog, basket, and frontend services. These services need to interact with each other, but their endpoints, such as different ports or URLs, can change dynamically. Service discovery helps address this challenge by providing a way for services to locate and communicate with one another.

## Implicit Service Discovery by Reference

In .NET Aspire, service discovery configuration is added only for services that are **referenced** by a given project. Let's consider an example:

```csharp
var builder = DistributedApplication.CreateBuilder(args);
var catalog = builder.AddProject<Projects.CatalogService>("catalog");
var basket = builder.AddProject<Projects.BasketService>("basket");
var frontend = builder.AddProject<Projects.MyFrontend>("frontend")
    .WithReference(basket)
    .WithReference(catalog)
    WithExternalHttpEndpoints();
```

You'll find this code in the App Host project, usually in the _Program.cs_ file:

- The `frontend` project receives references to both the `catalog` and `basket` projects.
- The `.WithReference()` calls instruct the .NET Aspire application to pass service discovery information for the referenced projects (in this case `catalog` and `basket`) into the `frontend` project.

## Named Endpoints

To make it easier to locate services, services can expose multiple **named endpoints**. These endpoints can be resolved by specifying the endpoint name in the host portion of the HTTP request URI. The format is `scheme://_endpointName.serviceName`. For instance:

```csharp
builder.Services.AddHttpClient<BasketServiceClient>(client =>
    client.BaseAddress = new Uri("https://basket"));
builder.Services.AddHttpClient<BasketServiceDashboardClient>(client =>
    client.BaseAddress = new Uri("https://_dashboard.basket"));
```

In this example:
- We configure two `HttpClient` classes—one for the core basket service and another for the basket service's dashboard.
- The `_dashboard` endpoint is resolved from the name `https://_dashboard.basket`.

## Configuration-Based Endpoint Resolver

With the configuration-based endpoint resolver, named endpoints can be specified in configuration files. For example, in `appsettings.json`:

```json
{
  "Services": {
    "basket": "https://10.2.3.4:8080", // Default endpoint, reachable at https://basket
    "dashboard": "https://10.2.3.4:9999" // "dashboard" endpoint, reachable at https://_dashboard.basket
  }
}
```

In this JSON:
- The default endpoint resolves the name `https://basket` to `10.2.3.4:8080`.
- The "dashboard" endpoint resolves the name `https://_dashboard.basket` to `10.2.3.4:9999`.

>[!div class="step-by-step"]
>[Previous](orchestration.md)
>[Next](components.md)
