---
title: "&lt;compositeDuplex&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 725004d1-ce88-4405-a220-78e89844f81f
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;compositeDuplex&gt;
Defines the binding element that is used when the client must expose an endpoint for the service to send messages back to the client.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<compositeDuplex>  
  
## Syntax  
  
```xml  
<compositeDuplex clientBaseAddress="URI" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|clientBaseAddress|A URI that sets the address of the back channel in duplex mode. The service uses this address to make contact and establish a connection with the client.<br /><br /> If this attribute is not set, a default address "`full qualified name+default port\TemporaryIndigoAddress\guid`" is generated. The default is `null`.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](../../../../../docs/framework/misc/binding.md)|Defines all binding capabilities of the custom binding.|  
  
## Remarks  
 This configuration element is used with transports that do not allow duplex communications natively, for example, HTTP. TCP, by contrast, allows duplex communications natively, and does not require the use of this binding element for the service to send messages back to a client.  
  
 The client must expose an address for the service to make contact and establish a connection. This client address is provided by the `clientBaseAddress` attribute. Note that Windows Communication Foundation (WCF) auto-generates a ClientBaseAddress if one is not explicitly set by the user.  
  
## Example  
  
```xml  
<compositeDuplex clientBaseAddress="http://www.contoso.com" />  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.CompositeDuplexElement>  
 <xref:System.ServiceModel.Channels.CompositeDuplexBindingElement>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)
