---
title: Dapr @ 20,000 feet
description: A high-level overview of what dapr is, what it does, and how it works
author: robvet 
ms.date: 09/20/2020
---

# Dapr @ 20,000 feet

Ladies and Gentlemen, please welcome Dapr.

Dapr, or *Distributed Application Runtime*, is not only the new kid on the block, but it's a new way of building distributed applications.

What started as a <blah>, give some history, has grown to <blah> with a 1.0 release. 

Since the announcement of Dapr at the 2019 Microsoft Ignite Conference, Microsoft has cloesly partnered with customers and the open source community to build and extend Dapr. This conceted effort validates the willingness of developers from all backgrounds to solve some of the toughest challenges when developing distributed applications.     

## What is Dapr?

At its core, Dapr is a *portable, event-driven runtime*. 

 - Portable, in that you write your application code once and run it across public clouds and edge devices. You expose a Dapr configuration file. It specifies external service components that you wish to include in your chosen environment. If you wish to move your app, you simply swap out the configuration file with bindings to service components in the new environment. Dapr can self-host for local development, run inside a VM, a Kubernetes, or Service Fabric cluster. 

 - Event-driven, in that you register external services. You can invoke them or have them invoke you - with minimal code and without taking a direct reference to them. 

 - Runtime, in that you encapsulate and expose Dapr functionality via a side car architecture - your application does not include any Dapr runtime code.

## What does Dapr solve?

Dapr addresses a large challenge in modern distributed app development: Complexity. Simplifying the complexities of distributed microservices applications is a key Dapr design goal. Through an architecture of pluggable components, Dapr abstracts external service components from the business logic of your application.

Dapr provides a *dynamic glue* that fuses together service component plumbing without tightly coupled references, while providing baked-in industry best practices. For example, you may have a service that requires a state store. You could write a wrapper around Azure Redis Cache, register, and inject an instance into your system. Instead, with Dapr, you call a Dapr state building block. That block dynamically binds to Redis Cache via configuratoin. You delegate the call to Dapr, which calls Redis on your behalf.  Your code has no SDK, library, or reference to Redis.

Figure 2-x shows Dapr from 20,000 feet.

![Dapr at 20,000 feet](./media/dapr-high-level.png)
**Figure 2-x**. Dapr at 20,000 feet.

The previous figure presents the end-to-end picture of Dapr.

Dapr is truly an open platform - both cross-platform and open-source. To start, Dapr is written in Google's Golang language. Out of the box, it supports language agnostic RESTful HTTP and gRPC APIs. In the previous figure, note how Dapr provides language typed SDKs for many popular programming platforms, including Go, Node.js, Python, .NET, Java, and JavaScript.   

The blue boxes across the center of the figure present the distributed system building blocks. Each block is independent, enabling you to integrate those services that are helpful for your application.

Dapr version 1.0 features support for interservice communication, state management, pub/sub messaging, actors, observablity, and secrets. Chapter x provides detail about the different building blocks.

Finally, the previous figure shows the portability of Dapr running across many different environments.

## Key concepts



### Buildilng blocks

As we saw in Figure 2-x, Dapr exposes a set of `Building Blocks`. Each block is API that abstracts an underlying service component. The APIs represent common services that a distributed application requires:

 - Service-to-service communication
 - Asynchronous messaging
 - State
 - Observability
 - Secrets
 - Actors
 - Resource bindings

Your application invokes building block services by either HTTP or gRPC.

The APIs exposed by building blocks bind to one or more underlying `components` that provide the service implementation. Components are 'pluggable' so that you can swap out one component with the same interface for another. You simply change defintion in the Dapr configuration file.


 > start with Dapr #4 detail



The building blocks in Dapr essentially expose the API that you work with. But the underlying functionality is performed by one or more components that you configure. All components are pluggable so that you can swap out one component with the same interface for another. For
example, if you use Redis as a state store, you can substitute it with Cosmos DB just by
changing the definition of your state component. Having applied then new component
definition, all requests for state store will go to Cosmos DB.

Treats service as a black box

simple—to bring distributed system building blocks to user code through a sidecar container or process.

without polluting that code with any SDKs or libraries; it worked with any programming language

profound impacts on framework design and distributed application development


### Sidecar architecture


### Components


### Configuraiton

## Supported platforms

### Native API vs. platform SDKs

### .NET SDK for Dapr


## Dapr considerations

Dapr is not without challenges. Consider the following:

 - When consuming a service component from Dapr, you're communicating with it through an abstraction. The abstraction can expose common functionality that all such components would expose. Some componenets may have custom features that are not exposed by the Dapr common interfaces. In these sceaniros, you may need to reference the component directly.
 - Overhead. With it's sidecar archtecture, Dapr invokes multiple hops per call. Figure 2-x contrasts the differenes.  It's important to keep in mind that a tremendous amount of engineering effort has gone into to making Dapr efficient. As well, calls between Dapr sidecars are always made with gRPC, which delivers high performance and small, binary payloads. In most cases, the additional overhead should be in milliseconds. 

 ![Dapr overhead](./media/dapr-high-level.png)
**Figure 2-x**. Dapr at 20,000 feet.

  
   
- Finally, while Dapr covers the gamut of distributed component services, it does not provide support for database interaction. 


## Dapr and service meshes



## Potential content?
Dapr reduces the complexity of constructing microservice and evevnt-driven applications. Companies can implement interservice-communication, state, resource binding, and asynchronous pub/sub messaging with open APIs and extensible components that are community-driven.

provides the *glue* that fuses decoupled service components with your business application b. At the same time, it greatly abstracts the complexity of distributed components and provides baked-in industry best practices. Figure 2-x provides a shot of Dapr from 20,000 feet.

*Dapr is a portable, event-driven runtime that reduces the complexity of building resilient, microservice stateless and stateful applications that run on the cloud and edge and embraces the diversity of languages and developer frameworks.*


 > stop





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
