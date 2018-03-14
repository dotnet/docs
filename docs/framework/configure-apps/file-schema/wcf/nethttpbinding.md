---
title: "&lt;netHttpBinding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b0d81ca0-87c5-4090-8baa-e390fd3656d2
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;netHttpBinding&gt;
Represents a binding that a [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] service can use to configure and expose endpoints that are able to communicate over HTTP. When used with a duplex contract, Web Sockets will be used, otherwise HTTP will be used.  
  
 \<system.ServiceModel>  
\<bindings>  
\<netHttpBinding>  
  
## Syntax  

```xml  
<netHttpBinding>  
   <binding   
       allowCookies="Boolean"  
       bypassProxyOnLocal="Boolean"  
       closeTimeout="TimeSpan"   
       hostNameComparisonMode="StrongWildCard/Exact/WeakWildcard"  
       maxBufferPoolSize="Integer"  
       maxBufferSize="Integer"  
       maxReceivedMessageSize="Integer"  
       messageEncoding="Binary/Text/Mtom"  
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
           <message   
                 algorithmSuite="Basic128/Basic192/Basic256/Basic128Rsa15/Basic256Rsa15/TripleDes/TripleDesRsa15/Basic128Sha256/Basic192Sha256/TripleDesSha256/Basic128Sha256Rsa15/Basic192Sha256Rsa15/Basic256Sha256Rsa15/TripleDesSha256Rsa15"  
                            clientCredentialType="UserName/Certificate"/>  
       </security>  
       <readerQuotas   
            maxArrayLength="Integer"  
            maxBytesPerRead="Integer"  
            maxDepth="Integer"             maxNameTableCharCount="Integer"                maxStringContentLength="Integer" />  
   </binding>  
</netHttpBinding>  
```  
  
## Type  
 `Type`  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`allowCookies`|A Boolean value that indicates whether the client accepts cookies and propagates them on future requests. The default is `false`.<br /><br /> You can use this property when you interact with ASMX Web services that use cookies. In this way, you can be sure that the cookies returned from the server are automatically copied to all future client requests for that service.|  
