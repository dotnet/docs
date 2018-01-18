---
title: "Message Encoding"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f30ee941-aca9-4c67-82a5-421568496f07
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Message Encoding
Encoding is the process of transforming a set of Unicode characters into a sequence of bytes. Decoding is the reverse process. Windows Communication Foundation (WCF) includes three types of encoding for SOAP messages: Text, Binary and Message Transmission Optimization Mechanism (MTOM).  
  
 The `binaryMessageEncoding` configuration section specifies the character encoding and message versioning used for binary-based XML messages. The binary message encoder encodes Windows Communication Foundation (WCF) messages in binary on the wire. While this encoding results in very fast transmission of messages, interoperability based on the WS-* standards is lost.  
  
 The `mtomMessageEncoding` configuration section specifies the character encoding and message versioning used for a message using a Message Transmission Optimization Mechanism (MTOM) encoding. (MTOM) is an efficient technology for transmitting binary data in Windows Communication Foundation (WCF) messages. The MTOM encoder attempts to strike a balance between efficiency and interoperability. The MTOM encoding transmits most XML in textual form, but optimizes large blocks of binary data by transmitting them as-is, without conversion to text.  
  
 The `textMessageEncoding` configuration section specifies a text encoder used to create text-based messages on the wire. Messages produced by this encoder are suitable for WS-* based interop. Web service or Web service client can generally understand textual XML. However, transmitting large blocks of binary data as text is the least efficient method for encoding XML messages  
  
## See Also  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 <xref:System.ServiceModel.Channels.MessageEncodingBindingElement>  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)  
 [Choosing a Message Encoder](../../../../../docs/framework/wcf/feature-details/choosing-a-message-encoder.md)
