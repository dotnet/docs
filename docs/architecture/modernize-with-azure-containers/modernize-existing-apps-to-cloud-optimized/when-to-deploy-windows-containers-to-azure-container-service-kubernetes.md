---
title: When to deploy Windows Containers to Azure Container Service (that is, Kubernetes)
description: Modernize existing .NET applications with Azure Cloud and Windows containers | When to deploy Windows Containers to Azure Container Service (that is, Kubernetes)
ms.date: 12/12/2021
---
# When to deploy Windows Containers to Azure Container Service (that is, Kubernetes)

Azure Container Service optimizes the configuration of popular open-source tools and technologies specifically for Azure. You get an open solution that offers portability both for your containers and for your application configuration. You select the size, the number of hosts, and the orchestrator tools. Azure Container Service handles the infrastructure for you.

If you are already working with open-source orchestrators like Kubernetes, Docker Swarm, or DC/OS, you don't need to change your existing management practices to move container workloads to the cloud. Use the application management tools that you're already familiar with and connect via the standard API endpoints for the orchestrator of your choice.

All these orchestrators are mature environments if you are using Linux Docker containers, but might only be in Preview state for Windows Containers.

For example, in Kubernetes, support for containers is native (first-class citizen), so using Windows Containers on Kubernetes is also effective (in preview in ACS as of early 2018).

Important note: The evolved and "more PaaS" version of ACS (Azure Container Service) for Kubernetes is AKS (Azure Kubernetes Service), however, Windows Containers are still not supported as of Q2 2018, but it will be supported soon.

>[!div class="step-by-step"]
>[Previous](when-to-deploy-windows-containers-to-azure-container-instances-ACI.md)
>[Next](choosing-azure-compute-options-for-container-based-applications.md)
