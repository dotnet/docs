---
title: Other Deployment Options
description: Architecting Cloud Native .NET Apps for Azure | Other Deployment Options
ms.date: 06/30/2019
---
# Other Deployment Options

In addition to deploying to AKS, you can also deploy containers to Azure App Service for Containers and Azure Container Instances. Simple production applications that don't require orchestration are well-suited to Azure App Service for Containers. Azure Container Instances are best used for testing scenarios.

## App Service for Containers

To deploy to [Azure App Service for Containers](https://azure.microsoft.com/services/app-service/containers/), you need to have configured an Azure Container Registry (ACR) and credentials for accessing it. Push the container you intend to host to the registry so it's available to pull into your Azure App Service. Once created, you can configure the app for Continuous Deployment, which will automatically deploy updates to the app whenever you update its corresponding image in ACR.

## Azure Container Instances

To deploy to [Azure Container Instances (ACI)](https://docs.microsoft.com/azure/container-instances/), you need to have configured an Azure Container Registry (ACR) and credentials for accessing it. You must also have previously pushed your container image to the registry, so it's available to pull into ACI. You can work with ACI using the Azure CLI or through the portal. Azure Container Registries make it easy to deploy individual container instances to ACI directly from within the registry, as shown in Figure 3-17.

![Azure Container Registry Run Instance](./media/acr-runinstance-contextmenu.png)
**Figure 3-17**. Azure Container Registry Run Instance

Creating a container instance from the registry just requires specifying the usual Azure settings (name, subscription, resource group, and location) as well as how much memory to allocate to the container and which port it should listen on. Figure 3-18 shows the Azure Portal form used to create the new instance.

![ACR Run Instance Create container instance](./media/acr-create-deeplink.png) \
**Figure 3-18**. ACR Run Instance Create container instance

Once the deployment completes, you can find the newly deployed container's IP address and communicate with it over the port you specified.

Azure Container Instances offers the fastest, simplest way to run a container in Azure. There's no need to configure an app service or an orchestrator or to deal with virtual machines. However, because of its simplicity, ACI should primarily be used for testing purposes. If your application requires automatic scalability, multiple containers configured to work together, or any additional complex features, there are other better-suited Azure services available to host your app.

## References

- [Azure Container Instances Docs](https://docs.microsoft.com/azure/container-instances/)
- [Deploy Container Instance from ACR](https://docs.microsoft.com/azure/container-instances/container-instances-using-azure-container-registry#deploy-with-azure-portal)

>[!div class="step-by-step"]
>[Previous](deploy-containers-azure.md)
>[Next](communication-patterns.md) <!-- Next Chapter -->
