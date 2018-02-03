---
title: Handling partial failure
description: .NET Microservices Architecture for Containerized .NET Applications | Handling partial failure
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
# Handling partial failure

In distributed systems like microservices-based applications, there is an ever-present risk of partial failure. For instance, a single microservice/container can fail or might not be available to respond for a short time, or a single VM or server can crash. Since clients and services are separate processes, a service might not be able to respond in a timely way to a client’s request. The service might be overloaded and responding extremely slowly to requests, or might simply not be accessible for a short time because of network issues.

For example, consider the Order details page from the eShopOnContainers sample application. If the ordering microservice is unresponsive when the user tries to submit an order, a bad implementation of the client process (the MVC web application)—for example, if the client code were to use synchronous RPCs with no timeout—would block threads indefinitely waiting for a response. In addition to creating a bad user experience, every unresponsive wait consumes or blocks a thread, and threads are extremely valuable in highly scalable applications. If there are many blocked threads, eventually the application’s runtime can run out of threads. In that case, the application can become globally unresponsive instead of just partially unresponsive, as show in Figure 10-1.

![](./media/image1.png)

**Figure 10-1**. Partial failures because of dependencies that impact service thread availability

In a large microservices-based application, any partial failure can be amplified, especially if most of the internal microservices interaction is based on synchronous HTTP calls (which is considered an anti-pattern). Think about a system that receives millions of incoming calls per day. If your system has a bad design that is based on long chains of synchronous HTTP calls, these incoming calls might result in many more millions of outgoing calls (let’s suppose a ratio of 1:4) to dozens of internal microservices as synchronous dependencies. This situation is shown in Figure 10-2, especially dependency \#3.

![](./media/image2.png)

**Figure 10-2**. The impact of having an incorrect design featuring long chains of HTTP requests

Intermittent failure is virtually guaranteed in a distributed and cloud based system, even if every dependency itself has excellent availability. This should be a fact you need to consider.

If you do not design and implement techniques to ensure fault tolerance, even small downtimes can be amplified. As an example, 50 dependencies each with 99.99% of availability would result in several hours of downtime each month because of this ripple effect. When a microservice dependency fails while handling a high volume of requests, that failure can quickly saturate all available request threads in each service and crash the whole application.

![](./media/image3.png)

**Figure 10-3**. Partial failure amplified by microservices with long chains of synchronous HTTP calls

To minimize this problem, in the section "*Asynchronous microservice integration enforce microservice’s autonomy*” (in the architecture chapter), we encouraged you to use asynchronous communication across the internal microservices. We briefly explain more in the next section.

In addition, it is essential that you design your microservices and client applications to handle partial failures—that is, to build resilient microservices and client applications.


>[!div class="step-by-step"]
[Previous] (index.md)
[Next] (partial-failure-strategies.md)
