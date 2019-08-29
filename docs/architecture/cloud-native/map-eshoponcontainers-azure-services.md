---
title: Mapping eShopOnContainers to Azure Services
description: Mapping eShopOnContainers to Azure Services like Azure Kubernetes Service, API Gateway, and Azure Service Bus.
ms.date: 06/30/2019
---
# Mapping eShopOnContainers to Azure Services

Although not required, Azure is very well-suited to supporting the eShopOnContainers because the project was built to be a cloud-native application. The application is built with .NET Core, so it's capable of running on Linux or Windows containers depending on the Docker host. The application is made up of multiple autonomous microservices, each with its own data. The different microservices showcase different approaches, ranging from simple CRUD operations to more complex DDD and CQRS patterns. Microservices communicate with clients over HTTP and with one another via message-based communication. The application supports multiple platforms for clients as well, since it leverages HTTP as a standard communication protocol and includes ASP.NET Core apps as well as Xamarin mobile apps that run on Android, iOS, and Windows platforms.

The application's architecture is shown in Figure 3-5. On the left are the client apps, broken up into mobile, traditional Web, and Web Single Page Application (SPA) flavors. On the right are the server-side side components that make up the system, each of which can be hosted in Docker containers and Kubernetes clusters. The traditional web app is powered by the ASP.NET Core MVC application shown in yellow. This app and the mobile and web SPA applications, communicates with the individual microservices through one or more API gateways. The API gateways follow the "backends for front ends" (BFF) pattern, meaning that each gateway is designed to support a given front end client. The individual microservices are listed to the right of the API gateways, and include both business logic and some kind of persistence store. The different services make use of SQL Server databases, Redis cache instances, and MongoDB/CosmosDB stores. On the far right is the system's Event Bus, which is used for communication between the microservices.

![eShopOnContainers Architecture](media/eshoponcontainers-architecture.png)
**Figure 3-5**. The eShopOnContainers Architecture.

The server-side components of this architecture all map easily to Azure services.

## Container orchestration and clustering

The application's container-hosted services, from ASP.NET Core MVC apps to individual Catalog and Ordering microservices, can all be hosted and managed in Azure Kubernetes Service (AKS). The application can run locally on Docker and Kubernetes, and the same containers can then be deployed to staging and production environments hosted in AKS. This process can be completely automated as we'll see in the next section.

AKS provides management services for individual clusters of containers. The application will deploy separate AKS clusters for each microservice shown in the architecture diagram above. This approach allows each individual service to each independently according to its resource demands. Each microservice can also be deployed independently, and ideally such deployments should incur zero system downtime.

## API Gateway

The eShopOnContainers application has multiple front end clients and multiple different backend services. There is no one-to-one correspondence between the client applications and the microservices that support them. In such a scenario, there may be a great deal of complexity when writing client software to interface with the various backend services in a secure manner. Each client would need to address this complexity on its own, resulting in duplication and many places in which to make updates as services change or new policies are implemented.

Azure API Management (APIM) helps organizations publish APIs in a consistent, manageable fashion. APIM consists of three components: the API Gateway, and administration portal (the Azure portal), and a developer portal.

The API Gateway accepts API calls and routes them to the appropriate backend API. It can also provide additional services like verification of API keys or JWT tokens and API transformation on the fly without code modifications (for instance, to accommodate clients expecting an older interface).

The Azure portal is where you define the API schema and package different APIs into products. You also configure user access, view reports, and configure policies for quotas or transformations.

The developer portal serves as the main resource for developers. It provides developers with API documentation, an interactive test console, and reports on their own usage. Developers also use the portal to create and manage their own accounts, including subscription and API key support.

Using APIM, the eShopOnContainers application exposes several different products of services, each providing a backend for a particular front end client.

## Data

The various backend services used by eShopOnContainers have different storage requirements. Several microservices use SQL Server databases. The Basket microservice leverages a Redis cache for its persistence. The Locations microservice expects a MongoDB API for its data. Azure supports each of these data formats.

For SQL Server database support, Azure has products for everything from single databases up to highly scalable SQL Database elastic pools. Individual microservices can be configured to communicate with their own individual SQL Server databases quickly and easily. These can be scaled as needed to support each separate microservice according to its needs.

The eShopOnContainers application stores the user's current shopping basket between requests. This is managed by the Basket microservice which stores the data in a Redis cache. In development, this cache can be deployed in a container, while in production in can leverage Azure Cache for Redis. Azure Cache for Redis is a fully managed service offering high performance and reliability without the need to deploy and manage your own Redis instances or containers.

The Locations microservice uses a MongoDB NoSQL database for its persistence. During development, this can be deployed in its own container, while in production the service can leverage [Azure Cosmos DB's API for MongoDB](https://docs.microsoft.com/azure/cosmos-db/mongodb-introduction). One of the benefits of Azure Cosmos DB is its ability to leverage multiple different communication protocols, including a SQL API as well as common NoSQL APIs including MongoDB (as well as Cassandra, Gremlin, and Azure Table Storage). Azure Cosmos DB offers a fully managed and globally distributed database as a service that can scale to meet the needs of the services that use it.

Distributed data in cloud-native applications is covered in more detail in [chapter 5](distributed-data.md).

## Event Bus

The application uses events to communicate changes between different services. This functionality can be implemented with a variety of implementations, and locally the eShopOnContainers application uses [RabbitMQ](https://www.rabbitmq.com/). When hosted in Azure, the application would leverage [Azure Service Bus](https://docs.microsoft.com/azure/service-bus/) for its messaging. Azure Service Bus is a fully managed integration message broker that allows applications and services to communicated with one another in a decoupled, reliable, asynchronous manner. Azure Service Bus supports individual queues as well as separate *topics* to support publisher-subscriber scenarios. The eShopOnContainers application would leverage topics with Azure Service Bus to support distributing messages from one microservice to any other microservice that needed to react to a given message.

## Resiliency

Once deployed to production, the eShopOnContainers application would be able to take advantage of several Azure services available to improve its resiliency. The application publishes health checks, which can be integrated with Application Insights to provide reporting and alerts based on the app's availability. Azure resources also provide diagnostic logs that can be used to identify and correct bugs and performance issues. Resource logs provide detailed information on when and how different Azure resources are used by the application. You'll learn more about cloud-native resiliency features in [chapter 6](resiliency.md).

## References

- [The eShopOnContainers Architecture](https://github.com/dotnet-architecture/eShopOnContainers/wiki/Architecture)
- [Orchestrating microservices and multi-container applications for high scalability and availability](https://docs.microsoft.com/dotnet/architecture/microservices/architect-microservice-container-applications/scalable-available-multi-container-microservice-applications)
- [Azure API Management](https://docs.microsoft.com/azure/api-management/api-management-key-concepts)
- [Azure SQL Database Overview](https://docs.microsoft.com/azure/sql-database/sql-database-technical-overview)
- [Azure Cache for Redis](https://azure.microsoft.com/services/cache/)
- [Azure Cosmos DB's API for MongoDB](https://docs.microsoft.com/azure/cosmos-db/mongodb-introduction)
- [Azure Service Bus](https://docs.microsoft.comazure/service-bus-messaging/service-bus-messaging-overview)
- [Azure Monitor overview](https://docs.microsoft.com/azure/azure-monitor/overview)

>[!div class="step-by-step"]
>[Previous](introduce-eshoponcontainers-reference-app.md)
>[Next](deploy-eshoponcontainers-azure.md)
