---
title: Deploying distributed apps with .NET Aspire
description: Architecture for Distributed Cloud-Native Apps with .NET Aspire & Containers | Deploying distributed apps with .NET Aspire
author: 
ms.date: 06/12/2024
---

# Deploying distributed apps with .NET Aspire

[!INCLUDE [download-alert](../includes/download-alert.md)]

In this topic, we will discuss .NET Aspire extensibility and the steps to deploy solutions to some popular cloud hosting platforms using .NET Aspire.

## .NET Aspire extensibility

.NET Aspire is created to be extensible so that you can configure it specifically for your needs and so that the developer community can share additional functionality. A good example of this is Aspir8. Soon after the initial release of .NET Aspire a developer and chief technology officer from the UK called David Sekula created Aspir8, a tool that publishes .NET Aspire solutions to Kubernetes clusters.

Developers can participate by sharing feedback, discussing ideas, and contributing code on the [.NET Aspire GitHub repo](https://github.com/dotnet/aspire)

### .NET Aspire manifest file

A key aspect of .NET Aspire is the manifest file. A manifest file is a JSON document that describes all of the resources required for a .NET Aspire project. A manifest file is generated when you build a .NET Aspire project, or by running the following command:

```dotnetcli
dotnet run --publisher manifest --output-path manifest.json
```

To build tools for .NET Aspire you can create your own manifest files enabling you to deploy .NET Aspire projects to additional hosting platforms.

For more information on the structure of a manifest file, see [.NET Aspire manifest format for deployment tool builders](https://learn.microsoft.com/dotnet/aspire/deployment/manifest-format)

You can also use the extensibility of .NET Aspire to create your own reusable building blocks for your solution. For more information on creating your own .NET Aspire resources, see [Create custom resource types for .NET Aspire](https://learn.microsoft.com/dotnet/aspire/extensibility/custom-resources)

## How to deploy a .NET Aspire solution to Azure using Azure Developer CLI (azd)

To deploy a NET Aspire solution to Azure, complete the following steps:

1. **Create a .NET Aspire solutions**:
   - Start by creating a .NET Aspire solution using the [.NET Aspire Starter Application template](https://learn.microsoft.com/en-us/dotnet/aspire/quickstart).
   - This template provides a solid foundation for your distributed application.

2. **Install the Azure Developer CLI (azd)**:
   - Install azd based on your operating system (available via winget, brew, apt, or directly via curl).
   - Refer to the [Install Azure Developer CLI](https://learn.microsoft.com/en-us/dotnet/aspire/deployment/azure/aca-deployment#install-azure-developer-cli) guide.

3. **Initialize the Template**:
   - Open a terminal and navigate to the *AppHost* project directory of your .NET Aspire solution.
   - Execute the `azd init` command to initialize your project with azd.
   - The CLI inspects your local directory structure and determines the app type.
   - For more information on the `azd init` command, see the [azd init documentation](https://learn.microsoft.com/en-us/dotnet/aspire/deployment/azure/aca-deployment#azure-developer-cli).

:::image type="content" source="media/azdinit.png" alt-text="A diagram showing an azd init command." border="false":::

**Figure 14-1**. azd init

4. **Provision and deploy your solution**:
   - Execute the `azd up` command from the *AppHost* project to begin the provision and deployment process.
   - Select the subscription that you'd like to deploy.
   - Select the Azure region to deploy to.

For more information, see [Deploy a .NET Aspire project to Azure Container Apps](https://learn.microsoft.com/dotnet/aspire/deployment/azure/aca-deployment)

For an in-depth guide using GitHub Actions, check out [Deploy a .NET Aspire app using the Azure Developer CLI and GitHub Actions](https://learn.microsoft.com/en-us/dotnet/aspire/deployment/azure/aca-deployment-github-actions).


## How to deploy a .NET Aspire app to Amazon Web Services (AWS)

Because of the extensible nature of .NET Aspire yoiu can deploy to alternative web platforms, either using your own code, or by implementing community created packages.

To deploy a .NET Aspire solution to AWS, complete the following steps:

1. Install the Aspire.Hosting.AWS package in your *AppHost* project.
1. Configuring the AWS SDK for .NET specifying the AWS profile and region.
1. Provision any required AWS application resources using a CloudFormation template.
1. Import any existing AWS resources ussing the *AddAWSCloudFormationStack* method.
1. Provision and deploy your solution.

For more information, see [Aspire.Hosting.AWS readme](https://www.nuget.org/packages/Aspire.Hosting.AWS/8.0.1-preview.8.24267.1#readme-body-tab)

## How to deploy a .NET Aspire app to Kubernetes

Kubernetes is a widely used cloud-agnostic container orchestration service. As such, Kubernetes is widely used for distributed microservices solutions. Aspir8 is a community created .NET Aspire tool to deploy solutions to Kubernetes. To deploy to a Kubernetes cluster using Aspir8, complete the following steps:

1. Generate a .NET Aspire manifest file.
1. Edit the manifest.json file, as necessary.
1. Initialize Aspir8 by executing *aspirate init*.
1. Build the Project by executing *aspirate build*.
1. Generate the Kubernetes files by executing *aspirate generate*.
1. Deploy the solution by executing *aspirate apply*.

For more information, see [.NET 8, Aspire, & Aspir8: Deploy Microservices Into Dev Environments Effortlessly with CLI](https://medium.com/@josephsims1/aspire-aspi8-deploy-microservices-effortlessly-with-cli-no-docker-or-yaml-needed-f30b58443107)

>[!div class="step-by-step"]
>[Previous](distribution-patterns.md)
>[Next](---TO DO---)