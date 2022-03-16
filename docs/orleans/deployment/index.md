---
title: Run an Orleans application
description: Learn how to run an Orleans app in .NET.
ms.date: 03/09/2022
---

# Orleans application

A typical Orleans application consists of a cluster of server processes (silos) where grains live, and a set of client processes, usually web servers, that receive external requests, turn them into grain method calls and return results. Hence, the first thing one needs to do to run an Orleans application is to start a cluster of silos. For testing purposes, a cluster can consist of a single silo. For a reliable production deployment, we want more than one silo in a cluster for fault tolerance and scale.

Once the cluster is running, we can start one or more client processes that connect to the cluster and can send requests to the grains. Clients connect to a special TCP endpoint on silos - gateway. By default, every silo in a cluster has a client gateway enabled. So clients can connect to all silos in parallel for better performance and resilience.

## Configure and start a silo

A silo is configured programmatically via a <xref:Orleans.Runtime.Configuration.ClusterConfiguration> object. It can be instantiated and populated directly, load settings from a file, or created with several available helper methods for different deployment environments. For local testing, the easiest way to go is to use <xref:Orleans.Runtime.Configuration.ClusterConfiguration.LocalhostPrimarySilo%2A> helper method. The configuration object is then passed to a new instance of <xref:Orleans.Runtime.Host.SiloHost> class, which can be initialized and started after that.

You can create an empty console application project targeting .NET Framework 4.6.1 or higher for hosting a silo.
Add the `Microsoft.Orleans.Server` NuGet meta-package to the project.

```powershell
Install-Package Microsoft.Orleans.Server
```

Here is an example of how a local silo can be started:

```csharp
var siloConfig = ClusterConfiguration.LocalhostPrimarySilo();
var silo = new SiloHost("Test Silo", siloConfig);
silo.InitializeOrleansSilo();
silo.StartOrleansSilo();

Console.WriteLine("Press Enter to close.");
// wait here
Console.ReadLine();

// shut the silo down after we are done.
silo.ShutdownOrleansSilo();
```

## Configure and connect to a client

Client for connecting to a cluster of silos and sending requests to grains is configured programmatically via a <xref:Orleans.Runtime.Configuration.ClientConfiguration> object and a <xref:Orleans.ClientBuilder>. `ClientConfiguration` object can be instantiated and populated directly, load settings from a file, or created with several available helper methods for different deployment environments. For local testing, the easiest way to go is to use <xref:Orleans.Runtime.Configuration.ClientConfiguration.LocalhostSilo%2A> helper method. The configuration object is then passed to a new instance of `ClientBuilder` class.

`ClientBuilder` exposes more methods for configuring additional client features. After that <xref:Orleans.ClientBuilder.Build?displayProperty=nameWithType> method of the `ClientBuilder` object is called to get an implementation of <xref:Orleans.IClusterClient> interface. Finally, we call <xref:Orleans.IClusterClient.Connect?displayProperty=nameWithType> method on the returned object to connect to the cluster.

You can create an empty console application project targeting .NET Framework 4.6.1 or higher for running a client or reuse the console application project you created for hosting a silo. Add the `Microsoft.Orleans.Client` NuGet meta-package to the project.

```powershell
Install-Package Microsoft.Orleans.Client
```

Here is an example of how a client can connect to a local silo:

```csharp
var config = ClientConfiguration.LocalhostSilo();
var builder = new ClientBuilder().UseConfiguration(config).
var client = builder.Build();
await client.Connect();
```

## Production configurations

The configuration examples we used here are for testing silos and clients running on the same machine as `localhost`. In production, silos and clients usually run on different servers and are configured with one of the reliable cluster configuration options. You can find more about that in the [Configuration guide](../host/configuration-guide/index.md) and in the description of [Cluster management](../implementation/cluster-management.md).
