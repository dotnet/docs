---
description: "Learn more about: <certificateReference> for <identity>"
title: "<certificateReference> for <identity>"
ms.date: "03/30/2017"
ms.assetid: ac359c65-c22d-42d2-97de-db53b77cebdb
---
# \<certificateReference> for \<identity>

Specifies settings for X.509 certificate validation. A secure Windows Communication Foundation (WCF) client that connects to an endpoint with this identity verifies that the claims presented by the server contain the identity claim used to construct this identity.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<client>**](client.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<endpoint>**](endpoint-of-client.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<identity>**](identity.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<certificateReference>**  
  
## Syntax  
  
```xml  
<certificateReference findValue="String"
                      isChainIncluded="Boolean"
                      storeName="AddressBook/AuthRoot/CertificateAuthority/Disallowed/My/Root/TrustedPeople/TrustedPublisher"
                      storeLocation="LocalMachine/CurrentUser"
                      X509FindType="FindByThumbPrint/FindBySubjectName/FindBySubjectDistinguishedName/FindByIssuerName/FindByIssuerDistinguishedName/FindBySerialNumber/FindByTimeValid/FindByTimeNotYetValid/FindByTemplateName/FindByApplicationPolicy/FindByCertificatePolicy/FindByExtension/FindByKeyUsage/FindBySubjectKeyIdentifier">
</certificateReference>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|findValue|Specifies the value to search for in the X.509 certificate store. The type contained in this attribute must satisfy the requirements of the specified `X509FindType` value. The default is an empty string.|  
|isChainIncluded|A Boolean value that specifies if the validation is done using a certificate chain.|  
|storeLocation|Specifies the location of the certificate store that the client can use to validate the server’s certificate.<br /><br /> Valid values include the following:<br /><br /> -   LocalMachine: The cert store assigned to the local machine.<br />-   CurrentUser: The cert store assigned to the current user.<br /><br /> The default value is LocalMachine.<br /><br /> This attribute is of type <xref:System.Security.Cryptography.X509Certificates.StoreLocation>.|  
|storeName|Specifies the name of the X.509 certificate store to open.<br /><br /> Valid values include the following:<br /><br /> -   AddressBook: Certificate store for other users.<br />-   AuthRoot: Certificate store for third-party certification authorities (CAs).<br />-   CertificateAuthority: Certificate store for intermediate CAs.<br />-   Disallowed: Certificate store for revoked certificates.<br />-   My: Certificate store for personal certificates.<br />-   Root: Certificate store for trusted root CAs.<br />-   TrustedPeople: Certificate store for directly trusted people and resources.<br />-   TrustedPublisher: Certificate store for directly trusted publishers.<br /><br /> The default value is My.<br /><br /> This attribute is of type <xref:System.Security.Cryptography.X509Certificates.StoreName>.|  
|X509FindType|Specifies the type of X.509 search to be executed. The type contained in the `findValue` attribute must satisfy the requirements of the specified X509FindType.<br /><br /> Valid values include the following:<br /><br /> -   FindByThumbPrint<br />-   FindBySubjectName<br />-   FindBySubjectDistinguishedName<br />-   FindByIssuerName<br />-   FindByIssuerDistinguishedName<br />-   FindBySerialNumber<br />-   FindByTimeValid<br />-   FindByTimeNotYetValid<br />-   FindByTemplateName<br />-   FindByApplicationPolicy<br />-   FindByCertificatePolicy<br />-   FindByExtension<br />-   FindByKeyUsage<br />-   FindBySubjectKeyIdentifier<br /><br /> The default value is FindBySubjectDistinguishedName.<br /><br /> This attribute is of type <xref:System.Security.Cryptography.X509Certificates.X509FindType>.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<identity>](identity.md)|Specifies settings that enable the authentication of an endpoint by other endpoints exchanging messages with it.|  
  
## See also

- <xref:System.ServiceModel.Configuration.CertificateReferenceElement>
- <xref:System.ServiceModel.Configuration.IdentityElement>
- <xref:System.ServiceModel.EndpointAddress>
- <xref:System.ServiceModel.EndpointAddress.Identity%2A>
