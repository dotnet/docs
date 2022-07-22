---
title: Deploy Orleans to Azure Container Apps
description: Learn how to deploy an updated Orleans shopping cart app to Azure Container Apps.
ms.date: 07/21/2022
ms.topic: tutorial
---

# Deploy Orleans to Azure Container Apps

In this tutorial, you learn how to deploy an Orleans shopping cart app to Azure Container Apps. The tutorial walks you through a sample application that supports the following features:

- **Shopping cart**: A simple shopping cart application that uses Orleans for its cross-platform framework support, and its scalable distributed applications capabilities.

  - **Inventory management**: Edit and/or create product inventory.
  - **Shop inventory**: Explore purchasable products and add them to your cart.
  - **Cart**: View a summary of all the items in your cart, and manage these items; either removing or changing the quantity of each item.

With an understanding of the app and its features, you will then learn how to deploy the app to Azure Container Apps using GitHub Actions, the .NET and Azure CLIs, and Azure Bicep. Additionally, you'll learn how to configure the virtual network for the app within Azure.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Deploy an Orleans application to Azure Container Apps
> - Automate deployment using GitHub Actions and Azure Bicep
> - Configure the virtual network for the app within Azure

## Prerequisites

- A [GitHub account](https://github.com/join)
- [Read an introduction to Orleans](../overview.md)
- The [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet)
- The [Azure CLI](/cli/azure/install-azure-cli)
- A .NET integrated development environment (IDE)
  - Feel free to use [Visual Studio 2022](https://visualstudio.microsoft.com) or [Visual Studio Code](https://code.visualstudio.com)

## Run the app locally

To run the app locally, fork the [Azure Samples: Orleans Cluster on Azure Container Apps](https://github.com/Azure-Samples/Orleans-Cluster-on-Azure-App-Service) repository and clone it to your local machine. Once cloned, open the solution in an IDE of your choice. If you're using Visual Studio, right-click the **Orleans.ShoppingCart.Silo** project and select **Set As Startup Project**, then run the app. Otherwise, you can run the app using the following .NET CLI command:

```dotnetcli
dotnet run --project Silo\Orleans.ShoppingCart.Silo.csproj
```

For more information, see [dotnet run](../../core/tools/dotnet-run.md). With the app running, you can navigate around and you're free to test out its capabilities. All of the app's functionality when running locally relies on in-memory persistence, local clustering, and it uses the [Bogus NuGet](https://www.nuget.org/packages/Bogus) package to generate fake products. Stop the app either by selecting the **Stop Debugging** option in Visual Studio or by pressing <kbd>Ctrl</kbd>+<kbd>C</kbd> in the .NET CLI.

## Configure the Container App's ingress

:::image type="content" source="media/azure-container-apps-http-ingress-diagram.png" lightbox="media/azure-container-apps-http-ingress-diagram.png" alt-text="Orleans: Shopping Cart sample Container App ingress architecture diagram.":::

## Deploy to Azure Container Apps

A typical Orleans application consists of a cluster of server processes (silos) where grains live, and a set of client processes, usually web servers, that receive external requests, turn them into grain method calls and return results. Hence, the first thing one needs to do to run an Orleans application is to start a cluster of silos. For testing purposes, a cluster can consist of a single silo.

> [!NOTE]
> For a reliable production deployment, you'd want more than one silo in a cluster for fault tolerance and scale.

Before deploying the app to Azure Container Apps, you need to create an Azure Resource Group (or you could choose to use an existing one). To create a new Azure Resource Group, use one of the following articles:

- [Azure Portal](/azure/azure-resource-manager/management/manage-resource-groups-portal#create-resource-groups)
- [Azure CLI](/azure/azure-resource-manager/management/manage-resource-groups-cli#create-resource-groups)
- [Azure PowerShell](/azure/azure-resource-manager/management/manage-resource-groups-powershell#create-resource-groups)

Make note of the resource group name you choose, you'll need it later to deploy the app.

### Create a service principal

To automate the deployment of the app, you'll need to create a service principal. This is a Microsoft account that has permission to manage Azure resources on your behalf.

```azurecli
az ad sp create-for-rbac --sdk-auth --role Contributor \
  --name "<display-name>"  --scopes /subscriptions/<your-subscription-id>
```

The JSON credentials created will look similar to the following, but with actual values for your client, subscription, and tenant:

```json
{
  "clientId": "<your client id>",
  "clientSecret": "<your client secret>",
  "subscriptionId": "<your subscription id>",
  "tenantId": "<your tenant id>",
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

GitHub provides a mechanism for creating encrypted secrets. The secrets that you create are available to use in GitHub Actions workflows. You're going to see how GitHub Actions can be used to automate the deployment of the app, in conjunction with Azure Bicep. Bicep is a domain-specific language (DSL) that uses a declarative syntax to deploy Azure resources. For more information, see [What is Bicep](/azure/azure-resource-manager/bicep/overview?tabs=bicep). Using the output from the [Create a service principal](#create-a-service-principal) step, you'll need to create a GitHub secret named `AZURE_CREDENTIALS` with the JSON-formatted credentials.

Within the GitHub repository, select **Settings** > **Secrets** > **Create a new secret**. Enter the name `AZURE_CREDENTIALS` and paste the JSON credentials from the previous step into the **Value** field.

:::image type="content" source="media/github-secret.png" alt-text="GitHub Repository: Settings > Secrets" lightbox="media/github-secret.png":::

For more information, see [GitHub: Encrypted Secrets](https://docs.github.com/actions/security-guides/encrypted-secrets).

### Prepare for Azure deployment

The app will need to be packaged for deployment. In the `Orleans.ShoppingCart.Silos` project we define a `Target` element that runs after the `Publish` step. This will zip the publish directory into a _silo.zip_ file:

```xml
<Target Name="ZipPublishOutput" AfterTargets="Publish">
    <Delete Files="$(ProjectDir)\..\silo.zip" />
    <ZipDirectory SourceDirectory="$(PublishDir)" DestinationFile="$(ProjectDir)\..\silo.zip" />
</Target>
```

There are many ways to deploy a .NET app to Azure Container Apps. In this tutorial, you use GitHub Actions, Azure Bicep, and the .NET and Azure CLIs. Consider the _./github/workflows/deploy.yml_ file in the root of the GitHub repository:

```yml
name: Deploy to Azure Container App

on:
  push:
    branches:
    - main

env:
  UNIQUE_APP_NAME: orleanscart
  SILO_IMAGE_NAME: orleanscart-silo
  AZURE_RESOURCE_GROUP_NAME: orleans-resourcegroup
  AZURE_RESOURCE_GROUP_LOCATION: eastus

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
          --parameters location=${{ env.AZURE_RESOURCE_GROUP_LOCATION }} \
            appName=${{ env.UNIQUE_APP_NAME }} \
          --debug

    - name: Get ACR Login Server
      run: |
        ACR_LOGIN_SERVER=$(az deployment group show -g ${{ env.AZURE_RESOURCE_GROUP_NAME }} -n main --query properties.outputs.acrLoginServer.value | tr -d '"')
        echo "ACR_LOGIN_SERVER=$ACR_LOGIN_SERVER" >> $GITHUB_ENV

    - name: Prepare Docker buildx
      uses: docker/setup-buildx-action@v1

    - name: Login to ACR
      run: |
        access_token=$(az account get-access-token --query accessToken -o tsv)
        refresh_token=$(curl https://${{ env.ACR_LOGIN_SERVER }}/oauth2/exchange -v -d "grant_type=access_token&service=${{ env.ACR_LOGIN_SERVER }}&access_token=$access_token" | jq -r .refresh_token)
        # The null GUID 0000... tells the container registry that this is an ACR refresh token during the login flow
        docker login -u 00000000-0000-0000-0000-000000000000 --password-stdin ${{ env.ACR_LOGIN_SERVER }} <<< "$refresh_token"

    - name: Build and push Silo image to registry
      uses: docker/build-push-action@v2
      with:
        push: true
        tags: ${{ env.ACR_LOGIN_SERVER }}/${{ env.SILO_IMAGE_NAME }}:${{ github.sha }}
        file: Silo/Dockerfile

    - name: Installing Container Apps extension
      uses: azure/cli@v1
      with:
        inlineScript: |
          az config set extension.use_dynamic_install=yes_without_prompt
          az extension add --name containerapp --yes

    - name: Deploy Silo
      uses: azure/cli@v1
      with:
        inlineScript: |
          az containerapp registry set \
            -n ${{ env.UNIQUE_APP_NAME }} \
            -g ${{ env.AZURE_RESOURCE_GROUP_NAME }} \
            --server ${{ env.ACR_LOGIN_SERVER }}
          az containerapp update \
            -n ${{ env.UNIQUE_APP_NAME }} \
            -g ${{ env.AZURE_RESOURCE_GROUP_NAME }} \
            -i ${{ env.ACR_LOGIN_SERVER }}/${{ env.SILO_IMAGE_NAME }}:${{ github.sha }}

    - name: Logout of Azure
      run: az logout
```

The preceding GitHub workflow will:

- Publish the shopping cart app as a zip file, using the [dotnet publish](../../core/tools/dotnet-publish.md) command.
- Login to Azure using the credentials from the [Create a service principal](#create-a-service-principal) step.
- Evaluate the _main.bicep_ file and start a deployment group using [az deployment group create](/cli/azure/deployment/group#az-deployment-group-create).
- Deploy the _silo.zip_ file to Azure Container Apps using [az webapp deploy](/cli/azure/webapp#az-webapp-deploy).

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

resource acr 'Microsoft.ContainerRegistry/registries@2021-09-01' = {
  name: toLower('${uniqueString(resourceGroup().id)}acr')
  location: location
  sku: {
    name: 'Basic'
  }
  properties: {
    adminUserEnabled: true
  }
}

module env 'environment.bicep' = {
  name: 'containerAppEnvironment'
  params: {
    location: location
    operationalInsightsName: '${appName}-logs'
    appInsightsName: '${appName}-insights'
  }
}

var envVars = [
  {
    name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
    value: env.outputs.appInsightsInstrumentationKey
  }
  {
    name: 'APPLICATIONINSIGHTS_CONNECTION_STRING'
    value: env.outputs.appInsightsConnectionString
  }
  {
    name: 'ORLEANS_AZURE_STORAGE_CONNECTION_STRING'
    value: storageModule.outputs.connectionString
  }
  {
    name: 'ASPNETCORE_FORWARDEDHEADERS_ENABLED'
    value: 'true'
  }
]

module storageModule 'storage.bicep' = {
  name: 'orleansStorageModule'
  params: {
    name: '${appName}storage'
    location: location
  }
}

module siloModule 'container-app.bicep' = {
  name: 'orleansSiloModule'
  params: {
    appName: appName
    location: location
    containerAppEnvironmentId: env.outputs.id
    registry: acr.name
    registryPassword: acr.listCredentials().passwords[0].value
    registryUsername: acr.listCredentials().username
    envVars: envVars
  }
}

output acrLoginServer string = acr.properties.loginServer
```

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

resource env 'Microsoft.App/managedEnvironments@2022-03-01' = {
  name: '${resourceGroup().name}env'
  location: location
  properties: {
    appLogsConfiguration: {
      destination: 'log-analytics'
      logAnalyticsConfiguration: {
        customerId: logs.properties.customerId
        sharedKey: logs.listKeys().primarySharedKey
      }
    }
  }
}

output id string = env.id
output appInsightsInstrumentationKey string = appInsights.properties.InstrumentationKey
output appInsightsConnectionString string = appInsights.properties.ConnectionString
```

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

The preceding bicep file defines the following:

- Two parameters for the resource group name and the app name.
- The `storageModule` definition, which defines the storage account.
- The `logsModule` definition, which defines the Azure Log Analytics and Application Insights resources.
- The `vnet` resource, which defines the virtual network.
- The `siloModule` definition, which defines the Azure Container Apps.

One very important `resource` is that of the Virtual Network. The `vnet` resource enables the Azure Container Apps to communicate with the Orleans cluster.

Whenever a `module` is encountered in the bicep file, it is evaluated via another bicep file that contains the resource definitions. The first encountered module was the `storageModule`, which is defined in the _storage.bicep_ file:

Bicep files accept parameters, which are declared using the `param` keyword. Likewise, they can also declare outputs using the `output` keyword. The storage `resource` relies on the `Microsoft.Storage/storageAccounts@2021-08-01` type and version. It will be provisioned in the resource group's location, as a `StorageV2` and `Standard_LRS` SKU. The storage bicep defines its connection string as an `output`. This `connectionString` is later used by the silo bicep to connect to the storage account.

Finally, the _app-service.bicep_ file defines the Azure Container Apps resource:

```bicepparam appName string
param location string
param containerAppEnvironmentId string
param repositoryImage string = 'mcr.microsoft.com/azuredocs/containerapps-helloworld:latest'
param envVars array = []
param registry string
param registryUsername string
@secure()
param registryPassword string

resource containerApp 'Microsoft.App/containerApps@2022-03-01' = {
  name: appName
  location: location
  properties: {
    managedEnvironmentId: containerAppEnvironmentId
    configuration: {
      activeRevisionsMode: 'multiple'
      secrets: [
        {
          name: 'container-registry-password'
          value: registryPassword
        }
      ]
      registries: [
        {
          server: registry
          username: registryUsername
          passwordSecretRef: 'container-registry-password'
        }
      ]
      ingress: {
        external: true
        targetPort: 80
      }
    }
    template: {
      containers: [
        {
          image: repositoryImage
          name: appName
          env: envVars
        }
      ]
      scale: {
        minReplicas: 1
        maxReplicas: 1
      }
    }
  }
}
```

The aforementioned Visual Studio Code extension for Bicep includes a visualizer. All of these bicep files are visualized as follows:

:::image type="content" source="media/shopping-cart-flexing.png" alt-text="Orleans: Shopping cart sample app bicep provisioning visualizer rendering." lightbox="media/shopping-cart-flexing.png":::

## Summary

<!--
As you update the source code and `push` changes to the `main` branch of the repository, the _deploy.yml_ workflow will run. It will provision the resources defined in the bicep files and deploy the application. The application can be expanded upon to include new features, such as authentication, or to support multiple instances of the application. The primary objective of this workflow is to demonstrate the ability to provision and deploy resources in a single step.

In addition to the visualizer from the bicep extension, the Azure portal resource group page would look similar to the following example after provisioning and deploying the application:

:::image type="content" source="media/shopping-cart-resources.png" alt-text="Azure Portal: Orleans shopping cart sample app resources." lightbox="media/shopping-cart-resources.png":::
-->

## See also

- [Orleans deployment overview](index.md)
- [GitHub Actions and .NET](../../devops/github-actions-overview.md)
- [Quickstart: Deploy an ASP.NET web app](/azure/app-service/quickstart-dotnetcore)
- [Integrate your app with an Azure virtual network](/azure/app-service/overview-vnet-integration)
- [Enable virtual network integration in Azure Container Apps](/azure/app-service/configure-vnet-integration-enable)
