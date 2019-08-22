---
title: Front-end client communication
description: Architecting Cloud Native .NET Apps for Azure | Front-End Client Communication
ms.date: 06/30/2019
---

# Front-end client communication

Front-end client applications (mobile, web, and desktop applications) require a channel to communicate with backend microservices.  

There are two common approaches. 

To keep things simple, a front-end client could directly communicate with back-end microservices, shown in Figure 4-2:

![Direct client to service communication](media/direct-client-to-service-communication.png)
**Figure 4-2**. Direct client to service communication

With this approach, each microservice has a public endpoint. In a production environment, you would typically place a load balancer in front of your microservices, routing traffic proportionately.

While relatively simple to implement, direct front-end communication wouldn't be acceptable for enterprise microservie applications. It tightly couples the frontend client to core backend services, opening the door for a number of potential problems, including:

- Client susceptibility to backend service refactoring.

- Wider attack surface as core backend services are directly exposed.

- Duplication of cross-cutting concerns across each microservice.

- Overly complex client code.

Instead, a widely accepted cloud design pattern is to implement an [API Gateway Service](https://docs.microsoft.com/dotnet/standard/microservices-architecture/architect-microservice-container-applications/direct-client-to-microservice-communication-versus-the-api-gateway-pattern) between the frontend applications and backend services. The pattern is shown in Figure 4-3:

![API Gateway Pattern](media/api-gateway-pattern.png)
**Figure 4-3.** API gateway pattern

This pattern exposes a single point of entry (the API gateway) to enable front-end communication with backend services. Clients aren't aware of the backend services, only the gateway. The gateway acts as a reverse proxy appropriately rerouting inbound traffic. The gateway insulates the client from internal service partitioning and refactoring. If we make a change to a service, we can accommodate for it in the gateway without breaking the client. THe gateway also implements cross-cutting concerns, such as identity, caching, resiliency, metering, and throttling. Many of these cross-cutting concerns can be off-loaded from the backend core services to the gateway, centralizing these concerns and simplifying the back-end services.

Care must be taken to keep the API Gateway simple and fast. A single gateway risks becoming a bottleneck and eventually a monolith itself. Larger systems might expose multiple API Gateways segmented by client type (mobile, web, desktop) or backend functionality. The [Backend for Frontends](https://docs.microsoft.com/azure/architecture/patterns/backends-for-frontends) pattern provides guidance for implementing multiple gateways.

To start, you could build your own API Gateway service. A quick search of GitHub will provide many examples. However, there are several commercial options.

## Azure API Management

Azure hosts a cloud-based API Management service that not only solves your API Gateway needs but provides rich developer and administrative features.

Shown in Figure 4-4, [Azure API Management](https://azure.microsoft.com/services/api-management/) is a great solution for medium- to large-scale cloud native systems. 

![Azure API Management](media/azure-api-management.png)
**Figure 4-4**. Azure API Management

> https://www.reply.com/solidsoft-reply/en/content/azure-api-management

> Robust Cloud Integration with Azure


In the previous figure, note how Azure API Management abstracts your backend microservices with a façade. Service consumers (front-end clients and other services) invoke the API façade with HTTP requests. Note also that a developer and publisher portal is exposed. 

The developer portal enables access to the API, its documentation, and sample code on how to invoke the API across a number of different programming languages. Developers can access Swagger/Open API metadata for their services and log issues. 

The publisher portal exposes an management dashboard where administrators 
can create APIs and configure how they behave. Access can be granted, service health monitored, and behavior and rules configured.


Here, API Policies can be applied to each call. Policies are a collection of pre-built statements that execute sequentially for the request and response of each call, enabling you to change the behavior of the API through configuration (that is, not code). The product ships with a large number of prebuilt [policies](https://docs.microsoft.com/azure/api-management/api-management-policies) that can be executed on the inbound call, backend processing, outbound call, and upon an error.





Each call is routed to a backend service. Additional rules can be configured, including:

- Throttling calls from a single source, if necessary.

- Enforcing authentication.

- Blocking calls from specific IP addresses.

- Enabling caching.

- Converting requests from SOAP to REST.

- Converting between different data formats, such as from XML to JSON.









The Azure API Management service provides a tremendous amount of functionality, shown in Figure 4-5.

![Azure API Management functionality](media/azure-api-management-functionality.png)
**Figure 4-5**. Azure API Management functionality

Azure API Management can access backend services hosted anywhere – including services in the cloud and in your data center. It supports both REST and SOAP APIs and works across any development platform (.NET, Java, Golang, and so on). Even other Azure services can be exposed through API Management. You could place a managed API on top of an Azure backing service like [Azure Service Bus](https://azure.microsoft.com/services/service-bus/) or [Azure Logic Apps](https://azure.microsoft.com/services/logic-apps/).


Azure API Management is available across [four different pricing tiers](https://azure.microsoft.com/pricing/details/api-management/):

- Developer

- Basic

- Standard

- Premium

The Developer tier is meant for non-production workloads and evaluation. The other tiers offer progressively more power, features, and service level agreements (SLAs) with the Premium tier providing Azure Virtual Network and multi-region support. All tiers have a fixed price per hour. 

Recently, Microsoft announced a [consumption pricing tier that is currently in preview. Unlike the “pre-allocated” pricing tiers previously shown, the consumption tier provides “serverless” functionality with instant provisioning and pay-per-Action pricing.

## SignalR Services

What was once a popular ASP.NET library to start two-way communication has now become a fully fledged Azure service. Azure SignalR Service makes real-time, two-way communication for HTTP-based applications easier. Once enabled, a cloud-based HTTP application or service can push content updates directly to connected clients, including browser, mobile and desktop applications. As a result, clients are updated without the need to poll the server. Applications that require high frequency updates such as chat, gaming, and financial apps are great candidates for this service.

Manually implementing real-time connectivity can quickly become complex, requiring non-trivial infrastructure to ensure scalability and reliable messaging to connected clients. You could easily find yourself managing your own instance of Azure Redis Cache along with a set of load balancers configured with sticky sessions for client affinity. Instead, these concerns are pre-configured and fully managed by Azure SignalR Service, freeing you up to focus on application features, not infrastructure plumbing.

Under the hood, SignalR abstracts the transport technologies that create real-time connectivity, including WebSockets, Server-Side Events, and Long Polling, depending on the capabilities of the client. Developers focus on sending messages to all or specific subsets of connected clients.

Figure 4-6 shows a set of HTTP Clients connecting to a Cloud App with Azure SignalR enabled.

![Azure SignalR](media/azure-signalr-service.png)

**Figure 4-6**. Azure SignalR

Azure SignalR Service can be integrated with other Azure services opening up many possibilities.

## Ocelot Gateway

For less complex cloud native applications, you might consider the open-source [Ocelot Gateway](https://github.com/ThreeMammals/Ocelot). Implemented as a set of configurable middleware, Ocelot is lightweight and scalable, and it exposes many gateway features. It's a good solution for simple microservice applications that don’t require the rich feature set of the Azure API Management gateway.

Available as a NuGet package, it targets NET Standard 2.0, making it compatible with both .NET Core 2.0+ and the .NET Framework 4.6.1+ runtimes. However, Ocelot integrates with anything that speaks HTTP and runs on the platforms which .NET Core supports: Linux, macOS, and Windows. It can be hosted in Azure and other public clouds.

Its primary functionality is to forward incoming HTTP requests to downstream services. But, it also supports a variety of configurable gateway capabilities, shown in Figure 4-7.

![Ocelot Features](media/ocelot-features.png)
**Figure 4-7**. Ocelot Features

Each Ocelot gateway instance includes a simple JSON configuration file that specifies the upstream and downstream addresses and configurable features, shown in Figure 4-8.

![Basic Ocelot implementation](media/basic-ocelot-implementation.png)

**Figure 4-8**. Basic Ocelot implementation

In Figure 4-8, the client sends an HTTP request to the Ocelot gateway. Once received, Ocelot manipulates the HttpRequest object into a state specified by its configuration. At the end of pipeline, Ocelot creates a new HttpRequestMessage that is passed to the downstream service. In reverse, Ocelot receives the HTTP response and sends it back to the client.

Ocelot is extensible and can support many modern platforms, including Azure Kubernetes Services and Service Fabric, as well as integration with open-source packages like Consul, GraphQL, Netflix’s Eureka, web sockets, and SignalR.

>[!div class="step-by-step"]
>[Previous](communication-patterns.md)
>[Next](cross-service-communication.md)
