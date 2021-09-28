---
description: "Learn more about: <mtomMessageEncoding>"
title: "<mtomMessageEncoding>"
ms.date: "03/30/2017"
ms.assetid: 7865d171-cd1e-430a-8421-39cc13541d1b
---
# \<mtomMessageEncoding>

Specifies the encoding and message versioning used for SOAP Message Transmission Optimization Mechanism (MTOM) based messages.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<customBinding>**](custombinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<mtomMessageEncoding>**  
  
## Syntax  
  
```xml  
<mtomMessageEncoding maxBufferSize="Integer"
                     maxReadPoolSize="Integer"
                     maxWritePoolSize="Integer"
                     messageVersion="Soap11Addressing1/Soap12Addressing10"
                     writeEncoding="UnicodeFffeTextEncoding/Utf16TextEncoding/Utf8TextEncoding" />
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|maxBufferSize|An integer that specifies the maximum size of the buffer that can be used.|  
|maxReadPoolSize|An integer that specifies how many messages can be read simultaneously without allocating new readers. Larger pool sizes make the system more tolerant to activity spikes at the cost of a larger working set. The default is 64.|  
|maxWritePoolSize|An integer that specifies how many messages can be sent simultaneously without allocating new writers. Larger pool sizes make the system more tolerant to activity spikes at the cost of a larger working set. The default is 16.|  
|messageVersion|Specifies the SOAP version of the messages sent using the binding. Valid values are<br /><br /> -   Soap11Addressing1<br />-   Soap12Addressing10<br /><br /> The default is Soap12Addressing10. This attribute is of type <xref:System.ServiceModel.Channels.MessageVersion>.|  
|writeEncoding|Specifies the character set encoding to be used for emitting messages on the binding. Valid values are<br /><br /> -   UnicodeFffeTextEncoding: Unicode BigEndian encoding<br />-   Utf16TextEncoding: Unicode encoding<br />-   Utf8TextEncoding: 8-bit encoding<br /><br /> The default is Utf8TextEncoding. This attribute is of type <xref:System.Text.Encoding>.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<readerQuotas>](/previous-versions/dotnet/netframework-4.0/ms731325(v=vs.100))|Defines the constraints on the complexity of SOAP messages that can be processed by endpoints configured with this binding. This element is of type <xref:System.ServiceModel.Configuration.XmlDictionaryReaderQuotasElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](bindings.md)|Defines all binding capabilities of the custom binding.|  
  
## Remarks  

 Encoding is the process of transforming a message into a sequence of bytes. Decoding is the reverse process. Windows Communication Foundation (WCF) includes three types of encoding for SOAP messages: Text, Binary and Message Transmission Optimization Mechanism (MTOM).  
  
 The `MtomMessageEncoding` element specifies the character encoding and message versioning and other settings used for messages using a Message Transmission Optimization Mechanism (MTOM) encoding. MTOM is an efficient technology for transmitting binary data in WCF messages. The MTOM encoder attempts to create a balance between efficiency and interoperability. The MTOM encoding transmits most XML in textual form, but optimizes large blocks of binary data by transmitting them as-is, without conversion to their base64 encoded format.  
  
## Example  
  
```xml  
<mtomMessageEncoding maxReadPoolSize="211"
                     maxWritePoolSize="2132"
                     messageVersion="Soap11Addressing10"
                     textEncoding="utf-8" />
```  
  
## See also

- <xref:System.ServiceModel.Configuration.MtomMessageEncodingElement>
- <xref:System.ServiceModel.Channels.CustomBinding>
- <xref:System.ServiceModel.Channels.MessageEncodingBindingElement>
- <xref:System.ServiceModel.Channels.MtomMessageEncodingBindingElement>
- [Message Encoding](message-encoding.md)
- [Choosing a Message Encoder](../../../wcf/feature-details/choosing-a-message-encoder.md)
- [Bindings](../../../wcf/bindings.md)
- [Extending Bindings](../../../wcf/extending/extending-bindings.md)
- [Custom Bindings](../../../wcf/extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
