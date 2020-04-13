---
title: Other container deployment options
description: Other Container Deployment Options using Azure
ms.date: 04/10/2020
---
# Other container deployment options

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

Aside from Azure Kubernetes Service (AKS), you can also deploy containers to Azure App Service for Containers and Azure Container Instances.

## When does it make sense to deploy to App Service for Containers?

Simple production applications that don't require orchestration are well suited to Azure App Service for Containers.

## How to deploy to App Service for Containers

To deploy to [Azure App Service for Containers](https://azure.microsoft.com/services/app-service/containers/), you'll need an Azure Container Registry (ACR) instance and credentials to access it. Push you container image to the ACR repository so it's available to pull into your Azure App Service. Once complete, you can configure the app for Continuous Deployment. Doing so will automatically deploy updates whenever the image changes in ACR.

## When does it make sense to deploy to Azure Container Instances?
 
[Azure Container Instances (ACI)](https://azure.microsoft.com/services/container-instances/) enables you to run Docker containers in a managed, serverless cloud environment, without having to set up virtual machines or clusters. It's a great solution for short-running workloads that can run in an isolated container. Consider ACI for simple services, testing scenarios, task automation, and build jobs. ACI spins-up a container instance, performs the task, and then spins it down.  

## How to deploy an app to Azure Container Instances

To deploy to [Azure Container Instances (ACI)](https://docs.microsoft.com/azure/container-instances/), you need an Azure Container Registry (ACR) and credentials for accessing it. Once you push your container image to the repository, it's available to pull into ACI. You can work with ACI using the Azure portal or command-line interface. ACR provides tight integration with ACI. Figure 3-14 shows how to push an individual container image to ACR.

![Azure Container Registry Run Instance](./media/acr-runinstance-contextmenu.png)

**Figure 3-14**. Azure Container Registry Run Instance

Creating an instance in ACI can be done quickly. Specify the image registry, Azure resource group information, the amount of memory to allocate, and the port on which to listen. This [quickstart shows how to deploy a container instance to ACI using the Azure portal](https://docs.microsoft.com/azure/container-instances/container-instances-quickstart-portal).

Once the deployment completes, find the newly deployed container's IP address and communicate with it over the port you specified.

Azure Container Instances offers the fastest way to run simple container workloads in Azure. You don't need to configure an app service, orchestrator, or virtual machine. For scenarios where you require full container orchestration, service discovery, automatic scaling, or coordinated upgrades, we recommend Azure Kubernetes Service (AKS).

## References

- [Azure Container Instances Docs](https://docs.microsoft.com/azure/container-instances/)
- [Deploy Container Instance from ACR](https://docs.microsoft.com/azure/container-instances/container-instances-using-azure-container-registry#deploy-with-azure-portal)

>[!div class="step-by-step"]
>[Previous](scale-containers-serverless.md)
>[Next](communication-patterns.md)
