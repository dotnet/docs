---
title: Kubernetes - gRPC for WCF Developers
description: TO BE WRITTEN
author: markrendle
ms.date: 09/02/2019
---

# Kubernetes

Although it is possible to run containers manually on Docker hosts, for reliable production systems you should use a Container Orchestration Engine to manage multiple instances running across multiple servers in a cluster. There are multiple Container Orchestration Engines available, including Kubernetes, Docker Swarm and Apache Mesos, but of these, Kubernetes is far and away the most widely used, so that will be the focus of this chapter.

Kubernetes includes the following functionality:

- **Scheduling** runs containers on multiple nodes within a cluster, ensuring balanced usage of the available resource, keeping containers running in the case of outages, and handling rolling updates to new versions of images or new configurations.
- **Health checks** monitor containers to ensure continued service.
- **Service discovery** handles routing between services within a cluster.
- **Ingress** exposes selected services externally, and generally provides load-balancing across instances of those services.
- **Resource management** attaches external resources such as storage to containers.

## Getting started with Kubernetes

If you are running Docker Desktop for Windows, Kubernetes is already available; you just need to enable it in the Kubernetes section of the Settings window.

>[!div class="step-by-step"]
<!-->[Next](service-mesh.md)-->
