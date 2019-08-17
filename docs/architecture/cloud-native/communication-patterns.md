---
title: Cloud native communication patterns
description: Learn about key service communication concerns in cloud-native applications
author: robvet
ms.date: 08/16/2019
---
# Cloud-native communication patterns

When constructing a cloud native system, communication among services is a significant design decision. For example, how do front-end client applications communicate with a microservices backend? And how do backend microservices communicate with each other? What are the principles, patterns, and best practices to consider when implementing communication in cloud-native applications?

[.NET Microservices: Architecture for Containerized .NET Applications](https://docs.microsoft.com/dotnet/standard/microservices-architecture/) is a free guidance eBook from Microsoft. It provides a wealth of coverage on communication patterns for microservice applications. In this chapter, we provide a high-level overview of these patterns along with implementation options available in the Azure cloud.

## Communication considerations

In a monolithic application, functionality is typically implemented in a single code base. The codebase executes in a single process sharing the same executable space within the operating system. This approach has performance advantages as everything runs together in shared memory, but results in tightly coupled code that becomes difficult to maintain, evolve, and scale.

Cloud-native systems implement a microservice-based architecture with many small, independent services. Each service runs in a separate process, typically deployed in a container running inside a *cluster*.

A cluster represents a pool of virtual machines that are federated together to form a highly available environment. They're managed with an orchestration tool, which is responsible for deploying and managing the containerized microservices. Figure 4-1 shows a Kubernetes cluster deployed in the Azure cloud with the fully managed [Azure Kubernetes Services](https://docs.microsoft.com/azure/aks/intro-kubernetes).

![A Kubernetes cluster in Azure](media/kubernetes-cluster-in-azure.png)

**Figure 4-1**. A Kubernetes cluster in Azure

While this approach enables each microservice to evolve, deploy, and scale independently, it adds a great deal of complexity to your architecture and infrastructure. For example, many new considerations come about:

- Each service communicates over a network protocol.

- Network congestion, latency, and transient faults are a constant concern.

- Resiliency (that is, retrying failed requests) is essential.

- Some calls must be [idempotent](https://www.restapitutorial.com/lessons/idempotency.html).

- Each service must authenticate and authorize calls.

- Each message must be serialized and then deserialized - which can be expensive.

- Message encryption/decryption become considerations.

In this module, we'll first address communication between front-end applications and back-end microservices and then to microservice-to-microservice communication.

>[!div class="step-by-step"]
>[Previous](centralized-configuration.md)
>[Next](front-end-communication.md)
