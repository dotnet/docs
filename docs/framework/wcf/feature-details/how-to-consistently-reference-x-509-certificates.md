---
description: "Learn more about: How to: Consistently Reference X.509 Certificates"
title: "How to: Consistently Reference X.509 Certificates"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "certificates [WCF], referencing X.509 certificates"
ms.assetid: a6de1c63-e450-4640-ad08-ad7302dbfbfc
---
# How to: Consistently Reference X.509 Certificates

You can identify a certificate in several ways: by the hash of the certificate, by the issuer and serial number, or by the subject key identifier (SKI). The SKI provides a unique identification for the certificate's subject public key and is often used when working with XML digital signing. The SKI value is usually part of the X.509 certificate as an *X.509 certificate extension*. Windows Communication Foundation (WCF) has a default *referencing style* that uses the issuer and serial number if the SKI extension is missing from the certificate. If the certificate contains the SKI extension, the default referencing style uses the SKI to point to the certificate. If mid-way through development of an application, you switch from using certificates that do not use the SKI extension to certificates that use the SKI extension, the referencing style used in WCF-generated messages also changes.  
  
 If a consistent referencing style is required regardless of SKI extension presence, it is possible to configure the desired referencing style as shown in the following code.  
  
## Example  

 The following example creates a custom security binding element that uses a single consistent referencing style, the issuer name and serial number.  
  
 [!code-csharp[c_ReferencingCertificatesConsistently#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_referencingcertificatesconsistently/cs/source.cs#1)]
 [!code-vb[c_ReferencingCertificatesConsistently#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_referencingcertificatesconsistently/vb/source.vb#1)]  
  
## Compiling the Code  

 The following namespaces are required to compile the code:  
  
- <xref:System>  
  
- <xref:System.ServiceModel>  
  
- <xref:System.ServiceModel.Channels>  
  
- <xref:System.ServiceModel.Security.Tokens>  
  
## See also

- [Working with Certificates](working-with-certificates.md)
