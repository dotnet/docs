---
title: "&lt;authentication&gt; of &lt;serviceCertificate&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 733b67b4-08a1-4d25-9741-10046f9357ef
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;authentication&gt; of &lt;serviceCertificate&gt; Element
Specifies the settings used by the client proxy to authenticate service certificates that are obtained using SSL/TLS negotiation.  
  
 \<system.ServiceModel>  
\<behaviors>  
endpointBehaviors section  
\<behavior>  
\<clientCredentials>  
\<serviceCertificate>  
\<authentication>  
  
## Syntax  
  
```xml  
<authentication customCertificateValidatorType="String" certificateValidationMode="None/PeerTrust/ChainTrust/PeerOrChainTrust/Custom"  
revocationMode="NoCheck/Online/Offline"   
trustedStoreLocation="LocalMachine/CurrentUser" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|customCertificateValidatorType|String. A type and assembly used to validate a custom type.|  
|certificateValidationMode|Specifies one of three modes used to validate credentials. If set to `Custom`, then a customCertificateValidator must also be supplied. The default is `ChainTrust`.|  
|revocationMode|One of the modes used to check for a revoked certificate lists (CRL). The default is `Online`.|  
|trustedStoreLocation|One of the two system store locations: `LocalMachine` or `CurrentUser`. This value is used when a service certificate is negotiated to the client. Validation is performed against the **Trusted People** store in the specified store location. The default is `CurrentUser`.|  
  
## customCertificateValidator Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|String|Specifies the type name and assembly and other data used to find the type.|  
  
## certificateValidationMode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Enumeration|One of the following values: None, PeerTrust, ChainTrust, PeerOrChainTrust, Custom.<br /><br /> For more information, see [Working with Certificates](../../../../../docs/framework/wcf/feature-details/working-with-certificates.md).|  
  
## revocationMode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Enumeration|One of the following values: NoCheck, Online, Offline.<br /><br /> For more information, see [Working with Certificates](../../../../../docs/framework/wcf/feature-details/working-with-certificates.md).|  
  
## trustedStoreLocation Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Enumeration|One of the following values: LocalMachine or CurrentUser. The default is CurrentUser. If the client application is running under a system account, then the certificate is typically under LocalMachine. If the client application is running under a user account, then the certificate is typically in CurrentUser.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<serviceCertificate>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicecertificate-of-clientcredentials-element.md)|Specifies a certificate to use when authenticating a service to the client.|  
  
## Remarks  
 The `certificateValidationMode` attribute of this configuration element specifies the level of trust used to authenticate certificates. By default, the level is set to `ChainTrust`, which specifies that each certificate must be found in a hierarchy of certificates ending in a trusted certification authority at the top of the chain. This is the most secure mode. You can also set the value to `PeerOrChainTrust`, which specifies that self-issued certificates (peer trust) are accepted as well as certificates that are in a trusted chain. This value is used when developing and debugging clients and services because self-issued certificates need not be purchased from a trusted authority. When deploying a client, use the `ChainTrust` value instead. You can also set the value to `Custom` or `None`. To use the `Custom` value, you must also set the `customCertificateValidator` attribute to an assembly and type used to validate the certificate. To create your own custom validator, you must inherit from the abstract X509CertificateValidator class. For more information, see [How to: Create a Service that Employs a Custom Certificate Validator](../../../../../docs/framework/wcf/extending/how-to-create-a-service-that-employs-a-custom-certificate-validator.md).  
  
 The `revocationMode` attribute specifies how certificates are checked for revocation. The default is `online` which indicates that certificates will be checked automatically for revocation. For more information, see [Working with Certificates](../../../../../docs/framework/wcf/feature-details/working-with-certificates.md).  
  
## Example  
 The following example does two tasks. It first specifies a service certificate for the client to use when communicating with endpoints whose domain name is www.contoso.com over the HTTP protocol. Second, it specifies the revocation mode and store location used during authentication.  
  
```xml  
<serviceCertificate>  
  <defaultCertificate findValue="www.contoso.com"   
                      storeLocation="LocalMachine"  
                      storeName="TrustedPeople"   
                      x509FindType="FindByIssuerDistinguishedName" />  
  <scopedCertificates>  
     <add targetUri="http://www.contoso.com"   
          findValue="www.contoso.com" storeLocation="LocalMachine"  
                  storeName="Root" x509FindType="FindByIssuerName" />  
  </scopedCertificates>  
  <authentication revocationMode="Online"   
   trustedStoreLocation="LocalMachine" />  
</serviceCertificate>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.X509RecipientCertificateClientElement>  
 <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential>  
 <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential.Authentication%2A>  
 <xref:System.ServiceModel.Security.X509ServiceCertificateAuthentication>  
 [Security Behaviors](../../../../../docs/framework/wcf/feature-details/security-behaviors-in-wcf.md)  
 [Working with Certificates](../../../../../docs/framework/wcf/feature-details/working-with-certificates.md)  
 [How to: Create a Service that Employs a Custom Certificate Validator](../../../../../docs/framework/wcf/extending/how-to-create-a-service-that-employs-a-custom-certificate-validator.md)  
 [\<authentication>](../../../../../docs/framework/configure-apps/file-schema/wcf/authentication-of-clientcertificate-element.md)  
 [Securing Clients](../../../../../docs/framework/wcf/securing-clients.md)  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)
