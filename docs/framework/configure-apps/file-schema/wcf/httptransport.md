---
description: "Learn more about: <httpTransport>"
title: "<httpTransport>"
ms.date: "03/30/2017"
ms.assetid: 8b30c065-b32a-4fa3-8eb4-5537a9c6b897
---
# \<httpTransport>

Specifies an HTTP transport for transmitting SOAP messages for a custom binding.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<customBinding>**](custombinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<httpTransport>**  
  
## Syntax  
  
```xml  
<httpTransport allowCookies="Boolean"
               authenticationScheme="Digest/Negotiate/Ntlm/Basic/Anonymous"
               bypassProxyOnLocal="Boolean"
               hostnameComparisonMode="StrongWildcard/Exact/WeakWildcard"
               keepAliveEnabled="Boolean"
               maxBufferSize="Integer"
               proxyAddress="Uri"
               proxyAuthenticationScheme="None/Digest/Negotiate/Ntlm/Basic/Anonymous"
               realm="String"
               transferMode="Buffered/Streamed/StreamedRequest/StreamedResponse"
               unsafeConnectionNtlmAuthentication="Boolean"
               useDefaultWebProxy="Boolean" />
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|allowCookies|A Boolean value that specifies whether the client accepts cookies and propagates them on future requests. The default is `false`.<br /><br /> You can use this attribute when you interact with ASMX Web services that use cookies. In this way, you can be sure that the cookies returned from the server are automatically copied to all future client requests for that service.|  
|authenticationScheme|Specifies the protocol used to authenticate client requests being processed by an HTTP listener. Valid values include the following:<br /><br /> -   Digest: Specifies digest authentication.<br />-   Negotiate: Negotiates with the client to determine the authentication scheme. If both client and server support Kerberos, it is used; otherwise, NTLM is used.<br />-   Ntlm: Specifies NTLM authentication.<br />-   Basic: Specifies basic authentication.<br />-   Anonymous: Specifies anonymous authentication.<br /><br /> The default is Anonymous. This attribute is of type <xref:System.Net.AuthenticationSchemes>. This attribute can only be set once.|  
|bypassProxyOnLocal|A Boolean value that indicates whether to bypass the proxy server for local addresses. The default is `false`.<br /><br /> A local address is one that is on the local LAN or intranet.<br /><br /> Windows Communication Foundation (WCF) always ignores the proxy if the service address begins with `http://localhost`.<br /><br /> You should use the host name rather than localhost if you want clients to go through a proxy when talking to services on the same machine.|  
|hostnameComparisonMode|Specifies the HTTP hostname comparison mode used to parse URIs. Valid values are,<br /><br /> -   StrongWildcard: ("+") matches all possible hostnames in the context of the specified scheme, port and relative URI.<br />-   Exact: no wildcards<br />-   WeakWildcard: ("\*") matches all possible hostname in the context of the specified scheme, port and relative UIR that have not been matched explicitly or through the strong wildcard mechanism.<br /><br /> This attribute is of type <xref:System.ServiceModel.HostNameComparisonMode>. The default is <xref:System.ServiceModel.HostNameComparisonMode.StrongWildcard>.|  
|keepAliveEnabled|A Boolean value that specifies whether to make a persistent connection to the internet resource.|  
|maxBufferSize|A positive integer that specifies the maximum size of the buffer. The default is 524288|  
|proxyAddress|A URI that specifies the address of the HTTP proxy. If `useSystemWebProxy` is `true`, this setting must be `null`. The default is `null`.|  
|proxyAuthenticationScheme|Specifies the protocol used for authenticating client requests being processed by an HTTP proxy. Valid values include the following:<br /><br /> -   None: No authentication is performed.<br />-   Digest: Specifies digest authentication.<br />-   Negotiate: Negotiates with the client to determine the authentication scheme. If both client and server support Kerberos, it is used; otherwise, NTLM is used.<br />-   Ntlm: Specifies NTLM authentication.<br />-   Basic: Specifies basic authentication.<br />-   Anonymous: Specifies anonymous authentication.<br /><br /> The default is Anonymous. This attribute is of type <xref:System.Net.AuthenticationSchemes>. Note that <xref:System.Net.AuthenticationSchemes.IntegratedWindowsAuthentication?displayProperty=nameWithType> is not supported.|  
|realm|A string that specifies the realm to use on the proxy/server. The default is an empty string.<br /><br /> Servers use realms to partition protected resources. Each partition can have its own authentication scheme and/or authorization database. Realms are used only for basic and digest authentication. After a client successfully authenticates, the authentication is valid for all resources in a given realm. For a detailed description of realms, see RFC 2617 at the [IETF website](https://www.ietf.org).|  
|transferMode|Specifies whether messages are buffered or streamed or a request or response. Valid values include the following:<br /><br /> -   Buffered: The request and response messages are buffered.<br />-   Streamed: The request and response messages are streamed.<br />-   StreamedRequest: The request message is streamed and the response message is buffered.<br />-   StreamedResponse: The request message is buffered and the response message is streamed.<br /><br /> The default is Buffered. This attribute is of type <xref:System.ServiceModel.TransferMode> .|  
|unsafeConnectionNtlmAuthentication|A Boolean value that specifies whether Unsafe Connection Sharing is enabled on the server. The default is `false`. If enabled, NTLM authentication is performed once on each TCP connection.|  
|useDefaultWebProxy|A Boolean value that specifies whether the machine-wide proxy settings are used rather than the user specific settings. The default is `true`.|  
  
### Child Elements  

 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](bindings.md)|Defines all binding capabilities of the custom binding.|  
  
## Remarks  

 The `httpTransport` element is the starting point for creating a custom binding that implements the HTTP transport protocol. HTTP is the primary transport used for interoperability purposes. This transport is supported by the Windows Communication Foundation (WCF) to ensure interoperability with other non-WCF Web services stacks.  
  
## See also

- <xref:System.ServiceModel.Configuration.HttpTransportElement>
- <xref:System.ServiceModel.Channels.HttpTransportBindingElement>
- <xref:System.ServiceModel.Channels.TransportBindingElement>
- <xref:System.ServiceModel.Channels.CustomBinding>
- [Transports](../../../wcf/feature-details/transports.md)
- [Choosing a Transport](../../../wcf/feature-details/choosing-a-transport.md)
- [Bindings](../../../wcf/bindings.md)
- [Extending Bindings](../../../wcf/extending/extending-bindings.md)
- [Custom Bindings](../../../wcf/extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
