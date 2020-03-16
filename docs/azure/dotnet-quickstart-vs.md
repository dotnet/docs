---
title: Deploy to Azure from Visual Studio
description: This tutorial will walk you through building and deploying a Microsoft Azure application using Visual Studio and .NET.
ms.date: 06/20/2017
---

# Deploy to Azure from Visual Studio

This tutorial will walk you through building and deploying a Microsoft Azure application using Visual Studio and .NET.  When finished, you'll have a web-based to-do application built in ASP.NET MVC Core, hosted as an Azure Web App, and using Azure Cosmos DB for data storage.

## Prerequisites

* [Visual Studio 2017](https://www.visualstudio.com/downloads/)
* A [Microsoft Azure subscription](https://azure.microsoft.com/free/)

## Create an Azure Cosmos DB account

Azure Cosmos DB is used for data storage in this tutorial, so you'll need to create an account.  Run this script locally or in the Cloud Shell to create an Azure Cosmos DB SQL API account.  Click the **Try it** button on the code block below to launch the [Azure Cloud Shell](/azure/cloud-shell/) and copy/paste the script block into the shell.

```azurecli-interactive
# Create the DotNetAzureTutorial resource group
az group create --name DotNetAzureTutorial --location EastUS

# Generate a unique name for the account
let randomNum=$RANDOM*$RANDOM
cosmosdbname=dotnettutorial$randomNum

# Create the Azure Cosmos DB account
az cosmosdb create --name $cosmosdbname --resource-group DotNetAzureTutorial

# Retrieve the endpoint and key (you'll need these later)
cosmosEndpoint=$(az cosmosdb show -n $cosmosdbname -g DotNetAzureTutorial --query [documentEndpoint] -o tsv)
cosmosAuthKey=$(az cosmosdb list-keys -n $cosmosdbname -g DotNetAzureTutorial --query [primaryMasterKey] -o tsv)
printf "\n\nauthKey: $cosmosAuthKey\nendpoint: $cosmosEndpoint\n\n"

# Done!

```

Make a note of the displayed **authKey** and **endpoint** 

## Downloading and running the application

Let's get the sample code for this walkthrough and hook it up to your Azure Cosmos DB account.

1. Download the sample code.  You can [get it from GitHub](https://github.com/Azure-Samples/dotnet-cosmosdb-quickstart/), or if you have the [git command line client](https://git-scm.com/), clone it to your local machine with the following command:

    ```cmd
    git clone https://github.com/Azure-Samples/dotnet-cosmosdb-quickstart
    ```

2. Open **todo.csproj** in Visual Studio.

3. Open **appsettings.json** in the web project.  Look for the following lines:

    ```json
    "authKey": "AUTHKEYVALUE",
    "endpoint": "ENDPOINTVALUE",
    ```

    Replace **AUTHKEYVALUE** and **ENDPOINTVALUE** with the values you noted earlier.

4. Press **F5** to restore the project's NuGet packages, build the project, and run it locally.

The web application should run locally in your browser.  You can add new items to the to-do list by clicking **Create New**.  Note the data you enter in the application is being stored in your Azure Cosmos DB account.  You can view your data in the [Azure portal](https://portal.azure.com) by selecting Azure Cosmos DB from the left menu, selecting your account, and then selecting **Data Explorer**.

## Deploying the application as an Azure Web App

You've successfully built an application that uses Azure services like Azure Cosmos DB.  Next, we'll deploy our web application to the cloud.

> [!IMPORTANT]
> Be sure you're signed into Visual Studio with the same account your Azure subscription is associated with.

1. In Visual Studio Solution Explorer, right-click on the project name and select **Publish...**

2. Using the Publish dialog, select **Microsoft Azure App Service**, select **Create New**, and then click **Publish**

3. Complete the Create App Service dialog as follows:

    * Enter a unique **Web App Name**.  This will be part of the URL for your app.
    * Select the Azure **Subscription** you're deploying to.  Use same subscription with which you were logged into Cloud Shell earlier.
    * Select *DotNetAzureTutorial* for the **Resource Group** for your web application.
    * Select or create an **App Service Plan** to determine the pricing your your application.  Here's [more information about App Service Plans](/azure/app-service/azure-web-sites-web-hosting-plans-in-depth-overview).

4. Click **Create** to deploy the application.  When deployment is complete, a browser will open with your deployed application.

![The completed app](./media/dotnet-quickstart/todo.png)

## Clean up

When you're done testing the app and inspecting the code and resources, you can delete the Web App and Azure Cosmos DB account by deleting the resource group in the Cloud Shell.

```azurecli-interactive
az group delete -n DotNetAzureTutorial
```

## Next steps

* [Use Azure Active Directory for authentication in an ASP.NET web application](/azure/active-directory/develop/active-directory-devquickstarts-webapp-dotnet)
* [Build an Azure Web App using Azure SQL Database](/azure/app-service-web/web-sites-dotnet-get-started)
* [Try a .NET sample application with Azure Storage](/azure/storage/storage-samples-dotnet)


