---
title: "&lt;udpTransportSettings&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 842d92e9-6199-4ec5-b2d1-58533054e1f0
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;udpTransportSettings&gt;
This configuration element exposes UDP transport settings for [\<udpDiscoveryEndpoint>](../../../../../docs/framework/configure-apps/file-schema/wcf/udpdiscoveryendpoint.md).  
  
\<system.ServiceModel>  
\<standardEndpoints>  
\<udpDiscoveryEndpoint>  
  
## Syntax  
  
```xml  
<system.serviceModel>  
  <standardEndpoints>
    <udpDiscoveryEndpoint>
      <standardEndpoint>
        <updTransportSettings duplicateMessageHistoryLength="Integer" 
                              maxBufferPoolSize="Integer" 
                              maxMulticastRetransmitCount="Integer" 
                              maxPendingMessageCount="Integer" 
                              maxReceivedMessageSize="Integer" 
                              maxUnicastRetransmitCount="Integer" 
                              multicastInterfaceId="String" 
                              socketReceiveBufferSize="Integer" 
                              timeToLive="Integer" />
      </standardEndpoint>
    </udpDiscoveryEndpoint>
  </standardEndpoints>  
</system.serviceModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|duplicateMessageHistoryLength|An integer that specifies the maximum number of message hashes used by the transport for identifying duplicate messages.  Duplicate detection will be done at the TransportManager level. Setting this property to 0 disables duplicate detection.<br /><br /> This attribute allows system administrators or developers to turn off duplicate message detection algorithms. This may be desirable if you want to implement your own duplicate detection algorithm.<br /><br /> The default is 4112.|  
|maxBufferPoolSize|An integer that specifies the maximum size of any buffer pools used by the transport.|  
|maxMulticastRetransmitCount|An integer that specifies the maximum number of times the message should be retransmitted (in addition to the first send).<br /><br /> The default is 2.|  
|maxPendingMessageCount|An integer that specifies the maximum number of messages that have been received but not yet removed from the InputQueue for an individual channel instance.  If the InputQueue has hit its pending message count limit, the message will be dropped.<br /><br /> The default is 32.|  
|maxReceivedMessageSize|An integer that specifies the maximum size for a message that can be processed by the binding.<br /><br /> The default value is 65507.|  
|maxUnicastRetransmitCount|An integer that specifies the maximum number of times the message should be retransmitted (in addition to the first send).  If the message is sent to a unicast address and a response message is received with a corresponding RelatesTo header, then retransmission may terminate early (before retransmitting the configured number of times).<br /><br /> The default value is 1.|  
|multicastInterfaceId|A string that uniquely identifies the network adapter that should be used when sending and receiving multicast traffic on multi-homed machines. At runtime, the transport will use this attribute value to lookup the interface index, which is then used to set the `IP_MULTICAST_IF` and `IPV6_MULTICAST_IF` socket options.  The same interface index will be used when joining a multicast group, if applicable.<br /><br /> The default value is `null`.|  
|socketReceiveBufferSize|An integer that specifies the receive buffer size on the underlying WinSock socket.<br /><br /> A user of a receiving channel can use this attribute on the Binding to control how the system behaves when it receives data.  For example, given an application that is consuming inbound WCF messages at the maximum threshold, using a higher value for this attribute would allow messages to stack up in the WinSock buffer while waiting for the application to be able to process them.  Using a lower value in the same situation would result in messages getting dropped.This attribute exposes the underlying WinSock `SO_RCVBUF` socket option.This attribute value must be at least the size of `maxReceivedMessageSize`.   Setting it to a value smaller than the `maxReceivedMessageSize` will result in runtime exception.<br /><br /> The default value is 65536.|  
|timeToLive|An integer that specifies the number of network segment hops that a multicast packet can traverse.  This attribute exposes the functionality associated with the `IP_MULTICAST_TTL` and `IP_TTL` socket options.<br /><br /> The default value is 1.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<udpDiscoveryEndpoint>](../../../../../docs/framework/configure-apps/file-schema/wcf/udpdiscoveryendpoint.md)|A standard endpoint that has fixed discovery contract and UDP transport binding.|  
  
## See Also  
 <xref:System.ServiceModel.Discovery.UdpTransportSettings>
