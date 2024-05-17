---
title: Multi-cluster support
description: Learn about multi-cluster support in .NET Orleans.
ms.date: 03/09/2022
---

# Multi-cluster support

Multi-Cluster support was removed in v2. The documentation below refers to Orleans v1. Orleans v.1.3.0 added support for federating several Orleans clusters into a loosely connected *multi-cluster* that acts as a single service. Multi-clusters facilitate *geo-distribution* as a service, that is, making it easier to run an Orleans application in multiple data centers around the world. Also, a multi-cluster can be run within a single datacenter to get better failure and performance isolation.

All mechanisms are designed with particular attention to:

1. Minimize communication between clusters.
1. Let each cluster run autonomously even if other clusters fail or become unreachable.

## Configuration and operation

Below we document how to configure and operate a multi-cluster.

[**Communication**](gossip-channels.md). Clusters communicate via the same silo-to-silo connections that are used within a cluster. To exchange status and configuration information, Clusters use a gossip mechanism and gossip channel implementations.

[**Silo Configuration**](silo-configuration.md). Silos need to be configured so they know which cluster they belong to (each cluster is identified by a unique string). Also, each silo needs to be configured with connection strings that allow them to connect to one or more [gossip channels](gossip-channels.md) on startup.

[**Multi-Cluster Configuration Injection**](multi-cluster-configuration.md). At runtime, the service operator can specify and/or change the *multi-cluster configuration*, which contains a list of cluster ids, to specify which clusters are part of the current multi-cluster. This is done by calling the management grain in any one of the clusters.

## Multi-cluster grains

Below we document how to use multi-cluster functionality at the application level.

[**Global-Single-Instance Grains**](global-single-instance.md). Developers can indicate when and how clusters should coordinate their grain directories concerning a particular grain class. The <xref:Orleans.MultiCluster.GlobalSingleInstanceAttribute> means we want the same behavior as when running Orleans in a single global cluster: that is, route all calls to a single activation of the grain. Conversely, the <xref:Orleans.MultiCluster.OneInstancePerClusterAttribute> indicates that each cluster can have its independent activation. This is appropriate if communication between clusters is undesired.

**Log-view grains**  *(not in v.1.3.0)*. A special type of grain that uses a new API, similar to event sourcing, for synchronizing or persisting grain state. It can be used to automatically and efficiently synchronize the state of a grain between clusters and with storage. Because its synchronization algorithms are safe to use with reentrant grains, and are optimized to use batching and replication, it can perform better than standard grains when a grain is frequently accessed in multiple clusters, and/or when it is written to storage frequently. Support for log-view grains is not part of the main branch yet. We have a prerelease including samples and a bit of documentation in the [`geo-orleans` branch](https://github.com/sebastianburckhardt/orleans/tree/geo-samples). It is currently being evaluated in production by an early adopter.
