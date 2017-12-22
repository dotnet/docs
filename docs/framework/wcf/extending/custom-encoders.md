---
title: "Custom Encoders"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fa0e1d7f-af36-4bf4-aac9-cd4eab95bc4f
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Custom Encoders
This topic discusses how to create custom encoders.  
  
 In [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)], you use a *binding* to specify how to transfer data across a network between endpoints. A binding is made up of a sequence of *binding elements*. A binding includes optional protocol binding elements such as security, a required *Message Encoder* binding element, and a required transport binding element. A message encoder is represented by a message encoding binding element. Three message encoders are included in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]: Binary, Message Transmission Optimization Mechanism (MTOM), and Text.  
  
 A message encoding binding element serializes an outgoing <xref:System.ServiceModel.Channels.Message> and passes it to the transport, or receives the serialized form of a message from the transport and passes it to the protocol layer if present, or to the application, if not present.  
  
 Message encoders transform <xref:System.ServiceModel.Channels.Message> instances to and from a wire representation. Although encoders are described as sitting above the transport layer in the channel stack, they reside inside the transport layer. Transports (for example HTTP) format the message according to the requirements of the transport standard. Encoders (for example Text Xml) just encode the message.  
  
 When connecting to a preexisting client or server, you may not have a choice about using a particular message encoding. However, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services can be made accessible through multiple endpoints, each with a different message encoder. When a single encoder does not cover the entire audience for your service, consider exposing your service over multiple endpoints. Client applications can then choose the endpoint that is best for them. Using multiple endpoints allows you to combine the advantages of different message encoders with other binding elements.  
  
## System-Provided Encoders  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides several system-provided bindings that are designed to cover the most common application scenarios. Each of these bindings combine a transport, message encoder, and other options (security, for example). This topic describes how to extend the `Text`, `Binary`, and `MTOM` message encoders that are included in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], or create your own custom encoder. The text message encoder supports both a plain XML encoding as well as SOAP encodings. The plain XML encoding mode of the text message encoder is called the POX ("Plain Old XML") encoder to distinguish it from the text-based SOAP encoding.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the combinations of binding elements provided by the system-provided bindings, see the corresponding section in [Choosing a Transport](../../../../docs/framework/wcf/feature-details/choosing-a-transport.md).  
  
## How to Work with System-Provided Encoders  
 An encoding is added to a binding using a class derived from <xref:System.ServiceModel.Channels.MessageEncodingBindingElement>.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides the following types of binding elements derived from the <xref:System.ServiceModel.Channels.MessageEncodingBindingElement> class that can provide for text, binary and Message Transmission Optimization Mechanism (MTOM) encoding:  
  
-   <xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement>: The most interoperable, but the least efficient encoder for XML messages. A Web service or Web service client can generally understand textual XML. However, transmitting large blocks of binary data as text is not efficient.  
  
-   <xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement>: Represents the binding element that specifies the character encoding and message versioning used for binary-based XML messages. This is most efficient of the encoding options, but the least interoperable, because it is only supported by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoints.  
  
-   <<!--zz xref:System.ServiceModel.Channels.MTOMMessageEncodingBindingElement --> `System.ServiceModel.Channels.MTOMMessageEncodingBindingElement`>: Represents the binding element that specifies the character encoding and message versioning used for a message using a Message Transmission Optimization Mechanism (MTOM) encoding. MTOM is an efficient technology for transmitting binary data in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] messages. The MTOM encoder attempts to balance between efficiency and interoperability. The MTOM encoding transmits most XML in textual form, but optimizes large blocks of binary data by transmitting them as-is, without conversion to text.  
  
 The binding element creates a binary, MTOM, or text <xref:System.ServiceModel.Channels.MessageEncoderFactory>. The factory creates a binary, MTOM, or text <xref:System.ServiceModel.Channels.MessageEncoderFactory> instance. Typically, there is only a single instance. However if sessions are used, a different encoder may be provided to each session. The Binary encoder makes use of this to coordinate dynamic dictionaries (see XML Infrastructure).  
  
 The <xref:System.ServiceModel.Channels.MessageEncoder.ReadMessage%2A> and <xref:System.ServiceModel.Channels.MessageEncoder.WriteMessage%2A> methods are the core of the encoders. The methods provide for reading a message from a stream or from a <xref:System.Byte> array. Byte arrays are used when the transport is operating in buffered mode. Messages are always written to streams. If the transport must buffer the message, it provides a stream that does the buffering.  
  
 The rest of the members work with support content, media types, and <xref:System.ServiceModel.Channels.MessageEncoder.MessageVersion%2A>. The transport calls these encoder methods to test whether the incoming message can be decoded by it, or to determine if the outgoing message is valid for this encoder.  
  
 Each of the three encoder implementations adds properties that are relevant to the specific encodings and is fully configurable. The encoders also expose reader quotas that have secure defaults. See XML Infrastructure for a discussion of the quotas.  
  
## Features of System-Provided Encoders  
 There are a number of features provided by the system-provided encoders.  
  
### Pooling  
 Each of the encoder implementations tries to pool as much as possible. Reducing allocations is a key way to improve the performance of managed code. To accomplish this pooling, the implementations use the `SynchronizedPool` class. The C# file contains a description of the additional optimizations used by this class.  
  
 `XmlDictionaryReader` and `XmlDictionaryWriter` instances are pooled and reinitialized to prevent allocating new ones for each message. For the readers, an `OnClose` callback reclaims the reader when `Close()` is called. The encoder also recycles some message state objects used when constructing messages. The sizes of these pools are configurable by the `MaxReadPoolSize` and `MaxWritePoolSize` properties on each of the three classes derived from <xref:System.ServiceModel.Channels.MessageEncodingBindingElement>.  
  
