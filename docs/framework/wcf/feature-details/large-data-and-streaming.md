---
title: "Large Data and Streaming"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ab2851f5-966b-4549-80ab-c94c5c0502d2
caps.latest.revision: 27
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Large Data and Streaming
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] is an XML-based communications infrastructure. Because XML data is commonly encoded in the standard text format defined in the [XML 1.0 specification](http://go.microsoft.com/fwlink/?LinkId=94838), connected systems developers and architects are typically concerned about the wire footprint (or size) of messages sent across the network, and the text-based encoding of XML poses special challenges for the efficient transfer of binary data.  
  
## Basic Considerations  
 To provide background information about the following information for [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], this section highlights some general concerns and considerations for encodings, binary data, and streaming that generally apply to connected systems infrastructures.  
  
### Encoding Data: Text vs. Binary  
 Commonly expressed developer concerns include the perception that XML has significant overhead when compared to binary formats due to the repetitive nature of start tags and end tags, that the encoding of numerical values is considered to be significantly larger because they are expressed in text values, and that binary data cannot be expressed efficiently because it must be specially encoded for embedding into a text format.  
  
 While many of these and similar concerns are valid, the actual difference between XML-text encoded messages in an XML Web services environment and binary-encoded messages in a legacy remote procedure call (RPC) environment is often much less significant than the initial consideration might suggest.  
  
 While XML-text encoded messages are transparent and "human readable", binary messages are often fairly obscure in comparison and difficult to decode without tools. This difference in legibility leads one to overlook that binary messages also often carry inline metadata in the payload, which adds overhead just as with XML text messages. This is specifically true for binary formats that aim to provide loose-coupling and dynamic invocation capabilities.  
  
 However, binary formats commonly carry such descriptive metadata information in a "header," which also declares the data layout for the following data records. The payload then follows this common metadata block declaration with minimal further overhead. In contrast, XML encloses each data item in an element or attribute so that the enclosing metadata is repetitively included for each serialized payload object. As a result, the size of a single serialized payload object is similar when comparing text to binary representations as some descriptive metadata must be expressed for both, but the binary format benefits from the shared metadata description with each additional payload object that is transferred due to the lower overall overhead.  
  
 Still, for certain data types, such as numbers, there might be a disadvantage to using fixed-size, binary numerical representations, such as a 128-bit decimal type instead of plain text, as the plain text representation might be several bytes smaller. Text data also might have size benefits from the typically more flexible XML text encoding choices, while some binary formats might default to 16-bit or even 32-bit Unicode, which does not apply to the .NET Binary XML Format.  
  
 As a result, deciding between text or binary is not quite as easy as assuming that binary messages are always smaller than XML-text messages.  
  
 A clear advantage of XML-text messages is that they are standards-based and offer the broadest choice of interoperability options and platform support. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the "Encodings" section later in this topic.  
  
### Binary Content  
 One area where binary encodings are superior to text-based encodings in terms of the resulting message size are large binary data items such as pictures, videos, sound clips, or any other form of opaque, binary data that must be exchanged between services and their consumers. To fit these types of data into XML text, the common approach is to encode them using the Base64 encoding.  
  
 In a Base64-encoded string, each character represents 6-bits of the original 8-bit data, which results in a 4:3 encoding-overhead ratio for Base64, not counting extra formatting characters (carriage return/line feed) that are commonly added by convention. While the significance of the differences between XML and binary encodings typically depends on the scenario, a size gain of more than 33% when transmitting a 500-MB payload is usually not acceptable.  
  
 To avoid this encoding overhead, the Message Transmission Optimization Mechanism (MTOM) standard allows for externalizing large data elements that are contained in a message and carrying them with the message as binary data without any special encoding. With MTOM, messages are exchanged in a similar fashion to Simple Mail Transfer Protocol (SMTP) email messages with attachments or embedded content (pictures and other embedded content); MTOM messages are packaged as multipart/related MIME sequences with the root part being the actual SOAP message.  
  
 An MTOM SOAP message is modified from its un-encoded version so that special element tags that refer to the respective MIME parts take the place of the original elements in the message that contained binary data. As a result, the SOAP message refers to binary content by pointing to the MIME parts sent with it, but otherwise just carries XML text data. Because this model is closely aligned with the well-established SMTP model, there is broad tooling support to encode and decode MTOM messages on many platforms, which makes it an extremely interoperable choice.  
  
 Still, as with Base64, MTOM also comes with some necessary overhead for the MIME format, so that advantages of using MTOM are only seen when the size of a binary data element exceeds about 1 KB. Due to the overhead, MTOM-encoded messages might be larger than messages that use Base64 encoding for binary data, if the binary payload remains under that threshold. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the "Encodings" section later in this topic.  
  
### Large Data Content  
 Wire-footprint aside, the previously mentioned 500-MB payload also poses a great local challenge at for the service and the client. By default, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] processes messages in *buffered mode*. This means that the entire content of a message is present in memory before it is sent or after it is received. While that is a good strategy for most scenarios, and necessary for messaging features such as digital signatures and reliable delivery, large messages could exhaust a system's resources.  
  
 The strategy to deal with large payloads is streaming. While messages, especially those expressed in XML, are commonly thought of as being relatively compact data packages, a message might be multiple gigabytes in size and resemble a continuous data stream more than a data package. When data is transferred in streaming mode instead of buffered mode, the sender makes the contents of the message body available to the recipient in the form of a stream and the message infrastructure continuously forwards the data from sender to receiver as it becomes available.  
  
 The most common scenario in which such large data content transfers occur are transfers of binary data objects that:  
  
