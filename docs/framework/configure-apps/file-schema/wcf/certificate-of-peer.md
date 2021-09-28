---
description: "Learn more about: <certificate> of <peer>"
title: "<certificate> of <peer>"
ms.date: "03/30/2017"
ms.assetid: 48b69142-c957-4305-a042-c9d0c9a55c0e
---
# \<certificate> of \<peer>

Specifies a certificate used by a peer.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<serviceBehaviors>**](servicebehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-servicebehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<serviceCredentials>**](servicecredentials.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<peer>**](peer-of-servicecredentials.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<certificate>**  
  
## Syntax  
  
```xml  
<certificate findValue = "String"
             storeLocation = "CurrentUser/LocalMachine"
             storeName="AddressBook/AuthRoot/CertificateAuthority/Disallowed/My/Root/TrustedPeople/TrustedPublisher"
             X509FindType="FindByThumbPrint/FindBySubjectName/FindBySubjectDistinguishedName/FindByIssuerName/FindByIssuerDistinguishedName/FindBySerialNumber/FindByTimeValid/FindByTimeNotYetValid/FindByTemplateName/FindByApplicationPolicy/FindByCertificatePolicy/FindByExtension/FindByKeyUsage/FindBySubjectKeyIdentifier" />
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
|[\<peer>](peer-of-servicecredentials.md)|Specifies the current credentials for a peer node.|  
  
## Remarks  

 This configuration element contains an `X509Certificate2` instance used when authenticating neighbors in the peer mesh.  
  
 For more information about peer-to-peer programming, see [Peer-to-Peer Networking](../../../wcf/feature-details/peer-to-peer-networking.md).  
  
## See also

- <xref:System.ServiceModel.Configuration.PeerCredentialElement>
- <xref:System.ServiceModel.Configuration.PeerCredentialElement.Certificate%2A>
- <xref:System.ServiceModel.Configuration.X509PeerCertificateElement>
- <xref:System.ServiceModel.Security.PeerCredential.Certificate%2A>
- <xref:System.ServiceModel.Security.PeerCredential>
- [Working with Certificates](../../../wcf/feature-details/working-with-certificates.md)
- [Peer-to-Peer Networking](../../../wcf/feature-details/peer-to-peer-networking.md)
- [Peer Channel Message Authentication](/previous-versions/dotnet/netframework-3.5/aa967730(v=vs.90))
- [Peer Channel Custom Authentication](/previous-versions/dotnet/netframework-3.5/ms751447(v=vs.90))
- [Securing Peer Channel Applications](../../../wcf/feature-details/securing-peer-channel-applications.md)
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
