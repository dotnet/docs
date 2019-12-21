---
title: Relational vs. NoSQL data
description: Learn about relational and NoSQL data in cloud-native applications
author: robvet
ms.date: 12/19/2019
---
# Relational vs. NoSQL data

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

The impact of [NoSQL](https://www.geeksforgeeks.org/introduction-to-nosql/) technologies for distributed cloud-native systems can't be overstated. The proliferation of new data technologies in this space has disrupted solutions that once exclusively relied on relational databases.

Relational databases have been a prevalent technology for decades. They're mature, proven, and widely implemented. Competing database products, tooling, and expertise abound. Relational databases provide a store of related data tables. These tables have a fixed schema, use SQL (Structured Query Language) to manage data, and support [ACID](https://www.geeksforgeeks.org/acid-properties-in-dbms/) guarantees. 

No-SQL databases refer to high-performance, non-relational data stores. They excel in their ease-of-use, scalability, resilience, and availability characteristics. Instead of joining tables of normalized data, NoSQL stores self-describing (schemaless) data typically in JSON documents. No-SQL databases typically don't provide [ACID](https://www.geeksforgeeks.org/acid-properties-in-dbms/) guarantees beyond the scope of a single database partition.

As a way to understand the differences between these types of databases, consider the [CAP theorem](https://towardsdatascience.com/cap-theorem-and-distributed-database-management-systems-5c2be977950e), a set of principles applied to distributed systems that store state. Figure 5-9 shows the three properties of the CAP theorem.

![CAP theorem](./media/cap-theorem.png)

**Figure 5-9**. The CAP theorem

The theorem states that distributed data systems will offer a trade-off between consistency, availability, and partition tolerance. And, that any database can only guarantee *two* of the three properties:

- *Consistency.* Every node in the cluster will respond with the most recent data, even if the system must block the request until all replicas update. If you query a "consistent system" for an item that is updating, you'll wait for that response until all replicas successfully update. However, you'll receive the most current data.

- *Availability.* Every node will return an immediate response, even if that response isn't the most recent data. If you query an "available system" for an item that is updating, you'll get the best possible answer the service can provide at that moment - even if the update hasn't replicated. 

- *Partition Tolerance.* Guarantees that the system will continue to operate if a replicated data node fails or loses connectivity with other replicated data nodes. 

Relational databases typically provide consistency and availability, but not partition tolerance. Relational databases scale-up, or vertically. Horizontally partitioning a relational database across multiple nodes, such as with [sharding](https://www.digitalocean.com/community/tutorials/understanding-database-sharding), is costly and time consuming to manage. Sharding can end up impacting performance, table joins, and referential integrity.

If data replicas were to lose network connectivity in a "highly consistent" relational database cluster, you wouldn't be able to write to the database. The system would reject the write operation as it can't replicate that change to every underlying data replica. Every data replica has to update before the transaction can complete.

NoSQL databases typically support high availability and partition tolerance. They scale out horizontally, often across commodity servers. This approach provides tremendous availability, both within and across geographical regions at a reduced cost. You partition and replicate data across these machines, or nodes, providing redundancy and fault tolerance. The downside is consistency. A change to data on one NoSQL node can take some time to propagate to other nodes. Typically, a NoSQL database node will provide an immediate response to a query - even if the data that is presented is stale and hasn't updated yet.

If data replicas were to lose connectivity in a "highly available" NoSQL database cluster, you could still complete a write operation to the database. The database cluster would allow the write operation and update each data replica as it becomes available.

This kind of result is known as [eventual consistency](http://www.cloudcomputingpatterns.org/eventual_consistency/), a characteristic of distributed data systems where ACID transactions aren't supported. It's a brief delay between the update of a data item and time that it takes to propagate that update to each of the replica nodes. Under normal conditions, the lag is typically short, but can increase when problems arise. For example, what would happen if you were to update a product item in a NoSQL database in the United States and query that same data item from a replica node in Europe? You would receive the earlier product information, until the cluster updates the European node with the product change. By immediately returning a query result and not waiting for all replica nodes to update, you gain enormous scale and volume, but with the possibility of presenting older data. For more on Eventual Consistency, see the Microsoft book [.NET Microservices: Architecture for Containerized .NET Applications](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/architect-microservice-container-applications/asynchronous-message-based-communication).

When possible, cloud-native services target the guarantees of data availability and partition tolerance over strong consistency. Often, high availability and massive scalability are often more critical to the business than consistency. Developers can implement techniques and patterns such as Sagas, CQRS, and asynchronous messaging that embraces eventual consistency.  

> Some care must be taken with these descriptions as some databases support configurations that can *"toggle"* these principles. For example, MySQL can be configured as either consistent and available or available and partition tolerant. Azure Cosmos DB also support five different consistency models as we'll see in the next section.

NoSQL databases include a variety of data models for accessing and managing data shown in Figure 5-10.

![Overview of Cosmos DB](./media/types-of-nosql-datastores.png)

**Figure 5-10**: Data models for NoSQL databases
 
Based upon specific data needs, a cloud-native-based microservice can  implement a relational, NoSQL datastore or both.

|  Consider a NoSQL datastore when: | Consider a relational database when: | 
| :-------- | :-------- |
| You have high volume workloads that require large scale | Your workload volume is consistent and requires medium to large scale |
| Your workloads don't require ACID guarantees |  ACID guarantees are required |
| Your data is dynamic and frequently changes | Your data is predictable and highly structured |
| Data can be expressed without relationships | Data is best expressed relationally |  
| You need fast writes and write safety isn't critical | Write safety is a requirement |  
| Data retrieval is simple and tends to be flat | You work with complex queries and reports|
| Your data requires a wide geographic distribution | Your users are more centralized | 
| Your application will be deployed to commodity hardware, such as with public clouds | Your application will be deployed to large, high-end hardware | 
|||

Next, we look at how data storage requirements for cloud-natve systems can be implemented in the Azure cloud.

## Relational Data in Azure

As we've seen in this book, the cloud changes how you design, deploy, and manage applications. As we move from a single shared database to an architecture where each service owns it own database, data management becomes complex. In this section, we'll explore how the Azure cloud can help streamline the way you store and manage your cloud-native data.

To start, you could provision an Azure virtual machine and install your database of choice for each service. While you'd have full control over the environment, you'd forgo many built-in features of the cloud platform. You'd also be responsible for managing the virtual machine and database for each service. This approach would quickly become time-consuming and expensive.

Instead, cloud-native applications favor fully managed Database as a Service (DBaaS) data services. They provide compelling built-in cloud features such as security, scalability, and monitoring. These data services can be configured across multiple Azure availability zones and regions to achieve high availability. The hosting, maintenance, and licensing are managed by the vendor, Microsoft. They all support just-in-time capacity and a pay-as-you-go model. Azure features different kinds of managed data service options, each with specific benefits.

We'll first look at relational DBaaS services available in Azure. You'll see that Microsoft's flagship SQL Server database is available along with several open-source options. Then, we'll talk about the NoSQL data services in Azure.

For cloud-native microservices that require relational data structures, Azure offers several managed relational database offerings, shown in Figure 5-12.

### Managed relational databases in Azure

Figure 5-12. Managed relational database available in Azure

The figure above presents four managed relational database offerings available in the Azure cloud. They're built upon a shared and proven DBaaS platform that provides many key Platforms as a Service (PaaS) capabilities - all at no additional cost:

Built-in high availability.

Predictable performance, using inclusive pay-as-you-go pricing.

Vertical Scale as needed within seconds.

Monitoring and alerting to quickly assess the impact of scaling.

Automatic backups and point-in-time-restore for up to 35 days.

Enterprise-grade security to protect sensitive data at-rest and in-motion.

These built-in features are especially important to organizations who provision large numbers of databases, but have limited resources to administer them.

Azure SQL Database
Azure SQL Database is a feature-rich, general-purpose relational database-as-a-service (DBaaS) based on the Microsoft SQL Server Database Engine. It's fully managed by Microsoft and is a high-performance, reliable, and secure cloud database. The service shares many of the features found in the on-premises version of SQL Server.

You can provision a SQL Database server and database in minutes. When demand grows from a handful of customers to millions, Azure SQL Database scales on-the-fly with minimal downtime. You can dynamically adjust resources such as CPU, memory, IO throughput, or the storage space consumed by your databases.

Figure 5-13 shows the deployment options for Azure SQL Database.

Azure SQL deployment options

Figure 5-13. Azure SQL deployment options

From the previous figure, we see three ways to deploy Azure SQL Database:

A Single Database represents a fully managed, isolated database with its own set of resources, managed by a SQL Database server. A single database is similar to a contained database in an on-premises SQL Server deployment.

An Elastic pool is a collection of SQL Databases that share a set of resources, such as CPU and memory - at a set price. Single databases can be moved in and out of an elastic pool as needed to optimize the price performance of the group.

A Managed Instance is a fully managed instance of the Microsoft SQL Server Database Engine and can contain a set of databases. This option provides near-100% compatibility with an on-premises SQL Server. This option supports larger databases, up to 35 TB and is placed in an Azure Virtual Network for better isolation.

The Azure SQL Database Server engine is a fully managed Platform as a Service (PaaS). It manages tasks such as upgrades, patching, backups, and monitoring without user involvement. The service runs the latest stable version of the SQL Server Database Engine and patched OS and guarantees 99.99% availability.

The active geo-replication feature lets you create readable secondary databases in the same or a different Azure data center. If a failure of the primary database should occur, a failover to a secondary database can be started. At that point, the other secondaries automatically link to the new primary. Up to four secondary replicas are supported in either the same or in different regions. These secondaries can be used for read-only access queries to distribute read operations for your services across multiple replicas.

Azure SQL Database includes built-in monitoring and intelligent tuning. These features can help you maximize performance and reduce operational costs. The Automatic Tuning feature provides continuous performance adjustments based on AI and machine learning. The service learns from your running workloads and can apply tuning recommendations. The longer an Azure SQL Database runs with automatic tuning enabled, the better it performs.

Azure SQL Database serverless (available for preview at time of the writing) is a compute tier for single databases that automatically scales based on workload demand. It bills only for the amount of compute used per second. The service is well suited for workloads with intermittent, unpredictable usage patterns, interspersed with periods of inactivity. The serverless compute tier also automatically pauses databases during inactive periods so that only storage charges are billed. It automatically resumes when activity returns.

Finally, there's the new Azure SQL Database Hyperscale pricing tier. It's powered by a highly scalable storage architecture and enables your database to grow as needed, eliminating the need to pre-provision storage resources. You can scale compute and storage resources independently, providing the flexibility to optimize performance for each workload. Azure SQL Database Hyperscale is optimized for OLTP processing and high throughput analytic workloads with storage up to 100 TB.  With read-intensive workloads, Hyperscale provides rapid scale-out by provisioning additional read replicas as needed for offloading read workloads.

Beyond the traditional Microsoft SQL Server stack, Azure also features managed versions of several popular open-source databases.

Open-source databases in Azure
Open-source relational databases have become a popular choice for cloud-native applications. Many enterprises favor them over commercial products, especially for cost savings. Many development teams favor them for their flexibility, community-backed development, and ecosystem of tools and extensions. Open-source databases can be deployed across multiple cloud providers, helping minimize the concern of "vendor lock-in."

Developers can easily self-host any open-source database on an Azure VM. While providing full control, this approach puts you on the hook for the management, monitoring, and maintenance of the database and VM.

Microsoft continues its commitment to keeping Azure an “open platform” by offering several popular open-source databases as fully managed DBaaS services.

You can create an open-source database server in one of three different pricing tiers: Basic, General Purpose, and Memory Optimized. The tiers are differentiated by the amount of processing cores, memory, and underlying storage technology. All resources are provisioned at the database server level. A server can have one to many databases.

Pricing tier Target workloads
Basic Workloads that require light compute and I/O performance. Examples include servers used for development or testing or small-scale infrequently used applications.

General Purpose Most business workloads that require balanced compute and memory with scalable I/O throughput. Examples include servers for hosting web and mobile apps and other enterprise applications.

Memory Optimized High-performance database workloads that require in-memory performance for faster transaction processing and higher concurrency. Examples include servers for processing real-time data and high-performance transactional or analytical apps.

After you create your server, you can dynamically change the virtual cores, hardware generation, pricing tier (except to and from Basic), amount of storage, and backup retention period. While changing the number of vCores requires approximately a minute of interruption, scaling storage and changing the backup retention period are true online operations. There's no downtime, and your application isn't affected.

### Azure Database for MySQL

MySQL is an open-source relational database and a pillar for applications built on the LAMP software stack. It's used by many large organizations, including Facebook, Twitter, and You Tube. The community edition is available for free, while the enterprise edition requires a license purchase. Originally created in 1995, the product was purchased by Sun Microsystems in 2008. Oracle acquired Sun and MySQL in 2010.

Azure Database for MySQL is a managed relational database service based on the open-source MySQL Server engine. It uses the MySQL Community edition. The Azure MySQL server is the administrative point for the service. It's the same MySQL server engine used for on-premises deployments. The engine can create a single database per server or multiple databases per server that share resources. You can continue to manage data using the same open-source tools without having to learn new skills or manage virtual machines.

### Azure Database for MariaDB

MariaDB Server is another popular open-source database server. It was created as a fork of MySQL when Oracle purchased Sun Microsystems, who owned MySQL. The intent was to ensure that MariaDB remained open-source.

As MariaDB is a fork of MySQL, the data and table definitions are compatible, and the client protocols, structures, and APIs, are close-knit.

MariaDB has a strong community and is used by many large enterprises. While Oracle continues to maintain, enhance, and support MySQL, the MariaDB foundation manages MariaDB, allowing public contributions to the product and documentation.

Azure Database for MariaDB is a fully managed relational database as a service in the Azure cloud. The service is based on the MariaDB community edition server engine. It can handle mission-critical workloads with predictable performance and dynamic scalability.

### Azure Database for PostgreSQL

PostgreSQL is a third open-source relational database with over 30 years of active development. It's a general purpose and object-relational database management system. The product has “liberal” licensing and is free to use, modify, and distribute in any form. Many large enterprises including Apple, Red Hat, and Fujitsu have built products using PostgreSQL.

Azure Database for PostgreSQL is a fully managed relational database service, based on the open-source Postgres database engine. The service can manage mission-critical workloads with predictable performance, security, high availability, and dynamic scalability. The service supports many development platforms, including C++, Java, Python, Node, C#, and PHP. It enables migration of PostgreSQL databases through a command-line interface or the Azure Data Migration Service.

The service includes built-in intelligence features that study your unique database patterns. It then provides customized recommendations and insights to help you maximize the performance of your PostgreSQL database. Advanced Threat Protection monitors your database around the clock, detects potential malicious activities, and alerts you upon detection so you can intervene right away.

Azure Database for PostgreSQL is available as two deployment options: Single Server and Hyperscale (Citus), available for preview at time of the writing of this book:

The Single Server deployment option is a central administrative point for multiple databases. It's the same PostgreSQL server engine available for on-premises deployments. With it, you can create a single database per server to consume all resources or create multiple databases to share resources. The pricing is structured per-server based upon cores and storage.

The Hyperscale (Citus) option is powered by Citus Data technology. It enables high performance by horizontally scaling a single database across hundreds of nodes to deliver blazingly fast performance and scale. This option allows the engine to fit more data in memory, parallelize queries across hundreds of nodes, and index data faster. The Hyperscale feature is compatible with the latest innovations, versions, and tools for PostgreSQL enabling you to leverage your existing PostgreSQL expertise.

## NoSQL data in Azure

In a prior section, we said that the impact of NoSQL data technologies for distributed cloud-native systems can't be overstated

Cosmos DB is a fully managed, globally distributed NoSQL database service in the Azure cloud.  If your application requires fast response time anywhere in the world, high availability, or elastic scalability for throughput and storage, Cosmos DB is a great choice. Figure 5-14 shows Cosmos DB.

![Overview of Cosmos DB](./media/cosmos-db-overview.png)

**Figure 5-14**: Overview of Cosmos DB

Figure 5-14 presents many of the built-in cloud-native capabilities available in Cosmos DB. In this section, we’ll take a closer look at them.

### Global Support

Cloud-native applications often have a global audience and require global scale.

You can globally distribute Cosmos databases across regions and around the world, placing data close to your users, improving response time, and reducing latency. You can add or remove a database from a region without pausing or redeploying your services. In the background, Cosmos DB transparently replicates the data to all of the configured regions.

Cosmos DB supports [active/active](https://kemptechnologies.com/white-papers/unfog-confusion-active-passive-activeactive-load-balancing/) clustering at the global level, enabling you to configure any or all your database regions to support both writes and reads.

The [Multi-Master](https://docs.microsoft.com/azure/cosmos-db/how-to-multi-master) protocol feature in Cosmos DB enables the following functionality:

- Unlimited elastic write and read scalability.

- 99.999% read and write availability all around the world.

- Guaranteed reads and writes served in less than 10 milliseconds at the 99th percentile.

Internally, Cosmos DB manages data replication between regions with consistency level guarantees and financially backed service level agreements.

With the Cosmos DB [Multi-Homing APIs](https://docs.microsoft.com/azure/cosmos-db/distribute-data-globally), your service is automatically aware of the nearest Azure region and sends requests to it. The nearest region is identified by Cosmos DB without any configuration changes. Should a region become unavailable, the Multi-Homing feature will automatically route requests to the next nearest available region.

### Multi-Model Support

Development teams often *replatform* legacy applications that consume different kinds of open-source, NoSQL data stores. These include documents, key-value pairs, wide-column, and graph data representations.

Cosmos DB is a *multi-model* data platform that enables you to preserve and interact directly with many popular NoSQL products. Figure 5-15 presents the supported NoSQL *"dialects,"* or [compatibility APIs](https://www.wikiwand.com/en/Cosmos_DB).

![Cosmos DB providers](./media/cosmos-db-providers.png)

**Figure 5-15**: Cosmos DB providers

 Internally, Cosmos stores the data from these sources in a simple [struct](https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/using-structs) format made up of primitive data types. For each request, the database engine translates the primitive data into the model representation you've selected. 

 Development teams can migrate existing Mongo, Gremlin, or Cassandra databases into Cosmos DB with minimal changes to data or code. For new apps, development teams can choose among open-source options or the built-in SQL API model.

Note in Figure 5-15 how Cosmos DB supports [Azure Table Storage](https://azure.microsoft.com/services/storage/tables/). Both Cosmos DB and [Azure Table Storage](https://docs.microsoft.com/azure/cosmos-db/table-storage-overview) share the same underlying table model and expose many of the same table operations. However, the [Cosmos DB Table API](https://docs.microsoft.com/azure/cosmos-db/table-introduction) provides many premium enhancements not available in the Azure Storage API. These features are contrasted in Figure 5-16.

![Azure Table API](media/azure-table-api.png)

**Figure 5-16**: Azure Table API Providers

Applications written for Azure Table storage can migrate to Azure Cosmos DB by using the Table API. No code changes are required.

### Consistency Models

Earlier in the *Relational vs. NoSQL* section, we discussed the subject of *data consistency*. Data consistency refers to the integrity of your data. Cloud-native services with distributed data rely on replication and must make a fundamental tradeoff between read consistency, availability, and latency.

Most distributed databases allow developers to choose between two consistency models: [strong consistency](https://en.wikipedia.org/wiki/Strong_consistency) and [eventual consistency](https://en.wikipedia.org/wiki/Eventual_consistency). *Strong consistency* is the gold standard of data programmability. It guarantees that a query will always return the most current data - even if the system must incur latency waiting for an update to replicate across all database copies. While a database configured for *eventual consistency* will return data immediately, even if that data isn't the most current copy. The latter option enables higher availability, greater scale, and increased performance.

Azure Cosmos DB offers [five well-defined consistency models](https://docs.microsoft.com/azure/cosmos-db/consistency-levels) shown in Figure 5-17. These options enable you to make precise choices and granular tradeoffs with respect to consistency, availability, and the performance for your data. These models are well-defined, intuitive, and backed by the service level agreements (SLAs). In the article [Getting Behind the 9-Ball: Cosmos DB Consistency Levels Explained](https://blog.jeremylikness.com/blog/2018-03-23_getting-behind-the-9ball-cosmosdb-consistency-levels/), Microsoft Cloud Developer Advocate Jeremy Likeness provides an excellent explanation of the five models.

![Cosmos DB consistency levels](./media/cosmos-db-consistency-levels.png)

**Figure 5-17**: Cosmos DB Consistency Levels

### Partitioning

Azure Cosmos DB uses automatic [partitioning](https://docs.microsoft.com/azure/cosmos-db/partitioning-overview) to scale the database to meet the performance needs of your cloud-native service. 

You manage data in Cosmos DB data by creating [databases, containers, and items](https://docs.microsoft.com/azure/cosmos-db/databases-containers-items), shown in Figure 5-18.

![Cosmos DB objects](./media/cosmos-db-entities.png)

**Figure 5-18**: Hierarchy of Cosmos DB entities

You start by creating a database inside a Cosmos DB database account. That database becomes the unit of management for a set of containers. A container is a schema-agnostic grouping of items expressed as a collection, table, or graph. The items are the data that you add to the container. They're represented as documents, rows, nodes, or edges. All items added to a container are automatically indexed without requiring explicit index or schema management.

To partition the container, items are divided into distinct subsets called [logical partitions](https://docs.microsoft.com/azure/cosmos-db/partition-data). Logical partitions are populated based on the value of a partition key that is associated with each item in a container. Figure 5-19 shows two containers each with a logical partition based on a partition key value.

![Cosmos DB partitioning mechanics](./media/cosmos-db-partitioning.png)

**Figure 5-19**: Cosmos DB partitioning mechanics

In Figure 5-19, each item includes a partition key of either ‘city’ or ‘airport’. The key determines the item’s logical partition. Items with a city code are assigned to the container on the left, and items with an airport code, to the container on the right. Combining the partition key value with the ID value creates an item's index, which uniquely identifies the item.

Internally, Cosmos DB automatically manages the placement of [logical partitions](https://docs.microsoft.com/azure/cosmos-db/partition-data) on [physical partitions](https://docs.microsoft.com/azure/cosmos-db/partition-data) to satisfy the scalability and performance needs of the container. As application throughput and storage requirements  increase, Azure Cosmos DB redistributes logical partitions across a greater number of servers. Redistribution operations are managed by Cosmos DB and invoked without interruption or downtime.

## Data migration to the cloud

One of the more time consuming tasks is migrating data from one data platform to another. The [Azure Data Migration Service](https://azure.microsoft.com/services/database-migration/) can help expedite such efforts. It can migrate data from several external database sources into Azure Data platforms with minimal downtime. Target platforms include the following services:

- Azure Sql Database
- Azure Database for MySQL
- Azure Database for MariaDB
- Azure Database for PostgreSQL
- CosmosDB
  
The service provides recommendations to guide you through the changes required to execute a migration, both small or large.

>[!div class="step-by-step"]
>[Previous](distributed-data.md)
>[Next](azure-data-storage.md)
