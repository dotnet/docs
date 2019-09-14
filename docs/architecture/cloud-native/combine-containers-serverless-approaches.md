---
title: Combining containers and serverless approaches
description: Architecting Cloud-native .NET Apps for Azure | Combining Containers and Serverless Approaches
ms.date: 06/30/2019
---
# Combining containers and serverless approaches

Frequently, microservices-based applications rely heavily on containers, orchestration, and message-passing for communication between nodes. This messaging is an ideal task for Azure Functions, but with the rest of the application configured and deployed using Kubernetes and related tools, it would be nice to be able to leverage Azure Functions within this same toolset. Fortunately, you can wrap Azure Functions in Docker containers and deploy them using the same processes and tools as the rest of your Kubernetes-based app.

## When does it make sense to use containers with serverless?

By default, your serverless functions have no knowledge of the platform on which they will run. However, in some cases you may have specific requirements that make it important for you to customize the container image in which your code will run. You may want to use a custom image because your function relies on a specific language version or has dependencies or configuration requirements that aren't supported by the default image. In these cases, it may make sense to customize your own container and deploy your function in a custom Docker container.

## When should you avoid using containers with Azure Functions?

If you're expecting to benefit from the consumption plan billing for your function, you won't be able to do so if you're using your own container. What's more, if you go beyond just using a Docker container and deploy your functions to your own Kubernetes cluster, you'll no longer benefit from the built-in scaling provided by Azure Functions. You'll need to use Kubernetes' scaling features, described below.

## How to combine serverless and Docker containers

To wrap an Azure Function in a Docker container, install the Azure Functions Core Tools and then run the following command:

```cli
func init ProjectName --docker
```

Choose which worker runtime you want from the following options:

- `dotnet` (C#)
- `node` (JavaScript)
- `python`

When the project is created, it will include a Dockerfile. Now, you can create and test your function locally. Build and run it using the  `docker build` and `docker run` commands. For detailed steps to get started building Azure Functions with Docker support, see the [Create a function on Linux using a custom image](https://docs.microsoft.com/azure/azure-functions/functions-create-function-linux-custom-image) tutorial.

## How to combine serverless and Kubernetes with KEDA

Azure functions scale automatically to meet demand based on the rate of events that are targeting a given function. Additionally, you can leverage Kubernetes to host your functions and use Kubernetes-based Event Driven Autoscaling, or KEDA. When no events are occurring, KEDA can scale down to 0 instances, and then in response to events it can scale up the number of containers to meet the demand using its horizontal pod autoscaler. [Learn more about scaling Azure functions with KEDA](https://docs.microsoft.com/azure/azure-functions/functions-kubernetes-keda).

## References

- [Run Azure Functions in a Docker Container](https://markheath.net/post/azure-functions-docker)
- [Create a function on Linux using a custom image](https://docs.microsoft.com/azure/azure-functions/functions-create-function-linux-custom-image)
- [Azure Functions with Kubernetes Event Driven Autoscaling](https://docs.microsoft.com/azure/azure-functions/functions-kubernetes-keda)

>[!div class="step-by-step"]
>[Previous](leverage-serverless-functions.md)
>[Next](deploy-containers-azure.md)
