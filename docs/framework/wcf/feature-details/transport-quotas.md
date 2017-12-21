---
title: "Transport Quotas"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "transport quotas [WCF]"
ms.assetid: 3e71dd3d-f981-4d9c-9c06-ff8abb61b717
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Transport Quotas
Transport quotas are a policy mechanism for deciding when a connection is consuming excessive resources. A quota is a hard limit that prevents the use of additional resources once the quota value is exceeded. Transport quotas prevent either malicious or unintentional denial of service attacks.  
  
 [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] transports have default quota values that are based on a conservative allocation of resources. These default values are suitable for development environments and small installation scenarios. Service administrators should review transport quotas and tune individual quota values if an installation is running out of resources or if connections are being limited despite the availability of additional resources.  
  
## Types of Transport Quotas  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] transports have three types of quotas:  
  
-   *Timeouts* mitigate denial of service attacks that rely on tying up resources for an extended period of time.  
  
-   *Memory allocation limits* prevent a single connection from exhausting system memory and denying service to other connections.  
  
-   *Collection size limits* bound the consumption of resources that indirectly allocate memory or are in limited supply.  
  
## Transport Quota Descriptions  
 This section describes the transport quotas available for the standard [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] transports: HTTP(S), TCP/IP, and named pipes. Custom transports can expose their own configurable quotas not included in this list. Consult the documentation for a custom transport to find out about its quotas.  
  
 Each quota setting has a type, minimum value, and default value. The maximum value of a quota is limited by its type. Due to machine limitations, it is not always possible to set a quota to its maximum value.  
  
|Name|Type|Min.<br /><br /> value|Default<br /><br /> value|Description|  
|----------|----------|--------------------|-----------------------|-----------------|  
|`ChannelInitializationTimeout`|TimeSpan|1 tick|5 sec|Maximum time to wait for a connection to send the preamble during the initial read. This data is received before authentication occurs. This setting is generally much smaller than the `ReceiveTimeout` quota value.|  
|`CloseTimeout`|TimeSpan|0|1 min|Maximum time to wait for a connection to close before the transport raises an exception.|  
|`ConnectionBufferSize`|Integer|1|8 KB|Size, in bytes, of the transmit and receive buffers of the underlying transport. Increasing the buffer size can improve throughput when sending large messages.|  
|`IdleTimeout`|TimeSpan|0|2 min|Maximum time a pooled connection can remain idle before being closed.<br /><br /> This setting only applies to pooled connections.|  
|`LeaseTimeout`|TimeSpan|0|5 min|Maximum lifetime of an active pooled connection. After the specified time elapses, the connection closes once the current request is serviced.<br /><br /> This setting only applies to pooled connections.|  
|`ListenBacklog`|Integer|1|10|Maximum number of connections that the listener can have unserviced before additional connections to that endpoint are denied.|  
|`MaxBufferPoolSize`|Long|0|512 KB|Maximum memory, in bytes, that the transport devotes to pooling reusable message buffers. When the pool cannot supply a message buffer, a new buffer is allocated for temporary use.<br /><br /> Installations that create many channel factories or listeners can allocate large amounts of memory for buffer pools. Reducing this buffer size can greatly reduce memory usage in this scenario.|  
|`MaxBufferSize`|Integer|1|64 KB|Maximum size, in bytes, of a buffer used for streaming data. If this transport quota is not set, or the transport is not using streaming, then the quota value is the same as the smaller of the `MaxReceivedMessageSize` quota value and <xref:System.Int32.MaxValue>.|  
|`MaxOutboundConnectionsPerEndpoint`|Integer|1|10|Maximum number of outgoing connections that can be associated with a particular endpoint.<br /><br /> This setting only applies to pooled connections.|  
|`MaxOutputDelay`|TimeSpan|0|200 ms|Maximum time to wait after a send operation for batching additional messages in a single operation. Messages are sent earlier if the buffer of the underlying transport becomes full. Sending additional messages does not reset the delay period.|  
|`MaxPendingAccepts`|Integer|1|1|Maximum number of accepts for channels that the listener can have waiting.<br /><br /> There is an interval of time between the accept completing and a new accept starting. Increasing this collection size can prevent clients that connect during this interval from being dropped.|  
|`MaxPendingConnections`|Integer|1|10|Maximum number of connections that the listener can have waiting to be accepted by the application. When this quota value is exceeded, new incoming connections are dropped rather than waiting to be accepted.<br /><br /> Connection features such as message security can cause a client to open more than one connection. Service administrators should account for these additional connections when setting this quota value.|  
|`MaxReceivedMessageSize`|Long|1|64 KB|Maximum size, in bytes, of a received message, including headers, before the transport raises an exception.|  
|`OpenTimeout`|TimeSpan|0|1 min|Maximum time to wait for a connection to be established before the transport raises an exception.|  
|`ReceiveTimeout`|TimeSpan|0|10 min|Maximum time to wait for a read operation to complete before the transport raises an exception.|  
|`SendTimeout`|Timespan|0|1 min|Maximum time to wait for a write operation to complete before the transport raises an exception.|  
  
 The transport quotas `MaxPendingConnections` and `MaxOutboundConnectionsPerEndpoint` are combined into a single transport quota called `MaxConnections` when set through the binding or configuration. Only the binding element allows setting these quota values individually. The `MaxConnections` transport quota has the same minimum and default values.  
  
