---
title: Candidate Apps for Cloud Native
description: Architecting Cloud-Native .NET Apps for Azure | Candidate Apps for Cloud Native
author: robvet
ms.date: 07/28/2019
---
# Candidate Apps for Cloud Native

Look at the apps in your portfolio. How many of them qualify for a cloud-native architecture? All of them? Perhaps some?

Applying a cost/benefit analysis, there's a good chance that most wouldn't support the hefty price tag required to be cloud native. The cost of being cloud native would far exceed the business value of the application.

What type of application might be a candidate for  cloud native?

- A large, strategic enterprise system that needs to align to business capabilities/features

- An application that requires a high release velocity - with high confidence

- A system with where individual features must release without a full redeployment of the entire system

- An application developed by heterogenous teams with expertise in different technology stacks

- An application with components that must scale independently

Then there's legacy systems. While we'd all like to build new applications, we're often responsible for modernizing legacy workloads that are critical to the business. Over time, a legacy application could be decomposed into microservices, containerized, and ultimately "replatformed" into a cloud-native architecture.  

The free Microsoft e-book [Modernize existing .NET applications with Azure cloud and Windows Containers](https://dotnet.microsoft.com/download/thank-you/modernizing-existing-net-apps-ebook) features guidance for migrating on-premises workloads into cloud. Figure 1-11 shows that there isn't a single, one-size-fits-all strategy.

![Strategies for migrating legacy workloads](media/strategies-for-migrating-legacy-workloads.png)
**Figure 1-11**. Strategies for migrating legacy workloads

Monolithic apps that are non-critical might benefit from a quick lift-and-shift ([Cloud Infrastructure-Ready](https://docs.microsoft.com/dotnet/standard/modernize-with-azure-and-containers/lift-and-shift-existing-apps-azure-iaas)) migration. Here, the on-premises workload is rehosted to a cloud-based VM, without changes. This approach uses the IaaS (Infrastructure as a Service) model. Azure includes several tools such as ([Azure Migrate](https://aka.ms/azuremigrate), [Azure Site Recovery](https://azure.microsoft.com/services/site-recovery/), and [Azure Database Migration Service](https://azure.microsoft.com/campaigns/database-migration/)) to make such a move easier.

Critical business systems might benefit from an enhanced lift-and-shift (*Cloud Optimized*) migration. This approach includes deployment optimizations that enable key cloud services - without changing the core architecture of the application. For example, you might [containerize](https://docs.microsoft.com/virtualization/windowscontainers/about/) the application and deploy it to a container orchestrator, like [Azure Kubernetes Services](https://azure.microsoft.com/services/kubernetes-service/), discussed later in this book. Once in the cloud, the application could consume other cloud services such as databases, message queues, monitoring, and distributed caching.

Finally, strategic enterprise applications might benefit from a *Cloud-Native* approach, the subject of this book. This approach provides agility and velocity. But, it comes at a cost of replatforming, rearchitecting, and rewriting code.

If you and your team believe a cloud-native approach is appropriate, it behooves you to rationalize the decision with your organization. What exactly is the business problem that a cloud- native approach will solve? How would it align with business needs?

- Rapid releases of features with increased confidence?

- Fine-grained scalability - more efficient usage of resources?

- Improved system resiliency?

- Improved system performance?

- More visibility into operations?

- Blend development platforms and data stores to arrive at the best tool for the job?

- Future-proof application investment?

The right migration strategy depends on the organizational priorities and the systems you're targeting. In many cases, it may be more cost effective to cloud-optimize a monolithic application or add coarse-grained services to an N-Tier app. In these cases, you can still make full use of cloud PaaS capabilities like the ones offered by Azure App Service.


>[!div class="step-by-step"]
>[Previous](definition.md)
>[Next](azure-development-stack.md)
