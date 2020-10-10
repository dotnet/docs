---
title: The World is Distributed
description: Gain an understanding of the challenges of distributed applications
author: robvet
ms.date: 10/10/2020
---

# The world is distributed

Just ask any 'cool kid': *Modern, distributed systems are in and, monolithic apps are out!* 

But, it's not just "cool kids." Progressive IT Leaders, corporate architects, and astute developers are echoing these same thoughts as they explore and evaluate modern distributed applications. Many have bought in. They're designing new and replatforming existing enterprise applications following the principles, patterns, and practices of distributed applications.

But, this evolution raises many questions...

- What exactly is a distributed application?
- Why are they gaining popularity?
- What are the costs?
- And, importantly, what are the tradeoffs?

To start, let's rewind and look at the past 15 years. During this period, we typically constructed applications as a single, monolithic unit. Figure 1-1 shows the architecture.

![Monolithic architecture.](./media/monolithic-design.png)

**Figure 1-1. Monolithic architecture.

In the previous figure, the modules for Ordering, Identity, and Marketing operate in a single-server process. Application data is stored in a shared database. Business functionality is exposed via HTML and RESTFul interfaces.

In many ways, monolithic apps are `straightforward`. They're straightforward to...

 - build
 - test
 - deploy
 - troubleshoot
 - scale-up vertically

However, monolithic architectures present significant challenges. 

Over time, you may reach a point where you begin to lose control... 

 - The monolith has become so overwhelmingly complicated that no single person understands it.
 - You fear making changes as each brings unintended and costly side effects.
 - New features/fixes become time-consuming and expensive to implement. 
 - Even the smallest change requires a full deployment of the entire application - expensive and risky. 
 - One unstable component can crash the entire system.
 - Adding new technologies and frameworks aren't an option.
 - Implementing agile delivery methodologies are difficult.
 - Architectural erosion sets in as the code base deteriorates with never-ending "special cases."
 - Eventually the consultants come in and tell you to rewrite it.

IT practitioners call this condition `the Fear Cycle`. If you've been in the technology business for any length of time, good chance you've experienced it. It's stressful and exhausts your IT budget. Instead of building new and innovative solutions, the majority of your budget is spent maintaining legacy apps.

Instead of fear, businesses require `speed and agility`. They seek an architectural style with which they can rapidly respond to market conditions. They need to instantaneously update and individually scale small areas of a live application.

Many organizations are finding this speed and agility by adopting a distributed architectural approach to building systems. Figure 1-2 shows the same system built applying distributed techniques and practices.

![Distributed architecture.](./media/distributed-design.png)

**Figure 1-2. Distributed architecture.

Note how the same application is decomposed across a set of distributed services. Each is self-contained and encapsulates its own code, data, and dependencies. Each is deployed in a software container and managed by a container orchestrator. Instead of a shared database, each service owns it own datastore. Note how some services require a full relational database, but others, a NoSQL datastore. The Basket service stores its state in a distributed key-value cache. Note how inbound traffic routes through an API Gateway service. It's responsible for directing calls to back-end services and enforcing cross-cutting concerns. Most importantly, the application takes full advantage of the scalability, availability, and resiliency features found in modern cloud platforms.

But, while distributed applications can help bring agility and speed, they bring many challenges.

| Challenge | Description |
| :-------- | :-------- |
| Cross-service communication | How can services synchronously communicate with each other using platform agnostic protocols and well-known endpoints? |
| State Management | How can services maintain contextual information across a transaction? |
| Asynchronous messaging | How can services implement secure, scalable pub/sub messaging across different kinds of message brokers? |
| External resource bindings | How can external resources trigger events across services with bi-directional communication? |
| Secrets | How can services securely access external secret stores |
| Observability | How can services implement end-to-end monitoring of processes executing on different machines |

This book introduces Dapr. Dapr is a distributed application runtime that directly addresses many of the challenges of distributed applications. 

## Summary

In this chapter, we highlighted the evolving trend of distributed applications. We contrasted a monolithic system approach with that of distributed services. We spotlighted some of the benefits challenges of both approaches. 

Now, sit back, relax, and let us introduce you the new world of Dapr.

### References

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](index.md)
