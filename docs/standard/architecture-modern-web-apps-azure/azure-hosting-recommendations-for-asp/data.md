---
title: Data | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Data
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# Data

Azure offers a wide variety of data storage options, so that your application can use the appropriate data provider for the data in question.

For transactional, relational data, Azure SQL Databases are the best option. For high performance read-mostly data, a Redis cache backed by an Azure SQL Database is a good solution.

Unstructured JSON data can be stored in a variety of ways, from SQL Database columns to Blobs or Tables in Azure Storage, to DocumentDB. Of these, DocumentDB offers the best querying functionality, and is the recommended option for large numbers of JSON-based documents that must support querying.

Transient command- or event-based data used to orchestrate application behavior can use Azure Service Bus or Azure Storage Queues. Azure Storage Bus offers more flexibility and is the recommended service for non-trivial messaging within and between applications.


>[!div class="step-by-step"]
[Previous] (logical-processes.md)
[Next] (architecture-recommendations.md)
