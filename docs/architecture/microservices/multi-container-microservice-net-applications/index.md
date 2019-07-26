---
title: Designing and Developing Multi Container and Microservice Based .NET Applications
description: .NET Microservices Architecture for Containerized .NET Applications | Understand the external architecture for Designing and Developing Multi Container and Microservice Based .NET Applications.
ms.date: 10/02/2018
---
# Designing and Developing Multi-Container and Microservice-Based .NET Applications

*Developing containerized microservice applications means you are building multi-container applications. However, a multi-container application could also be simpler—for example, a three-tier application—and might not be built using a microservice architecture.*

Earlier we raised the question "Is Docker necessary when building a microservice architecture?" The answer is a clear no. Docker is an enabler and can provide significant benefits, but containers and Docker are not a hard requirement for microservices. As an example, you could create a microservices-based application with or without Docker when using Azure Service Fabric, which supports microservices running as simple processes or as Docker containers.

However, if you know how to design and develop a microservices-based application that is also based on Docker containers, you will be able to design and develop any other, simpler application model. For example, you might design a three-tier application that also requires a multi-container approach. Because of that, and because microservice architectures are an important trend within the container world, this section focuses on a microservice architecture implementation using Docker containers.

>[!div class="step-by-step"]
>[Previous](../docker-application-development-process/docker-app-development-workflow.md)
>[Next](microservice-application-design.md)
