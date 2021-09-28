---
description: "Learn more about: <webSocketSettings>"
title: "<webSocketSettings>"
ms.date: "03/30/2017"
ms.assetid: bbf97e02-8dd1-4922-acac-3cd33397b249
---
# \<webSocketSettings>

A configuration element used to specify Web Socket settings.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<netHttpBinding>**](nethttpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<webSocketSettings>**  
  
## Syntax  
  
```xml  
<netHttpBinding>
  <binding>
    <webSocketSettings createNotificationOnConnection="Boolean"
                       disablePayloadMasking="Boolean"
                       keepAliveInterval="TimeSpan"
                       maxPendingConnections="Integer"
                       receiveBufferSize="Integer"
                       sendBufferSize="Integer"
                       subProtocol="String"
                       transportUsage="WhenDuplex/Always/Never" />
  </binding>
</netHttpBinding>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|createNotificationOnConnection|Specifies whether a notification is sent upon connection.|  
|disablePayloadMasking|Specifies whether Web Socket masking is disabled.|  
|keepAliveInterval|Specifies the keep alive interval.|  
|maxPendingConnections|Specifies the maximum number of connections awaiting dispatch on the service.|  
|receiveBufferSize|Specifies the size of the receive buffer.|  
|sendBufferSize|Specifies the size of the send buffer.|  
|subProtocol|Specifies the Web Socket subprotocol.|  
|transportUsage|Specifies when to use Web Sockets.|  
  
## transportUsage Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|WhenDuplex|Use the Web Socket protocol when the contract is duplex.|  
|Always|Always use the Web Socket protocol regardless of the contract.|  
|Never|Never use the Web Socket protocol.|  
  
### Child Elements  

 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|\<netHttpBinding>|Specifies the NetHttpBinding|  
  
## Example  

 The following example shows how to use the \<webSocketSettings> element.  
  
```xml  
<netHttpBinding>
  <binding>
    <webSocketSettings createNotificationOnConnection="true"
                       disablePayloadMasking="false"
                       keepAliveInterval="00:10:00"
                       maxPendingConnections="100"
                       receiveBufferSize="1000"
                       sendBufferSize="1000"
                       subProtocol="Soap"
                       transportUsage="WhenDuplex/Always/Never" />
  </binding>
</netHttpBinding>
```  
  
## See also

- <xref:System.ServiceModel.Channels.Binding>
- <xref:System.ServiceModel.Channels.BindingElement>
- <xref:System.ServiceModel.BasicHttpBinding>
- <xref:System.ServiceModel.Configuration.BasicHttpBindingElement>
- [Bindings](../../../wcf/bindings.md)
- [Configuring System-Provided Bindings](../../../wcf/feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../../wcf/using-bindings-to-configure-services-and-clients.md)
- [\<binding>](bindings.md)