## Setting Transport Quotas  
 Transport quotas are set through the transport binding element, the transport binding, application configuration, or host policy. This document does not cover setting transports through host policy. Consult the documentation for the underlying transport to discover the settings for host policy quotas. The [Configuring HTTP and HTTPS](../../../../docs/framework/wcf/feature-details/configuring-http-and-https.md) topic describes quota settings for the Http.sys driver. Search the Microsoft Knowledge Base for more information about configuring Windows limits on HTTP, TCP/IP, and named pipe connections.  
  
 Other types of quotas apply indirectly to transports. The message encoder that the transport uses to transform a message into bytes can have its own quota settings. However, these quotas are independent of the type of transport being used.  
  
### Controlling Transport Quotas from the Binding Element  
 Setting transport quotas through the binding element offers the greatest flexibility in controlling the transport's behavior. The default timeouts for Close, Open, Receive, and Send operations are taken from the binding when a channel is built.  
  
|Name|HTTP|TCP/IP|Named pipe|  
|----------|----------|-------------|----------------|  
|`ChannelInitializationTimeout`||X|X|  
|`CloseTimeout`||||  
|`ConnectionBufferSize`||X|X|  
|`IdleTimeout`||X|X|  
|`LeaseTimeout`||X||  
|`ListenBacklog`||X||  
|`MaxBufferPoolSize`|X|X|X|  
|`MaxBufferSize`|X|X|X|  
|`MaxOutboundConnectionsPerEndpoint`||X|X|  
|`MaxOutputDelay`||X|X|  
|`MaxPendingAccepts`||X|X|  
|`MaxPendingConnections`||X|X|  
|`MaxReceivedMessageSize`|X|X|X|  
|`OpenTimeout`||||  
|`ReceiveTimeout`||||  
|`SendTimeout`||||  
  
### Controlling Transport Quotas from the Binding  
 Setting transport quotas through the binding offers a simplified set of quotas to choose from while still giving access to the most common quota values.  
  
|Name|HTTP|TCP/IP|Named pipe|  
|----------|----------|-------------|----------------|  
|`ChannelInitializationTimeout`||||  
|`CloseTimeout`|X|X|X|  
|`ConnectionBufferSize`||||  
|`IdleTimeout`||||  
|`LeaseTimeout`||||  
|`ListenBacklog`||X||  
|`MaxBufferPoolSize`|X|X|X|  
|`MaxBufferSize`|1|X|X|  
|`MaxOutboundConnectionsPerEndpoint`||2|2|  
|`MaxOutputDelay`||||  
|`MaxPendingAccepts`||||  
|`MaxPendingConnections`||2|2|  
|`MaxReceivedMessageSize`|X|X|X|  
|`OpenTimeout`|X|X|X|  
|`ReceiveTimeout`|X|X|X|  
|`SendTimeout`|X|X|X|  
  
1.  The `MaxBufferSize` transport quota is only available on the `BasicHttp` binding. The `WSHttp` bindings are for scenarios that do not support streamed transport modes.  
  
2.  The transport quotas `MaxPendingConnections` and `MaxOutboundConnectionsPerEndpoint` are combined into a single transport quota called `MaxConnections`.  
  
### Controlling Transport Quotas from Configuration  
 Application configuration can set the same transport quotas as directly accessing properties on a binding. In configuration files, the name of a transport quota always starts with a lowercase letter. For example, the `CloseTimeout` property on a binding corresponds to the `closeTimeout` setting in configuration and the `MaxConnections` property on a binding corresponds to the `maxConnections` setting in configuration.  
  
## See Also  
 <xref:System.ServiceModel.Channels.HttpsTransportBindingElement>  
 <xref:System.ServiceModel.Channels.HttpTransportBindingElement>  
 <xref:System.ServiceModel.Channels.TcpTransportBindingElement>  
 <xref:System.ServiceModel.Channels.NamedPipeTransportBindingElement>  
 <xref:System.ServiceModel.Channels.ConnectionOrientedTransportBindingElement>  
 <xref:System.ServiceModel.Channels.TransportBindingElement>
