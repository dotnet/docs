---
title: Deploy Orleans to Azure App Service
description: Learn how to deploy an Orleans shopping cart app to Azure App Service.
ms.date: 04/27/2022
ms.topic: tutorial
---

# Deploy Orleans to Azure App Service

In this article, you will learn how to deploy an Orleans shopping cart app to Azure App Service. This tutorial will walk you through a sample application that supports the following features:

- **Shopping cart**: A simple shopping cart application that uses Orleans for its cross-platform framework support, and its scalable distributed applications capabilities.

  - **Inventory management**: Edit and/or create product inventory.
  - **Shop inventory**: Explore purchasable products and add them to your cart.
  - **Cart**: View a summary of all the items in your cart, and manage these items; either removing or changing the quantity of each item.

With an understanding of the app and its features, you will then learn how to deploy the app to Azure App Service. Additionally, you'll learn how to configure the virtual network for the app within Azure.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Deploy an Orleans application to Azure App Service
> - Automate deployment using GitHub Actions and Azure Bicep
> - Configure the virtual network for the app within Azure

## Prerequisites

- A [GitHub account](https://github.com/join)
- The [.NET 6 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- The [Azure CLI](/cli/azure/install-azure-cli)
- A .NET integrated development environment (IDE)
  - Feel free to use the [Visual Studio IDE](https://visualstudio.microsoft.com) or the [Visual Studio Code](https://code.visualstudio.com)

## Run the app locally

The app is built using .NET 6, if you don't already have .NET 6 installed on your machine, you need to [download and install it](https://dotnet.microsoft.com/download/dotnet/6.0).

Next, you need to fork the [Orleans-shopping-cart](https://github.com/IEvangelist/orleans-shopping-cart) repository and clone it to your local machine. If you're using Visual Studio, right-click the **Orleans.ShoppingCart.Silo** project and select **Set As Startup Project**, then run the app. Otherwise you can run the app using the following .NET CLI command:

```dotnetcli
dotnet run --project Silo\Orleans.ShoppingCart.Silo.csproj
```

For more information, see [dotnet run](../../core/tools/dotnet-run.md).

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

The shopping cart client app has several pages, each of which represents a different user experience.

**Home page**

A few simple phrases for the user to understand the app's purpose, and add context to each navigation menu item.

:::image type="content" source="media/home-page.png" lightbox="media/home-page.png" alt-text="Orleans: Shopping Cart sample app, home page.":::

**Shop inventory page**

A page that displays all of the products that are available for purchase. Items can be added to the cart from this page.

:::image type="content" source="media/shop-inventory-page.png" lightbox="media/shop-inventory-page.png" alt-text="Orleans: Shopping Cart sample app, shop inventory page.":::

**Empty cart page**

When you haven't added anything to your cart, the page renders a message that indicates that you have no items in your cart.

:::image type="content" source="media/empty-shopping-cart-page.png" lightbox="media/empty-shopping-cart-page.png" alt-text="Orleans: Shopping Cart sample app, empty cart page.":::

**Items added to cart while on the shop inventory page**

When items are added to your cart while on the shop inventory page, the app displays a message that indicates the item was added to the cart.

:::image type="content" source="media/shop-inventory-items-added-page.png" lightbox="media/shop-inventory-items-added-page.png" alt-text="Orleans: Shopping Cart sample app, items added to cart while on shop inventory page.":::

**Product management page**

A user can manage inventory from this page. Products can be added, edited, and removed from the inventory.

:::image type="content" source="media/product-management-page.png" lightbox="media/product-management-page.png" alt-text="Orleans: Shopping Cart sample app, product management page.":::

**Product management page create new dialog**

When a user clicks the **Create new product** button, the app displays a dialog that allows the user to create a new product.

:::image type="content" source="media/product-management-page-new.png" lightbox="media/product-management-page-new.png" alt-text="Orleans: Shopping Cart sample app, product management page - create new product dialog.":::

**Items in cart page**

When items are in your cart, you can view them and change their quantity, and even remove them from the cart. The user is shown a summary of the items in the cart and the pretax total cost.

:::image type="content" source="media/items-in-shopping-cart-page.png" lightbox="media/items-in-shopping-cart-page.png" alt-text="Orleans: Shopping Cart sample app, items in cart page.":::

> [!IMPORTANT]
> When this app runs locally, in a Development environment, the app will use localhost clustering, in-memory storage, and a local silo. It also seeds the inventory with fake data that is automatically generated using the [Bogus NuGet](https://www.nuget.org/packages/bogus) package. This is all intentional to demonstrate the functionality.

## Deploy to Azure App Service

A typical Orleans application consists of a cluster of server processes (silos) where grains live, and a set of client processes, usually web servers, that receive external requests, turn them into grain method calls and return results. Hence, the first thing one needs to do to run an Orleans application is to start a cluster of silos. For testing purposes, a cluster can consist of a single silo.

> [!NOTE]
> For a reliable production deployment, you'd want more than one silo in a cluster for fault tolerance and scale.

Before deploying the app to Azure App Service, you need to create an Azure Resource Group (or you could choose to use an existing one).To create a new Azure Resource Group, use one of the following articles:

- [Azure Portal](/azure/azure-resource-manager/management/manage-resource-groups-portal#create-resource-groups)
- [Azure CLI](/azure/azure-resource-manager/management/manage-resource-groups-cli#create-resource-groups)
- [Azure PowerShell](/azure/azure-resource-manager/management/manage-resource-groups-powershell#create-resource-groups)

Make note of the resource group name you choose, you'll need it later to deploy the app.

### Create a service principal

To automate the deployment of the app, you'll need to create a service principal. This is a Microsoft account that has permissions to manage Azure resources on your behalf.

```azurecli
az ad sp create-for-rbac --sdk-auth --role contributor --scopes /subscription/<your-subscription-id>
```

The JSON credentials created will look similar to the following, but with actual values for your client, subscription, and tenant:

```json
{
  "clientId": "<your client id>",
  "clientSecret": "<your client secret>",
  "subscriptionId": "<your subscription id>",
  "tenantId": "<yor tenant id>",
  "activeDirectoryEndpointUrl": "https://login.microsoftonline.com/",
  "resourceManagerEndpointUrl": "https://brazilus.management.azure.com",
  "activeDirectoryGraphResourceId": "https://graph.windows.net/",
  "sqlManagementEndpointUrl": "https://management.core.windows.net:8443/",
  "galleryEndpointUrl": "https://gallery.azure.com",
  "managementEndpointUrl": "https://management.core.windows.net"
}
```

Copy the output of the command into your clipboard, and continue to the next step.

### Create a GitHub secret

GitHub provides a mechanism for creating encrypted secrets. The secrets that you create are available to use in GitHub Actions workflows. You're going to see how a GitHub Actions can be used to automate the deployment of the app, in conjunction with Azure Bicep. Bicep is a domain-specific language (DSL) that uses declarative syntax to deploy Azure resources. For more information, see [What is Bicep](/azure/azure-resource-manager/bicep/overview?tabs=bicep). Using the output from the [Create a service principal](#create-a-service-principal) step, you'll need to create a GitHub secret named `AZURE_CREDENTIALS` with the JSON-formatted credentials.

Within the GitHub repository, select **Settings** > **Secrets** > **Create a new secret**. Enter the name `AZURE_CREDENTIALS` and paste the JSON credentials from the previous step into the **Value** field.

:::image type="content" source="media/github-secret.png" alt-text="GitHub Repository: Settings > Secrets" lightbox="media/github-secret.png":::

For more information, see [GitHub: Encrypted Secrets](https://docs.github.com/actions/security-guides/encrypted-secrets).

### Prepare for Azure deployment

The app will need to be packaged for deployment. In the `Orleans.ShoppingCart.Silos` project, we define a `Target` element that runs after the `Publish` step. This will zip the publish directory into a _silo.zip_ file:

```xml
<Target Name="ZipPublishOutput" AfterTargets="Publish">
    <Delete Files="$(ProjectDir)\..\silo.zip" />
    <ZipDirectory SourceDirectory="$(PublishDir)" DestinationFile="$(ProjectDir)\..\silo.zip" />
</Target>
```

There are many ways to deploy a .NET app to Azure App Service, in this tutorial we'll use GitHub Actions, Azure Bicep, and the Azure CLI.

```yml
name: Deploy to Azure App Service

on:
  push:
    branches:
    - main

env:
  AZURE_RESOURCE_GROUP_NAME: orleans-resourcegroup
  AZURE_RESOURCE_GROUP_LOCATION: centralus

jobs:
  build-and-deploy:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v2

    - name: Setup .NET 6.0
      uses: actions/setup-dotnet@v1
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
          --parameters resourceGroupName=${{ env.AZURE_RESOURCE_GROUP_NAME }} \
            resourceGroupLocation=${{ env.AZURE_RESOURCE_GROUP_LOCATION }} \
          --debug

    - name: Webapp deploy
      run: |
        az webapp deploy --name "orleans-app-silo" \
          --resource-group ${{ env.AZURE_RESOURCE_GROUP_NAME  }} \
          --clean true --restart true \
          --type zip --src-path silo.zip --debug
```

The preceding GitHub workflow will:

- Publish the shopping cart app as a zip file, using the [dotnet publish](../../core/tools/dotnet-publish.md) command.
- Login to Azure using the credentials from the [Create a service principal](#create-a-service-principal) step.
- Evaluates the _main.bicep_ file and starts a deployment group using [az deployment group create](/cli/azure/deployment/group#az-deployment-group-create).
- Deploys the _silo.zip_ file to the Azure App Service using [az webapp deploy](/cli/azure/webapp#az-webapp-deploy).

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
> For more information, see [Resolve errors for resource provider registration](/azure/azure-resource-manager/troubleshooting/error-register-resource-provider?tabs=azure-cli)

## Explore the bicep templates

When the `az deployment group create` command is run, it will evaluate the _main.bicep_ file. This file contains the Azure resources that you want to deploy. One way to think of this step is that it _provisions_ all of the resources for deployment.

> [!TIP]
> If you're using Visual Studio Code, the bicep authoring experience is improved when using the [Bicep Extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-bicep).

There are a number of bicep files, each containing either resources or modules (collection of resources). The _main.bicep_ file is the entry point, and is comprised of primarily a number of `module` definitions:

```bicep
param resourceGroupName string = resourceGroup().name
param resourceGroupLocation string = resourceGroup().location

module storageModule 'storage.bicep' = {
  name: 'orleansStorageModule'
  params: {
    name: replace(resourceGroupName, '-resourcegroup', 'storage')
    resourceGroupLocation: resourceGroupLocation
  }
}

module logsModule 'logs-and-insights.bicep' = {
  name: 'orleansLogModule'
  params: {
    operationalInsightsName: replace(resourceGroupName, 'resourcegroup', 'logs')
    appInsightsName: replace(resourceGroupName, 'resourcegroup', 'insights')
    resourceGroupLocation: resourceGroupLocation
  }
}

resource vnet 'Microsoft.Network/virtualNetworks@2021-05-01' = {
  name: 'orleans-vnet'
  location: resourceGroupLocation
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
    appName: replace(resourceGroupName, '-resourcegroup', '-app-silo')
    resourceGroupName: resourceGroupName
    resourceGroupLocation: resourceGroupLocation
    vnetSubnetId: vnet.properties.subnets[0].id
    appInsightsConnectionString: logsModule.outputs.appInsightsConnectionString
    appInsightsInstrumentationKey: logsModule.outputs.appInsightsInstrumentationKey
    storageConnectionString: storageModule.outputs.connectionString
  }
}
```

The preceding bicep file defines the following:

- Two parameters for the resource group name and location.
- The `storageModule` definition, which defines the storage account.
- The `logsModule` definition, which defines the Azure Log Analytics and Application Insights resources.
- The `vnet` resource, which defines the virtual network.
- The `siloModule` definition, which defines the Azure App Service.

Whenever a `module` is encountered in the bicep file, it is evaluated via another bicep file which contains the resource definitions. The first encountered module was the `storageModule`, it's defined in the _storage.bicep_ file:

```bicep
param name string
param resourceGroupLocation string

resource storage 'Microsoft.Storage/storageAccounts@2021-08-01' = {
  name: name
  location: resourceGroupLocation
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

Bicep files accept parameters, which are declared using the `param` keyword. Likewise, they can also declare outputs using the `output` keyword. The storage resource relies on the `Microsoft.Storage/storageAccounts@2021-08-01` type and version.

```bicep
param appName string
param resourceGroupName string
param resourceGroupLocation string
param vnetSubnetId string
param appInsightsInstrumentationKey string
param appInsightsConnectionString string
param storageConnectionString string

resource appServicePlan 'Microsoft.Web/serverfarms@2021-03-01' = {
  name: '${resourceGroupName}-plan'
  location: resourceGroupLocation
  kind: 'app'
  sku: {
    name: 'S1'
    capacity: 1
  }
}

resource appService 'Microsoft.Web/sites@2021-03-01' = {
  name: appName
  location: resourceGroupLocation
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

```bicep
param operationalInsightsName string
param appInsightsName string
param resourceGroupLocation string

resource appInsights 'Microsoft.Insights/components@2020-02-02' = {
  name: appInsightsName
  location: resourceGroupLocation
  kind: 'web'
  properties: {
    Application_Type: 'web'
    WorkspaceResourceId: logs.id
  }
}

resource logs 'Microsoft.OperationalInsights/workspaces@2021-06-01' = {
  name: operationalInsightsName
  location: resourceGroupLocation
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



## Configure the virtual network for the app

There are many ways to configure the [virtual network](/azure/virtual-network/virtual-networks-overview) for the app. The following are some of the most common ways:

- The Azure portal
- Azure PowerShell
- Azure CLI
- ARM templates
- Azure Bicep

## See also

- [Orleans deployment overview](index.md)
- [Quickstart: Deploy an ASP.NET web app](/azure/app-service/quickstart-dotnetcore)
- [Integrate your app with an Azure virtual network](/azure/app-service/overview-vnet-integration)
- [Enable virtual network integration in Azure App Service](/azure/app-service/configure-vnet-integration-enable)
