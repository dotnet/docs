---
title: List of options classes
description: Explore a listing of options classes in .NET Orleans.
ms.date: 07/03/2024
ms.topic: article
---

# List of options classes

All options classes used to configure Orleans are found in the `Orleans.Configuration` namespace. Many of them have helper methods in the `Orleans.Hosting` namespace.

## Common core options for `IClientBuilder` and `ISiloHostBuilder`

| Option type | Used for |
|--|--|
| <xref:Orleans.Configuration.ClusterOptions> | Setting the `ClusterId` and the `ServiceId` |
| <xref:Orleans.Configuration.NetworkingOptions> | Setting timeout values for sockets and opened connections |
| <xref:Orleans.Configuration.SerializationProviderOptions>` | Setting the serialization providers |
| <xref:Orleans.Configuration.TypeManagementOptions> | Setting the refresh period of the Type Map (see Heterogeneous silos and Versioning) |

## `IClientBuilder` specific options

| Option type | Used for |
|--|--|
| <xref:Orleans.Configuration.ClientMessagingOptions> | Setting the number of connections to keep open, and specify what network interface to use |
| <xref:Orleans.Configuration.StatisticsOptions> | Settings related to statistics output |
| <xref:Orleans.Configuration.GatewayOptions> | Setting the refresh period of the list of available gateways |
| <xref:Orleans.Configuration.StaticGatewayListProviderOptions> | Setting URIs a client will use to connect to cluster |

## `ISiloHostBuilder` specific options

| Option type | Used for |
|--|--|
| <xref:Orleans.Configuration.ClusterMembershipOptions> | Settings for cluster membership |
| <xref:Orleans.Configuration.ConsistentRingOptions> | Configuration options for consistent hashing algorithm, used to balance resource allocations across the cluster. |
| <xref:Orleans.Configuration.EndpointOptions> | Setting the Silo endpoint options |
| <xref:Orleans.Configuration.GrainCollectionOptions> | Options for grain garbage collection |
| <xref:Orleans.Configuration.GrainVersioningOptions> | Governs grain implementation selection in heterogeneous deployments |
| <xref:Orleans.Configuration.LoadSheddingOptions> | Settings for load shedding configuration. Must have a registered implementation of <xref:Orleans.Statistics.IHostEnvironmentStatistics> such as through <xref:Orleans.Statistics.ClientBuilderExtensions.UsePerfCounterEnvironmentStatistics%2A?displayProperty=nameWithType> or <xref:Orleans.Statistics.SiloHostBuilderExtensions.UsePerfCounterEnvironmentStatistics%2A?displayProperty=nameWithType> (Windows only) for `LoadShedding` to function. |
| <xref:Orleans.Configuration.MultiClusterOptions> | Options for configuring multi-cluster support |
| <xref:Orleans.Configuration.PerformanceTuningOptions> | Performance tuning options (networking, number of threads) |
| <xref:Orleans.Configuration.ProcessExitHandlingOptions> | Configure silo behavior on process exit |
| <xref:Orleans.Configuration.SchedulingOptions> | Configuring scheduler behavior |
| <xref:Orleans.Configuration.SiloMessagingOptions> | Configuring global messaging options that are silo related. |
| <xref:Orleans.Configuration.SiloOptions> | Setting the name of the Silo |
| <xref:Orleans.Configuration.StatisticsOptions> | Setting related to statistics output |
| <xref:Orleans.Configuration.TelemetryOptions> | Setting telemetry consumer settings |
