---
title: "<connectionPoolSettings> of <tcpTransport>"
ms.date: "03/30/2017"
ms.assetid: 2fbc3aa7-fcc9-4193-99a3-85d31d60d3f7
---
# \<connectionPoolSettings> of \<tcpTransport>
Specifies additional connection pool settings for a TCP transport.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<customBinding>**](custombinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<tcpTransport>**](tcptransport.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<connectionPoolSettings>**  
  
## Syntax  
  
```xml  
<connectionPoolSettings groupName="String"
                        idleTimeout="TimeSpan"
                        leaseTimeout="TimeSpan"
                        maxOutboundConnectionsPerEndpoint="Integer" />
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`groupName`|A string that defines the name of the connection pool used for outgoing channels. In streamed mode, connections are not shared, meaning that connection pooling is disabled. The default is a "default" string. You can modify this value to isolate the connections for a particular client into separate groups.|  
|`idleTimeout`|A positive <xref:System.TimeSpan> that specifies the maximum time the connection can be idle before being disconnected. The default is 00:02:00.|  
|`leaseTimeout`|A <xref:System.TimeSpan> that specifies the time after which an active connection is closed. The default is 00:05:00.<br /><br /> A connection is closed after it has been returned to the connection cache and not during active transmission. The connection cache used by the TCP transport creates new connections as required for each endpoint, up to the cache limit that is set by `maxOutboundConnectionsPerEndpoint.`|  
|`maxOutboundConnectionsPerEndpoint`|A positive integer that specifies the maximum number of connections to a remote endpoint initiated by the service. Connections in excess of the limit are queued until a space below the limit becomes available. The `idleTimeout` limits the duration in which connections remain queued before an exception is thrown. The default is 10.<br /><br /> This attribute limits the number of simultaneous active connections from the client to a particular service endpoint. If this value is exceeded by having more active client connections, the service may appear unresponsive to the client. In this case, this value should be adjusted to exceed the maximum number of expected simultaneous client connections to a specific endpoint.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<namedPipeTransport>](namedpipetransport.md)|Defines a transport that causes a channel to transfer messages using named pipes.|  
  
## See also

- <xref:System.ServiceModel.Configuration.TcpConnectionPoolSettingsElement>
- <xref:System.ServiceModel.Channels.TcpTransportBindingElement.ConnectionPoolSettings%2A>
- <xref:System.ServiceModel.Channels.TcpConnectionPoolSettings>
- <xref:System.ServiceModel.Channels.TransportBindingElement>
- <xref:System.ServiceModel.Channels.CustomBinding>
- [Transports](../../../wcf/feature-details/transports.md)
- [Choosing a Transport](../../../wcf/feature-details/choosing-a-transport.md)
- [Bindings](../../../wcf/bindings.md)
- [Extending Bindings](../../../wcf/extending/extending-bindings.md)
- [Custom Bindings](../../../wcf/extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
