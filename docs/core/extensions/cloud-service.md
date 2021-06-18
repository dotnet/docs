---
title: Deploy a Worker Service to Azure
description: Learn how to deploy a .NET Worker Service to Azure.
author: IEvangelist
ms.author: dapine
ms.date: 06/18/2021
ms.topic: tutorial
zone_pivot_groups: development-environment-one
---

# Deploy a Worker Service to Azure

In this article, you'll learn how to deploy a .NET Worker Service to Azure. With your Worker running as an [Azure Container Instance (ACI)](/azure/container-instances) from the [Azure Container Registry (ACR)](/azure/container-registry), it can act as a microservice in the cloud. There are many use cases for long-running services, and the Worker Service exists for this reason.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Create a worker service.
> - Create an ACR resource.
> - Push an image to ACR.
> - Create an ACI resource.
> - Deploy an ACR image to ACI.
> - Verify worker service functionality.

## Prerequisites

- The [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download/dotnet).
- Docker Desktop ([Windows](https://docs.docker.com/docker-for-windows/install) or [Mac](https://docs.docker.com/docker-for-mac/install)).
- An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/dotnet).
:::zone target="docs" pivot="visualstudio"
- A .NET integrated development environment (IDE).
  - Feel free to use [Visual Studio, Visual Studio Code, or Visual Studio for Mac](https://visualstudio.microsoft.com).
:::zone-end
:::zone target="docs" pivot="vscode"
- A .NET integrated development environment (IDE).
  - Feel free to use [Visual Studio, Visual Studio Code, or Visual Studio for Mac](https://visualstudio.microsoft.com).
:::zone-end
:::zone target="docs" pivot="cli"
- Azure CLI.
  - [Install the Azure CLI](/cli/azure/install-azure-cli).
:::zone-end

<!-- ## Create a new project -->
[!INCLUDE [zoned-file-new-worker](includes/zoned-file-new-worker.md)]

### Add Docker support

:::zone target="docs" pivot="visualstudio"

In Visual Studio, right-click on the project node in the **Solution Explorer**, and select **Add** > **Docker Support**. You'll be prompted to select a **Target OS**, select **OK** with the default OS selection.

:::image type="content" source="media/docker-file-options.png" alt-text="Docker File Options":::

:::zone-end
:::zone target="docs" pivot="vscode"

In Visual Studio Code, you'll need the [Docker extension](https://code.visualstudio.com/docs/containers/overview) installed. Open the Command Palette, and select the **Docker: Add Docker files to workspace** option. If prompted to **Select Application Platform** choose **.NET: Core Console**. If prompted to **Select Project**, choose the Worker Service project you created. When prompted to **Select Operating System**, choose the first listed OS. When prompted whether or not to **Include optional Docker Compose files**, select **No**.

:::zone-end

Docker support requires a *Dockerfile*. This file is a set of comprehensive instructions, for building your .NET Worker Service as a Docker image. The following is an example *Dockerfile*, and should exist at the root directory of the project file:

:::code language="dockerfile" source="snippets/workers/cloud-service/Dockerfile":::

### Build the Docker image

To build the Docker image, the Docker Engine must be running.

:::zone target="docs" pivot="visualstudio"

Right-click on the *Dockerfile* in the **Solution Explorer**, and select **Build Docker Image**. The **Output** window pane displays, reporting the Docker build command progress.

:::zone-end
:::zone target="docs" pivot="vscode"

Right-click on the *Dockerfile* in the **Explorer**, and select **Build Image**. When prompted to **Tag image as**, enter `appcloudservice:latest`. The **Docker Task** output terminal displays, reporting the Docker build command progress.

> [!TIP]
> If you're _not_ prompted to tag the image, it's possible that Visual Studio Code is relying on an existing *tasks.json*. If the tag used is undesirable, you can change it by updating the `docker-build` configuration item's `dockerBuild/tag` value in the `tasks` array.
>
> :::code language="json" source="snippets/workers/.vscode/tasks.json" range="58-73" highlight="59,64-65":::

:::zone-end
:::zone target="docs" pivot="cli"

Open a terminal window in the root directory of the *Dockerfile*, and run the following docker command:

```console
docker build -t appcloudservice:latest -f Dockerfile .
```

:::zone-end

The `docker build` command runs, instructing Docker to process each line in the *Dockerfile*. This command builds the image and creates a local repository named **worker-service** that points to the image.

> [!TIP]
> The generated _Dockerfile_ differs between development environments. For example, if you [Add Docker support](#add-docker-support) from Visual Studio you cannot [Build the Docker image](#build-the-docker-image) from Visual Studio Code &mdash; as the _Dockerfile_ steps vary. It is best to choose a single development environment and use it through out.

## Create container registry

An Azure Container Registry (ACR) resource allows you to build, store, and manage container images and artifacts in a private registry. To create a container registry, you'll need to [create a new resource](https://ms.portal.azure.com/#create/Microsoft.ContainerRegistry) in the Azure portal.

1. Select the **Subscription**, and corresponding **Resource group** (or create a new one).
1. Enter a **Registry name**.
1. Select a **Location**.
1. Select an appropriate **SKU**, for example **Basic**.
1. Select **Review + create**.
1. After seeing **Validation passed**, select **Create**.

> [!IMPORTANT]
> In order to use this container registry when creating a container instance, you must enable **Admin user**. Select **Access keys**, and enable **Admin user**.

For more information, see [Quickstart: Create an Azure container registry](/azure/container-registry/container-registry-get-started-portal).

## Push image to ACR

With the .NET Docker image built, and the ACR resource created, you can now push the image to ACR.

:::zone target="docs" pivot="visualstudio"

Right-click on the project in the **Solution Explorer**, and select **Publish**. The **Publish** dialog displays. For the **Target**, select **Azure** and then **Next**.

:::image type="content" source="media/publish-dialog-azure.png" lightbox="media/publish-dialog-azure.png" alt-text="Visual Studio: Publish dialog - select Azure":::

For the **Specific Target**, select **Azure Container Registry** and then **Next**.

:::image type="content" source="media/publish-dialog-azure-acr.png" lightbox="media/publish-dialog-azure-acr.png" alt-text="Visual Studio: Publish dialog - select ACR":::

Next, for the **Container Registry**, select your **Subscription name** that you used to created the ACR resrouce. From the **Container registries** selection area, select the container registry that you created, and then select **Finish**.

:::image type="content" source="media/publish-dialog-azure-acr-registry.png" lightbox="media/publish-dialog-azure-acr-registry.png" alt-text="Visual Studio: Publish dialog - select container registry":::

This creates a publish profile, which can be used to publish the image to ACR. Select the **Publish** button to push the image to ACR, the **Output** window reports the publish progress &mdash; and when it completes successfully, you'll see a "Successfully published" message.

:::zone-end
:::zone target="docs" pivot="vscode"

Select **Docker** from the **Activity Bar** in Visual Studio Code. Expand the **IMAGES** tree view panel, then expand the `appcloudservice` image node and right-click on the `latest` tag.

:::image type="content" source="media/vs-code-push-image.png" alt-text="Visual Studio Code: Docker - push image":::

The integrated terminal window will report the progress of the `docker push` command to ACR.

:::zone-end
:::zone target="docs" pivot="cli"

Open a terminal window in the root directory of the *Dockerfile*, and run the following docker command:

```console
docker build -t worker-service -f Dockerfile .
```

:::zone-end

To verify that the image was successfully pushed to ACR, navigate to the Azure portal. Open the ACR resource, under **Services**, select **Repositories**. You should see the image.

## Create Container Instance

To create a Container Instance, you'll need to [create a new resource](https://ms.portal.azure.com/#create/Microsoft.ContainerInstances) in the Azure portal.

1. Select the same **Subscription**, and corresponding **Resource group** from the previous section.
1. Enter a **Container name**.
1. Select a **Region** that corresponds to the previous **Location** selection.
1. Select **Azure Container Registry**.
1. Select the **Registry** by the name provided in the previous step.
1. Select the **Image** and **Image tag**.
1. Select **Review + create**.
1. Assuming **Validation passed**, select **Create**.

For more information, see [Quickstart: Create an Azure container instance](/azure/container-instances/container-instances-quickstart-portal).

## Deploy 

## Verify service functionality

Immediately after the container instance is created, it starts running. From the Azure portal in the container instance resource, select the **Containers** option.

:::image type="content" source="media/container-instance-running.png" lightbox="media/container-instance-running.png" alt-text="Azure portal: Container instance running":::

You'll see the containers, and their current **State**. In this case it will be **Running**. Select **Logs** to see the .NET worker service output.

## See also

- [Worker Services in .NET](workers.md)
- [Use scoped services within a `BackgroundService`](scoped-service.md)
- [Create a Windows Service using `BackgroundService`](windows-service.md)
- [Implement the `IHostedService` interface](timer-service.md)
