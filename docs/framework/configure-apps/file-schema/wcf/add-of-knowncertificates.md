---
title: "&lt;add&gt; of &lt;knownCertificates&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 128aaabe-3f1a-4c3b-b59f-898d0f02910f
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;add&gt; of &lt;knownCertificates&gt;
Adds an X.509 certificate to the collection of known certificates.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<serviceCredentials>  
\<issuedTokenAuthentication>  
\<knownCertificates>  
\<add>  
  
## Syntax  
  
```xml  
<knownCertificates>   
   <add findValue="String"  
      storeLocation="CurrentUser/LocalMachine"  
      storeName="AddressBook/AuthRoot/CertificateAuthority/Disallowed/My/Root/TrustedPeople/TrustedPublisher"  
      x509FindType="FindByThumbprint/FindBySubjectName/FindBySubjectDistinguishedName/FindByIssuerName/FindByIssuerDistinguishedName/FindBySerialNumber/FindByTimeValid/FindByTimeNotYetValid/FindBySerialNumber/FindByTimeExpired/FindByTemplateName/FindByApplicationPolicy/FindByCertificatePolicy/FindByExtension/FindByKeyUsage/FindBySubjectKeyIdentifier"/>  
</knownCertificates>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|findValue|String. The value to search for.|  
|storeLocation|Enumeration. One of the two store locations to search.|  
|storeName|Enumeration. One of the system stores to search.|  
|x509FindType|Enumeration. One of the certificate fields to search.|  
  
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
|[\<knownCertificates>](../../../../../docs/framework/configure-apps/file-schema/wcf/knowncertificates.md)|Represents a collection of X.509 certificates that are provided by a Security Token Service (STS) for validation of security tokens.|  
  
## Remarks  
 The issued token scenario has three stages. In the first stage, a client trying to access a service is referred to a *secure token service*. The secure token service then authenticates the client and subsequently issues the client a token, typically a Security Assertions Markup Language (SAML) token. The client then returns to the service with the token. The service examines the token for data that allows the service to authenticate the token and therefore the client. To authenticate the token, the certificate the secure token service uses must be known to the service.  
  
 The [\<issuedTokenAuthentication>](../../../../../docs/framework/configure-apps/file-schema/wcf/issuedtokenauthentication-of-servicecredentials.md) element is the repository for any such secure token service certificates. To add certificates, use the [\<knownCertificates>](../../../../../docs/framework/configure-apps/file-schema/wcf/knowncertificates.md). Insert an [\<add> element \<knownCertificates> Element](../../../../../docs/framework/configure-apps/file-schema/wcf/add-of-knowncertificates.md) for each certificate, as shown in the following example.  
  
```xml  
<issuedTokenAuthentication>  
   <knownCertificates>  
      <add findValue="www.contoso.com"   
           storeLocation="LocalMachine" storeName="My"   
           X509FindType="FindBySubjectName" />  
    </knownCertificates>  
</issuedTokenAuthentication>  
```  
  
 By default, the certificates must be obtained from a secure token service. These "known" certificates ensure that only legitimate clients can access a service.  
  
 To review conditions required for a client to be authenticated by a federated service, as well as more information on using this configuration element, see [How to: Configure Credentials on a Federation Service](../../../../../docs/framework/wcf/feature-details/how-to-configure-credentials-on-a-federation-service.md). For more information about federated scenarios, see [Federation and Issued Tokens](../../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md).  
  
## Example  
 The following example adds certificate to the repository for any STS certificates.  
  
```xml  
<serviceBehaviors>  
 <behavior name="myServiceBehavior">  
  <serviceCredentials>  
   <issuedTokenAuthentication>  
    <knownCertificates>  
     <add findValue="www.contoso.com" storeLocation="LocalMachine"   
           storeName="CertificateAuthority"  
           x509FindType="FindByIssuerName" />  
     </knownCertificates>  
    </issuedTokenAuthentication>  
   </serviceCredentials>  
  </behavior>  
 </serviceBehaviors>  
```  
  
## See Also  
 <xref:System.IdentityModel.Selectors.SamlSecurityTokenAuthenticator>  
 <xref:System.IdentityModel.Selectors.SamlSecurityTokenAuthenticator.AllowedAudienceUris%2A>  
 <xref:System.IdentityModel.Selectors.SamlSecurityTokenAuthenticator.AudienceUriMode%2A>  
 <xref:System.ServiceModel.Configuration.IssuedTokenServiceElement.KnownCertificates%2A>  
 <xref:System.ServiceModel.Configuration.X509CertificateTrustedIssuerElementCollection>  
 <xref:System.ServiceModel.Configuration.X509CertificateTrustedIssuerElement>  
 <xref:System.ServiceModel.Security.IssuedTokenServiceCredential.KnownCertificates%2A>  
 [\<knownCertificates>](../../../../../docs/framework/configure-apps/file-schema/wcf/knowncertificates.md)  
 [Working with Certificates](../../../../../docs/framework/wcf/feature-details/working-with-certificates.md)  
 [Federation and Issued Tokens](../../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md)  
 [How to: Configure Credentials on a Federation Service](../../../../../docs/framework/wcf/feature-details/how-to-configure-credentials-on-a-federation-service.md)  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)
