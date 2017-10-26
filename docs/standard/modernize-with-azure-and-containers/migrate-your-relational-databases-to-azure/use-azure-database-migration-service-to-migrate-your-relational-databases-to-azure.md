---
title: Use Azure Database Migration Service to migrate your relational databases to Azure  | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Use Azure Database Migration Service to migrate your relational databases to Azure 
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/28/2017
---
# Use Azure Database Migration Service to migrate your relational databases to Azure 

You can use Azure Database Migration Service to migrate relational databases like SQL Server, Oracle, and MySQL to Azure, whether your target database is Azure SQL Database, Azure SQL Database Managed Instance, or SQL Server on an Azure VM.

The automated workflow, with assessment reporting, guides you through the changes you need to make before you migrate the database. When you are ready, the service migrates the source database to Azure.

Whenever you change an original RDBMS, you might need to retest. You also might need to change the SQL sentences or Object-Relational Mapping (ORM) code in your application, depending on testing results.

If you have any other database (for example, IBM DB2) and you opt for a lift and shift approach, you might want to continue using those databases as IaaS VMs in Azure, unless you are willing to perform a more complex data migration. A more complex data migration will require additional effort, because you'd be migrating to a different database type with new schema and different programming libraries.

To learn how to migrate databases by using Azure Database Migration Service, see [Get to the cloud faster with Azure SQL Database Managed Instance and Azure Database Migration Service](https://channel9.msdn.com/Events/Build/2017/P4008).

### Additional resources

-   **Choose a cloud SQL Server option: Azure SQL Database (PaaS) or SQL Server on Azure VM (IaaS)**

    <https://docs.microsoft.com/en-us/azure/sql-database/sql-database-paas-vs-sql-server-iaas>

-   **Get to the cloud faster with Azure SQL DB Managed Instance and Database Migration Service**

    <https://channel9.msdn.com/Events/Build/2017/P4008>

-   **SQL Server database migration to SQL Database in the cloud**

    <https://docs.microsoft.com/en-us/azure/sql-database/sql-database-cloud-migrate>

-   **Azure SQL Database**

    <https://azure.microsoft.com/en-us/services/sql-database/?v=16.50>

-   **SQL Server on virtual machines**

    <https://azure.microsoft.com/en-us/services/virtual-machines/sql-server/>

> [Previous](when-to-migrate-to-sql-server-as-a-vm-iaas.md)  
[Next](../lift-and-shift-existing-apps-devops/index.md)
