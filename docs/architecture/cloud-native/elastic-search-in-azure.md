---
title: Elasticsearch in cloud-native applications
description: Learn about adding Elastic Search capabilities to cloud-native applications.
author: robvet
ms.date: 04/06/2022
ms.topic: article
---

# Elasticsearch in a cloud-native app

[!INCLUDE [download-alert](includes/download-alert.md)]

Elasticsearch is a distributed search and analytics system that enables complex search capabilities across diverse types of data. It's open source and widely popular. Consider how the following companies integrate Elasticsearch into their application:

- [Wikipedia](https://blog.wikimedia.org/2014/01/06/wikimedia-moving-to-elasticsearch/) for full-text and incremental (search as you type) searching.
- [GitHub](https://www.elastic.co/customers/github) to index and expose over 8 million code repositories.
- [Docker](https://www.elastic.co/customers/docker) for making its container library discoverable.

Elasticsearch is built on top of the [Apache Lucene](https://lucene.apache.org/core/) full-text search engine. Lucene provides high-performance document indexing and querying. It indexes data with an inverted indexing scheme – instead of mapping pages to keywords, it maps keywords to pages just like a glossary at the end of a book. Lucene has powerful query syntax capabilities and can query data by:

- Term (a full word)
- Prefix (starts-with word)
- Wildcard (using "\*" or "?" filters)
- Phrase (a sequence of text in a document)
- Boolean value (complex searches combining queries)

While Lucene provides low-level plumbing for searching, Elasticsearch provides the server that sits on top of Lucene. Elasticsearch adds higher-level functionality to simplify working Lucene, including a RESTful API to access Lucene's indexing and searching functionality. It also provides a distributed infrastructure capable of massive scalability, fault tolerance, and high availability.

For larger cloud-native applications with complex search requirements, Elasticsearch is available as managed service in Azure. The Microsoft Azure Marketplace features preconfigured templates which developers can use to deploy an Elasticsearch cluster on Azure.

From the Microsoft Azure Marketplace, developers can use preconfigured templates built to quickly deploy an Elasticsearch cluster on Azure. Using the Azure-managed offering, you can deploy up to 50 data nodes, 20 coordinating nodes, and three dedicated master nodes.

## Summary

This chapter presented a detailed look at data in cloud-native systems. We started by contrasting data storage in monolithic applications with data storage patterns in cloud-native systems. We looked at data patterns implemented in cloud-native systems, including cross-service queries, distributed transactions, and patterns to deal with high-volume systems. We contrasted SQL with NoSQL data. We looked at data storage options available in Azure that include both Microsoft-centric and open-source options. Finally, we discussed caching and Elasticsearch in a cloud-native application.

### References

- [Command and Query Responsibility Segregation (CQRS) pattern](/azure/architecture/patterns/cqrs)

- [Event Sourcing pattern](/azure/architecture/patterns/event-sourcing)

- [Why isn't RDBMS Partition Tolerant in CAP Theorem and why is it Available?](https://stackoverflow.com/questions/36404765/why-isnt-rdbms-partition-tolerant-in-cap-theorem-and-why-is-it-available)

- [Materialized View](/azure/architecture/patterns/materialized-view)

- All you really need to know about open source databases (IBM blog)

- [Compensating Transaction pattern](/azure/architecture/patterns/compensating-transaction)

- [Saga Pattern](https://microservices.io/patterns/data/saga.html)

- [Saga Patterns | How to implement business transactions using microservices](https://blog.couchbase.com/saga-pattern-implement-business-transactions-using-microservices-part/)

- [Compensating Transaction pattern](/azure/architecture/patterns/compensating-transaction)

- [Getting Behind the 9-Ball: Cosmos DB Consistency Levels Explained](https://blog.jeremylikness.com/blog/2018-03-23_getting-behind-the-9ball-cosmosdb-consistency-levels/)

- [On RDBMS, NoSQL and NewSQL databases. Interview with John Ryan](http://www.odbms.org/blog/2018/03/on-rdbms-nosql-and-newsql-databases-interview-with-john-ryan/)

- [SQL vs NoSQL vs NewSQL: The Full Comparison](https://www.xenonstack.com/blog/sql-vs-nosql-vs-newsql/)

- [DASH: Four Properties of Kubernetes-Native Databases](https://thenewstack.io/dash-four-properties-of-kubernetes-native-databases/)

- [CockroachDB](https://www.cockroachlabs.com/)

- [TiDB](https://pingcap.com/en/)

- [YugabyteDB](https://www.yugabyte.com/)

- [Vitess](https://vitess.io/)

- [Elasticsearch: The Definitive Guide](https://shop.oreilly.com/product/0636920028505.do)

- [Introduction to Apache Lucene](https://www.baeldung.com/lucene)

>[!div class="step-by-step"]
>[Previous](azure-caching.md)
>[Next](resiliency.md) <!-- Next Chapter -->
