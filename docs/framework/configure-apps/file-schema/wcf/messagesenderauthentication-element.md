---
description: "Learn more about: <messageSenderAuthentication> element"
title: "<messageSenderAuthentication> element"
ms.date: "03/30/2017"
ms.assetid: 8d979dfc-a6f9-42ec-96d5-7fbc13a48118
---
# \<messageSenderAuthentication> element

Specifies authentication options for peer-to-peer message senders.  
  
 For more information about peer-to-peer programming, see [Peer-to-Peer Networking](../../../wcf/feature-details/peer-to-peer-networking.md).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<endpointBehaviors>**](endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<clientCredentials>**](clientcredentials.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<peer>**](peer-of-clientcredentials-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<messageSenderAuthentication>**  
  
## Syntax  
  
```xml  
<messageSenderAuthentication customCertificateValidatorType= "namespace.typeName, [,AssemblyName] [,Version=version number] [,Culture=culture] [,PublicKeyToken=token]"
                             certificateValidationMode = "ChainTrust/None/PeerTrust/PeerOrChainTrust/Custom"
                             revocationMode="NoCheck/Online/Offline"
                             trustedStoreLocation="CurrentUser/LocalMachine" />
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`customCertificateValidatorType`|A type and assembly used to validate a custom type. This attribute must be set when `certificateValidationMode` is set to `Custom`.|  
|`certificateValidationMode`|Specifies one of three modes used to validate credentials. If set to `Custom`, then a `customCertificateValidator` must also be supplied.|  
|`revocationMode`|One of the modes used to check for a revoked certificate lists (CRL).|  
|`trustedStoreLocation`|One of the two system store locations: `LocalMachine` or `CurrentUser`. This value is used when a service certificate is negotiated to the client. Validation is performed against the **Trusted People** store in the specified store location.|  
  
## customCertificateValidatorType Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|String|Optional. Specifies the type name and assembly and other data used to find the type. At minimum, a namespace and type name are required. Optional information includes: assembly name, version number, culture, and public key token.|  
  
## certificateValidationMode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Enumeration|Optional. One of the following values: `None`, `PeerTrust`, `ChainTrust`, `PeerOrChainTrust`, `Custom`. The default is `ChainTrust`. The default is `ChainTrust`.<br /><br /> For more information, see [Working with Certificates](../../../wcf/feature-details/working-with-certificates.md).|  
  
## revocationMode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Enumeration|One of the following values: `NoCheck`, `Online`, `Offline`. The default is `Online`.<br /><br /> For more information, see [Working with Certificates](../../../wcf/feature-details/working-with-certificates.md).|  
  
## trustedStoreLocation Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Enumeration|One of the following values: `LocalMachine` or `CurrentUser`. The default is `CurrentUser`. If the client application is running under a system account then the certificate is typically under `LocalMachine`. If the client application is running under a user account then the certificate is typically in `CurrentUser`. The default is `CurrentUser`.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<peer>](peer-of-clientcredentials-element.md)|Specifies a credential used for authenticating the client to a peer service.|  
  
## Remarks  

 This element must be configured if message authentication is chosen. For output channels, each message is signed using the certificate provided by [\<certificate>](certificate-element.md). All messages, before delivered to the application, are checked against the message credential using the validator specified by the `customCertificateValidatorType` attribute of this element. The validator can either accept or reject the credential.  
  
## Example  

 The following code sets the message sender validation mode to `PeerOrChainTrust`.  
  
```xml  
<behaviors>
  <endpointBehaviors>
    <behavior name="MyEndpointBehavior">
      <clientCredentials>
        <peer>
          <certificate findValue="www.contoso.com"
                       storeLocation="LocalMachine"
                       x509FindType="FindByIssuerName" />
          <messageSenderAuthentication certificateValidationMode="PeerOrChainTrust" />
          <messageSenderAuthentication certificateValidationMode="None" />
        </peer>
      </clientCredentials>
    </behavior>
  </endpointBehaviors>
</behaviors>
```  
  
## See also

- <xref:System.ServiceModel.Security.X509PeerCertificateAuthentication>
- <xref:System.ServiceModel.Security.PeerCredential.MessageSenderAuthentication%2A>
- <xref:System.ServiceModel.Configuration.PeerCredentialElement.MessageSenderAuthentication%2A>
- <xref:System.ServiceModel.Configuration.X509PeerCertificateAuthenticationElement>
- [Working with Certificates](../../../wcf/feature-details/working-with-certificates.md)
- [Peer-to-Peer Networking](../../../wcf/feature-details/peer-to-peer-networking.md)
- [Peer Channel Message Authentication](/previous-versions/dotnet/netframework-3.5/aa967730(v=vs.90))
- [Peer Channel Custom Authentication](/previous-versions/dotnet/netframework-3.5/ms751447(v=vs.90))
- [Securing Peer Channel Applications](../../../wcf/feature-details/securing-peer-channel-applications.md)
