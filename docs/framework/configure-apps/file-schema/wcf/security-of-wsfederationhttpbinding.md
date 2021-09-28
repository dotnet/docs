---
description: "Learn more about: <security> of <wsFederationHttpBinding>"
title: "<security> of <wsFederationHttpBinding>"
ms.date: "03/30/2017"
ms.assetid: a8e5e854-b8dc-4921-843d-34b6a4a6a8ba
---
# \<security> of \<wsFederationHttpBinding>

Defines the security settings of the [\<wsFederationHttpBinding>](wsfederationhttpbinding.md).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<wsFederationHttpBinding>**](wsfederationhttpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<security>**  
  
## Syntax  
  
```xml  
<wsFederationBinding>
  <binding>
    <security mode="None/Message/TransportWithMessageCredential">
      <message algorithmSuite="Basic128/Basic192/Basic256/Basic128Rsa15/Basic256Rsa15/TripleDes/TripleDesRsa15/Basic128Sha256/Basic192Sha256/TripleDesSha256/Basic128Sha256Rsa15/Basic192Sha256Rsa15/Basic256Sha256Rsa15/TripleDesSha256Rsa15"
               issuedTokenType="string"
               issuedKeyType="SymmetricKey/PublicKey"
               negotiateServiceCredential="Boolean">
        <claimTypeRequirements>
          <add claimType="URI"
               isOptional="Boolean" />
        </claimTypeRequirements>
        <issuer address="Uri" >
          <headers>
            <add name="String"
                 namespace="String" />
          </headers>
          <identity>
            <certificate encodedValue="String" />
            <certificateReference findValue="String"
                                  isChainIncluded="Boolean"
                                  storeName="AddressBook/AuthRoot/CertificateAuthority/Disallowed/My/Root/TrustedPeople/TrustedPublisher"
                                  storeLocation="LocalMachine/CurrentUser"
                                  X509FindType="System.Security.Cryptography.X509certificates.X509findtype" />
            <dns value="String" />
            <rsa value="String" />
            <servicePrincipalName value="String" />
            <usePrincipalName value="String" />
          </identity>
        </issuer>
        <issuerMetadata address="String">
          <headers>
            <add name="String"
                 namespace="String" />
          </headers>
          <identity>
            <certificate encodedValue="String" />
            <certificateReference findValue="String"
                                  isChainIncluded="Boolean"
                                  storeName="AddressBook/AuthRoot/CertificateAuthority/Disallowed/My/Root/TrustedPeople/TrustedPublisher"
                                  storeLocation="LocalMachine/CurrentUser"
                                  X509FindType="System.Security.Cryptography.X509certificates.X509findtype" />
            <dns value="String" />
            <rsa value="String" />
            <servicePrincipalName value="String" />
            <usePrincipalName value="String" />
          </identity>
        </issuerMetadata>
        <tokenRequestParameters>
          <xmlElement>
          </xmlElement>
        </tokenRequestParameters>
      </message>
    </security>
  </binding>
</wsFederationBinding>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|Mode|Optional. Specifies the type of security that is applied. The default value is `Message`. This attribute is of type <xref:System.ServiceModel.WSFederationHttpSecurityMode>.|  
  
## Mode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|None|The SOAP message is not secure during transfer.|  
|Message|Integrity, confidentiality, server authentication and client authentication are provided using SOAP message security. By default, the body is encrypted and signed. The service needs to be configured with a certificate. Client authentication is based on the token issued to the client by a security token service|  
|TransportWithMessageCredential|Integrity, confidentiality and server authentication are provided by HTTPS. The service needs to be configured with a certificate. Client authentication is provided by means of SOAP message security and is based on the token issued to the client by a security token service.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<message>](message-element-of-wsfederationhttpbinding.md)|Defines the settings for the message-level security. This element is of type <xref:System.ServiceModel.Configuration.FederatedMessageSecurityOverHttpElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](bindings.md)|Defines all binding capabilities of the [\<wsDualHttpBinding>](wsdualhttpbinding.md).|  
  
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
- [\<binding>](bindings.md)
