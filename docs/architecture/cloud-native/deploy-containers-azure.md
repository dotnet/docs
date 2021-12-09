---
title: Deploying containers in Azure
description: Deploying Containers in Azure with Azure Container Registry, Azure Kubernetes Service, and Azure Dev Spaces.
ms.date: 11/28/2021
---

# Deploying containers in Azure

We've discussed containers in this chapter and in chapter 1. We've seen that containers provide many benefits to cloud-native applications, including portability. In the Azure cloud, you can deploy the same containerized services across staging and production environments. Azure provides several options for hosting these containerized workloads:

- Azure Kubernetes Services (AKS)
- Azure Container Instance (ACI)
- Azure Web Apps for Containers

## Azure Container Registry

When containerizing a microservice, you first build a container "image." The image is a binary representation of the service code, dependencies, and runtime. While you can manually create an image using the `Docker Build` command from the Docker API, a better approach is to create it as part of an automated build process.

Once created, container images are stored in container registries. They enable you to build, store, and manage container images. There are many registries available, both public and private. Azure Container Registry (ACR) is a fully managed container registry service in the Azure cloud. It persists your images inside the Azure network, reducing the time to deploy them to Azure container hosts. You can also secure them using the same security and identity procedures that you use for other Azure resources.

You create an Azure Container Registry using the [Azure portal](/azure/container-registry/container-registry-get-started-portal), [Azure CLI](/azure/container-registry/container-registry-get-started-azure-cli), or [PowerShell tools](/azure/container-registry/container-registry-get-started-powershell). Creating a registry in Azure is simple. It requires an Azure subscription, resource group, and a unique name. Figure 3-10 shows the basic options for creating a registry, which will be hosted at `registryname.azurecr.io`.

![Create container registry](./media/create-container-registry.png)

**Figure 3-10**. Create container registry

Once you've created the registry, you'll need to authenticate with it before you can use it. Typically, you'll log into the registry using the Azure CLI command:

```azurecli
az acr login --name *registryname*
```

Once authenticated, you can use docker commands to push container images to it. Before you can do so, however, you must tag your image with the fully qualified name (URL) of your ACR login server. It will have the format *registryname*.azurecr.io.

```console
docker tag mycontainer myregistry.azurecr.io/mycontainer:v1
```

After you've tagged the image, you use the `docker push` command to push the image to your ACR instance.

```console
docker push myregistry.azurecr.io/mycontainer:v1
```

After you push an image to the registry, it's a good idea to remove the image from your local Docker environment, using this command:

```console
docker rmi myregistry.azurecr.io/mycontainer:v1
```

As a best practice, developers shouldn't manually push images to a container registry. Instead, a build pipeline defined in a tool like GitHub or Azure DevOps should be responsible for this process. Learn more in the [Cloud-Native DevOps chapter](devops.md).

## ACR Tasks

[ACR Tasks](/azure/container-registry/container-registry-tasks-overview) is a set of features available from the Azure Container Registry. It extends your [inner-loop development cycle](../containerized-lifecycle/design-develop-containerized-apps/docker-apps-inner-loop-workflow.md) by building and managing container images in the Azure cloud. Instead of invoking a `docker build` and `docker push` locally on your development machine, they're automatically handled by ACR Tasks in the cloud.

The following AZ CLI command both builds a container image and pushes it to ACR:

```azurecli
# create a container registry
az acr create --resource-group myResourceGroup --name myContainerRegistry008 --sku Basic

# build container image in ACR and push it into your container registry
az acr build --image sample/hello-world:v1  --registry myContainerRegistry008 --file Dockerfile .
```

As you can see from the previous command block, there's no need to install Docker Desktop on your development machine. Additionally, you can configure ACR Task triggers to rebuild containers images on both source code and base image updates.

## Azure Kubernetes Service

We discussed Azure Kubernetes Service (AKS) at length in this chapter. We've seen that it's the de facto container orchestrator managing containerized cloud-native applications.

Once you deploy an image to a registry, such as ACR, you can configure AKS to automatically pull and deploy it. With a CI/CD pipeline in place, you might configure a [canary release](https://martinfowler.com/bliki/CanaryRelease.html) strategy to minimize the risk involved when rapidly deploying updates. The new version of the app is initially configured in production with no traffic routed to it. Then, the system will route a small percentage of users to the newly deployed version. As the team gains confidence in the new version, it can roll out more instances and retire the old. AKS easily supports this style of deployment.

As with most resources in Azure, you can create an Azure Kubernetes Service cluster using the portal, command-line, or automation tools like Helm or Terraform. To get started with a new cluster, you need to provide the following information:

- Azure subscription
- Resource group
- Kubernetes cluster name
- Region
- Kubernetes version
- DNS name prefix
- Node size
- Node count

This information is sufficient to get started. As part of the creation process in the Azure portal, you can also configure options for the following features of your cluster:

- Scale
- Authentication
- Networking
- Monitoring
- Tags

This [quickstart walks through deploying an AKS cluster using the Azure portal](/azure/aks/kubernetes-walkthrough-portal).

## Azure Bridge to Kubernetes

Cloud-native applications can grow large and complex, requiring significant compute resources to run. In these scenarios, the entire application can't be hosted on a development machine (especially a laptop). [Azure Bridge to Kubernetes](/visualstudio/bridge/overview-bridge-to-kubernetes) addresses the shortcoming. It enables developers to work with a local version of their service while hosting the entire application in an AKS development cluster.

When ready, developers test their changes locally while running against the full application in the AKS cluster - without replicating dependencies. Under the hood, the bridge merges code from the local machine with services in AKS. Developers can rapidly iterate and debug code directly in Kubernetes using Visual Studio or Visual Studio Code.

Gabe Monroy, former VP of Product Management at Microsoft, describes it well:

> Imagine you're a new employee trying to fix a bug in a complex microservices application consisting of dozens of components, each with their own configuration and backing services. To get started, you must configure your local development environment so that it can mimic production including setting up your IDE, building tool chain, containerized service dependencies, a local Kubernetes environment, mocks for backing services, and more. With all the time involved setting up your development environment, fixing that first bug could take days! Or you could just use Bridge to Kubernetes and AKS.

>[!div class="step-by-step"]
>[Previous](combine-containers-serverless-approaches.md)
>[Next](scale-containers-serverless.md)
