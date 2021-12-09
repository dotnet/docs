---
title: Combining containers and serverless approaches for cloud-native services
description: Combining containers and Kubernetes with serverless approaches
ms.date: 05/13/2020
---

# Combining containers and serverless approaches

Cloud-native applications typically implement services leveraging containers and orchestration. There are often opportunities to expose some of the application's services as Azure Functions. However, with a cloud-native app deployed to Kubernetes, it would be nice to leverage Azure Functions within this same toolset. Fortunately, you can wrap Azure Functions inside Docker containers and deploy them using the same processes and tools as the rest of your Kubernetes-based app.

## When does it make sense to use containers with serverless?

Your Azure Function has no knowledge of the platform on which it's deployed. For some scenarios, you may have specific requirements and need to customize the environment on which your function code will run. You'll need a custom image that supports dependencies or a configuration not supported by the default image. In these cases, it makes sense to deploy your function in a custom Docker container.

## When should you avoid using containers with Azure Functions?

If you want to use consumption billing, you can't run your function in a container. What's more, if you deploy your function to a Kubernetes cluster, you'll no longer benefit from the built-in scaling provided by Azure Functions. You'll need to use Kubernetes' scaling features, described earlier in this chapter.

## How to combine serverless and Docker containers

To wrap an Azure Function in a Docker container, install the [Azure Functions Core Tools](https://github.com/Azure/azure-functions-core-tools) and then run the following command:

```console
func init ProjectName --worker-runtime dotnet --docker
```

When the project is created, it will include a Dockerfile and the worker runtime configured to `dotnet`. Now, you can create and test your function locally. Build and run it using the  `docker build` and `docker run` commands. For detailed steps to get started building Azure Functions with Docker support, see the [Create a function on Linux using a custom image](/azure/azure-functions/functions-create-function-linux-custom-image) tutorial.

## How to combine serverless and Kubernetes with KEDA

In this chapter, you've seen that the Azure Functions' platform automatically scales out to meet demand. When deploying containerized functions to AKS, however, you lose the built-in scaling functionality. To the rescue comes [Kubernetes-based Event Driven (KEDA)](/azure/azure-functions/functions-kubernetes-keda). It enables fine-grained autoscaling for `event-driven Kubernetes workloads,` including containerized functions.

KEDA provides event-driven scaling functionality to the Functions' runtime in a Docker container. KEDA can scale from zero instances (when no events are occurring) out to `n instances`, based on load. It enables autoscaling by exposing custom metrics to the Kubernetes autoscaler (Horizontal Pod Autoscaler). Using Functions containers with KEDA makes it possible to replicate serverless function capabilities in any Kubernetes cluster.

It's worth noting that the KEDA project is now managed by the Cloud Native Computing Foundation (CNCF).

>[!div class="step-by-step"]
>[Previous](leverage-serverless-functions.md)
>[Next](deploy-containers-azure.md)
