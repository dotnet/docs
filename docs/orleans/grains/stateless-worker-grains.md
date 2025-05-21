---
title: Stateless worker grains
description: Learn how to use stateless worker grains in .NET Orleans.
ms.date: 07/03/2024
ms.topic: article
---

# Stateless worker grains

By default, the Orleans runtime creates no more than one activation of a grain within the cluster. This is the most intuitive expression of the Virtual Actor model with each grain corresponding to an entity with a unique type/identity. However, there are also cases when an application needs to perform functional stateless operations that are not tied to a particular entity in the system. For example, if the client sends requests with compressed payloads that need to be decompressed before they could be routed to the target grain for processing, such decompression/routing logic is not tied to a specific entity in the application, and can easily scale-out.

When the <xref:Orleans.Concurrency.StatelessWorkerAttribute> is applied to a grain class, it indicates to the Orleans runtime that grains of that class should be treated as stateless worker grains. Stateless worker grains have the following properties that make their execution very different from that of normal grain classes.

1. The Orleans runtime can and will create multiple activations of a stateless worker grain on different silos of the cluster.
1. Stateless worker grains execute requests locally as long as the silo is compatible, and therefore don't incur networking or serialization costs. If the local silo is not compatible, requests are forwarded to a compatible silo.
1. The Orleans Runtime automatically creates additional activations of a stateless worker grain if the already existing ones are busy.
The maximum number of activations of a stateless worker grain the runtime creates per silo is limited by default by the number of CPU cores on the machine, unless specified explicitly by the optional `maxLocalWorkers` argument.
1. Because of 2 and 3, stateless worker grain activations are not individually addressable. Two subsequent requests to a stateless worker grain may be processed by different activations of it.

Stateless worker grains provide a straightforward way of creating an auto-managed pool of grain activations that automatically scales up and down based on the actual load. The runtime always scans for available stateless worker grain activations in the same order. Because of that, it always dispatches requests to the first idle local activation it can find and only gets to the last one if all previous activations are busy. If all activations are busy and the activation limit hasn't been reached, it creates one more activation at the end of the list and dispatches the request to it. That means that when the rate of requests to a stateless worker grain increases, and existing activations are all currently busy, the runtime expands the pool of its activations up to the limit. Conversely, when the load drops, and it can be handled by a smaller number of activations of the stateless worker grain, the activations at the tail of the list will not be getting requests dispatched to them. They will become idle, and eventually deactivated by the standard activation collection process. Hence, the pool of activations will eventually shrink to match the load.

The following example defines a stateless worker grain class `MyStatelessWorkerGrain` with the default maximum activation number limit.

```csharp
[StatelessWorker]
public class MyStatelessWorkerGrain : Grain, IMyStatelessWorkerGrain
{
    // ...
}
```

Making a call to a stateless worker grain is the same as to any other grain.
The only difference is that in most cases a single grain ID is used, for example `0` or <xref:System.Guid.Empty?displayProperty=nameWithType>.
Multiple grain IDs can be used when having multiple stateless worker grain pools, one per ID is desirable.

```csharp
var worker = GrainFactory.GetGrain<IMyStatelessWorkerGrain>(0);
await worker.Process(args);
```

This one defines a stateless worker grain class with no more than one-grain activation per silo.

```csharp
[StatelessWorker(1)] // max 1 activation per silo
public class MyLonelyWorkerGrain : ILonelyWorkerGrain
{
    //...
}
```

Note that <xref:Orleans.Concurrency.StatelessWorkerAttribute> does not change the reentrancy of the target grain class. Just like any other grains, stateless worker grains are non-reentrant by default. They can be explicitly made reentrant by adding a <xref:Orleans.Concurrency.ReentrantAttribute> to the grain class.

## State

The "stateless" part of "stateless worker" does not mean that a stateless worker cannot have a state and is limited only to executing functional operations. Like any other grain, a stateless worker grain can load and keep in memory any state it needs. It's just because multiple activations of a stateless worker grain can be created on the same and different silos of the cluster, there is no easy mechanism to coordinate state held by different activations.

Several useful patterns involve stateless worker holding state.

### Scaled out hot cache items

For hot cache items that experience high throughput, holding each such item in a stateless worker grain makes it:

1. Automatically scale out within a silo and across all silos in the cluster, and;
1. Makes the data always locally available on the silo that received the client request via its client gateway, so that the requests can be answered without an extra network hop to another silo.

### Reduce style aggregation

In some scenarios, applications need to calculate certain metrics across all grains of a particular type in the cluster and report the aggregates periodically. Examples are reporting several players per game map, the average duration of a VoIP call, etc. If each of the many thousands or millions of grains were to report their metrics to a single global aggregator, the aggregator would get immediately overloaded unable to process the flood of reports. The alternative approach is to turn this task into a 2 (or more) step to reduce style aggregation. The first layer of aggregation is done by reporting grain sending their metrics to a stateless worker pre-aggregation grain. The Orleans runtime will automatically create multiple activations of the stateless worker grain with each silo. Since all such calls will be processed locally with no remote calls or serialization of the messages, the cost of such aggregation will be significantly less than in a remote case. Now each of the pre-aggregation stateless worker grain activations, independently or in coordination with other local activations, can send their aggregated reports to the global final aggregator (or to another reduction layer if necessary) without overloading it.
