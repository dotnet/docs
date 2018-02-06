---
title: "Security Considerations for Data"
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
ms.assetid: a7eb98da-4a93-4692-8b59-9d670c79ffb2
caps.latest.revision: 23
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Security Considerations for Data
When dealing with data in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)], you must consider a number of threat categories. The following table lists the most important threat classes that relate to data processing. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides tools to mitigate these threats.  
  
 Denial of service  
 When receiving untrusted data, the data may cause the receiving side to access a disproportionate amount of various resources, such as memory, threads, available connections, or processor cycles by causing lengthy computations. A denial-of-service attack against a server may cause it to crash and be unable to process messages from other, legitimate clients.  
  
 Malicious code execution  
 Incoming untrusted data causes the receiving side to run code it did not intend to.  
  
 Information disclosure  
 The remote attacker forces the receiving party to respond to its requests in such a way as to disclose more information than it intends to.  
  
## User-Provided Code and Code Access Security  
 A number of places in the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] infrastructure run code that is provided by the user. For example, the <xref:System.Runtime.Serialization.DataContractSerializer> serialization engine may call user-provided property `set` accessors and `get` accessors. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] channel infrastructure may also call into user-provided derived classes of the <xref:System.ServiceModel.Channels.Message> class.  
  
 It is the responsibility of the code author to ensure that no security vulnerabilities exist. For example, if you create a data contract type with a data member property of type integer, and in the `set` accessor implementation allocate an array based on the property value, you expose the possibility of a denial-of-service attack if a malicious message contains an extremely large value for this data member. In general, avoid any allocations based on incoming data or lengthy processing in user-provided code (especially if lengthy processing can be caused by a small amount of incoming data). When performing security analysis of user-provided code, make sure to also consider all failure cases (that is, all code branches where exceptions are thrown).  
  
 The ultimate example of user-provided code is the code inside your service implementation for each operation. The security of your service implementation is your responsibility. It is easy to inadvertently create insecure operation implementations that may result in denial-of-service vulnerabilities. For example, an operation that takes a string and returns the list of customers from a database whose name starts with that string. If you are working with a large database and the string being passed is just a single letter, your code may attempt to create a message larger than all available memory, causing the entire service to fail. (An <xref:System.OutOfMemoryException> is not recoverable in the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] and always results in the termination of your application.)  
  
 You should ensure that no malicious code is plugged in to the various extensibility points. This is especially relevant when running under partial trust, dealing with types from partially-trusted assemblies, or creating components usable by partially-trusted code. For more information, see "Partial Trust Threats" in a later section.  
  
 Note that when running in partial trust, the data contract serialization infrastructure supports only a limited subset of the data contract programming model - for example, private data members or types using the <xref:System.SerializableAttribute> attribute are not supported. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Partial Trust](../../../../docs/framework/wcf/feature-details/partial-trust.md).  
  
## Avoiding Unintentional Information Disclosure  
 When designing serializable types with security in mind, information disclosure is a possible concern.  
  
 Consider the following points:  
  
-   The <xref:System.Runtime.Serialization.DataContractSerializer> programming model allows the exposure of private and internal data outside of the type or assembly during serialization. Additionally, the shape of a type can be exposed during schema export. Be sure to understand your type's serialization projection. If you do not want anything exposed, disable serializing it (for example, by not applying the <xref:System.Runtime.Serialization.DataMemberAttribute> attribute in the case of a data contract).  
  
-   Be aware that the same type may have multiple serialization projections, depending on the serializer in use. The same type may expose one set of data when used with the <xref:System.Runtime.Serialization.DataContractSerializer> and another set of data when used with the <xref:System.Xml.Serialization.XmlSerializer>. Accidentally using the wrong serializer may lead to information disclosure.  
  
-   Using the <xref:System.Xml.Serialization.XmlSerializer> in legacy remote procedure call (RPC)/encoded mode may unintentionally expose the shape of the object graph on the sending side to the receiving side.  
  
## Preventing Denial-of-Service Attacks  
  
### Quotas  
 Causing the receiving side to allocate a significant amount of memory is a potential denial-of-service attack. While this section concentrates on memory consumption issues arising from large messages, other attacks may occur. For example, messages may use a disproportionate amount of processing time.  
  
 Denial-of-service attacks are usually mitigated using quotas. When a quota is exceeded, a <xref:System.ServiceModel.QuotaExceededException> exception is normally thrown. Without the quota, a malicious message may cause all available memory to be accessed, resulting in an <xref:System.OutOfMemoryException> exception, or all available stacks to be accessed, resulting in a <xref:System.StackOverflowException>.  
  
 The quota exceeded scenario is recoverable; if encountered in a running service, the message currently being processed is discarded and the service keeps running and processes further messages. The out-of-memory and stack overflow scenarios, however, are not recoverable anywhere in the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)]; the service terminates if it encounters such exceptions.  
  
 Quotas in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] do not involve any pre-allocation. For example, if the <xref:System.ServiceModel.Channels.TransportBindingElement.MaxReceivedMessageSize%2A> quota (found on various classes) is set to 128 KB, it does not mean that 128 KB is automatically allocated for each message. The actual amount allocated depends on the actual incoming message size.  
  
 Many quotas are available at the transport layer. These are quotas enforced by the specific transport channel in use (HTTP, TCP, and so on). While this topic discusses some of these quotas, these quotas are described in detail in [Transport Quotas](../../../../docs/framework/wcf/feature-details/transport-quotas.md).  
  
