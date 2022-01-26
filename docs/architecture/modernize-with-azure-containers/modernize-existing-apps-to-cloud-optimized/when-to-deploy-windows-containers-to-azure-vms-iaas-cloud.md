---
title: When to deploy Windows Containers to Azure VMs (IaaS cloud)
description: Modernize existing .NET applications with Azure Cloud and Windows containers | When to deploy Windows Containers to Azure VMs (IaaS cloud)
ms.date: 12/12/2021
---
# When to deploy Windows Containers to Azure VMs (IaaS cloud)

If your organization is using Azure VMs, even if you are also using Windows Containers, you are still dealing with IaaS. That means that dealing with infrastructure operations, VM OS patches, and infrastructure complexity for highly scalable applications when you need to deploy to multiple VMs in a load-balanced infrastructure. The main scenarios for using Windows Containers in an Azure VM are:

- **Dev/test environment**: A VM in the cloud is perfect for development and testing in the cloud. You can rapidly create or stop the environment depending on your needs.

- **Small and medium scalability needs**: In scenarios where you might need just a couple of VMs for your production environment, managing a few VMs might be affordable until you can move to more advanced PaaS environments, like orchestrators.

- **Production environment with existing deployment tools**: You might be moving from an on-premises environment in which you have invested in tools to make complex deployments to VMs or bare-metal servers (like Puppet or similar tools). To move to the cloud with minimal changes to production environment deployment procedures, you might continue to use those tools to deploy to Azure VMs. However, you'll want to use Windows Containers as the unit of deployment to improve the deployment experience.

>[!div class="step-by-step"]
>[Previous](when-to-deploy-windows-containers-in-your-on-premises-iaas-vm-infrastructure.md)
>[Next](when-to-deploy-windows-containers-to-azure-container-instances-ACI.md)
