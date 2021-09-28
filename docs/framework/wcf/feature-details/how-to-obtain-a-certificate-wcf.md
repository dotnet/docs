---
description: "Learn more about: How to: Obtain a Certificate (WCF)"
title: "How to: Obtain a Certificate (WCF)"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "certificates [WCF], obtaining"
ms.assetid: d53762fd-15ea-42dc-b0ea-6a6597aa23f7
---
# How to: Obtain a Certificate (WCF)

To use any of the Windows Communication Foundation (WCF) features of that use X.509 certificates, you just first obtain certificates.  
  
## Obtain an X.509 certificate  
  
Choose one of the following:  
  
- Purchase a certificate from a certification authority, such as VeriSign, Inc.  
  
- Set up your own certificate service and have a certification authority sign the certificates. Windows Server 2003, Windows 2000 Server, Windows 2000 Server Datacenter, and Windows 2000 Datacenter Server all include certificate services that support public key infrastructure (PKI). In Windows Server 2008, use the [Active Directory Certificate Services](/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/cc731564(v=ws.10)) role to manage a certification authority.  
  
- Set up your own certificate service and do not have the certificates signed.  
  
> [!NOTE]
> Whichever approach you take, the recipient of the SOAP request that contains the X.509 certificate must trust the X.509 certificate. This means that the X.509 certificate or an issuer in the certificate chain is in the Trusted People certificate store and that the X.509 certificate is not in the Untrusted Certificates store.  
  
## See also

- [Working with Certificates](working-with-certificates.md)
- [How to: Create Temporary Certificates for Use During Development](how-to-create-temporary-certificates-for-use-during-development.md)
