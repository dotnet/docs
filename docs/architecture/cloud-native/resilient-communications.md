---
title: Resilient communication
description: Learn about how service mesh technologies streamline cloud-native microservice communication
author: robvet
ms.date: 09/08/2019
---

# Resilient communications

Throughout this chapter, we've explored the challenges of microservice communication. We said that development teams need to be sensitive to how backend services communicate with each other. Ideally, the less inter-service communication, the better. However, avoidance isn't always possible as backend services often rely on one another to complete operations.

We explored a number of different approaches for implementing both direct synchronous HTTP communication and asynchronous messaging.

In each of the cases, the developer is burdened with implementing communication code. Communication code is complex and time intensive. Incorrect decisions can lead to significant performance issues.

## Service mesh

A more modern approach to microservice communication centers around a new and rapidly evolving technology entitled *Service Mesh*. A [service mesh](https://www.nginx.com/blog/what-is-a-service-mesh/) is a configurable infrastructure layer with built-in capabilities to handle service communication, resiliency, and many cross-cutting concerns. It decouples these concerns, moves them out of your application code and into the service mesh technology. Communication is abstracted away from your microservices.

A key component of a service mesh is a proxy. In a cloud-native application, an instance of a proxy is typically colocated with each microservice. While they execute in separate processes, the two are closely linked and share the same lifecycle. This pattern, known as the [Sidecar pattern](https://docs.microsoft.com/azure/architecture/patterns/sidecar), and is shown in Figure 4-23.

![Service mesh with a side car](media/service-mesh-with-side-car.png)

**Figure 4-23**. Service mesh with a side car

Note in the previous figure how messages are intercepted by a proxy that runs alongside each microservice. Each proxy can be configured with traffic rules specific to the microservice. It understands messages and can route them across your services and the outside world.

In chapter 6, we deep-dive into Service Mesh technologies including a discussion on its architecture and available open-source implementations.

## Summary

In this chapter, we discussed cloud-native communication patterns. We started by examining how front-end clients communicate with backend microservices. Along the way, we talked about API Gateway platforms and real-time communication. We then looked at how microservcies communicate with other microservices. We looked at synchronous HTTP communication and then asynchronous messaging. We covered gRPC, an upcoming technology in the cloud-native world. Finally, we introduced a new and rapidly evolving technology entitled Service Mesh that can streamline microservice communication. 

Special emphasis was on managed Azure services that can help implement communication in cloud-native systems:

- [Azure Application Gateway](https://docs.microsoft.com/azure/application-gateway/overview)
- [Azure API Management](https://azure.microsoft.com/services/api-management/)
- [Azure SignalR Service](https://azure.microsoft.com/services/signalr-service/)
- [Azure Storage Queues](https://docs.microsoft.com/azure/storage/queues/storage-queues-introduction)
- [Azure Service Bus](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-messaging-overview)
- [Azure Event Grid](https://docs.microsoft.com/azure/event-grid/overview)
- [Azure Event Hub](https://azure.microsoft.com/services/event-hubs/)

We next move to distributed data in cloud-native systems and the benefits and challenges that it presents.

### References 

- [.NET Microservices: Architecture for Containerized .NET applications](https://dotnet.microsoft.com/download/thank-you/microservices-architecture-ebook)
  
- [Azure SignalR Service, a fully managed service to add real-time functionality](https://azure.microsoft.com/blog/azure-signalr-service-a-fully-managed-service-to-add-real-time-functionality/)
  
- [Azure API Gateway Ingress Controller](https://azure.github.io/application-gateway-kubernetes-ingress/)
  
- [About Ingress in Azure Kubernetes Service (AKS)](https://vincentlauzon.com/2018/10/10/about-ingress-in-azure-kubernetes-service-aks/)
 
- [Practical gRPC](https://www.worldcat.org/title/practical-grpc/oclc/1042342319)

- [gRPC Documentation](https://grpc.io/docs/guides/)

- [gRPC for WCF Developers](https://bing.com) [Mark's gRPC book]
  
- [Comparing gRPC Services with HTTP APIs](https://docs.microsoft.com/en-us/aspnet/core/grpc/comparison?view=aspnetcore-3.0)

>[!div class="step-by-step"]
>[Previous](grpc.md)
>[Next](distributed-data.md) <!-- Next Chapter -->
