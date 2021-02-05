---
title: Summary
description: A summary of key Dapr conclusions and the road ahead.
ms.date: 02/07/2021
author: robvet
---

# Summary

We're at the end of our Dapr flight. The jet plane flying at 20,000 feet from chapter 2 is on final approach and about to land.

As the plane taxis to the gate, let's take a minute to review some important conclusions from this guide:

- **Dapr** - Dapr is a *Distributed Application Runtime* that streamlines how you build distributed applications. Through an architecture of building blocks and pluggable components, Dapr abstracts away the complexity of distributed application capabilities. Instead of building plumbing, your team focuses on delivering business features to customers.

- **Open source and cross-platform** - The native Dapr API can be consumed by *any platform* that supports HTTP. Dapr also provides language-specific SDKs for popular development platforms. Dapr v1.0 supports Go, Node.js, Python, .NET, Java, and JavaScript.

- **Building blocks** - Dapr building blocks encapsulate distributed application functionality. At the time of this writing, Dapr supports the seven building blocks shown in figure 11-1.

![Dapr building blocks](./media/dapr-at-20000-feet/building-blocks.png)

**Figure 11-1**. Dapr building blocks.

- **Components** - Dapr components provide the concrete implementation for each Dapr building block capability. They expose a common interface that enables developers to swap out component implementations without changing application code. Figure 11-2 shows the relationship among components, building blocks, and your service.

![Dapr building blocks](./media/dapr-at-20000-feet/building-blocks-integration.png)

**Figure 11-2**. Dapr building block integration.

- **Sidecars** - Clients consume Dapr building blocks and components through a sidecar architecture. A sidecar enables Dapr to run in a separate memory process or container alongside your service. Sidecars provide isolation and encapsulation as they aren't part of the service, but connected to it. Figure 11-3 shows a sidecar architecture.

![Sidecar architecture](./media/dapr-at-20000-feet/sidecar-generic.png)

**Figure 11-3**. Sidecar architecture.

- **Hosting environments** Dapr has cross-platform support and can run in multiple environments. At the time of this writing, the environments include a local self-hosted mode and a Kubernetes implementation.

- **eShopOnDapr** - This book includes an accompanying reference application entitled [eShopOnDapr](https://github.com/dotnet-architecture/eShopOnDapr). In the context of an online ecommerce store, the application demonstrates the usage of each building block. It's an evolution of widely popular [eShopOnContainers](https://github.com/dotnet-architecture/eShopOnContainers), released several years ago.  

## The Road Ahead

Looking forward, Dapr has the potential to have a profound impact on distributed application development. What can you expect from the Dapr team and its open-source contributors?

At the time of writing, here's a list of proposed enhancements for Dapr:

- Feature enhancements to existing building blocks:
  - Query capabilities in state management
- Topic filtering in pub/sub
  - An application tracing API in observability
  - Binding and pub/sub support for actors, including the self-deletion of actors

- New building blocks:
  - Configuration API building block
  - Http scale-to-zero autoscale building block
  - Leader election building block
  - Transparent proxying building block for service invocation
  - Resiliency building block (circuit breakers, Bulkheads, Timeouts)

- Integration with frameworks and cloud native technologies:
  - Django
  - Nodejs
  - Express
  - Kyma
  - Midway

- New language SDKs:
  - PHP
  - JavaScript
  - RUST
  - C++

- New hosting platforms:
  - VM sets
  - IoT Edge
  - Azure Stack Edge
  - Service Fabric

- Developer and operator productivity tooling:
  - VS Code extension
  - Remote Dev Containers
  - Dapr operational dashboard enhancements

>[!div class="step-by-step"]
>[Previous](secrets.md)
