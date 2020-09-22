---
title: Dapr @ 20,000 feet
description: A high-level overview of what dapr is, what it does, and how it works
author: robvet 
ms.date: 09/20/2020
---

# Dapr @ 20,000 feet

Ladies and Gentlemen, please welcome Dapr.

Dapr, or *Distributed Application Runtime*, is the new kid on the block. What started as a <blah>, give some history, has grown to <blah> with a 1.0 release. 

At its core, it's a portable, event-driven runtime. 

 - Portable, in that you write your application once and run it across different public clouds and edge devices. You simply swap out Dapr configuration files for specific service components for the new environment. Dapr can self-host for local development, run inside a VM, a Kubernetes, or Service Fabric cluster. 

 - Event-driven, in that you register external services, invoke them or get invoked without taking a direct reference to them. 

 - Runtime that encapsulates and exposes Dapr functionality via a side car architecture - your application does not include any Dapr runtime code.

Dapr addresses a large gap in modern app development: Simplifying the complexities of distributed microservices applications. Through an architecture of pluggable components, Dapr abstracts 
external service components from the business logic of your application.

Dapr provides a *dynamic glue* that fuses together the plumbing without tightly coupled references, while providing baked-in industry best practices. For example, your service may need to write state to a store. You might consider writing a wrapper around Azure Redis Cache and communicating with it. Howevere, with Dapr, you could make a call to a Dapr state building block, dynamically bind it to Redis Cache, and have Dapr implement the  call to Redis on your behalf. Dapr is responsbile for REdis implementation. Your code has no direct reference to Redis.

Figure 2-x provides a shot of Dapr from 20,000 feet.

![Dapr at 20,000 feet](./media/dapr-high-level.png)
**Figure 2-x**. Dapr at 20,000 feet.

The previous figure presents the end-to-end picture of Dapr.

Dapr is truly an open platform - both cross-platform and open-source. To start, Dapr is written in Google's Golang language. Out of the box, it supports language agnostic RESTful HTTP and gRPC APIs. In the previous figure, note how Dapr provides language typed SDKs for many popular programming platforms, including Go, Node.js, Python, .NET, Java, and JavaScript.   

The blue boxes across the center of the figure present the distributed system building blocks. Each block is independent, enabling you to integrate those services that are helpful for your application.

Dapr version 1.0 features support for interservice communication, state management, pub/sub messaging, actors, observablity, and secrets. Chapter x provides detail about the different building blocks.

Finally, the previous figure shows the portability of Dapr running across many different environments.
 
## Side car architecture



## Sevice mesh




## .NET SDK for Dapr








## What dapr does

Dapr reduces the complexity of constructing microservice and evevnt-driven applications. Companies can implement interservice-communication, state, resource binding, and asynchronous pub/sub messaging with open APIs and extensible components that are community-driven.





provides the *glue* that fuses decoupled service components with your business application b. At the same time, it greatly abstracts the complexity of distributed components and provides baked-in industry best practices. Figure 2-x provides a shot of Dapr from 20,000 feet.



*Dapr is a portable, event-driven runtime that reduces the complexity of building resilient, microservice stateless and stateful applications that run on the cloud and edge and embraces the diversity of languages and developer frameworks.*



## What problems dapr solves

Blah, blah


## What problems dapr doesn't solve

Blah, blah


## Key 

Blah, blah





Template for bullet points:

In the example, we saw some clear benefits:

- Each microservice has an autonomous lifecycle and can evolve independently and deploy frequently.

- Each microservice can scale independently. 




Template for link:

Consider the widely accepted DevOps concept of [Pets vs. Cattle](https://medium.com/@Joachim8675309/devops-concepts-pets-vs-cattle-2380b5aab313). 





Template for two column table:

| Col1 | Col2 |
| :-------- | :-------- |
| [Netflix](https://www.infoq.com/news/2013/06/netflix/) | Has 600+ services in production. Deploys hundred times per day. |
| [Uber](https://eng.uber.com/micro-deploy/) | Has 1,000+ services in production. Deploys several thousand times each week. |
| [WeChat](https://www.cs.columbia.edu/~ruigu/papers/socc18-final100.pdf) | Has 3,000+ services in production. Deploys 1,000 times a day. |




Template for three column table:

|    |  Factor | Explanation  |
| :-------- | :-------- | :-------- |
| 1 | Code Base | A single code base for each microservice, stored in its own repository. Tracked with version control, it can deploy to multiple environments (QA, Staging, Production). |
| 2 | Dependencies | Each microservice isolates and packages its own dependencies, embracing changes without impacting the entire system. |
| 3 | Configurations  | Configuration information is moved out of the microservice and externalized through a configuration management tool outside of the code. The same deployment can propagate across environments with the correct configuration applied.  |


Template for a figure:

![eShopOnContainers Architecture](./media/eshoponcontainers-architecture.png)
**Figure 2-5**. The eShopOnContainers Architecture.

Template for italiczed indented text:

The Cloud Native Computing Foundation provides an [official definition](https://github.com/cncf/foundation/blob/master/charter.md):

> *Cloud-native technologies empower organizations to build and run scalable applications in modern, dynamic environments such as public, private, and hybrid clouds. Containers, service meshes, microservices, immutable infrastructure, and declarative APIs exemplify this approach.*



## Summary

In this chapter, we introduced cloud-native computing. We provided a definition along with the key capabilities that drive a cloud-native application. We looked at the types of applications that might justify this investment and effort.

### References

- [Cloud Native Computing Foundation](https://www.cncf.io/)

- [.NET Microservices: Architecture for Containerized .NET applications](https://dotnet.microsoft.com/download/thank-you/microservices-architecture-ebook)





>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](index.md)
