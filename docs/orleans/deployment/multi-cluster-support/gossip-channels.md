---
title: Multi-cluster communication
description: Learn about multi-cluster communication in .NET Orleans.
ms.date: 05/23/2025
ms.topic: conceptual
---

# Multi-cluster communication

You must configure the network so that any Orleans silo can connect to any other Orleans silo via TCP/IP, regardless of where in the world it's located. Exactly how you achieve this is outside the scope of Orleans, as it depends on how and where you deploy the silos.

For example, on Azure, you can use VNets to connect multiple deployments within a region and gateways to connect VNets across different regions.

## Cluster identifier

Each cluster has its own unique cluster ID. You must specify the cluster ID in the global configuration.

Cluster IDs cannot be empty, nor can they contain commas. Also, if you use Azure Table Storage, cluster IDs cannot contain characters forbidden for row keys (/, \, #, ?).

We recommend using very short strings for cluster IDs because they are transmitted frequently and might be stored in storage by some log-view providers.

## Cluster gateways

Each cluster automatically designates a subset of its active silos to serve as *cluster gateways*. Cluster gateways directly advertise their IP addresses to other clusters and can thus serve as "points of first contact". By default, Orleans designates at most 10 silos (or the number configured as <xref:Orleans.Configuration.MultiClusterOptions.MaxMultiClusterGateways>) as cluster gateways.

Communication between silos in different clusters does *not* always pass through a gateway. Once a silo learns and caches the location of a grain activation (regardless of the cluster), it sends messages directly to that silo, even if the target silo isn't a cluster gateway.

## Gossip

Gossip is a mechanism for clusters to share configuration and status information. As the name suggests, gossip is decentralized and bidirectional: each silo communicates directly with other silos (both in the same cluster and in other clusters) to exchange information in both directions.

**Content**: Gossip contains some or all of the following information:

- The current time-stamped [multi-cluster configuration](multi-cluster-configuration.md).
- A dictionary containing information about cluster gateways. The key is the silo address, and the value contains (1) a timestamp, (2) the cluster ID, and (3) a status (either active or inactive).

**Fast & Slow Propagation**: When a gateway changes its status, or when an operator injects a new configuration, this gossip information is immediately sent to all silos, clusters, and gossip channels. This happens quickly but isn't reliable. If the message is lost for any reason (for example,, races, broken sockets, silo failures), periodic background gossip ensures the information eventually spreads, albeit more slowly. All information eventually propagates everywhere and is highly resilient to occasional message loss and failures.

All gossip data is timestamped. This ensures that newer information replaces older information, regardless of the relative timing of messages. For example, newer multi-cluster configurations replace older ones, and newer information about a gateway replaces older information about that gateway. For more details on the representation of gossip data, see the `MultiClusterData` class. It has a `Merge` method that combines gossip data, resolving conflicts using timestamps.

## Gossip channels

When a silo first starts, or when it restarts after a failure, it needs a way to **bootstrap the gossip**. This is the role of the *gossip channel*, which you can configure in the [Silo Configuration](silo-configuration.md). On startup, a silo fetches all information from the gossip channels. After startup, a silo continues gossiping periodically every 30 seconds (or the interval configured as `BackgroundGossipInterval`). Each time, it synchronizes its gossip information with a partner randomly selected from all cluster gateways and gossip channels.

- Although not strictly required, we recommend always configuring at least two gossip channels in distinct regions for better availability.
- Latency of communication with gossip channels isn't critical.
- Multiple different services can use the same gossip channel without interference, as long as the `ServiceId` `Guid` (specified in their respective configurations) is distinct.
- There's no strict requirement that all silos use the same gossip channels, as long as the channels are sufficient to let a silo initially connect with the "gossiping community" when it starts. However, if a gossip channel isn't part of a silo's configuration, and that silo is a gateway, it doesn't push its status updates to that channel (fast propagation). Therefore, it might take longer for those updates to reach the channel via periodic background gossip (slow propagation).

### Azure Table-based gossip channel

We have implemented a gossip channel based on Azure Tables. The configuration specifies standard connection strings used for Azure accounts. For example, a configuration could specify two gossip channels with separate Azure storage accounts `usa` and `europe` as follows:

```csharp
var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.Configure<MultiClusterOptions>(options =>
        {
            options.GossipChannels.Add(
                "AzureTable",
                "DefaultEndpointsProtocol=https;AccountName=usa;AccountKey=...");
            options.GossipChannels.Add(
                "AzureTable",
                "DefaultEndpointsProtocol=https;AccountName=europe;AccountKey=...")
        });
    })
```

Multiple different services can use the same gossip channel without interference, as long as the `ServiceId` `Guid` specified by their respective configurations is distinct.
