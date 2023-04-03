---
title: Deploy Orleans to Azure App Service
description: Learn how to deploy an Orleans shopping cart app to Azure App Service.
ms.date: 05/02/2022
ms.topic: tutorial
ms.custom: devx-track-bicep
---

# Deploy Orleans to Azure App Service

In this tutorial, you learn how to deploy an Orleans shopping cart app to Azure App Service. The tutorial walks you through a sample application that supports the following features:

- **Shopping cart**: A simple shopping cart application that uses Orleans for its cross-platform framework support, and its scalable distributed applications capabilities.

  - **Inventory management**: Edit and/or create product inventory.
  - **Shop inventory**: Explore purchasable products and add them to your cart.
  - **Cart**: View a summary of all the items in your cart, and manage these items; either removing or changing the quantity of each item.

With an understanding of the app and its features, you will then learn how to deploy the app to Azure App Service using GitHub Actions, the .NET and Azure CLIs, and Azure Bicep. Additionally, you'll learn how to configure the virtual network for the app within Azure.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Deploy an Orleans application to Azure App Service
> - Automate deployment using GitHub Actions and Azure Bicep
> - Configure the virtual network for the app within Azure

## Prerequisites

- A [GitHub account](https://github.com/join)
- [Read an introduction to Orleans](../overview.md)
- The [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet)
- The [Azure CLI](/cli/azure/install-azure-cli)
- A .NET integrated development environment (IDE)
  - Feel free to use [Visual Studio](https://visualstudio.microsoft.com) or [Visual Studio Code](https://code.visualstudio.com)

## Run the app locally

To run the app locally, fork the [Azure Samples: Orleans Cluster on Azure App Service](https://github.com/Azure-Samples/Orleans-Cluster-on-Azure-App-Service) repository and clone it to your local machine. Once cloned, open the solution in an IDE of your choice. If you're using Visual Studio, right-click the **Orleans.ShoppingCart.Silo** project and select **Set As Startup Project**, then run the app. Otherwise, you can run the app using the following .NET CLI command:

```dotnetcli
dotnet run --project Silo\Orleans.ShoppingCart.Silo.csproj
```

For more information, see [dotnet run](../../core/tools/dotnet-run.md). With the app running, you can navigate around and you're free to test out its capabilities. All of the app's functionality when running locally relies on in-memory persistence, local clustering, and it uses the [Bogus NuGet](https://www.nuget.org/packages/Bogus) package to generate fake products. Stop the app either by selecting the **Stop Debugging** option in Visual Studio or by pressing <kbd>Ctrl</kbd>+<kbd>C</kbd> in the .NET CLI.

## Inside the shopping cart app

Orleans is a reliable and scalable framework for building distributed applications. For this tutorial, you will deploy a simple shopping cart app built using Orleans to Azure App Service. The app exposes the ability to manage inventory, add and remove items in a cart, and shop available products. The client is built using Blazor with a server hosting model. The app is architected as follows:

:::image type="content" source="media/shopping-cart-app-arch.png" lightbox="media/shopping-cart-app-arch.png" alt-text="Orleans: Shopping Cart sample app architecture.":::

The preceding diagram shows that the client is the server-side Blazor app. It's composed of several services that consume a corresponding Orleans grain. Each service pairs with an Orleans grain as follows:

- `InventoryService`: Consumes the `IInventoryGrain` where inventory is partitioned by product category.
- `ProductService`: Consumes the `IProductGrain` where a single product is tethered to a single grain instance by `Id`.
- `ShoppingCartService`: Consumes the `IShoppingCartGrain`  where a single user only has a single shopping cart instance regardless of consuming clients.

The solution contains three projects:

- `Orleans.ShoppingCart.Abstractions`: A class library that defines the models and the interfaces for the app.
- `Orleans.ShoppingCart.Grains`: A class library that defines the grains that implement the app's business logic.
- `Orleans.ShoppingCart.Silos`: A server-side Blazor app that hosts the Orleans silo.

### The client user experience

The shopping cart client app has several pages, each of which represents a different user experience. The app's UI is built using the [MudBlazor NuGet](https://www.nuget.org/packages/MudBlazor) package.

**Home page**

A few simple phrases for the user to understand the app's purpose, and add context to each navigation menu item.

:::image type="content" source="media/home-page.png" lightbox="media/home-page.png" alt-text="Orleans: Shopping Cart sample app, home page.":::

**Shop inventory page**

A page that displays all of the products that are available for purchase. Items can be added to the cart from this page.

:::image type="content" source="media/shop-inventory-page.png" lightbox="media/shop-inventory-page.png" alt-text="Orleans: Shopping Cart sample app, shop inventory page.":::

**Empty cart page**

When you haven't added anything to your cart, the page renders a message that indicates that you have no items in your cart.

:::image type="content" source="media/empty-shopping-cart-page.png" lightbox="media/empty-shopping-cart-page.png" alt-text="Orleans: Shopping Cart sample app, empty cart page.":::

**Items added to the cart while on the shop inventory page**

When items are added to your cart while on the shop inventory page, the app displays a message that indicates the item was added to the cart.

:::image type="content" source="media/shop-inventory-items-added-page.png" lightbox="media/shop-inventory-items-added-page.png" alt-text="Orleans: Shopping Cart sample app, items added to cart while on shop inventory page.":::

**Product management page**

A user can manage inventory from this page. Products can be added, edited, and removed from the inventory.

:::image type="content" source="media/product-management-page.png" lightbox="media/product-management-page.png" alt-text="Orleans: Shopping Cart sample app, product management page.":::

**Product management page create new dialog**

When a user clicks the **Create new product** button, the app displays a dialog that allows the user to create a new product.

:::image type="content" source="media/product-management-page-new.png" lightbox="media/product-management-page-new.png" alt-text="Orleans: Shopping Cart sample app, product management page - create new product dialog.":::

**Items in the cart page**

When items are in your cart, you can view them and change their quantity, and even remove them from the cart. The user is shown a summary of the items in the cart and the pretax total cost.

:::image type="content" source="media/items-in-shopping-cart-page.png" lightbox="media/items-in-shopping-cart-page.png" alt-text="Orleans: Shopping Cart sample app, items in cart page.":::

> [!IMPORTANT]
> When this app runs locally, in a development environment, the app will use localhost clustering, in-memory storage, and a local silo. It also seeds the inventory with fake data that is automatically generated using the [Bogus NuGet](https://www.nuget.org/packages/bogus) package. This is all intentional to demonstrate the functionality.

## Deploy to Azure App Service

A typical Orleans application consists of a cluster of server processes (silos) where grains live, and a set of client processes, usually web servers, that receive external requests, turn them into grain method calls and return results. Hence, the first thing one needs to do to run an Orleans application is to start a cluster of silos. For testing purposes, a cluster can consist of a single silo.

> [!NOTE]
> For a reliable production deployment, you'd want more than one silo in a cluster for fault tolerance and scale.

[!INCLUDE [create-azure-resources](includes/deployment/create-azure-resources.md)]

[!INCLUDE [create-service-principal](includes/deployment/create-service-principal.md)]

[!INCLUDE [create-github-secret](includes/deployment/create-github-secret.md)]

### Prepare for Azure deployment

The app will need to be packaged for deployment. In the `Orleans.ShoppingCart.Silos` project we define a `Target` element that runs after the `Publish` step. This will zip the publish directory into a _silo.zip_ file:

```xml
<Target Name="ZipPublishOutput" AfterTargets="Publish">
    <Delete Files="$(ProjectDir)\..\silo.zip" />
    <ZipDirectory SourceDirectory="$(PublishDir)" DestinationFile="$(ProjectDir)\..\silo.zip" />
</Target>
```

There are many ways to deploy a .NET app to Azure App Service. In this tutorial, you use GitHub Actions, Azure Bicep, and the .NET and Azure CLIs. Consider the _./github/workflows/deploy.yml_ file in the root of the GitHub repository:

```yml
name: Deploy to Azure App Service

on:
  push:
    branches:
    - main

env:
  UNIQUE_APP_NAME: cartify
  AZURE_RESOURCE_GROUP_NAME: orleans-resourcegroup
  AZURE_RESOURCE_GROUP_LOCATION: centralus

jobs:
  build-and-deploy:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v3

    - name: Setup .NET 6.0
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: 6.0.x

    - name: .NET publish shopping cart app
      run: dotnet publish ./Silo/Orleans.ShoppingCart.Silo.csproj --configuration Release

    - name: Login to Azure
      uses: azure/login@v1
      with:
        creds: ${{ secrets.AZURE_CREDENTIALS }}
    
    - name: Flex bicep
      run: |
        az deployment group create \
          --resource-group ${{ env.AZURE_RESOURCE_GROUP_NAME }} \
          --template-file '.github/workflows/flex/main.bicep' \
          --parameters location=${{ env.AZURE_RESOURCE_GROUP_LOCATION }} \
            appName=${{ env.UNIQUE_APP_NAME }} \
          --debug

    - name: Webapp deploy
      run: |
        az webapp deploy --name ${{ env.UNIQUE_APP_NAME }} \
          --resource-group ${{ env.AZURE_RESOURCE_GROUP_NAME  }} \
          --clean true --restart true \
          --type zip --src-path silo.zip --debug
```

The preceding GitHub workflow will:

- Publish the shopping cart app as a zip file, using the [dotnet publish](../../core/tools/dotnet-publish.md) command.
- Login to Azure using the credentials from the [Create a service principal](#create-a-service-principal) step.
- Evaluate the _main.bicep_ file and start a deployment group using [az deployment group create](/cli/azure/deployment/group#az-deployment-group-create).
- Deploy the _silo.zip_ file to Azure App Service using [az webapp deploy](/cli/azure/webapp#az-webapp-deploy).

The workflow is triggered by a push to the _main_ branch. For more information, see [GitHub Actions and .NET](../../devops/github-actions-overview.md).

> [!TIP]
> If you encounter issues when running the workflow, you might need to verify that the service principal has all the required provider namespaces registered. The following provider namespaces are required:
>
> - `Microsoft.Web`
> - `Microsoft.Network`
> - `Microsoft.OperationalInsights`
> - `Microsoft.Insights`
> - `Microsoft.Storage`
>
> For more information, see [Resolve errors for resource provider registration](/azure/azure-resource-manager/troubleshooting/error-register-resource-provider?tabs=azure-cli).

Azure imposes naming restrictions and conventions for resources. You need to update the _deploy.yml_ file values for the following:

- `UNIQUE_APP_NAME`
- `AZURE_RESOURCE_GROUP_NAME`
- `AZURE_RESOURCE_GROUP_LOCATION`

Set these values to your unique app name and your Azure resource group name and location.

For more information, see [Naming rules and restrictions for Azure resources](/azure/azure-resource-manager/management/resource-name-rules).

## Explore the Bicep templates

When the `az deployment group create` command is run, it will evaluate the _main.bicep_ file. This file contains the Azure resources that you want to deploy. One way to think of this step is that it _provisions_ all of the resources for deployment.

> [!IMPORTANT]
> If you're using Visual Studio Code, the bicep authoring experience is improved when using the [Bicep Extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-bicep).

There are many bicep files, each containing either resources or modules (collections of resources). The _main.bicep_ file is the entry point and is comprised primarily of `module` definitions:

```bicep
param appName string
param location string = resourceGroup().location

module storageModule 'storage.bicep' = {
  name: 'orleansStorageModule'
  params: {
    name: '${appName}storage'
    location: location
  }
}

module logsModule 'logs-and-insights.bicep' = {
  name: 'orleansLogModule'
  params: {
    operationalInsightsName: '${appName}-logs'
    appInsightsName: '${appName}-insights'
    location: location
  }
}

resource vnet 'Microsoft.Network/virtualNetworks@2021-05-01' = {
  name: '${appName}-vnet'
  location: location
  properties: {
    addressSpace: {
      addressPrefixes: [
        '172.17.0.0/16'
      ]
    }
    subnets: [
      {
        name: 'default'
        properties: {
          addressPrefix: '172.17.0.0/24'
          delegations: [
            {
              name: 'delegation'
              properties: {
                serviceName: 'Microsoft.Web/serverFarms'
              }
            }
          ]
        }
      }
    ]
  }
}

module siloModule 'app-service.bicep' = {
  name: 'orleansSiloModule'
  params: {
    appName: appName
    location: location
    vnetSubnetId: vnet.properties.subnets[0].id
    appInsightsConnectionString: logsModule.outputs.appInsightsConnectionString
    appInsightsInstrumentationKey: logsModule.outputs.appInsightsInstrumentationKey
    storageConnectionString: storageModule.outputs.connectionString
  }
}
```

The preceding bicep file defines the following:

- Two parameters for the resource group name and the app name.
- The `storageModule` definition, which defines the storage account.
- The `logsModule` definition, which defines the Azure Log Analytics and Application Insights resources.
- The `vnet` resource, which defines the virtual network.
- The `siloModule` definition, which defines the Azure App Service.

One very important `resource` is that of the Virtual Network. The `vnet` resource enables the Azure App Service to communicate with the Orleans cluster.

Whenever a `module` is encountered in the bicep file, it is evaluated via another bicep file that contains the resource definitions. The first encountered module was the `storageModule`, which is defined in the _storage.bicep_ file:

```bicep
param name string
param location string

resource storage 'Microsoft.Storage/storageAccounts@2021-08-01' = {
  name: name
  location: location
  kind: 'StorageV2'
  sku: {
    name: 'Standard_LRS'
  }
}

var key = listKeys(storage.name, storage.apiVersion).keys[0].value
var protocol = 'DefaultEndpointsProtocol=https'
var accountBits = 'AccountName=${storage.name};AccountKey=${key}'
var endpointSuffix = 'EndpointSuffix=${environment().suffixes.storage}'

output connectionString string = '${protocol};${accountBits};${endpointSuffix}'
```

Bicep files accept parameters, which are declared using the `param` keyword. Likewise, they can also declare outputs using the `output` keyword. The storage `resource` relies on the `Microsoft.Storage/storageAccounts@2021-08-01` type and version. It will be provisioned in the resource group's location, as a `StorageV2` and `Standard_LRS` SKU. The storage bicep defines its connection string as an `output`. This `connectionString` is later used by the silo bicep to connect to the storage account.

Next, the _logs-and-insights.bicep_ file defines the Azure Log Analytics and Application Insights resources:

```bicep
param operationalInsightsName string
param appInsightsName string
param location string

resource appInsights 'Microsoft.Insights/components@2020-02-02' = {
  name: appInsightsName
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'
    WorkspaceResourceId: logs.id
  }
}

resource logs 'Microsoft.OperationalInsights/workspaces@2021-06-01' = {
  name: operationalInsightsName
  location: location
  properties: {
    retentionInDays: 30
    features: {
      searchVersion: 1
    }
    sku: {
      name: 'PerGB2018'
    }
  }
}

output appInsightsInstrumentationKey string = appInsights.properties.InstrumentationKey
output appInsightsConnectionString string = appInsights.properties.ConnectionString
```

This bicep file defines the Azure Log Analytics and Application Insights resources. The `appInsights` resource is a `web` type, and the `logs` resource is a `PerGB2018` type. Both the `appInsights` resource and the `logs` resource are provisioned in the resource group's location. The `appInsights` resource is linked to the `logs` resource via the `WorkspaceResourceId` property. There are two outputs defined in this bicep, used later by the App Service `module`.

Finally, the _app-service.bicep_ file defines the Azure App Service resource:

```bicep
param appName string
param location string
param vnetSubnetId string
param appInsightsInstrumentationKey string
param appInsightsConnectionString string
param storageConnectionString string

resource appServicePlan 'Microsoft.Web/serverfarms@2021-03-01' = {
  name: '${appName}-plan'
  location: location
  kind: 'app'
  sku: {
    name: 'S1'
    capacity: 1
  }
}

resource appService 'Microsoft.Web/sites@2021-03-01' = {
  name: appName
  location: location
  kind: 'app'
  properties: {
    serverFarmId: appServicePlan.id
    virtualNetworkSubnetId: vnetSubnetId
    httpsOnly: true
    siteConfig: {
      vnetPrivatePortsCount: 2
      webSocketsEnabled: true
      netFrameworkVersion: 'v6.0'
      appSettings: [
        {
          name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
          value: appInsightsInstrumentationKey
        }
        {
          name: 'APPLICATIONINSIGHTS_CONNECTION_STRING'
          value: appInsightsConnectionString
        }
        {
          name: 'ORLEANS_AZURE_STORAGE_CONNECTION_STRING'
          value: storageConnectionString
        }
      ]
      alwaysOn: true
    }
  }
}

resource appServiceConfig 'Microsoft.Web/sites/config@2021-03-01' = {
  name: '${appService.name}/metadata'
  properties: {
    CURRENT_STACK: 'dotnet'
  }
}
```

This bicep file configures the Azure App Service as a .NET 6 application. Both the `appServicePlan` resource and the `appService` resource are provisioned in the resource group's location. The `appService` resource is configured to use the `S1` SKU, with a capacity of `1`. Additionally, the resource is configured to use the `vnetSubnetId` subnet and to use HTTPS. It also configures the `appInsightsInstrumentationKey` instrumentation key, the `appInsightsConnectionString` connection string, and the `storageConnectionString` connection string. These are used by the shopping cart app.

The aforementioned Visual Studio Code extension for Bicep includes a visualizer. All of these bicep files are visualized as follows:

:::image type="content" source="media/shopping-cart-flexing.png" alt-text="Orleans: Shopping cart sample app bicep provisioning visualizer rendering." lightbox="media/shopping-cart-flexing.png":::

## Summary

As you update the source code and `push` changes to the `main` branch of the repository, the _deploy.yml_ workflow will run. It will provision the resources defined in the bicep files and deploy the application. The application can be expanded upon to include new features, such as authentication, or to support multiple instances of the application. The primary objective of this workflow is to demonstrate the ability to provision and deploy resources in a single step.

In addition to the visualizer from the bicep extension, the Azure portal resource group page would look similar to the following example after provisioning and deploying the application:

:::image type="content" source="media/shopping-cart-resources.png" alt-text="Azure Portal: Orleans shopping cart sample app resources." lightbox="media/shopping-cart-resources.png":::

## See also

- [Orleans deployment overview](index.md)
- [GitHub Actions and .NET](../../devops/github-actions-overview.md)
- [Quickstart: Deploy an ASP.NET web app](/azure/app-service/quickstart-dotnetcore)
- [Integrate your app with an Azure virtual network](/azure/app-service/overview-vnet-integration)
- [Enable virtual network integration in Azure App Service](/azure/app-service/configure-vnet-integration-enable)
