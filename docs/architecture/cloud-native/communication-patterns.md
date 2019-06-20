---
title: Cloud Native Communication Patterns
description: Architecting Cloud Native .NET Apps for Azure | Cloud Native Communication Patterns
ms.date: 06/30/2019
---
# Cloud Native Communication Patterns

In a traditional monolithic application, functionality is implemented as modules that all run in the same process. What this means is that all application code shares the same executable space within the operating system. It can be efficient as everything runs together, but poor in terms of  scalability.

When constructing cloud native systems, we implement a microservice-based architecture which consists of a large number of small, independent, self-contained services, each running in its own separate process, typically deployed inside a container to a *cluster*.

A cluster represents a pool of virtual machines that federated together form a highly-available environment. Clusters are typically managed by an orchestrator which is responsible for deploying and managing the various containerized microservices. Figure 4-1, shown below, depicts a Kubernetes cluster as deployed in the Azure cloud with the fully-managed [Azure Kubernetes Services](https://docs.microsoft.com/en-us/azure/aks/intro-kubernetes).

![A Kubernetes cluster in Azure](media/kubernetes-cluster-in-azure.png)
**Figure 4-1**. A Kubernetes cluster in Azure

While such an approach enables each microservice to evolve, deploy, and scale independently as needed, it adds a great deal of complexity to both your architecture and infrastructure. For example, many new considerations come about:

- Each service now communicates over a network protocol

- Network congestion, latency and transient faults now become an issue

- Resiliency (i.e., retrying failed requests) becomes required

- Some calls must be [idempotent](https://www.restapitutorial.com/lessons/idempotency.html)

- Each service must authenticate and authorize each call

- Message encryption/decryption become important

- Each message must be serialized and then deserialized - which can be     expensive

In this module, we'll first address communication between front end applications and back end microservices and then to microservice-to-microservice communication.

>[!div class="step-by-step"]
>[Previous](centralized-configuration.md)
>[Next](cross-service-communication.md)
