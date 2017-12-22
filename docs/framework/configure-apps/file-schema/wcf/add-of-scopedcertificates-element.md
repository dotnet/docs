---
title: "&lt;add&gt; of &lt;scopedCertificates&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e21c1ef8-d6d6-4bca-ac5a-6fbf4bd77412
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;add&gt; of &lt;scopedCertificates&gt; Element
Adds an X.509 certificate to the collection of scoped certificates.  
  
 \<system.ServiceModel>  
\<behaviors>  
endpointBehaviors section  
\<behavior>  
\<clientCredentials>  
\<serviceCertificate>  
\<scopedCertificates>  
\<add> element for \<scopedCertificates>  
  
## Syntax  
  
```xml  
<add findValue="String"  
          storeLocation="CurrentUser/LocalMachine"  
          storeName=" CurrentUser/LocalMachine"  
          targetUri="string"  
         x509Type="FindByThumbprint/FindBySubjectName/FindBySubjectDistinguishedName/FindByIssuerName/FindByIssuerDistinguishedName/FindBySerialNumber/FindByTimeValid/FindByTimeNotYetValid/FindBySerialNumber/FindByTimeExpired/FindByTemplateName/FindByApplicationPolicy/FindByCertificatePolicy/FindByExtension/FindByKeyUsage/FindBySubjectKeyIdentifier"   
/>   
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|targetUri|String. Specifies the URI of the service associated with the certificate.|  
|findValue|String. The value to search for.|  
|x509FindType|Enumeration. One of the certificate fields to search.|  
|storeLocation|Enumeration. One of the two store locations to search.|  
|storeName|Enumeration. One of the system stores to search.|  
  
## findValue Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|String|The value depends on the field (specified by the X509FindType attribute) being searched. For example, if searching for a thumbprint, the value must be a string of hexadecimal numbers.|  
  
## x509FindType Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Enumeration|Values include: FindByThumbprint, FindBySubjectName, FindBySubjectDistinguishedName, FindByIssuerName, FindByIssuerDistinguishedName, FindBySerialNumber, FindByTimeValid, FindByTimeNotYetValid, FindBySerialNumber, FindByTimeExpired, FindByTemplateName, FindByApplicationPolicy, FindByCertificatePolicy, FindByExtension, FindByKeyUsage, FindBySubjectKeyIdentifier.|  
  
## storeLocation Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Enumeration|CurrentUser or LocalMachine.|  
  
## storeName Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Enumeration|Values include: AddressBook, AuthRoot, CertificateAuthority, Disallowed, My, Root, TrustedPeople, and TrustedPublisher.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<scopedCertificates>](../../../../../docs/framework/configure-apps/file-schema/wcf/scopedcertificates-element.md)|Represents a collection of X.509 certificates provided by specific services (scoped) for authentication.|  
  
## Remarks  
 This element enables the client to configure a service certificate to use based on the URL of the service it communicates with. This is especially useful in issued token scenarios where a client can be communicating to multiple services (the end service as well as intermediary security token services). For bindings that use certificate-based message security, this certificate is used to encrypt messages to the service, and is expected to be used by the service for signing replies to the client.  
  
 If a binding requires a certificate for the service and no specific certificate for the service URL is found in the ScopedCertificates, the default certificate is used.  
  
 For more information, see the "Scoped Certificates" section of [How to: Create a Federated Client](../../../../../docs/framework/wcf/feature-details/how-to-create-a-federated-client.md).  
  
## Example  
 The following example adds an X.509 certificate the collection.  
  
```xml  
<behaviors>  
 <endpointBehaviors>  
  <behavior name="MyEndpointBehavior">  
   <clientCredentials>  
    <serviceCertificate>  
     <scopedCertificates>  
      <add targetUri="http://www.contoso.com"   
       findValue="www.Contoso.com"   
       storeLocation="LocalMachine"  
       storeName="Root"   
       x509FindType="FindByIssuerName" />  
     </scopedCertificates>  
    </serviceCertificate>  
   </clientCredentials>  
  </behavior>  
 </endpointBehaviors>  
</behaviors>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.X509RecipientCertificateClientElement.ScopedCertificates%2A>  
 <xref:System.ServiceModel.Configuration.X509ScopedServiceCertificateElementCollection>  
 <xref:System.ServiceModel.Configuration.X509ScopedServiceCertificateElement>  
 <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential>  
 <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential.ScopedCertificates%2A>  
 [How to: Create a Federated Client](../../../../../docs/framework/wcf/feature-details/how-to-create-a-federated-client.md)  
 [Working with Certificates](../../../../../docs/framework/wcf/feature-details/working-with-certificates.md)  
 [Securing Clients](../../../../../docs/framework/wcf/securing-clients.md)  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)
