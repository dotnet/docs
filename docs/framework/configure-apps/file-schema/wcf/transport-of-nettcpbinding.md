---
description: "Learn more about: <transport> of <netTcpBinding>"
title: "<transport> of <netTcpBinding>"
ms.date: "03/30/2017"
ms.assetid: 49462e0a-66e1-463f-b3e1-c83a441673c6
---
# \<transport> of \<netTcpBinding>

Defines the type of message-level security requirements for an endpoint configured with the [\<netTcpBinding>](nettcpbinding.md).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<netTcpBinding>**](nettcpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<security>**](security-of-nettcpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<transport>**  
  
## Syntax  
  
```xml  
<netTcpBinding>
  <binding>
    <security mode="None|Transport|Message|TransportWithMessageCredential">
      <transport clientCredentialType="None|Windows|Certificate"
                 protectionLevel="None|Sign|EncryptAndSign"
                 sslProtocols="Tls|Tls11|Tls12">
        <extendedProtectionPolicy policyEnforcement="Never|WhenSupported|Always"
                                  protectionScenario="TransportSelected|TrustedProxy">
          <customServiceNames>
          </customServiceNames>
        </extendedProtectionPolicy>
      </transport>
    </security>
  </binding>
</netTcpBinding>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|clientCredentialType|Optional. Specifies the type of credential to be used when performing client authentication using Transport security.<br /><br /> -   The default value is `Windows`.<br />-   This attribute is of type <xref:System.ServiceModel.TcpClientCredentialType>.|  
|protectionLevel|Optional. Defines security at the level of the TCP transport. Signing messages mitigates the risk of a third party tampering with the message while it is being transferred. Encryption provides data-level privacy during transport.<br /><br /> The default value is `EncryptAndSign`.|  
|sslProtocols|A SslProtocols enum flag value that specifies which SslProtocols are supported. The default is Tls&#124;Tls11&#124;Tls12.|  
|policyEnforcement|This enumeration specifies when the <xref:System.Security.Authentication.ExtendedProtection.ExtendedProtectionPolicy> should be enforced.<br /><br /> 1.  Never – The policy is never enforced (Extended Protection is disabled).<br />2.  WhenSupported – The policy is enforced only if the client supports Extended Protection.<br />3.  Always – The policy is always enforced. Clients which don’t support Extended Protection will fail to authenticate.|  
  
## clientCredentialType Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|None|The client is anonymous. This requires a certificate for the service.|  
|Windows|Specifies Windows authentication of the client using SP Negotiation (Kerberos negotiation).|  
|Certificate|The client is authenticated using a certificate. This uses SSL Negotiation and requires a certificate for the service.|  
  
## protectionLevel Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|None|No protection.|  
|Sign|Messages are signed.|  
|EncryptAndSign|-   Messages are encrypted and signed.|  
  
### Child Elements  

 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](security-of-nettcpbinding.md)|Specifies the security capabilities of the [\<netTcpBinding>](nettcpbinding.md).|  
  
## Remarks  

 Use Transport security for integrity and confidentiality of the SOAP message and for mutual authentication. If this security mode is selected on a binding, the channel stack is configured using a secure transport and the SOAP messages are secured using transport security such as Windows (Negotiate) or SSL over TCP.  
  
## See also

- <xref:System.ServiceModel.TcpTransportSecurity>
- <xref:System.ServiceModel.Configuration.NetTcpSecurityElement.Transport%2A>
- <xref:System.ServiceModel.NetTcpSecurity.Transport%2A>
- <xref:System.ServiceModel.Configuration.NetTcpSecurityElement>
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
- [Bindings](../../../wcf/bindings.md)
- [Configuring System-Provided Bindings](../../../wcf/feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../../wcf/using-bindings-to-configure-services-and-clients.md)
- [\<binding>](bindings.md)
