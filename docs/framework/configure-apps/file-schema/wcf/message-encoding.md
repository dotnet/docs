---
description: "Learn more about: Message Encoding"
title: "Message Encoding"
ms.date: "03/30/2017"
ms.assetid: f30ee941-aca9-4c67-82a5-421568496f07
---
# Message Encoding

Encoding is the process of transforming a set of Unicode characters into a sequence of bytes. Decoding is the reverse process. Windows Communication Foundation (WCF) includes three types of encoding for SOAP messages: Text, Binary and Message Transmission Optimization Mechanism (MTOM).  
  
 The `binaryMessageEncoding` configuration section specifies the character encoding and message versioning used for binary-based XML messages. The binary message encoder encodes Windows Communication Foundation (WCF) messages in binary on the wire. While this encoding results in very fast transmission of messages, interoperability based on the WS-* standards is lost.  
  
 The `mtomMessageEncoding` configuration section specifies the character encoding and message versioning used for a message using a Message Transmission Optimization Mechanism (MTOM) encoding. (MTOM) is an efficient technology for transmitting binary data in Windows Communication Foundation (WCF) messages. The MTOM encoder attempts to strike a balance between efficiency and interoperability. The MTOM encoding transmits most XML in textual form, but optimizes large blocks of binary data by transmitting them as-is, without conversion to text.  
  
 The `textMessageEncoding` configuration section specifies a text encoder used to create text-based messages on the wire. Messages produced by this encoder are suitable for WS-* based interop. Web service or Web service client can generally understand textual XML. However, transmitting large blocks of binary data as text is the least efficient method for encoding XML messages  
  
## See also

- <xref:System.ServiceModel.Channels.CustomBinding>
- <xref:System.ServiceModel.Channels.MessageEncodingBindingElement>
- [Bindings](../../../wcf/bindings.md)
- [Extending Bindings](../../../wcf/extending/extending-bindings.md)
- [Custom Bindings](../../../wcf/extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
- [Choosing a Message Encoder](../../../wcf/feature-details/choosing-a-message-encoder.md)
