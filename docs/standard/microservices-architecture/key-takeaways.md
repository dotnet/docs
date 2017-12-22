---
title: key takeaways
description: .NET Microservices Architecture for Containerized .NET Applications | key takeaways
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/26/2017
ms.prod: .net-core
ms.technology: dotnet-docker
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Key Takeaways

As a summary and key takeaways, the following are the most important conclusions from this guide.

**Benefits of using containers.** Container-based solutions provide the important benefit of cost savings because containers are a solution to deployment problems caused by the lack of dependencies in production environments. Containers significantly improve DevOps and production operations.

**Containers will be ubiquitous.** Docker-based containers are becoming the de facto standard in the container industry, supported by the most significant vendors in the Windows and Linux ecosystems. This includes Microsoft, Amazon AWS, Google, and IBM. In the near future, Docker will probably be ubiquitous in both cloud and on-premises datacenters.

**Containers as a unit of deployment.** A Docker container is becoming the standard unit of deployment for any server-based application or service.

**Microservices.** The microservices architecture is becoming the preferred approach for distributed and large or complex mission-critical applications based on multiple independent subsystems in the form of autonomous services. In a microservice-based architecture, the application is built as a collection of services that can be developed, tested, versioned, deployed, and scaled independently; this can include any related autonomous database.

**Domain-driven design and SOA.** The microservices architecture patterns derive from service-oriented architecture (SOA) and domain-driven design (DDD). When you design and develop microservices for environments with evolving business rules shaping a particular domain, it is important to take into account DDD approaches and patterns.

**Microservices challenges.** Microservices offer many powerful capabilities, like independent deployment, strong subsystem boundaries, and technology diversity. However, they also raise many new challenges related to distributed application development, such as fragmented and independent data models, resilient communication between microservices, eventual consistency, and operational complexity that results from aggregating logging and monitoring information from multiple microservices. These aspects introduce a higher level of complexity than a traditional monolithic application. As a result, only specific scenarios are suitable for microservice-based applications. These include large and complex applications with multiple evolving subsystems; in these cases, it is worth investing in a more complex software architecture, because it will provide better long-term agility and application maintenance.

**Containers for any application.** Containers are convenient for microservices, but are not exclusive for them. Containers can also be used with monolithic applications, including legacy applications based on the traditional .NET Framework and modernized through Windows Containers. The benefits of using Docker, such as solving many deployment-to-production issues and providing state of the art Dev and Test environments, apply to many different types of applications.

**CLI versus IDE.** With Microsoft tools, you can develop containerized .NET applications using your preferred approach. You can develop with a CLI and an editor-based environment by using the Docker CLI and Visual Studio Code. Or you can use an IDE-focused approach with Visual Studio and its unique features for Docker, such as like being able to debug multi-container applications.

**Resilient cloud applications.** In cloud-based systems and distributed systems in general, there is always the risk of partial failure. Since clients and services are separate processes (containers), a service might not be able to respond in a timely way to a client’s request. For example, a service might be down because of a partial failure or for maintenance; the service might be overloaded and responding extremely slowly to requests; or it might simply not be accessible for a short time because of network issues. Therefore, a cloud-based application must embrace those failures and have a strategy in place to respond to those failures. These strategies can include retry policies (resending messages or retrying requests) and implementing circuit-breaker patterns to avoid exponential load of repeated requests. Basically, cloud-based applications must have resilient mechanisms—either custom ones, or ones based on cloud infrastructure, such as high-level frameworks from orchestrators or service buses.

**Security.** Our modern world of containers and microservices can expose new vulnerabilities. Basic application security is based on authentication and authorization; multiple ways exist to implement these. However, container security includes additional key components that result in inherently safer applications. A critical element of building safer apps is having a secure way of communicating with other apps and systems, something that often requires credentials, tokens, passwords, and other types of confidential information—usually referred to as application secrets. Any secure solution must follow security best practices, such as encrypting secrets while in transit; encrypting secrets at rest; and preventing secrets from unintentionally leaking when consumed by the final application. Those secrets need to be stored and kept safe somewhere. To help with security, you can take advantage of your chosen orchestrator’s infrastructure, or of cloud infrastructure like Azure Key Vault and the ways it provides for application code to use it.

**Orchestrators.** Container-based orchestrators like the ones provided in Azure Container Service (Kubernetes, Mesos DC/OS, and Docker Swarm) and Azure Service Fabric are indispensable for any production-ready microservice-based application and for any multi-container application with significant complexity, scalability needs, and constant evolution. This guide has introduced orchestrators and their role in microservice-based and container-based solutions. If your application needs are moving you toward complex containerized apps, you will find it useful to seek out additional resources for learning more about orchestrators

>[!div class="step-by-step"]
[Previous] (secure-net-microservices-web-applications/azure-key-vault-protects-secrets.md)
