---
description: "Learn more about: <security> of <wsHttpBinding>"
title: "<security> of <wsHttpBinding>"
ms.date: "03/30/2017"
ms.assetid: 8658b162-2ddf-4162-a869-aa517a42288a
---
# \<security> of \<wsHttpBinding>

Represents the security capabilities of the [\<wsHttpBinding>](wshttpbinding.md).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<wsHttpBinding>**](wshttpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<security>**  
  
## Syntax  
  
```xml  
<security mode="Message/None/Transport/TransportWithMessageCredential">
  <transport clientCredentialType="Basic/Certificate/Digest/None/Ntlm/Windows"
             proxyCredentialType="Basic/Digest/None/Ntlm/Windows"
             realm="String"
             defaultClientCredentialType="Basic/Certificate/Digest/None/Ntlm/Windows"
             defaultProxyCredentialType="Basic/Digest/None/Ntlm/Windows"
             defaultRealm="String" />
  <message clientCredentialType="Certificate/IssuedToken/None/UserName/Windows"
           algorithmSuite="Basic128/Basic192/Basic256/Basic128Rsa15/Basic256Rsa15/TripleDes/TripleDesRsa15/Basic128Sha256/Basic192Sha256/TripleDesSha256/Basic128Sha256Rsa15/Basic192Sha256Rsa15/Basic256Sha256Rsa15/TripleDesSha256Rsa15"
           establishSecurityContext="Boolean"
           negotiateServiceCredential="Boolean" />
</security>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|mode|-   Optional. Specifies the type of security that is applied. The default is `Message`.<br />-   This attribute is of type <xref:System.ServiceModel.SecurityMode>.|  
  
## Mode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|None|Security is disabled.|  
|Transport|Security is provided using HTTPS. The service needs to be configured with SSL certificates. The message is entirely secured using HTTPS and is authenticated by the client using the service’s SSL certificate. The client authentication is controlled through the `ClientCredentials` attribute. of the [\<transport>](transport-of-wshttpbinding.md).|  
|Message|Security is provided using SOAP message security. By default, the SOAP body is Encrypted and Signed. This mode offers a variety of features, such as whether the service credentials are available at the client out of band, the algorithm suite to use, and what level of protection to apply to the message body through the Security.Message property. Client authentication is performed once per session and the results of authentication are cached for the duration of the session.|  
|TransportWithMessageCredential|In this mode, HTTPS provides integrity, confidentiality, and server authentication, and SOAP message security provides client authentication. By default, client authentication is performed once per session and the results of authentication are cached for the duration of the session.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<transport>](transport-of-wshttpbinding.md)|Defines the transport security settings. This element corresponds to the <xref:System.ServiceModel.Configuration.HttpTransportSecurityElement> type.|  
|[\<message>](message-of-wshttpbinding.md)|Defines the security settings for the message. This element corresponds to the <xref:System.ServiceModel.Configuration.MessageSecurityOverHttpElement> type.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<wsHttpBinding>](wshttpbinding.md)|A secure binding for HTTP transport applications.|  
  
## Remarks  

 The WSHttpBinding class is designed for interoperation with services that implement WS-* specifications. The transport security for this binding is Secure Sockets Layer (SSL) over HTTP, or HTTPS.  
  
## See also

- <xref:System.ServiceModel.WSHttpSecurity>
- <xref:System.ServiceModel.WSHttpBinding.Security%2A>
- <xref:System.ServiceModel.Configuration.WSHttpBindingElement.Security%2A>
- <xref:System.ServiceModel.Configuration.WSHttpSecurityElement>
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
- [Bindings](../../../wcf/bindings.md)
- [Configuring System-Provided Bindings](../../../wcf/feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../../wcf/using-bindings-to-configure-services-and-clients.md)
- [\<binding>](bindings.md)
