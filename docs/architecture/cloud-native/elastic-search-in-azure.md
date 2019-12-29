---
title: Elasticsearch in cloud-native applications
description: Learn about adding Elastic Search capabilities to cloud-native applications.
author: robvet
ms.date: 12/28/2019
---
# Elasticsearch in a cloud-native app

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

Elasticsearch is a distributed, open source search, and analytics engine that supports searching across all types of data. It's built on top of the open source Apache Lucene search engine. The engine is known for the following characteristics:

- A simple RESTful API interface.
- A distributed architecture which can scale to thousands of nodes
- High availability with multiple copies of data.
- Index data without an explicit schema.

THe engine enables you to rank your search results on a variety of factors, including the frequency of a serach term, recency, and popularity.   
  
Elasticsearch detects failures to keep your cluster (and your data) safe and available. With cross-cluster replication, a secondary cluster can spring into action as a hot backup. Elasticsearch operates in a distributed environment designed from the ground up for perpetual peace of mind.

 is known for simple REST APIs, a distributed architecture, speed, and scalability. Elasticsearch is the central component of the Elastic Stack, a set of open source tools for data ingestion, enrichment, storage, analysis, and visualization.

Elastic Stack lets you reliably and securely take data from any source, in any format, and search, analyze, and visualize it in real time. Elastic is the company behind the Elastic

## Summary

This chapter presented a detailed look at data in cloud-native systems. We started by contrasting data storage in monolithic applications with that in cloud-native systems. We looked at data patterns implemented in cloud-native systems, including cross-service queries, distributed transactions, and patterns to deal with high-volume systems. We contrasted SQL with NoSQL data stores. We looked at data storage options available in Azure that include both Microsoft-centric and open-source options. Finally, we discussed caching in a cloud-native application.

### References

- [Command and Query Responsibility Segregation (CQRS) pattern](https://docs.microsoft.com/azure/architecture/patterns/cqrs)

- [Event Sourcing pattern](https://docs.microsoft.com/azure/architecture/patterns/event-sourcing)

- [RDBMSs vs. NoSQL Databases: Overview](https://maxivak.com/rdbms-vs-nosql-databases/)

- [Why isn't RDBMS Partition Tolerant in CAP Theorem and why is it Available?](https://stackoverflow.com/questions/36404765/why-isnt-rdbms-partition-tolerant-in-cap-theorem-and-why-is-it-available)

- [Materialized View](https://docs.microsoft.com/azure/architecture/patterns/materialized-view)

- [All you really need to know about open source databases](https://www.ibm.com/blogs/systems/all-you-really-need-to-know-about-open-source-databases/)

- [Compensating Transaction pattern](https://docs.microsoft.com/azure/architecture/patterns/compensating-transaction)

- [Saga Pattern](https://microservices.io/patterns/data/saga.html)

- [Saga Patterns | How to implement business transactions using microservices](https://blog.couchbase.com/saga-pattern-implement-business-transactions-using-microservices-part/)

- [Compensating Transaction pattern](https://docs.microsoft.com/azure/architecture/patterns/compensating-transaction)

- [Getting Behind the 9-Ball: Cosmos DB Consistency Levels Explained](https://blog.jeremylikness.com/blog/2018-03-23_getting-behind-the-9ball-cosmosdb-consistency-levels/)

- [Exploring the different types of NoSQL Databases Part II](https://www.3pillarglobal.com/insights/exploring-the-different-types-of-nosql-databases)

- [On RDBMS, NoSQL and NewSQL databases. Interview with John Ryan](http://www.odbms.org/blog/2018/03/on-rdbms-nosql-and-newsql-databases-interview-with-john-ryan/)
  
- [SQL vs NoSQL vs NewSQL: The Full Comparison](https://www.xenonstack.com/blog/sql-vs-nosql-vs-newsql/)

- [DASH: Four Properties of Kubernetes-Native Databases](https://thenewstack.io/dash-four-properties-of-kubernetes-native-databases/)

- [CockroachDB](https://www.cockroachlabs.com/)

- [TiDB](https://pingcap.com/en/)

- [YugabyteDB](https://www.yugabyte.com/)

- [Vitess](https://vitess.io/)

>[!div class="step-by-step"]
>[Previous](azure-caching.md)
>[Next](resiliency.md) <!-- Next Chapter -->
