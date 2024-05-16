---
description: Learn the different ways to obtain an X.509 certificate in Windows Communication Foundation (WCF).
title: "How to: Obtain a Certificate (WCF)"
ms.date: 03/30/2022
helpviewer_keywords: 
  - "certificates [WCF], obtaining"
---
# How to: Obtain a certificate (WCF)

To use any of the Windows Communication Foundation (WCF) features that use X.509 certificates, you must first obtain certificates.  
  
## Obtain an X.509 certificate  
  
Choose one of the following:  
  
- Purchase a certificate from a certification authority, such as VeriSign, Inc.  
  
- Set up your own certificate service and have a certification authority sign the certificates. In Windows Server, use the [Active Directory Certificate Services](/previous-versions/windows/it-pro/windows-server-2012-R2-and-2012/hh831740(v=ws.11)) role to manage a certification authority.  
  
- Set up your own certificate service and do not have the certificates signed.  
  
> [!NOTE]
> Whichever approach you take, the recipient of the SOAP request that contains the X.509 certificate must trust the X.509 certificate. This means that the X.509 certificate or an issuer in the certificate chain is in the Trusted People certificate store, and that the X.509 certificate is not in the Untrusted Certificates store.  
  
## See also

- [Working with Certificates](working-with-certificates.md)
- [How to: Create Temporary Certificates for Use During Development](how-to-create-temporary-certificates-for-use-during-development.md)
