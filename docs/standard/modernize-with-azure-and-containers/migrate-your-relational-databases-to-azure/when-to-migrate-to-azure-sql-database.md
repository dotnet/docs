---
title: When to migrate to Azure SQL Database  | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | When to migrate to Azure SQL Database 
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/28/2017
---
# When to migrate to Azure SQL Database 

As mentioned, the standard Azure SQL Database is a fully managed, relational DBaaS. SQL Database currently manages millions of production databases, across 38 datacenters, around the world. It supports a broad range of applications and workloads, from managing straightforward transactional data, to driving the most data-intensive, mission-critical applications that require advanced data processing at a global scale.

Because of its full PaaS features and better pricing-and ultimately lower cost-you should move to the standard Azure SQL Database as your "by-default choice" if you have an application that uses basic, standard SQL databases, and no additional instance features. SQL Server features like SQL CLR integration, SQL Server Agent, and cross-database querying are not supported in the standard Azure SQL Database. Those features are available only in the Azure SQL Database Managed Instance model.

Azure SQL Database is the only intelligent cloud database service that's built for app developers. It's also the only cloud database service that scales on-the-fly, without downtime, to help you efficiently deliver multitenant apps. Ultimately, Azure SQL Database leaves you more time to innovate, and it accelerates your time to market. You can build secure apps, and connect to your SQL database by using the languages and platforms that you prefer.

Azure SQL Database offers the following benefits:

-   Built-in intelligence (machine learning) that learns and adapts to your app

-   On-demand database provisioning

-   A range of offers, for all workloads

-   99.99% availability SLA, zero maintenance

-   Geo-replication and restore services for data protection

-   Azure SQL Database Point in Time Restore feature

-   Compatibility with SQL Server 2016, including hybrid and migration

The standard Azure SQL Database is closer to PaaS than Azure SQL Database Managed Instance. You should try to use it, if possible, because you'll get more benefits from a managed cloud. However, Azure SQL Database has some key differences from regular and on-premises SQL Server instances. Depending on your existing application's database requirements, and your enterprise requirements and policies, it might not be the best choice when you are planning your migration to the cloud.


> [Previous](when-to-migrate-to-azure-sql-database-managed-instance.md)  
[Next](when-to-move-your-original-rdbms-to-a-vm-iaas.md)
