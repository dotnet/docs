---
title: Mapping eShopOnContainers to Azure Services
description: Architecting Cloud Native .NET Apps for Azure | Mapping eShopOnContainers to Azure Services
ms.date: 06/30/2019
---
# Mapping eShopOnContainers to Azure Services

Although not required, Azure is very well-suited to supporting the eShopOnContainers because the project was built to be a cloud native application. The application is built with .NET Core, so it's capable of running on Linux or Windows containers depending on the Docker host. The application is made up of multiple autonomous microservices, each with its own data. The different microservices showcase different approaches, ranging from simple CRUD operations to more complex DDD and CQRS patterns. Microservices communicate with clients over HTTP and with one another via message-based communication. The application supports multiple platforms for clients as well, since it leverages HTTP as a standard communication protocol and includes ASP.NET Core apps as well as Xamarin mobile apps that run on Android, iOS, and Windows platforms.

The application's architecture is shown in Figure 3-X. On the left are the client apps, broken up into mobile, traditional Web, and Web Single Page Application (SPA) flavors. On the right are the server-side side components that make up the system, each of which can be hosted in Docker containers and Kubernetes clusters. The traditional web app is powered by the ASP.NET Core MVC application shown in yellow. This app and the mobile and web SPA applications, communicates with the individual microservices through one or more API gateways. The API gateways follow the "back-ends for front-ends" (BFF) pattern, meaning that each gateway is designed to support a given front end client. The individual microservices are listed to the right of the API gateways, and include both business logic and some kind of persistence store. The different services make use of SQL Server databases, Redis cache instances, and MongoDB/CosmosDB stores. On the far right is the system's Event Bus, which is used for communication between the microservices.

![eShopOnContainers Architecture](media/eshoponcontainers-architecture.png)
**Figure 3-X**. The eShopOnContainers Architecture.

The server-side components of this architecture all map easily to Azure services.

## Container orchestration and clustering

The application's container-hosted services, from ASP.NET Core MVC apps to individual Catalog and Ordering microservices, can all be hosted and managed in Azure Kubernetes Service (AKS). The application can run locally on Docker and Kubernetes, and the same containers can then be deployed to staging and production environments hosted in AKS. This process can be completely automated as we'll see in the next section.

AKS provides management services for individual clusters of containers. The application will deploy separate AKS clusters for each microservice shown in the architecture diagram above. This approach allows the individual services to each scale independently according to its resource demands. Each microservice can also be deployed independently, and ideally such deployments should incur zero system downtime.

## API Gateway

Azure API Management

## Data

SQL Server using Azure SQL
Redis
MongoDB/CosmosDB

## EventBus

The application uses events to communicate changes between different services. This functionality can be implemented with a variety of implementations. When hosted in Azure, the application would leverage [Azure Service Bus](https://docs.microsoft.com/azure/service-bus/) for its messaging.

## Resiliency

https://docs.microsoft.com/en-us/dotnet/architecture/microservices/architect-microservice-container-applications/resilient-high-availability-microservices
Health Checks
Azure Monitor
Azure Diagnostics
Logging

## References

- [The eShopOnContainers Architecture](https://github.com/dotnet-architecture/eShopOnContainers/wiki/Architecture)
- [Orchestrating microservices and multi-container applications for high scalability and availability](https://docs.microsoft.com/dotnet/architecture/microservices/architect-microservice-container-applications/scalable-available-multi-container-microservice-applications)



>[!div class="step-by-step"]
>[Previous](introduce-eshoponcontainers-reference-app.md)
>[Next](host-eshoponcontainers-application.md)
