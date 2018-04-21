---
title: Run composed and microservices-based applications in production environments
description: Containerized Docker Application Lifecycle with Microsoft Platform and Tools
ms.prod: ".net"
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/22/2017
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Run composed and microservices-based applications in production environments

Applications composed by multiple microservices do need to be deployed into orchestrator clusters in order to simplify the complexity of deployment and make it viable from an IT point of view. Without an orchestrator cluster, it would be very difficult to deploy and scale-out a complex microservices application.

## Introduction to orchestrators, schedulers, and container clusters

Earlier in this e-book, we introduced *clusters* and *schedulers* as part of the discussion on software architecture and development. Examples of Docker clusters are Docker Swarm and Mesosphere Datacenter Operating System (DC/OS). Both of these can run as a part of the infrastructure provided by Microsoft Azure Container Service.

When applications are scaled-out across multiple host systems, the ability to manage each host system and abstract away the complexity of the underlying platform becomes attractive. That is precisely what orchestrators and schedulers provide. Let's take a brief look at them here:

-   **Schedulers*** *"Scheduling" refers to the ability for an administrator to load a service file onto a host system that establishes how to run a specific container. Launching containers in a Docker cluster tends to be known as scheduling. Although scheduling refers to the specific act of loading the service definition, in a more general sense, schedulers are responsible for hooking into a host's init system to manage services in whatever capacity needed.

A cluster scheduler has multiple goals: using the cluster's resources efficiently, working with user-supplied placement constraints, scheduling applications rapidly to not leave them in a pending state, having a degree of "fairness," being robust to errors, and always be available.

-   **Orchestration*** *Platforms extend life-cycle management capabilities to complex, multicontainer workloads deployed on a cluster of hosts. By abstracting the host infrastructure, orchestration tools give users a way to treat the entire cluster as a single deployment target.

The process of orchestration involves tooling and a platform that can automate all aspects of application management from initial placement or deployment per container; moving containers to different hosts depending on its host's health or performance; versioning and rolling updates and health monitoring functions that support scaling and failover; and many more.

Orchestration is a broad term that refers to container scheduling, cluster management, and possibly the provisioning of additional hosts.

The capabilities provided by orchestrators and schedulers are very complex to develop and create from scratch, and therefore you usually would want to make use of orchestration solutions offered by vendors.


>[!div class="step-by-step"]
[Previous] (index.md)
[Next] (manage-production-docker-environments.md)
