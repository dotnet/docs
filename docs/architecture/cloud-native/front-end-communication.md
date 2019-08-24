---
title: Front-end client communication
description: Architecting Cloud Native .NET Apps for Azure | Front-End Client Communication
ms.date: 06/30/2019
---

# Front-end client communication

Front-end client applications (mobile, web, and desktop applications) require a communication channel to interact  with backend microservices that are part of a cloud-native system.  

To keep things simple, a front-end client could *directly communicate* with the backend microservices, shown in Figure 4-2.

![Direct client to service communication](./media/direct-client-to-service-communication.png)
**Figure 4-2**. Direct client to service communication

With this approach, each microservice has a public endpoint and is accessible by the front-end client. In a production environment, you'd go a step further and place a load balancer in front of your microservices, routing traffic proportionately.

While simple to implement, direct client communication would be acceptable only for simple microservice applications. This pattern tightly couples the frontend client to the core backend services, opening the door for a number of potential problems, including:

- Client susceptibility to backend service refactoring.

- A wider attack surface as core backend services are directly exposed.

- Duplication of cross-cutting concerns across each microservice.

- Overly complex client code.

Instead, a widely accepted cloud design pattern is to implement an [API Gateway Service](https://docs.microsoft.com/dotnet/standard/microservices-architecture/architect-microservice-container-applications/direct-client-to-microservice-communication-versus-the-api-gateway-pattern) between the frontend applications and backend services. The pattern is shown in Figure 4-3.

![API Gateway Pattern](./media/api-gateway-pattern.png)

**Figure 4-3.** API gateway pattern

In the previous figure, note how the API Gateway service abstracts the backend core microservices. Implemented as a simple .NET Core API application (in this case), it acts as a *reverse proxy*, incoming routing traffic to internal services. 

The gateway insulates the client from internal service partitioning and refactoring. If you make a change to a backend service, you can accommodate for it in the gateway without breaking the client. It also acts as your first line of defense for implementing cross-cutting concerns, such as identity, caching, resiliency, metering, and throttling. Many of these cross-cutting concerns can be off-loaded from the backend core services to the gateway, centralizing these concerns and simplifying the back-end services.

Care must be taken to keep the API Gateway simple and fast. Typically, business logic is kept out of the gateway. A complex gateway risks becoming a bottleneck and eventually a monolith itself. Larger systems often expose multiple API Gateways segmented by client type (mobile, web, desktop) or backend functionality. The [Backend for Frontends](https://docs.microsoft.com/azure/architecture/patterns/backends-for-frontends) pattern provides direction for implementing multiple gateways. The pattern is shown in Figure 4-4.

![API Gateway Pattern](./media/backend-for-frontend-pattern.png)

**Figure 4-4.** Backend for frontend pattern


To start, you could build your own API Gateway service. A quick search of GitHub will provide many examples. However, there are several frameworks and commercial gateway products available.

## Ocelot Gateway

For simple .NET cloud-native applications, you might consider the [Ocelot Gateway](https://github.com/ThreeMammals/Ocelot). Ocelot is an Open Source .NET Core based API Gateway created for microservice systems architecture that requires unified points of entry. It's lightweight, fast, scalable, 

Like any API Gateway, its primary functionality is to forward incoming HTTP requests to downstream services. Additionally, it supports a wide variety of capabilities that are configurable as a .NET Core middleware pipeline. Its feature set is shown in Figure 4-5.

![Ocelot Features](./media/ocelot-features.png)

**Figure 4-5**. Ocelot Features

Each Ocelot gateway specifies the upstream and downstream addresses and configurable features in a JSON configuration file. 

Shown in Figure 4-6, The client sends an HTTP request to the Ocelot gateway. Once received, Ocelot then passes the HttpRequest object through its pipeline manipulating it into the state specified by its configuration. At the end of pipeline, Ocelot creates a new HTTPResponseObject and passed it to the downstream service. For the response, Ocelot reverses the pipeline, sending the response back to client.

![Basic Ocelot implementation](./media/basic-ocelot-implementation.png)

**Figure 4-6**. Basic Ocelot implementation

Ocelot is available as a NuGet package. It targets the NET Standard 2.0, making it compatible with both .NET Core 2.0+ and .NET Framework 4.6.1+ runtimes. However, Ocelot integrates with anything that speaks HTTP and runs on the platforms which .NET Core supports: Linux, macOS, and Windows. Ocelot can run in a docker container and be hosted in Azure Kuberentes Service, or other public clouds.

Ocelot is extensible and supports many modern platforms, including Azure Kubernetes Services.  It integrates with open-source packages like Consul, GraphQL, and Netflix’s Eureka. Consider Ocelot for simple cloud-native applications that don’t require the rich feature-set of a commercial API gateway.

## Azure API Management

For moderate to large-scale cloud-native systems, you may consider [Azure API Management](https://azure.microsoft.com/services/api-management/). It's a cloud-based service that not only solves your API Gateway needs, but provides a rich developer and administrative experience. API Management is shown in Figure 4-4. 

![Azure API Management](./media/azure-api-management.png)
**Figure 4-4**. Azure API Management

To start, API Management exposes a gateway server that sits in front of backend services and manages access to them. 

For developers, API Management offers a developer portal that provides access to services, documentation, and sample code for invoking them. Developers can use Swagger/Open API to inspect service endpoints and log bugs and track issues. 

The publisher portal exposes a management dashboard where administrators create APIs and manage their behavior. Service access can be granted, service health monitored, and telemetry gathered. Administrators apply *policies* to each endpoint to affect behavior. [Policies](https://docs.microsoft.com/azure/api-management/api-management-howto-policies) are pre-built statements that execute sequentially for service each call.  They're configured for the inbound call, outbound call, or invoked upon an error. The product ships with a large number of prebuilt [policies](https://docs.microsoft.com/azure/api-management/api-management-policies). 

Policies can be applied at different scopes as to enable deterministic ordering when combining policies.


Here are examples of how policies can change service behavior:  

- Restrict service access.

- Enforce authentication.
  
- Throttle calls from a single source, if necessary.

- Enable caching.

- Block calls from specific IP addresses.

- Control the flow of the service.

- Convert requests from SOAP to REST or between different data formats, such as from XML to JSON.

Azure API Management can access backend services hosted anywhere – including services in the cloud and in your data center. It supports both REST and SOAP APIs and works across any development platform (.NET, Java, Golang, and so on). Even other Azure services can be exposed through API Management. You could place a managed API on top of an Azure backing service like [Azure Service Bus](https://azure.microsoft.com/services/service-bus/) or [Azure Logic Apps](https://azure.microsoft.com/services/logic-apps/).

Azure API Management is available across [four different pricing tiers](https://azure.microsoft.com/pricing/details/api-management/):

- Developer

- Basic

- Standard

- Premium

The Developer tier is meant for non-production workloads and evaluation. The other tiers offer progressively more power, features, and service level agreements (SLAs) with the Premium tier providing Azure Virtual Network and multi-region support. All tiers have a fixed price per hour. 

Recently, Microsoft announced a [API Management serverless tier](https://azure.microsoft.com/blog/announcing-azure-api-management-for-serverless-architectures/) for Azure API Management. Referred to as the *consumption pricing tier*, the service is a variant of API Management designed and implemented around serverless principles. Unlike the “pre-allocated” pricing tiers previously shown, the consumption tier provides “serverless” functionality with instant provisioning and pay-per-Action pricing.

> At the time of writing, this service is in preview in the Azure cloud.

It enables API Gateway features for the following use cases:

- Microservices implemented using serverless technologies such as Functions and Logic Apps.
- Azure backing service resources such as Service Bus queues and topics, Azure storage, and others.
- Microservices where traffic has occasional large spikes but remains low the majority of the time. 

Consumption tier uses the same underlying service API Management components, but employs an entirely different architecture, based on shared, dynamically allocated resources. It aligns perfectly with the serverless computing model: no infrastructure to manage, no idle capacity, high-availability, automatic scaling, and usage-based pricing. The new pricing tier is a great choice for solutions that involve exposing serverless resources as APIs. 

## SignalR Services

What was once a popular ASP.NET library to implement two-way communication between backend services and clients has now become an Azure service. Azure SignalR Service simplifies two-way communication that is real time for HTTP-based applications. Once enabled, a cloud-based HTTP service can push content updates directly to connected clients, including browser, mobile and desktop applications. As a result, clients are updated without the need to poll the server. Applications that require high frequency updates such as chat, gaming, and financial apps are great candidates for this service.

Manually implementing real-time connectivity would require complex infrastructure to ensure reliable messaging to connected clients. You could find yourself managing an instance of Azure Redis Cache along with load balancers configured with sticky sessions for client affinity. Instead, these concerns are abstracted by Azure SignalR Service, freeing you to focus on application features, not infrastructure plumbing.

Azure SignalR abstracts the transport technologies that create real-time connectivity, including WebSockets, Server-Side Events, and Long Polling. Developers focus on sending messages to all or specific subsets of connected clients.

Figure 4-6 shows a set of HTTP Clients connecting to a Cloud App with Azure SignalR enabled.

![Azure SignalR](./media/azure-signalr-service.png)

**Figure 4-6**. Azure SignalR

Azure SignalR Service can be integrated with other Azure services opening up many possibilities.



>[!div class="step-by-step"]
>[Previous](communication-patterns.md)
>[Next](cross-service-communication.md)
