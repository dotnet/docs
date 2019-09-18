---
title: Appendix - gRPC for WCF Developers
description: Discussion of distributed transactions and their implementation in modern microservices architectures
author: markrendle
ms.date: 09/02/2019
---

# Appendix A - Transactions

WCF supported distributed transactions, allowing atomic operations to be performed across multiple services. This functionality was based on the [Microsoft Distributed Transaction Coordinator](https://docs.microsoft.com/previous-versions/windows/desktop/ms684146(v=vs.85)?redirectedfrom=MSDN).

In the modern microservices landscape, this type of automated distributed transaction processing is not possible. There are too many different technologies at play, including relational databases, NoSQL data stores, and messaging systems, not to mention the mix of operating systems, programming languages and frameworks that may be used in a single environment.

The WCF distributed transaction is an implementation of what is known as a [2-phase commit (2PC)](https://en.wikipedia.org/wiki/Two-phase_commit_protocol). It is possible to implement 2PC transactions manually by coordinating messages across services, creating open transactions within each service and sending "commit" or "rollback" messages depending upon success or failure. However, the complexity involved in managing 2PC can increase exponentially as systems evolve, and open transactions hold database locks which can negatively impact performance or, worse, cause cross-service deadlocks.

If at all possible, it is best to avoid distributed transactions altogether. If two items of data are so linked as to require atomic updates, consider handling them both with the same service, and applying those atomic changes using a single request or message to that service.

If that is not possible, then one alternative is to use the Saga pattern. In a saga, updates are processing sequentially; as each update succeeds the next one is triggered. These triggers can be propagated from service to service, or managed by a Saga coordinator or "orchestrator". If an update fails at any point during the process, the services that have already completed their updates apply specific logic to reverse them.

Another option is to use Domain Driven Design (DDD) and Command/Query Responsibility Segregation (CQRS), as described in the [.NET Microservices e-book](https://docs.microsoft.com/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/). In particular, using domain events or [event sourcing](https://martinfowler.com/eaaDev/EventSourcing.html) can help to ensure that updates are consistently&mdash;if not immediately&mdash;applied.

>[!div class="step-by-step"]
<!-->[Next](introduction.md)-->
