---
title: "<byteStreamMessageEncoding>"
ms.date: "03/30/2017"
ms.assetid: bbadd8dd-60a2-4007-b959-89373a8a7d60
---
# \<byteStreamMessageEncoding>
Specifies the message encoding as a stream of bytes, with the option to specify the character encoding.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<binaryMessageEncoding>  
  
## Syntax  
  
```xml  
<byteStreamMessageEncoding />
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|messageVersion|Specifies the SOAP version of the messages sent using the binding. This property can only be set to the message version value of <xref:System.ServiceModel.Channels.MessageVersion.None%2A>. The byte stream message encoder does not support any other message versions.<br /><br /> This attribute is of type <xref:System.ServiceModel.Channels.MessageVersion>.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<readerQuotas>](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/ms731325(v=vs.100))|Defines the constraints on the complexity of SOAP messages that can be processed by endpoints configured with this binding. This element is of type <xref:System.ServiceModel.Configuration.XmlDictionaryReaderQuotasElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](../../../misc/binding.md)|Defines all binding capabilities of the custom binding.|  
  
## See also

- <xref:System.ServiceModel.Configuration.ByteStreamMessageEncodingElement>
- <xref:System.ServiceModel.Channels.CustomBinding>
- <xref:System.ServiceModel.Channels.MessageEncodingBindingElement>
- <xref:System.ServiceModel.Channels.ByteStreamMessageEncodingBindingElement>
- [Message Encoding](message-encoding.md)
- [Choosing a Message Encoder](../../../wcf/feature-details/choosing-a-message-encoder.md)
- [Bindings](../../../wcf/bindings.md)
- [Extending Bindings](../../../wcf/extending/extending-bindings.md)
- [Custom Bindings](../../../wcf/extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
