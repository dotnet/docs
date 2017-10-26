---
title: Use Azure Site Recovery to migrate your existing VMs to Azure VMs | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Use Azure Site Recovery to migrate your existing VMs to Azure VMs
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/28/2017
---
# Use Azure Site Recovery to migrate your existing VMs to Azure VMs

As part of the end-to-end [Azure Migrate](https://aka.ms/azuremigrate), [Azure Site Recovery](https://docs.microsoft.com/en-us/azure/site-recovery/site-recovery-overview) is a tool that you can use to easily migrate your web apps to VMs in Azure. You can use Site Recovery to replicate on-premises VMs and physical servers to Azure, or to replicate them to a secondary on-premises location. You can even replicate a workload that's running on a supported Azure VM, on an on-premises *Hyper-V* VM, on a *VMware* VM, or on a Windows or Linux physical server. Replication to Azure eliminates the cost and complexity of maintaining a secondary datacenter.

Site Recovery is also made specifically for hybrid environments that are partly on-premises and partly on Azure. Site Recovery helps ensure business continuity by keeping your apps that are running on VMs and on-premises physical servers available if a site goes down. It replicates workloads that are running on VMs and physical servers so that they remain available in a secondary location if the primary site isn't available. It recovers workloads to the primary site when it's up and running again.

Figure 2-3 shows the execution of multiple VM migrations by using Azure Site Recovery.

![](./media/image3.png)

> **Figure 2-3.** Positioning Cloud Infrastructure-Ready applications

### Additional resources

-   **Azure Migrate Datasheet**

    https://aka.ms/azuremigration\_datasheet

-   **Azure Migrate**

    http://azuremigrationcenter.com/

-   **Migrate to Azure with Site Recovery**

    https://docs.microsoft.com/en-us/azure/site-recovery/site-recovery-migrate-to-azure

-   **Azure Site Recovery service overview**

    <https://docs.microsoft.com/en-us/azure/site-recovery/site-recovery-overview>

-   **Migrating VMs in AWS to Azure VMs**

    <https://docs.microsoft.com/en-us/azure/site-recovery/site-recovery-migrate-aws-to-azure>

> [Previous](use-azure-migrate-to-analyze-and-migrate-your-existing-applications-to-azure.md)  
[Next](../migrate-your-relational-databases-to-azure/index.md)
