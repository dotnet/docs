---
title: "<certificateReference>"
ms.date: "03/30/2017"
ms.assetid: 2ac8bc14-e9f1-48fb-b662-f5991558fbe4
author: "BrucePerlerMS"
---
# \<certificateReference>
Specifies settings that are used to find and validate an X.509 certificate in a certificate store.  
  
 \<system.identityModel.services>  
\<federationConfiguration>  
\<serviceCertificate>  
\<certificateReference>  
  
## Syntax  
  
```xml  
<system.identityModel.services>  
  <federationConfiguration>  
    <serviceCertificate>  
      <certificateReference   
        storeName="AddressBook||AuthRoot||CertificateAuthority||Disallowed||My||Root||TrustedPeople||TrustedPublisher"  
        storeLocation="CurrentUser||LocalMachine"  
        x509FindType="FindByThumbprint||FindBySubjectName||FindBySubjectDistinguishedName||FindByIssuerName||FindByIssuerDistinguishedName||FindBySerialNumber||FindByTimeValid||FindByTimeNotYetValid||FindByTimeExpired||FindByTemplateName||FindByApplicationPolicy||FindByCertificatePolicy||FindByExtension||FindByKeyUsage||FindBySubjectKeyIdentifier"  
        findValue=xs:String  
        isChainIncluded=xs:Boolean >  
      </certificateReference>  
    </serviceCertificate>  
  </federationConfiguration>  
</system.identityModel.services>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|storeName|The name of the X.509 certificate store. The default is "My". Optional.|  
|storeLocation|A <xref:System.Security.Cryptography.X509Certificates.StoreLocation> value that specifies the location of the X.509 certificate store. The default value is "LocalMachine". Optional.|  
|x509FindType|An <xref:System.Security.Cryptography.X509Certificates.X509FindType> value that specifies the type of search that is to be executed. The default is "FindBySubjectDistinguishedName". Optional.|  
|findValue|The value to search for in the X.509 certificate store. Optional.|  
|isChainIncluded|Specifies whether validation should be performed by using the certificate chain. The default is "true"; validation is performed by using the certificate chain. Optional.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<serviceCertificate>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/servicecertificate.md)|Configures the certificate that is used to encrypt and decrypt tokens.|  
  
## Remarks  
 The `<certificateReference>` element specifies settings that are used to find and validate an X.509 certificate in a certificate store. When it is specified as the child element of the `<serviceCertificate>` element, it specifies the location and verification settings of the X.509 certificate that is used to encrypt and decrypt tokens. The `<certificateReference>` element is represented by the <xref:System.ServiceModel.Configuration.CertificateReferenceElement> class.
