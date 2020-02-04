---
title: Appendix - gRPC for WCF Developers
description: Discussion of distributed transactions and their implementation in modern microservices architectures.
ms.date: 09/02/2019
---

# Appendix A - Transactions

Windows Communication Foundation (WCF) supports distributed transactions, allowing you to perform atomic operations across multiple services. This functionality is based on the [Microsoft Distributed Transaction Coordinator](https://docs.microsoft.com/previous-versions/windows/desktop/ms684146(v=vs.85)).

In the newer microservices landscape, this type of automated distributed transaction processing isn't possible. There are too many different technologies involved, including relational databases, NoSQL data stores, and messaging systems. There might also be a mix of operating systems, programming languages, and frameworks in use in a single environment.

WCF distributed transaction is an implementation of what is known as a [two-phase commit (2PC)](https://en.wikipedia.org/wiki/Two-phase_commit_protocol). You can implement 2PC transactions manually by coordinating messages across services, creating open transactions within each service, and sending commit or rollback messages, depending upon success or failure. However, the complexity involved in managing 2PC can increase exponentially as systems evolve. Open transactions hold database locks that can negatively affect performance, or, worse, cause cross-service deadlocks.

If possible, it's best to avoid distributed transactions altogether. If two items of data are so linked as to require atomic updates, consider handling them both with the same service. Apply those atomic changes by using a single request or message to that service.

If that isn't possible, then one alternative is to use the [Saga pattern](https://microservices.io/patterns/data/saga.html). In a saga, updates are processed sequentially; as each update succeeds, the next one is triggered. These triggers can be propagated from service to service, or managed by a saga coordinator or orchestrator. If an update fails at any point during the process, the services that have already completed their updates apply specific logic to reverse them.

Another option is to use Domain Driven Design (DDD) and Command/Query Responsibility Segregation (CQRS), as described in the [.NET Microservices e-book](https://docs.microsoft.com/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/). In particular, using domain events or [event sourcing](https://martinfowler.com/eaaDev/EventSourcing.html) can help to ensure that updates are consistently, if not immediately, applied.

>[!div class="step-by-step"]
>[Previous](application-performance-management.md)
