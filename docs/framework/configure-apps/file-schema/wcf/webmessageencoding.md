---
title: "&lt;webMessageEncoding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 892ca485-e21a-4a44-8e40-633161ef6796
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;webMessageEncoding&gt;
Enables plain-text XML, JavaScript Object Notation (JSON) message encodings and "raw" binary content to be read and written when used in a [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] binding.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<webMessageEncoding>  
  
## Syntax  
  
```xml  
<webMessageEncoding   
      maxReadPoolSize="Integer"  
   maxWritePoolSize="Integer"  
  
writeEncoding="UnicodeFffeTextEncoding/Utf16TextEncoding/Utf8TextEncoding" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`maxReadPoolSize`|The amount of messages that can be read simultaneously without allocating new readers. Larger pool sizes make the system more tolerant to activity spikes at the cost of a larger working set. The default is 64 readers for each of the inner encoders (text, JSON, and "raw").<br /><br /> Increasing this number increases memory consumption, but prepares the encoder to deal with sudden bursts of incoming messages because it is able to use readers from the pool that are already created instead of creating new ones.|  
|`maxWritePoolSize`|The amount of messages that can be sent simultaneously without allocating new writers. Larger pool sizes make the system more tolerant to activity spikes at the cost of a larger working set. The default is 16 writers for each of the inner encoders (text, JSON, and "raw").<br /><br /> Increasing this number increases memory consumption, but prepares the encoder to deal with sudden bursts of outgoing messages because it is able to use writers from the pool that are already created instead of creating new ones.|  
|`writeEncoding`|Specifies the character set encoding to be used for emitting messages on the binding. Valid values are:<br /><br /> -   UnicodeFffeTextEncoding: Unicode Big Endian encoding.<br />-   Utf16TextEncoding: Unicode encoding.<br />-   Utf8TextEncoding: 8-bit encoding.<br /><br /> The default is Utf8TextEncoding. This attribute is of type <xref:System.Text.Encoding>.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<readerQuotas>](http://msdn.microsoft.com/library/3e5e42ff-cef8-478f-bf14-034449239bfd)|Defines the constraints on the complexity of SOAP messages that can be processed by endpoints configured with this binding. This element is of type <xref:System.ServiceModel.Configuration.XmlDictionaryReaderQuotasElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](../../../../../docs/framework/misc/binding.md)|Defines all binding capabilities of the custom binding.|  
  
## Remarks  
 Encoding is the process of transforming a message into a sequence of bytes. Decoding is the reverse process. These processes require the specification of a character encoding.  
  
 The `webMessageEncoding` element works by delegating to a series of inner encoders to handle the plain-text XML and JSON encodings, and "raw" binary data. This delegation is done by a composite message encoder.  
  
 This binding element and its composite encoder are used to control the encoding in scenarios that do not use SOAP messaging used by the `webHttpBinding` element. These scenarios include "Plain Old XML" (POX), Representational State Transfer (REST), Really Simple Syndication (RSS) and Atom syndication, and Asynchronous JavaScript and XML (AJAX). The composite message encoder does not support SOAP or WS-Addressing.  
  
 The binding element can be configured with a write character encoding by using the `writeEncoding` attribute. The supplied <xref:System.Text.Encoding> value specifies the behavior on write for the JSON and Textual XML cases. On read, any valid message encoding and text encoding is understood.  
  
 `maxReadPoolSize` and `maxWritePoolSize` can also be used to set the maximum number of readers and writers to be allocated respectively. By default 64 readers and 16 writers are allocated.  
  
 Default complexity constraints are also set using the [\<readerQuotas>](http://msdn.microsoft.com/library/3e5e42ff-cef8-478f-bf14-034449239bfd) element to protect against a class of denial of service (DOS) attacks that attempt to use message complexity to tie up endpoint processing resources.  
  
## Example  
  
```xml  
<webMessageEncoding   
    maxReadPoolSize="256"  
    maxWritePoolSize="128"  
    messageVersion="None"  
    textEncoding="utf-8"   
/>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.WebMessageEncodingElement>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 <xref:System.ServiceModel.Channels.MessageEncodingBindingElement>  
 <xref:System.ServiceModel.Channels.WebMessageEncodingBindingElement>  
 [Message Encoding](../../../../../docs/framework/configure-apps/file-schema/wcf/message-encoding.md)  
 [Choosing a Message Encoder](../../../../../docs/framework/wcf/feature-details/choosing-a-message-encoder.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)
