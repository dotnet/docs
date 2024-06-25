---
title: Deployment with or without .Net Aspire
description: Architecture for Distributed Cloud-Native Apps with .NET Aspire & Containers | Deployment with or without the .Net Aspire
author: 
ms.date: 06/12/2024
---

# Deployment with or without .Net Aspire

[!INCLUDE [download-alert](../includes/download-alert.md)]

Deploying distributed applications is a complex process that involves various steps and considerations to ensure that the application runs smoothly across different environments. The introduction of .NET Aspire has streamlined this process significantly, offering a more efficient and reliable way to deploy distributed apps. However, it's also possible to deploy these applications without .NET Aspire, and you should continue to use conventional methods for existing applications because the configuration and testing of deployment has already been done.

## Without .NET Aspire

Deploying distributed applications without .NET Aspire involves a more hands-on approach. Developers can still use ASP.NET Core to create and manage distributed applications, but they miss out on the guidance and automation provided by .NET Aspire. The process typically involves manually setting up the infrastructure, configuring the environments, and ensuring that all components of the distributed system communicate effectively.

Without the streamlined process of .NET Aspire, developers need to be more vigilant about each step of the deployment. This includes creating deployment manifests manually, setting up CI/CD pipelines, and handling container orchestration platforms like Kubernetes without the assistance of .NET Aspire's tools.

For existing applications you should continue to use conventional methods because the deployment setup has already been done.

## With .NET Aspire

.NET Aspire simplifies the deployment of distributed apps by providing a cloud-agnostic framework that supports various platforms. It offers a deployment manifest that describes the structure of applications and the necessary properties for deployment, such as environment variables⁶. This manifest enables deployment tools from Microsoft and other cloud providers to understand and manage the application effectively.

For instance, deploying to Azure Container Apps is made easier with .NET Aspire. The Azure Developer CLI (AZD) has been extended to support .NET Aspire applications, allowing developers to provision and deploy resources on Azure with ease. Additionally, .NET Aspire apps are designed to emit telemetry using OpenTelemetry, which can be directed to Azure Monitor or Application Insights for monitoring and analysis.

When deploying to Kubernetes, .NET Aspire applications require mapping the JSON manifest to a Kubernetes YML manifest file. This can be done using the Aspir8 tool, which generates the necessary Kubernetes manifests based on the .NET Aspire app host manifest.

In conclusion, while .NET Aspire offers a more automated and error-free deployment experience, it is still possible to deploy distributed applications without it. The choice between using .NET Aspire or not depends on the specific needs of the project, the expertise of the development team, and the desired level of control over the deployment process.

## Additional resources

- [.NET Aspire deployments](https://learn.microsoft.com/en-us/dotnet/aspire/deployment/overview)
- [Deploy a .NET Aspire apps to Azure Container Apps](https://learn.microsoft.com/en-us/dotnet/aspire/deployment/azure/aca-deployment-azd-in-depth)
- [Deploy distributed .NET apps to the cloud with .NET Aspire and Azure](https://learn.microsoft.com/en-us/shows/azure-developers/deploy-distributed-dotnet-apps-to-the-cloud-with-dotnet-aspire-and-azure-container-apps)
- [How to deploy .NET Aspire apps to Azure Container Apps](https://devblogs.microsoft.com/dotnet/how-to-deploy-dotnet-aspire-apps-to-azure-container-apps/)
- [Deploy apps to Azure Container Apps easily with .NET Aspire](https://techcommunity.microsoft.com/t5/apps-on-azure-blog/deploy-apps-to-azure-container-apps-easily-with-net-aspire/ba-p/4032711)

>[!div class="step-by-step"]
>[Previous](development-vs-production.md)
>[Next](deployment-patterns.md)
