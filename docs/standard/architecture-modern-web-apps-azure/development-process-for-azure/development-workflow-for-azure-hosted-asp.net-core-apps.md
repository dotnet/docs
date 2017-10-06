---
title: Development workflow for Azure-hosted ASP.NET Core apps | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Development workflow for Azure-hosted ASP.NET Core apps
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# Development workflow for Azure-hosted ASP&period;NET Core apps

The application development lifecycle starts from each developer's machine, coding the app using their preferred language and testing it locally. Developers may choose their preferred source control system and can configure Continuous Integration (CI) and/or Continuous Delivery/Deployment (CD) using a build server or based on built-in Azure features.

To get started with developing an ASP&period;NET Core application using CI/CD, you can use Visual Studio Team Services or your organization's own Team Foundation Server (TFS).

## Initial Setup

To create a release pipeline for your app, you need to have your application code in source control. Set up a local repository and connect it to a remote repository in a team project. Follow these instructions:

-   [Share your code with Git and Visual Studio](https://www.visualstudio.com/en-us/docs/git/share-your-code-in-git-vs) or

-   [Share your code with TFVC and Visual Studio](https://www.visualstudio.com/en-us/docs/tfvc/share-your-code-in-tfvc-vs)

Create an Azure App Service where you'll deploy your application. Create a Web App by going to the App Services blade on the Azure portal. Click +Add, select the Web App template, click Create, and provide a name and other details. The web app will be accessible from {name}.azurewebsites.net.

![AzureWebApp](./media/image2.png)

**Figure 10-X.** Creating a new Azure App Service Web App in the Azure Portal.

Your CI build process will perform an automated build whenever new code is committed to the project's source control repository. This gives you immediate feedback that the code builds (and, ideally, passes automated tests) and can potentially be deployed. This CI build will produce a web deploy package artifact and publish it for consumption by your CD process.

[Define your CI build process](https://www.visualstudio.com/en-us/docs/build/apps/aspnet/aspnetcore-to-azure#ci)

Be sure to enable continuous integration so the system will queue a build whenever someone on your team commits new code. Test the build and verify that it is producing a web deploy package as one of its artifacts.

When a build succeeds, your CD process will deploy the results of your CI build to your Azure web app. To configure this, you create and configure a *Release*, which will deploy to your Azure App Service.

[Define your CD release process](https://www.visualstudio.com/en-us/docs/build/apps/aspnet/aspnetcore-to-azure#cd)

Once your CI/CD pipeline is configured, you can simply make updates to your web app and commit them to source control to have them deployed.

## Workflow for developing Azure-hosted ASP&period;NET Core applications

Once you have configured your Azure account and your CI/CD process, developing Azure-hosted ASP&period;NET Core applications is simple. The following are the basic steps you usually take when building an ASP&period;NET Core app, hosted in Azure App Service as a Web App, as illustrated in Figure 10-X.

![EndToEndDevDeployWorkflow](./media/image3.png){width="6.25in" height="3.75in"}

**Figure 10-X.** Step-by-step workflow for building ASP&period;NET Core apps and hosting them in Azure

### Step 1. Local Dev Environment Inner Loop

Developing your ASP&period;NET Core application for deployment to Azure is no different from developing your application otherwise. Use the local development environment you're comfortable with, whether that's Visual Studio 2017 or the dotnet CLI and Visual Studio Code or your preferred editor. You can write code, run and debug your changes, run automated tests, and make local commits to source control until you're ready to push your changes to your shared source control repository.

### Step 2. Application Code Repository

Whenever you're ready to share your code with your team, you should push your changes from your local source repository to your team's shared source repository. If you've been working in a custom branch, this step usually involves merging your code into a shared branch (perhaps by means of a [pull request](https://www.visualstudio.com/en-us/docs/git/pull-requests)).

### Step 3. Build Server: Continuous Integration. Build, Test, Package

A new build is triggered on the build server whenever a new commit is made to the shared application code repository. As part of the CI process, this build should fully compile the application and run automated tests to confirm everything is working as expected. The end result of the CI process should be a packaged version of the web app, ready for deployment.

### Step 4. Build Server: Continuous Delivery

Once a build as succeeded, the CD process will pick up the build artifacts produced. This will include a web deploy package. The build server will deploy this package to Azure App Service, replacing any existing service with the newly created one. Typically this step targets a staging environment, but some applications deploy directly to production through a CD process.

### Step 5. Azure App Service. Web App.

Once deployed, the ASP&period;NET Core application runs within the context of an Azure App Service Web App. This Web App can be monitored and further configured using the Azure Portal.

### Step 6. Production Monitoring and Diagnostics

While the Web App is running, you can monitor the health of the application and collect diagnostics and user behavior data. Application Insights is included in Visual Studio, and offers automatic instrumentation for ASP&period;NET apps. It can provide you with information on usage, exceptions, requests, performance, and logs.

## References

**Build and Deploy Your ASP&period;NET Core App to Azure**  
<https://www.visualstudio.com/en-us/docs/build/apps/aspnet/aspnetcore-to-azure>

>[!div class="step-by-step"]
[Previous] (development-environment-for-asp.net-core-apps.md)
[Next] (../azure-hosting-recommendations-for-asp/index.md)
