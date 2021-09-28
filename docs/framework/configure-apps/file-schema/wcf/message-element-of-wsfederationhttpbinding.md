---
description: "Learn more about: <message> element of <wsFederationHttpBinding>"
title: "<message> element of <wsFederationHttpBinding>"
ms.date: "03/30/2017"
ms.assetid: 9d710389-d9d8-4454-9bf2-da4ccda31cec
---
# \<message> element of \<wsFederationHttpBinding>

Defines the settings for the message-level security for the [\<wsFederationHttpBinding>](wsfederationhttpbinding.md).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<wsFederationHttpBinding>**](wsfederationhttpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<security>**](security-of-wsfederationhttpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<message>**  
  
## Syntax  
  
```xml  
<wsFederationBinding>
  <binding>
    <security>
      <message algorithmSuite="Basic128/Basic192/Basic256/Basic128Rsa15/Basic256Rsa15/TripleDes/TripleDesRsa15/Basic128Sha256/Basic192Sha256/TripleDesSha256/Basic128Sha256Rsa15/Basic192Sha256Rsa15/Basic256Sha256Rsa15/TripleDesSha256Rsa15"
               issuedTokenType="string"
               issuedKeyType="SymmetricKey/PublicKey"
               negotiateServiceCredential="Boolean">
        <claimTypeRequirements>
          <add claimType="URI"
               isOptional="Boolean" />
        </claimTypeRequirements>
        <issuer address="Uri">
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
                                  x509FindType="System.Security.Cryptography.X509certificates.X509findtype" />
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
|algorithmSuite|Sets the message encryption and key-wrap algorithms. See the "algorithmSuite attribute" table for valid values of this attribute. The default value is `Basic256`.<br /><br /> This attribute is of type <xref:System.ServiceModel.Security.SecurityAlgorithmSuite>. These algorithms map to those specified in the Security Policy Language (WS-SecurityPolicy) specification.|  
|issuedKeyType|Specifies the type of key to be issued. Valid values include the following:<br /><br /> -   SymmetricKey<br />-   PublicKey<br /><br /> The default is `SymmetricKey`. This attribute is of type <xref:System.IdentityModel.Tokens.SecurityKeyType>.|  
|issuedTokenType|A string that contains a URI that specifies the type of token to be issued. The default is `null`.|  
|negotiateServiceCredential|A Boolean value that specifies whether the service credential should be exchanged as part of negotiation or is available out of band. The default is `true`, which means that the service credential is negotiated.|  
  
## algorithmSuite Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Basic128|Use Basic128 encryption, Sha1 for message digest, and Rsa-oaep-mgf1p for key wrap.|  
|Basic192|Use Basic192 encryption, Sha1 for message digest, Rsa-oaep-mgf1p for key wrap.|  
|Basic256|Use Basic256 encryption, Sha1 for message digest, Rsa-oaep-mgf1p for key wrap.|  
|Basic256Rsa15|Use Basic256 for message encryption, Sha1 for message digest and Rsa15 for key wrap.|  
|Basic192Rsa15|Use Basic192 for message encryption, Sha1 for message digest and Rsa15 for key wrap.|  
|TripleDes|Use TripleDes encryption, Sha1 for message digest, Rsa-oaep-mgf1p for key wrap.|  
|Basic128Rsa15|Use Basic128 for message encryption, Sha1 for message digest and Rsa15 for key wrap.|  
|TripleDesRsa15|Use TripleDes encryption, Sha1 for message digest and Rsa15 for key wrap.|  
|Basic128Sha256|Use Basic128 for message encryption, Sha256 for message digest and Rsa-oaep-mgf1p for key wrap.|  
|Basic192Sha256|Use Basic192 for message encryption, Sha256 for message digest and Rsa-oaep-mgf1p for key wrap.|  
|Basic256Sha256|Use Basic256 for message encryption, Sha256 for message digest and Rsa-oaep-mgf1p for key wrap.|  
|TripleDesSha256|Use TripleDes for message encryption, Sha256 for message digest and Rsa-oaep-mgf1p for key wrap.|  
|Basic128Sha256Rsa15|Use Basic128 for message encryption, Sha256 for message digest and Rsa15 for key wrap.|  
|Basic192Sha256Rsa15|Use Aes192 for message encryption, Sha256 for message digest and Rsa15 for key wrap.|  
|Basic256Sha256Rsa15|Use Basic256 for message encryption, Sha256 for message digest and Rsa15 for key wrap.|  
|TripleDesSha256Rsa15|Use TripleDes for message encryption, Sha256 for message digest and Rsa15 for key wrap.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<claimTypeRequirements>](claimtyperequirements-element.md)|Specifies a collection of claim types for this binding. Each element is of type <xref:System.ServiceModel.Configuration.ClaimTypeElement>.|  
|issuer|Specifies an endpoint that issues a security token. This element is of type <xref:System.ServiceModel.Configuration.IssuedTokenParametersEndpointAddressElement>.|  
|issuerMetadata|Specifies the endpoint address of the issuer.|  
|[\<tokenRequestParameters>](tokenrequestparameters.md)|A collection of token request parameters. Each parameter is an XML element.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](security-of-wsfederationhttpbinding.md)|Defines the security settings for a binding.|  
  
## See also

- <xref:System.ServiceModel.FederatedMessageSecurityOverHttp>
- <xref:System.ServiceModel.Configuration.WSFederationHttpSecurityElement.Message%2A>
- <xref:System.ServiceModel.WSFederationHttpSecurity.Message%2A>
- <xref:System.ServiceModel.Configuration.FederatedMessageSecurityOverHttpElement>
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
- [Bindings](../../../wcf/bindings.md)
- [Configuring System-Provided Bindings](../../../wcf/feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../../wcf/using-bindings-to-configure-services-and-clients.md)
- [\<binding>](bindings.md)
