---
title: Deploy a Worker Service to Azure
description: Learn how to deploy a .NET Worker Service to Azure.
author: IEvangelist
ms.author: dapine
ms.date: 06/02/2021
ms.topic: tutorial
zone_pivot_groups: development-experience-one
---

# Deploy a Worker Service to Azure

In this article, you'll learn how to deploy a .NET Worker Service to Azure. With your Worker running as an [Azure Container Instance (ACI)](/azure/container-instances) from the [Azure Container Registry (ACR)](/azure/container-registry), it can act as a microservice in the cloud. There are many use cases for long-running services, and the Worker Service exists for this reason.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Create a worker service.
> - Create an Azure Container Registry resource.
> - Create an Azure Container Instance resource.
> - Deploy the worker service to Azure.
> - Monitor worker service activity.

## Prerequisites

- The [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- Docker Desktop ([Windows](https://docs.docker.com/docker-for-windows/install) or [Mac](https://docs.docker.com/docker-for-mac/install)).
- An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/dotnet).
- A .NET integrated development environment (IDE)
  - Feel free to use [Visual Studio, Visual Studio Code, or Visual Studio for Mac](https://visualstudio.microsoft.com)

<!-- ## Create a new project -->
[!INCLUDE [zoned-file-new-worker](includes/zoned-file-new-worker.md)]

### Add Docker support

:::zone target="docs" pivot="visualstudio"

In Visual Studio, right-click on the project, and select **Add** > **Docker Support**.

:::zone-end
:::zone target="docs" pivot="vscode"

In Visual Studio Code, you'll need the [Docker extension](https://code.visualstudio.com/docs/containers/overview) installed. Open the Command Palette, and select the **Docker: Add Docker files to workspace** option. If prompted to **Select Application Platform** choose **.NET: Core Console**. If prompted to **Select Project**, choose the Worker Service project you created. When prompted to **Select Operating System**, choose the desired OS. When prompted whether or not to **Include optional Docker Compose files**, choose **No**.

:::zone-end

Docker support requires a *Dockerfile*. This file is a set of comprehensive instructions, for building your .NET Worker Service as a Docker image. The following is an example *Dockerfile*, and should exist at the root directory of the project file:

:::code language="dockerfile" source="snippets/workers/cloud-service/Dockerfile":::

### Build the Docker image

:::zone target="docs" pivot="visualstudio"

Right-click on the *Dockerfile* in the **Solution Explorer**, and select **Build Docker Image**.

:::zone-end
:::zone target="docs" pivot="vscode"

Right-click on the *Dockerfile* in the **Explorer**, and select **Build Image**.

:::zone-end
:::zone target="docs" pivot="vscode"

Open a terminal window in the root directory of the *Dockerfile*, and run the following docker command:

```console
docker build -t worker-service -f Dockerfile .
```

Docker will process each line in the Dockerfile. The `.` in the `docker build` command tells Docker to use the current folder to find a *Dockerfile*. This command builds the image and creates a local repository named **worker-service** that points to that image.

:::zone-end

## Create Container Registry

An Azure Container Registry (ACR) resource allows you to build, store, and manage container images and artifacts in a private registry. To create a Container Registry, you'll need to [create a new resource](https://ms.portal.azure.com/#create/Microsoft.ContainerRegistry) in the Azure portal.

1. Select the **Subscription**, and corresponding **Resource group** (or create a new one).
1. Enter a **Registry name**.
1. Select a **Location**.
1. Select an appropriate **SKU**, for example **Basic**.
1. Select **Review + create**.
1. Assuming **Validation passed**, select **Create**.

## Push image to ACR

TODO: ...

## Create Container Instance

To create a Container Instance, you'll need to [create a new resource](https://ms.portal.azure.com/#create/Microsoft.ContainerInstances) in the Azure portal.

1. Select the same **Subscription**, and corresponding **Resource group** from the previous section.
1. Enter a **Container name**.
1. Select a **Region** that corresponds to the previous **Location** selection.
1. Select **Azure Container Registry**.
1. Select the **Registry** by the name provided in the previous step.
1. Select the **Image** and**Image tag**.
1. Select **Review + create**.
1. Assuming **Validation passed**, select **Create**.

## Verify service functionality

TODO: ...

## See also

- [Worker Services in .NET](workers.md)
- [Use scoped services within a `BackgroundService`](scoped-service.md)
- [Create a Windows Service using `BackgroundService`](windows-service.md)
- [Implement the `IHostedService` interface](timer-service.md)
