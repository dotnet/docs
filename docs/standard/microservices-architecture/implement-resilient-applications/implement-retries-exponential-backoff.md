---
title: Implement retries with exponential backoff
description: Learn how to implement retries with exponential backoff.
ms.date: 10/16/2018
---
# Implement retries with exponential backoff

[*Retries with exponential backoff*](/azure/architecture/patterns/retry) is a technique that retries an operation, with an exponentially increasing wait time, up to a maximum retry count has been reached (the [exponential backoff](https://en.wikipedia.org/wiki/Exponential_backoff)). This technique embraces the fact that cloud resources might intermittently be unavailable for more than a few seconds for any reason. For example, an orchestrator might be moving a container to another node in a cluster for load balancing. During that time, some requests might fail. Another example could be a database like SQL Azure, where a database can be moved to another server for load balancing, causing the database to be unavailable for a few seconds.

There are many approaches to implement retries logic with exponential backoff.

>[!div class="step-by-step"]
>[Previous](partial-failure-strategies.md)
>[Next](implement-resilient-entity-framework-core-sql-connections.md)
