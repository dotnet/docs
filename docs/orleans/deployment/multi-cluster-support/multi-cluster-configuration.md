---
title: Multi-cluster configuration
description: Learn about multi-cluster configuration in .NET Orleans.
ms.date: 05/23/2025
ms.topic: conceptual
---

# Multi-cluster configuration

The multi-cluster configuration determines which clusters are currently part of the multi-cluster. It doesn't change automatically; instead, the operator controls it. Thus, it's quite different from the membership mechanism used within a cluster, which automatically determines the set of silos that are part of that cluster.

We use the following terminology for clusters in a service:

- A cluster is *active* if it has at least one active silo, and *inactive* otherwise.
- A cluster is *joined* if it is part of the current multi-cluster configuration, and *non-joined* otherwise.

Being active/inactive is independent of being joined/non-joined: all four combinations are possible.

All clusters for a particular service connect via a [gossip network](gossip-channels.md). The gossip network propagates configuration and status information.

## Inject a configuration

An operator issues configuration changes by injecting them into the multi-cluster network. You can inject configurations into any cluster, and they spread from there to all active clusters. Each new configuration consists of a list of cluster IDs that form the multi-cluster. It also has a UTC timestamp used to track its propagation through the gossip network.

Initially, the multi-cluster configuration is null, meaning the multi-cluster list is empty (contains no clusters). Thus, the operator *must* initially inject a multi-cluster configuration. Once injected, this configuration persists in all connected silos (while running) and in all specified gossip channels (if those channels are persistent).

We impose some restrictions on injecting new configurations that an operator must follow:

- Each new configuration may add several clusters, or remove some clusters (but not both at the same time).
- An operator should not issue a new configuration while a previous configuration change is still processing.

These restrictions ensure that protocols like the single-instance protocol can correctly maintain the mutual exclusion of activations, even during configuration changes.

### Management grain

You can inject multi-cluster configurations on any node in any cluster using the Orleans Management Grain.
For example, to inject a multi-cluster configuration consisting of the three clusters { us1, eu1, us2 }, pass a string enumerable to the management grain:

```csharp
var clusters = "us1,eu1,us2".Split(',');
var mgtGrain = client.GetGrain<IManagementGrain>(0);
mgtGrain.InjectMultiClusterConfiguration(clusters, "my comment here"));
```

The first argument to <xref:Orleans.Runtime.IManagementGrain.InjectMultiClusterConfiguration(System.Collections.Generic.IEnumerable{System.String},System.String,System.Boolean)> is a collection of cluster IDs that defines the new multi-cluster configuration. The second argument is an optional comment string that you can use to tag configurations with arbitrary information, such as who injected them and why.

There's an optional third argument, a boolean named `checkForLaggingSilosFirst`, which defaults to true. It means the system performs a best-effort check to see if any silos anywhere haven't caught up to the current configuration yet. If it finds such a silo, it rejects the change. This helps detect violations of the restriction that only one configuration change should be pending at a time (though it cannot guarantee this under all circumstances).

### Default configuration

In situations where the multi-cluster configuration is known in advance and the deployment is fresh every time (for testing), you might want to supply a default configuration. The global configuration supports an optional attribute <xref:Orleans.Runtime.Configuration.GlobalConfiguration.DefaultMultiCluster> which takes a comma-separated list of cluster IDs:

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

After a silo starts with this setting, it checks if the current multi-cluster configuration is null. If it is, the silo injects the given configuration with the current UTC timestamp.

> [!WARNING]
> Persistent multi-cluster gossip channels (based on AzureTable) retain the last injected configuration unless they are deleted explicitly. In that case, specifying a `DefaultMultiCluster` has no effect when re-deploying a cluster because the configuration stored in the gossip channels is not null.>

### Gossip channel

An operator can also inject the configuration directly into the gossip channel. Periodic background gossip automatically picks up and propagates changes in the channel, although possibly very slowly (using the management grain is much faster). A rough estimate of the propagation time is 30 seconds (or the gossip interval specified in the global configuration) times the binary logarithm of the total number of silos across all clusters. However, since gossip pairs are selected randomly, propagation can be much quicker or much slower.

If you use the Azure table-based gossip channel, operators can inject a new configuration simply by editing the configuration record in the `OrleansGossipTable` using a tool for editing Azure table data. The configuration record has the following format:

| Name            | Type     | Value                                                   |
|-----------------|----------|---------------------------------------------------------|
| PartitionKey    | String   | the ServiceId                                           |
| RowKey          | String   | "CONFIG"                                                |
| Clusters        | String   | comma-separated list of cluster IDs, for example, "us1,eu1,us2" |
| Comment         | String   | optional comment                                        |
| GossipTimestamp | DateTime | UTC timestamp for the configuration                     |

> [!NOTE]
> When editing this record in storage, you must also set the `GossipTimestamp` to a newer value than its current value (otherwise, the change is ignored). The most convenient and recommended way to do this is to *delete the `GossipTimestamp` field*. The gossip channel implementation then automatically replaces it with a correct, current timestamp (it uses the Azure Table Timestamp).

## Cluster procedures

Adding or removing a cluster from the multi-cluster often needs coordination within a larger context. We recommend always following the procedures described below when adding or removing clusters from the multi-cluster.

### Procedure for adding a cluster

1. Start a new Orleans cluster and wait until all silos are up and running.
1. Inject a configuration that includes the new cluster.
1. Start routing user requests to the new cluster.

### Procedure for removing a cluster

1. Stop routing new user requests to the cluster.
1. Inject a configuration that no longer includes the cluster.
1. Stop all silos of the cluster.

Once you remove a cluster this way, you can re-add it by following the procedure for adding a new cluster.

## Activity on non-joined clusters

There can be brief, temporary periods when a cluster is both active and non-joined:

- A freshly started cluster might start executing code before it's included in the multi-cluster configuration (between steps 1 and 2 of the procedure for adding a cluster).
- A cluster being decommissioned might still execute code before the silos shut down (between steps 2 and 3 of the procedure for removing a cluster).

During these intermediate situations, the following are possible:

- For global-single-instance grains: A grain might have a duplicate activation on a non-joined cluster.
- For versioned grains: Activations on non-joined clusters don't receive notifications when the grain state changes.
