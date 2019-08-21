---
title: Mapping eShopOnContainers to Azure Services
description: Architecting Cloud Native .NET Apps for Azure | Mapping eShopOnContainers to Azure Services
ms.date: 06/30/2019
---
# Mapping eShopOnContainers to Azure Services

Although not required, Azure is very well-suited to supporting the eShopOnContainers because the project was built to be a cloud native application. The application is built with .NET Core, so it's capable of running on Linux or Windows containers depending on the Docker host. The application is made up of multiple autonomous microservices, each with its own data. The different microservices showcase different approaches, ranging from simple CRUD operations to more complex DDD and CQRS patterns. Microservices communicate with clients over HTTP and with one another via message-based communication.

architecture diagram: https://github.com/dotnet-architecture/eShopOnContainers/wiki/images/Architecture/eshoponcontainers-arquitecture.png

## Container orchestration and clustering

AKS
https://docs.microsoft.com/en-us/dotnet/architecture/microservices/architect-microservice-container-applications/scalable-available-multi-container-microservice-applications

## EventBus

The application uses events to communicate changes between different services. This functionality can be implemented with a variety of implementations. When hosted in Azure, the application would leverage [Azure Service Bus](https://docs.microsoft.com/azure/service-bus/) for its messaging.

## API Gateway

Azure API Management

## Data

SQL Server using Azure SQL
Redis
MongoDB/CosmosDB

## Resiliency

https://docs.microsoft.com/en-us/dotnet/architecture/microservices/architect-microservice-container-applications/resilient-high-availability-microservices
Health Checks
Azure Monitor
Azure Diagnostics

Reference:
https://github.com/dotnet-architecture/eShopOnContainers/wiki/Architecture


>[!div class="step-by-step"]
>[Previous](introduce-eshoponcontainers-reference-app.md)
>[Next](host-eshoponcontainers-application.md)
