---
title: "&lt;connectionPoolSettings&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6fa7fa65-2c6e-4eab-b8cf-7690112c0be5
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;connectionPoolSettings&gt;
Specifies additional connection pool settings for a Named Pipe binding.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<namePipeTransport>  
\<connectionPoolSettings>  
  
## Syntax  
  
```xml  
<connectionPoolSettings  
        groupName="String"  
    idleTimeout"TimeSpan"  
    maxOutboundConnectionsPerEndpopint="Integer" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`groupName`|A string that defines the name of the connection pool used for outgoing channels. In streamed mode, connections are not shared, meaning that connection pooling is disabled. The default is a "default" string. You can modify this value to isolate the connections for a particular client into separate groups.|  
|`idleTimeout`|A positive <xref:System.TimeSpan> that specifies the maximum time the connection can be idle before being disconnected. The default is 00:02:00.|  
|`maxOutboundConnectionsPerEndpoint`|A positive integer that specifies the maximum number of connections to a remote endpoint initiated by the service. Connections in excess of the limit are queued until a space below the limit becomes available. The `idleTimeout` limits the duration in which connections remain queued before an exception is thrown. The default is 10.<br /><br /> This attribute limits the number of simultaneous active connections from the client to a particular service endpoint. If this value is exceeded by having more active client connections, the service may appear unresponsive to the client. In this case, this value should be adjusted to exceed the maximum number of expected simultaneous client connections to a specific endpoint.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<namedPipeTransport>](../../../../../docs/framework/configure-apps/file-schema/wcf/namedpipetransport.md)|Defines a transport that causes a channel to transfer messages using named pipes.|  
  
## See Also  
 <xref:System.ServiceModel.Configuration.NamedPipeConnectionPoolSettingsElement>  
 <xref:System.ServiceModel.Channels.NamedPipeTransportBindingElement.ConnectionPoolSettings%2A>  
 <xref:System.ServiceModel.Channels.NamedPipeConnectionPoolSettings>  
 <xref:System.ServiceModel.Channels.TransportBindingElement>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 [Transports](../../../../../docs/framework/wcf/feature-details/transports.md)  
 [Choosing a Transport](../../../../../docs/framework/wcf/feature-details/choosing-a-transport.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)