### Hashtable Vulnerability  
 A vulnerability exists when data contracts contain hashtables or collections. The problem occurs if a large number of values are inserted into a hashtable where a large number of those values generate the same hash value. This can be used as a DOS attack.  This vulnerability can be mitigated by setting the MaxRecievedMessageSize binding quota. Care must be taken while setting this quota in order to prevent such attacks. This quota puts an upper limit on the size of WCF message. Additionally, avoid using hashtables or collections in your data contracts.  
  
## Limiting Memory Consumption Without Streaming  
 The security model around large messages depends on whether streaming is in use. In the basic, non-streamed case, messages are buffered into memory. In this case, use the <xref:System.ServiceModel.Channels.TransportBindingElement.MaxReceivedMessageSize%2A> quota on the <xref:System.ServiceModel.Channels.TransportBindingElement> or on the system-provided bindings to protect against large messages by limiting the maximum message size to access. Note that a service may be processing multiple messages at the same time, in which case they are all in memory. Use the throttling feature to mitigate this threat.  
  
 Also note that `MaxReceivedMessageSize` does not place an upper bound on per-message memory consumption, but limits it to within a constant factor. For example, if the `MaxReceivedMessageSize` is 1 MB and a 1-MB message is received and then deserialized, additional memory is required to contain the deserialized object graph, resulting in total memory consumption well over 1 MB. For this reason, avoid creating serializable types that could result in significant memory consumption without much incoming data. For example, a data contract "MyContract" with 50 optional data member fields and an additional 100 private fields could be instantiated with the XML construction "\<MyContract/>". This XML results in memory being accessed for 150 fields. Note that data members are optional by default. The problem is compounded when such a type is part of an array.  
  
 `MaxReceivedMessageSize` alone is not enough to prevent all denial-of-service attacks. For example, the deserializer may be forced to deserialize a deeply-nested object graph (an object that contains another object that contains yet another one, and so on) by an incoming message. Both the <xref:System.Runtime.Serialization.DataContractSerializer> and the <xref:System.Xml.Serialization.XmlSerializer> call methods in a nested way to deserialize such graphs. Deep nesting of method calls may result in an unrecoverable <xref:System.StackOverflowException>. This threat is mitigated by setting the <xref:System.ServiceModel.Configuration.XmlDictionaryReaderQuotasElement.MaxDepth%2A> quota to limit the level of XML nesting, as discussed in the "Using XML Safely" section later in the topic.  
  
 Setting additional quotas to `MaxReceivedMessageSize` is especially important when using binary XML encoding. Using binary encoding is somewhat equivalent to compression: a small group of bytes in the incoming message may represent a lot of data. Thus, even a message fitting into the `MaxReceivedMessageSize` limit may take up much more memory in fully expanded form. To mitigate such XML-specific threats, all of the XML reader quotas must be set correctly, as discussed in the "Using XML Safely" section later in this topic.  
  
## Limiting Memory Consumption with Streaming  
 When streaming, you may use a small `MaxReceivedMessageSize` setting to protect against denial-of-service attacks. However, more complicated scenarios are possible with streaming. For example, a file upload service accepts files larger than all available memory. In this case, set the `MaxReceivedMessageSize` to an extremely large value, expecting that almost no data is buffered in memory and the message streams directly to disk. If a malicious message can somehow force [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] to buffer data instead of streaming it in this case, `MaxReceivedMessageSize` no longer protects against the message accessing all available memory.  
  
 To mitigate this threat, specific quota settings exist on various [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] data-processing components that limit buffering. The most important of these is the `MaxBufferSize` property on various transport binding elements and standard bindings. When streaming, this quota should be set taking into account the maximum amount of memory you are willing to allocate per message. As with `MaxReceivedMessageSize`, the setting does not put an absolute maximum on memory consumption but only limits it to within a constant factor. Also, as with `MaxReceivedMessageSize`, be aware of the possibility of multiple messages being processed simultaneously.  
  
### MaxBufferSize Details  
 The `MaxBufferSize` property limits any bulk buffering [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does. For example, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] always buffers SOAP headers and SOAP faults, as well as any MIME parts found to be not in the natural reading order in an Message Transmission Optimization Mechanism (MTOM) message. This setting limits the amount of buffering in all these cases.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] accomplishes this by passing the `MaxBufferSize` value to the various components that may buffer. For example, some <xref:System.ServiceModel.Channels.Message.CreateMessage%2A> overloads of the <xref:System.ServiceModel.Channels.Message> class take a `maxSizeOfHeaders` parameter. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] passes the `MaxBufferSize` value to this parameter to limit the amount of SOAP header buffering. It is important to set this parameter when using the <xref:System.ServiceModel.Channels.Message> class directly. In general, when using a component in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] that takes quota parameters, it is important to understand the security implications of these parameters and set them correctly.  
  
 The MTOM message encoder also has a `MaxBufferSize` setting. When using standard bindings, this is set automatically to the transport-level `MaxBufferSize` value. However, when using the MTOM message encoder binding element to construct a custom binding, it is important to set the `MaxBufferSize` property to a safe value when streaming is used.  
  
## XML-Based Streaming Attacks  
 `MaxBufferSize` alone is not enough to ensure that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] cannot be forced into buffering when streaming is expected. For example, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] XML readers always buffer the entire XML element start tag when starting to read a new element. This is done so that namespaces and attributes are properly processed. If `MaxReceivedMessageSize` is configured to be large (for example, to enable a direct-to-disk large file streaming scenario), a malicious message may be constructed where the entire message body is a large XML element start tag. An attempt to read it results in an <xref:System.OutOfMemoryException>. This is one of many possible XML-based denial-of-service attacks that can all be mitigated using XML reader quotas, discussed in the "Using XML Safely" section later in this topic. When streaming, it is especially important to set all of these quotas.  
  
