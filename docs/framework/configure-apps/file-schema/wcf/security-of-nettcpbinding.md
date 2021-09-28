---
description: "Learn more about: <security> of <netTcpBinding>"
title: "<security> of <netTcpBinding>"
ms.date: "03/30/2017"
ms.assetid: 286cd191-4fd5-4c4e-a223-9c71cf7fdead
---
# \<security> of \<netTcpBinding>

Defines the security settings for a binding.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<netTcpBinding>**](nettcpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<security>**  
  
## Syntax  
  
```xml  
<security mode="Message/None/Transport/TransportWithCredential">
  <transport clientCredentialType="Basic/Certificate/Digest/None/Ntlm/Windows"
             protectionLevel="None/Sign/EncryptAndSign" />
  <message algorithmSuite="Basic128/Basic192/Basic256/Basic128Rsa15/Basic256Rsa15/TripleDes/TripleDesRsa15/Basic128Sha256/Basic192Sha256/TripleDesSha256/Basic128Sha256Rsa15/Basic192Sha256Rsa15/Basic256Sha256Rsa15/TripleDesSha256Rsa15"
           clientCredentialType="Certificate/IssuedToken/None/UserName/Windows" />
</security>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|mode|Optional. Specifies the type of security that is applied. Valid values are shown below. The default value is `Transport`.<br /><br /> This attribute is of type <xref:System.ServiceModel.SecurityMode>.|  
  
## mode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|None|Security is disabled.|  
|Transport|Transport security is provided using TLS over TCP or SPNego. The service may need to be configured with SSL certificates. It is possible to control the protection level with this mode.|  
|Message|Security is provided using SOAP message security. By default, the SOAP body is encrypted and signed. This mode offers a variety of features, such as whether the service credentials are available at the client out of band, the algorithm suite to use, and what level of protection to apply to the message body. Client authentication is performed once per session and the results of authentication are cached for the duration of the session.|  
|TransportWithMessageCredential|Transport security is coupled with message security. Transport security is provided by TLS over TCP, or SPNego, and ensures integrity, confidentiality, and server authentication. SOAP message security provides client authentication. By default, client authentication is performed once per session and the results of authentication are cached for the duration of the session.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<transport>](transport-of-nettcpbinding.md)|Defines the security settings for the transport. This element is of type <xref:System.ServiceModel.Configuration.TcpTransportSecurityElement>.|  
|[\<message>](message-element-of-nettcpbinding.md)|Defines the security settings for the message. This element is of type <xref:System.ServiceModel.Configuration.MessageSecurityOverTcpElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|binding|The binding element of the [\<netTcpBinding>](nettcpbinding.md).|  
  
## Remarks  

 Each of the standard bindings provides parameters for controlling the transfer security requirements. These parameters typically include the security mode that specified whether message-level or transport-level security is used and the choice of client credential type. Based on the choice of options these parameters present, a channel stack is constructed with appropriate security.  
  
 The system-provided bindings supplied by Windows Communication Foundation (WCF) are a set designed to meet some of the most common scenario requirements. Each of these bindings allows the specification of security requirements for some specific targeted scenarios.  
  
 This configuration element provides the security specifications for `netTcpBinding`. This is a secure, reliable, optimized binding suitable for cross-machine communication. By default it generates a runtime communication stack supporting TCP for message delivery and Windows Security for message security and authentication, WS-ReliableMessaging for reliability, and binary message encoding.  
  
## See also

- <xref:System.ServiceModel.NetTcpSecurity>
- <xref:System.ServiceModel.NetTcpBinding.Security%2A>
- <xref:System.ServiceModel.Configuration.NetTcpBindingElement.Security%2A>
- <xref:System.ServiceModel.Configuration.NetTcpSecurityElement>
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
- [Bindings](../../../wcf/bindings.md)
- [Configuring System-Provided Bindings](../../../wcf/feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../../wcf/using-bindings-to-configure-services-and-clients.md)
- [\<binding>](bindings.md)
