---
title: "<peerTransport>"
ms.date: "03/30/2017"
ms.assetid: c1a5013a-9dd4-4a27-b114-795b8b323177
---
# \<peerTransport>
Defines a peer transport for a custom binding.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<peerTransport>  
  
## Syntax  
  
```xml  
<peerTransport listenIpAddress="String"
               maxBufferPoolSize="Integer"
               maxReceivedMessageSize="Integer"
               port="Integer">
  <security>
  </security>
</peerTransport>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|listenIpAddress|A string that specifies an IP address on which the peer node will listen for TCP messages. The default is `null`.|  
|maxBufferPoolSize|A positive integer that specifies the maximum size of the buffer pool. The default is 524288.<br /><br /> Many parts of WCF use buffers. Creating and destroying buffers each time they are used is expensive, and garbage collection for buffers is also expensive. With buffer pools, you can take a buffer from the pool, use it, and return it to the pool once you are done. Thus the overhead in creating and destroying buffers is avoided.|  
|maxReceivedMessageSize|A positive integer that defines the maximum message size in bytes including headers. The sender of a message receives a SOAP fault when the message is too large for the receiver. The receiver drops the message and creates an entry of the event in the trace log. The default is 65536.|  
|port|An integer that specifies the network interface port on which this binding will process peer channel TCP messages. This value must be between <xref:System.Net.IPEndPoint.MinPort> and <xref:System.Net.IPEndPoint.MaxPort>. The default is 0.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](security-of-peertransport.md)|Defines the security settings for this transport. This element is of type <xref:System.ServiceModel.Configuration.PeerSecurityElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](../../../misc/binding.md)|Defines all binding capabilities of the custom binding.|  
  
## Remarks  
 This transport cannot be used with contracts that have request/reply operations.  
  
## See also

- <xref:System.ServiceModel.Configuration.PeerTransportElement>
- <xref:System.ServiceModel.Channels.PeerTransportBindingElement>
- <xref:System.ServiceModel.Channels.TransportBindingElement>
- <xref:System.ServiceModel.Channels.CustomBinding>
- [Transports](../../feature-details/transports.md)
- [Choosing a Transport](../../feature-details/choosing-a-transport.md)
- [Bindings](../../bindings.md)
- [Extending Bindings](../../extending/extending-bindings.md)
- [Custom Bindings](../../extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