-   Cannot be easily broken up into a message sequence.  
  
-   Must be delivered in a timely manner.  
  
-   Are not available in their entirety when the transfer is initiated.  
  
 For data that does not have these constraints, it is typically better to send sequences of messages within the scope of a session than one large message. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the "Streaming Data" section later in this topic.  
  
 When sending large amounts of data you will need to set the `maxAllowedContentLength` IIS setting (for more information see [Configuring IIS Request Limits](http://go.microsoft.com/fwlink/?LinkId=253165)) and the `maxReceivedMessageSize` binding setting (for example [System.ServiceModel.BasicHttpBinding.MaxReceivedMessageSize](xref:System.ServiceModel.HttpBindingBase.MaxReceivedMessageSize%2A) or <xref:System.ServiceModel.NetTcpBinding.MaxReceivedMessageSize%2A>). The `maxAllowedContentLength` property defaults to 28.6 M and the `maxReceivedMessageSize` property defaults to 64KB.  
  
## Encodings  
 An *encoding* defines a set of rules about how to present messages on the wire. An *encoder* implements such an encoding and is responsible, on the sender side, for turning a <xref:System.ServiceModel.Channels.Message> in-memory message into a byte stream or byte buffer that can be sent across the network. On the receiver side, the encoder turns a sequence of bytes into an in-memory message.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] includes three encoders and allows you to write and plug in your own encoders, if necessary.  
  
 Each of the standard bindings includes a preconfigured encoder, whereby the bindings with the Net* prefix use the binary encoder (by including the <xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement> class) while the <xref:System.ServiceModel.BasicHttpBinding> and <xref:System.ServiceModel.WSHttpBinding> classes use the text message encoder (by means of the <xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement> class) by default.  
  
|Encoder binding element|Description|  
|-----------------------------|-----------------|  
|<xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement>|The text message encoder is the default encoder for all HTTP-based bindings and the appropriate choice for all custom bindings where interoperability is the highest concern. This encoder reads and writes standard SOAP 1.1/SOAP 1.2 text messages with no special handling for binary data. If the <xref:System.ServiceModel.Channels.MessageVersion> of a message is set to `None`, the SOAP envelope wrapper is omitted from the output and only the message body content is serialized.|  
|<xref:System.ServiceModel.Channels.MtomMessageEncodingBindingElement>|The MTOM message encoder is a text encoder that implements special handling for binary data and is not used by default in any of the standard bindings because it is strictly a case-by-case optimization utility. If the message contains binary data that exceeds a threshold where MTOM encoding yields a benefit, the data is externalized into a MIME part following the message envelope. See Enabling MTOM later in this section.|  
|<xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement>|The binary message encoder is the default encoder for the Net* bindings and the appropriate choice whenever both communicating parties are based on [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. The binary message encoder uses the .NET Binary XML Format, a Microsoft-specific binary representation for XML Information Sets (Infosets) that generally yields a smaller footprint than the equivalent XML 1.0 representation and encodes binary data as a byte stream.|  
  
 Text message encoding is typically the best choice for any communication path that requires interoperability, while binary message encoding is the best choice for any other communication path. Binary message encoding typically yields smaller message sizes compared to text for a single message and progressively even smaller message sizes over the duration of a communication session. Unlike text encoding, binary encoding does not have to use special handling for binary data, such as using Base64, but represents bytes as bytes.  
  
 If your solution does not require interoperability, but you still want to use HTTP transport, you can compose the <xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement> into a custom binding that uses the <xref:System.ServiceModel.Channels.HttpTransportBindingElement> class for the transport. If a number of clients on your service require interoperability, it is recommended that you expose parallel endpoints that each has the appropriate transport and encoding choices for the respective clients enabled.  
  
### Enabling MTOM  
 When interoperability is a requirement and large binary data must be sent, then MTOM message encoding is the alternative encoding strategy that you can enable on the standard <xref:System.ServiceModel.BasicHttpBinding> or <xref:System.ServiceModel.WSHttpBinding> bindings by setting the respective `MessageEncoding` property to <xref:System.ServiceModel.WSMessageEncoding.Mtom> or by composing the <xref:System.ServiceModel.Channels.MtomMessageEncodingBindingElement> into a <xref:System.ServiceModel.Channels.CustomBinding>. The following example code, extracted from the [MTOM Encoding](../../../../docs/framework/wcf/samples/mtom-encoding.md) sample demonstrates how to enable MTOM in configuration.  
  
```xml  
<system.serviceModel>  
     …  
    <bindings>  
      <wsHttpBinding>  
        <binding name="ExampleBinding" messageEncoding="Mtom"/>  
      </wsHttpBinding>  
    </bindings>  
     …  
<system.serviceModel>  
```  
  
 As mentioned earlier, the decision to use MTOM encoding depends on the data volume you are sending. Also, because MTOM is enabled at the binding level, enabling MTOM affects all operations on a given endpoint.  
  
 Because the MTOM encoder always emits an MTOM-encoded MIME/multi-part message regardless of whether binary data ends up being externalized, you should generally only enable MTOM for endpoints that exchange messages with more than 1 KB of binary data. Also, the service contracts designed for use with MTOM-enabled endpoints should, when possible, be constrained to specifying such data transfer operations. Related control functionality should reside on a separate contract. This "MTOM-only" rule applies only to messages sent through an MTOM-enabled endpoint; the MTOM-encoder can decode and parse incoming non-MTOM messages as well.  
  
 Using the MTOM encoder conforms with all other [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] features. Note that it may not be possible to observe this rule in all cases, such as when session support is required.  
  
### Programming Model  
 Regardless of which of the three built-in encoders you use in your application, the programming experience is identical with regards to transferring binary data. The difference is in how [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] handles the data based on their data types.  
  
```  
[DataContract]  
class MyData  
{  
    [DataMember]  
    byte[] binaryBuffer;  
    [DataMember]  
    string someStringData;  
}   
```  
  
 When using MTOM, the preceding data contract is serialized according to the following rules:  
  
-   If `binaryBuffer` is not `null` and individually contains enough data to justify the MTOM externalization overhead (MIME headers, and so on) when compared to Base64 encoding, the data is externalized and carried with the message as a binary MIME part. If the threshold is not exceeded, the data is encoded as Base64.  
  
-   The string (and all other types that are not binary) is always represented as a string inside the message body, regardless of size.  
  
 The effect on the MTOM encoding is the same whether you use an explicit data contract, as shown in the preceding example, use a parameter list in an operation, have nested data contracts, or transfer a data contract object inside a collection. Byte arrays are always candidates for optimization and are optimized if the optimization thresholds are being met.  
  
> [!NOTE]
>  You should not be using <xref:System.IO.Stream?displayProperty=nameWithType> derived types inside of data contracts. Stream data should be communicated using the streaming model, explained in the following "Streaming Data" section.  
  
## Streaming Data  
 When you have a large amount of data to transfer, the streaming transfer mode in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is a feasible alternative to the default behavior of buffering and processing messages in memory in their entirety.  
  
 As mentioned earlier, enable streaming only for large messages (with text or binary content) if the data cannot be segmented, if the message must be delivered in a timely fashion, or if the data is not yet fully available when the transfer is initiated.  
  
### Restrictions  
 You cannot use a significant number of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] features when streaming is enabled:  
  
-   Digital signatures for the message body cannot be performed because they require computing a hash over the entire message contents. With streaming, the content is not fully available when the message headers are constructed and sent and, therefore, a digital signature cannot be computed.  
  
-   Encryption depends on digital signatures to verify that the data has been reconstructed correctly.  
  
-   Reliable sessions must buffer sent messages on the client for redelivery if a message gets lost in transfer and must hold messages on the service before handing them to the service implementation to preserve message order in case messages are received out-of-sequence.  
  
 Because of these functional constraints, you can use only transport-level security options for streaming and you cannot turn on reliable sessions. Streaming is only available with the following system-defined bindings:  
  
-   <xref:System.ServiceModel.BasicHttpBinding>  
  
-   <xref:System.ServiceModel.NetTcpBinding>  
  
-   <xref:System.ServiceModel.NetNamedPipeBinding>  
  
-   <xref:System.ServiceModel.WebHttpBinding>  
  
 Because the underlying transports of <xref:System.ServiceModel.NetTcpBinding> and <xref:System.ServiceModel.NetNamedPipeBinding> have inherent reliable delivery and connection-based session support, unlike HTTP, these two bindings are only minimally affected by these constraints, in practice.  
  
 Streaming is not available with the Message Queuing (MSMQ) transport and so cannot be used with the <xref:System.ServiceModel.NetMsmqBinding> or the <xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding> class. The Message Queuing transport only supports buffered data transfers with a constrained message size, while all other transports do not have any practical message size limit for the vast majority of scenarios.  
  
 Streaming is also not available when using the Peer Channel transport, so is not available with the <xref:System.ServiceModel.NetPeerTcpBinding>.  
  
#### Streaming and Sessions  
 You may get unexpected behavior when streaming calls with a session-based binding. All streaming calls are made through a single channel (the datagram channel) that does not support sessions even if the binding being used is configured to use sessions. If multiple clients make streaming calls to the same service object over a session-based binding and the service object's concurrency mode is set to single and its instance context mode is set to PerSession, all calls must go through the datagram channel and so only one call is processed at a time. One or more clients may then time out. You can work around this issue by either setting the service object's Instance Context Mode to PerCall or Concurrency to Multiple.  
  
> [!NOTE]
>  MaxConcurrentSessions has no effect in this case because there is only one "session" available.  
  
### Enabling Streaming  
 You can enable streaming in the following ways:  
  
-   Send and accept requests in streaming mode, and accept and return responses in buffered mode (<xref:System.ServiceModel.TransferMode.StreamedRequest>).  
  
-   Send and accept requests in buffered mode, and accept and return responses in streamed mode (<xref:System.ServiceModel.TransferMode.StreamedResponse>).  
  
-   Send and receive requests and responses in streamed mode in both directions. (<xref:System.ServiceModel.TransferMode.Streamed>).  
  
 You can disable streaming by setting the transfer mode to <xref:System.ServiceModel.TransferMode.Buffered>, which is the default setting on all bindings. The following code shows how to set the transfer mode in configuration.  
  
```xml  
<system.serviceModel>  
     …  
    <bindings>  
      <basicHttpBinding>  
        <binding name="ExampleBinding" transferMode="Streaming"/>  
      </basicHttpBinding>  
    </bindings>  
     …  
<system.serviceModel>  
```  
  
 When you instantiate your binding in code, you must set the respective `TransferMode` property of the binding (or the transport binding element if you are composing a custom binding) to one of the previously mentioned values.  
  
 You can turn on streaming for requests and replies or for both directions independently at either side of the communicating parties without affecting functionality. However, you should always assume that the transferred data size is so significant that enabling streaming is justified on both endpoints of a communication link. For cross-platform communication where one of the endpoints is not implemented with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], the ability to use streaming depends on the platform's streaming capabilities. Another rare exception might be a memory-consumption driven scenario where a client or service must minimize its working set and can only afford small buffer sizes.  
  