|`bypassProxyOnLocal`|A Boolean value that indicates whether to bypass the proxy server for local addresses. The default is `false`.<br /><br /> An Internet resource is local if it has a local address. A local address is one that is on same computer, the local LAN or intranet and is identified, syntactically, by the lack of a period (.) as in the URIs "http://webserver/" and "http://localhost/".<br /><br /> Setting this attribute determines whether endpoints configured with the BasicHttpBinding use the proxy server when accessing local resources. If this attribute is `true`, requests to local Internet resources do not use the proxy server. Use the host name (rather than localhost) if you want clients to go through a proxy when talking to services on the same machine when this attribute is set to `true`.<br /><br /> When this attribute is `false`, all Internet requests are made through the proxy server.|  
|`closeTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for a close operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|`hostnameComparisonMode`|Specifies the HTTP hostname comparison mode used to parse URIs. This attribute is of type `System.ServiceModel.HostnameComparisonMode`, which indicates whether the hostname is used to reach the service when matching on the URI. The default value is `StrongWildcard`>, which ignores the hostname in the match.|  
|`maxBufferPoolSize`|An integer value that specifies the maximum amount of memory that is allocated for use by the manager of the message buffers that receive messages from the channel. The default value is 524288 (0x80000) bytes.<br /><br /> The Buffer Manager minimizes the cost of using buffers by using a buffer pool. Buffers are required to process messages by the service when they come out of the channel. If there is not sufficient memory in the buffer pool to process the message load, the Buffer Manager must allocate additional memory from the CLR heap, which increases the garbage collection overhead. Extensive allocation from the CLR garbage heap is an indication that the buffer pool size is too small and that performance can be improved with a larger allocation by increasing the limit specified by this attribute.|  
|`maxBufferSize`|An integer value that specifies the maximum size, in bytes, of a buffer that stores messages while they are processed for an endpoint configured with this binding. The default value is 65,536 bytes.|  
|`maxReceivedMessageSize`|A positive integer that defines the maximum message size, in bytes, including headers, for a message that can be received on a channel configured with this binding. The sender receives a SOAP fault if the message is too large for the receiver. The receiver drops the message and creates an entry of the event in the trace log. The default is 65,536 bytes.|  
|`messageEncoding`|Defines the encoder used to encode the SOAP message. Valid values include the following:<br /><br /> -   Text: Use a text message encoder.<br />-   Mtom: Use a Message Transmission Organization Mechanism 1.0 (MTOM) encoder.<br /><br /> The default is Text. This attribute is of type <xref:System.ServiceModel.WSMessageEncoding>.|  
|`name`|A string that contains the configuration name of the binding. This value should be unique because it is used as an identification for the binding. Each binding has a `name` and `namespace` attribute that together uniquely identify it in the metadata of the service. In addition, this name is unique among bindings of the same type. Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).|  
|`namespace`|Specifies the XML namespace of the binding. The default value is "http://tempuri.org/Bindings". Each binding has a `name` and `namespace` attribute that together uniquely identify it in the metadata of the service.|  
|`openTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for an open operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|`proxyAddress`|A URI that contains the address of the HTTP proxy. If `useSystemWebProxy` is set to `true`, this setting must be `null`. The default is `null`.|  
|`receiveTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for a receive operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:10:00.|  
|`sendTimeout`|A <xref:System.TimeSpan> value that specifies the interval of time provided for a send operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|`textEncoding`|Sets the character set encoding to be used for emitting messages on the binding. Valid values include the following:<br /><br /> -   BigEndianUnicode: Unicode BigEndian encoding.<br />-   Unicode: 16-bit encoding.<br />-   UTF8: 8-bit encoding<br /><br /> The default is UTF8. This attribute is of type <xref:System.Text.Encoding>.|  
|`transferMode`|A valid <xref:System.ServiceModel.TransferMode> value that specifies whether messages are buffered or streamed on a request or response.|  
|`useDefaultWebProxy`|A Boolean value that specifies whether the auto-configured HTTP proxy of the system should be used, if available. The default is `true`.|  
|||  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-basichttpbinding.md)|Defines the security settings for the binding. This element is of type `NetHttpSecurityElement`.|  
|[\<readerQuotas>](http://msdn.microsoft.com/library/3e5e42ff-cef8-478f-bf14-034449239bfd)|Defines the constraints on the complexity of SOAP messages that can be processed by endpoints configured with this binding. This element is of type <xref:System.ServiceModel.Configuration.XmlDictionaryReaderQuotasElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<bindings>](../../../../../docs/framework/configure-apps/file-schema/wcf/bindings.md)|This element holds a collection of standard and custom bindings.|  
  
## Remarks  
 The NetHttpBinding uses HTTP as the transport for sending messages. When used with a duplex contract, Web Sockets will be used.  When used with a request-reply contract NetHttpBinding will behave like a BasicHttpBinding with a binary encoder.  
  
 Security is turned off by default, but can be added setting the mode attribute of the [\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-basichttpbinding.md) child element to a value other than `None`. It uses a "Text" message encoding and UTF-8 text encoding by default.  
  
## Example  
 The following example demonstrates the use of <xref:System.ServiceModel.NetHttpBinding> that provides HTTP communication and maximum interoperability with first- and second-generation Web services. The binding is specified in the configuration files for the client and service. The binding type is specified using the `binding` attribute of the `<endpoint>` element. If you want to configure the basic binding and change some of its settings, it is necessary to define a binding configuration. The endpoint must reference the binding configuration by name by using the `bindingConfiguration` attribute of the `<endpoint>` element, as shown in the following configuration code for the service.  
  
```xml  
<system.serviceModel>   
  <services>  
    <service   
        type="Microsoft.ServiceModel.Samples.CalculatorService"  
        behaviorConfiguration="CalculatorServiceBehavior">  
       <endpoint address=""  
             binding="netHttpBinding"  
             bindingConfiguration="Binding1"   
             contract="Microsoft.ServiceModel.Samples.ICalculator" />  
    </service>  
  </services>  
  <bindings>  
     <netHttpBinding>  
        <binding name="Binding1"   
               hostNameComparisonMode="StrongWildcard"   
               receiveTimeout="00:10:00"  
               sendTimeout="00:10:00"  
               openTimeout="00:10:00"  
               closeTimeout="00:10:00"  
               maxReceivedMessageSize="65536"   
               maxBufferSize="65536"   
               maxBufferPoolSize="524288"   
               transferMode="Buffered"   
               messageEncoding="Binary"   
               textEncoding="utf-8"  
               bypassProxyOnLocal="false"  
               useDefaultWebProxy="true" >  
              <security mode="None" />  
         </binding>  
     </netHttpBinding>  
  </bindings>  
</system.serviceModel>  
```  
  
## Example  
 Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. The functionality from the previous example can be accomplished by removing the bindingConfiguration from the endpoint address and the name frm the binding.  
  
```xml  
<system.serviceModel>   
  <services>  
    <service   
        type="Microsoft.ServiceModel.Samples.CalculatorService"  
        behaviorConfiguration="CalculatorServiceBehavior">  
       <endpoint address=""  
             binding="netHttpBinding"  
             contract="Microsoft.ServiceModel.Samples.ICalculator" />  
    </service>  
  </services>  
  <bindings>  
     <netHttpBinding>  
        <binding   
               hostNameComparisonMode="StrongWildcard"   
               receiveTimeout="00:10:00"  
               sendTimeout="00:10:00"  
               openTimeout="00:10:00"  
               closeTimeout="00:10:00"  
               maxReceivedMessageSize="65536"   
               maxBufferSize="65536"   
               maxBufferPoolSize="524288"   
               transferMode="Buffered"   
               messageEncoding="Binary"   
               textEncoding="utf-8"  
               bypassProxyOnLocal="false"  
               useDefaultWebProxy="true" >  
              <security mode="None" />  
         </binding>  
     </netHttpBinding>  
  </bindings>  
</system.serviceModel>  
```  
  
 For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).  
  
## See Also  
 <xref:System.ServiceModel.Channels.Binding>  
 <xref:System.ServiceModel.Channels.BindingElement>  
 <xref:System.ServiceModel.BasicHttpBinding>  
 <xref:System.ServiceModel.Configuration.BasicHttpBindingElement>  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 [\<binding>](../../../../../docs/framework/misc/binding.md)
