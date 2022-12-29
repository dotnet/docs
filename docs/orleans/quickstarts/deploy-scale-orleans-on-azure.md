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

* Use the `Configure` method to assign IDs for the Orleans cluster. The `ClusterID` is a unique ID for the cluster that allows clients and silos to talk to one another. The `ClusterID` can change across deployments. The `ServiceID` is a unique ID for the application that is used internally by Orleans and should remain consistent across deployments.
* The `UseAzureStorageClustering` method configures Orleans to store cluster data in Azure Table Storage and authenticates using the connection string.

```csharp
const string connectionString = "YOUR_CONNECTION_STRING_HERE";
var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "my-first-cluster";
            options.ServiceId = "SampleApp";
        })
        builder.UseAzureStorageClustering(
            options => options.ConfigureTableServiceClient(connectionString));
    })
    .Build();
```

## Create the Azure Container App and Azure Container Registry

1. In Visual Studio solution explorer, right-click on the top level project node and select **Publish**.
1. In the publishing dialog, select **Azure** as the deployment target, and then select **Next**.
1. For the specific target, select **Azure Container Apps (Linux)**, and then select **Next**.
1. Create a new container app to deploy to. Select the **+ Create new** button to open a new dialog and enter the following values:

    :::image type="content" source="./media/visual-studio-create-container-app.png" lightbox="./media/visual-studio-create-container-app-large.png" alt-text="A screenshot showing how to create a container app.":::

    * **Container app name**: Leave the default value or enter a name.
    * **Subscription name**: Select the subscription to deploy to.
    * **Resource group**: Select **New** and create a new resource group called *msdocs-app-db-ef*.
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

    :::image type="content" source="./media/visual-studio-container-registry.png" lightbox="./media/visual-studio-container-registry-large.png" alt-text="A screenshot showing how to create a new container registry.":::

1. Leave the default values, and then select **Create**.
1. After the container registry is created, make sure it's selected, and then select next.