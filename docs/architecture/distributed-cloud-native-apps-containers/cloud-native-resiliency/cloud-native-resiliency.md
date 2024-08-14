---
title: Cloud-native resiliency
description: Architecture for Distributed Cloud-Native Apps with .NET Aspire & Containers | Cloud-native resiliency
author: 
ms.date: 17/04/2024
---

[!INCLUDE [download-alert](../includes/download-alert.md)]

Your cloud-native applications must embrace the partial failures that will inevitably occur. You apps should continue working when limited failures occur and recover quickly from more serious events. In cloud-native applications, where there are multiple microservices and backing services running in different containers and potentially in different locations, failures can be more common, even if you're using platforms with robust Service Level Aggreements (SLAs).

Resiliency is the ability of your system to react to failure and still remain functional. It's not about avoiding failure, but accepting failure and constructing your cloud-native services to recover from them. You want to return to a fully functioning state as quickly as possible.

As you've learned, unlike traditional monolithic applications, where everything runs together in a single process, cloud-native systems embrace a distributed architecture:

:::image type="content" source="media/distributed-cloud-native-environment.png" alt-text="Distributed cloud-native environment" border="false":::

**Figure 9-1**. Distributed cloud-native environment

Operating in this environment, a service must be sensitive to many different challenges:

- Unexpected network latency - the time for a service request to travel to the receiver and back may become unpredictable.

- [Transient faults](/azure/architecture/best-practices/transient-faults) - short-lived network connectivity errors may arise.

- Slow synchronous operations - If you call an remote function synchronously, your local service is blocked by slow responses.

- Crashed hosts - A microservice host may crash and need to be restarted or moved.

- Overloaded microservices - Microservices that have too much demand may become unresponsive for a time.

- Orchestrator operations - Your microservice orchestrator may initiate a rolling upgrade or move a service from one node to another.

- Hardware failures.

Cloud platforms can detect and mitigate many of these infrastructure issues. They may restart, scale out, and even redistribute your service to a different node.  However, to take full advantage of this built-in protection, you must design your services to react to it and thrive in this dynamic environment.

In the following sections, we'll explore defensive techniques that your service and managed cloud resources can use to minimize downtime and disruption caused by these challenges.

>[!div class="step-by-step"]
>[Previous](..TODO..)
>[Next](application-resiliency-patterns.md)
