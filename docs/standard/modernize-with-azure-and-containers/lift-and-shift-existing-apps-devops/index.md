---
title: lift and shift existing apps devops | Microsoft Docs 
description: Modernize Existing .NET Applications With Azure Cloud and Windows Containers | lift and shift existing apps devops
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/28/2017
---
-   [Reasons to lift and shift existing .NET apps to Cloud DevOps-Ready applications](#reasons-to-lift-and-shift-existing-.net-apps-to-cloud-devops-ready-applications)
    -   [Cloud DevOps-Ready application principles and tenets ](#cloud-devops-ready-application-principles-and-tenets)
    -   [Benefits of a Cloud DevOps-Ready application](#benefits-of-a-cloud-devops-ready-application)
-   [Microsoft technologies in Cloud DevOps-Ready applications](#microsoft-technologies-in-cloud-devops-ready-applications)
    -   [Monolithic applications *can* be Cloud DevOps-Ready](#monolithic-applications-can-be-cloud-devops-ready)
-   [What about Cloud-Optimized applications?](#what-about-cloud-optimized-applications)
    -   [Cloud-native applications with Cloud-Optimized applications](#cloud-native-applications-with-cloud-optimized-applications)
    -   [What about microservices? ](#what-about-microservices)
    -   [When to use Azure App Service for modernizing existing .NET apps](#when-to-use-azure-app-service-for-modernizing-existing-.net-apps)
        -   [Benefits of moving to Azure App Service](#benefits-of-moving-to-azure-app-service)
        -   [Additional resources](#additional-resources)
        -   [](#section)
        -   [Benefits of moving to Windows Containers](#benefits-of-moving-to-windows-containers)
-   [How to deploy existing .NET apps to Azure App Service ](#how-to-deploy-existing-.net-apps-to-azure-app-service)
    -   [Validate sites and migrate to App Service with Azure App Service Migration Assistant](#validate-sites-and-migrate-to-app-service-with-azure-app-service-migration-assistant)
        -   [Additional resources](#additional-resources-1)
-   [Deploy existing .NET apps as Windows containers](#deploy-existing-.net-apps-as-windows-containers)
    -   [What are containers? (Linux or Windows)](#what-are-containers-linux-or-windows)
    -   [Benefits of containers (Docker Engine on Linux or Windows)](#benefits-of-containers-docker-engine-on-linux-or-windows)
    -   [What is Docker?](#what-is-docker)
    -   [Benefits of Windows Containers for your existing .NET applications](#benefits-of-windows-containers-for-your-existing-.net-applications)
    -   [Choose an OS to target with .NET-based containers](#choose-an-os-to-target-with-.net-based-containers)
        -   [Multi-arch images](#multi-arch-images)
    -   [Windows container types](#windows-container-types)
        -   [Additional resources](#additional-resources-2)
-   [When not to deploy to Windows Containers](#when-not-to-deploy-to-windows-containers)
    -   [Additional resources](#additional-resources-3)
-   [When to deploy Windows Containers in your on-premises IaaS VM infrastructure](#when-to-deploy-windows-containers-in-your-on-premises-iaas-vm-infrastructure)
-   [When to deploy Windows Containers to Azure VMs (IaaS cloud)](#when-to-deploy-windows-containers-to-azure-vms-iaas-cloud)
-   [When to deploy Windows Containers to Service Fabric](#when-to-deploy-windows-containers-to-service-fabric)
-   [When to deploy Windows Containers to Azure Container Service (i.e., Kubernetes)](#when-to-deploy-windows-containers-to-azure-container-service-i.e.-kubernetes)
-   [Build resilient services ready for the cloud: Embrace transient failures in the cloud ](#build-resilient-services-ready-for-the-cloud-embrace-transient-failures-in-the-cloud)
    -   [Handling partial failure](#handling-partial-failure)
        -   [Additional resources](#additional-resources-4)
-   [Modernize your apps with monitoring and telemetry](#modernize-your-apps-with-monitoring-and-telemetry)
    -   [Monitor your application with Application Insights](#monitor-your-application-with-application-insights)
    -   [Monitor your Docker infrastructure with Log Analytics and its Container Monitoring solution](#monitor-your-docker-infrastructure-with-log-analytics-and-its-container-monitoring-solution)
        -   [Additional resources](#additional-resources-5)
-   [Modernize your app's lifecycle with CI/CD pipelines and DevOps tools in the cloud](#modernize-your-apps-lifecycle-with-cicd-pipelines-and-devops-tools-in-the-cloud)
-   [Migrate to hybrid cloud scenarios](#migrate-to-hybrid-cloud-scenarios)
    -   [Azure Stack](#azure-stack)
        -   [Azure Stack integrated systems](#azure-stack-integrated-systems)
        -   [Azure Stack Development Kit](#azure-stack-development-kit)
        -   [Additional resources](#additional-resources-6)


> Vision: Lift and shift your existing .NET Framework applications to Cloud DevOps-Ready applications to drastically improve your deployment agility, so you can ship faster and lower app delivery costs.

To take advantage of the benefits of the cloud and new technologies like containers, you should at least partially modernize your existing .NET applications. Ultimately, modernizing your enterprise applications will lower your total cost of ownership.

Partially modernizing an app doesn't necessarily mean a full migration and re-architecture. You can initially modernize your existing applications by using a lift and shift process that's easy and fast. You can maintain your current code base, written in existing .NET Framework versions, with any Windows and IIS dependencies. Figure 4-1 highlights how Cloud DevOps-Ready apps are positioned in Azure application modernization maturity models.

![](./media/image1.png)

> **Figure 4-1.** Positioning Cloud DevOps-Ready applications


> [Previous](../migrate-your-relational-databases-to-azure/use-azure-database-migration-service-to-migrate-your-relational-databases-to-azure.md)  
[Next](reasons-to-lift-and-shift-existing-.net-apps-to-cloud-devops-ready-applications.md)
