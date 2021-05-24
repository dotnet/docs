---
title: Hosting ASP.NET Core and ASP.NET application on Azure - Solution overview
description: This article provides the high level design of how to host ASP.NET Core and ASP.NET web applications and APIs on Azure
ms.date: 05/20/2021
ms.topic: conceptual
ms.custom: devx-track-dotnet
ms.author: daberry
---

# Hosting ASP.NET Core and ASP.NET application on Azure - Solution overview

## Solution overview

This tutorial shows how to deploy an ASP.NET Core or ASP.NET web application to Azure using an Azure SQL database.  The web application will
be hosted using Azure App Service where as the database will be hosted using Azure SQL.  This article will show you how to provision the required
Azure services, establish connectivity between the web app and database, run database migrations, and deploy your application.

:::image type="content" source="../media/aspnet-app.png" alt-text="Diagram showing what Azure services different components of an ASP.NET Core or ASP.NET application use":::

## Sample application

To follow along, you may download or clone the sample application from the repository [https://github.com/azure-samples/dotnetcore-sqldb-tutorial](https://github.com/azure-samples/dotnetcore-sqldb-tutorial).

```bash
git clone https://github.com/azure-samples/dotnetcore-sqldb-tutorial
```
