---
title: "How to: Retrieve the Thumbprint of a Certificate"
description: Learn how to specify claims found in an X.509 certificate, which is necessary when developing a WCF application that uses certificates for authentication.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "certificates [WCF], retrieving thumbprint"
ms.assetid: da3101aa-78cd-4c34-9652-d1f24777eeab
---
# How to: Retrieve the Thumbprint of a Certificate

When writing a Windows Communication Foundation (WCF) application that uses an X.509 certificate for authentication, it is often necessary to specify claims found in the certificate. For example, you must supply a thumbprint claim when using the <xref:System.Security.Cryptography.X509Certificates.X509FindType.FindByThumbprint> enumeration in the <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential.SetCertificate%2A> method. Finding the claim value requires two steps. First, open the Microsoft Management Console (MMC) snap-in for certificates. (See [How to: View Certificates with the MMC Snap-in](how-to-view-certificates-with-the-mmc-snap-in.md).) Second, as described here, find an appropriate certificate and copy its thumbprint (or other claim values).  
  
 If you are using a certificate for service authentication, it is important to note the value of the **Issued To** column (the first column in the console). When using Secure Sockets Layer (SSL) as a transport security, one of the first checks done is to compare the base address Uniform Resource Identifier (URI) of a service to the **Issued To** value. The values must match or the authentication process is halted.  
  
 You can also use the PowerShell New-SelfSignedCertificate cmdlet to create temporary certificates for use only during development. By default, however, such a certificate is not issued by a certification authority and is unusable for production purposes. For more information, see [How to: Create Temporary Certificates for Use During Development](how-to-create-temporary-certificates-for-use-during-development.md).  
  
### To retrieve a certificate's thumbprint  
  
1. Open the Microsoft Management Console (MMC) snap-in for certificates. (See [How to: View Certificates with the MMC Snap-in](how-to-view-certificates-with-the-mmc-snap-in.md).)  
  
2. In the **Console Root** window's left pane, click **Certificates (Local Computer)**.  
  
3. Click the **Personal** folder to expand it.  
  
4. Click the **Certificates** folder to expand it.  
  
5. In the list of certificates, note the **Intended Purposes** heading. Find a certificate that lists **Client Authentication** as an intended purpose.  
  
6. Double-click the certificate.  
  
7. In the **Certificate** dialog box, click the **Details** tab.  
  
8. Scroll through the list of fields and click **Thumbprint**.  
  
9. Copy the hexadecimal characters from the box. If this thumbprint is used in code for the `X509FindType`, remove the spaces between the hexadecimal numbers. For example, the thumbprint "a9 09 50 2d d8 2a e4 14 33 e6 f8 38 86 b0 0d 42 77 a3 2a 7b" should be specified as "a909502dd82ae41433e6f83886b00d4277a32a7b" in code.  
  
## See also

- <xref:System.Security.Cryptography.X509Certificates.X509FindType.FindByThumbprint>
- <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential.SetCertificate%2A>
- [How to: Configure a Port with an SSL Certificate](how-to-configure-a-port-with-an-ssl-certificate.md)
- [How to: View Certificates with the MMC Snap-in](how-to-view-certificates-with-the-mmc-snap-in.md)
- [How to: Create Temporary Certificates for Use During Development](how-to-create-temporary-certificates-for-use-during-development.md)
