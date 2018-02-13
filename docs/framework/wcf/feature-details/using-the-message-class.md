---
title: "Using the Message Class"
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
ms.assetid: d1d62bfb-2aa3-4170-b6f8-c93d3afdbbed
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using the Message Class
The <xref:System.ServiceModel.Channels.Message> class is fundamental to [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)]. All communication between clients and services ultimately results in <xref:System.ServiceModel.Channels.Message> instances being sent and received.  
  
 You would not usually interact with the <xref:System.ServiceModel.Channels.Message> class directly. Instead, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service model constructs, such as data contracts, message contracts, and operation contracts, are used to describe incoming and outgoing messages. However, in some advanced scenarios you can program using the <xref:System.ServiceModel.Channels.Message> class directly. For example, you might want to use the <xref:System.ServiceModel.Channels.Message> class:  
  
-   When you need an alternative way of creating outgoing message contents (for example, creating a message directly from a file on disk) instead of serializing [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] objects.  
  
-   When you need an alternative way of using incoming message contents (for example, when you want to apply an XSLT transformation to the raw XML contents) instead of deserializing into [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] objects.  
  
-   When you need to deal with messages in a general way regardless of message contents (for example, when routing or forwarding messages when building a router, load-balancer, or a publish-subscribe system).  
  
 Before using the <xref:System.ServiceModel.Channels.Message> class, familiarize yourself with the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] data transfer architecture in [Data Transfer Architectural Overview](../../../../docs/framework/wcf/feature-details/data-transfer-architectural-overview.md).  
  
 A <xref:System.ServiceModel.Channels.Message> is a general-purpose container for data, but its design closely follows the design of a message in the SOAP protocol. Just like in SOAP, a message has both a message body and headers. The message body contains the actual payload data, while the headers contain additional named data containers. The rules for reading and writing the body and the headers are different, for example, the headers are always buffered in memory and may be accessed in any order any number of times, while the body may be read only once and may be streamed. Normally, when using SOAP, the message body is mapped to the SOAP body and the message headers are mapped to the SOAP headers.  
  
## Using the Message Class in Operations  
 You can use the <xref:System.ServiceModel.Channels.Message> class as an input parameter of an operation, the return value of an operation, or both. If <xref:System.ServiceModel.Channels.Message> is used anywhere in an operation, the following restrictions apply:  
  
-   The operation cannot have any `out` or `ref` parameters.  
  
-   There cannot be more than one `input` parameter. If the parameter is present, it must be either Message or a message contract type.  
  
