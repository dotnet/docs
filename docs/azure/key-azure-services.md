---
title: Key Azure Services for .NET developers
description: Azure has over 100 services, but this article focuses on the ~8 or so services used by .NET developers most frequently
ms.date: 06/01/2021
ms.topic: conceptual
ms.custom: devx-track-dotnet
ms.author: daberry
author: DavidCBerry13
---

# Key Azure Services for .NET developers

While Azure contains over 100 services, the following Azure services are the services you will use most frequently as a .NET developer.

| Icon | Service | Description |
|:----:|:--------|:------------|
| ![App Service Icon](./media/app-services.svg) | **Azure App Service** | Azure App Service is a fully managed platform for hosting web applications and APIs in Azure.  It features automatic load balancing and auto-scaling in a highly available environment.  You pay only for the compute resources you use and free tiers are available. |
| ![Azure Functions Icon](./media/azure-functions.svg) | **Azure Functions** | Azure Functions is a serverless compute service that lets you write small, discrete segments of code that can be executed in a scalable and cost-effective manner, all without managing any servers or runtimes.  Functions can be invoked by a variety of different events and easily integrate with other Azure services through the use of input and output bindings.        |
| ![Azure SQL Icon](./media/azure-sql.svg) | **Azure SQL**            | Azure SQL is a fully managed cloud based version of SQL Server. Azure automatically performs traditional administrative tasks like patching and backups for you and features built-in high availability.  |
| ![Cosmos DB Icon](./media/cosmos-db.svg) | **Azure Cosmos DB**      | Azure Cosmos DB is a fully managed NoSQL database with single digit response times, automatic scaling, and a MongoDB compatible API.                    |
| ![Azure Storage Blobs Icon](./media/storage-blobs.svg) | **Azure Blob Storage**   | Azure Blob Storage allows your applications to store and retrieve files in the cloud.  Azure Storage is highly scalable to store massive amounts of data and data is stored redundantly to ensure high availability. |
| ![Azure Service Bus Icon](./media/service-bus.svg) | **Azure Service Bus**   | Azure Service Bus is a fully managed enterprise message broker supporting both point to point and publish-subscribe integrations.  It is ideal for building decoupled applications, queue based load leveling, or facilitating communication between microservices.   |
| ![Azure Key Vault Icon](./media/azure-key-vault.svg) | **Azure Key Vault**   | Every application has application secrets like connection strings and API keys it must store.  Azure Key Vault helps you store and access those secrets securely, in an encrypted vault with restricted access to make sure your secrets and your application are not compromised.   |
| ![Cognitive Services Icon](./media/cognitive-services.svg) | **Cognitive Services**   | Azure Cognitive Services are a collection of cloud-based services that allow you to add AI based capabilities to your application.  Examples include computer vision, speech recognition, language understanding, and anomaly detection. |

For the full list of Azure products and services, visit the [Azure documentation home page](/azure/?product=all)

### Next steps

Start configuring your Azure development environment by [Creating an Azure Account](create-azure-account.md)
