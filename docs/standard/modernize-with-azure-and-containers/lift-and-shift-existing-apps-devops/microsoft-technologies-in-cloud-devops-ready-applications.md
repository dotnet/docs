---
title: Microsoft technologies in cloud devops-Ready applications
description: .NET Microservices Architecture for Containerized .NET Applications | Microsoft technologies in Cloud DevOps-Ready applications
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 10/26/2017
ms.prod: .net
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Microsoft technologies in cloud devops-ready applications

The following list describes the tools, technologies, and solutions that are recognized as requirements for Cloud DevOps-Ready apps. You can adopt Cloud DevOps-Ready apps selectively or gradually, depending on your priorities.

-   **Cloud infrastructure**: The infrastructure that provides the compute platform, operating system, network, and storage. Microsoft Azure is positioned at this level.

-   **Runtime**: This layer provides the environment for the application to run. If you are using containers, this layer usually is based on [Docker Engine](https://docs.docker.com/engine/), running either on Linux hosts or on Windows hosts. ([Windows Containers](https://docs.microsoft.com/virtualization/windowscontainers/about/) are supported beginning with Windows Server 2016. Windows Containers is the best choice for existing .NET Framework applications that run on Windows.)

-   **Managed cloud**: When you choose a managed cloud option, you can avoid the expense and complexity of managing and supporting the underlying infrastructure, VMs, OS patches, and networking configuration. If you choose to migrate by using IaaS, you are responsible for all of these tasks, and for associated costs. In a managed cloud option, you manage only the applications and services that you develop. The cloud service provider typically manages everything else. Examples of managed cloud services in Azure include [Azure SQL Database](https://azure.microsoft.com/services/sql-database), [Azure Redis Cache](https://azure.microsoft.com/services/cache/), [Azure Cosmos DB](https://azure.microsoft.com/services/cosmos-db/), [Azure Storage](https://azure.microsoft.com/services/storage/), [Azure Database for MySQL](https://azure.microsoft.com/services/mysql/), [Azure Database for PostgreSQL](https://azure.microsoft.com/services/postgresql/), [Azure Active Directory](https://azure.microsoft.com/services/active-directory/), and managed compute services like [VM scale sets](https://azure.microsoft.com/services/virtual-machine-scale-sets/), [Azure Service Fabric](https://azure.microsoft.com/services/service-fabric/), [Azure App Service](https://azure.microsoft.com/services/app-service/), and [Azure Container Service](https://azure.microsoft.com/services/container-service/).

-   **Application development**: You can choose from many languages when you build applications that run in containers. In this guide, we focus on [.NET](https://www.microsoft.com/net), but, you can develop container-based apps by using other languages, like Node.js, Python, Spring/Java, or GoLang.

-   **Monitoring, telemetry, logging, and auditing**: The ability to monitor and audit applications and containers that are running in the cloud is critical for any Cloud DevOps-Ready application. [Azure Application Insights](https://azure.microsoft.com/services/application-insights/) and [Microsoft Operations Management Suite](https://www.microsoft.com/cloud-platform/operations-management-suite) are the main Microsoft tools that provide monitoring and auditing for Cloud DevOps-Ready apps.

-   **Provisioning**: Automation tools help you provision the infrastructure and deploy an application to multiple environments (production, testing, staging). You can use tools like Chef and Puppet to manage an application's configuration and environment. This layer also can be implemented by using simpler and more direct approaches. For example, you can deploy directly by using Azure command-line interface (Azure CLI) tooling, and then use the continuous deployment and release management pipelines in [Visual Studio Team Services](https://www.visualstudio.com/team-services/).

-   **Application lifecycle**: [Visual Studio Team Services](https://www.visualstudio.com/team-services/) and other tools, like Jenkins, are build automation servers that help you implement CI/CD pipelines, including release management.

The next sections of this chapter, and the related walkthroughs, focus specifically on details about the runtime layer (Windows Containers). The guidance describes the ways you can deploy Windows Containers on Windows Server 2016 (and later versions) VMs. It also covers more advanced orchestrator layers, like Azure Service Fabric, Kubernetes, and Azure Container Service. Setting up orchestrator layers is a fundamental requirement for modernizing existing .NET Framework (Windows-based) applications as Cloud DevOps-Ready applications.

## Monolithic applications *can* be Cloud DevOps-Ready

It's important to highlight that monolithic applications (applications that are not based on microservices) *can* be Cloud DevOps-Ready applications. You can build and operate monolithic applications that take advantage of the cloud computing model by using a combination of containers, continuous delivery, and DevOps. If an existing monolithic application is right for your business goals, you can modernize it and make it Cloud DevOps-Ready.

Similarly, if monolithic applications can be Cloud DevOps-Ready applications, other, more complex architectures like N-Tier applications also can be modernized as Cloud DevOps-Ready applications.

>[!div class="step-by-step"]
[Previous](reasons-to-lift-and-shift-existing-net-apps-to-cloud-devops-ready-applications.md)
[Next](what-about-cloud-optimized-applications.md)
