---
title: Cloud-native resiliency
description: Architecting Cloud Native .NET Apps for Azure | Cloud Native Resiliency
author: robvet
ms.date: 04/06/2022
---

# Cloud-native resiliency

[!INCLUDE [download-alert](includes/download-alert.md)]

Resiliency is the ability of your system to react to failure and still remain functional. It's not about avoiding failure, but accepting failure and constructing your cloud-native services to respond to it. You want to return to a fully functioning state quickly as possible.

Unlike traditional monolithic applications, where everything runs together in a single process, cloud-native systems embrace a distributed architecture as shown in Figure 6-1:

![Distributed cloud-native environment](./media/distributed-cloud-native-environment.png)

**Figure 6-1.** Distributed cloud-native environment

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
>[Previous](elastic-search-in-azure.md)
>[Next](application-resiliency-patterns.md)