### Binary Encoding  
 When binary encoding uses sessions, the dynamic dictionary string must be communicated to the receiver of the message. This is done by prefixing the message with the dynamic dictionary strings. The receiver strips off the strings, adds them to the session, and processes the message. Correctly passing dictionary strings requires that the transport be buffered.  
  
 The strings are appended to the message by an internal `AddSessionInformationToMessage` method. It adds the strings as UTF-8 to the front of the message prefixed with their length. The entire dictionary header is then prefixed with the length of its data. The reverse operation is performed by an internal `ExtractSessionInformationFromMessage` method.  
  
 In addition to processing dynamic dictionary keys, buffered sessionful messages are received in a unique way. Instead of creating a reader over the document and processing it, the binary encoder uses the internal `MessagePatterns` class to deconstruct the binary stream. The idea is that most messages have a certain set of headers that show up in a certain order when generated by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. The pattern system breaks the message apart based on what it expects. If it is successful, it initializes a <xref:System.ServiceModel.Channels.MessageHeaders> object without parsing the XML. If not, it falls back to the standard method.  
  
### MTOM Encoding  
 The <<!--zz xref:System.ServiceModel.Channels.MTOMMessageEncodingBindingElement --> `System.ServiceModel.Channels.MTOMMessageEncodingBindingElement`> class has an additional configuration property called <<!--zz xref:System.ServiceModel.Channels.MTOMMessageEncodingBindingElement --> `System.ServiceModel.Channels.MTOMMessageEncodingBindingElement`.MaxBufferSize%2A>. This places an upper bound on how much data it is allowed to buffer during the process of reading a message. The XML Information Set (Infoset), or other MIME parts, may need to be buffered to reassemble all the MIME parts into a single message.  
  
 To work correctly with HTTP, the internal MTOM message encoder class provides some internal APIs for `GetContentType` (which is also internal) and `WriteMessage`, which is public and can be overridden. More communication must occur to ensure values in the HTTP headers agree with values in the MIME headers.  
  
 Internally, the MTOM message encoder uses [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]'s text readers, and is similar to the Text encoder. The main difference is that it optimizes large chunks of binary, or "Binary Large Objects" (BLOBs), by not converting them to Base-64 encoding prior to being embedded into the message bytes. Instead, these BLOBs are kept extracted, and referenced as the MIME attachments.  
  
## Writing your own Encoder  
 To implement your own custom message encoder, you must provide custom implementations of the following abstract base classes:  
  
-   <xref:System.ServiceModel.Channels.MessageEncoder>  
  
-   <xref:System.ServiceModel.Channels.MessageEncoderFactory>  
  
-   <xref:System.ServiceModel.Channels.MessageEncodingBindingElement>  
  
 Converting from the in-memory representation of a message to a representation that can be written to a stream is encapsulated within the <xref:System.ServiceModel.Channels.MessageEncoder> class, which serves as a factory for XML readers and XML writers that support specific types of XML encodings.  
  
-   The key methods of this class that you must override are:  
  
-   <xref:System.ServiceModel.Channels.MessageEncoder.WriteMessage%2A> which takes a <xref:System.ServiceModel.Channels.MessageEncodingBindingElement> object and writes it into a <xref:System.IO.Stream> object.  
  
-   <xref:System.ServiceModel.Channels.MessageEncoder.ReadMessage%2A> which takes a <xref:System.IO.Stream> object and a maximum header size and returns a <xref:System.ServiceModel.Channels.Message> object.  
  
 It is the code you write in these methods that handles conversion between the standard transport protocol, and your customized encoding.  
  
 Next you need to code a factory class that creates your custom encoder. Override the <xref:System.ServiceModel.Channels.MessageEncoderFactory.Encoder%2A> to return an instance of your custom <xref:System.ServiceModel.Channels.MessageEncoder>.  
  
 Then connect your custom <xref:System.ServiceModel.Channels.MessageEncoderFactory> to the binding element stack used to configure the service or client by overriding the <xref:System.ServiceModel.Channels.MessageEncodingBindingElement.CreateMessageEncoderFactory%2A> method to return an instance of this factory.  
  
 There are two samples provided with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] that illustrate this process with sample code: [Custom Message Encoder: Custom Text Encoder](../../../../docs/framework/wcf/samples/custom-message-encoder-custom-text-encoder.md) and [Custom Message Encoder: Compression Encoder](../../../../docs/framework/wcf/samples/custom-message-encoder-compression-encoder.md).  
  
## See Also  
 <xref:System.ServiceModel.Channels.MessageEncodingBindingElement>  
 <xref:System.ServiceModel.Channels.MessageEncoderFactory>  
 <xref:System.ServiceModel.Channels.MessageEncoder>  
 [Data Transfer Architectural Overview](../../../../docs/framework/wcf/feature-details/data-transfer-architectural-overview.md)  
 [Choosing a Message Encoder](../../../../docs/framework/wcf/feature-details/choosing-a-message-encoder.md)  
 [Choosing a Transport](../../../../docs/framework/wcf/feature-details/choosing-a-transport.md)
