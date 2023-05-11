---
title: Orleans overview
description: An introduction to .NET Orleans.
ms.date: 05/10/2022
---

# Microsoft Orleans

Orleans is a cross-platform framework for building robust, scalable distributed applications. Distributed applications are defined as apps that span more than a single process, often beyond hardware boundaries using peer-to-peer communication. Orleans scales from a single on-premises server to hundreds to thousands of distributed, highly available applications in the cloud. Orleans extends familiar concepts and C# idioms to multi-server environments. Orleans is designed to scale elastically. When a host joins a cluster, it can accept new activations. When a host leaves the cluster, either because of scale down or a machine failure, the previous activations on that host will be reactivated on the remaining hosts as needed. An Orleans cluster can be scaled down to a single host. The same properties that enable elastic scalability also enable fault tolerance. The cluster automatically detects and quickly recovers from failures.

One of the primary design objectives of Orleans is to simplify the complexities of distributed application development by providing a common set of patterns and APIs. Developers familiar with single-server application development can easily transition to building resilient, scalable cloud-native services and other distributed applications using Orleans. For this reason, Orleans has often been referred to as "Distributed .NET" and is the framework of choice when building cloud-native apps. Orleans runs anywhere that .NET is supported. This includes hosting on Linux, Windows, and macOS. Orleans apps can be deployed to Kubernetes, virtual machines, and PaaS services such as [Azure App Service](/azure/app-service/overview) and [Azure Container Apps](/azure/container-apps/overview).

## The "Actor Model"

Orleans is based on the "actor model". The actor model originated in the early 1970s and is now a core component of Orleans. The actor model is a programming model in which each _actor_ is a lightweight, concurrent, immutable object that encapsulates a piece of state and corresponding behavior. Actors communicate exclusively with each other using asynchronous messages. Orleans notably invented the _Virtual Actor_ abstraction, wherein actors exist perpetually.

> [!NOTE]
> Actors are purely logical entities that _always_ exist, virtually. An actor cannot be explicitly created nor destroyed, and its virtual existence is unaffected by the failure of a server that executes it. Since actors always exist, they are always addressable.

This is a novel approach to building a new generation of distributed applications for the Cloud era. The Orleans programming model tames the complexity inherent to highly parallel distributed applications _without_ restricting capabilities or imposing constraints on the developer.

