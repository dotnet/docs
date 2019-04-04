---
title: Implementing Resilient Applications
description: Learn about resilience, a core concept in a microservices architecture. You must know how to handle transient failures gracefully because they will occur.
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 10/16/2018
---
# Implement Resilient Applications

*Your microservice and cloud-based applications must embrace the partial failures that will certainly occur eventually. You must design your application to be resilient to those partial failures.*

Resiliency is the ability to recover from failures and continue to function. It isn't about avoiding failures but accepting the fact that failures will happen and responding to them in a way that avoids downtime or data loss. The goal of resiliency is to return the application to a fully functioning state after a failure.

It's challenging enough to design and deploy a microservices-based application. But you also need to keep your application running in an environment where some sort of failure is certain. Therefore, your application should be resilient. It should be designed to cope with partial failures, like network outages or nodes or VMs crashing in the cloud. Even microservices (containers) being moved to a different node within a cluster can cause intermittent short failures within the application.

The many individual components of your application should also incorporate health monitoring features. By following the guidelines in this chapter, you can create an application that can work smoothly in spite of transient downtime or the normal hiccups that occur in complex and cloud-based deployments.

>[!div class="step-by-step"]
>[Previous](../microservice-ddd-cqrs-patterns/microservice-application-layer-implementation-web-api.md)
>[Next](handle-partial-failure.md)