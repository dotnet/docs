---
title: .NET Microservices Architecture key takeaways
description: Get the key takeaways from the .NET Microservices Architecture for Containerized .NET Applications guide/e-book, to have a quick look at the high-level issues involved when using a microservices architecture, like benefits and drawbacks, DDD patterns for design and development, as well as resiliency, security, and the use of orchestrators.
ms.date: 10/19/2018
---
# .NET Microservices Architecture key takeaways

As a summary and key takeaways, the following are the most important conclusions from this guide.

**Benefits of using containers.** Container-based solutions provide important cost savings because they help reduce deployment problems caused by failing dependencies in production environments. Containers significantly improve DevOps and production operations.

**Containers will be ubiquitous.** Docker-based containers are becoming the de facto standard in the industry, supported by key vendors in the Windows and Linux ecosystems, such as Microsoft, Amazon AWS, Google, and IBM. Docker will probably soon be ubiquitous in both the cloud and on-premises datacenters.

**Containers as a unit of deployment.** A Docker container is becoming the standard unit of deployment for any server-based application or service.

**Microservices.** The microservices architecture is becoming the preferred approach for distributed and large or complex mission-critical applications based on many independent subsystems in the form of autonomous services. In a microservice-based architecture, the application is built as a collection of services that are developed, tested, versioned, deployed, and scaled independently. Each service can include any related autonomous database.

**Domain-driven design and SOA.** The microservices architecture patterns derive from service-oriented architecture (SOA) and domain-driven design (DDD). When you design and develop microservices for environments with evolving business needs and rules, it's important to consider DDD approaches and patterns.

**Microservices challenges.** Microservices offer many powerful capabilities, like independent deployment, strong subsystem boundaries, and technology diversity. However, they also raise many new challenges related to distributed application development, such as fragmented and independent data models, resilient communication between microservices, eventual consistency, and operational complexity that results from aggregating logging and monitoring information from multiple microservices. These aspects introduce a much higher complexity level than a traditional monolithic application. As a result, only specific scenarios are suitable for microservice-based applications. These include large and complex applications with multiple evolving subsystems. In these cases, it's worth investing in a more complex software architecture, because it will provide better long-term agility and application maintenance.

**Containers for any application.** Containers are convenient for microservices, but can also be useful for monolithic applications based on the traditional .NET Framework, when using Windows Containers. The benefits of using Docker, such as solving many deployment-to-production issues and providing state-of-the-art Dev and Test environments, apply to many different types of applications.

**CLI versus IDE.** With Microsoft tools, you can develop containerized .NET applications using your preferred approach. You can develop with a CLI and an editor-based environment by using the Docker CLI and Visual Studio Code. Or you can use an IDE-focused approach with Visual Studio and its unique features for Docker, such as multi-container debugging.

**Resilient cloud applications.** In cloud-based systems and distributed systems in general, there is always the risk of partial failure. Since clients and services are separate processes (containers), a service might not be able to respond in a timely way to a client's request. For example, a service might be down because of a partial failure or for maintenance; the service might be overloaded and responding slowly to requests; or it might not be accessible for a short time because of network issues. Therefore, a cloud-based application must embrace those failures and have a strategy in place to respond to those failures. These strategies can include retry policies (resending messages or retrying requests) and implementing circuit-breaker patterns to avoid exponential load of repeated requests. Basically, cloud-based applications must have resilient mechanisms—either based on cloud infrastructure or custom, as the high-level ones provided by  orchestrators or service buses.

**Security.** Our modern world of containers and microservices can expose new vulnerabilities. There are several ways to implement basic application security, based on authentication and authorization. However, container security must consider additional key components that result in inherently safer applications. A critical element of building safer apps is having a secure way of communicating with other apps and systems, something that often requires credentials, tokens, passwords, and the like, commonly referred to as application secrets. Any secure solution must follow security best practices, such as encrypting secrets while in transit and at rest, and preventing secrets from leaking when consumed by the final application. Those secrets need to be stored and kept safely, as when using Azure Key Vault.

**Orchestrators.** Container-based orchestrators, such as Azure Kubernetes Service and Azure Service Fabric are key part of any significant microservice and container-based application. These applications carry with them high complexity, scalability needs, and go through constant evolution. This guide has introduced orchestrators and their role in microservice-based and container-based solutions. If your application needs are moving you toward complex containerized apps, you will find it useful to seek out additional resources for learning more about orchestrators.

>[!div class="step-by-step"]
>[Previous](secure-net-microservices-web-applications/azure-key-vault-protects-secrets.md)
