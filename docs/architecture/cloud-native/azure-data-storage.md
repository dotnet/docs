---
title: Data storage in Azure
description: Architecting Cloud Native .NET Apps for Azure | Data storage in Azure
ms.date: 06/30/2019
---
# Data storage in Azure

As we seen throughout this book, the cloud is changing the way applications are designed, deployed and managed. When moving there, a critical question is what do we do about our data? Fortunately, the Azure cloud provides many options.

You could simply provision a virtual machine and install your database of choice. While such an [Infrastructure as a Service (IaaS)](https://www.techopedia.com/definition/141/ infrastructure-as-a-service-iaas) approach might facilate moving an on-premises database into the cloud as-is, it would put the burden of managing the virtual machine and the database onto you.

A more popular approach is that of a fully-managed [Database as a Service (DBaaS)](https://www.stratoscale.com/blog/dbaas/what-is-database-as-a-service/) experience. You get a plethora of features and functionality while the hosting, maintenance and licensing by managed by Microsoft. Azure features a wide variety of fully-managed data storage options, each with specific benefits. They all support a just-in-time capacity and a pay-as-you-go model.

Here, we’ll fly over many of the key data services that are available in Azure. As you will soon see, Microsoft continues is commitment to making Azure an “open platform,” offering managed support for numerous open-source relational and NoSQL databases and making key contributions to the various open-source foundations as an active member.

## Azure SQL Database

[Azure SQL Database](https://docs.microsoft.com/azure/sql-database/) is a feature-rich, general-purpose relational database-as-a-service (DBaaS) based on the latest stable version of Microsoft SQL Server Database Engine. Fully managed by Microsoft, SQL Database is a high-performance, reliable, and secure cloud database. The service shares many of the features found in the on-premises SQL Server. 

You can provision a SQL Database server and database in minutes. When demand for your underlying app grows from a handful of devices and customers to millions, Azure SQL Database scales on the fly with minimal downtime. Its scalability features enables you to dynamically add or remove resources including CPU power, memory, IO throughput, and storage allocated to your databases.

Figure 5-12, show below, depicts the deployment options for Azure SQL Database.

![Azure sql deployment options](media/azure-sql-database-deployment-options.png)

**Figure 5-12**. Azure SQL Deployment Options

The alternatives in the figure above include deploying a SQL Database as a…

-   [Single
    database](https://docs.microsoft.com/azure/sql-database/sql-database-single-database) with its own set of resources managed via a SQL Database server. A single database is similar to a [contained database](https://docs.microsoft.com/sql/relational-databases/databases/contained-databases) in an on-premises SQL Server deployment.

-   [Elastic
    pool](https://docs.microsoft.com/azure/sql-database/sql-database-elastic-pool), which is a collection of databases with that share a single SQL Database server and the server resources at a set price. Single databases can be moved into and out of an elastic pool as needed to optimize the price performance for a group of databases.

-   [Managed
    instance](https://docs.microsoft.com/azure/sql-database/sql-database-managed-instance), which is a collection of system and user databases which provides near- 100%    compatibility with an on-premises SQL Server. This option supports larger databases, up to 35 TB, and is placed inside of an [Azure Virtual Network](https://docs.microsoft.com/azure/virtual-network/virtual-networks-overview) for better isolation.

Azure SQL Database is a fully managed [Platform as a Service (PaaS) Database Engine](https://docs.microsoft.com/azure/sql-database/sql-database-paas) that handles many database management functions such as upgrading, patching, backups, and monitoring without user involvement. Azure SQL Database is always running on the latest stable version of SQL Server Database Engine and patched OS with 99.99% availability. One such feature, [active geo-replication](https://docs.microsoft.com/azure/sql-database/sql-database-active-geo-replication), enables you to create readable secondardy databases in the same or different Azure data center. Upon failure, a failover to a secondary database in a different Azure region can be initiated. At that point, the other secondaries are automatically linked to the new primary. Up to four secondaries are supported in the same or different regions, and secondaries can also be leveraged for read-only access queries.

Azure SQL Database includes a wealth of [built-in monitoring and intelligent tuning](https://docs.microsoft.com/azure/sql-database/sql-database-monitoring-tuning-index) that can help you maximize performance and help reduce operational costs. For example, the [Automatic Tuning](https://docs.microsoft.com/azure/sql-database/sql-database-automatic-tuning) feature provides continuous performance tuning based on AI and machine learning. The service learns from the running workloads and can apply tuning recommendations. The longer an Azure SQL Database runs with automatic tuning enabled, the better it performs.

[Azure SQL Database serverless](https://docs.microsoft.com/azure/sql-database/sql-database-serverless) (available for preview as of the writing of this book) is a compute tier for single databases that automatically scales compute based on workload demand and bills for the amount of compute used per second. The serverless compute tier also automatically pauses databases during inactive periods when only storage is billed and automatically resumes databases when activity returns.

Finally, there is the new [Azure SQL Database Hyperscale](https://azure.microsoft.com/services/sql-database/) pricing tier. Powered by a highly scalable storage architecture, it enables a database to grow as needed, effectively eliminating the need to pre-provision storage resources. You can scale compute and storage resources independently, providing flexibility to optimize performance for workloads. Azure SQL Database Hyperscale is optimized for OLTP and high throughput analytics workloads with storage up to 100TB.  With read-intensive workloads, Hyperscale provides rapid scale-out by provisioning additional read replicas as needed for offloading read workloads. 

Moving beyond the traditional Microsoft SQL Server stack, Azure also features managed versions of several widely-popular open-source databases.

## Azure Database for MySQL

[MySQL](https://en.wikipedia.org/wiki/MySQL) is an [open-source](https://en.wikipedia.org/wiki/Open-source_software) [relational database](https://en.wikipedia.org/wiki/Relational_database_management_system). It is a key component of the [LAMP software stack](https://en.wikipedia.org/wiki/LAMP_(software_bundle)) and used by many large organizations, including Facebook, Twitter and You Tube. The community edition is available for free while the enterprise edition subscription requires a license purchase. Originally created in 1995, the product was purchased by Sun Microsystems in 2008 which was acquired by Oracle in 2010.

[Azure Database for MySQL](https://azure.microsoft.com/services/mysql/) is a fully managed, enterprise-ready relational database service based on the open-source MySQL Server engine. Based upon the MySQL Community edition, it includes the following Platform as a Service (PaaS) capabilities at no additional cost:

-   Built-in [high availability](https://docs.microsoft.com/azure/mysql/concepts-high-availability) with no additional cost.

-   Predictable performance, using inclusive [pay-as-you-go pricing](https://docs.microsoft.com/azure/mysql/concepts-pricing-tiers). 

-   [Scale](https://docs.microsoft.com/azure/mysql/concepts-high-availability) as needed within seconds.

-   Secured to protect sensitive data at-rest and in-motion.

-   [Automatic backups](https://docs.microsoft.com/azure/mysql/concepts-backup) and [point-in-time-restore](https://docs.microsoft.com/azure/mysql/concepts-backup) for up to 35 days.

-   Enterprise-grade security and compliance.

These built-in PaaS services become extremely important for organizaitons who have hundreds of these “tactical (not strategic” databases in their data centers, but do not have the resources to perform patching, backup, security and performance monitoring. 

Additionally, the [Azure Data Migration Service](https://azure.microsoft.com/services/database-migration/) can facilitate migrations from multiple database sources to Azure Data platforms with minimal downtime. The service generates assessment reports that provide recommendations to guide you through the changes required prior to performing a migration, both small or large.

The managed [Azure MySQL server](https://docs.microsoft.com/azure/mysql/concepts-servers) is the central administrative point for the service. It is the same MySQL server construct from the on-premises world. Within it, you can create one or multiple databases. You can opt to create a single database per server to use all the resources or to create multiple databases to share the resources. At the same time, your team can continue to develop your applications with the open-source tools and platform of your choice without having to learn new skills or manage virtual machines and infrastructure.

## Azure Database for MariaDB

[MariaDB ](https://mariadb.com/)Server is a popular open-source database server. It was created as a fork of MySQL by the original developers of MySQL at the time that Oracle purchased Sun Microsystems who owned MySQL. The intent was to ensure that MariaDB remained open-source.

As MariaDB is a [fork of MySQL](https://blog.panoply.io/a-comparative-vmariadb-vs-mysql), the data and table definitions are compatible, the client protocols, structures and APIs are close knit and the MySQL connectors will work MariaDB without modification.

Like MySQL, MariaDB has a strong following and is used by many large enterprises. While Oracle continues to maintain, enhance and support MySQL, MariaDB is managed by the MariaDB Foundation allowing people to contribute to the product and documentation.

[Azure Database for MariaDB](https://azure.microsoft.com/services/mariadb/) is a relational database service available in the Azure cloud. Azure Database for MariaDB is based on the [MariaDB community edition](https://mariadb.org/download/) server engine. It's a fully managed database as a service offering that can handle mission-critical workloads with predictable performance and dynamic scalability. Like the other Azure Database platforms, it includes many Platform as a Service capabilities at no additional cost:

-   Built-in [high availability](https://docs.microsoft.com/azure/mariadb/concepts-high-availability) with no additional cost.

-   Predictable performance, using inclusive [pay-as-you-go pricing](https://docs.microsoft.com/azure/mariadb/concepts-pricing-tiers). 
 
-   [Scaling](https://docs.microsoft.com/azure/mariadb/concepts-high-availability) as needed within seconds.

-   Secured protection of sensitive data at rest and in motion.

-   [Automatic backups](https://docs.microsoft.com/azure/mariadb/concepts-backup) and [point-in-time-restore](https://docs.microsoft.com/azure/mariadb/concepts-backup)    for up to 35 days.

-   Enterprise-grade security and compliance.

## Azure Database for PostgreSQL 

[PostgreSQL](https://www.postgresql.org/) is extremely popular, open-source relational database with over 30 years of active development. It is a general purpose and object-relational database management system. Its licensing is considered to be “liberal” and the product is free to use, modify and distribute in any form. Many large enterprises have built products using PostgreSQL including Apple, Red Hat and Fujitsu.

[Azure Database for PostgreSQL](https://azure.microsoft.com/services/postgresql/) is a fully-managed relational database service, based on the open-source Postgres database engine. It can handle mission-critical workloads with predictable performance, security, high availability, and dynamic scalability. It supports several open source frameworks and languages—including C++, Java, Python, Node, C\# and PHP and enables the [migration](https://datamigration.microsoft.com/scenario/postgresql-to-azurepostgresql?step=1) of PostgreSQL databases through a command line interface or the [Azure Data Migration Service](Azure%20Database%20Migration%20Service).

The service includes [built-in intelligence](https://docs.microsoft.com/azure/postgresql/concepts-monitoring) that learns your unique database patterns and provides customized recommendations and insights to hep you maximize performance of your PostgreSQL database. [Advanced Threat Protection](https://docs.microsoft.com/azure/postgresql/concepts-data-access-and-security-threat-protection) monitors your database around the clock and detects potential malicious activities, alerting you upon detection so you can intervene right away.

It's available in two deployment options, Single Server and Hyperscale (Citus), currently in preview.

-   The [Single Server](https://docs.microsoft.com/azure/postgresql/concepts-servers) deployment option is a central administrative point for multiple databases. It is the same PostgreSQL server construct that you would deploy in the on-premises world. Within it, you can opt to create a single database per server to utilize all the resources or create multiple databases to share the resources. The pricing is structured per-server based upon cores and storage.

-   The [Hyperscale (Citus) option](https://azure.microsoft.com/blog/get-high-performance-scaling-for-your-azure-database-workloads-with-hyperscale/) powered by [Citus Data](https://www.citusdata.com/) technology brings high-performance scaling to PostgreSQL database workloads by horizontally scaling a single database across hundreds of nodes to deliver blazingly fast performance and scale. This enables the engine to fit more data to in-memory, parallelize queries across hundreds of nodes and index data faster. The Hyperscale feature is compatible with the latest innovations, versions and tools of PostgreSQL, so you can leverage your existing PostgreSQL expertise.

## Cosmos DB

Blah

### Consistency Models

Blah

### Open-Source Support

MongoDB, Casandra, GraphAPI

### Providers

Blah

### Availability

Blah

### Partitioning

Blah

## Azure Storage Services

<https://azure.microsoft.com/product-categories/databases/>

Blah

### Azure Blobs

Blah

### Azure Tables

Blah

Comparison of Cosmos Table vs Azure Table Provider

<https://docs.microsoft.com/azure/cosmos-db/table-support>

### Azure Files

Blah

## Additional resources

>[!div class="step-by-step"]
>[Previous](data-patterns.md)
>[Next](caching-in-azure.md)
