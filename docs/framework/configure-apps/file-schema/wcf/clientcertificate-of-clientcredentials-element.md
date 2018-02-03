---
title: "&lt;clientCertificate&gt; of &lt;clientCredentials&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3b3fa000-3434-4142-a178-11903bdd2c5d
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;clientCertificate&gt; of &lt;clientCredentials&gt; Element
Defines an X.509 certificate used to authenticate a client to a service.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<endpointBehaviors>  
\<behavior>  
\<clientCredentials>  
\<clientCertificate>  
  
## Syntax  
  
```xml  
<clientCertificate findValue="String"   
    storeLocation="LocalMachine/CurrentUser"  
    storeName="AddressBook/AuthRoot/CertificateAuthority/Disallowed/My/Root/TrustedPeople/TrustedPublisher"  
X509FindType="FindByThumbPrint/FindBySubjectName/FindBySubjectDistinguishedName/FindByIssuerName/FindByIssuerDistinguishedName/FindBySerialNumber/FindByTimeValid/FindByTimeNotYetValid/FindByTemplateName/FindByApplicationPolicy/FindByCertificatePolicy/FindByExtension/FindByKeyUsage/FindBySubjectKeyIdentifier"  
/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`findValue`|A string that contains the value to search for in the X.509 certificate store. The type contained in the attribute must satisfy the requirements of the `X509FindType` attribute value. The default is an empty string.|  
|`storeLocation`|Specifies the location of the X.509 certificate that the client uses to authenticate itself to the service. Valid values include the following:<br /><br /> -   LocalMachine: the certificate store assigned to the local machine.<br />-   CurrentUser: the certificate store assigned to the current user.<br /><br /> The default is LocalMachine. This attribute is of type <xref:System.Security.Cryptography.X509Certificates.StoreLocation>.|  
|`storeName`|Specifies the name of the X.509 certificate store to search. Valid values include the following:<br /><br /> -   AddressBook: Certificate store for other users.<br />-   AuthRoot: Certificate store for third-party certificate authorities (CAs).<br />-   CertificateAuthority: Certificate store for intermediate certificate authorities (CAs).<br />-   Disallowed: Certificate store for revoked certificates.<br />-   My: Certificate store for personal certificates.<br />-   Root: Certificate store for trusted root certificate authorities (CAs).<br />-   TrustedPeople: Certificate store for directly trusted people and resources.<br />-   TrustedPublisher: Certificate store for directly trusted publishers.<br /><br /> The default is My. This attribute is of type <xref:System.Security.Cryptography.X509Certificates.StoreName>.|  
|X509FindType|Defines the type of X.509 search to be executed. The type contained in the `findValue` attribute must satisfy the requirements of this attribute. Valid values include the following:<br /><br /> -   FindByThumbPrint<br />-   FindBySubjectName<br />-   FindBySubjectDistinguishedName<br />-   FindByIssuerName<br />-   FindByIssuerDistinguishedName<br />-   FindBySerialNumber<br />-   FindByTimeValid<br />-   FindByTimeNotYetValid<br />-   FindByTemplateName<br />-   FindByApplicationPolicy<br />-   FindByCertificatePolicy<br />-   FindByExtension<br />-   FindByKeyUsage<br />-   FindBySubjectKeyIdentifier<br /><br /> The default value is FindBySubjectDistinguishedName. This attribute is of type <xref:System.Security.Cryptography.X509Certificates.X509FindType>.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<clientCredentials>](../../../../../docs/framework/configure-apps/file-schema/wcf/clientcredentials.md)|Specifies the credentials used to authenticate the client to a service.|  
  
## Remarks  
 This configuration element specifies the certificate used to authenticate the client with this element. [!INCLUDE[crdefault](../../../../../includes/crdefault-md.md)] [How to: Specify Client Credential Values](../../../../../docs/framework/wcf/how-to-specify-client-credential-values.md).  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ClientCredentialsElement>  
 <xref:System.ServiceModel.Configuration.ClientCredentialsElement.ClientCertificate%2A>  
 <xref:System.ServiceModel.Description.ClientCredentials>  
 <xref:System.ServiceModel.Description.ClientCredentials.ClientCertificate%2A>  
 <xref:System.ServiceModel.Configuration.X509InitiatorCertificateServiceElement>  
 <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential>  
 [Security Behaviors](../../../../../docs/framework/wcf/feature-details/security-behaviors-in-wcf.md)  
 [How to: Specify Client Credential Values](../../../../../docs/framework/wcf/how-to-specify-client-credential-values.md)  
 [Securing Clients](../../../../../docs/framework/wcf/securing-clients.md)  
 [Working with Certificates](../../../../../docs/framework/wcf/feature-details/working-with-certificates.md)  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)