### Mixing Streaming and Buffering Programming Models  
 Many possible attacks arise from mixing streaming and non-streaming programming models in the same service. Suppose there is a service contract with two operations: one takes a <xref:System.IO.Stream> and another takes an array of some custom type. Suppose also that `MaxReceivedMessageSize` is set to a large value to enable the first operation to process large streams. Unfortunately, this means that large messages can now be sent to the second operation as well, and the deserializer buffers data in memory as an array before the operation is called. This is a potential denial-of-service attack: the `MaxBufferSize` quota does not limit the size of the message body, which is what the deserializer works with.  
  
 For this reason, avoid mixing stream-based and non-streamed operations in the same contract. If you absolutely must mix the two programming models, use the following precautions:  
  
-   Turn off the <xref:System.Runtime.Serialization.IExtensibleDataObject> feature by setting the <xref:System.ServiceModel.ServiceBehaviorAttribute.IgnoreExtensionDataObject%2A> property of the <xref:System.ServiceModel.ServiceBehaviorAttribute> to `true`. This ensures that only members that are a part of the contract are deserialized.  
  
-   Set the <xref:System.Runtime.Serialization.DataContractSerializer.MaxItemsInObjectGraph%2A> property of the <xref:System.Runtime.Serialization.DataContractSerializer> to a safe value. This quota is also available on the <xref:System.ServiceModel.ServiceBehaviorAttribute> attribute or through configuration. This quota limits the number of objects that are deserialized in one deserialization episode. Normally, each operation parameter or message body part in a message contract is deserialized in one episode. When deserializing arrays, each array entry is counted as a separate object.  
  
-   Set all of the XML reader quotas to safe values. Pay attention to <xref:System.Xml.XmlDictionaryReaderQuotas.MaxDepth%2A>, <xref:System.Xml.XmlDictionaryReaderQuotas.MaxStringContentLength%2A>, and <xref:System.Xml.XmlDictionaryReaderQuotas.MaxArrayLength%2A> and avoid strings in non-streaming operations.  
  
-   Review the list of known types, keeping in mind that any one of them can be instantiated at any time (see the "Preventing Unintended Types from Being Loaded" section later in this topic).  
  
-   Do not use any types that implement the <xref:System.Xml.Serialization.IXmlSerializable> interface that buffer a lot of data. Do not add such types to the list of known types.  
  
-   Do not use the <xref:System.Xml.XmlElement>, <xref:System.Xml.XmlNode> arrays, <xref:System.Byte> arrays, or types that implement <xref:System.Runtime.Serialization.ISerializable> in a contract.  
  
-   Do not use the <xref:System.Xml.XmlElement>, <xref:System.Xml.XmlNode> arrays, <xref:System.Byte> arrays, or types that implement <xref:System.Runtime.Serialization.ISerializable> in the list of known types.  
  
 The preceding precautions apply when the non-streamed operation uses the <xref:System.Runtime.Serialization.DataContractSerializer>. Never mix streaming and non-streaming programming models on the same service if you are using the <xref:System.Xml.Serialization.XmlSerializer>, because it does not have the protection of the <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior.MaxItemsInObjectGraph%2A> quota.  
  
### Slow Stream Attacks  
 A class of streaming denial-of-service attacks does not involve memory consumption. Instead, the attack involves a slow sender or receiver of data. While waiting for the data to be sent or received, resources such as threads and available connections are exhausted. This situation could arise either as a result of a malicious attack or from a legitimate sender/receiver on a slow network connection.  
  
 To mitigate these attacks, set the transport time-outs correctly. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Transport Quotas](../../../../docs/framework/wcf/feature-details/transport-quotas.md). Secondly, never use synchronous `Read` or `Write` operations when working with streams in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
## Using XML Safely  
  
> [!NOTE]
>  Although this section is about XML, the information also applies to JavaScript Object Notation (JSON) documents. The quotas work similarly, using [Mapping Between JSON and XML](../../../../docs/framework/wcf/feature-details/mapping-between-json-and-xml.md).  
  
### Secure XML Readers  
 The XML Infoset forms the basis of all message processing in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. When accepting XML data from an untrusted source, a number of denial-of-service attack possibilities exist that must be mitigated. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides special, secure XML readers. These readers are created automatically when using one of the standard encodings in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] (text, binary, or MTOM).  
  
 Some of the security features on these readers are always active. For example, the readers never process document type definitions (DTDs), which are a potential source of denial-of-service attacks and should never appear in legitimate SOAP messages. Other security features include reader quotas that must be configured, which are described in the following section.  
  
 When working directly with XML readers (such as when writing your own custom encoder or when working directly with the <xref:System.ServiceModel.Channels.Message> class), always use the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] secure readers when there is a chance of working with untrusted data. Create the secure readers by calling one of the static factory method overloads of <xref:System.Xml.XmlDictionaryReader.CreateTextReader%2A>, <xref:System.Xml.XmlDictionaryReader.CreateBinaryReader%2A>, or <xref:System.Xml.XmlDictionaryReader.CreateMtomReader%2A> on the <xref:System.Xml.XmlDictionaryReader> class. When creating a reader, pass in secure quota values. Do not call the `Create` method overloads. These do not create a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] reader. Instead, a reader is created that is not protected by the security features described in this section.  
  
### Reader Quotas  
 The secure XML readers have five configurable quotas. These are normally configured using the `ReaderQuotas` property on the encoding binding elements or standard bindings, or by using an <xref:System.Xml.XmlDictionaryReaderQuotas> object passed when creating a reader.  
  
