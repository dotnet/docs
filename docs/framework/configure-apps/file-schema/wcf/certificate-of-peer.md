---
title: "&lt;certificate&gt; of &lt;peer&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 48b69142-c957-4305-a042-c9d0c9a55c0e
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;certificate&gt; of &lt;peer&gt;
Specifies a certificate used by a peer.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<serviceCredentials>  
\<peer>  
\<certificate>  
  
## Syntax  
  
```xml  
<certificate findValue = "String"   
storeLocation = "CurrentUser/LocalMachine"  
storeName="AddressBook/AuthRoot/CertificateAuthority/Disallowed/My/Root/TrustedPeople/TrustedPublisher"  
X509FindType="FindByThumbPrint/FindBySubjectName/FindBySubjectDistinguishedName/FindByIssuerName/FindByIssuerDistinguishedName/FindBySerialNumber/FindByTimeValid/FindByTimeNotYetValid/FindByTemplateName/FindByApplicationPolicy/FindByCertificatePolicy/FindByExtension/FindByKeyUsage/FindBySubjectKeyIdentifier"  
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`findValue`|A string that contains the value to search for in the X.509 certificate store. The type contained in the attribute must satisfy the requirements of the specified `x509FindType`. The default is an empty string.|  
|`storeLocation`|Specifies the location of the X.509 certificate store that the client uses to validate the peer's certificate against. Valid values include the following:<br /><br /> -   LocalMachine: the certificate store assigned to the local machine.<br />-   CurrentUser: the certificate store assigned to the current user.<br /><br /> The default is LocalMachine.|  
|`storeName`|Specifies the name of the X.509 certificate store to open. Valid values include the following:<br /><br /> -   AddressBook: Certificate store for other users.<br />-   AuthRoot: Certificate store for third-party certificate authorities (CAs).<br />-   CertificateAuthority: Certificate store for intermediate certificate authorities (CAs).<br />-   Disallowed: Certificate store for revoked certificates.<br />-   My: Certificate store for personal certificates.<br />-   Root: Certificate store for trusted root certificate authorities (CAs).<br />-   TrustedPeople: Certificate store for directly-trusted people and resources.<br />-   TrustedPublisher: Certificate store for directly-trusted publishers.<br /><br /> The default is My.|  
|`X509FindType`|Defines the type of X.509 search to be executed. Valid values include the following:<br /><br /> -   FindByThumbPrint<br />-   FindBySubjectName<br />-   FindBySubjectDistinguishedName<br />-   FindByIssuerName<br />-   FindByIssuerDistinguishedName<br />-   FindBySerialNumber<br />-   FindByTimeValid<br />-   FindByTimeNotYetValid<br />-   FindByTemplateName<br />-   FindByApplicationPolicy<br />-   FindByCertificatePolicy<br />-   FindByExtension<br />-   FindByKeyUsage<br />-   FindBySubjectKeyIdentifier<br /><br /> The type contained in the `findValue` attribute must satisfy the requirements of the specified `X509FindType`.<br /><br /> The default value is FindBySubjectDistinguishedName.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<peer>](../../../../../docs/framework/configure-apps/file-schema/wcf/peer-of-servicecredentials.md)|Specifies the current credentials for a peer node.|  
  
## Remarks  
 This configuration element contains an `X509Certificate2` instance used when authenticating neighbors in the peer mesh.  
  
 For more information about peer-to-peer programming, see [Peer-to-Peer Networking](../../../../../docs/framework/wcf/feature-details/peer-to-peer-networking.md).  
  
## See Also  
 <xref:System.ServiceModel.Configuration.PeerCredentialElement>  
 <xref:System.ServiceModel.Configuration.PeerCredentialElement.Certificate%2A>  
 <xref:System.ServiceModel.Configuration.X509PeerCertificateElement>  
 <xref:System.ServiceModel.Security.PeerCredential.Certificate%2A>  
 <xref:System.ServiceModel.Security.PeerCredential>  
 [Working with Certificates](../../../../../docs/framework/wcf/feature-details/working-with-certificates.md)  
 [Peer-to-Peer Networking](../../../../../docs/framework/wcf/feature-details/peer-to-peer-networking.md)  
 [Peer Channel Message Authentication](http://msdn.microsoft.com/library/80e73386-514e-4c30-9e4a-b9ca8c173a95)  
 [Peer Channel Custom Authentication](http://msdn.microsoft.com/library/4aa8a82e-41a8-48e2-8621-7e1cbabdca7c)  
 [Securing Peer Channel Applications](../../../../../docs/framework/wcf/feature-details/securing-peer-channel-applications.md)  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)