For more information, see [Orleans: Virtual Actors](https://www.microsoft.com/research/project/orleans-virtual-actors) via Microsoft Research. A virtual actor is represented as an Orleans grain.

## What are Grains?

The grain is one of several Orleans primitives. In terms of the actor model, a grain is a virtual actor. The fundamental building block in any Orleans application is a *grain*. Grains are entities comprising user-defined identity, behavior, and state. Consider the following visual representation of a grain:

:::image type="content" source="media/grain-formulation.svg" lightbox="media/grain-formulation.svg" alt-text="A grain is composed of a stable identity, behavior, and state.":::

Grain identities are user-defined keys that make grains always available for invocation. Grains can be invoked by other grains or by any number of external clients. Each grain is an instance of a class that implements one or more of the following interfaces:

- <xref:Orleans.IGrainWithGuidKey>: Marker interface for grains with `Guid` keys.
- <xref:Orleans.IGrainWithIntegerKey>: Marker interface for grains with `Int64` keys.
- <xref:Orleans.IGrainWithStringKey>: Marker interface for grains with `string` keys.
- <xref:Orleans.IGrainWithGuidCompoundKey>: Marker interface for grains with compound keys.
- <xref:Orleans.IGrainWithIntegerCompoundKey>: Marker interface for grains with compound keys.

Grains can have volatile or persistent state data that can be stored in any storage system. As such, grains implicitly partition application states, enabling automatic scalability and simplifying recovery from failures. The grain state is kept in memory while the grain is active, leading to lower latency and less load on data stores.

:::image type="content" source="media/grain-lifecycle.svg" lightbox="media/grain-lifecycle.svg" alt-text="The managed lifecycle of an Orleans grain.":::

Instantiation of grains is automatically performed on demand by the Orleans runtime. Grains that aren't used for a while are automatically removed from memory to free up resources. This is possible because of their stable identity, which allows invoking grains whether they're already loaded into memory or not. This also allows for transparent recovery from failure because the caller doesn't need to know on which server a grain is instantiated at any point in time. Grains have a managed lifecycle, with the Orleans runtime responsible for activating/deactivating, and placing/locating grains as needed. This allows the developer to write code as if all grains are always in-memory.

## What are Silos?

A silo is another example of an Orleans primitive. A silo hosts one or more grains. The Orleans runtime is what implements the programming model for applications.

Typically, a group of silos runs as a cluster for scalability and fault tolerance. When run as a cluster, silos coordinate with each other to distribute work and detect and recover from failures. The runtime enables grains hosted in the cluster to communicate with each other as if they are within a single process. To help visualize the relationship between clusters, silos and grains, consider the following diagram:

:::image type="content" source="media/cluster-silo-grain-relationship.svg" lightbox="media/cluster-silo-grain-relationship.svg" alt-text="A cluster has one or more silos, and a silo has one or more grains.":::

The preceding diagram shows the relationship between clusters, silos, and grains. You can have any number of clusters, each cluster has one or more silos, and each silo has one or more grains.

In addition to the core programming model, silos provide grains with a set of runtime services such as timers, reminders (persistent timers), persistence, transactions, streams, and more. For more information, see [What can I do with Orleans?](#what-can-i-do-with-orleans)

Web apps and other external clients call grains in the cluster using the client library, which automatically manages network communication. Clients can also be co-hosted in the same process with silos for simplicity.

## What can I do with Orleans?

Orleans is a framework for building cloud-native apps and should be considered whenever you're building .NET apps that would eventually need to scale. There are seemingly endless ways to use Orleans, but the following are some of the most common ways; Gaming, Banking, Chat apps, GPS tracking, Stock trading, Shopping carts, Voting apps, and more. Orleans is used by Microsoft in Azure, Xbox, Skype, Halo, PlayFab, Gears of War, and many other internal services. Orleans has many features that make it easy to use for a variety of applications.

### Persistence

Orleans provides a simple persistence model that ensures the state is available before processing a request, and that its consistency is maintained. Grains can have multiple named persistent data objects. For example, there might be one called "profile" for a user's profile and one called "inventory" for their inventory. This state can be stored in any storage system.

While a grain is running, the state is kept in memory so that read requests can be served without accessing storage. When the grain updates its state, calling <xref:Orleans.Core.IStorage.WriteStateAsync%2A?displayProperty=nameWithType> ensures that the backing store is updated for durability and consistency.

For more information, see the [Grain persistence](grains/grain-persistence/index.md).

### Timers and reminders

Reminders are a durable scheduling mechanism for grains. They can be used to ensure that some action is completed at a future point even if the grain isn't currently activated at that time. Timers are the non-durable counterpart to reminders and can be used for high-frequency events, which don't require reliability.

For more information, see [Timers and reminders](grains/timers-and-reminders.md).

### Flexible grain placement

When a grain is activated in Orleans, the runtime decides which server (silo) to activate that grain on. This is called grain placement.

The placement process in Orleans is fully configurable. Developers can choose from a set of out-of-the-box placement policies such as random, prefer-local, and load-based, or custom logic can be configured. This allows for full flexibility in deciding where grains are created. For example, grains can be placed on a server close to resources that they need to operate against or other grains with which they communicate.

For more information, see [Grain placement](grains/grain-placement.md).

### Grain versioning and heterogeneous clusters

Upgrading production systems in a manner that safely accounts for changes can be challenging, particularly in stateful systems. To account for this, grain interfaces in Orleans can be versioned.

The cluster maintains a mapping of which grain implementations are available on which silos in the cluster and the versions of those implementations. This version of the information is used by the runtime in conjunction with placement strategies to make placement decisions when routing calls to grains. In addition, to safely update a versioned grain, this also enables heterogeneous clusters, where different silos have different sets of grain implementations available.

For more information, see [Grain Versioning](grains/grain-versioning/grain-versioning.md).

### Stateless workers

Stateless workers are specially marked grains that don't have any associated state and can be activated on multiple silos simultaneously. This enables increased parallelism for stateless functions.

For more information, see [stateless worker grains](grains/stateless-worker-grains.md).

### Grain call filters

A [grain call filter](grains/interceptors.md) is logic that's common to many grains. Orleans supports filters for both incoming and outgoing calls. Filters for authorization, logging and telemetry, and error handling are all considered common.

### Request context

Metadata and other information can be passed with a series of requests using the [request context](grains/request-context.md). Request context can be used for holding distributed tracing information or any other user-defined values.

### Distributed ACID transactions

In addition to the simple persistence model described above, grains can have a *transactional state*. Multiple grains can participate in [ACID](/windows/win32/cossdk/acid-properties) transactions together regardless of where their state is ultimately stored. Transactions in Orleans are distributed and decentralized (there is no central transaction manager or transaction coordinator) and have [serializable isolation](https://en.wikipedia.org/wiki/Isolation_(database_systems)#Isolation_levels).

For more information on transactions, see [Transactions](grains/transactions.md).

### Streams

Streams help developers to process a series of data items in near-real-time. Orleans streams are *managed*; streams don't need to be created or registered before a grain or client publishes, or subscribes to a stream. This allows for greater decoupling of stream producers and consumers from each other and the infrastructure.

Stream processing is reliable: grains can store checkpoints (cursors) and reset to a stored checkpoint during activation or at any subsequent time. Streams support batch delivery of messages to consumers to improve efficiency and recovery performance.

Streams are backed by queueing services such as Azure Event Hubs, Amazon Kinesis, and others.

An arbitrary number of streams can be multiplexed onto a smaller number of queues and the responsibility for processing these queues is balanced evenly across the cluster.

## Introduction to Orleans video

If you're interested in a video introduction to Orleans, check out the following video:

<!-- markdownlint-disable-next-line MD034 -->
> [!VIDEO https://aka.ms/docs/player?show=reactor&ep=an-introduction-to-orleans]

## Next steps

> [!div class="nextstepaction"]
> [Tutorial: Create a minimal Orleans application](tutorials-and-samples/tutorial-1.md)