#### MaxBytesPerRead  
 This quota limits the number of bytes that are read in a single `Read` operation when reading the element start tag and its attributes. (In non-streamed cases, the element name itself is not counted against the quota.) <xref:System.Xml.XmlDictionaryReaderQuotas.MaxBytesPerRead%2A> is important for the following reasons:  
  
-   The element name and its attributes are always buffered in memory when they are being read. Therefore, it is important to set this quota correctly in streaming mode to prevent excessive buffering when streaming is expected. See the `MaxDepth` quota section for information about the actual amount of buffering that takes place.  
  
-   Having too many XML attributes may use up disproportionate processing time because attribute names have to be checked for uniqueness. `MaxBytesPerRead` mitigates this threat.  
  
#### MaxDepth  
 This quota limits the maximum nesting depth of XML elements. For example, the document "\<A>\<B>\<C/>\</B>\</A>" has a nesting depth of three. <xref:System.Xml.XmlDictionaryReaderQuotas.MaxDepth%2A> is important for the following reasons:  
  
-   `MaxDepth` interacts with `MaxBytesPerRead`: the reader always keeps data in memory for the current element and all of its ancestors, so the maximum memory consumption of the reader is proportional to the product of these two settings.  
  
-   When deserializing a deeply-nested object graph, the deserializer is forced to access the entire stack and throw an unrecoverable <xref:System.StackOverflowException>. A direct correlation exists between XML nesting and object nesting for both the <xref:System.Runtime.Serialization.DataContractSerializer> and the <xref:System.Xml.Serialization.XmlSerializer>. Use `MaxDepth` to mitigate this threat.  
  
#### MaxNameTableCharCount  
 This quota limits the size of the reader’s *nametable*. The nametable contains certain strings (such as namespaces and prefixes) that are encountered when processing an XML document. As these strings are buffered in memory, set this quota to prevent excessive buffering when streaming is expected.  
  
#### MaxStringContentLength  
 This quota limits the maximum string size that the XML reader returns. This quota does not limit memory consumption in the XML reader itself, but in the component that is using the reader. For example, when the <xref:System.Runtime.Serialization.DataContractSerializer> uses a reader secured with <xref:System.Xml.XmlDictionaryReaderQuotas.MaxStringContentLength%2A>, it does not deserialize strings larger than this quota. When using the <xref:System.Xml.XmlDictionaryReader> class directly, not all methods respect this quota, but only the methods that are specifically designed to read strings, such as the <xref:System.Xml.XmlDictionaryReader.ReadContentAsString%2A> method. The <xref:System.Xml.XmlReader.Value%2A> property on the reader is not affected by this quota, and thus should not be used when the protection this quota provides is necessary.  
  
#### MaxArrayLength  
 This quota limits the maximum size of an array of primitives that the XML reader returns, including byte arrays. This quota does not limit memory consumption in the XML reader itself, but in whatever component that is using the reader. For example, when the <xref:System.Runtime.Serialization.DataContractSerializer> uses a reader secured with <xref:System.Xml.XmlDictionaryReaderQuotas.MaxArrayLength%2A>, it does not deserialize byte arrays larger than this quota. It is important to set this quota when attempting to mix streaming and buffered programming models in a single contract. Keep in mind that when using the <xref:System.Xml.XmlDictionaryReader> class directly, only the methods that are specifically designed to read arrays of arbitrary size of certain primitive types, such as <xref:System.Xml.XmlDictionaryReader.ReadInt32Array%2A>, respect this quota.  
  
## Threats Specific to the Binary Encoding  
 The binary XML encoding [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports includes a *dictionary strings* feature. A large string may be encoded using only a few bytes. This enables significant performance gains, but introduces new denial-of-service threats that must be mitigated.  
  
 There are two kinds of dictionaries: *static* and *dynamic*. The static dictionary is a built-in list of long strings that may be represented using a short code in the binary encoding. This list of strings is fixed when the reader is created and cannot be modified. None of the strings in the static dictionary that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses by default are sufficiently large to pose a serious denial-of-service threat, although they may still be used in a dictionary expansion attack. In advanced scenarios where you supply your own static dictionary, be careful when introducing large dictionary strings.  
  
 The dynamic dictionaries feature allows messages to define their own strings and associate them with short codes. These string-to-code mappings are kept in memory during the entire communication session, such that subsequent messages do not have to resend the strings and can utilize codes that are already defined. These strings may be of arbitrary length and thus pose a more serious threat than those in the static dictionary.  
  
 The first threat that must be mitigated is the possibility of the dynamic dictionary (the string-to-code mapping table) becoming too large. This dictionary may be expanded over the course of several messages, and so the `MaxReceivedMessageSize` quota offers no protection because it applies only to each message separately. Therefore, a separate <xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement.MaxSessionSize%2A> property exists on the <xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement> that limits the size of the dictionary.  
  
 Unlike most other quotas, this quota also applies when writing messages. If it is exceeded when reading a message, the `QuotaExceededException` is thrown as usual. If it is exceeded when writing a message, any strings that cause the quota to be exceeded are written as-is, without using the dynamic dictionaries feature.  
  
### Dictionary Expansion Threats  
 A significant class of binary-specific attacks arises from dictionary expansion. A small message in binary form may turn into a very large message in fully expanded textual form if it makes extensive use of the string dictionaries feature. The expansion factor for dynamic dictionary strings is limited by the <xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement.MaxSessionSize%2A> quota, because no dynamic dictionary string exceeds the maximum size of the entire dictionary.  
  
 The <xref:System.Xml.XmlDictionaryReaderQuotas.MaxNameTableCharCount%2A>, `MaxStringContentLength`, and `MaxArrayLength` properties only limit memory consumption. They are normally not required to mitigate any threats in the non-streamed usage because memory usage is already limited by `MaxReceivedMessageSize`. However, `MaxReceivedMessageSize` counts pre-expansion bytes. When binary encoding is in use, memory consumption could potentially go beyond `MaxReceivedMessageSize`, limited only by a factor of <xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement.MaxSessionSize%2A>. For this reason, it is important to always set all of the reader quotas (especially <xref:System.Xml.XmlDictionaryReaderQuotas.MaxStringContentLength%2A>) when using the binary encoding.  
  
 When using binary encoding together with the <xref:System.Runtime.Serialization.DataContractSerializer>, the `IExtensibleDataObject` interface can be misused to mount a dictionary expansion attack. This interface essentially provides unlimited storage for arbitrary data that is not a part of the contract. If quotas cannot be set low enough such that `MaxSessionSize` multiplied by `MaxReceivedMessageSize` does not pose a problem, disable the `IExtensibleDataObject` feature when using the binary encoding. Set the `IgnoreExtensionDataObject` property to `true` on the `ServiceBehaviorAttribute` attribute. Alternatively, do not implement the `IExtensibleDataObject` interface. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Forward-Compatible Data Contracts](../../../../docs/framework/wcf/feature-details/forward-compatible-data-contracts.md).  
  
