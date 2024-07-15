---
title: Silo configuration
description: Learn about silo configuration in .NET Orleans.
ms.date: 07/03/2024
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
var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.Configure<ClusterInfo>(options =>
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
        });
    });
```

As usual, all configuration settings can also be read and written programmatically, via the respective members of the <xref:Orleans.Runtime.Configuration.GlobalConfiguration> class.

The <xref:Orleans.Runtime.Configuration.GlobalConfiguration.ServiceId?displayProperty=nameWithType> is an arbitrary ID for identifying this service. It must be the same for all clusters and all silos.

The <xref:Orleans.Runtime.MultiClusterNetwork> section is optional&mdash;if not present, all multi-cluster support is disabled for this silo.

The **required parameters** <xref:Orleans.MultiCluster.IMultiClusterGatewayInfo.ClusterId> and <xref:Orleans.Configuration.MultiClusterOptions.GossipChannels> are explained in the section on [Multi-Cluster Communication](gossip-channels.md).

The  optional parameters <xref:Orleans.Configuration.MultiClusterOptions.MaxMultiClusterGateways> and <xref:Orleans.Configuration.MultiClusterOptions.BackgroundGossipInterval> are explained in the section on [Multi-Cluster Communication](gossip-channels.md).

The optional parameter <xref:Orleans.Configuration.MultiClusterOptions.DefaultMultiCluster> is explained in the section on [Multi-Cluster Configuration](multi-cluster-configuration.md).

The optional parameters <xref:Orleans.Configuration.MultiClusterOptions.UseGlobalSingleInstanceByDefault>, <xref:Orleans.Configuration.MultiClusterOptions.GlobalSingleInstanceRetryInterval>, and <xref:Orleans.Configuration.MultiClusterOptions.GlobalSingleInstanceNumberRetries> are explained in the section on [Global-Single-Instance Grains](global-single-instance.md).

## Orleans client configuration

No extra configuration is required for Orleans client. The same client may not connect to silos in different clusters (the silo refuses the connection in that situation).
