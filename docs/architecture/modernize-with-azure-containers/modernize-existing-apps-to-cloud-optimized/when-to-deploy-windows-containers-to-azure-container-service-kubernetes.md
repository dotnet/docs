---
title: When to deploy Windows Containers to Azure Kubernetes Service
description: Modernize existing .NET applications with Azure Cloud and Windows containers | When to deploy Windows Containers to Azure Kubernetes Service
ms.date: 02/21/2022
---
# When to deploy Windows Containers to Azure Kubernetes Service (AKS)

[!INCLUDE [download-alert](../includes/download-alert.md)]

Azure Kubernetes Service (AKS) simplifies deploying a managed Kubernetes cluster in Azure by offloading the operational overhead to Azure. You get an open solution that offers portability both for your containers and for your application configuration. You select the size, the number of hosts, and the orchestrator tools. Azure Kubernetes Service handles the infrastructure for you. It also supports Windows Server containers alongside Linux containers. For more details on Windows OS support and the feature differences between Windows and Linux, read the [FAQ](/azure/aks/windows-faq).

The main benefits of Azure Kubernetes Service (AKS) are:

- Identity and security management
- Integrated logging and monitoring
- Cluster node and pod scaling.
- Ingress with HTTP application routing
- AKS supports the Docker image format. For private storage of your Docker images, you can integrate AKS with Azure Container Registry (ACR).

If you are already working with open-source orchestrators like Kubernetes, Docker Swarm, or DC/OS, you don't need to change your existing management practices to move container workloads to the cloud. Use the application management tools that you're already familiar with and connect via the standard API endpoints for the orchestrator of your choice.

>[!div class="step-by-step"]
>[Previous](when-to-deploy-windows-containers-to-azure-container-instances-ACI.md)
>[Next](choosing-azure-compute-options-for-container-based-applications.md)
