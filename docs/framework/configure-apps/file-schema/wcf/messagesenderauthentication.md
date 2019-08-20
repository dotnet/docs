---
title: "<messageSenderAuthentication>"
ms.date: "03/30/2017"
ms.assetid: ea62fc06-55fb-42e0-aa2b-8867bdf4b415
---
# \<messageSenderAuthentication>
Specifies authentication settings for peer certificate used by a message sender.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<serviceCredentials>  
\<peer>  
\<messageSenderAuthentication>  
  
## Syntax  
  
```xml  
<messageSenderAuthentication customCertificateValidatorType="namespace.typeName, [,AssemblyName] [,Version=version number] [,Culture=culture] [,PublicKeyToken=token]"
                             certificateValidationMode="ChainTrust/None/PeerTrust/PeerOrChainTrust/Custom"
                             revocationMode="NoCheck/Online/Offline"
                             trustedStoreLocation="CurrentUser/LocalMachine" />
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`certificateValidationMode`|Optional enumeration. Specifies one of five modes used to validate credentials. This attribute is of type <xref:System.ServiceModel.Security.X509CertificateValidationMode>. If set to `Custom`, then a `customCertificateValidator` must also be supplied.|  
|`customCertificateValidatorType`|Optional string. Specifies a type and assembly used to validate a custom type. This attribute must be set when `certificateValidationMode` is set to `Custom`. This attribute is of type <xref:System.IdentityModel.Selectors.X509CertificateValidator>. Windows Communication Foundation (WCF) provides a default peer certificate validator that verifies the peer certificate against the trusted people store. It also verifies that the certificate chains up to a valid root. You can implement a custom validator to specify a different behavior and use this attribute to point to the custom validator.|  
|`revocationMode`|Optional enumeration. Specifies the certificate revocation mode. This attribute is of type <xref:System.Security.Cryptography.X509Certificates.X509RevocationMode>. The system verifies that the peer certificate has not been revoked by looking it up in the revoked certificate list. This check can be performed either by checking online or against a cached revocation list. Revocation checking can be turned off by setting this attribute to NoCheck.|  
|`trustedStoreLocation`|Optional enumeration. Specifies the trusted store location where the peer certificate is validated by the WCF security system. This attribute is of type <xref:System.Security.Cryptography.X509Certificates.StoreLocation>.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<peer>](peer-of-servicecredentials.md)|Specifies the current credentials for a peer node.|  
  
## Remarks  
 This element must be configured if message authentication is chosen. For output channels, each message is signed using the certificate provided by [\<certificate>](certificate-element.md). All messages, before delivered to the application, are checked against the message credential using the validator specified by the `customCertificateValidatorType` attribute of this element. The validator can either accept or reject the credential.  
  
## See also

- <xref:System.ServiceModel.Configuration.X509PeerCertificateAuthenticationElement>
- <xref:System.ServiceModel.Security.X509PeerCertificateAuthentication>
- <xref:System.ServiceModel.Security.PeerCredential.MessageSenderAuthentication%2A>
- <xref:System.ServiceModel.Configuration.PeerCredentialElement.MessageSenderAuthentication%2A>
- [Working with Certificates](../../feature-details/working-with-certificates.md)
- [Peer-to-Peer Networking](../../feature-details/peer-to-peer-networking.md)
- [Peer Channel Message Authentication](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/aa967730(v=vs.90))
- [Peer Channel Custom Authentication](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms751447(v=vs.90))
- [Securing Peer Channel Applications](../../feature-details/securing-peer-channel-applications.md)
