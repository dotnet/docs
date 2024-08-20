---
title: Multi-cluster configuration
description: Learn about multi-cluster configuration in .NET Orleans.
ms.date: 07/03/2024
---

# Multi-cluster configuration

The multi-cluster configuration determines which clusters are currently part of the multi-cluster. It does not change automatically but is controlled by the operator. Thus, it is quite different from the membership mechanism used within a cluster, which automatically determines the set of silos that are part of the cluster.

We use the following terminology for the clusters in a service:

- A cluster is *active* if it has at least one active silo, and *inactive* otherwise.
- A cluster is *joined* if it is part of the current multi-cluster configuration, and *non-joined* otherwise.

Being active/inactive is independent of being joined/non-joined: all four combinations are possible.

All the clusters for a particular service are connected by a [gossip network](gossip-channels.md). The gossip network propagates configuration and status information.

## Inject a configuration

An operator issues configuration changes by injecting them into the multi-cluster network. The configurations can be injected into any cluster and spread from there to all active clusters. Each new configuration consists of a list of cluster ids that form the multi-cluster. It also has a UTC timestamp that is used to track its propagation through the gossip network.

Initially, the multi-cluster configuration is null, which means the multi-cluster list is empty (contains no clusters). Thus, the operator *must* initially inject a multi-cluster configuration. Once injected, this configuration persists in all connected silos (while running) and in all specified gossip channels (if those channels are persistent).

We pose some restrictions on the injection of new configurations that an operator must follow:

- Each new configuration may add several clusters, or remove some clusters (but not both at the same time).
- An operator should not issue a new configuration while a previous configuration change is still being processed.

These restrictions ensure that protocols such as the single-instance protocol can correctly maintain the mutual exclusion of activations even under configuration changes.

### Management grain

Multi-cluster configurations can be injected on any node in any cluster, using the Orleans Management Grain.
For example, to inject a multi-cluster configuration that consists of the three clusters { us1, eu1, us2 }, we can pass a string enumerable to the management grain:

```csharp
var clusters = "us1,eu1,us2".Split(',');
var mgtGrain = client.GetGrain<IManagementGrain>(0);
mgtGrain.InjectMultiClusterConfiguration(clusters, "my comment here"));
```

The first argument to <xref:Orleans.Runtime.IManagementGrain.InjectMultiClusterConfiguration(System.Collections.Generic.IEnumerable{System.String},System.String,System.Boolean)> is a collection of cluster ids, which is going to define the new multi-cluster configuration. The second argument is an (optional) comment string that can be used to tag configurations with arbitrary information, such as who injected them and why.

There is an optional third argument, a boolean called `checkForLaggingSilosFirst`, which defaults to true. It means that the system performs a best-effort check to see if there are any silos anywhere that have not caught up to the current configuration yet, and rejects the change if it finds such a silo. This helps to detect violations of the restriction that only one configuration change should be pending at a time (though it cannot guarantee it under all circumstances).

### Default configuration

In situations where the multi-cluster configuration is known in advance and the deployment is fresh every time (for testing), we may want to supply a default configuration. The global configuration supports an optional attribute <xref:Orleans.Runtime.Configuration.GlobalConfiguration.DefaultMultiCluster> which takes a comma-separated list of cluster ids:

```csharp
var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.Configure<MultiClusterOptions>(options =>
        {
            options.DefaultMultiCluster = new[] { "us1", "eu1", "us2" };
        })
    })
    .Build();
```

After a silo is started with this setting, it checks to see if the current multi-cluster configuration is null, and if so, injects the given configuration with the current UTC timestamp.

> [!WARNING]
> Persistent multi-cluster gossip channels (based on AzureTable) retain the last injected configuration unless they are deleted explicitly. In that case, specifying a `DefaultMultiCluster` has no effect when re-deploying a cluster because the configuration stored in the gossip channels is not null.>

### Gossip channel

An operator can also inject the configuration directly into the gossip channel. Changes in the channel are picked up and propagated automatically by the periodic background gossip, though possibly very slowly (using the management grain is much faster).  A rough estimate on the propagation time is 30 seconds (or whatever gossip interval is specified in the global configuration) times the binary logarithm of the total number of silos in all clusters. But since the gossip pairs are selected randomly, they can be both much quicker or much slower.

If using the Azure table-based gossip channel, operators can inject a new configuration simply by editing the configuration record in the `OrleansGossipTable`, using some tool for editing data in Azure tables. The configuration record has the following format:

| Name            | Type     | Value                                                   |
|-----------------|----------|---------------------------------------------------------|
| PartitionKey    | String   | the ServiceId                                           |
| RowKey          | String   | "CONFIG"                                                |
| Clusters        | String   | comma-separated list of cluster IDs, e.g. "us1,eu1,us2" |
| Comment         | String   | optional comment                                        |
| GossipTimestamp | DateTime | UTC timestamp for the configuration                     |

> [!NOTE]
> When editing this record in storage, the `GossipTimestamp` must also be set to a newer value than it has currently (otherwise the change is ignored). The most convenient and recommended way to do this is to *delete the `GossipTimestamp` field* - our gossip channel implementation then automatically replaces it with a correct, current Timestamp (it uses the Azure Table Timestamp).

## Cluster procedures

Adding or removing a cluster from the multi-cluster often needs to be coordinated within some larger context. We recommend always following the procedures described below when adding/removing clusters from the multi-cluster.

### Procedure for adding a cluster

1. Start a new Orleans cluster and wait till all silos are up and running.
1. Inject a configuration that contains the new cluster.
1. Start routing user requests to the new cluster.

### Procedure for removing a cluster

1. Stop routing new user requests to the cluster.
1. Inject a configuration that no longer contains the cluster.
1. Stop all silos of the cluster.

Once a cluster has been removed in this way, it can be re-added by following the procedure for adding a new cluster.

## Activity on non-joined clusters

There can be brief, temporary periods where a cluster is both active and non-joined:

- A freshly started cluster may start executing code before it is in the multi-cluster configuration (between steps 1 and 2 of the procedure for adding a cluster)
- A cluster that is being decommissioned may still execute code before the silos are shut down (between steps 2 and 3 of the procedure for removing a cluster).

During those intermediate situations, the following are possible:

- For global-single-instance grains: A grain may have a duplicate activation on a non-joined cluster.
- For versioned grains: activations on non-joined clusters do not receive notifications when the grain state changes.
