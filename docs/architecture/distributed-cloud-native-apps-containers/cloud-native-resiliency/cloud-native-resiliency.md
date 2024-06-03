---
title: Cloud-native resiliency
description: Architecture for Distributed Cloud-Native Apps with .NET Aspire & Containers | Cloud-native resiliency
author: 
ms.date: 17/04/2024
---

<!-- TODO update figure references -->

# Cloud-native resiliency

[!INCLUDE [download-alert](../includes/download-alert.md)]

*Your cloud-native applications must embrace the partial failures that will eventually occur. You must design your application to be resilient enough to recover from failures.*

Resiliency is the ability of your system to react to failure and still remain functional. It's not about avoiding failure, but accepting failure and constructing your cloud-native services to recover from them. You want to return to a fully functioning state quickly as possible.

Unlike traditional monolithic applications, where everything runs together in a single process, cloud-native systems embrace a distributed architecture:

:::image type="content" source="media/distributed-cloud-native-environment.png" alt-text="Distributed cloud-native environment" border="false":::

**Figure 9-1**. Distributed cloud-native environment

In the previous figure, each microservice and cloud-based [backing service](https://12factor.net/backing-services) execute in a separate process, across server infrastructure, communicating via network-based calls.

Operating in this environment, a service must be sensitive to many different challenges:

- Unexpected network latency - the time for a service request to travel to the receiver and back.

- [Transient faults](/azure/architecture/best-practices/transient-faults) - short-lived network connectivity errors.

- Blockage by a long-running synchronous operation.

- A host process that has crashed and is being restarted or moved.

- An overloaded microservice that can't respond for a short time.

- An in-flight orchestrator operation such as a rolling upgrade or moving a service from one node to another.

- Hardware failures.

Cloud platforms can detect and mitigate many of these infrastructure issues. It may restart, scale out, and even redistribute your service to a different node.  However, to take full advantage of this built-in protection, you must design your services to react to it and thrive in this dynamic environment.

In the following sections, we'll explore defensive techniques that your service and managed cloud resources can leverage to minimize downtime and disruption.

>[!div class="step-by-step"]
>[Previous](..TODO..)
>[Next](application-resiliency-patterns.md)
