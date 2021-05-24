---
title: Hosting ASP.NET Core and ASP.NET application on Azure - Create Azure resources
description: This article covers all of the Azure resources that need to be created in Azure to host a typical ASP.NET Core or ASP.NET web application or API
ms.date: 01/20/2021
ms.topic: conceptual
ms.custom: devx-track-dotnet
ms.author: daberry
---

# Create Azure resources for hosting an ASP.NET Core or ASP.NET application on Azure

In this article, you will create the Azure resources needed to host your ASP.NET Core or ASP.NET application in Azure.

This tutorial shows commands with arguments to create all Azure resources in the East US region.  If you prefer, you can create these resources in a different Azure region closer to you.  To find the available Azure regions, use the command `az account list-locations --output table`.

## Create a resource group

A resource group is a logical container used to group together all of the Azure resources for your application.  

```azurecli
# Create a resource group

az group create \
    --name <resource-group-name> \
    --location "East US"

```

## Create the App Service for the application

Azure App Service is a fully managed solution for hosting your ASP.NET Core or ASP.NET web applications or APIs.  You can think of Azure App Service as the web server for your application.

To create an App Service to host your application, first you need to create an App Service plan.  The App Service plan defines how many compute resources (CPU and memory) are available to the application and how much you pay.  You can learn more about choosing the correct App Service plan in the article [Choosing an App Service plan](..\choosing-app-service-plan.md).  This example uses the FREE App Service plan.

```azurecli

az appservice plan create \
    --name <app-service-plan-name> \
    --resource-group <resource-group-name> \
    --sku FREE

```

Next, create the web app to host the application.  The name of the application must be unique across Azure as the application will have the fully qualified domain name of _<app-name>.azurewebsites.net_.

```azurecli


az webapp create \
    --resource-group <resource-group-name> \
    --plan <app-service-plan> \
    --name <app-name>

```

## Create an Azure SQL database for the data

When hosting a SQL Server database in Azure, first create the database server by using the `az sql server create` command.

```azurecli

az sql server create \
    --name <server-name> \
    --resource-group <resource-group-name> \
    --admin-user <db-username> \
    --admin-password <db-password>

```

Once the server is created, you need to grant network access to allow your application and your development workstation access to the database.  This is done by using the `az sql server firewall-rule create` command.

You can [use Bing to find your current IP address](https://www.bing.com/search?&q=my+ip+address).



Finally, create the database for your application's data using the `az sql db create` command.  The service-objective paramater in this command specifies the size of the database to create.  To list the available database sizes, use the command `az sql db list-editions -a -o table -l <location>`.

```azurecli

az sql db create \
    --resource-group <resource-group-name> \
    --name <app-database-name> \
    --service-objective Free

```
```azurecli
# Create a resource group
az group create --name myResourceGroup --location "East US"


# Create App Service Plan
az appservice plan create --name <app-service-plan-name> --resource-group <resource-group-name> --sku FREE

# Create a web app
az webapp create --resource-group <resource-group-name> --plan <app-service-plan> --name <app-name>


# Create database server
az sql server create --name <database-server-name> --resource-group <resource-group-name> --admin-user <db-username> --admin-password <db-password>

# Configure database server firewall
az sql server firewall-rule create --name AllowLocalClient --server <database-server-name> --resource-group <resource-group-name> --start-ip-address=<your-ip-address> --end-ip-address=<your-ip-address>

# Create database
az sql db create --resource-group <resource-group-name> --server <database-server-name> --name <app-database-name> --service-objective S0

```

## Next Steps
