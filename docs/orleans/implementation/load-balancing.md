---
title: Load balancing
description: Learn how .NET Orleans manages load balancing.
ms.date: 07/03/2024
---

# Load balancing

Load balancing, in a broad sense, is one of the pillars of the Orleans runtime. Orleans runtime tries to make everything balanced since balancing allows to maximize resource usage and avoid hotspots, which leads to better performance, as well as helps with elasticity. Load balancing in Orleans applies in multiple places. Below is a non-exhaustive list of places where the runtime performs balancing:

1. The default actor placement strategy is random, new activations are placed randomly across silos. That results in a balanced placement and prevents hotspots for most scenarios.
1. A more advanced <xref:Orleans.Runtime.ActivationCountBasedPlacement> tries to equalize the number of activations on all silos, which results in a more even distribution of activations across silos. This is especially important for elasticity.
1. The grain directory service is built on top of a distributed hash table, which inherently is balanced. The directory service maps grains to activations, each silo owns part of the global mapping table, and this table is globally partitioned in a balanced way across all silos. We use consistent hashing with virtual buckets for that.
1. Clients connect to all gateways and spread their requests across them, in a balanced way.
1. The reminder service is a distributed partitioned runtime service. The assignment of which silo is responsible to serve which reminder is balanced across all silos via consistent hashing, just like in grain directory.
1. Performance critical components within a silo are partitioned, and the work across them is locally balanced. That way the silo runtime can fully utilize all available CPU cores and not create in-silo bottlenecks. This applies to all local resources: allocation of work to threads, sockets, dispatch responsibilities, queues, etc.
1. The <xref:Orleans.Streams.QueueBalancerBase> balances the responsibility of pulling events from persistence queues across silos in the cluster.

Balancing doesn't necessarily mean loss of locality. One can be balanced and still maintain a good locality. For example, when balancing means sharding/partitioning, you can partition responsibility for a certain logical task, while still maintaining locality within each partition. That applies both for local and distributed balancing.
