---
title: "&lt;textMessageEncoding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e6d834d0-356e-45eb-b530-bbefbb9ec3f0
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;textMessageEncoding&gt;
Specifies the character encoding and message versioning used for text-based XML messages.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<textMessageEncoding>  
  
## Syntax  
  
```xml  
<textMessageEncoding maxReadPoolSize="Integer"  
   maxWritePoolSize="Integer"  
   messageVersion="Soap11Addressing10/Soap12Addressing10"  
      writeEncoding="UnicodeFffeTextEncoding/Utf16TextEncoding/Utf8TextEncoding" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|maxReadPoolSize|An integer that specifies how many messages can be read simultaneously without allocating new readers. Larger pool sizes make the system more tolerant to activity spikes at the cost of a larger working set. The default is 64.|  
|maxWritePoolSize|An integer that specifies how many messages can be sent simultaneously without allocating new writers. Larger pool sizes make the system more tolerant to activity spikes at the cost of a larger working set. The default is 16.|  
|messageVersion|Specifies the SOAP version of the messages sent using the binding. Valid values are<br /><br /> -   Soap11Addressing10<br />-   Soap12Addressing10<br /><br /> The default is Soap12Addressing10. This attribute is of type <xref:System.ServiceModel.Channels.MessageVersion>.|  
|writeEncoding|Specifies the character set encoding to be used for emitting messages on the binding. Valid values are<br /><br /> -   UnicodeFffeTextEncoding: Unicode BigEndian encoding<br />-   Utf16TextEncoding: Unicode encoding<br />-   Utf8TextEncoding: 8-bit encoding<br /><br /> The default is Utf8TextEncoding. This attribute is of type <xref:System.Text.Encoding>.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<readerQuotas>](http://msdn.microsoft.com/library/3e5e42ff-cef8-478f-bf14-034449239bfd)|Defines the constraints on the complexity of SOAP messages that can be processed by endpoints configured with this binding. This element is of type <xref:System.ServiceModel.Configuration.XmlDictionaryReaderQuotasElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](../../../../../docs/framework/misc/binding.md)|Defines all binding capabilities of the custom binding.|  
  
## Remarks  
 Encoding is the process of transforming a message into a sequence of bytes. Decoding is the reverse process. Windows Communication Foundation (WCF) includes three types of encoding for SOAP messages: Text, Binary and Message Transmission Optimization Mechanism (MTOM).  
  
 The text encoding represented by the `textMessageEncoding` element is the most interoperable, but the least efficient encoder for XML messages.  The text encoder creates text-based messages on the wire. Messages produced by this encoder are suitable for WS-* based interop. Web service or Web service client can generally understand textual XML. However, transmitting large blocks of binary data as text is the least efficient method for encoding XML messages.  
  
## Example  
  
```xml  
<textMessageEncoding maxReadPoolSize="211"  
    maxWritePoolSize="2132"  
    messageVersion="Soap12Addressing10"  
    textEncoding="utf-8" />  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.TextMessageEncodingElement>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 <xref:System.ServiceModel.Channels.MessageEncodingBindingElement>  
 <xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement>  
 [Choosing a Message Encoder](../../../../../docs/framework/wcf/feature-details/choosing-a-message-encoder.md)  
 [Message Encoding](../../../../../docs/framework/configure-apps/file-schema/wcf/message-encoding.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)
