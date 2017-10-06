---
title: working with data in asp | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | working with data in asp
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
-   [Summary](#summary)
-   [Entity Framework Core (for relational databases)](#entity-framework-core-for-relational-databases)
    -   [The DbContext](#the-dbcontext)
    -   [Configuring EF Core](#configuring-ef-core)
    -   [Fetching and Storing Data](#fetching-and-storing-data)
    -   [Fetching Related Data](#fetching-related-data)
    -   [Resilient Connections](#resilient-connections)
-   [EF Core or micro-ORM?](#ef-core-or-micro-orm)
-   [SQL or NoSQL](#sql-or-nosql)
-   [Azure DocumentDB](#azure-documentdb)
-   [Other Persistence Options](#other-persistence-options)
-   [Caching](#caching)
    -   [ASP.NET Core Response Caching](#asp.net-core-response-caching)
    -   [Data Caching](#data-caching)

Working with Data in ASP.NET Core Apps

> "Data is a precious thing and will last longer than the systems themselves."

Tim Berners-Lee


>[!div class="step-by-step"]
[Previous] (../developing-asp/deployment.md)
[Next] (summary.md)
