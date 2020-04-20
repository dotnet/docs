---
title: Combining containers and serverless approaches for cloud-native services
description: Combining Containers and Kubernetes with Serverless Approaches
ms.date: 04/13/2020
---

# Combining containers and serverless approaches

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

Cloud-native applications typically implement services leveraging containers and orchestration. There are often opportunities to expose some of the application's services as Azure Functions. However, with a cloud-native app deployed to Kubernetes, it would be nice to leverage Azure Functions within this same toolset. Fortunately, you can wrap Azure Functions inside Docker containers and deploy them using the same processes and tools as the rest of your Kubernetes-based app.

## When does it make sense to use containers with serverless?

By default, your Azure Function has no knowledge of the platform on which it's deployed. In some cases, you may have specific requirements and need to customize the environment on which your function code will run. You'll need a custom image that supports dependencies or a configuration not supported by the default image. In these cases, it makes sense to deploy your function in a custom Docker container.

## When should you avoid using containers with Azure Functions?

If you want to use consumption billing, you won't be able to run your function in a container. What's more, if you deploy your function to a Kubernetes cluster, you'll no longer benefit from the built-in scaling provided by Azure Functions. You'll need to use Kubernetes' scaling features, described earlier in this chapter.

## How to combine serverless and Docker containers

To wrap an Azure Function in a Docker container, install the [Azure Functions Core Tools](https://github.com/Azure/azure-functions-core-tools) and then run the following command:

```console
func init ProjectName --docker
```

Choose which worker runtime you want from the following options:

- `dotnet` (C#)
- `node` (JavaScript)
- `python`

When the project is created, it will include a Dockerfile. Now, you can create and test your function locally. When deploying a function in containers, the ritual of building an image and hosting a container isn't necessary. You write your function code, include a Docker file, and trigger the function. It deploys without additional overhead or configuration.

When creating Azure functions, you'll want to reference version 3 of the Azure Functions runtime, which targets .NET Core 3.1 and later. [This link](https://docs.microsoft.com/azure/azure-functions/functions-versions) describes the runtime versions available for Azure Functions.

For detailed steps to get started building Azure Functions with Docker support, see the [Create a function on Linux using a custom image](https://docs.microsoft.com/azure/azure-functions/functions-create-function-linux-custom-image) tutorial.

## How to combine serverless and Kubernetes with KEDA

In this chapter, you've seen that the Azure Functions' platform automatically scales out your functions to meet demand. When deploying containerized functions to AKS, however, you lose the built-in scaling functionality. To the rescue comes [Kubernetes-based Event Driven (KEDA)](https://docs.microsoft.com/azure/azure-functions/functions-kubernetes-keda). It enables fine-grained autoscaling for `event-driven Kubernetes workloads,` including containerized functions.

KEDA provides event-driven scaling functionality to the Functions' runtime in a Docker container. KEDA can scale from zero instances (when no events are occurring) out to `n instances`, based on load. It enables autoscaling by exposing custom metrics to the Kubernetes autoscaler (Horizontal Pod Autoscaler). Using Functions containers with KEDA makes it possible to replicate serverless function capabilities in any Kubernetes cluster.

It is worth noting that the KEDA project is now managed by the Cloud Native Computing Foundation (CNCF).

>[!div class="step-by-step"]
>[Previous](leverage-serverless-functions.md)
>[Next](deploy-containers-azure.md)