### Enabling Asynchronous Streaming  
 To enable asynchronous streaming, add the  <xref:System.ServiceModel.Description.DispatcherSynchronizationBehavior> endpoint behavior to the service host and set its <xref:System.ServiceModel.Description.DispatcherSynchronizationBehavior.AsynchronousSendEnabled%2A> property to `true`. We have also added the capability of true asynchronous streaming on the send side. This improves scalability of the service in scenarios where it is streaming messages to multiple clients some of which are slow in reading possibly due to network congestion or are not reading at all. In these scenarios we now do not block individual threads on the service per client. This ensures that the service is able to process many more clients thereby improving the scalability of the service.  
  
### Programming Model for Streamed Transfers  
 The programming model for streaming is straightforward. For receiving streamed data, specify an operation contract that has a single <xref:System.IO.Stream> typed input parameter. For returning streamed data, return a <xref:System.IO.Stream> reference.  
  
```  
[ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]  
public interface IStreamedService  
{  
    [OperationContract]  
    Stream Echo(Stream data);  
    [OperationContract]  
    Stream RequestInfo(string query);  
    [OperationContract(OneWay=true)]  
    void ProvideInfo(Stream data);  
}  
```  
  
 The operation `Echo` in the preceding example receives and returns a stream and should therefore be used on a binding with <xref:System.ServiceModel.TransferMode.Streamed>. For the operation `RequestInfo`, <xref:System.ServiceModel.TransferMode.StreamedResponse> is best suited, because it only returns a <xref:System.IO.Stream>. The one-way operation is best suited for <xref:System.ServiceModel.TransferMode.StreamedRequest>.  
  
 Note that adding a second parameter to the following `Echo` or `ProvideInfo` operations causes the service model to revert back to a buffered strategy and use the run-time serialization representation of the stream. Only operations with a single input stream parameter are compatible with end-to-end request streaming.  
  
 This rule similarly applies to message contracts. As shown in the following message contract, you can have only a single body member in your message contract that is a stream. If you want to communicate additional information with the stream, this information must be a carried in message headers. The message body is exclusively reserved for the stream content.  
  
