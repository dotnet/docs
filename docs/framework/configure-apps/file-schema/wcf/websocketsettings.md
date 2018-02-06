---
title: "&lt;webSocketSettings&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bbf97e02-8dd1-4922-acac-3cd33397b249
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;webSocketSettings&gt;
A configuration element used to specify Web Socket settings.  
  
\<system.ServiceModel>  
\<bindings>  
\<netHttpBinding>  
  
## Syntax  
  
```xml  
<netHttpBinding>  
  <binding>   
    <webSocketSettings createNotificationOnConnection="boolean" 
                       disablePayloadMasking="boolean" 
                       keepAliveInterval="TimeSpan" 
                       maxPendingConnections="Integer" 
                       receiveBufferSize="Integer" 
                       sendBufferSize="Integer" 
                       subProtocol="String" 
                       transportUsage="WhenDuplex/Always/Never"/>
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
                              disablePayloadMasking="false  
                              keepAliveInterval="00:10:00"  
                              maxPendingConnections="100"  
                              receiveBufferSize="1000"  
                              sendBufferSize="1000"  
                              subProtocol="Soap"  
                              transportUsage="WhenDuplex/Always/Never"/>  
  
        </binding>  
      </netHttpBinding>  
```  
  
## See Also  
 <xref:System.ServiceModel.Channels.Binding>  
 <xref:System.ServiceModel.Channels.BindingElement>  
 <xref:System.ServiceModel.BasicHttpBinding>  
 <xref:System.ServiceModel.Configuration.BasicHttpBindingElement>  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 [\<binding>](../../../../../docs/framework/misc/binding.md)
