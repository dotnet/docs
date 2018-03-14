---
title: "&lt;binaryMessageEncoding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e4ae3cd4-6b67-4ce1-af4b-9400e0a38dba
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;binaryMessageEncoding&gt;
Defines a binary message encoder that encodes Windows Communication Foundation (WCF) messages in binary on the wire.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<binaryMessageEncoding>  
  
## Syntax  
  
```xml  
<binaryMessageEncoding   
      maxReadPoolSize="Integer"  
   maxSessionSize="Integer"   
   maxWritePoolSize="Integer"   messageVersion="Soap11Addressing10/Soap12Addressing10" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|maxReadPoolSize|An integer that defines how many messages can be read simultaneously without allocating new readers. Larger pool sizes make the system more tolerant to activity spikes at the cost of a larger working set. The default is 64.|  
|maxSessionSize|A positive integer that sets the size, in bytes, of the buffer used for encoding. A larger buffer increases encoding speed at the expense of the size of the working set. The default is 2048.|  
|maxWritePoolSize|An integer that defines how many messages can be sent simultaneously without allocating new writers. Larger pool sizes make the system more tolerant to activity spikes at the cost of a larger working set. The default is 16.|  
|messageVersion|Specifies the SOAP message and WS-Addressing versions that are used or expected.|  
  
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
  
 The `binaryMessageEncoding` element specifies the .NET Binary Format for XML and has options to specify the character encoding and the SOAP and WS-Addressing version to be used. The binary message encoder encodes Windows Communication Foundation (WCF) messages in binary on the wire. While this encoding results in very fast transmission of messages, interoperability based on the WS-* standards is lost.  
  
## Example  
  
```xml  
<binaryMessageEncoding maxReadPoolSize="211"  
   maxWritePoolSize="2132"  
   maxSessionSize="3141" />  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.BinaryMessageEncodingElement>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 <xref:System.ServiceModel.Channels.MessageEncodingBindingElement>  
 <xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement>  
 [Message Encoding](../../../../../docs/framework/configure-apps/file-schema/wcf/message-encoding.md)  
 [Choosing a Message Encoder](../../../../../docs/framework/wcf/feature-details/choosing-a-message-encoder.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)
