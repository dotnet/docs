---
title: Silo configuration
description: Learn about silo configuration in .NET Orleans.
ms.date: 01/31/2022
---

# Orleans silo configuration

To get a quick overview, we show all relevant configuration parameters (including optional ones) in XML syntax below:

```xml
<?xml version="1.0" encoding="utf-8"?>
<OrleansConfiguration xmlns="urn:orleans">
  <Globals>
    <MultiClusterNetwork
      ClusterId="clusterid"
      DefaultMultiCluster="uswest,europewest,useast"
      BackgroundGossipInterval="30s"
      UseGlobalSingleInstanceByDefault="false"
      GlobalSingleInstanceRetryInterval="30s"
      GlobalSingleInstanceNumberRetries="3"
      MaxMultiClusterGateways="10">
         <GossipChannel Type="..." ConnectionString="..."/>
         <GossipChannel Type="..." ConnectionString="..."/>
    </MultiClusterNetwork>
    <SystemStore ServiceId="some-guid" />
  </Globals>
</OrleansConfiguration>
```

```csharp
var silo = new SiloHostBuilder()
    .Configure<ClusterInfo>(options =>
    {
        options.ClusterId = "us3";
        options.ServiceId = "myawesomeservice";
    })
    .Configure<MultiClusterOptions>(options =>
    {
        options.HasMultiClusterNetwork = true;
        options.DefaultMultiCluster = new[] { "us1", "eu1", "us2" };
        options.BackgroundGossipInterval = TimeSpan.FromSeconds(30);
        options.UseGlobalSingleInstanceByDefault = false;
        options.GlobalSingleInstanceRetryInterval = TimeSpan.FromSeconds(30);
        options.GlobalSingleInstanceNumberRetries = 3;
        options.MaxMultiClusterGateways = 10;
        options.GossipChannels.Add(
            "AzureTable",
            "DefaultEndpointsProtocol=https;AccountName=usa;AccountKey=...");
        options.GossipChannels.Add(
            "AzureTable",
            "DefaultEndpointsProtocol=https;AccountName=europe;AccountKey=...")
    })
```

As usual, all configuration settings can also be read and written programmatically, via the respective members of the `GlobalConfiguration` class.

The `Service Id` is an arbitrary ID for identifying this service. It must be the same for all clusters and all silos.

The `MultiClusterNetwork` section is optional - if not present, all multi-cluster support is disabled for this silo.

The **required parameters** `ClusterId` and `GossipChannel` are explained in the section on [Multi-Cluster Communication](gossip-channels.md).

The  optional parameters `MaxMultiClusterGateways` and `BackgroundGossipInterval`  are explained in the section on [Multi-Cluster Communication](gossip-channels.md).

The optional parameter `DefaultMultiCluster` is explained in the section on [Multi-Cluster Configuration](multi-cluster-configuration.md).

The optional parameters `UseGlobalSingleInstanceByDefault`,  `GlobalSingleInstanceRetryInterval` and `GlobalSingleInstanceNumberRetries` are explained in the section on [Global-Single-Instance Grains](global-single-instance.md).

## Orleans client configuration

No extra configuration is required for Orleans client. The same client may not connect to silos in different clusters (the silo refuses the connection in that situation).