```  
[MessageContract]  
public class UploadStreamMessage  
{  
   [MessageHeader]  
   public string appRef;  
   [MessageBodyMember]  
   public Stream data;  
}   
```  
  
 Streamed transfers end and the message is closed when the stream reaches the end of file (EOF). When sending a message (returning a value or invoking an operation), you can pass a <xref:System.IO.FileStream> and the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] infrastructure subsequently pulls all the data from that stream until the stream has been completely read and reached EOF. To transfer streamed data for the source that no such pre-built <xref:System.IO.Stream> derived class exists, construct such a class, overlay that class over your stream source, and use that as the argument or return value.  
  
 When receiving a message, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] constructs a stream over the Base64-encoded message body content (or the respective MIME part if using MTOM) and the stream reaches EOF when the content has been read.  
  
 Transport-level streaming also works with any other message contract type (parameter lists, data contract arguments, and explicit message contract), but because the serialization and deserialization of such typed messages requires buffering by the serializer, using such contract variants is not advisable.  
  
### Special Security Considerations for Large Data  
 All bindings allow you to constrain the size of incoming messages to prevent denial-of-service attacks. The <xref:System.ServiceModel.BasicHttpBinding>, for example, exposes a [System.ServiceModel.BasicHttpBinding.MaxReceivedMessageSize](xref:System.ServiceModel.HttpBindingBase.MaxReceivedMessageSize%2A) property that bounds the size of the incoming message, and so also bounds the maximum amount of memory that is accessed when processing the message. This unit is set in bytes with a default value of 65,536 bytes.  
  
 A security threat that is specific to the large data streaming scenario provokes a denial of service by causing data to be buffered when the receiver expects it to be streamed. For example, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] always buffers the SOAP headers of a message, and so an attacker may construct a large malicious message that consists entirely of headers to force the data to be buffered. When streaming is enabled, the `MaxReceivedMessageSize` may be set to an extremely large value, because the receiver never expects the entire message to be buffered in memory at once. If [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is forced to buffer the message, a memory overflow occurs.  
  
 Therefore, restricting the maximum incoming message size is not enough in this case. The `MaxBufferSize` property is required to constrain the memory that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] buffers. It is important to set this to a safe value (or keep it at the default value) when streaming. For example, suppose your service must receive files up to 4 GB in size and store them on the local disk. Suppose also that your memory is constrained in such a way that you can only buffer 64 KB of data at a time. Then you would set the `MaxReceivedMessageSize` to 4 GB and `MaxBufferSize` to 64 KB. Also, in your service implementation, you must ensure that you read only from the incoming stream in 64-KB chunks and do not read the next chunk before the previous one has been written to disk and discarded from memory.  
  
 It is also important to understand that this quota only limits the buffering done by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and cannot protect you against any buffering that you do in your own service or client implementation. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] additional security considerations, see [Security Considerations for Data](../../../../docs/framework/wcf/feature-details/security-considerations-for-data.md).  
  
> [!NOTE]
>  The decision to use either buffered or streamed transfers is a local decision of the endpoint. For HTTP transports, the transfer mode does not propagate across a connection or to proxy servers and other intermediaries. Setting the transfer mode is not reflected in the description of the service interface. After generating a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client to a service, you must edit the configuration file for services intended to be used with streamed transfers to set the mode. For TCP and named pipe transports, the transfer mode is propagated as a policy assertion.  
  
## See Also  
 [How to: Enable Streaming](../../../../docs/framework/wcf/feature-details/how-to-enable-streaming.md)
