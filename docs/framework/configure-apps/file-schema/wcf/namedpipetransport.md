---
title: "&lt;namedPipeTransport&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9fc3f42f-43e2-4ab1-8bc7-3c95a9220df1
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;namedPipeTransport&gt;
Defines a transport that causes a channel to transfer messages using named pipes when it is included in a custom binding.  
  
\<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<namePipeTransport>  
  
## Syntax  
  
```xml
<namedPipeTransport channelInitializationTimeout="TimeSpan"   
                    connectionBufferSize="Integer"   
                    hostNameComparisonMode="StrongWildcard/Exact/WeakWildcard"  
                    manualAddressing="Boolean"   
                    maxBufferPoolSize="Integer"  
                    maxBufferSize="Integer"  
                    maxOutputDelay="TimeSpan"  
                    maxPendingAccepts="Integer"   
                    maxPendingConnections="Integer"  
                    maxReceivedMessageSize="Integer"   
                    transferMode="Buffered/Streamed/StreamedRequest/StreamedResponse">  
  <connectionPoolSettings groupName="String" 
                          idleTimeout"TimeSpan"  
                          maxOutboundConnectionsPerEndpopint="Integer" />  
</namedPipeTransport>  
```  
  
## Attributes and Elements  
The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|ChannelInitializationTimeout|Gets or sets a <xref:System.TimeSpan> that determines the maximum time a channel can be in the initialization status before being disconnected.|  
|ConnectionBufferSize|Gets or sets the size of the buffer used to transmit a chunk of the serialized message on the wire from the client or service.|  
|hostNameComparisonMode|Gets or sets a value that indicates whether the hostname is used to reach the service when matching on the URI.|  
|manualAddressing|Gets or sets a value that indicates whether manual addressing of the message is required.|  
|maxBufferPoolSize|Gets or sets the maximum size, in bytes, of any buffer pools used by the transport.|  
|maxBufferSize|Gets or sets the maximum size of the buffer to use. For streamed messages, this value should be at least the maximum possible size of the message headers, which are read in buffered mode.|  
|maxOutputDelay|Gets or sets the maximum interval of time that a chunk of a message or a full message can remain buffered in memory before being sent out.|  
|maxPendingAccepts|Gets or sets the maximum number of channels a service can have waiting on a listener for processing incoming connections to the service.|  
|maxPendingConnections|Gets or sets the maximum number of connections awaiting dispatch on the service.|  
|maxReceivedMessageSize|Gets and sets the maximum allowable message size, in bytes, that can be received.|  
|transferMode|Gets or sets a value that indicates whether the messages are buffered or streamed with the connection-oriented transport.|  
|[\<connectionPoolSettings> of \<namedPipeTransport>](../../../../../docs/framework/configure-apps/file-schema/wcf/connectionpoolsettings.md)|Specifies additional connection pool settings for a Named Pipe binding.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](../../../../../docs/framework/misc/binding.md)|Defines all binding capabilities of the custom binding.|  
  
## Remarks  
This transport uses URIs of the form "net.pipe://hostname/path". Other URI components are optional.  
  
The `namedPipeTransport` element is the starting point for creating a custom binding that implements the named pipes transport protocol. This transport is used for on-machine Windows Communication Foundation (WCF)-to-WCF communication.  
  
## See Also  
<xref:System.ServiceModel.Configuration.NamedPipeTransportElement>   
<xref:System.ServiceModel.Channels.NamedPipeTransportBindingElement>   
<xref:System.ServiceModel.Channels.TransportBindingElement>   
<xref:System.ServiceModel.Channels.CustomBinding>   
[Transports](../../../../../docs/framework/wcf/feature-details/transports.md)   
[Choosing a Transport](../../../../../docs/framework/wcf/feature-details/choosing-a-transport.md)   
[Bindings](../../../../../docs/framework/wcf/bindings.md)   
[Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)   
[Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)   
[\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)
