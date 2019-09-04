---
title: Combining containers and serverless approaches
description: Architecting Cloud-native .NET Apps for Azure | Combining Containers and Serverless Approaches
ms.date: 06/30/2019
---
# Combining containers and serverless approaches

Frequently, microservices-based applications rely heavily on containers, orchestration, and message-passing for communication between nodes. This messaging is an ideal task for Azure Functions, but with the rest of the application configured and deployed using Kubernetes and related tools, it would be nice to be able to leverage Azure Functions within this same toolset. Fortunately, you can wrap Azure Functions in Docker containers and deploy them using the same processes and tools as the rest of your Kubernetes-based app.

Note that one of the primary benefits of leveraging functions is that the consumption plan allows you to only pay for when your functions are running. If you migrate your functions to Docker containers that are deployed and managed through your Kubernetes cluster, you'll no longer benefit from this serverless feature or from Azure Functions' built-in scale out feature. Instead, you'll benefit from having a consistent development and deployment process that will allow you to host your Function apps locally or compose them within your AKS cluster in whatever way best suits your app's needs.

To wrap an Azure Function in a Docker container, you should install the Azure Functions Core Tools and then run the `func init --docker` command. Choose which worker runtime you want (for example, dotnet), and the project will be generated for you, along with a Dockerfile. Now that the app is set up, you can build and run it using the  `docker build` and `docker run` commands, as shown in [this walkthrough](https://markheath.net/post/azure-functions-docker).

## Azure functions with Kubernetes Event Driven Autoscaling (KEDA)

Azure functions scale automatically to meet demand based on the rate of events that are targeting a given function. Additionally, you can leverage Kubernetes to host your functions in Docker containers with event-driven scaling using KEDA. When no events are occurring, KEDA can scale down to 0 instances, and then in response to events it can scale up the number of containers to meet the demand. [Learn more about scaling Azure functions with KEDA](https://docs.microsoft.com/azure/azure-functions/functions-kubernetes-keda).

## References

- [Run Azure Functions in a Docker Container](https://markheath.net/post/azure-functions-docker)
- [Azure Functions with Kubernetes Event Driven Autoscaling](https://docs.microsoft.com/azure/azure-functions/functions-kubernetes-keda)

>[!div class="step-by-step"]
>[Previous](leverage-serverless-functions.md)
>[Next](deploy-containers-azure.md)
