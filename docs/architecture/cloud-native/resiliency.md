---
title: Cloud-native resiliency
description: Architecting Cloud Native .NET Apps for Azure | Cloud Native Resiliency
author: robvet
ms.date: 05/13/2020
---

# Cloud-native resiliency

Resiliency is the ability of your system to react to failure and still remain functional. It's not about avoiding failure, but accepting failure as inevitable and crafting  your cloud-native services to respond to it. The end-goal is to return the application to a fully functioning state after a failure.

Cloud-native systems take full advantage of the cloud computing model. Your services must know how to thrive in a dynamic, virtualized cloud environment. They'll make extensive use of Platform as a Service (PaaS) compute infrastructure and managed services. The caveat: Cloud infrastructure and networking are inherently unreliable.

Cloud vendors can detect and mitigate platform failure. Your service will be restarted, scale out and in, and distributed across nodes. Your services must be design services to detect these environmental scenarios and recover.  

Unlike traditional monolithic applications, where everything runs together in a single process, cloud-native systems embrace a distributed architecture as shown in Figure 6-1:

![Distributed cloud-native environment](./media/distributed-cloud-native-environment.png)

**Figure 6-1.** Distributed cloud-native environment

Note in the previous figure how each microservice and cloud-based [backing service](https://12factor.net/backing-services) execute as a separate process, running across different server infrastructure, and communicating via network-based calls.

With such a design, what could go wrong?

- Unexpected [network latency](https://www.techopedia.com/definition/8553/network-latency) (Time for a request to travel to the receiver and back).
- [Transient faults](https://docs.microsoft.com/azure/architecture/best-practices/transient-faults) (short-loved network connectivity errors).
- Blockage by a long-running synchronous operation.
- A host process that has crashed and is being restarted or moved.
- An overloaded microservice that can't respond for a short time.
- An in-flight Orchestrator operation such as a rolling upgrade or moving a service from one node to another.
- Hardware failures from commodity hardware.

When deploying distributed cloud-native services across a cloud-based infrastructure, these factors are real. You must design and develop defensively to deal with them.

In a smaller system, failure will be less frequent. But as a system scales up and out, you can expect more and more issues - to a level, perhaps, where partial failure could become normal operation.

To remain functional, both your application and infrastructure must be resilient. In the following sections, we'll explore defensive techniques that your application and managed cloud resources can leverage to minimize downtime and disruption.

>[!div class="step-by-step"]
>[Previous](elastic-search-in-azure.md)
>[Next](application-resiliency-patterns.md)
