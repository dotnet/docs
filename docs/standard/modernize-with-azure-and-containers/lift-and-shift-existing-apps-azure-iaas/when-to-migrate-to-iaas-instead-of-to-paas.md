---
title: When to migrate to IaaS instead of to PaaS | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | When to migrate to IaaS instead of to PaaS
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/28/2017
---
# When to migrate to IaaS instead of to PaaS

In the next sections, we discuss Cloud DevOps-Ready applications that are mostly based on PaaS platforms and services. These apps give you the most benefits from migrating to the cloud.

If your goal is simply to move existing applications to the cloud, first, identify existing applications that will require substantial modification to run in Azure App Service. These apps should be the first candidates.

Then, if you don't want or still cannot move to Windows Containers and or orchestrators like Azure Service Fabric or Kubernetes, yet, then is when you would use plain VMs (IaaS).

But, keep in mind that correctly configuring, securing, and maintaining VMs requires much more time and IT expertise compared to using PaaS services in Azure. If you are considering Azure Virtual Machines, make sure that you take into account the ongoing maintenance effort required to patch, update, and manage your VM environment. Azure Virtual Machines is IaaS.



> [Previous](why-migrate-existing-.net-web-applications-to-azure-iaas.md)  
[Next](use-azure-migrate-to-analyze-and-migrate-your-existing-applications-to-azure.md)
