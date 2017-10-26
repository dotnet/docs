---
title: When to move your original RDBMS to a VM (IaaS) | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | When to move your original RDBMS to a VM (IaaS)
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/28/2017
---
# When to move your original RDBMS to a VM (IaaS)

One of your migration options is to move your original relational database management system (RDBMS), including Oracle, IBM DB2, MySQL, PostgreSQL, or SQL Server, to a similar server that's running on an Azure VM. If you have existing applications that require the fastest migration to the cloud with minimal changes, or no changes at all, a direct migration to IaaS in the cloud might be a fair option. It might not be the best way to take advantage of all the cloud's benefits, but it's probably the fastest initial path.

Currently, Microsoft Azure supports up to [331 different database servers](https://azuremarketplace.microsoft.com/en-us/marketplace/apps/category/databases?page=1&subcategories=databases-all) deployed as IaaS VMs. These include popular RDBMSes like SQL Server, Oracle, MySQL, PostgreSQL, and IBM DB2, and many other NoSQL databases like MongoDB, Cassandra, DataStax, MariaDB, and Cloudera.

> [!NOTE]
> Although moving your RDBMS to an Azure VM might be the fastest way to migrate your data to the cloud (because it is IaaS), this approach requires a significant investment in your IT teams (database administrators and IT pros). Enterprise teams need to be able to set up and manage high availability, disaster recovery, and patching for SQL Server. This context also needs a customized environment, with full administrative rights.


> [Previous](when-to-migrate-to-azure-sql-database.md)  
[Next](when-to-migrate-to-sql-server-as-a-vm-iaas.md)