### Quotas Summary  
 The following table summarizes the guidance about quotas.  
  
|Condition|Important quotas to set|  
|---------------|-----------------------------|  
|No streaming or streaming small messages, text, or MTOM encoding|`MaxReceivedMessageSize`, `MaxBytesPerRead`, and `MaxDepth`|  
|No streaming or streaming small messages, binary encoding|`MaxReceivedMessageSize`, `MaxSessionSize`, and all `ReaderQuotas`|  
|Streaming large messages, text, or MTOM encoding|`MaxBufferSize` and all `ReaderQuotas`|  
|Streaming large messages, binary encoding|`MaxBufferSize`, `MaxSessionSize`, and all `ReaderQuotas`|  
  
-   Transport-level time-outs must always be set and never use synchronous reads/writes when streaming is in use, regardless of whether you are streaming large or small messages.  
  
-   When in doubt about a quota, set it to a safe value rather than leaving it open.  
  
## Preventing Malicious Code Execution  
 The following general classes of threats can execute code and have unintended effects:  
  
-   The deserializer loads a malicious, unsafe, or security-sensitive type.  
  
-   An incoming message causes the deserializer to construct an instance of a normally safe type in such a way that it has unintended consequences.  
  
 The following sections discuss these classes of threats further.  
  
## DataContractSerializer  
 (For security information on the <xref:System.Xml.Serialization.XmlSerializer>, see the relevant documentation.) The security model for the <xref:System.Xml.Serialization.XmlSerializer> is similar to that of the <xref:System.Runtime.Serialization.DataContractSerializer>, and differs mostly in details. For example, the <xref:System.Xml.Serialization.XmlIncludeAttribute> attribute is used for type inclusion instead of the <xref:System.Runtime.Serialization.KnownTypeAttribute> attribute. However, some threats unique to the <xref:System.Xml.Serialization.XmlSerializer> are discussed later in this topic.  
  
### Preventing Unintended Types from Being Loaded  
 Loading unintended types may have significant consequences, whether the type is malicious or just has security-sensitive side effects. A type may contain exploitable security vulnerability, perform security-sensitive actions in its constructor or class constructor, have a large memory footprint that facilitates denial-of-service attacks, or may throw non-recoverable exceptions. Types may have class constructors that run as soon as the type is loaded and before any instances are created. For these reasons, it is important to control the set of types that the deserializer may load.  
  
 The <xref:System.Runtime.Serialization.DataContractSerializer> deserializes in a loosely coupled way. It never reads common language runtime (CLR) type and assembly names from the incoming data. This is similar to the behavior of the <xref:System.Xml.Serialization.XmlSerializer>, but differs from the behavior of the <xref:System.Runtime.Serialization.NetDataContractSerializer>, <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>, and the <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter>. Loose coupling introduces a degree of safety, because the remote attacker cannot indicate an arbitrary type to load just by naming that type in the message.  
  
 The <xref:System.Runtime.Serialization.DataContractSerializer> is always allowed to load a type that is currently expected according to the contract. For example, if a data contract has a data member of type `Customer`, the <xref:System.Runtime.Serialization.DataContractSerializer> is allowed to load the `Customer` type when it deserializes this data member.  
  
 Additionally, the <xref:System.Runtime.Serialization.DataContractSerializer> supports polymorphism. A data member may be declared as <xref:System.Object>, but the incoming data may contain a `Customer` instance. This is possible only if the `Customer` type has been made "known" to the deserializer through one of these mechanisms:  
  
-   <xref:System.Runtime.Serialization.KnownTypeAttribute> attribute applied to a type.  
  
-   `KnownTypeAttribute` attribute specifying a method that returns a list of types.  
  
-   `ServiceKnownTypeAttribute` attribute.  
  
-   The `KnownTypes` configuration section.  
  
-   A list of known types explicitly passed to the <xref:System.Runtime.Serialization.DataContractSerializer> during construction, if using the serializer directly.  
  
 Each of these mechanisms increases the surface area by introducing more types that the deserializer can load. Control each of these mechanisms to ensure no malicious or unintended types are added to the known types list.  
  
 Once a known type is in scope, it can be loaded at any time, and instances of the type can be created, even if the contract forbids actually using it. For example, suppose the type "MyDangerousType" is added to the known types list using one of the mechanisms above. This means that:  
  
