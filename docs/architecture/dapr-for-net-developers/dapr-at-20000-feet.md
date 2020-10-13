---
title: Dapr @ 20,000 feet
description: A high-level overview of what dapr is, what it does, and how it works
author: robvet 
ms.date: 09/20/2020
---

# Dapr @ 20,000 feet

In chapter 1, we discussed the appeal of distributed microservice applications. But, we also pointed out that they dramatically increase architectural and operational complexity. With that in mind, the question becomes, how can we "have our cake" and "eat it too?" That is, how can we take advantage of the agility, but minimize the complexity.

Ladies and Gentlemen, please welcome Dapr.

Dapr, or *Distributed Application Runtime* - a new way to build distributed applications.

What started as a prototype at Microsoft has evolved into a highly successful open-source project. Sponsoring the project, Microsoft has partnered with customers and the open-source community to build and extend Dapr. This concerted effort validates the willingness of developers from all backgrounds to solve some of the toughest challenges when developing distributed applications.     

In this book, we look at Dapr through the lens of the .NET Core platform. In this chapter, we help you build a solid conceptual understanding of Dapr and how it works.

## What is Dapr?

Imagine flying in a jet at 20,000 feet. You look out the window and see the landscape from a wide perspective. Let's do the same for Dapr. Visualize yourself flying over at Dapr at 20,000 feet. What would you see?

At its core, Dapr is a `portable, event-driven runtime`. 

 - `Portable` - Your write your application code once and run it on public clouds and edge devices. With a configuration file, you specify the external infrastructure services that you wish to include in your environment. These services might include pub-sub messaging, state management, or service-to-service invocation. Later, if you move your app to another environment, you swap out the configuration file with one that specifies bindings to service components in the new environment. Your service does not hold direct references to the external services - Dapr does that.

 - `Event-driven` - Dapr supports event-driven resource binding and pub-sub messaging services. You can receive events from external resources, such as datastores, streaming services, or web hooks. You can also publish and subscribe to events from message brokers - with minimal code and, again, no direct reference to the external service. 

 - `Runtime` - Dapr exposes a runtime engine that runs your services - regardless of programming platform. For example, Dotnet Core is a runtime engine - you run services within it. Dapr is *also* a runtime engine. You invoke the Dapr runtime and instruct it to start the dotnet runtime. Under the hood, Dapr implements a `distributed runtime` by operating along side with your application using a `sidecar` architecture. More about *sidecars* coming up.

## What does Dapr solve?

Dapr addresses a large challenge in modern distributed app development: `Complexity`. 

Simplifying the complexity of distributed microservice applications is a key design goal of Dapr. Through an architecture of pluggable components, Dapr abstracts external service components from the business logic of your application.

Dapr provides a *dynamic glue* that fuses together service component plumbing without tightly coupled references. For example, your service may require a state store. You could write some custom code to wrap Azure Redis Cache, register it with your dependency injection container, and inject an instance into your system. However, with Dapr, you configure and call a Dapr state building block. That block dynamically binds to Redis Cache via a configuration. Your service delegates the call to Dapr, which, in turns,  calls Redis on your behalf.  Your code has no SDK, library, or reference to Redis.

Figure 2-x shows Dapr from 20,000 feet.

![Dapr at 20,000 feet](./media/dapr-high-level.png)
**Figure 2-x**. Dapr at 20,000 feet.

Near the top of the figure, note how Dapr provides language typed SDKs for many popular programming platforms, including Go, Node.js, Python, .NET, Java, and JavaScript. 

The row beneath shows how Dapr supports both RESTFul HTTP APIs and gRPC communication.

The blue boxes across the center of the figure present the distributed system building blocks. Each block represents an independent service component, enabling you to integrate those services that are helpful for your application.

The bottom row shows the portability of Dapr running across many different environments. 

## Dapr architecture

At this point, our jet turns around and flies back over Dapr, descending in altitude, giving us a closer look at how Dapr works.

### Building blocks

Dapr is built on the concept of `building blocks`. 

A building block is as an HTTP or gRPC API that can be called from user code from any supported programming platform. Each block encapsulates infrastructure services required by a distributed appllication. Figure 2-x shows the blocks for Dapr v 1.0.

![Dapr building blocks](./media/building-block.png)

**Figure 2-x**. Dapr building blocks.

Building blocks treats infrastructure services as a black box. When your code needs to invoke an infrastructure service, it calls the building block API. Figure 2-x shows the architecture.

![Dapr building blocks](./media/building-block-integration.png)

**Figure 2-x**. Dapr building blocks.

