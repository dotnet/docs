---
title: Leveraging serverless functions
description: Architecting Cloud-native .NET Apps for Azure | Leveraging Serverless Functions
ms.date: 06/30/2019
---
# Leveraging serverless functions

In the spectrum of managing full machines and operating systems to leveraging cloud capabilities, serverless lives at the extreme end where the only thing you're responsible for is your code, and you only pay for your code when it runs. Azure Functions provides a way to build serverless capabilities into your applications. Traditionally, Azure Functions is built on the Azure platform or on infrastructure running the Azure Stack or the Azure Functions Runtime. However, you can also run Azure Functions within a Docker container for additional portability and flexibility. Adding support for docker to an Azure Functions project is as simple as adding a switch to the command line:

```cli
func init ProjectName --docker
```

When creating an Azure Function, you must choose the programming language you want to use from these options:

- `dotnet` (C#)
- `node` (JavaScript)
- `python`

When the project is created, it will include a Dockerfile. Next, you can create and test your function locally. For detailed steps to get started building Azure Functions with Docker support, see the [Create a function on Linux using a custom image](https://docs.microsoft.com/azure/azure-functions/functions-create-function-linux-custom-image) tutorial.

## References

- [Create a function on Linux using a custom image](https://docs.microsoft.com/azure/azure-functions/functions-create-function-linux-custom-image)

>[!div class="step-by-step"]
>[Previous](leverage-containers-orchestrators.md)
>[Next](combine-containers-serverless-approaches.md)
