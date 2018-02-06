---
title: "&lt;tcpTransport&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8fcd18c1-9958-42e7-b442-7903f7bdb563
caps.latest.revision: 18
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;tcpTransport&gt;
Defines a TCP transport that can be used by a channel to transfers messages for a custom binding.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<tcpTransport>  
  
## Syntax  
  
```xml  
<tcpTransport   
      channelInitializationTimeout="TimeSpan"   
      connectionBufferSize="Integer"   
      hostNameComparisonMode="StrongWildcard/Exact/WeakWildcard"  
      listenBacklog="Integer"  
      manualAddressing="Boolean"   
      maxBufferPoolSize="Integer"  
      maxBufferSize="Integer"  
      maxOutputDelay="TimeSpan"  
      maxPendingAccepts="Integer"   
      maxPendingConnections="Integer"  
      maxReceivedMessageSize="Integer"   
      portSharingEnabled="Boolean"  
      teredoEnabled="Boolean"  
      transferMode="Buffered/Streamed/StreamedRequest/StreamedResponse" >  
      <connectionPoolSettings  
            groupName="String"  
            idleTimeout"TimeSpan"  
            leaseTimeout="TimeSpan"  
            maxOutboundConnectionsPerEndpopint="Integer" />  
</tcpTransport>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|channelInitializationTimeout|Gets or sets the time limit for initializing a channel to be accepted.  The maximum time a channel can be in the initialization state before being disconnected in seconds. This quota includes the time a TCP connection can take to authenticate itself using the .Net Message Framing protocol. A client needs to send some initial data before the server has enough information to perform authentication. The default is 30 seconds.|  
|connectionBufferSize|Gets or sets the size of the buffer used to transmit a chunk of the serialized message on the wire from the client or service.|  
|hostNameComparisonMode|Gets or sets a value that indicates whether the hostname is used to reach the service when matching on the URI.|  
|listenBacklog|The maximum number of queued connection requests that can be pending for a Web service. The `connectionLeaseTimeout` attribute limits the duration the client will wait to be connected before throwing a connection exception. This is a socket level property which controls the maximum number of queued connection requests that can be pending for a Web service. When ListenBacklog is too low, WCF will stop accepting requests and therefore drop new connections until the server acknowledges some of the existing queued connections .The default is 16 * number of processors.|  
|manualAddressing|Gets or sets a value that indicates whether manual addressing of the message is required.|  
|maxBufferPoolSize|Gets or sets the maximum size of any buffer pools used by the transport.|  
|maxBufferSize|Gets or sets the maximum size of the buffer to use. For streamed messages, this value should be at least the maximum possible size of the message headers, which are read in buffered mode.|  
|maxOutputDelay|Gets or sets the maximum interval of time that a chunk of a message or a full message can remain buffered in memory before being sent out.|  
|maxPendingAccepts|Gets or sets the maximum number of pending asynchronous accept operations that are available for processing incoming connections to the service.|  
|maxPendingConnections|Gets or sets the maximum number of connections awaiting dispatch on the service.|  
|maxReceivedMessageSize|Gets and sets the maximum allowable message size that can be received.|  
|portSharingEnabled|A Boolean value that specifies if TCP port sharing is enabled for this connection. If this is `false`, each binding will use its own exclusive port. The default is `false`.<br /><br /> This setting is relevant only to services. Clients are not affected.<br /><br /> Using this setting requires enabling the Windows Communication Foundation (WCF) TCP Port Sharing Service by changing its Startup Type to Manual or Automatic|  
|teredoEnabled|A Boolean value that specifies whether Teredo (a technology for addressing clients that are behind firewalls) is enabled. The default is `false`.<br /><br /> This property enables Teredo for the underlying TCP socket. For more information, see [Teredo Overview](http://go.microsoft.com/fwlink/?LinkId=95339).<br /><br /> This property is applicable only on [!INCLUDE[wxpsp2](../../../../../includes/wxpsp2-md.md)] and [!INCLUDE[ws2003](../../../../../includes/ws2003-md.md)]. [!INCLUDE[wv](../../../../../includes/wv-md.md)] has a machine-wide configuration option for Teredo, so when running Vista, this property is ignored. Teredo requires that the client and service machines both have the Microsoft IPv6 stack installed and correctly configured for Teredo usage. For more information about configuring Teredo, see [Teredo Overview](http://go.microsoft.com/fwlink/?LinkId=95339). For more information, see [Windows Server 2003 Technology Centers](http://go.microsoft.com/fwlink/?LinkId=49888).|  
|transferMode|Gets or sets a value that indicates whether the messages are buffered or streamed with the connection-oriented transport.|  
|connectionPoolSettings|Specifies additional connection pool settings for a Named Pipe binding.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](../../../../../docs/framework/misc/binding.md)|Defines all binding capabilities of the custom binding.|  
  
## Remarks  
 This transport uses URIs of the form "net.tcp://hostname:port/path". Other URI components are optional.  
  
 The `tcpTransport` element is the starting point for creating a custom binding that implements the TCP transport protocol. This transport is optimized for WCF-to-WCF communication.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.TcpTransportElement>  
 <xref:System.ServiceModel.Channels.TcpTransportBindingElement>  
 <xref:System.ServiceModel.Channels.TransportBindingElement>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 [Transports](../../../../../docs/framework/wcf/feature-details/transports.md)  
 [Choosing a Transport](../../../../../docs/framework/wcf/feature-details/choosing-a-transport.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)
