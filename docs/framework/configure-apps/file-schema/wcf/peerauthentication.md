---
title: "&lt;peerAuthentication&gt;"
ms.date: "03/30/2017"
ms.assetid: ad545e6f-f06e-4549-ac92-09d758d5c636
---
# &lt;peerAuthentication&gt;
Specifies authentication settings for a peer certificate used by a peer node.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<serviceCredentials>  
\<peer>  
\<peerAuthentication>  
  
## Syntax  
  
```xml  
<peerAuthentication customCertificateValidatorType="namespace.typeName, [,AssemblyName] [,Version=version number] [,Culture=culture] [,PublicKeyToken=token]"
                    certificateValidationMode="ChainTrust/None/PeerTrust/PeerOrChainTrust/Custom"
                    revocationMode="NoCheck/Online/Offline"
                    trustedStoreLocation="CurrentUser/LocalMachine" />
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`certificateValidationMode`|Optional enumeration. Specifies one of three modes used to validate credentials. This attribute is of type <xref:System.ServiceModel.Security.X509CertificateValidationMode>. If set to `Custom`, then a `customCertificateValidator` must also be supplied.|  
|`customCertificateValidatorType`|Optional string. Specifies a type and assembly used to validate a custom type. This attribute must be set when `certificateValidationMode` is set to `Custom`. This attribute is of type <xref:System.IdentityModel.Selectors.X509CertificateValidator>. Windows Communication Foundation (WCF) provides a default peer certificate validator that verifies the peer certificate against the trusted people store. It also verifies that the certificate chains up to a valid root. You can implement a custom validator to specify a different behavior and use this attribute to point to the custom validator.|  
|`revocationMode`|Optional enumeration. Specifies the certificate revocation mode. This attribute is of type <xref:System.Security.Cryptography.X509Certificates.X509RevocationMode>. The system verifies that the peer certificate has not been revoked by looking it up in the revoked certificate list. This check can be performed either by checking online or against a cached revocation list. Revocation checking can be turned off by setting this attribute to NoCheck.|  
|`trustedStoreLocation`|Optional enumeration. Specifies the trusted store location where the peer certificate is validated by the WCF security system. This attribute is of type <xref:System.Security.Cryptography.X509Certificates.StoreLocation>.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<peer>](../../../../../docs/framework/configure-apps/file-schema/wcf/peer-of-servicecredentials.md)|Specifies the current credentials for a peer node.|  
  
## Remarks  
 The `<authentication>` element corresponds to the <xref:System.ServiceModel.Security.X509PeerCertificateAuthentication> class. This element specifies a validator, which is invoked during neighbor-to-neighbor authentication in the mesh. When a new peer tries to establish a neighbor connection, it passes its own credential to the responding peer. The validator of the responder is invoked to verify the credential of the remote party. Whenever a peer connection is established in the mesh, both peers are mutually authenticated, meaning validators on both ends are invoked.  
  
## See also
- <xref:System.ServiceModel.Configuration.PeerCredentialElement>
- <xref:System.ServiceModel.Security.X509PeerCertificateAuthentication>
- <xref:System.ServiceModel.Security.PeerCredential.PeerAuthentication%2A>
- <xref:System.ServiceModel.Configuration.PeerCredentialElement.PeerAuthentication%2A>
- <xref:System.ServiceModel.Configuration.X509PeerCertificateAuthenticationElement>
- [Working with Certificates](../../../../../docs/framework/wcf/feature-details/working-with-certificates.md)
- [Peer-to-Peer Networking](../../../../../docs/framework/wcf/feature-details/peer-to-peer-networking.md)
- [Peer Channel Message Authentication](https://msdn.microsoft.com/library/80e73386-514e-4c30-9e4a-b9ca8c173a95)
- [Peer Channel Custom Authentication](https://msdn.microsoft.com/library/4aa8a82e-41a8-48e2-8621-7e1cbabdca7c)
- [Securing Peer Channel Applications](../../../../../docs/framework/wcf/feature-details/securing-peer-channel-applications.md)
