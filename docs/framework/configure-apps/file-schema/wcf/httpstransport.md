---
description: "Learn more about: <httpsTransport>"
title: "<httpsTransport>"
ms.date: "03/30/2017"
ms.assetid: f6ed4bc0-7e38-4348-9259-30bf61eb9435
---
# \<httpsTransport>

Specifies an HTTP transport for transmitting SOAP messages for a custom binding.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<customBinding>**](custombinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<httpsTransport>**  
  
## Syntax  
  
```xml  
<httpsTransport allowCookies="Boolean"
                authenticationScheme="Digest/Negotiate/Ntlm/Basic/Anonymous"
                bypassProxyOnLocal="Boolean"
                hostnameComparisonMode="StrongWildcard/Exact/WeakWildcard"
                manualAddressing="Boolean"
                maxBufferPoolSize="Integer"
                maxBufferSize="Integer"
                maxReceivedMessageSize="Integer"
                proxyAddress="Uri"
                proxyAuthenticationScheme="None/Digest/Negotiate/Ntlm/Basic/Anonymous"
                realm="String"
                requireClientCertificate="Boolean"
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
|hostnameComparisonMode|Specifies the HTTP hostname comparison mode used to parse URIs. Valid values are,<br /><br /> -   StrongWildcard: ("+") matches all possible hostnames in the context of the specified scheme, port and relative URI.<br />-   Exact: no wildcards<br />-   WeakWildcard: ("\*") matches all possible hostname in the context of the specified scheme, port and relative UIR that have not been matched explicitly or through the strong wildcard mechanism.<br /><br /> The default is StrongWildcard. This attribute is of type `System.ServiceModel.HostnameComparison`.|  
|manualAddressing|A Boolean value that enables the user to take control of message addressing. This property is usually used in router scenarios, where the application determines which one of several destinations to send a message to.<br /><br /> When set to `true`, the channel assumes the message has already been addressed and does not add any additional information to it. The user can then address every message individually.<br /><br /> When set to `false`, the default Windows Communication Foundation (WCF) addressing mechanism automatically creates addresses for all messages.<br /><br /> The default is `false`.|  
|maxBufferPoolSize|A positive integer that specifies the maximum size of the buffer pool. The default is 524288.<br /><br /> Many parts of WCF use buffers. Creating and destroying buffers each time they are used is expensive, and garbage collection for buffers is also expensive. With buffer pools, you can take a buffer from the pool, use it, and return it to the pool once you are done. Thus the overhead in creating and destroying buffers is avoided.|  
|maxBufferSize|A positive integer that specifies the maximum size of the buffer. The default is 524288|  
|maxReceivedMessageSize|A positive integer that specifies the maximum allowable message size that can be received. The default is 65536.|  
|proxyAddress|A URI that specifies the address of the HTTP proxy. If `useSystemWebProxy` is `true`, this setting must be `null`. The default is `null`.|  
|proxyAuthenticationScheme|Specifies the protocol used for authenticating client requests being processed by an HTTP proxy. Valid values include the following:<br /><br /> -   None: No authentication is performed.<br />-   Digest: Specifies digest authentication.<br />-   Negotiate: Negotiates with the client to determine the authentication scheme. If both client and server support Kerberos, it is used; otherwise, NTLM is used.<br />-   Ntlm: Specifies NTLM authentication.<br />-   Basic: Specifies basic authentication.<br />-   Anonymous: Specifies anonymous authentication.<br /><br /> The default is Anonymous. This attribute is of type <xref:System.Net.AuthenticationSchemes>. Note that <xref:System.Net.AuthenticationSchemes.IntegratedWindowsAuthentication?displayProperty=nameWithType> is not supported.|  
|realm|A string that specifies the realm to use on the proxy/server. The default is an empty string.<br /><br /> Servers use realms to partition protected resources. Each partition can have its own authentication scheme and/or authorization database. Realms are used only for basic and digest authentication. After a client successfully authenticates, the authentication is valid for all resources in a given realm. For a detailed description of realms, see RFC 2617 at the [IETF website](https://www.ietf.org).|  
|requireClientCertificate|A Boolean value that specifies if the server requires the client to provide a client certificate as part of the HTTPS handshake. The default is `false`.|  
|transferMode|Specifies whether messages are buffered or streamed or a request or response. Valid values include the following:<br /><br /> -   Buffered: The request and response messages are buffered.<br />-   Streamed: The request and response messages are streamed.<br />-   StreamedRequest: The request message is streamed and the response message is buffered.<br />-   StreamedResponse: The request message is buffered and the response message is streamed.<br /><br /> The default is Buffered. This attribute is of type <xref:System.ServiceModel.TransferMode>.|  
|unsafeConnectionNtlmAuthentication|A Boolean value that specifies whether Unsafe Connection Sharing is enabled on the server. The default is `false`. If enabled, NTLM authentication is performed once on each TCP connection.|  
|useDefaultWebProxy|A Boolean value that specifies whether the machine-wide proxy settings are used rather than the user specific settings. The default is `true`.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](bindings.md)|Defines all binding capabilities of the custom binding.|  
  
## Remarks  

 The `httpsTransport` element is the starting point for creating a custom binding that implements the HTTPS transport protocol. HTTPS is the primary transport used for secure interoperability purposes. HTTPS is supported by the Windows Communication Foundation (WCF) to ensure interoperability with other Web services stacks.  
  
## See also

- <xref:System.ServiceModel.Configuration.HttpsTransportElement>
- <xref:System.ServiceModel.Channels.HttpsTransportBindingElement>
- <xref:System.ServiceModel.Channels.TransportBindingElement>
- <xref:System.ServiceModel.Channels.CustomBinding>
- [Transports](../../../wcf/feature-details/transports.md)
- [Choosing a Transport](../../../wcf/feature-details/choosing-a-transport.md)
- [Bindings](../../../wcf/bindings.md)
- [Extending Bindings](../../../wcf/extending/extending-bindings.md)
- [Custom Bindings](../../../wcf/extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
