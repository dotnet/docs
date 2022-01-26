---
title: When to deploy Windows Containers to Azure Container Instances (ACI)
description: Modernize existing .NET applications with Azure Cloud and Windows containers | When to deploy Windows Containers to Azure Container Instances (ACI)
ms.date: 12/12/2021
---

# When to deploy Windows Containers to Azure Container Instances (ACI)

The main value proposition of Azure Container Instances is that you can right away deploy containers to it and you don't need to maintain that environment, you don't need to upgrade/patch the underlying operating system or VMs, all that is transparent and you just deploy containers into a ready-to-use environment.

The reasons and scenarios when you would want to use ACI are similar to the main scenarios when you use Azure VMs with containers, so basically, the main scenarios for using Azure Container Instances are:

- **Dev/Test scenarios**
- **Task automation**
- **CI/CD agents**
- **Small/scale batch processing**
- **Simple web apps**

The simple web apps scenario is a fair scenario for ACI but take into account that since in ACI you can only have a single container instance per container image, you won't have high availability and only have limited scalability.

However, even when ACI is considered infrastructure because it just provides single container instances, there is a huge benefit compared to regular Azure VMs with Windows Server. With ACI, you just deploy the containers into a self-maintained environment and you just pay for those containers. You don't need to maintain/update/patch VMs, so it is a much better platform for most scenarios where you might be using VMs with containers. Using ACI is straight forward, you just deploy a container, there's no need to create a VM environment you just deploy containers.

The main benefits of Azure Container Instances (ACI) are:

- Run containers without managing servers
- Increase agility with containers on demand
- Deploy containers to the cloud with unprecedented simplicity and speed—with a single command.
- Secure applications with hypervisor isolation

In short, with ACI you can develop apps fast without managing virtual machines or having to learn new tools. It's just your application, in a container, running in the cloud.

> [!div class="step-by-step"]
> [Previous](when-to-deploy-windows-containers-to-azure-vms-iaas-cloud.md)
> [Next](when-to-deploy-windows-containers-to-azure-container-service-kubernetes.md)
