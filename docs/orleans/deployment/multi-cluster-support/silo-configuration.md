---
title: Silo configuration
description: Learn about silo configuration for multi-cluster support in .NET Orleans.
ms.date: 05/23/2025
ms.topic: conceptual
ms.service: orleans
---

# Orleans silo configuration

For a quick overview, we show all relevant configuration parameters (including optional ones) in XML syntax below:

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

As usual, you can also read and write all configuration settings programmatically via the respective members of the <xref:Orleans.Runtime.Configuration.GlobalConfiguration> class.

The <xref:Orleans.Runtime.Configuration.GlobalConfiguration.ServiceId?displayProperty=nameWithType> is an arbitrary ID for identifying this service. It must be the same for all clusters and all silos.

The `MultiClusterNetwork` section is optional. If it's not present, all multi-cluster support is disabled for this silo.

The **required parameters** <xref:Orleans.MultiCluster.IMultiClusterGatewayInfo.ClusterId> and <xref:Orleans.Configuration.MultiClusterOptions.GossipChannels> are explained in [Multi-cluster communication](gossip-channels.md).

The optional parameters <xref:Orleans.Configuration.MultiClusterOptions.MaxMultiClusterGateways> and <xref:Orleans.Configuration.MultiClusterOptions.BackgroundGossipInterval> are explained in [Multi-cluster communication](gossip-channels.md).

The optional parameter <xref:Orleans.Configuration.MultiClusterOptions.DefaultMultiCluster> is explained in [Multi-cluster configuration](multi-cluster-configuration.md).

The optional parameters <xref:Orleans.Configuration.MultiClusterOptions.UseGlobalSingleInstanceByDefault>, <xref:Orleans.Configuration.MultiClusterOptions.GlobalSingleInstanceRetryInterval>, and <xref:Orleans.Configuration.MultiClusterOptions.GlobalSingleInstanceNumberRetries> are explained in [Global single-instance grains](global-single-instance.md).

## Orleans client configuration

No extra configuration is required for the Orleans client. The same client cannot connect to silos in different clusters (the silo refuses the connection in that situation).
