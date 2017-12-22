---
title: "&lt;byteStreamMessageEncoding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bbadd8dd-60a2-4007-b959-89373a8a7d60
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;byteStreamMessageEncoding&gt;
Specifies the message encoding as a stream of bytes, with the option to specify the character encoding.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<binaryMessageEncoding>  
  
## Syntax  
  
```xml  
<byteStreamMessageEncoding/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|messageVersion|Specifies the SOAP version of the messages sent using the binding. This property can only be set to the message version value of <xref:System.ServiceModel.Channels.MessageVersion.None%2A>. The byte stream message encoder does not support any other message versions.<br /><br /> This attribute is of type <xref:System.ServiceModel.Channels.MessageVersion>.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<readerQuotas>](http://msdn.microsoft.com/library/3e5e42ff-cef8-478f-bf14-034449239bfd)|Defines the constraints on the complexity of SOAP messages that can be processed by endpoints configured with this binding. This element is of type <xref:System.ServiceModel.Configuration.XmlDictionaryReaderQuotasElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](../../../../../docs/framework/misc/binding.md)|Defines all binding capabilities of the custom binding.|  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ByteStreamMessageEncodingElement>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 <xref:System.ServiceModel.Channels.MessageEncodingBindingElement>  
 <xref:System.ServiceModel.Channels.ByteStreamMessageEncodingBindingElement>  
 [Message Encoding](../../../../../docs/framework/configure-apps/file-schema/wcf/message-encoding.md)  
 [Choosing a Message Encoder](../../../../../docs/framework/wcf/feature-details/choosing-a-message-encoder.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)
