---
title: "How to: Specify the Certificate Authority Certificate Chain Used to Verify Signatures (WCF)"
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
  - "certificates [WCF], specifying the certificate authority certificate chain"
  - "certificates [WCF], verifying signatures"
ms.assetid: 7c719355-aa41-4567-80d0-5115a8cf73fd
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Specify the Certificate Authority Certificate Chain Used to Verify Signatures (WCF)
When [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] receives a SOAP message signed using an X.509 certificate, by default it verifies that the X.509 certificate was issued by a trusted certification authority. This is done by looking in a certificate store and determining if the certificate for that certification authority has been designated as trusted. In order for [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] to make this determination, the certification authority certificate chain must be installed in the correct certificate store.  
  
### To install a certification authority certificate chain  
  
-   For each certification authority that a SOAP message recipient intends to trust X.509 certificates issued from, install the certification authority certificate chain into the certificate store that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is configured to retrieve X.509 certificates from.  
  
     For instance, if a SOAP message recipient intends to trust X.509 certificates issued by Microsoft, the certification authority certificate chain for Microsoft must be installed in the certificate store that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is set up to look for X.509 certificates from. The certificate store in which [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] looks for X.509 certificates can be specified in code or configuration. For example, this can be specified in code using the <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential.SetCertificate%2A> method or in configuration a few ways, including the [\<serviceCertificate>](../../../../docs/framework/configure-apps/file-schema/wcf/servicecertificate-of-clientcredentials-element.md) .  
  
     Because Windows ships with a set of default certificate chains for trusted certificate authorities, it may not be necessary to install the certificate chain for all certificate authorities.  
  
    1.  Export the certification authority certificate chain.  
  
         Exactly how this is done depends on the certification authority. If the certification authority is running Microsoft Certificate Services, select **Download a CA certificate, certificate chain, or CRL**, and then choose **Download CA certificate**.  
  
    2.  Import the certification authority certificate chain.  
  
         In the Microsoft Management Console (MMC), open the Certificates snap-in. For the certificate store that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is configured to retrieve X.509 certificates from, select the **Trusted Root** **Certification Authorities**folder. Under the **Trusted Root Certification Authorities** folder, right-click the **Certificates**folder, point to **All Tasks**, and then click **Import**. Provide the file exported in step a.  
  
         [!INCLUDE[crabout](../../../../includes/crabout-md.md)] using the Certificates snap-in with MMC, see [How to: View Certificates with the MMC Snap-in](../../../../docs/framework/wcf/feature-details/how-to-view-certificates-with-the-mmc-snap-in.md).  
  
## See Also  
 [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md)
