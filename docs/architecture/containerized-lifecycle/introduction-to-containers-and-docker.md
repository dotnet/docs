---
title: Overview of Containers and Docker
description: Get a high level overview of the main benefits of using Docker.
ms.date: 04/15/2020
---
# Overview of Containers and Docker

*Containerization is an approach to software development in which an application or service, its dependencies, and its configuration (abstracted as deployment manifest files) are packaged together as a container image. You then can test the containerized application as a unit and deploy it as a container image instance to the host operating system (OS).*

Just as shipping containers allow goods to be transported by ship, train, or truck regardless of the cargo inside, software containers act as a standard unit of software deployment that can contain different code and dependencies. Containerizing software this way enables developers and IT professionals to deploy them across environments with little or no modification.

Containers also isolate applications from each other on a shared OS. Containerized applications run on top of a container host that in turn runs on the OS (Linux or Windows). Containers therefore have a much smaller footprint than virtual machine (VM) images.

Each container can run a whole web application or a service, as shown in Figure 1-1. In this example, Docker host is a container host, and App1, App2, Svc1, and Svc2 are containerized applications or services.

![Diagram showing four containers running in a VM or a server.](./media/introduction-to-containers-and-docker/multiple-containers-single-host.png)

**Figure 1-1**. Multiple containers running on a container host

Another benefit you can derive from containerization is scalability. You can scale out quickly by creating new containers for short-term tasks. From an application point of view, instantiating an image (creating a container) is similar to instantiating a process like a service or web app. For reliability, however, when you run multiple instances of the same image across multiple host servers, you typically want each container (image instance) to run in a different host server or VM in different fault domains.

In short, containers offer the benefits of isolation, portability, agility, scalability, and control across the entire application lifecycle workflow. The most important benefit is the environment isolation provided between Dev and Ops.

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](what-is-docker.md)
