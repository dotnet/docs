---
title: When to migrate to Azure SQL Database Managed Instance | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | When to migrate to Azure SQL Database Managed Instance
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/28/2017
---
# When to migrate to Azure SQL Database Managed Instance

In most cases, Azure SQL Database Managed Instance will be your best option to consider when you migrate your data to Azure. If you are migrating SQL Server databases and need nearly 100% assurance that you won't need to re-architect your application or make changes to your data or data access code, choose the Managed Instance feature of Azure SQL Database.

Azure SQL Database Managed Instance is the best option if you have additional requirements for SQL Server instance-level functionality, or isolation requirements beyond the features provided in a standard Azure SQL Database (single database model). This last one is the most PaaS-oriented choice, but it doesn't offer the same features as that of a traditional SQL server. Migration might surface frictions.

For example, an organization that has made deep investments in instance-level SQL Server capabilities would benefit from migrating to SQL Managed Instance. Examples of instance-level SQL Server capabilities include SQL common language runtime (CLR) integration, SQL Server Agent, and cross-database querying. Support for these features are not available in standard Azure SQL Database (a single-database model).

An organization that operates in a highly regulated industry, and which needs to maintain isolation for security purposes, also might benefit from choosing the SQL Managed Instance model.

Managed Instance in Azure SQL Database has the following characteristics:

-   Security isolation through Azure Virtual Network

-   Application surface compatibility, with these features:

    -   SQL Server Agent and SQL Server Profiler

    -   Cross-database references and queries, SQL CLR, replication, change data capture (CDC), and Service Broker

-   Database sizes up to 35 TB

-   Minimum-downtime migration, with these features:

    -   Azure Database Migration Service

    -   Native backup and restore, and log shipping

With these capabilities, when you migrate existing application databases to Azure SQL Database, the Managed Instance model offers nearly 100% of the benefits of Paas for SQL Server. Managed Instance is a SQL Server environment where you continue using instance-level capabilities without changing your application design.

Managed Instance is probably the best fit for enterprises that currently are using SQL Server, and which require flexibility in their network security in the cloud. It's like having a private virtual network for your SQL databases.



> [Previous](index.md)  
[Next](when-to-migrate-to-azure-sql-database.md)
