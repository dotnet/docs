---
title: "&lt;peerAuthentication&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 09a8a9ff-e395-42f6-8ceb-9d44bdc1cbe1
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;peerAuthentication&gt; Element
Specifies authentication options for peer-to-peer clients.  
  
 [!INCLUDE[crabout](../../../../../includes/crabout-md.md)] peer-to-peer programming, see [Peer-to-Peer Networking](../../../../../docs/framework/wcf/feature-details/peer-to-peer-networking.md).  
  
 \<system.ServiceModel>  
\<behaviors>  
\<endpointBehaviors>  
\<behavior>  
\<clientCredentials>  
\<peer>  
\<PeerAuthentication>  
  
## Syntax  
  
```xml  
<peerAuthentication  
customCertificateValidatorType = "namespace.typeName, [,AssemblyName] [,Version=version number] [,Culture=culture] [,PublicKeyToken=token]"  
certificateValidationMode = "ChainTrust/None/PeerTrust/PeerOrChainTrust/Custom"  
revocationMode="NoCheck/Online/Offline"  
trustedStoreLocation="CurrentUser/LocalMachine"   
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`customCertificateValidatorType`|Optional string. A type and assembly used to validate a custom type. This attribute must be set when `certificateValidationMode` is set to `Custom`.|  
|`certifcateValidationMode`|Optional enumeration. Specifies one of three modes used to validate credentials. If set to `Custom`, then a `customCertificateValidator` must also be supplied. The default is `ChainTrust`.|  
|`revocationMode`|Optional enumeration. One of the modes used to check for a revoked certificate lists (CRL). The default is `Online`.|  
|`trustedStoreLocation`|Optional enumeration. One of the two system store locations: `LocalMachine` or `CurrentUser`. This value is used when a service certificate is negotiated to the client. Validation is performed against the **Trusted People** store in the specified store location. The default is `CurrentUser`.|  
  
## customCertificateValidatorType Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|String|Specifies the type name and assembly and other data used to find the type. At minimum, a namespace and type name are required. Optional information includes: assembly name, version number, culture, and public key token.|  
  
## certificateValidationMode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Enumeration|One of the following values: `None`, `PeerTrust`, `ChainTrust`, `PeerOrChainTrust`, `Custom`. The default is `ChainTrust`.<br /><br /> For more information, see [Working with Certificates](../../../../../docs/framework/wcf/feature-details/working-with-certificates.md).|  
  
## revocationMode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Enumeration|One of the following values: `NoCheck`, `Online`, `Offline`. The default is `Online`.<br /><br /> For more information, see [Working with Certificates](../../../../../docs/framework/wcf/feature-details/working-with-certificates.md).|  
  
## trustedStoreLocation Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Enumeration|One of the following values: `LocalMachine` or `CurrentUser`. The default is `CurrentUser`. If the client application is running under a system account then the certificate is typically under `LocalMachine`. If the client application is running under a user account then the certificate is typically in `CurrentUser`.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<peer>](../../../../../docs/framework/configure-apps/file-schema/wcf/peer-of-clientcredentials-element.md)|Specifies a credential used for authenticating the client to a peer service.|  
  
## Remarks  
 The `<authentication>` element corresponds to the <xref:System.ServiceModel.Security.X509PeerCertificateAuthentication> class. This element specifies a validator, which is invoked during neighbor-to-neighbor authentication in the mesh. When a new peer tries to establish a neighbor connection, it passes its own credential to the responding peer. The validator of the responder is invoked to verify the credential of the remote party. Whenever a peer connection is established in the mesh, both peers are mutually authenticated, meaning validators on both ends are invoked.  
  
## Example  
 The following code sets the certificate validation mode to `PeerOrChainTrust`.  
  
```xml  
<behaviors>  
 <endpointBehaviors>  
  <behavior name="MyEndpointBehavior">  
   <clientCredentials>  
    <peer>  
     <certificate findValue="www.contoso.com"   
                   storeLocation="LocalMachine"  
                   x509FindType="FindByIssuerName" />  
     <peerAuthentication   
          certificateValidationMode="PeerOrChainTrust" />  
     <messageSenderAuthentication certificateValidationMode="None" />  
    </peer>  
   </clientCredentials>  
  </behavior>  
</endpointBehaviors>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.PeerCredentialElement>  
 <xref:System.ServiceModel.Security.X509PeerCertificateAuthentication>  
 <xref:System.ServiceModel.Security.PeerCredential.PeerAuthentication%2A>  
 <xref:System.ServiceModel.Configuration.PeerCredentialElement.PeerAuthentication%2A>  
 <xref:System.ServiceModel.Configuration.X509PeerCertificateAuthenticationElement>  
 [Working with Certificates](../../../../../docs/framework/wcf/feature-details/working-with-certificates.md)  
 [Peer-to-Peer Networking](../../../../../docs/framework/wcf/feature-details/peer-to-peer-networking.md)  
 [Peer Channel Message Authentication](http://msdn.microsoft.com/library/80e73386-514e-4c30-9e4a-b9ca8c173a95)  
 [Peer Channel Custom Authentication](http://msdn.microsoft.com/library/4aa8a82e-41a8-48e2-8621-7e1cbabdca7c)  
 [Securing Peer Channel Applications](../../../../../docs/framework/wcf/feature-details/securing-peer-channel-applications.md)
