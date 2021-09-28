---
description: "Learn more about: <namedPipeTransport>"
title: "<namedPipeTransport>"
ms.date: "03/30/2017"
ms.assetid: 9fc3f42f-43e2-4ab1-8bc7-3c95a9220df1
---
# \<namedPipeTransport>

Defines a transport that causes a channel to transfer messages using named pipes when it is included in a custom binding.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<customBinding>**](custombinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<namedPipeTransport>**  
  
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
                          idleTimeout="TimeSpan"
                          maxOutboundConnectionsPerEndpoint="Integer" />
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
|[\<connectionPoolSettings> of \<namedPipeTransport>](connectionpoolsettings.md)|Specifies additional connection pool settings for a Named Pipe binding.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](bindings.md)|Defines all binding capabilities of the custom binding.|  
  
## Remarks  

This transport uses URIs of the form "net.pipe://hostname/path". Other URI components are optional.  
  
The `namedPipeTransport` element is the starting point for creating a custom binding that implements the named pipes transport protocol. This transport is used for on-machine Windows Communication Foundation (WCF)-to-WCF communication.  
  
## See also

- <xref:System.ServiceModel.Configuration.NamedPipeTransportElement>
- <xref:System.ServiceModel.Channels.NamedPipeTransportBindingElement>
- <xref:System.ServiceModel.Channels.TransportBindingElement>
- <xref:System.ServiceModel.Channels.CustomBinding>
- [Transports](../../../wcf/feature-details/transports.md)
- [Choosing a Transport](../../../wcf/feature-details/choosing-a-transport.md)
- [Bindings](../../../wcf/bindings.md)
- [Extending Bindings](../../../wcf/extending/extending-bindings.md)
- [Custom Bindings](../../../wcf/extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
