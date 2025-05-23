---
title: Multi-cluster support
description: Learn about multi-cluster support in .NET Orleans.
ms.date: 05/23/2025
ms.topic: overview
---

# Multi-cluster support

> [!IMPORTANT]
> Multi-Cluster support was removed in Orleans v2. The documentation below refers to Orleans v1.

Orleans v1.3.0 added support for federating several Orleans clusters into a loosely connected *multi-cluster* that acts as a single service. Multi-clusters facilitate *geo-distribution* as a service, making it easier to run an Orleans application in multiple data centers around the world. You can also run a multi-cluster within a single datacenter to get better failure and performance isolation.

All mechanisms are designed with particular attention to:

1. Minimize communication between clusters.
1. Let each cluster run autonomously, even if other clusters fail or become unreachable.

## Configuration and operation

Below, we document how to configure and operate a multi-cluster.

[**Communication**](gossip-channels.md): Clusters communicate via the same silo-to-silo connections used within a cluster. To exchange status and configuration information, clusters use a gossip mechanism and gossip channel implementations.

[**Silo Configuration**](silo-configuration.md): You need to configure silos so they know which cluster they belong to (each cluster is identified by a unique string). Also, you need to configure each silo with connection strings that allow it to connect to one or more [gossip channels](gossip-channels.md) on startup.

[**Multi-Cluster Configuration Injection**](multi-cluster-configuration.md): At runtime, the service operator can specify and/or change the *multi-cluster configuration*, which contains a list of cluster IDs, to specify which clusters are part of the current multi-cluster. You do this by calling the management grain in any one of the clusters.

## Multi-cluster grains

Below, we document how to use multi-cluster functionality at the application level.

[**Global-Single-Instance Grains**](global-single-instance.md): You can indicate when and how clusters should coordinate their grain directories for a particular grain class. The <xref:Orleans.MultiCluster.GlobalSingleInstanceAttribute> means you want the same behavior as when running Orleans in a single global cluster: route all calls to a single activation of the grain. Conversely, the <xref:Orleans.MultiCluster.OneInstancePerClusterAttribute> indicates that each cluster can have its independent activation. This is appropriate if you don't want communication between clusters.

**Log-view grains** *(not in v1.3.0)*: A special type of grain that uses a new API, similar to event sourcing, for synchronizing or persisting grain state. You can use it to automatically and efficiently synchronize the state of a grain between clusters and with storage. Because its synchronization algorithms are safe for use with reentrant grains and are optimized for batching and replication, it can perform better than standard grains when a grain is frequently accessed in multiple clusters and/or written to storage frequently. Support for log-view grains isn't part of the main branch yet. We have a prerelease including samples and some documentation in the [`geo-orleans` branch](https://github.com/sebastianburckhardt/orleans/tree/geo-samples). It's currently being evaluated in production by an early adopter.
