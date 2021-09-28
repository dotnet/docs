---
title: Implement resilient applications
description: Learn about resilience, a core concept in a microservices architecture. You must know how to handle transient failures gracefully when they occur.
ms.date: 01/30/2020
---
# Implement resilient applications

*Your microservice and cloud-based applications must embrace the partial failures that will certainly occur eventually. You must design your application to be resilient to those partial failures.*

Resiliency is the ability to recover from failures and continue to function. It isn't about avoiding failures but accepting the fact that failures will happen and responding to them in a way that avoids downtime or data loss. The goal of resiliency is to return the application to a fully functioning state after a failure.

It's challenging enough to design and deploy a microservices-based application. But you also need to keep your application running in an environment where some sort of failure is certain. Therefore, your application should be resilient. It should be designed to cope with partial failures, like network outages or nodes or VMs crashing in the cloud. Even microservices (containers) being moved to a different node within a cluster can cause intermittent short failures within the application.

The many individual components of your application should also incorporate health monitoring features. By following the guidelines in this chapter, you can create an application that can work smoothly in spite of transient downtime or the normal hiccups that occur in complex and cloud-based deployments.

>[!IMPORTANT]
> eShopOnContainer had been using the [Polly library](https://thepollyproject.azurewebsites.net/) to implement resiliency using [Typed Clients](./use-httpclientfactory-to-implement-resilient-http-requests.md) up until the release 3.0.0.
>
> Starting with release 3.0.0, the HTTP calls resiliency is implemented using a [Linkerd mesh](https://linkerd.io/), that handles retries in a transparent and configurable fashion, within a Kubernetes cluster, without having to handle those concerns in the code.
>
> The Polly library is still used to add resilience to database connections, specially while starting up the services.

>[!WARNING]
> All code samples and images in this section were valid before using Linkerd and are not updated to reflect the current actual code. So they make sense in the context of this section.

>[!div class="step-by-step"]
>[Previous](../microservice-ddd-cqrs-patterns/microservice-application-layer-implementation-web-api.md)
>[Next](handle-partial-failure.md)
