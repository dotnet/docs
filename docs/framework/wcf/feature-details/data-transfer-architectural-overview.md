---
title: "Data Transfer Architectural Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "data transfer [WCF], architectural overview"
ms.assetid: 343c2ca2-af53-4936-a28c-c186b3524ee9
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Data Transfer Architectural Overview
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] can be thought of as a messaging infrastructure. It can receive messages, process them, and dispatch them to user code for further action, or it can construct messages from data given by user code and deliver them to a destination. This topic, which is intended for advanced developers, describes the architecture for handling messages and the contained data. For a simpler, task-oriented view of how to send and receive data, see [Specifying Data Transfer in Service Contracts](../../../../docs/framework/wcf/feature-details/specifying-data-transfer-in-service-contracts.md).  
  
> [!NOTE]
>  This topic discusses [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implementation details that are not visible by examining the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] object model. Two words of caution are in order with regard to documented implementation details. First, the descriptions are simplified; actual implementation may be more complex due to optimizations or other reasons. Second, you should never rely on specific implementation details, even documented ones, because these may change without notice from version to version or even in a servicing release.  
  
## Basic Architecture  
 At the core of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] message-handling capabilities is the <xref:System.ServiceModel.Channels.Message> class, which is described in detail in [Using the Message Class](../../../../docs/framework/wcf/feature-details/using-the-message-class.md). The run-time components of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] can be divided into two major parts: the channel stack and the service framework, with the <xref:System.ServiceModel.Channels.Message> class being the connection point.  
  
 The channel stack is responsible for converting between a valid <xref:System.ServiceModel.Channels.Message> instance and some action that corresponds to the sending or receiving of message data. On the sending side, the channel stack takes a valid <xref:System.ServiceModel.Channels.Message> instance and, after some processing, performs some action that logically corresponds to sending the message. The action may be sending TCP or HTTP packets, queuing the message in Message Queuing, writing the message to a database, saving it to a file share, or any other action, depending on the implementation. The most common action is sending the message over a network protocol. On the receive side, the opposite happens—an action is detected (which may be TCP or HTTP packets arriving or any other action), and, after processing, the channel stack converts this action into a valid <xref:System.ServiceModel.Channels.Message> instance.  
  
 You can use [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] by using the <xref:System.ServiceModel.Channels.Message> class and the channel stack directly. However, doing so is difficult and time-consuming. Additionally, the <xref:System.ServiceModel.Channels.Message> object provides no metadata support, so you cannot generate strongly typed [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] clients if you use [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] in this manner.  
  
 Therefore, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] includes a service framework that provides an easy-to-use programming model that you can use to construct and receive `Message` objects. The service framework maps services to [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] types through the notion of service contracts, and dispatches messages to user operations that are simply [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] methods marked with the <xref:System.ServiceModel.OperationContractAttribute> attribute (for more details, see [Designing Service Contracts](../../../../docs/framework/wcf/designing-service-contracts.md)). These methods may have parameters and return values. On the service side, the service framework converts incoming <xref:System.ServiceModel.Channels.Message> instances into parameters and converts return values into outgoing <xref:System.ServiceModel.Channels.Message> instances. On the client side, it does the opposite. For example, consider the `FindAirfare` operation below.  
  
 [!code-csharp[c_DataArchitecture#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_dataarchitecture/cs/source.cs#1)]
 [!code-vb[c_DataArchitecture#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_dataarchitecture/vb/source.vb#1)]  
  
 Suppose `FindAirfare` is called on the client. The service framework on the client converts the `FromCity` and `ToCity` parameters into an outgoing <xref:System.ServiceModel.Channels.Message> instance and passes it to the channel stack to be sent.  
  
 On the service side, when a <xref:System.ServiceModel.Channels.Message> instance arrives from the channel stack, the service framework extracts the relevant data from the message to populate the `FromCity` and `ToCity` parameters and then calls the service-side `FindAirfare` method. When the method returns, the service framework takes the returned integer value and the `IsDirectFlight` output parameter and creates a <xref:System.ServiceModel.Channels.Message> object instance that contains this information. It then passes the `Message` instance to the channel stack to be sent back to the client.  
  
 On the client side, a <xref:System.ServiceModel.Channels.Message> instance that contains the response message emerges from the channel stack. The service framework extracts the return value and the `IsDirectFlight` value and returns these to the caller of the client.  
  
## Message Class  
 The <xref:System.ServiceModel.Channels.Message> class is intended to be an abstract representation of a message, but its design is strongly tied to the SOAP message. A <xref:System.ServiceModel.Channels.Message> contains three major pieces of information: a message body, message headers, and message properties.  
  
## Message Body  
 The message body is intended to represent the actual data payload of the message. The message body is always represented as an XML Infoset. This does not mean that all messages created or received in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] must be in XML format. It is up to the channel stack to decide how to interpret the message body. It may emit it as XML, convert it to some other format, or even omit it entirely. Of course, with most of the bindings [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supplies, the message body is represented as XML content in the body section of a SOAP envelope.  
  
 It is important to realize that the `Message` class does not necessarily contain a buffer with XML data representing the body. Logically, `Message` contains an XML Infoset, but this Infoset may be dynamically constructed and may never physically exist in memory.  
  
### Putting Data into the Message Body  
 There is no uniform mechanism to put data into a message body. The <xref:System.ServiceModel.Channels.Message> class has an abstract method, <xref:System.ServiceModel.Channels.Message.OnWriteBodyContents%28System.Xml.XmlDictionaryWriter%29>, which takes an <xref:System.Xml.XmlDictionaryWriter>. Each subclass of the <xref:System.ServiceModel.Channels.Message> class is responsible for overriding this method and writing out its own contents. The message body logically contains the XML Infoset that `OnWriteBodyContent` produces. For example, consider the following `Message` subclass.  
  
 [!code-csharp[c_DataArchitecture#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_dataarchitecture/cs/source.cs#2)]
 [!code-vb[c_DataArchitecture#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_dataarchitecture/vb/source.vb#2)]  
  
 Physically, an `AirfareRequestMessage` instance contains only two strings ("fromCity" and "toCity"). However, logically the message contains the following XML infoset:  
  
```xml  
<airfareRequest>  
    <from>Tokyo</from>  
    <to>London</to>  
</airfareRequest>  
```  
  
 Of course, you would normally not create messages in this manner, because you can use the service framework to create a message like the preceding one from operation contract parameters. Additionally, the <xref:System.ServiceModel.Channels.Message> class has static `CreateMessage` methods that you can use to create messages with common types of content: an empty message, a message that contains an object serialized to XML with the <xref:System.Runtime.Serialization.DataContractSerializer>, a message that contains a SOAP fault, a message that contains XML represented by an <xref:System.Xml.XmlReader>, and so on.  
  
### Getting Data from a Message Body  
 You can extract the data stored in a message body in two main ways:  
  
-   You can get the entire message body at one time by calling the <xref:System.ServiceModel.Channels.Message.WriteBodyContents%28System.Xml.XmlDictionaryWriter%29> method and passing in an XML writer. The complete message body is written out to this writer. Getting the entire message body at one time is also called *writing a message*. Writing is done primarily by the channel stack when sending messages—some part of the channel stack will usually get access to the entire message body, encode it, and send it.  
  
-   Another way to get information out of the message body is to call <xref:System.ServiceModel.Channels.Message.GetReaderAtBodyContents> and get an XML reader. The message body can then be accessed sequentially as needed by calling methods on the reader. Getting the message body piece-by-piece is also called *reading a message*. Reading the message is primarily used by the service framework when receiving messages. For example, when the <xref:System.Runtime.Serialization.DataContractSerializer> is in use, the service framework will get an XML reader over the body and pass it to the deserialization engine, which will then start reading the message element-by-element and constructing the corresponding object graph.  
  
 A message body can be retrieved only once. This makes it possible to work with forward-only streams. For example, you can write an <xref:System.ServiceModel.Channels.Message.OnWriteBodyContents%28System.Xml.XmlDictionaryWriter%29> override that reads from a <xref:System.IO.FileStream> and returns the results as an XML Infoset. You will never need to "rewind" to the beginning of the file.  
  
 The `WriteBodyContents` and `GetReaderAtBodyContents` methods simply check that the message body has never been retrieved before, and then call `OnWriteBodyContents` or `OnGetReaderAtBodyContents`, respectively.  
  
## Message Usage in WCF  
 Most messages can be classified as either *outgoing* (those that are created by the service framework to be sent by the channel stack) or *incoming* (those that arrive from the channel stack and are interpreted by the service framework). Furthermore, the channel stack can operate in either buffered or streaming mode. The service framework may also expose a streamed or nonstreamed programming model. This leads to the cases listed in the following table, along with simplified details of their implementation.  
  
|Message type|Body data in message|Write (OnWriteBodyContents) implementation|Read (OnGetReaderAtBodyContents) Implementation|  
|------------------|--------------------------|--------------------------------------------------|-------------------------------------------------------|  
|Outgoing, created from nonstreamed programming model|The data needed to write the message (for example, an object and the <xref:System.Runtime.Serialization.DataContractSerializer> instance needed to serialize it)*|Custom logic to write out the message based on the stored data (for example, call `WriteObject` on the `DataContractSerializer` if that is the serializer in use)*|Call `OnWriteBodyContents`, buffer the results, return an XML reader over the buffer|  
|Outgoing, created from streamed programming model|The `Stream` with the data to be written*|Write out data from the stored stream using the <xref:System.Xml.IStreamProvider> mechanism*|Call `OnWriteBodyContents`, buffer the results, return an XML reader over the buffer|  
|Incoming from streaming channel stack|A `Stream` object that represents the data coming in over the network with an <xref:System.Xml.XmlReader> over it|Write out the contents from the stored `XmlReader` using `WriteNode`|Returns the stored `XmlReader`|  
|Incoming from nonstreaming channel stack|A buffer that contains body data with an `XmlReader` over it|Writes out the contents from the stored `XmlReader` using `WriteNode`|Returns the stored lang|  
  
 \* These items are not implemented directly in `Message` subclasses, but in subclasses of the <xref:System.ServiceModel.Channels.BodyWriter> class. For more information about the <xref:System.ServiceModel.Channels.BodyWriter>, see [Using the Message Class](../../../../docs/framework/wcf/feature-details/using-the-message-class.md).  
  
## Message Headers  
 A message may contain headers. A header logically consists of an XML Infoset that is associated with a name, a namespace, and a few other properties. Message headers are accessed using the `Headers` property on <xref:System.ServiceModel.Channels.Message>. Each header is represented by a <xref:System.ServiceModel.Channels.MessageHeader> class. Normally, message headers are mapped to SOAP message headers when using a channel stack configured to work with SOAP messages.  
  
 Putting information into a message header and extracting information from it is similar to using the message body. The process is somewhat simplified because streaming is not supported. It is possible to access the contents of the same header more than once, and headers can be accessed in arbitrary order, forcing headers to always be buffered. There is no general-purpose mechanism available to get an XML reader over a header, but there is a `MessageHeader` subclass internal to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] that represents a readable header with such a capability. This type of `MessageHeader` is created by the channel stack when a message with custom application headers comes in. This enables the service framework to use a deserialization engine, such as the <xref:System.Runtime.Serialization.DataContractSerializer>, to interpret these headers.  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Using the Message Class](../../../../docs/framework/wcf/feature-details/using-the-message-class.md).  
  
## Message Properties  
 A message may contain properties. A *property* is any [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] object that is associated with a string name. Properties are accessed through the `Properties` property on `Message`.  
  
 Unlike the message body and message headers (which normally map to the SOAP body and SOAP headers, respectively), message properties are normally not sent or received along with the messages. Message properties exist primarily as a communication mechanism to pass data about the message between the various channels in the channel stack, and between the channel stack and the service model.  
  
 For example, the HTTP transport channel included as part of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is capable of producing various HTTP status codes, such as "404 (Not Found)" and "500 (Internal Server Error)," when it sends replies to clients. Before sending a reply message, it checks to see whether the `Properties` of the `Message` contain a property called "httpResponse" that contains an object of type <xref:System.ServiceModel.Channels.HttpResponseMessageProperty>. If such a property is found, it will look at the <xref:System.ServiceModel.Channels.HttpResponseMessageProperty.StatusCode%2A> property and use that status code. If it is not found, the default "200 (OK)" code is used.  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Using the Message Class](../../../../docs/framework/wcf/feature-details/using-the-message-class.md).  
  
### The Message as a Whole  
 So far, we have discussed methods for accessing the various parts of the message in isolation. However, the <xref:System.ServiceModel.Channels.Message> class also provides methods to work with the entire message as a whole. For example, the `WriteMessage` method writes out the entire message to an XML writer.  
  
 For this to be possible, a mapping must be defined between the entire `Message` instance and an XML Infoset. Such a mapping, in fact, exists: [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the SOAP standard to define this mapping. When a `Message` instance is written out as an XML Infoset, the resulting Infoset is the valid SOAP envelope that contains the message. Thus, `WriteMessage` would normally perform the following steps:  
  
1.  Write the SOAP envelope element opening tag.  
  
2.  Write the SOAP header element opening tag, write out all of the headers, and close the header element.  
  
3.  Write the SOAP body element opening tag.  
  
4.  Call `WriteBodyContents` or an equivalent method to write out the body.  
  
5.  Close the body and envelope elements.  
  
 The preceding steps are closely tied to the SOAP standard. This is complicated by the fact that multiple versions of SOAP exist, for example, it is impossible to write out the SOAP envelope element correctly without knowing the SOAP version in use. Also, in some cases, it may be desirable to turn off this complex SOAP-specific mapping completely.  
  
 For these purposes, a `Version` property is provided on `Message`. It can be set to the SOAP version to use when writing out the message, or it can be set to `None` to prevent any SOAP-specific mappings. If the `Version` property is set to `None`, methods that work with the entire message act as if the message consisted of its body only, for example, `WriteMessage` would simply call `WriteBodyContents` instead of performing the multiple steps listed above. It is expected that on incoming messages, `Version` will be auto-detected and set correctly.  
  
## The Channel Stack  
  
### Channels  
 As stated before, the channel stack is responsible for converting outgoing <xref:System.ServiceModel.Channels.Message> instances into some action (such as sending packets over the network), or converting some action (such as receiving network packets) into incoming `Message` instances.  
  
 The channel stack is composed of one or more channels ordered in a sequence. An outgoing `Message` instance is passed to the first channel in the stack (also called the *topmost channel*), which passes it to the next channel down in stack, and so on. The message terminates in the last channel, which is called the *transport channel*. Incoming messages originate in the transport channel and are passed from channel to channel up the stack. From the topmost channel, the message is usually passed into the service framework. While this is the usual pattern for application messages, some channels may work slightly differently, for example, they may send their own infrastructure messages without being passed a message from a channel above.  
  
 Channels may operate on the message in various ways as it passes through the stack. The most common operation is adding a header to an outgoing message and reading headers on an incoming message. For example, a channel may compute the digital signature of a message and add it as a header. A channel may also inspect this digital signature header on incoming messages and block messages that do not have a valid signature from making their way up the channel stack. Channels also often set or inspect message properties. The message body is usually not modified, although this is allowed, for example, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security channel can encrypt the message body.  
  
### Transport Channels and Message Encoders  
 The bottommost channel in the stack is responsible for actually transforming an outgoing <xref:System.ServiceModel.Channels.Message>, as modified by other channels, into some action. On the receive side, this is the channel that converts some action into a `Message` that other channels process.  
  
 As stated previously, the actions may be varied: sending or receiving network packets over various protocols, reading or writing the message in a database, or queuing or dequeuing the message in a Message Queuing queue, to provide but a few examples. All these actions have one thing in common: they require a transformation between the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]`Message` instance and an actual group of bytes that can be sent, received, read, written, queued, or dequeued. The process of converting a `Message` into a group of bytes is called *encoding*, and the reverse process of creating a `Message` from a group of bytes is called *decoding*.  
  
 Most transport channels use components called *message encoders* to accomplish the encoding and decoding work. A message encoder is a subclass of the <xref:System.ServiceModel.Channels.MessageEncoder> class. `MessageEncoder` includes various `ReadMessage` and `WriteMessage` method overloads to convert between `Message` and groups of bytes.  
  
 On the sending side, a buffering transport channel passes the `Message` object that it received from a channel above it to `WriteMessage`. It gets back an array of bytes, which it then uses to perform its action (such as packaging these bytes as valid TCP packets and sending them to the correct destination). A streaming transport channel first creates a `Stream` (for example, over the outgoing TCP connection), and then passes both the `Stream` and the `Message` it needs to send to the appropriate `WriteMessage` overload, which writes out the message.  
  
 On the receiving side, a buffering transport channel extracts incoming bytes (for example, from incoming TCP packets) into an array and calls `ReadMessage` to get a `Message` object that it can pass further up the channel stack. A streaming transport channel creates a `Stream` object (for example, a network stream over the incoming TCP connection) and passes that to `ReadMessage` to get back a `Message` object.  
  
 The separation between the transport channels and the message encoder is not mandatory; it is possible to write a transport channel that does not use a message encoder. However, the advantage of this separation is ease of composition. As long as a transport channel uses only the base <xref:System.ServiceModel.Channels.MessageEncoder>, it can work with any [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] or third-party message encoder. Likewise, the same encoder can normally be used in any transport channel.  
  
### Message Encoder Operation  
 To describe the typical operation of an encoder, it is useful to consider the following four cases.  
  
|Operation|Comment|  
|---------------|-------------|  
|Encoding, Buffered|In buffered mode, the encoder normally creates a variable-size buffer and then creates an XML writer over it. It then calls <xref:System.ServiceModel.Channels.Message.WriteMessage%28System.Xml.XmlWriter%29> on the message being encoded, which writes out the headers and then the body using <xref:System.ServiceModel.Channels.Message.WriteBodyContents%28System.Xml.XmlDictionaryWriter%29>, as explained in the preceding section about `Message` in this topic. The contents of the buffer (represented as an array of bytes) are then returned for the transport channel to use.|  
|Encoding, Streamed|In streamed mode, the operation is similar to the above, but simpler. There is no need for a buffer. An XML writer is normally created over the stream and <xref:System.ServiceModel.Channels.Message.WriteMessage%28System.Xml.XmlWriter%29> is called on the `Message` to write it out to this writer.|  
|Decoding, Buffered|When decoding in buffered mode, a special `Message` subclass that contains the buffered data is normally created. The headers of the message are read, and an XML reader positioned on the message body is created. This is the reader that will be returned with <xref:System.ServiceModel.Channels.Message.GetReaderAtBodyContents>.|  
|Decoding, Streamed|When decoding in streamed mode, a special Message subclass is normally created. The stream is advanced just enough to read all the headers and position it on the message body. An XML reader is then created over the stream. This is the reader that will be returned with <xref:System.ServiceModel.Channels.Message.GetReaderAtBodyContents>.|  
  
 Encoders can perform other functions as well. For example, the encoders can pool XML readers and writers. It is expensive to create a new XML reader or writer every time one is needed. Therefore, encoders normally maintain a pool of readers and a pool of writers of configurable size. In the descriptions of encoder operation described previously, whenever the phrase "create an XML reader/writer" is used, it normally means "take one from the pool, or create one if one is not available." The encoder (and the `Message` subclasses it creates while decoding) contain logic to return readers and writers to the pools once they are no longer needed (for example, when the `Message` is closed).  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides three message encoders, although it is possible to create additional custom types. The supplied types are Text, Binary, and Message Transmission Optimization Mechanism (MTOM). These are described in detail in [Choosing a Message Encoder](../../../../docs/framework/wcf/feature-details/choosing-a-message-encoder.md).  
  
### The IStreamProvider Interface  
 When writing an outgoing message that contains a streamed body to an XML writer, the <xref:System.ServiceModel.Channels.Message> uses a sequence of calls similar to the following in its <xref:System.ServiceModel.Channels.Message.OnWriteBodyContents%28System.Xml.XmlDictionaryWriter%29> implementation:  
  
-   Write any necessary information preceding the stream (for example, the opening XML tag).  
  
-   Write the stream.  
  
-   Write any information following the stream (for example, the closing XML tag).  
  
 This works well with encodings that are similar to the textual XML encoding. However, some encodings do not place XML Infoset information (for example, tags for starting and ending XML elements) together with the data contained within elements. For example, in the MTOM encoding, the message is split into multiple parts. One part contains the XML Infoset, which may contain references to other parts for actual element contents. The XML Infoset is normally small compared to the streamed contents, so it makes sense to buffer the Infoset, write it out, and then write the contents in a streamed way. This means that by the time the closing element tag is written, the stream should not have been written out yet.  
  
 For this purpose, the <xref:System.Xml.IStreamProvider> interface is used. The interface has a <xref:System.Xml.IStreamProvider.GetStream> method that returns the stream to be written. The correct way to write out a streamed message body in <xref:System.ServiceModel.Channels.Message.OnWriteBodyContents%28System.Xml.XmlDictionaryWriter%29> is as follows:  
  
1.  Write any necessary information preceding the stream (for example, the opening XML tag).  
  
2.  Call the `WriteValue` overload on the <xref:System.Xml.XmlDictionaryWriter> that takes an <xref:System.Xml.IStreamProvider>, with an `IStreamProvider` implementation that returns the stream to be written.  
  
3.  Write any information following the stream (for example, the closing XML tag).  
  
 With this approach, the XML writer has a choice of when to call <xref:System.Xml.IStreamProvider.GetStream> and write out the streamed data. For example, the textual and binary XML writers will call it immediately and write out the streamed contents in-between the start and end tags. The MTOM writer may decide to call <xref:System.Xml.IStreamProvider.GetStream> later, when it is ready to write the appropriate part of the message.  
  
## Representing Data in the Service Framework  
 As stated in the "Basic Architecture" section of this topic, the service framework is the part of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] that, among other things, is responsible for converting between a user-friendly programming model for message data and actual `Message` instances. Normally, a message exchange is represented in the service framework as a [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] method marked with the <xref:System.ServiceModel.OperationContractAttribute> attribute. The method can take in some parameters and can return a return value or out parameters (or both). On the service side, the input parameters represent the incoming message, and the return value and out parameters represent the outgoing message. On the client side, the reverse is true. The programming model for describing messages using parameters and the return value is described in detail in [Specifying Data Transfer in Service Contracts](../../../../docs/framework/wcf/feature-details/specifying-data-transfer-in-service-contracts.md). However, this section will provide a brief overview.  
  
## Programming Models  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service framework supports five different programming models for describing messages:  
  
### 1. The Empty Message  
 This is the simplest case. To describe an empty incoming message, do not use any input parameters.  
  
 [!code-csharp[C_DataArchitecture#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_dataarchitecture/cs/source.cs#3)]
 [!code-vb[C_DataArchitecture#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_dataarchitecture/vb/source.vb#3)]  
  
 To describe an empty outgoing message, use a void return value and do not use any out parameters:  
  
 [!code-csharp[C_DataArchitecture#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_dataarchitecture/cs/source.cs#4)]
 [!code-vb[C_DataArchitecture#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_dataarchitecture/vb/source.vb#4)]  
  
 Note that this is different from a one-way operation contract:  
  
 [!code-csharp[C_DataArchitecture#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_dataarchitecture/cs/source.cs#5)]
 [!code-vb[C_DataArchitecture#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_dataarchitecture/vb/source.vb#5)]  
  
 In the `SetDesiredTemperature` example, a two-way message exchange pattern is described. A message is returned from the operation, but it is empty. It is possible to return a fault from the operation. In the "Set Lightbulb" example, the message exchange pattern is one-way, so there is no outgoing message to describe. The service cannot communicate any status back to the client in this case.  
  
### 2. Using the Message Class Directly  
 It is possible to use the <xref:System.ServiceModel.Channels.Message> class (or one of its subclasses) directly in an operation contract. In this case, the service framework just passes the `Message` from the operation to the channel stack and vice versa, with no further processing.  
  
 There are two main use cases for using `Message` directly. You can use this for advanced scenarios, when none of the other programming models gives you enough flexibility to describe your message. For example, you might want to use files on disk to describe a message, with the file’s properties becoming message headers and the file’s contents becoming the message body. You can then create something similar to the following.  
  
 [!code-csharp[C_DataArchitecture#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_dataarchitecture/cs/source.cs#6)]
 [!code-vb[C_DataArchitecture#6](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_dataarchitecture/vb/source.vb#6)]  
  
 The second common use for `Message` in an operation contract is when a service does not care about the particular message contents and acts on the message as on a black box. For example, you might have a service that forwards messages to multiple other recipients. The contract can be written as follows.  
  
 [!code-csharp[C_DataArchitecture#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_dataarchitecture/cs/source.cs#7)]
 [!code-vb[C_DataArchitecture#7](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_dataarchitecture/vb/source.vb#7)]  
  
 The Action="*" line effectively turns off message dispatching and ensures that all messages sent to the `IForwardingService` contract make their way to the `ForwardMessage` operation. (Normally, the dispatcher would examine the message’s "Action" header to determine which operation it is intended for. Action="\*" means "all possible values of the Action header".) The combination of Action="\*" and using Message as a parameter is known as the "universal contract" because it is able to receive all possible messages. To be able to send all possible messages, use Message as the return value and set `ReplyAction` to "\*". This will prevent the service framework from adding its own Action header, enabling you to control this header using the `Message` object you return.  
  
### 3. Message Contracts  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides a declarative programming model for describing messages, called *message contracts*. This model is described in detail in [Using Message Contracts](../../../../docs/framework/wcf/feature-details/using-message-contracts.md). Essentially, the entire message is represented by a single [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] type that uses attributes like the <xref:System.ServiceModel.MessageBodyMemberAttribute> and <xref:System.ServiceModel.MessageHeaderAttribute> to describe which parts of the message contract class should map to which part of the message.  
  
 Message contracts provide a lot of control over the resulting `Message` instances (although obviously not as much control as using the `Message` class directly). For example, message bodies are often composed of multiple pieces of information, each represented by its own XML element. These elements can either occur directly in the body (*bare* mode) or can be *wrapped* in an encompassing XML element. Using the message contract programming model enables you to make the bare-versus-wrapped decision and control the name of the wrapper name and namespace.  
  
 The following code example of a message contract demonstrates these features.  
  
 [!code-csharp[C_DataArchitecture#9](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_dataarchitecture/cs/source.cs#9)]
 [!code-vb[C_DataArchitecture#9](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_dataarchitecture/vb/source.vb#9)]  
  
 Items marked to be serialized (with the <xref:System.ServiceModel.MessageBodyMemberAttribute>, <xref:System.ServiceModel.MessageHeaderAttribute>, or other related attributes) must be serializable to participate in a message contract. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the "Serialization" section later in this topic.  
  
### 4. Parameters  
 Often, a developer who wants to describe an operation that acts on multiple pieces of data does not need the degree of control that message contracts provide. For example, when creating new services, one does not usually want to make the bare-versus-wrapped decision and decide on the wrapper element name. Making these decisions often requires deep knowledge of Web services and SOAP.  
  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service framework can automatically pick the best and most interoperable SOAP representation for sending or receiving multiple related pieces of information, without forcing these choices on the user. This is accomplished by simply describing these pieces of information as parameters or return values of an operation contract. For example, consider the following operation contract.  
  
 [!code-csharp[C_DataArchitecture#11](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_dataarchitecture/cs/source.cs#11)]
 [!code-vb[C_DataArchitecture#11](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_dataarchitecture/vb/source.vb#11)]  
  
 The service framework automatically decides to put all three pieces of information (`customerID`, `item`, and `quantity`) into the message body and wrap them in a wrapper element named `SubmitOrderRequest`.  
  
 Describing the information to be sent or received as a simple list of operation contract parameters is the recommended approach, unless special reasons exist to move to the more-complex message contract or `Message`-based programming models.  
  
### 5. Stream  
 Using `Stream` or one of its subclasses in an operation contract or as a sole message body part in a message contract can be considered a separate programming model from the ones described above. Using `Stream` in this way is the only way to guarantee that your contract will be usable in a streamed fashion, short of writing your own streaming-compatible `Message` subclass. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Large Data and Streaming](../../../../docs/framework/wcf/feature-details/large-data-and-streaming.md).  
  
 When `Stream` or one of its subclasses is used in this way, the serializer is not invoked. For outgoing messages, a special streaming `Message` subclass is created and the stream is written out as described in the section on the <xref:System.Xml.IStreamProvider> interface. For incoming messages, the service framework creates a `Stream` subclass over the incoming message and provides it to the operation.  
  
## Programming Model Restrictions  
 The programming models described above cannot be arbitrarily combined. For example, if an operation accepts a message contract type, the message contract must be its only input parameter. Furthermore, the operation must then either return an empty message (return type of void) or another message contract. These programming model restrictions are described in the topics for each specific programming model: [Using Message Contracts](../../../../docs/framework/wcf/feature-details/using-message-contracts.md), [Using the Message Class](../../../../docs/framework/wcf/feature-details/using-the-message-class.md), and [Large Data and Streaming](../../../../docs/framework/wcf/feature-details/large-data-and-streaming.md).  
  
## Message Formatters  
 The programming models described above are supported by plugging in components called *message formatters* into the service framework. Message formatters are types that implement the <xref:System.ServiceModel.Dispatcher.IClientMessageFormatter> or <xref:System.ServiceModel.Dispatcher.IDispatchMessageFormatter> interface, or both, for use in clients and service [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] clients, respectively.  
  
 Message formatters are normally plugged in by behaviors. For example, the <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior> plugs in the data contract message formatter. This is done on the service side by setting <xref:System.ServiceModel.Dispatcher.DispatchOperation.Formatter%2A> to the correct formatter in the <xref:System.ServiceModel.Description.IOperationBehavior.ApplyDispatchBehavior%28System.ServiceModel.Description.OperationDescription%2CSystem.ServiceModel.Dispatcher.DispatchOperation%29> method, or on the client side by setting <xref:System.ServiceModel.Dispatcher.ClientOperation.Formatter%2A> to the correct formatter in the <xref:System.ServiceModel.Description.IOperationBehavior.ApplyClientBehavior%28System.ServiceModel.Description.OperationDescription%2CSystem.ServiceModel.Dispatcher.ClientOperation%29> method.  
  
 The following tables lists the methods that a message formatter may implement.  
  
|Interface|Method|Action|  
|---------------|------------|------------|  
|<xref:System.ServiceModel.Dispatcher.IDispatchMessageFormatter>|<xref:System.ServiceModel.Dispatcher.IDispatchMessageFormatter.DeserializeRequest%28System.ServiceModel.Channels.Message%2CSystem.Object%5B%5D%29>|Converts an incoming `Message` to operation parameters|  
|<xref:System.ServiceModel.Dispatcher.IDispatchMessageFormatter>|<xref:System.ServiceModel.Dispatcher.IDispatchMessageFormatter.SerializeReply%28System.ServiceModel.Channels.MessageVersion%2CSystem.Object%5B%5D%2CSystem.Object%29>|Creates an outgoing `Message` from operation return value/out parameters|  
|<xref:System.ServiceModel.Dispatcher.IClientMessageFormatter>|<xref:System.ServiceModel.Dispatcher.IClientMessageFormatter.SerializeRequest%28System.ServiceModel.Channels.MessageVersion%2CSystem.Object%5B%5D%29>|Creates an outgoing `Message` from operation parameters|  
|<xref:System.ServiceModel.Dispatcher.IClientMessageFormatter>|<xref:System.ServiceModel.Dispatcher.IClientMessageFormatter.DeserializeReply%28System.ServiceModel.Channels.Message%2CSystem.Object%5B%5D%29>|Converts an incoming `Message` to a return value/out parameters|  
  
## Serialization  
 Whenever you use message contracts or parameters to describe message contents, you must use serialization to convert between [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] types and XML Infoset representation. Serialization is used in other places in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], for example, <xref:System.ServiceModel.Channels.Message> has a Generic <xref:System.ServiceModel.Channels.Message.GetBody%2A> method that you can use to read the entire body of the message deserialized into an object.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports two serialization technologies "out of the box" for serializing and deserializing parameters and message parts: the <xref:System.Runtime.Serialization.DataContractSerializer> and the `XmlSerializer`. Additionally, you can write custom serializers. However, other parts of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] (such as the Generic `GetBody` method or SOAP fault serialization) may be restricted to use only the <xref:System.Runtime.Serialization.XmlObjectSerializer> subclasses (<xref:System.Runtime.Serialization.DataContractSerializer> and <xref:System.Runtime.Serialization.NetDataContractSerializer>, but not the <xref:System.Xml.Serialization.XmlSerializer>), or may even be hard-coded to use only the <xref:System.Runtime.Serialization.DataContractSerializer>.  
  
 The `XmlSerializer` is the serialization engine used in [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Web services. The `DataContractSerializer` is the new serialization engine that understands the new data contract programming model. `DataContractSerializer` is the default choice, and the choice to use the `XmlSerializer` can be made on a per-operation basis using the <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior.DataContractFormatAttribute%2A> attribute.  
  
 <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior> and <xref:System.ServiceModel.Description.XmlSerializerOperationBehavior> are the operation behaviors responsible for plugging in the message formatters for the `DataContractSerializer` and the `XmlSerializer`, respectively. The <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior> behavior can actually operate with any serializer that derives from <xref:System.Runtime.Serialization.XmlObjectSerializer>, including the <xref:System.Runtime.Serialization.NetDataContractSerializer> (described in detail in Using Stand-Alone Serialization). The behavior calls one of the `CreateSerializer` virtual method overloads to obtain the serializer. To plug in a different serializer, create a new <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior> subclass and override both `CreateSerializer` overloads.  
  
## See Also  
 [Specifying Data Transfer in Service Contracts](../../../../docs/framework/wcf/feature-details/specifying-data-transfer-in-service-contracts.md)
