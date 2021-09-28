---
description: "Learn more about: <certificate> Element"
title: "<certificate> Element"
ms.date: "03/30/2017"
ms.assetid: 9b3d9233-ef35-477a-bf5d-efd1e80a52f4
---
# \<certificate> Element

Specifies an X.509 certificate to use for signing and encrypting messages for peer-to-peer clients.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<endpointBehaviors>**](endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<clientCredentials>**](clientcredentials.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<peer>**](peer-of-clientcredentials-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<certificate>**  
  
## Syntax  
  
```xml  
<certificate findValue="String"
             storeLocation="LocalMachine/CurrentUser"
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
|`storeName`|Specifies the name of the X.509 certificate store to open. Valid values include the following:<br /><br /> -   AddressBook: Certificate store for other users.<br />-   AuthRoot: Certificate store for third-party certification authorities (CAs).<br />-   CertificateAuthority: Certificate store for intermediate certification authorities (CAs).<br />-   Disallowed: Certificate store for revoked certificates.<br />-   My: Certificate store for personal certificates.<br />-   Root: Certificate store for trusted root certification authorities (CAs).<br />-   TrustedPeople: Certificate store for directly-trusted people and resources.<br />-   TrustedPublisher: Certificate store for directly-trusted publishers.<br /><br /> The default is My.|  
|`X509FindType`|Defines the type of X.509 search to be executed. Valid values include the following:<br /><br /> -   FindByThumbPrint<br />-   FindBySubjectName<br />-   FindBySubjectDistinguishedName<br />-   FindByIssuerName<br />-   FindByIssuerDistinguishedName<br />-   FindBySerialNumber<br />-   FindByTimeValid<br />-   FindByTimeNotYetValid<br />-   FindByTemplateName<br />-   FindByApplicationPolicy<br />-   FindByCertificatePolicy<br />-   FindByExtension<br />-   FindByKeyUsage<br />-   FindBySubjectKeyIdentifier<br /><br /> The type contained in the `findValue` attribute must satisfy the requirements of the specified `X509FindType`.<br /><br /> The default value is FindBySubjectDistinguishedName.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<peer>](peer-of-clientcredentials-element.md)|Specifies credentials used when authenticating peer-to-peer clients.|  
  
## Remarks  

 This configuration element contains a X509Certificate2 instance used when authenticating neighbors in the peer mesh.  
  
 For more information about peer-to-peer programming, see [Peer-to-Peer Networking](../../../wcf/feature-details/peer-to-peer-networking.md).  
  
## Example  

 The following code specifies how to find the certificate used in a peer-to-peer scenario.  
  
```xml  
<behaviors>
  <endpointBehaviors>
    <behavior name="MyEndpointBehavior">
      <clientCredentials>
        <peer>
          <certificate findValue="www.contoso.com"
                       storeLocation="LocalMachine"
                       x509FindType="FindByIssuerName" />
        </peer>
      </clientCredentials>
    </behavior>
  </endpointBehaviors>
</behaviors>
```  
  
## See also

- <xref:System.ServiceModel.Configuration.PeerCredentialElement>
- <xref:System.ServiceModel.Configuration.PeerCredentialElement.Certificate%2A>
- <xref:System.ServiceModel.Configuration.X509PeerCertificateElement>
- <xref:System.ServiceModel.Security.PeerCredential.Certificate%2A>
- [Working with Certificates](../../../wcf/feature-details/working-with-certificates.md)
- [Peer-to-Peer Networking](../../../wcf/feature-details/peer-to-peer-networking.md)
- [Peer Channel Message Authentication](/previous-versions/dotnet/netframework-3.5/aa967730(v=vs.90))
- [Peer Channel Custom Authentication](/previous-versions/dotnet/netframework-3.5/ms751447(v=vs.90))
- [Securing Peer Channel Applications](../../../wcf/feature-details/securing-peer-channel-applications.md)
