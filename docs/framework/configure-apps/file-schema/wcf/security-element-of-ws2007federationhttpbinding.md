---
title: "<security> element of <ws2007FederationHttpBinding>"
ms.date: "03/30/2017"
ms.assetid: 826219b4-3a16-45fc-832d-0cd7cbbd3b84
---
# \<security> element of \<ws2007FederationHttpBinding>
Defines the security settings of the [\<ws2007FederationHttpBinding>](ws2007federationhttpbinding.md) element.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<ws2007FederationHttpBinding>**](ws2007federationhttpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<security>**  
  
## Syntax  
  
```xml  
<ws2007FederationBinding>
  <binding>
    <security mode="None/Message/TransportWithMessageCredential">
      <message negotiateServiceCredential="Boolean"
               algorithmSuite="Basic128/Basic192/Basic256/Basic128Rsa15/  Basic256Rsa15/TripleDes/TripleDesRsa15/Basic128Sha256/Basic192Sha256/TripleDesSha256/Basic128Sha256Rsa15/Basic192Sha256Rsa15/Basic256Sha256Rsa15/TripleDesSha256Rsa15"
               defaultProtectionLevel="none/sign/EncryptAndSign"
               issuedTokenType="string"
               issuedKeyType="SymmetricKey/PublicKey">
      </message>
    </security>
  </binding>
</ws2007FederationBinding>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`mode`|Optional. Specifies the type of security that is applied. The default value is `Message`. This attribute is of type <xref:System.ServiceModel.WSFederationHttpSecurityMode>.|  
  
## mode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|None|The SOAP message is not secure during transfer.|  
|Message|Integrity, confidentiality, server authentication and client authentication are provided using SOAP message security. By default, the body is encrypted and signed. The service must be configured with a certificate. Client authentication is based on the token issued to the client by a security token service.|  
|TransportWithMessageCredential|Integrity, confidentiality and server authentication are provided by HTTPS. The service must be configured with a certificate. Client authentication is provided by means of SOAP message security and is based on the token issued to the client by a security token service.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<message>](message-of-ws2007httpbinding.md)|Defines the settings for the message-level security. This element is of type <xref:System.ServiceModel.Configuration.FederatedMessageSecurityOverHttpElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](../../../misc/binding.md)|Defines all binding capabilities of the [\<wsDualHttpBinding>](wsdualhttpbinding.md).|  
  
## See also

- <xref:System.ServiceModel.WSFederationHttpSecurity>
- <xref:System.ServiceModel.WSFederationHttpBinding.Security%2A>
- <xref:System.ServiceModel.Configuration.WSFederationHttpBindingElement.Security%2A>
- <xref:System.ServiceModel.Configuration.WSFederationHttpSecurityElement>
- [How to: Create a WSFederationHttpBinding](../../../wcf/feature-details/how-to-create-a-wsfederationhttpbinding.md)
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
- [Selecting a Credential Type](../../../wcf/feature-details/selecting-a-credential-type.md)
- [Bindings](../../../wcf/bindings.md)
- [Configuring System-Provided Bindings](../../../wcf/feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../../wcf/using-bindings-to-configure-services-and-clients.md)
- [\<binding>](../../../misc/binding.md)
