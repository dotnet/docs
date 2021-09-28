---
description: "Learn more about: <webHttpBinding>"
title: "<webHttpBinding>"
ms.date: "03/30/2017"
ms.assetid: 84179d77-825d-44b9-895a-ab08e7aa044d
---
# \<webHttpBinding>

Defines a binding element that is used to configure endpoints for Windows Communication Foundation (WCF) Web services that respond to HTTP requests instead of SOAP messages.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<webHttpBinding>**  
  
## Syntax  
  
```xml  
<webHttpBinding>
  <binding allowCookies="Boolean"
           bypassProxyOnLocal="Boolean"
           closeTimeout="TimeSpan"
           hostNameComparisonMode="StrongWildCard/Exact/WeakWildcard"
           maxBufferPoolSize="integer"
           maxBufferSize="integer"
           maxReceivedMessageSize="Integer"
           name="string"
           openTimeout="TimeSpan"
           proxyAddress="URI"
           receiveTimeout="TimeSpan"
           sendTimeout="TimeSpan"
           transferMode="Buffered/Streamed/StreamedRequest/StreamedResponse"
           useDefaultWebProxy="Boolean"
           writeEncoding="UnicodeFffeTextEncoding/Utf16TextEncoding/Utf8TextEncoding">
    <security mode="None/Transport/TransportCredentialOnly">
      <transport clientCredentialType="Basic/Certificate/Digest/None/Ntlm/Windows"
                 proxyCredentialType="Basic/Digest/None/Ntlm/Windows"
                 realm="string" />
    </security>
    <readerQuotas maxArrayLength="Integer"
                  maxBytesPerRead="Integer"
                  maxDepth="Integer"
                  maxNameTableCharCount="Integer"
                  maxStringContentLength="Integer" />
  </binding>
</webHttpBinding>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|allowCookies|A Boolean value that indicates whether the client accepts cookies and propagates them on future requests. The default is false.<br /><br /> You can use this property when you interact with ASMX Web services that use cookies. In this way, you can be sure that the cookies returned from the server are automatically copied to all future client requests for that service.|  
|bypassProxyOnLocal|A Boolean value that indicates whether to bypass the proxy server for local addresses. The default is `false`.|  
|closeTimeout|A <xref:System.TimeSpan> value that specifies the interval of time provided for a close operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|hostnameComparisonMode|Specifies the HTTP hostname comparison mode used to parse URIs. This attribute is of type <xref:System.ServiceModel.HostNameComparisonMode>, which indicates whether the hostname is used to reach the service when matching on the URI. The default value is <xref:System.ServiceModel.HostNameComparisonMode.StrongWildcard>, which ignores the hostname in the match.|  
|maxBufferPoolSize|An integer that specifies the maximum buffer pool size for this binding. The default is 524,288 bytes (512 * 1024). Many parts of Windows Communication Foundation (WCF) use buffers. Creating and destroying buffers each time they are used is expensive, and garbage collection for buffers is also expensive. With buffer pools, you can take a buffer from the pool, use it, and return it to the pool once you are done. Thus the overhead in creating and destroying buffers is avoided.|  
|maxBufferSize|An integer that specifies the maximum amount of memory that is allocated for use by the manager of the message buffers that receive messages from the channel. The default value is 524,288 (0x80000) bytes.|  
|maxReceivedMessageSize|A positive integer that specifies the maximum message size, in bytes, including headers, that can be received on a channel configured with this binding. The sender of a message exceeding this limit will receive a fault. The receiver drops the message and creates an entry of the event in the trace log. The default is 65536. **Note:**  Increasing this value alone is not sufficient in ASP.NET compatible mode. You should also increase the value of `httpRuntime` (see [httpRuntime Element (ASP.NET Settings Schema)](/previous-versions/dotnet/netframework-4.0/e1f13641(v=vs.100))).|  
|name|A string that contains the configuration name of the binding. This value should be unique because it is used as an identification for the binding. Starting with .NET Framework 4, bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../wcf/samples/simplified-configuration-for-wcf-services.md).|  
|openTimeout|A <xref:System.TimeSpan> value that specifies the interval of time provided for an open operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|proxyAddress|A URI that specifies the address of the HTTP proxy. If `useSystemWebProxy` is `true`, this setting must be `null`. The default is `null`.|  
|receiveTimeout|A <xref:System.TimeSpan> value that specifies the interval of time provided for a receive operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|sendTimeout|A <xref:System.TimeSpan> value that specifies the interval of time provided for a send operation to complete. This value should be greater than or equal to <xref:System.TimeSpan.Zero>. The default is 00:01:00.|  
|transferMode.|A <xref:System.ServiceModel.TransferMode> value that indicates whether the service configured with the binding uses streamed or buffered (or both) modes of message transfer. The default is `Buffered`.|  
|useDefaultWebProxy|A Boolean value that specifies whether the system’s auto-configured HTTP proxy is used. The default is `true`.|  
|writeEncoding|Specifies the character encoding that is used for the message text. Valid values include the following:<br /><br /> UnicodeFffeTextEncoding: Unicode BigEndian encoding.<br /><br /> Utf16TextEncoding: 16-bit encoding.<br /><br /> Utf8TextEncoding: 8-bit encoding.<br /><br /> The default is Utf8TextEncoding.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<readerQuotas>](/previous-versions/dotnet/netframework-4.0/ms731325(v=vs.100))|Defines the constraints on the complexity of POX messages that can be processed by endpoints configured with this binding. This element is of type <xref:System.ServiceModel.Configuration.XmlDictionaryReaderQuotasElement>.|  
|[\<security>](security-of-webhttpbinding.md)|Defines the security settings for the binding. This element is of type <xref:System.ServiceModel.Configuration.WebHttpSecurityElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<bindings>](bindings.md)|This element holds a collection of standard and custom bindings.|  
  
## Remarks  

 The WCF Web Programming Model allows developers to expose WCF Web services through HTTP requests that use "plain old XML" (POX) style messaging instead of SOAP-based messaging. For clients to communicate with a service using HTTP requests, an endpoint of the service must be configured with the [\<webHttpBinding>](webhttpbinding.md) that has the \<WebHttpBehavior> attached to it.  
  
 Support in WCF for syndication and ASP.AJAX integration are both built on top of the Web Programming Model. For more information on the model, see [WCF Web HTTP Programming Model](../../../wcf/feature-details/wcf-web-http-programming-model.md).  
  
## See also

- <xref:System.ServiceModel.WebHttpBinding>
- <xref:System.ServiceModel.Configuration.WebHttpBindingElement>
- [WCF Web HTTP Programming Model](../../../wcf/feature-details/wcf-web-http-programming-model.md)
- [Bindings](../../../wcf/bindings.md)
- [Configuring System-Provided Bindings](../../../wcf/feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../../wcf/using-bindings-to-configure-services-and-clients.md)
- [\<binding>](bindings.md)
