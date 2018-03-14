---
title: "How to: Create Temporary Certificates for Use During Development"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "certificates [WCF], creating temporary certificates"
  - "temporary certificates [WCF]"
ms.assetid: bc5f6637-5513-4d27-99bb-51aad7741e4a
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create Temporary Certificates for Use During Development
When developing a secure service or client using [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)], it is often necessary to supply an X.509 certificate to be used as a credential. The certificate typically is part of a chain of certificates with a root authority found in the Trusted Root Certification Authorities store of the computer. Having a certificate chain enables you to scope a set of certificates where typically the root authority is from your organization or business unit. To emulate this at development time, you can create two certificates to satisfy the security requirements. The first is a self-signed certificate that is placed in the Trusted Root Certification Authorities store, and the second certificate is created from the first and is placed in either the Personal store of the Local Machine location, or the Personal store of the Current User location. This topic walks through the steps to create these two certificates using the [Certificate Creation Tool (MakeCert.exe)](http://go.microsoft.com/fwlink/?LinkId=248185), which is provided by the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] SDK.  
  
> [!IMPORTANT]
>  The certificates the Certification Creation tool generates are provided for testing purposes only. When deploying a service or client, be sure to use an appropriate certificate provided by a certification authority. This could either be from a [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] certificate server in your organization or a third party.  
>   
>  By default, the [Makecert.exe (Certificate Creation Tool)](http://msdn.microsoft.com/library/b0343f8e-9c41-4852-a85c-f8a0c408cf0d) creates certificates whose root authority is called "Root Agency**."** Because the "Root Agency" is not in the Trusted Root Certification Authorities store, this makes these certificates insecure. Creating a self-signed certificate that is placed in the Trusted Root Certification Authorities store enables you to create a development environment that more closely simulates your deployment environment.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] creating and using certificates, see [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] using a certificate as a credential, see [Securing Services and Clients](../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md). For a tutorial about using Microsoft Authenticode technology, see [Authenticode Overviews and Tutorials](http://go.microsoft.com/fwlink/?LinkId=88919).  
  
### To create a self-signed root authority certificate and export the private key  
  
1.  Use the MakeCert.exe tool with the following switches:  
  
    1.  `-n` `subjectName`. Specifies the subject name. The convention is to prefix the subject name with "CN = " for "Common Name".  
  
    2.  `-r`. Specifies that the certificate will be self-signed.  
  
    3.  `-sv` `privateKeyFile`. Specifies the file that contains the private key container.  
  
     For example, the following command creates a self-signed certificate with a subject name of "CN=TempCA."  
  
    ```  
    makecert -n "CN=TempCA" -r -sv TempCA.pvk TempCA.cer  
    ```  
  
     You will be prompted to provide a password to protect the private key. This password is required when creating a certificate signed by this root certificate.  
  
### To create a new certificate signed by a root authority certificate  
  
1.  Use the MakeCert.exe tool with the following switches:  
  
    1.  `-sk` `subjectKey`. The location of the subject's key container that holds the private key. If a key container does not exist, one is created. If neither of the -sk or -sv options is used, a key container called JoeSoft is created by default.  
  
    2.  `-n` `subjectName`. Specifies the subject name. The convention is to prefix the subject name with "CN = " for "Common Name".  
  
    3.  `-iv` `issuerKeyFile`. Specifies the issuer's private key file.  
  
    4.  `-ic` `issuerCertFile`. Specifies the location of the issuer's certificate.  
  
     For example, the following command creates a certificate signed by the `TempCA` root authority certificate with a subject name of `"CN=SignedByCA"` using the private key of the issuer.  
  
    ```  
    makecert -sk SignedByCA -iv TempCA.pvk -n "CN=SignedByCA" -ic TempCA.cer SignedByCA.cer -sr currentuser -ss My  
    ```  
  
## Installing a Certificate in the Trusted Root Certification Authorities Store  
 Once a self-signed certificate is created, you can install it in the Trusted Root Certification Authorities store. Any certificates that are signed with the certificate at this point are trusted by the computer. For this reason, delete the certificate from the store as soon as you no longer need it. When you delete this root authority certificate, all other certificates that signed with it become unauthorized. Root authority certificates are simply a mechanism whereby a group of certificates can be scoped as necessary. For example, in peer-to-peer applications, there is typically no need for a root authority because you simply trust the identity of an individual by its supplied certificate.  
  
#### To install a self-signed certificate in the Trusted Root Certification Authorities  
  
1.  Open the certificate snap-in. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: View Certificates with the MMC Snap-in](../../../../docs/framework/wcf/feature-details/how-to-view-certificates-with-the-mmc-snap-in.md).  
  
2.  Open the folder to store the certificate, either the **Local Computer** or the **Current User**.  
  
3.  Open the **Trusted Root Certification Authorities** folder.  
  
4.  Right-click the **Certificates** folder and click **All Tasks**, then click **Import**.  
  
5.  Follow the on-screen wizard instructions to import the TempCa.cer into the store.  
  
## Using Certificates With WCF  
 Once you have set up the temporary certificates, you can use them to develop WCF solutions that specify certificates as a client credential type. For example, the following XML configuration specifies message security and a certificate as the client credential type.  
  
#### To specify a certificate as the client credential type  
  
-   In the configuration file for a service, use the following XML to set the security mode to message, and the client credential type to certificate.  
  
    ```xml  
    <bindings>       
      <wsHttpBinding>  
        <binding name="CertificateForClient">  
          <security>  
            <message clientCredentialType="Certificate" />  
          </security>  
        </binding>  
      </wsHttpBinding>  
    </bindings>  
    ```  
  
 In the configuration file for a client, use the following XML to specify that the certificate is found in the user’s store, and can be found by searching the SubjectName field for the value "CohoWinery."  
  
```xml  
<behaviors>  
  <endpointBehaviors>  
    <behavior name="CertForClient">  
      <clientCredentials>  
        <clientCertificate findValue="CohoWinery" x509FindType="FindBySubjectName" />  
       </clientCredentials>  
     </behavior>  
   </endpointBehaviors>  
</behaviors>  
```  
  
 For more information about using certificates in WCF, see [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md).  
  
## .NET Framework Security  
 Be sure to delete any temporary root authority certificates from the **Trusted Root Certification Authorities** and **Personal** folders by right-clicking the certificate, then clicking **Delete**.  
  
## See Also  
 [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md)  
 [How to: View Certificates with the MMC Snap-in](../../../../docs/framework/wcf/feature-details/how-to-view-certificates-with-the-mmc-snap-in.md)  
 [Securing Services and Clients](../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)
