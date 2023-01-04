---
title: 'Quickstart: Deploy and scale an Orleans app on Azure'
description: Learn how to host and scale an Orleans app on Azure
author: alexwolfmsft
ms.author: alexwolf
ms.date: 12/16/2022
ms.topic: quickstart
ms.devlang: csharp
---

# Quickstart: Host and scale an Orleans app on Azure

In this quickstart, you'll deploy and scale an Orleans URL shortener app on Azure Container Apps. The app allows users to submit a full URL to the app, which will return a shortened version they can share with others to direct them to the original site. Orleans and Azure provide the scalability features necessary to host potentially high traffic utility apps like URL shorteners. Orleans is also compatible with any other hosting service that supports .NET.

At the end of this quickstart, you'll have a scalable app running in Azure to provide URL shortener functionality. Along the way you'll learn to:

* Configure an Orleans app for Azure hosting
* Deploy an Orleans app to Azure Container Apps
* Scale the app to multiple instances
* Verify where Orleans stores state data in Azure

## Prerequisites

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with the ASP.NET and web development workload
- An Azure Account - [sign up for free](https://azure.microsoft.com/free/)

## Setup the sample app

This quickstart builds on the sample app from the [Build your first Orleans app][build-your-first-orleans-app.md] quickstart, which can be cloned from GitHub using the command below. You can download the app directly. Completing the previous quickstart is not a prerequisite for the steps ahead.

```bash
git clone https://github.com/Azure-Samples/build-your-first-orleans-app-aspnetcore
```

## Configure the sample app

The sample app is currently configured to create a localhost cluster and persist grains in memory. When hosted in Azure, Orleans can be configured to use more scalable, centralized state using services like Azure Table Storage. Update the configuration code in the `Program.cs` file to match the example below, which implements these key concepts:

* A conditional environment check is added to ensure the app runs properly in both local development and Azure hosted scenarios
* The `UseAzureStorageClustering` method configures Orleans to store cluster data in Azure Table Storage and authenticates using the connection string.
* Use the `Configure` method to assign IDs for the Orleans cluster. The `ClusterID` is a unique ID for the cluster that allows clients and silos to talk to one another. The `ClusterID` can change across deployments. The `ServiceID` is a unique ID for the application that is used internally by Orleans and should remain consistent across deployments.

```csharp
var builder = WebApplication.CreateBuilder();

if (builder.Environment.IsDevelopment())
{
    builder.Host.UseOrleans(builder =>
    {
        builder.UseLocalhostClustering();
        builder.AddMemoryGrainStorage("urls");
    });
} else
{
    builder.Host.UseOrleans(builder =>
    {
        var connectionString = "your_storage_connection_string";
        
        builder.UseAzureStorageClustering(options =>
            options.ConfigureTableServiceClient(connectionString))
            .AddAzureTableGrainStorage("urls",
                            options => options.ConfigureTableServiceClient(connectionString));
        builder.Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "url-shortener";
            options.ServiceId = "urls";
        });
    });
}

var app = builder.Build();
```

## Create the Azure Storage account

Create an Azure Storage Account to hold the cluster and persistent state data you configured in the previous step.

1. In the Azure Portal, select **Storage accounts** from the left navigation.
1. On the **Storage accounts** listing page, select **Create**.
1. On the **Create a storage account** page, enter the following values:
    * **Subscription**: Select the subscription you plan to use.
    * **Resource group**: Select **Create new** and then enter a name of msdocs-orleans.
    * **Storage account name**: Enter a name of *OrleansUrlShortener*.
    * **Region**: Select a region that is near your location.
    * Leave the rest of the options at their defaults, and then select **Review**.
    * Select **Create** after Azure validates your settings.
1. Select **Go to resource** after the storage account is created.

## Configure the connection to Azure Storage

1. On the storage account overview page, select **Access keys** on the left navigation.
1. On the Access keys page, select **Show** for the **Connection string**, and then copy the value.
1. Inside of Visual Studio, replace the storageConnectionString placeholder with the value you copied from the storage account.

## Deploy to Azure Container Apps

1. In the Visual Studio solution explorer, right click on the top level project node and select **Add > Dockerfile**. Visual Studio creates a Dockerfile at the root of your project. This will enable containerization for your app and allow it to run on Azure container apps.
1. In Visual Studio solution explorer, right-click on the top level project node and select **Publish**.
1. In the publishing dialog, select **Azure** as the deployment target, and then select **Next**.
1. For the specific target, select **Azure Container Apps (Linux)**, and then select **Next**.
1. Create a new container app to deploy to. Select the **+ Create new** button to open a new dialog and enter the following values:

    :::image type="content" source="../media/deploy-container-apps.png" alt-text="A screenshot showing how to create a container app.":::

    * **Container app name**: Leave the default value.
    * **Subscription name**: Select the subscription to deploy to.
    * **Resource group**: Select **New** and create a new resource group called *msdocs-orleans*.
    * **Container apps environment**: Select **New** to open the container apps environment dialog and enter the following values:
        * **Environment name**: Keep the default value.
        * **Location**: Select a location near you.
        * **Azure Log Analytics Workspace**: Select **New** to open the log analytics workspace dialog.
            * **Name**: Leave the default value.
            * **Location**: Select a location near you and then select **Ok** to close the dialog.
        * Select **Ok** to close the container apps environment dialog.
    * Select **Create** to close the original container apps dialog. Visual Studio creates the container app resource in Azure.
1. Once the resource is created, make sure it's selected in the list of container apps, and then select **Next**.
1. You'll need to create an Azure Container Registry to store the published image artifact for your app. Select the green **+** icon on the container registry screen. 

    :::image type="content" source="../media/deploy-container-apps.png" alt-text="A screenshot showing how to create a new container registry.":::

1. Leave the default values, and then select **Create**.
1. After the container registry is created, make sure it's selected, and then select **Next**.
1. Select **Publish (generates pubxml file)**, and then select **Finish**.
1. On the publishing profile overview, select **Publish** to deploy the app to Azure.

When the deployment finishes, Visual Studio will launch the application in the browser.

## Test the app

1. In the browser address bar, test the `shorten` endpoint by adding a URL path such as `/shorten/www.microsoft.com`. The page should reload and provide a URL with a shortened path at the end. Copy the shortened URL to your clipboard.

    :::image type="content" source="../media/url-shortener.png" alt-text="A screenshot showing the result of the URL shortener launched from Visual Studio.":::

1. Paste the shortened URL into the address bar and press enter. The page should reload and redirect you to [https://microsoft.com](https://microsoft.com).

> [!NOTE]
> By default, Azure Container Apps have lengthy domain names, so the shortened URL is still quite long. In a production app you can assign a custom domain name to improve this setup.

## Scale the app

Orleans is designed for distributed applications. Even an app as simple as the URL shortener can benefit from the scalability of Orleans. You can scale and test your app across multiple instances using the following steps:

1. On the container app overview page, select **Scale** on the left navigation.
1. Select **Edit and deploy**, and then switch to the **Scale** tab.
1. Use the slider control to set the min and max replica values to 3. This will ensure the app is running on multiple instances.
1. Select **Create** to deploy the new revision.
1. After the deployment is finished, repeat the testing steps from the previous section. The app will continue to work as expected.
1. 