-   The return type must be either `void`, `Message`, or a message contract type.  
  
 The following code example contains a valid operation contract.  
  
 [!code-csharp[C_UsingTheMessageClass#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_usingthemessageclass/cs/source.cs#1)]
 [!code-vb[C_UsingTheMessageClass#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_usingthemessageclass/vb/source.vb#1)]  
  
## Creating Basic Messages  
 The <xref:System.ServiceModel.Channels.Message> class provides static `CreateMessage` factory methods that you can use to create basic messages.  
  
 All `CreateMessage` overloads take a version parameter of type <xref:System.ServiceModel.Channels.MessageVersion> that indicates the SOAP and WS-Addressing versions to use for the message. If you want to use the same protocol versions as the incoming message, you can use the <xref:System.ServiceModel.OperationContext.IncomingMessageVersion%2A> property on the <xref:System.ServiceModel.OperationContext> instance obtained from the <xref:System.ServiceModel.OperationContext.Current%2A> property. Most `CreateMessage` overloads also have a string parameter that indicates the SOAP action to use for the message. Version can be set to `None` to disable SOAP envelope generation; the message consists of only the body.  
  
## Creating Messages from Objects  
 The most basic `CreateMessage` overload that takes only a version and an action creates a message with an empty body. Another overload takes an additional <xref:System.Object> parameter; this creates a message whose body is the serialized representation of the given object. Use the <xref:System.Runtime.Serialization.DataContractSerializer> with default settings for serialization. If you want to use a different serializer, or you want the `DataContractSerializer` configured differently, use the `CreateMessage` overload that also takes an `XmlObjectSerializer` parameter.  
  
 For example, to return an object in a message, you can use the following code.  
  
 [!code-csharp[C_UsingTheMessageClass#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_usingthemessageclass/cs/source.cs#2)]
 [!code-vb[C_UsingTheMessageClass#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_usingthemessageclass/vb/source.vb#2)]  
  
## Creating Messages from XML Readers  
 There are `CreateMessage` overloads that take an <xref:System.Xml.XmlReader> or an <xref:System.Xml.XmlDictionaryReader> for the body instead of an object. In this case, the body of the message contains the XML that results from reading from the passed XML reader. For example, the following code returns a message with body contents read from an XML file.  
  
 [!code-csharp[C_UsingTheMessageClass#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_usingthemessageclass/cs/source.cs#3)]
 [!code-vb[C_UsingTheMessageClass#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_usingthemessageclass/vb/source.vb#3)]  
  
 Additionally, there are `CreateMessage` overloads that take an <xref:System.Xml.XmlReader> or an <xref:System.Xml.XmlDictionaryReader> that represents the entire message and not just the body. These overloads also take an integer `maxSizeOfHeaders` parameter. Headers are always buffered into memory as soon as the message is created, and this parameter limits the amount of buffering that takes place. It is important to set this parameter to a safe value if the XML is coming from an untrusted source to mitigate the possibility of a denial of service attack. The SOAP and WS-Addressing versions of the message the XML reader represents must match the versions indicated using the version parameter.  
  
## Creating Messages with BodyWriter  
 One `CreateMessage` overload takes a `BodyWriter` instance to describe the body of the message. A `BodyWriter` is an abstract class that can be derived to customize how message bodies are created. You can create your own `BodyWriter` derived class to describe message bodies in a custom way. You must override the `BodyWriter.OnWriteBodyContents` method that takes an <xref:System.Xml.XmlDictionaryWriter>; this method is responsible for writing out the body.  
  
 Body writers can be buffered or non-buffered (streamed). Buffered body writers can write out their contents any number of times, while streamed ones can write out their contents only once. The `IsBuffered` property indicates whether a body writer is buffered or not. You can set this for your body writer by calling the protected `BodyWriter` constructor that takes an `isBuffered` boolean parameter. Body writers support creating a buffered body writer from a non-buffered body writer. You can override the `OnCreateBufferedCopy` method to customize this process. By default, an in-memory buffer that contains the XML returned by `OnWriteBodyContents` is used. `OnCreateBufferedCopy` takes a `maxBufferSize` integer parameter; if you override this method, you must not create buffers larger than this maximum size.  
  
 The `BodyWriter` class provides the `WriteBodyContents` and `CreateBufferedCopy` methods, which are essentially thin wrappers around `OnWriteBodyContents` and `OnCreateBufferedCopy` methods, respectively. These methods perform state checking to ensure that a non-buffered body writer is not accessed more than once. These methods are called directly only when creating custom `Message` derived classes based on `BodyWriters`.  
  
## Creating Fault Messages  
 You can use certain `CreateMessage` overloads to create SOAP fault messages. The most basic of these takes a <xref:System.ServiceModel.Channels.MessageFault> object that describes the fault. Other overloads are provided for convenience. The first such overload takes a `FaultCode` and a reason string and creates a `MessageFault` using `MessageFault.CreateFault` using this information. The other overload takes a detail object and also passes it to `CreateFault` together with the fault code and the reason. For example, the following operation returns a fault.  
  
 [!code-csharp[C_UsingTheMessageClass#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_usingthemessageclass/cs/source.cs#4)]
 [!code-vb[C_UsingTheMessageClass#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_usingthemessageclass/vb/source.vb#4)]  
  
## Extracting Message Body Data  
 The `Message` class supports multiple ways of extracting information from its body. These can be classified into the following categories:  
  
-   Getting the entire message body written out at once to an XML writer. This is referred to as *writing a message*.  
  
-   Getting an XML reader over the message body. This enables you to later access the message body piece-by-piece as required. This is referred to as *reading a message*.  
  
-   The entire message, including its body, can be copied to an in-memory buffer of the <xref:System.ServiceModel.Channels.MessageBuffer> type. This is referred to as *copying a message*.  
  
 You can access the body of a `Message` only once, regardless of how it is accessed. A message object has a `State` property, which is initially set to Created. The three access methods described in the preceding list set the state to Written, Read, and Copied, respectively. Additionally, a `Close` method can set the state to Closed when the message body contents are no longer required. The message body can be accessed only in the Created state, and there is no way to go back to the Created state after the state has changed.  
  
## Writing Messages  
 The <xref:System.ServiceModel.Channels.Message.WriteBodyContents%28System.Xml.XmlDictionaryWriter%29> method writes out the body contents of a given `Message` instance to a given XML writer. The <xref:System.ServiceModel.Channels.Message.WriteBody%2A> method does the same, except that it encloses the body contents in the appropriate wrapper element (for example, <`soap:body`>). Finally, <xref:System.ServiceModel.Channels.Message.WriteMessage%2A> writes out the entire message, including the wrapping SOAP envelope and the headers. If SOAP is turned off (Version is `MessageVersion.None`), all three methods do the same thing: they write out the message body contents.  
  
 For example, the following code writes out the body of an incoming message to a file.  
  
 [!code-csharp[C_UsingTheMessageClass#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_usingthemessageclass/cs/source.cs#5)]
 [!code-vb[C_UsingTheMessageClass#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_usingthemessageclass/vb/source.vb#5)]  
  
 Two additional helper methods write out certain SOAP start element tags. These methods do not access the message body and so they do not change the message state. These include:  
  
-   <xref:System.ServiceModel.Channels.Message.WriteStartBody%2A> writes the start body element, for example, `<soap:Body>`.  
  
-   <xref:System.ServiceModel.Channels.Message.WriteStartEnvelope%2A> writes the start envelope element, for example, `<soap:Envelope>`.  
  
 To write the corresponding end element tags, call `WriteEndElement` on the corresponding XML writer. These methods are rarely called directly.  
  
## Reading Messages  
 The primary way to read a message body is to call <xref:System.ServiceModel.Channels.Message.GetReaderAtBodyContents%2A>. You get back an <xref:System.Xml.XmlDictionaryReader> that you can use to read the message body. Note that the <xref:System.ServiceModel.Channels.Message> transitions to the Read state as soon as <xref:System.ServiceModel.Channels.Message.GetReaderAtBodyContents%2A> is called, and not when you use the returned XML reader.  
  
 The <xref:System.ServiceModel.Channels.Message.GetBody%2A> method also enables you to access the message body as a typed object. Internally, this method uses `GetReaderAtBodyContents`, and so it also transitions the message state to the <xref:System.ServiceModel.Channels.MessageState.Read> state (see the <xref:System.ServiceModel.Channels.Message.State%2A> property).  
  
 It is good practice to check the <xref:System.ServiceModel.Channels.Message.IsEmpty%2A> property, in which case the message body is empty and <xref:System.ServiceModel.Channels.Message.GetReaderAtBodyContents%2A> throws an <xref:System.InvalidOperationException>. Also, if it is a received message (for example, the reply), you may also want to check <xref:System.ServiceModel.Channels.Message.IsFault%2A>, which indicates whether the message contains a fault.  
  
 The most basic overload of <xref:System.ServiceModel.Channels.Message.GetBody%2A> deserializes the message body into an instance of a type (indicated by the generic parameter) using a <xref:System.Runtime.Serialization.DataContractSerializer> configured with the default settings and with the <xref:System.Runtime.Serialization.DataContractSerializer.MaxItemsInObjectGraph%2A> quota disabled. If you want to use a different serialization engine, or configure the `DataContractSerializer` in a non-default way, use the <xref:System.ServiceModel.Channels.Message.GetBody%2A> overload that takes an <xref:System.Runtime.Serialization.XmlObjectSerializer>.  
  
 For example, the following code extracts data from a message body that contains a serialized `Person` object and prints out the person’s name.  
  
 [!code-csharp[C_UsingTheMessageClass#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_usingthemessageclass/cs/source.cs#6)]
 [!code-vb[C_UsingTheMessageClass#6](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_usingthemessageclass/vb/source.vb#6)]  
  
## Copying a Message into a Buffer  
 Sometimes it is necessary to access the message body more than once, for example, to forward the same message to multiple destinations as part of a publisher-subscriber system. In this case, it is necessary to buffer the entire message (including the body) in memory. You can do this by calling <xref:System.ServiceModel.Channels.Message.CreateBufferedCopy%28System.Int32%29>. This method takes an integer parameter that represents the maximum buffer size, and creates a buffer not larger than this size. It is important to set this to a safe value if the message is coming from an untrusted source.  
  
 The buffer is returned as a <xref:System.ServiceModel.Channels.MessageBuffer> instance. You can access data in the buffer in several ways. The primary way is to call <xref:System.ServiceModel.Channels.Message.CreateMessage%2A> to create `Message` instances from the buffer.  
  
 Another way to access the data in the buffer is to implement the <xref:System.Xml.XPath.IXPathNavigable> interface that the <xref:System.ServiceModel.Channels.MessageBuffer> class implements to access the underlying XML directly. Some <xref:System.ServiceModel.Channels.MessageBuffer.CreateNavigator%2A> overloads allow you to create <xref:System.Xml.XPath> navigators protected by a node quota, limiting the number of XML nodes that can be visited. This helps prevent denial of service attacks based on lengthy processing time. This quote is disabled by default. Some `CreateNavigator` overloads allow you to specify how white space should be handled in the XML using the <xref:System.Xml.XmlSpace> enumeration, with the default being `XmlSpace.None`.  
  
 A final way to access the contents of a message buffer is to write out its contents to a stream using <xref:System.ServiceModel.Channels.Message.WriteMessage%2A>.  
  
 The following example demonstrates the process of working with a `MessageBuffer`: an incoming message is forwarded to multiple recipients, and then logged to a file. Without buffering, this is not possible, because the message body can then be accessed only once.  
  
 [!code-csharp[C_UsingTheMessageClass#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_usingthemessageclass/cs/source.cs#7)]
 [!code-vb[C_UsingTheMessageClass#7](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_usingthemessageclass/vb/source.vb#7)]  
  
 The `MessageBuffer` class has other members worth noting. The <xref:System.ServiceModel.Channels.MessageBuffer.Close%2A> method can be called to free resources when the buffer contents are no longer required. The <xref:System.ServiceModel.Channels.MessageBuffer.BufferSize%2A> property returns the size of the allocated buffer. The <xref:System.ServiceModel.Channels.MessageBuffer.MessageContentType%2A> property returns the MIME content type of the message.  
  
## Accessing the Message Body for Debugging  
 For debugging purposes, you can call the <xref:System.ServiceModel.Channels.Message.ToString%2A> method to get a representation of the message as a string. This representation generally matches the way a message would look on the wire if it were encoded with the text encoder, except that the XML would be better formatted for human readability. The one exception to this is the message body. The body can be read only once, and `ToString` does not change the message state. Therefore, the `ToString` method might not be able to access the body and might substitute a placeholder (for example, "…" or three dots) instead of the message body. Therefore, do not use `ToString` to log messages if the body content of the messages is important.  
  
## Accessing Other Message Parts  
 Various properties are provided to access information about the message other than its body contents. However, these cannot be called once the message has been closed:  
  
-   The <xref:System.ServiceModel.Channels.Message.Headers%2A> property represents the message headers. See the section on "Working with Headers" later in this topic.  
  
-   The <xref:System.ServiceModel.Channels.Message.Properties%2A> property represents the message properties, which are pieces of named data attached to the message that do not generally get emitted when the message is sent. See the section on "Working with Properties" later in this topic.  
  
-   The <xref:System.ServiceModel.Channels.Message.Version%2A> property indicates the SOAP and WS-Addressing version associated with the message, or `None` if SOAP is disabled.  
  
-   The <xref:System.ServiceModel.Channels.Message.IsFault%2A> property returns `true` if the message is a SOAP fault message.  
  
-   The <xref:System.ServiceModel.Channels.Message.IsEmpty%2A> property returns `true` if the message is empty.  
  
 You can use the <xref:System.ServiceModel.Channels.Message.GetBodyAttribute%28System.String%2CSystem.String%29> method to access a particular attribute on the body wrapper element (for example, `<soap:Body>`) identified by a particular name and namespace. If such an attribute is not found, `null` is returned. This method can be called only when the `Message` is in the Created state (when the message body has not yet been accessed).  
  
## Working with Headers  
 A `Message` can contain any number of named XML fragments, called *headers*. Each fragment normally maps to a SOAP header. Headers are accessed through the `Headers` property of type <xref:System.ServiceModel.Channels.MessageHeaders>. <xref:System.ServiceModel.Channels.MessageHeaders> is a collection of <xref:System.ServiceModel.Channels.MessageHeaderInfo> objects, and individual headers can be accessed through its <xref:System.Collections.IEnumerable> interface or through its indexer. For example, the following code lists the names of all the headers in a `Message`.  
  
 [!code-csharp[C_UsingTheMessageClass#8](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_usingthemessageclass/cs/source.cs#8)]
 [!code-vb[C_UsingTheMessageClass#8](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_usingthemessageclass/vb/source.vb#8)]  
  
#### Adding, Removing, Finding Headers  
 You can add a new header at the end of all existing headers using the <xref:System.ServiceModel.Channels.MessageHeaders.Add%2A> method. You can use the <xref:System.ServiceModel.Channels.MessageHeaders.Insert%2A> method to insert a header at a particular index. Existing headers are shifted for the inserted item. Headers are ordered according to their index, and the first available index is 0. You can use the various <xref:System.ServiceModel.Channels.MessageHeaders.CopyHeadersFrom%2A> method overloads to add headers from a different `Message` or `MessageHeaders` instance. Some overloads copy one individual header, while others copy all of them. The <xref:System.ServiceModel.Channels.MessageHeaders.Clear%2A> method removes all headers. The <xref:System.ServiceModel.Channels.MessageHeaders.RemoveAt%2A> method removes a header at a particular index (shifting all headers after it). The <xref:System.ServiceModel.Channels.MessageHeaders.RemoveAll%2A> method removes all headers with a particular name and namespace.  
  
 Retrieve a particular header using the <xref:System.ServiceModel.Channels.MessageHeaders.FindHeader%2A> method. This method takes the name and namespace of the header to find, and returns its index. If the header occurs more than once, an exception is thrown. If the header is not found, it returns -1.  
  
 In the SOAP header model, headers can have an `Actor` value that specifies the intended recipient of the header. The most basic `FindHeader` overload searches only headers intended for the ultimate receiver of the message. However, another overload enables you to specify which `Actor` values are included in the search. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the SOAP specification.  
  
 A <xref:System.ServiceModel.Channels.MessageHeaders.CopyTo%28System.ServiceModel.Channels.MessageHeaderInfo%5B%5D%2CSystem.Int32%29> method is provided to copy headers from a <xref:System.ServiceModel.Channels.MessageHeaders> collection to an array of <xref:System.ServiceModel.Channels.MessageHeaderInfo> objects.  
  
 To access the XML data in a header, you can call <xref:System.ServiceModel.Channels.MessageHeaders.GetReaderAtHeader%2A> and return an XML reader for the specific header index. If you want to deserialize the header contents into an object, use <xref:System.ServiceModel.Channels.MessageHeaders.GetHeader%60%601%28System.Int32%29> or one of the other overloads. The most basic overloads deserialize headers using the <xref:System.Runtime.Serialization.DataContractSerializer> configured in the default way. If you want to use a different serializer or a different configuration of the `DataContractSerializer`, use one of the overloads that take an `XmlObjectSerializer`. There are also overloads that take the header name, namespace, and optionally a list of `Actor` values instead of an index; this is a combination of `FindHeader` and `GetHeader`.  
  
## Working with Properties  
 A `Message` instance can contain an arbitrary number of named objects of arbitrary types. This collection is accessed through the `Properties` property of type `MessageProperties`. The collection implements the <xref:System.Collections.Generic.IDictionary%602> interface and acts as a mapping from <xref:System.String> to <xref:System.Object>. Normally, property values do not map directly to any part of the message on the wire, but rather provide various message processing hints to the various channels in the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] channel stack or to the <xref:System.ServiceModel.Channels.MessageHeaders.CopyTo%28System.ServiceModel.Channels.MessageHeaderInfo%5B%5D%2CSystem.Int32%29> service framework. For an example, see [Data Transfer Architectural Overview](../../../../docs/framework/wcf/feature-details/data-transfer-architectural-overview.md).  
  
## Inheriting from the Message Class  
 If the built-in message types created using `CreateMessage` do not meet your requirements, create a class that derives from the `Message` class.  
  
### Defining the Message Body Contents  
 Three primary techniques exist for accessing data within a message body: writing, reading, and copying it to a buffer. These operations ultimately result in the <xref:System.ServiceModel.Channels.Message.OnWriteBodyContents%2A>, <xref:System.ServiceModel.Channels.Message.OnGetReaderAtBodyContents%2A>, and <xref:System.ServiceModel.Channels.Message.OnCreateBufferedCopy%2A> methods being called, respectively, on your derived class of `Message`. The base `Message` class guarantees that only one of these methods is called for each `Message` instance, and that it is not called more than once. The base class also ensures that the methods are not called on a closed message. There is no need to track the message state in your implementation.  
  
 <xref:System.ServiceModel.Channels.Message.OnWriteBodyContents%2A> is an abstract method and must be implemented. The most basic way to define the body contents of your message is to write using this method. For example, the following message contains 100,000 random numbers from 1 to 20.  
  
 [!code-csharp[C_UsingTheMessageClass#9](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_usingthemessageclass/cs/source.cs#9)]
 [!code-vb[C_UsingTheMessageClass#9](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_usingthemessageclass/vb/source.vb#9)]  
  
 The `OnGetReaderAtBodyContents` and `OnCreateBufferedCopy` methods have default implementations that work for most cases. The default implementations call `OnWriteBodyContents`, buffer the results, and work with the resulting buffer. However, in some cases this may not be enough. In the preceding example, reading the message results in 100,000 XML elements being buffered, which might not be desirable. You might want to override `OnGetReaderAtBodyContents` to return a custom `XmlDictionaryReader` derived class that serves up random numbers. You can then override `OnWriteBodyContents` to use the reader that the `OnGetReaderAtBodyContents` property returns, as shown in the following example.  
  
 [!code-csharp[C_UsingTheMessageClass#10](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_usingthemessageclass/cs/source.cs#10)]
 [!code-vb[C_UsingTheMessageClass#10](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_usingthemessageclass/vb/source.vb#10)]  
  
 Similarly, you might want to override `OnCreateBufferedCopy` to return your own `MessageBuffer` derived class.  
  
 In addition to providing message body contents, your message derived class must also override the `Version`, `Headers`, and `Properties` properties.  
  
 Note that if you create a copy of a message, the copy uses the message headers from the original.  
  
### Other Members that Can Be Overridden  
 You can override the <xref:System.ServiceModel.Channels.Message.OnWriteStartEnvelope%2A>, <xref:System.ServiceModel.Channels.Message.OnWriteStartHeaders%2A>, and <xref:System.ServiceModel.Channels.Message.OnWriteStartBody%2A> methods to specify how the SOAP envelope, SOAP headers, and SOAP body element start tags are written out. These normally correspond to `<soap:Envelope>`, `<soap:Header>`, and `<soap:Body>`. These methods should normally not write anything out if the `Version` property returns `MessageVersion.None`.  
  
> [!NOTE]
>  The default implementation of `OnGetReaderAtBodyContents` calls `OnWriteStartEnvelope` and `OnWriteStartBody` before calling `OnWriteBodyContents` and buffering the results. Headers are not written out.  
  
 Override the <xref:System.ServiceModel.Channels.Message.OnWriteMessage%2A> method to change the way the entire message is constructed from its various pieces. The `OnWriteMessage` method is called from <xref:System.ServiceModel.Channels.Message.WriteMessage%2A> and from the default <xref:System.ServiceModel.Channels.Message.OnCreateBufferedCopy%2A> implementation. Note that overriding <xref:System.ServiceModel.Channels.Message.WriteMessage%2A> is not a best practice. It is better to override the appropriate `On` methods (for example, <xref:System.ServiceModel.Channels.Message.OnWriteStartEnvelope%2A>, <xref:System.ServiceModel.Channels.Message.OnWriteStartHeaders%2A>, and <xref:System.ServiceModel.Channels.BodyWriter.OnWriteBodyContents%2A>.  
  
 Override <xref:System.ServiceModel.Channels.Message.OnBodyToString%2A> to override how your message body is represented during debugging. The default is to represent it as three dots ("…"). Note that this method can be called multiple times when the message state is anything other than Closed. An implementation of this method should never cause any action that must be performed only once (such as reading from a forward-only stream).  
  
 Override the <xref:System.ServiceModel.Channels.Message.OnGetBodyAttribute%2A> method to allow access to attributes on the SOAP body element. This method can be called any number of times, but the `Message` base type guarantees that it is only called when the message is in the Created state. It is not required to check the state in an implementation. The default implementation always returns `null`, which indicates that there are no attributes on the body element.  
  
 If your `Message` object must do any special cleanup when the message body is no longer required, you can override <xref:System.ServiceModel.Channels.Message.OnClose%2A>. The default implementation does nothing.  
  
 The `IsEmpty` and `IsFault` properties can be overridden. By default, both return `false`.
