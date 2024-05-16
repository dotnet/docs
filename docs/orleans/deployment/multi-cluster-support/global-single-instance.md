---
title: Global single-instance grains
description: Learn about global single-instance grains and coordination attributes in .NET Orleans.
ms.date: 03/09/2022
---

# Grain coordination attributes

Developers can indicate when and how clusters should coordinate their grain directories concerning a particular grain class. The <xref:Orleans.MultiCluster.GlobalSingleInstanceAttribute> means we want the same behavior as when running Orleans in a single global cluster: that is, route all calls to a single activation of the grain. Conversely, the `[OneInstancePerCluster]` attribute indicates that each cluster can have its independent activation. This is appropriate if communication between clusters is undesired.

The attributes are placed on grain implementations. For example:

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

If a grain class does not specify either one of those attributes, it defaults to <xref:Orleans.MultiCluster.OneInstancePerClusterAttribute>, or <xref:Orleans.MultiCluster.GlobalSingleInstanceAttribute> if the  configuration parameter <xref:Orleans.Runtime.Configuration.GlobalConfiguration.UseGlobalSingleInstanceByDefault?displayProperty=nameWithType> is set to `true`.

## Protocol for global single-instance grains

When a global-single-instance (GSI) grain is accessed, and no activation is known to exist, a special GSI activation protocol is executed before activating a new instance. Specifically, a request is sent to all other clusters in the current [multi-cluster configuration](multi-cluster-configuration.md) to check if they already have activation for this grain. If all responses are negative, a new activation is created in this cluster. Otherwise, the remote activation is used (and a reference to it is cached in the local directory).

## Protocol for one instance per cluster grains

There is no inter-cluster communication for One-Instance-Per-Cluster grains. They simply use the standard Orleans mechanism independently within each cluster. Inside the Orleans framework itself, the following grain classes are marked with the <xref:Orleans.MultiCluster.OneInstancePerClusterAttribute>:

- `ManagementGrain`
- `SystemTargetBasedMembershipTable`
- `GrainBasedReminderTable`

## Doubtful activations

If the GSI protocol does not receive conclusive responses from all clusters after 3 retries (or whatever number is specified by the configuration parameter <xref:Orleans.Configuration.MultiClusterOptions.GlobalSingleInstanceNumberRetries>), it creates a new local "doubtful" activation optimistically, favoring availability over consistency.

Doubtful activations may be duplicates (because some remote clusters that did not respond during the GSI protocol activation may nevertheless have activation of this grain). Therefore, periodically every 30 seconds (or whatever interval is specified by the configuration parameter <xref:Orleans.Configuration.MultiClusterOptions.GlobalSingleInstanceRetryInterval>) the GSI protocol is run again for all doubtful activations. This ensures that once communication between clusters is restored, duplicate activations can be detected and removed.