-   `MyDangerousType` is loaded and its class constructor runs.  
  
-   Even when deserializing a data contract with a string data member, a malicious message may still cause an instance of `MyDangerousType` to create. Code in `MyDangerousType`, such as property setters, may run. After this is done, the deserializer tries to assign this instance to the string data member and fail with an exception.  
  
 When writing a method that returns a list of known types, or when passing a list directly to the <xref:System.Runtime.Serialization.DataContractSerializer> constructor, ensure that the code that prepares the list is secure and operates only on trusted data.  
  
 If specifying known types in configuration, ensure that the configuration file is secure. Always use strong names in configuration (by specifying the public key of the signed assembly where the type resides), but do not specify the version of the type to load. The type loader automatically picks the latest version, if possible. If you specify a particular version in configuration, you run the following risk: A type may have a security vulnerability that may be fixed in a future version, but the vulnerable version still loads because it is explicitly specified in configuration.  
  
 Having too many known types has another consequence: The <xref:System.Runtime.Serialization.DataContractSerializer> creates a cache of serialization/deserialization code in the application domain, with an entry for each type it must serialize and deserialize. This cache is never cleared as long as the application domain is running. Therefore, an attacker who is aware that an application uses many known types can cause the deserialization of all these types, causing the cache to consume a disproportionately large amount of memory.  
  
### Preventing Types from Being in an Unintended State  
 A type may have internal consistency constraints that must be enforced. Care must be taken to avoid breaking these constraints during deserialization.  
  
 The following example of a type represents the state of an airlock on a spacecraft, and enforces the constraint that both the inner and the outer doors cannot be open at the same time.  
  
 [!code-csharp[DataContractAttribute#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/datacontractattribute/cs/overview.cs#3)]
 [!code-vb[DataContractAttribute#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/datacontractattribute/vb/overview.vb#3)]  
  
 An attacker may send a malicious message like this, getting around the constraints and getting the object into an invalid state, which may have unintended and unpredictable consequences.  
  
```xml  
<SpaceStationAirlock>  
    <innerDoorOpen>true</innerDoorOpen>  
    <outerDoorOpen>true</outerDoorOpen>  
</SpaceStationAirlock>  
```  
  
 This situation can be avoided by being aware of the following points:  
  
-   When the <xref:System.Runtime.Serialization.DataContractSerializer> deserializes most classes, constructors do not run. Therefore, do not rely on any state management done in the constructor.  
  
-   Use callbacks to ensure that the object is in a valid state. The callback marked with the <xref:System.Runtime.Serialization.OnDeserializedAttribute> attribute is especially useful because it runs after deserialization is complete and has a chance to examine and correct the overall state. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Version-Tolerant Serialization Callbacks](../../../../docs/framework/wcf/feature-details/version-tolerant-serialization-callbacks.md).  
  
-   Do not design data contract types to rely on any particular order in which property setters must be called.  
  
-   Take care using legacy types marked with the <xref:System.SerializableAttribute> attribute. Many of them were designed to work with [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] remoting for use with trusted data only. Existing types marked with this attribute may not have been designed with state safety in mind.  
  
-   Do not rely on the <xref:System.Runtime.Serialization.DataMemberAttribute.IsRequired%2A> property of the `DataMemberAttribute` attribute to guarantee presence of data as far as state safety is concerned. Data could always be `null`, `zero`, or `invalid`.  
  
-   Never trust an object graph deserialized from an untrusted data source without validating it first. Each individual object may be in a consistent state, but the object graph as a whole may not be. Furthermore, even if the object graph preservation mode is disabled, the deserialized graph may have multiple references to the same object or have circular references. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Serialization and Deserialization](../../../../docs/framework/wcf/feature-details/serialization-and-deserialization.md).  
  
### Using the NetDataContractSerializer Securely  
 The <xref:System.Runtime.Serialization.NetDataContractSerializer> is a serialization engine that uses tight coupling to types. This is similar to the <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> and the <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter>. That is, it determines which type to instantiate by reading the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] assembly and type name from the incoming data. Although it is a part of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], there is no supplied way of plugging in this serialization engine; custom code must be written. The `NetDataContractSerializer` is provided primarily to ease migration from [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] remoting to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the relevant section in [Serialization and Deserialization](../../../../docs/framework/wcf/feature-details/serialization-and-deserialization.md).  
  
 Because the message itself may indicate any type can be loaded, the <xref:System.Runtime.Serialization.NetDataContractSerializer> mechanism is inherently insecure and should be used only with trusted data. It is possible to make it secure by writing a secure, type-limiting type binder that allows only safe types to load (using the <xref:System.Runtime.Serialization.NetDataContractSerializer.Binder%2A> property).  
  
 Even when used with trusted data, the incoming data may insufficiently specify the type to load, especially if the <xref:System.Runtime.Serialization.NetDataContractSerializer.AssemblyFormat%2A> property is set to <xref:System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple>. Anyone with access to the application’s directory or to the global assembly cache can substitute a malicious type in place of the one that is supposed to load. Always ensure the security of your application’s directory and of the global assembly cache by correctly setting permissions.  
  
 In general, if you allow partially trusted code access to your `NetDataContractSerializer` instance or otherwise control the surrogate selector (<xref:System.Runtime.Serialization.ISurrogateSelector>) or the serialization binder (<xref:System.Runtime.Serialization.SerializationBinder>), the code may exercise a great deal of control over the serialization/deserialization process. For example, it may inject arbitrary types, lead to information disclosure, tamper with the resulting object graph or serialized data, or overflow the resultant serialized stream.  
  
 Another security concern with the `NetDataContractSerializer` is a denial of service, not a malicious code execution threat. When using the `NetDataContractSerializer`, always set the <xref:System.Runtime.Serialization.NetDataContractSerializer.MaxItemsInObjectGraph%2A> quota to a safe value. It is easy to construct a small malicious message that allocates an array of objects whose size is limited only by this quota.  
  
