---
title: The World is Distributed
description: Gain an understanding of the challenges of distributed applications
author: robvet
ms.date: 09/05/2020
---

# The world is distributed

> Notes:

> Proposing to change title as think the reader has to come into it with a clear definition and understanding. We may understand what a distributed app, but there are many who will not. 


> Outline:
> - Intro thought
> - Mono vs. distritubed apps
> - What happens when we migrate a component to a service?
> - What is the appeal
> - What are the challenges
> - Lead into how DAPR addresses the challenges

-- Start:

Modern, distributed systems are in and, monolithics apps are out! Just ask any 'cool kid.'

But, interestingly, they aren't the only ones saying it. More and more, corporate architects and IT leaders are designing new and replatforming existing enterprise applications to fit this mold. 

As a developer, architect, or IT leader...

- What exactly is a distributed application?
- Why is it important?
- What are the costs?
- And, importantly, what are the tradeoffs?

For years, we designed, developed, and deployed applications as a single, monolithic unit. Figure 1.x shows a monolithic architecture.

![Monolithic architecture.](./media/monolithic-design.png)

**Figure 1-x**. Monolithic architecture.

Note in the previous figure how modules for Ordering, Identity, Marketing, and others, all reside in a single server process. Applicaiton state is stored inside a shared reltaional database. Business functionality is exposed via an HTML and RESTFul interface.

Although simple and straightforward, monolithic architectures face a number of challenges:

- Coupling
- Deployment
- Scaling

The challenges become more pronounced as the application grows in size, complexity, and volume.

In the Microsoft guidance eBook, [Architecting Cloud-Native .NET Apps for Azure](https://docs.microsoft.com/en-us/dotnet/architecture/cloud-native/), reference is made to the `Fear Cycle`. The *fear cycle* is a state in which you have lost control of your monolithic application. Obvious giveways include:

- The app has become so overwhelmingly complicated that no single person understands it.
- You fear making changes - each change has unintended and costly side effects.
- New features/fixes become tricky, time-consuming, and expensive to implement.
- Each release as small as possible and requires a full deployment of the entire application.
- One unstable component can crash the entire system.
- New technologies and frameworks aren't an option.
- It's difficult to implement agile delivery methodologies.
- Architectural erosion sets in as the code base deteriorates with never-ending "special cases."
- The consultants tell you to rewrite it.

As applications become increasingly complex and users demand more and more, businesses require speed and agility. They need an architectural style enables them to rapidly respond to market conditions. They can instantaneously update small areas of a live, complex application, and individually scale those areas as needed.

Many organizations have addressed the monolithic fear cycle and are gaining speed and agility by adopting a distributed architectural approach to building systems. Figure 1-x shows the same system built applying cloud-native techniques and practices.

![Distributed architecture.](./media/distributed-design.png)

**Figure 1-x**. Distributed architecture.

Note in the previous figure how the same application is decomposed across a set of distributed services. Each is self-contained and encapsulates its own code, data, and dependencies. Each is deployed in a software container and managed by a container orchestrator. Instead of a large relational database, each service owns it own datastore, the type of which vary based upon the data needs. Note how some services depend on a relational database, but other on NoSQL databases. One service stores its state in a distributed cache. Note how all traffic routes through an API Gateway service that is responsible for directing traffic to the core back-end services and enforcing many cross-cutting concerns. Most importantly, the application takes full advantage of the scalability, availability, and resiliency features found in modern cloud platforms.

But, while distributed applications can help bring agilty and speed, they bring many challenges. Consdier, for example:

- Complexity
- Interservice communication
- State management
- Messaging - 
- Observability - End-to-end monitoring of processes executing on different machines






### blah

So, what exactly is DAPR? Sit back, relax, and let us help you explore this new world.

In this chapter, we introduced DAPR. Blah. We provided a definition along with the key capabilities that drive a cloud-native application. We looked at the types of applications that might justify this investment and effort.

With the introduction behind, we now dive into a much more detailed look at cloud native.

### References

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](index.md)
