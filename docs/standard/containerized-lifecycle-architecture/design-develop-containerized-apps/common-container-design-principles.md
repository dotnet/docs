---
title: Common container design principles
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
# Common container design principles

Ahead of getting into the development process there are a few basic concepts worth mentioning with regard to how you use containers.

## Container equals a process

In the container model, a container represents a single process. By defining a container as a process boundary, you begin to create the primitives used to scale, or batch-off, processes. When you run a Docker container, you'll see an [ENTRYPOINT](https://docs.docker.com/engine/reference/builder/#/entrypoint) definition. This defines the process and the lifetime of the container. When the process completes, the container life cycle ends. There are long-running processes, such as web servers, and short-lived processes, such as batch jobs, which might have been implemented as Microsoft Azure [WebJobs](https://azure.microsoft.com/en-us/documentation/articles/websites-webjobs-resources/). If the process fails, the container ends, and the orchestrator takes over. If the orchestrator was instructed to keep five instances running and one fails, the orchestrator will create another container to replace the failed process. In a batch job, the process is started with parameters. When the process completes, the work is complete.

You might find a scenario in which you want multiple processes running in a single container. In any architecture document, there's never a "never," nor is there always an "always." For scenarios requiring multiple processes, a common pattern is to use [Supervisor](http://supervisord.org/).


>[!div class="step-by-step"]
[Previous] (design-docker-applications.md)
[Next] (monolithic-applications.md)
