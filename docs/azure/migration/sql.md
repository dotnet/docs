---
title: Migrate a SQL Server database to Azure
description: Learn how to migrate a SQL Server database from on-premises SQL Server to Azure.
ms.topic: how-to
ms.date: 05/27/2020
recommendations: false
---

# Migrate a SQL Server database to Azure

This article provides a brief outline of two options for migrating a SQL Server database to Azure. Azure has three primary options for migrating a production SQL Server database. This article focuses on the following two options:

1. [SQL Server on Azure VMs](/azure/virtual-machines/windows/sql/virtual-machines-windows-sql-server-iaas-overview): A SQL Server instance installed and hosted on a Windows Virtual Machine running in Azure, also known as Infrastructure as a Service (IaaS).
2. [Azure SQL Database](/azure/sql-database/sql-database-technical-overview): A fully managed SQL database Azure service, also known as Platform as a Service (PaaS).

Both come with pros and cons that you will need to evaluate before migrating. The third option is [Azure SQL Database managed instances](/azure/sql-database/sql-database-managed-instance).

## Get started

The following migration guides will be useful, depending on which service you use:

* [Migrate a SQL Server database to SQL Server in an Azure VM](/azure/virtual-machines/windows/sql/virtual-machines-windows-migrate-sql)
* [Migrate your SQL Server database to Azure SQL Database](/azure/sql-database/sql-database-migrate-your-sql-server-database)

Additionally, the following links to conceptual content will help you understand VMs better:

* [High availability and disaster recovery for SQL Server in Azure Virtual Machines](/azure/virtual-machines/windows/sql/virtual-machines-windows-sql-high-availability-dr)
* [Performance best practices for SQL Server in Azure Virtual Machines](/azure/virtual-machines/windows/sql/virtual-machines-windows-sql-performance)
* [Application Patterns and Development Strategies for SQL Server in Azure Virtual Machines](/azure/virtual-machines/windows/sql/virtual-machines-windows-sql-server-app-patterns-dev-strategies)

And the following links will help you understand Azure SQL Database better:

* [Create and manage Azure SQL Database servers and databases](/azure/sql-database/sql-database-servers-databases)
* [Database Transaction Units (DTUs) and elastic Database Transaction Units (eDTUs)](/azure/sql-database/sql-database-what-is-a-dtu)
* [Azure SQL Database resource limits](/azure/sql-database/sql-database-resource-limits)

## Choosing IaaS or PaaS

When evaluating where to migrate your database, determine if IaaS or PaaS is more appropriate for you.

**Choose SQL Server in Azure VMs if:**

* You are looking to "lift and shift" your database and applications with minimal to no changes.
* You prefer having full control over your database server and the VM it runs on.
* You already have SQL Server and Windows Server licenses that you intend to use.

**Choose Azure SQL Database if:**

* You are looking to modernize your applications and are migrating to use other PaaS services in Azure.
* You do not wish to manage your database server and the VM it runs on.
* You do not have SQL Server or Windows Server licenses, or you intend to let licenses you have expire.

The following table describes differences between each service based on a set of scenarios.

| Scenario | SQL Server in Azure VMs | Azure SQL Database |
|----------|-------------------------|--------------------|
| Migration | Requires minimal changes to your database. | May require changes to your database if you use features unavailable in Azure SQL, as determined by the [Data Migration Assistant](https://www.microsoft.com/download/details.aspx?id=53595), or if you have other dependencies such as locally installed executables.|
| Managing availability, recovery, and upgrades | Availability and recovery are configured manually. Upgrades can be automated with [VM Scale Sets](/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-automatic-upgrade). | Automatically managed for you. |
| Underlying OS configuration | Manual configuration. | Automatically managed for you. |
| Managing database size | Supports up to 256 TB of storage per SQL Server instance. | Supports 8 TB of storage before needing a horizontal partition. |
| Managing costs | You must manage SQL Server license costs, Windows Server license costs, and VM costs (based on cores, RAM, and storage). | You must manage service costs (based on [eDTUs or DTUs](/azure/sql-database/sql-database-what-is-a-dtu), storage, and number of databases if using an elastic pool). You must also manage the cost of any SLA. |

To learn more about the differences between the two, see [Choose the right deployment option in Azure SQL](/azure/sql-database/sql-database-paas-vs-sql-server-iaas).

## FAQ

* **Can I still use tools such as SQL Server Management Studio and SQL Server Reporting Services (SSRS) with SQL Server in Azure VMs or Azure SQL Database?**

    Yes. All Microsoft SQL tooling works with both services. SSRS is not part of Azure SQL Database, though, and it's recommended that you run it in an Azure VM and then point it to your database instance.

* **I want to go PaaS but I'm not sure if my database is compatible. Are there tools to help?**

    Yes. The [Data Migration Assistant](https://www.microsoft.com/download/details.aspx?id=53595) is a tool that is used as a part of migrating to Azure SQL Database. The [Azure Database Migration Service](https://azure.microsoft.com/campaigns/database-migration/) is a preview service that you can use for either IaaS or PaaS.

* **Can I estimate costs?**

    Yes. The [Azure Pricing Calculator](https://azure.microsoft.com/pricing/calculator/) can be used for estimating costs for all Azure services, including VMs and database services.

## Next steps

> [!div class="nextstepaction"]
> [Choose the right Azure hosting option](choose.md)