### XmlSerializer-Specific Threats  
 The <xref:System.Xml.Serialization.XmlSerializer> security model is similar to that of the <xref:System.Runtime.Serialization.DataContractSerializer>. A few threats, however, are unique to the <xref:System.Xml.Serialization.XmlSerializer>.  
  
 The <xref:System.Xml.Serialization.XmlSerializer> generates *serialization assemblies* at runtime that contain code that actually serializes and deserializes; these assemblies are created in a temporary files directory. If some other process or user has access rights to that directory, they may overwrite the serialization/deserialization code with arbitrary code. The <xref:System.Xml.Serialization.XmlSerializer> then runs this code using its security context, instead of the serialization/deserialization code. Make sure the permissions are set correctly on the temporary files directory to prevent this from happening.  
  
 The <xref:System.Xml.Serialization.XmlSerializer> also has a mode in which it uses pre-generated serialization assemblies instead of generating them at runtime. This mode is triggered whenever the <xref:System.Xml.Serialization.XmlSerializer> can find a suitable serialization assembly. The <xref:System.Xml.Serialization.XmlSerializer> checks whether or not the serialization assembly was signed by the same key that was used to sign the assembly that contains the types being serialized. This offers protection from malicious assemblies being disguised as serialization assemblies. However, if the assembly that contains your serializable types is not signed, the <xref:System.Xml.Serialization.XmlSerializer> cannot perform this check and uses any assembly with the correct name. This makes running malicious code possible. Always sign the assemblies that contain your serializable types, or tightly control access to your application’s directory and the global assembly cache to prevent the introduction of malicious assemblies.  
  
 The <xref:System.Xml.Serialization.XmlSerializer> can be subject to a denial of service attack. The <xref:System.Xml.Serialization.XmlSerializer> does not have a `MaxItemsInObjectGraph` quota (as is available on the <xref:System.Runtime.Serialization.DataContractSerializer>). Thus, it deserializes an arbitrary amount of objects, limited only by the message size.  
  
### Partial Trust Threats  
 Note the following concerns regarding threats related to code running with partial trust. These threats include malicious partially-trusted code as well as malicious partially-trusted code in combination with other attack scenarios (for example, partially-trusted code that constructs a specific string and then deserializing it).  
  
-   When using any serialization components, never assert any permissions before such usage, even if the entire serialization scenario is within the scope of your assert, and you are not dealing with any untrusted data or objects. Such usage may lead to security vulnerabilities.  
  
-   In cases where partially-trusted code has control over the serialization process, either through extensibility points (surrogates), types being serialized, or through other means, the partially-trusted code may cause the serializer to output a large amount of data into the serialized stream, which may cause Denial of Service (DoS) to the receiver of this stream. If you are serializing data intended for a target that is sensitive to DoS threats, do not serialize partially-trusted types or otherwise let partially-trusted code control serialization.  
  
-   If you allow partially-trusted code access to your <xref:System.Runtime.Serialization.DataContractSerializer> instance or otherwise control the [Data Contract Surrogates](../../../../docs/framework/wcf/extending/data-contract-surrogates.md), it may exercise a great deal of control over the serialization/deserialization process. For example, it may inject arbitrary types, lead to information disclosure, tamper with the resulting object graph or serialized data, or overflow the resultant serialized stream. An equivalent <xref:System.Runtime.Serialization.NetDataContractSerializer> threat is described in the "Using the NetDataContractSerializer Securely" section.  
  
-   If the <xref:System.Runtime.Serialization.DataContractAttribute> attribute is applied to a type (or the type marked as `[Serializable]` but is not `ISerializable`), the deserializer can create an instance of such a type even if all constructors are non-public or protected by demands.  
  
-   Never trust the result of deserialization unless the data to be deserialized is trusted and you are certain that all known types are types that you trust. Note that known types are not loaded from the application configuration file, (but are loaded from the computer configuration file) when running in partial trust.  
  
-   If you pass a `DataContractSerializer` instance with a surrogate added to partially-trusted code, the code can change any modifiable settings on that surrogate.  
  
-   For a deserialized object, if the XML reader (or the data therein) comes from partially-trusted code, treat the resulting deserialized object as untrusted data.  
  
-   The fact that the <xref:System.Runtime.Serialization.ExtensionDataObject> type has no public members does not mean that data within it is secure. For example, if you deserialize from a privileged data source into an object in which some data resides, then hand that object to partially-trusted code, the partially-trusted code can read the data in the `ExtensionDataObject` by serializing the object. Consider setting <xref:System.Runtime.Serialization.DataContractSerializer.IgnoreExtensionDataObject%2A> to `true` when deserializing from a privileged data source into an object that is later passed to partially-trusted code.  
  
