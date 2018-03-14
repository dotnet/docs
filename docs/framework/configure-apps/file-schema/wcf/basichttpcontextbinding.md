---
title: "&lt;basicHttpContextBinding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 39b16b82-4ec6-4eff-8031-67e026870961
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;basicHttpContextBinding&gt;
Specifying a binding that provides context for the <xref:System.ServiceModel.BasicHttpBinding> to be exchanged by enabling HTTP cookies as the exchange mechanism.  
  
 \<system.ServiceModel>  
\<bindings>  
\<basicHttpContextBinding>  
  
## Syntax  
  
```xml  
<basicHttpContextBinding>  
   <binding   
       allowCookies="Boolean"  
       bypassProxyOnLocal="Boolean"  
       closeTimeout="TimeSpan"   
       envelopeVersion="None/Soap11/Soap12"  
       hostNameComparisonMode="StrongWildCard/Exact/WeakWildcard"  
       maxBufferPoolSize="Integer"  
       maxBufferSize="Integer"  
       maxReceivedMessageSize="Integer"  
       messageEncoding="Text/Mtom"  
       name="string"   
       openTimeout="TimeSpan"   
       proxyAddress="URI"  
       receiveTimeout="TimeSpan"  
       sendTimeout="TimeSpan"  
       textEncoding="UnicodeFffeTextEncoding/Utf16TextEncoding/Utf8TextEncoding"  
       transferMode="Buffered/Streamed/StreamedRequest/StreamedResponse"  
       useDefaultWebProxy="Boolean"  
       <security mode="None/Transport/Message/TransportWithMessageCredential/TransportCredentialOnly">  
           <transport clientCredentialType="None/Basic/Digest/Ntlm/Windows/Certificate"  
                  proxyCredentialType="None/Basic/Digest/Ntlm/Windows"  
                                    realm="string" />  
           <message  algorithmSuite="Aes128/Aes192/Aes256/Rsa15Aes128/ Rsa15Aes256/TripleDes"  
                                    clientCredentialType="UserName/Certificate"/>  
       </security>  
       <readerQuotas             maxArrayLength="Integer"            maxBytesPerRead="Integer"            maxDepth="Integer"             maxNameTableCharCount="Integer"                     maxStringContentLength="Integer" />   </binding>  
</basicHttpContextBinding>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`allowCookies`|A Boolean value that indicates whether the client accepts cookies and propagates them on future requests. The default is `false`.<br /><br /> You can use this property when you interact with ASMX Web services that use cookies. In this way, you can be sure that the cookies returned from the server are automatically copied to all future client requests for that service.|  
|`bypassProxyOnLocal`|A Boolean value that indicates whether to bypass the proxy server for local addresses. The default is `false`.<br /><br /> An Internet resource is local if it has a local address. A local address is one that is on same computer, the local LAN or intranet and is identified, syntactically, by the lack of a period (.) as in the URIs "http://webserver/" and "http://localhost/".<br /><br /> Setting this attribute determines whether endpoints configured with the BasicHttpBinding use the proxy server when accessing local resources. If this attribute is `true`, requests to local Internet resources do not use the proxy server. Use the host name (rather than localhost) if you want clients to go through a proxy when talking to services on the same machine when this attribute is set to `true`.<br /><br /> When this attribute is `false`, all Internet requests are made through the proxy server.|  
|`closeTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for a close operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|`envelopeVersion`|Specifies the version of SOAP that is used for messages that are processed by this binding. The only valid value is Soap11.|  
|`hostnameComparisonMode`|Specifies the HTTP hostname comparison mode used to parse URIs. This attribute is of type <xref:System.ServiceModel.HostNameComparisonMode>, which indicates whether the hostname is used to reach the service when matching on the URI. The default value is <xref:System.ServiceModel.HostNameComparisonMode.StrongWildcard>, which ignores the hostname in the match.|  
|`maxBufferPoolSize`|An integer value that specifies the maximum amount of memory that is allocated for use by the manager of the message buffers that receive messages from the channel. The default value is 524288 (0x80000) bytes.<br /><br /> The Buffer Manager minimizes the cost of using buffers by using a buffer pool. Buffers are required to process messages by the service when they come out of the channel. If there is not sufficient memory in the buffer pool to process the message load, the Buffer Manager must allocate additional memory from the CLR heap, which increases the garbage collection overhead. Extensive allocation from the CLR garbage heap is an indication that the buffer pool size is too small and that performance can be improved with a larger allocation by increasing the limit specified by this attribute.|  
|`maxBufferSize`|An integer value that specifies the maximum size, in bytes, of a buffer that stores messages while they are processed for an endpoint configured with this binding. The default value is 65,536 bytes.|  
|`maxReceivedMessageSize`|A positive integer that defines the maximum message size, in bytes, including headers, for a message that can be received on a channel configured with this binding. The sender receives a SOAP fault if the message is too large for the receiver. The receiver drops the message and creates an entry of the event in the trace log. The default is 65,536 bytes.|  
|`messageEncoding`|Defines the encoder used to encode the SOAP message. Valid values include the following:<br /><br /> -   Text: Use a text message encoder.<br />-   Mtom: Use a Message Transmission Organization Mechanism 1.0 (MTOM) encoder.<br /><br /> The default is Text. This attribute is of type <xref:System.ServiceModel.WSMessageEncoding>.|  
|`messageVersion`|Specifies the message version used by clients and services configured with the binding. This attribute is of type <xref:System.ServiceModel.Channels.MessageVersion>.|  
|`name`|A string that contains the configuration name of the binding. This value should be unique because it is used as an identification for the binding. Each binding has a `name` and `namespace` attribute that together uniquely identify it in the metadata of the service. In addition, this name is unique among bindings of the same type. Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).|  
|`namespace`|Specifies the XML namespace of the binding. The default value is "http://tempuri.org/Bindings". Each binding has a `name` and `namespace` attribute that together uniquely identify it in the metadata of the service.|  
|`openTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for an open operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|`proxyAddress`|A URI that contains the address of the HTTP proxy. If `useSystemWebProxy` is set to `true`, this setting must be `null`. The default is `null`.|  
|`receiveTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for a receive operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:10:00.|  
|`sendTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for a send operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|`textEncoding`|Sets the character set encoding to be used for emitting messages on the binding. Valid values include the following:<br /><br /> -   BigEndianUnicode: Unicode BigEndian encoding.<br />-   Unicode: 16-bit encoding.<br />-   UTF8: 8-bit encoding<br /><br /> The default is UTF8. This attribute is of type <xref:System.Text.Encoding>.|  
|`transferMode`|A valid <xref:System.ServiceModel.TransferMode> value that specifies whether messages are buffered or streamed on a request or response.|  
|`useDefaultWebProxy`|A Boolean value that specifies whether the auto-configured HTTP proxy of the system should be used, if available. The default is `true`.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-basichttpbinding.md)|Defines the security settings for the binding. This element is of type <xref:System.ServiceModel.Configuration.BasicHttpSecurityElement>.|  
|[\<readerQuotas>](http://msdn.microsoft.com/library/3e5e42ff-cef8-478f-bf14-034449239bfd)|Defines the constraints on the complexity of SOAP messages that can be processed by endpoints configured with this binding. This element is of type <xref:System.ServiceModel.Configuration.XmlDictionaryReaderQuotasElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<bindings>](../../../../../docs/framework/configure-apps/file-schema/wcf/bindings.md)|This element holds a collection of standard and custom bindings.|  
  
## Remarks  
 This binding element provides a protection level and an exchange mechanism as part of the context for a `BasicHttpBinding`.  
  
## See Also  
 <xref:System.ServiceModel.BasicHttpBinding>  
 <xref:System.ServiceModel.BasicHttpContextBinding>  
 <xref:System.ServiceModel.Configuration.BasicHttpContextBindingElement>  
 <xref:System.ServiceModel.Channels.ContextBindingElement>  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 [\<binding>](../../../../../docs/framework/misc/binding.md)  
 [\<basicHttpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/basichttpbinding.md)