Note how the building block exposes an API that can be consumed by your service. As shown, building block APIs support both HTTP and gRPC. In turn, building blocks consume configurable componenets that provide the actual implementation for external services. We'll cover components next. Note too how your code takes no dependencies

 
 > show code example of calling a building block.


Your code calls building block without taking dependencies on SDKs or libraries. T

We cover each of the Dapr building blocks in detail in chapter x.

### Components

Building blocks in Dapr essentially expose the API that you work with. But the underlying functionality is performed by one or more components that you specify in the configuration.

Building blocks bind to one or more components that provides the actual service implementation. Components are 'pluggable' - you can swap out one component that shares the same interface with another component. To do so, you simply change the definition in the Dapr configuration file. For example, if you use Redis as a state store, you can substitute it with Cosmos DB just by changing the definition of your state component. Having applied then new component definition, all requests for state store will route to Cosmos DB.

A building block can use any combination of components. For example the actors building block and the state management building block both use state components. As another example, the pub/sub building block uses pub/sub components.

The following component types are provided by Dapr at the time of this book:

| Component | Description |
| :-------- | :-------- |
| [Service discovery](https://github.com/dapr/components-contrib/tree/master/nameresolution) | Used by the Service Invocation building block to integrate with the hosting environment to provide service-to-service discovery. |
| [State](https://github.com/dapr/components-contrib/tree/master/state) | Provides uniform interface to interact with wide variety of state store implementations. |
| [Pub/sub](https://github.com/dapr/components-contrib/tree/master/pubsub) | Provides uniform interface to interact with wide variety of message bus implementations. |
| [Bindings](https://github.com/dapr/components-contrib/tree/master/bindings) | Provides uniform interface to trigger application events from external systems and invoke external systems with optional data payloads. |
| [Middleware](https://github.com/dapr/components-contrib/tree/master/middleware) | Allows custom middleware to plug into the request processing pipeline to perform additional actions on a request or response. |
| [Secret stores](https://github.com/dapr/components-contrib/tree/master/secretstores) | Provides uniform interface to interact with external secret stores, including cloud, edge, commercial, open source. |
| [Tracing exporters](https://github.com/dapr/components-contrib/tree/master/exporters) | Provides uniform interface to open telemetry wrappers. |

### Sidecar

Dapr exposes its building block APIs using a `sidecar architecture`. Figure 2-x shows an example of a Dapr sidecar.

![Sidecar architecture](./media/sidecar-state-mgmt.png)

**Figure 2-x**. Sidecar archtitecture.

In this sceanario, the customer service, on the left, needs to store customer location data in a state store, on the right.

However, the customer service has no reference to underlying state store. Instead it invokes the Dapr State Management building block, exposed as a stand-alone sidecar service. It is the sidecar API that is responsible for calling into state store component on your behalf. Note too the variety of state store service implementaitons that are available.

 > Extra...

While you application makes calls to the Dapr API, it does not include any Dapr runtime code. Instead, Dapr exposes its building block APIs using a sidecar architecture. 

, not requiring the application code to include any Dapr runtime code. This makes integration with Dapr easy from other runtimes, as well as providing separation of the application logic for improved supportability.

you encapsulate and expose Dapr functionality via a side car architecture - your application does not include any Dapr runtime code.


, either as a container or as a process, not requiring the application code to include any Dapr runtime code. This makes integration with Dapr easy from other runtimes, as well as providing separation of the application logic for improved supportability.


It is a “Runtime” that operates along with your application using a sidecar architecture — your application does not run “inside it”. In standalone mode, Dapr simply runs as a different process and in Kubernetes, it runs as a (sidecar) container in the same Pod as your application

you encapsulate and expose Dapr functionality via a side car architecture - your application does not include any Dapr runtime code.

  > Specfically, you're running the dot net service in a dapr sidecar. Now, other service can use dapr to call this service.

That’s not the case with Dapr. It is a “Runtime” that operates along with
your application using a sidecar architecture—your application
does not run “inside it”. In standalone mode, Dapr simply runs as a
different process and in Kubernetes, it runs as a (sidecar) container in
the same Pod as your application

Dapr is a “runtime” — what does that mean?
I thought about this as well, when I first started exploring Dapr. In my specific case (Java middleware background), “runtime” was an application server that provided a “managed environment” (concurrency, security etc.) to my code (WAR, EAR etc.)
That’s not the case with Dapr. It is a “Runtime” that operates along with your application using a sidecar architecture — your application does not run “inside it”. In standalone mode, Dapr simply runs as a different process and in Kubernetes, it runs as a (sidecar) container in the same Pod as your application
Image for post

It should be clear from the above picture that Dapr is a higher abstraction than
Kubernetes. Kubernetes does not have any concept of application.
You can use Dapr as a sidecar container with your application containers running in
Kubernetes. You can also use Dapr as a process for traditional deployments as well.

 > Extra end

### Configuration

 > Configuration driaves compoenent selection via YAML files. Similar format to K8s.

 Dapr Configuration defines a policy that affects how any Dapr sidecar instance behaves, such as using distributed tracing or a middleware component. Configuration can be applied to Dapr sidecar instances dynamically.

You can get a list of current configurations available in the current the hosting environment using the dapr configurations CLI command.

### Dapr control plane

## Supported platforms

Dapr is truly an open platform - both cross-platform and open-source. To start, Dapr is written in Google's Golang language. Out of the box, it supports language agnostic RESTful HTTP and gRPC APIs. 

 Dapr can self-host for local development, run inside a VM, a Kubernetes, or Service Fabric cluster. 



### Native API vs. platform SDKs

### .NET SDK for Dapr


## Dapr considerations

Dapr is not without challenges. Consider the following:

 - When consuming a service component from Dapr, you're communicating with it through an abstraction. The abstraction can expose common functionality that all such components would expose. Some components may have custom features that are not exposed by the Dapr common interfaces. In these scenarios, you may need to reference the component directly.
 - Overhead. With it's sidecar architecture, Dapr invokes multiple hops per call. Figure 2-x contrasts the differences.  It's important to keep in mind that a tremendous amount of engineering effort has gone into to making Dapr efficient. As well, calls between Dapr sidecars are always made with gRPC, which delivers high performance and small, binary payloads. In most cases, the additional overhead should be in milliseconds. 

 ![Dapr overhead](./media/dapr-high-level.png)
**Figure 2-x**. Dapr at 20,000 feet.

  
   
- Finally, while Dapr covers the gamut of distributed component services, it does not provide support for database interaction. 


## Dapr, service meshes, and Orleans

 > See Dapr-runtime3.pdf and Dapr-runtime4.pdf
 > Orleans -- see pros-cons.pdf

Dapr can be used alongside any service mesh such as Istio and
Linkerd. A service mesh is a dedicated network infrastructure layer
designed to connect services to one another and provide insightful
telemetry. A service mesh doesn’t introduce new functionality to an
application.
Dapr introduces new functionality to an app’s runtime. Both service
meshes and Dapr run as side-car services to your application, one
giving network features and the other distributed application
capabilities.
1 dapr init --slim
Istio is not a programming model and does not focus on application
level features such as state management, pub-sub, bindings etc. That
is where Dapr comes in.
So, there are some similarities between the two. But, as suggested by the dapr
documentation we can use them together as well. Dapr will not focus on network
concerns like traffic routing, A/B testing etc. This is where service mesh like Istio will
provide value. Dapr will be more application centric


















## Potential content?
Dapr reduces the complexity of constructing microservice and evevnt-driven applications. Companies can implement interservice-communication, state, resource binding, and asynchronous pub/sub messaging with open APIs and extensible components that are community-driven.

provides the *glue* that fuses decoupled service components with your business application b. At the same time, it greatly abstracts the complexity of distributed components and provides baked-in industry best practices. Figure 2-x provides a shot of Dapr from 20,000 feet.

*Dapr is a portable, event-driven runtime that reduces the complexity of building resilient, microservice stateless and stateful applications that run on the cloud and edge and embraces the diversity of languages and developer frameworks.*



 Dapr implements a sidecar architecture so that 
 
  > dotnet core is a runtime engine - you run programs within it
 > dapr is also a runtime engine - you run the dotnet program within the dapr runtime -- you tell dapr to start the service and that is with the dotnet runtime (dotnet run). So, the Dapr runtime encapsulates the .NET core runtime.


Dapr is a “runtime” — what does that mean?
I thought about this as well, when I first started exploring Dapr. In my specific case (Java middleware background), “runtime” was an application server that provided a “managed environment” (concurrency, security etc.) to my code (WAR, EAR etc.)
That’s not the case with Dapr. It is a “Runtime” that operates along with your application using a sidecar architecture — your application does not run “inside it”. In standalone mode, Dapr simply runs as a different process and in Kubernetes, it runs as a (sidecar) container in the same Pod as your application
Image for post

 > stop





Template for bullet points:

In the example, we saw some clear benefits:

- Each microservice has an autonomous lifecycle and can evolve independently and deploy frequently.

- Each microservice can scale independently. 




Template for link:

Consider the widely accepted DevOps concept of [Pets vs. Cattle](https://medium.com/@Joachim8675309/devops-concepts-pets-vs-cattle-2380b5aab313). 




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