-   <xref:System.Runtime.Serialization.DataContractSerializer> and <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> support the serialization of private, protected, internal, and public members in full trust. However, in partial trust, only public members can be serialized. A `SecurityException` is thrown if an application attempts to serialize a non-public member.  
  
     To allow internal or protected internal members to be serialized in partial trust, use the `System.Runtime.CompilerServices.InternalsVisibleTo` assembly attribute. This attribute allows an assembly to declare that its internal members are visible to some other assembly. In this case, an assembly that wants to have its internal members serialized declares that its internal members are visible to System.Runtime.Serialization.dll.  
  
     The advantage of this approach is that it does not require an elevated code generation path.  
  
     At the same time, there are two major disadvantages.  
  
     The first disadvantage is that the opt-in property of the `InternalsVisibleTo` attribute is assembly-wide. That is, you cannot specify that only a certain class can have its internal members serialized. Of course, you can still choose not to serialize a specific internal member, by simply not adding a `DataMember` attribute to that member. Similarly, a developer can also choose to make a member internal rather than private or protected, with slight visibility concerns.  
  
     The second disadvantage is that it still does not support private or protected members.  
  
     To illustrate the use of the `InternalsVisibleTo` attribute in partial trust, consider the following program:  
  
     [!code-csharp[CDF_WCF_SecurityConsiderationsForData#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/cdf_wcf_securityconsiderationsfordata/cs/program.cs#1)]  
  
     In the example above, `PermissionsHelper.InternetZone` corresponds to the `PermissionSet` for partial trust. Now, without `InternalsVisibleToAttribute`, the application will fail, throwing a `SecurityException` indicating that non-public members cannot be serialized in partial trust.  
  
     However, if we add the following line to the source file, the program runs successfully.  
  
     [!code-csharp[CDF_WCF_SecurityConsiderationsForData#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/cdf_wcf_securityconsiderationsfordata/cs/program.cs#2)]  
  
## Other State Management Concerns  
 A few other concerns regarding object state management are worth mentioning:  
  
-   When using the stream-based programming model with a streaming transport, processing of the message occurs as the message arrives. The sender of the message may abort the send operation in the middle of the stream, leaving your code in an unpredictable state if more content was expected. In general, do not rely on the stream being complete, and do not perform any work in a stream-based operation that cannot be rolled back in case the stream is aborted. This also applies to the situation where a message may be malformed after the streaming body (for example, it may be missing an end tag for the SOAP envelope or may have a second message body).  
  
-   Using the `IExtensibleDataObject` feature may cause sensitive data to be emitted. If you are accepting data from an untrusted source into data contracts with `IExtensibleObjectData` and later re-emitting it on a secure channel where messages are signed, you are potentially vouching for data you know nothing about. Moreover, the overall state you are sending may be invalid if you take both the known and unknown pieces of data into account. Avoid this situation by either selectively setting the extension data property to `null` or by selectively disabling the `IExtensibleObjectData` feature.  
  
## Schema Import  
 Normally, the process of importing schema to generate types happens only at design time, for example, when using the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) on a Web service to generate a client class. However, in more advanced scenarios, you may process schema at runtime. Be aware that doing so can expose you to denial-of-service risks. Some schema may take a long time to be imported. Never use the <xref:System.Xml.Serialization.XmlSerializer> schema import component in such scenarios if schemas are possibly coming from an untrusted source.  
  
## Threats Specific to ASP.NET AJAX Integration  
 When the user implements <xref:System.ServiceModel.Description.WebScriptEnablingBehavior> or <xref:System.ServiceModel.Description.WebHttpBehavior>, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] exposes an endpoint that can accept both XML and JSON messages. However, there is only one set of reader quotas, used both by the XML reader and the JSON reader. Some quota settings may be appropriate for one reader but too large for the other.  
  
 When implementing `WebScriptEnablingBehavior`, the user has the option to expose a JavaScript proxy at the endpoint. The following security issues must be considered:  
  
-   Information about the service (operation names, parameter names, and so on) can be obtained by examining the JavaScript proxy.  
  
-   When using the JavaScript endpoint, sensitive and private information might be retained in the client Web browser cache.  
  
## A Note on Components  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is a flexible and customizable system. Most of the contents of this topic focus on the most common [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] usage scenarios. However, it is possible to compose components [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides in many different ways. It is important to understand the security implications of using each component. In particular:  
  
-   When you must use XML readers, use the readers the <xref:System.Xml.XmlDictionaryReader> class provides as opposed to any other readers. Safe readers are created using <xref:System.Xml.XmlDictionaryReader.CreateTextReader%2A>, <xref:System.Xml.XmlDictionaryReader.CreateBinaryReader%2A>, or <xref:System.Xml.XmlDictionaryReader.CreateMtomReader%2A> methods. Do not use the <xref:System.Xml.XmlReader.Create%2A> method. Always configure the readers with safe quotas. The serialization engines in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] are secure only when used with secure XML readers from [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
-   When using the <xref:System.Runtime.Serialization.DataContractSerializer> to deserialize potentially untrusted data, always set the <xref:System.Runtime.Serialization.DataContractSerializer.MaxItemsInObjectGraph%2A> property.  
  
-   When creating a message, set the `maxSizeOfHeaders` parameter if `MaxReceivedMessageSize` does not offer enough protection.  
  
-   When creating an encoder, always configure the relevant quotas, such as `MaxSessionSize` and `MaxBufferSize`.  
  
-   When using an XPath message filter, set the <xref:System.ServiceModel.Dispatcher.XPathMessageFilter.NodeQuota%2A> to limit the amount of XML nodes the filter visits. Do not use XPath expressions that could take a long time to compute without visiting many nodes.  
  
-   In general, when using any component that accepts a quota, understand its security implications and set it to a safe value.  
  
## See Also  
 <xref:System.Runtime.Serialization.DataContractSerializer>  
 <xref:System.Xml.XmlDictionaryReader>  
 <xref:System.Xml.Serialization.XmlSerializer>  
 [Data Contract Known Types](../../../../docs/framework/wcf/feature-details/data-contract-known-types.md)
