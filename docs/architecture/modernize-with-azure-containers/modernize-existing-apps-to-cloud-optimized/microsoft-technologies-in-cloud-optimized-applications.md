---
title: Microsoft technologies in Cloud-Optimized applications
description: Modernize existing .NET applications with Azure Cloud and Windows containers | Microsoft technologies in Cloud-Optimized applications
ms.date: 12/12/2021
---
# Microsoft technologies in cloud-optimized applications

The following list describes the tools, technologies, and solutions that are recognized as requirements for Cloud-Optimized apps. You can adopt Cloud-Optimized elements selectively or gradually, depending on your priorities.

- **Cloud infrastructure**: The infrastructure that provides the compute platform, operating system, network, and storage. Microsoft Azure is positioned at this level.

- **Runtime**: This layer provides the environment for the application to run. If you are using containers, this layer usually is based on [Docker Engine](https://docs.docker.com/engine/), running either on Linux hosts or on Windows hosts. ([Windows Containers](/virtualization/windowscontainers/about/) are supported beginning with Windows Server 2016. Windows Containers is the best choice for existing .NET Framework applications that run on Windows.)

- **Managed cloud**: When you choose a managed cloud option, you can avoid the expense and complexity of managing and supporting the underlying infrastructure, VMs, OS patches, and networking configuration. If you choose to migrate by using IaaS, you are responsible for all of these tasks, and for associated costs. In a managed cloud option, you manage only the applications and services that you develop. The cloud service provider typically manages everything else. Examples of managed cloud services in Azure include [Azure SQL Database](https://azure.microsoft.com/services/sql-database), [Azure Redis Cache](https://azure.microsoft.com/services/cache/), [Azure Cosmos DB](https://azure.microsoft.com/services/cosmos-db/), [Azure Storage](https://azure.microsoft.com/services/storage/), [Azure Database for MySQL](https://azure.microsoft.com/services/mysql/), [Azure Database for PostgreSQL](https://azure.microsoft.com/services/postgresql/), [Azure Active Directory](https://azure.microsoft.com/services/active-directory/), and managed compute services like [VM scale sets](https://azure.microsoft.com/services/virtual-machine-scale-sets/), [Azure App Service](https://azure.microsoft.com/services/app-service/), and [Azure Kubernetes Service](https://azure.microsoft.com/services/container-service/).

- **Application development**: You can choose from many languages when you build applications that run in containers. This guide focuses on [.NET](https://dotnet.microsoft.com), but, you can develop container-based apps by using other languages, like Node.js, Python, Spring/Java, or Go.

- **Monitoring, telemetry, logging, and auditing**: The ability to monitor and audit applications and containers that are running in the cloud is critical for any Cloud-Optimized application. [Azure Application Insights](https://azure.microsoft.com/services/application-insights/) and [Microsoft Operations Management Suite](https://www.microsoft.com/cloud-platform/operations-management-suite) are the main Microsoft tools that provide monitoring and auditing for Cloud-Optimized apps.

- **Provisioning**: Automation tools help you provision the infrastructure and deploy an application to multiple environments (production, testing, staging). You can use tools like Chef and Puppet to manage an application's configuration and environment. This layer also can be implemented by using simpler and more direct approaches. For example, you can deploy directly by using Azure command-line interface (Azure CLI) tooling, and then use the continuous deployment and release management pipelines in [Azure DevOps Services](https://azure.microsoft.com/services/devops/).

- **Application lifecycle**: [Azure DevOps Services](https://azure.microsoft.com/services/devops/) and other tools, like Jenkins, are built automation servers that help you implement CI/CD pipelines, including release management.

The next sections of this chapter, and the related walkthroughs, focus specifically on details about the runtime layer (Windows Containers). The guidance describes the ways you can deploy Windows Containers on Windows Server 2016 (and later versions) VMs and Azure Container Instances. It also covers more advanced PaaS platforms like Azure App Service and orchestrator like Azure Kubernetes Service.

## Monolithic applications *can* be Cloud-Optimized

It's important to highlight that monolithic applications (applications that are not based on microservices) *can* be Cloud-Optimized applications. You can build and operate monolithic applications that take advantage of the cloud computing model by using a combination of containers, continuous delivery, and DevOps. If an existing monolithic application is right for your business goals, you can modernize it and make it Cloud-Optimized.

Similarly, if monolithic applications can be Cloud-Optimized applications, other, more complex architectures like N-Tier applications can also be modernized as Cloud-Optimized applications.

>[!div class="step-by-step"]
>[Previous](reasons-to-modernize-existing-net-apps-to-cloud-optimized-applications.md)
>[Next](what-about-cloud-native-applications.md)
