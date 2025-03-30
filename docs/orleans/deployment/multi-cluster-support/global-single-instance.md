---
title: Global single-instance grains
description: Learn about global single-instance grains and coordination attributes in .NET Orleans.
ms.date: 05/23/2025
ms.topic: conceptual
ms.service: orleans
---

# Grain coordination attributes

You can indicate when and how clusters should coordinate their grain directories for a particular grain class. The <xref:Orleans.MultiCluster.GlobalSingleInstanceAttribute> means you want the same behavior as when running Orleans in a single global cluster: route all calls to a single activation of the grain. Conversely, the `[OneInstancePerCluster]` attribute indicates that each cluster can have its independent activation. This is appropriate if you don't want communication between clusters.

Place the attributes on grain implementations. For example:

```csharp
using Orleans.MultiCluster;

[GlobalSingleInstance]
public class MyGlobalGrain : Orleans.Grain, IMyGrain
{
   // ...
}

[OneInstancePerCluster]
public class MyLocalGrain : Orleans.Grain, IMyGrain
{
   // ...
}
```

If a grain class doesn't specify either of these attributes, it defaults to <xref:Orleans.MultiCluster.OneInstancePerClusterAttribute>. However, it defaults to <xref:Orleans.MultiCluster.GlobalSingleInstanceAttribute> if you set the configuration parameter <xref:Orleans.Runtime.Configuration.GlobalConfiguration.UseGlobalSingleInstanceByDefault?displayProperty=nameWithType> to `true`.

## Protocol for global single-instance grains

When you access a global-single-instance (GSI) grain, and no activation is known to exist, Orleans executes a special GSI activation protocol before activating a new instance. Specifically, it sends a request to all other clusters in the current [multi-cluster configuration](multi-cluster-configuration.md) to check if they already have an activation for this grain. If all responses are negative, Orleans creates a new activation in the current cluster. Otherwise, it uses the remote activation (and caches a reference to it in the local directory).

## Protocol for one-instance-per-cluster grains

There is no inter-cluster communication for one-instance-per-cluster grains. They simply use the standard Orleans mechanism independently within each cluster. Inside the Orleans framework itself, the following grain classes are marked with the <xref:Orleans.MultiCluster.OneInstancePerClusterAttribute>:

- `ManagementGrain`
- `SystemTargetBasedMembershipTable`
- `GrainBasedReminderTable`

## Doubtful activations

If the GSI protocol doesn't receive conclusive responses from all clusters after 3 retries (or the number specified by the <xref:Orleans.Configuration.MultiClusterOptions.GlobalSingleInstanceNumberRetries> configuration parameter), it optimistically creates a new local "doubtful" activation, favoring availability over consistency.

"Doubtful" means the activation might be a duplicate because a remote cluster that didn't respond during the GSI protocol might still have an activation for this grain. Therefore, periodically, every 30 seconds (or the interval specified by the <xref:Orleans.Configuration.MultiClusterOptions.GlobalSingleInstanceRetryInterval> configuration parameter), Orleans runs the GSI protocol again for all doubtful activations. This process ensures that once communication between clusters is restored, the system can detect and remove duplicate activations.
