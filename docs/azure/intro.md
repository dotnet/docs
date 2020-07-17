---
title: Get started with Azure and .NET
description: Learn the basics you need to know about Azure and .NET.
ms.date: 06/20/2020
---

# Introduction to Azure and .NET

This document provides an overview of key concepts and services .NET developers should be familiar with to get started developing apps using Azure services.

## Key Concepts

**Azure account**: Your Azure account is the credential you use to sign into Azure services, such as the [Azure Portal](https://portal.azure.com) or [Cloud Shell](https://shell.azure.com). If you don't have an Azure account, you can [create one for free](https://azure.microsoft.com/free/dotnet/).

**Azure subscription**: A subscription is the billing plan within which Azure resources are created. Subscriptions can be individual subscriptions or enterprise subscriptions managed by your company. Your Azure account can be associated with multiple subscriptions. In this case, make sure you're selecting the correct subscription when creating resources. For more information, see [Understanding accounts, subscriptions and billing](/azure/guides/developer/azure-developer-guide#understanding-accounts-subscriptions-and-billing).

> [!TIP]
> If you have a Visual Studio subscription, [you have monthly Azure credits waiting to be activated](https://azure.microsoft.com/pricing/member-offers/credit-for-visual-studio-subscribers/).

**Resource group**: Resource groups are a way to organize your Azure resources into groups for management. Resources created in Azure will be stored in a resource group, similar to saving a file in a folder on a computer.

**Hosting**: To run code in Azure, it needs to be hosted in a service that supports executing user-provided code.

**Managed services**: Azure provides some services where you provide data or information to Azure, and Azure's implementation takes the appropriate action. One example is Azure Blob Storage, where you provide files and Azure handles reading, writing, and persisting them.

**Azure SDK for .NET**: Sometimes referred to as the **Azure libraries for .NET**, this collectively refers to the [NuGet packages](https://www.nuget.org/profiles/azure-sdk) you install in your project that provide various interactions and functionality with Azure services. These packages also include management libraries used to provision and administer the resources.

## Choosing a hosting option

Hosting in Azure can be divided into three categories.

* **Infrastructure-as-a-Service (IaaS)**: With IaaS, you provision the virtual machines you need along with associated network and storage components. You then deploy whatever software and applications you want onto those VMs. This model is the closest to a traditional on-premises environment except that Microsoft manages the infrastructure. You still manage the individual VMs, including the operating system, custom software, and security updates.

* **Platform-as-a-Service (PaaS)**: PaaS provides a managed hosting environment where you deploy your application without needing to manage VMs or networking resources. For example, instead of creating individual VMs, you specify an instance count, and the service will provision, configure, and manage the necessary resources. Azure App Service is an example of a PaaS service.
  
* **Functions-as-a-Service (FaaS)**: Commonly referred to as serverless computing, FaaS goes even further than PaaS in abstracting the concerns of the hosting environment. Instead of creating compute instances and then deploying code to those instances, you deploy your code and the service automatically runs it. You don't need to administer the compute resources. The platform seamlessly scales your code up or down to whatever level necessary to handle the traffic, and you pay only when your code is running. Azure Functions is a FaaS service.

Generally, the more your application favors FaaS and PaaS models, the more benefits you'll see from running in the cloud. Below is a summary of three common hosting choices in Azure and when to choose them.

* [Azure App Service](/azure/app-service/app-service-value-prop-what-is): If you're looking to host a web application or service, look at App Service first. To get started with App Service and ASP.NET, WCF, and ASP.NET Core apps, see [Create an ASP.NET Core web app in Azure](/azure/app-service/app-service-web-get-started-dotnet).

* [Azure Functions](/azure/azure-functions/functions-overview): Azure Functions is great for event-driven workflows. Examples include responding to webhooks, processing items in queues or blob storage, and timers. To get started with Azure Functions, see [Create your first function using Visual Studio](/azure/azure-functions/functions-create-your-first-function-visual-studio).

* [Azure Virtual Machines](/azure/virtual-machines/): If App Service doesn't meet your needs for hosting an existing application due to specific dependencies, Virtual Machines will be the easiest place to start. To get started with Virtual Machines and ASP.NET or WCF, see [Deploy an ASP.NET app to an Azure virtual machine](https://tutorials.visualstudio.com/aspnet-vm/intro).

> [!TIP]
> For more information on choosing a service, see [Choose an Azure compute service for your application](/azure/architecture/guide/technology-choices/compute-decision-tree).

## Choose a data storage service

Azure offers several services for storing your data depending on your needs. The most common data services for .NET developers are:

* [Azure SQL Database](/azure/sql-database/): If you're looking to migrate an application that is already using SQL Server to the cloud, Azure SQL Database is a natural place to start. To get started, see [Tutorial: Build an ASP.NET app in Azure with SQL Database](/azure/app-service/app-service-web-tutorial-dotnet-sqldatabase).

* [Azure Cosmos DB](/azure/cosmos-db/): Azure Cosmos DB is a modern database designed for the cloud. When starting a new application that doesn't yet have a specific database dependency, you should look at Azure Cosmos DB. Cosmos DB is a good choice for new web, mobile, gaming, and IoT applications where automatic scale, predictable performance, fast response times, and the ability to query schema-free data are important. To get started, see [Quickstart: Build a .NET web app with Azure Cosmos DB using the SQL API and the Azure portal](/azure/cosmos-db/create-sql-api-dotnet).

* [Azure Blob Storage](/azure/storage/): Azure Blob Storage is optimized for storing and retrieving large binary objects, such as images, files, and streams. Object stores enable the management of extremely large amounts of unstructured data. To get started, see [Quickstart: Use .NET to create a blob in object storage](/azure/storage/blobs/storage-quickstart-blobs-dotnet).

> [!TIP]
> For more information, see [Choose the right data store](/azure/architecture/guide/technology-choices/data-store-overview).

## Connect to Azure services

If you use Visual Studio, you can add support for certain Azure services to your projects. The **Connected Services** dialog in Visual Studio provides an easy way to add all the required references, connection code, and configuration settings to your projects. Some commonly used Azure services are supported out of the box, such as [Storage](/azure/vs-azure-tools-connected-services-storage), [Azure Active Directory](/azure/active-directory/develop/vs-active-directory-add-connected-service) authentication, [Azure Key Vault](/azure/key-vault/vs-key-vault-add-connected-service), and [Cognitive Services](/azure/cognitive-services/) such as [Computer Vision](/azure/cognitive-services/computer-vision/vs-computer-vision-connected-service). More services, including third-party services, are available as extensions in the [Visual Studio Marketplace](https://marketplace.visualstudio.com/search?term=connected%20service&target=VS&category=Tools&vsVersion=&subCategory=All&sortBy=Relevance).

## Using the Azure SDK for .NET

If you're using the Azure SDK for .NET to access or manage your Azure resources, please note the following:

* **Authentication**: Many libraries in the SDK use a common authentication infrastructure, while some libraries use authentication mechanisms specific to the service they're consuming. For more information, see [Authentication with the Azure SDK for .NET](authentication.md).
* **Logging**: If supported, the client libraries include the ability to log client library operations. For more information, see [Logging with the Azure SDK for .NET](logging.md).
* **REST API**: The Azure SDK for .NET is an abstraction built on the [Azure REST API](/rest/api/azure/). The Azure REST API may be used in lieu of or alongside the Azure SDK for .NET if desired.

## Diagnosing problems in the Cloud
Once you deploy your application to Azure, you may run into cases where it worked in development but doesn't in Azure. Below are two good places to start when diagnosing issues:

* **Remote debug from Visual Studio**: Most Azure compute services (including the services discussed in this document) support remote debugging with Visual Studio and acquiring logs. To explore Visual Studio's capabilities with your application, open the Cloud Explorer tool window by typing 'Cloud Explorer' into Visual Studio's quick launch toolbar (in the upper-right corner), and then locate your application in the tree. For details, see [Troubleshoot a web app in Azure App Service using Visual Studio](/azure/app-service/web-sites-dotnet-troubleshoot-visual-studio#remotedebug).

* **Application Insights**: [Application Insights](/azure/application-insights/) is a complete application performance monitoring (APM) solution that captures diagnostic data, telemetry, and performance data from applications automatically. To get started collecting diagnostic data for your app, see [Start monitoring your ASP.NET Web Application](/azure/application-insights/quick-monitor-portal).

## Next steps

* [Deploy your first ASP.NET Core web app to Azure](/azure/app-service/app-service-web-get-started-dotnet)
* [Learn about authentication in Azure SDK for .NET](authentication.md)
* [Diagnose errors in your cloud apps](https://devblogs.microsoft.com/aspnet/diagnosing-errors-on-your-cloud-apps/)
* Download the free e-book [Azure Quick Start Guide for .NET Developers](https://www.microsoft.com/net/download/thank-you/azure-quick-start-ebook)
