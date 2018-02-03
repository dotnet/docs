---
title: "Certificate Selection and Validation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c933aca2-4cd0-4ff1-9df9-267143f25a6f
caps.latest.revision: 15
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Certificate Selection and Validation
The <xref:System.Net> classes support several ways to select and validate <xref:System.Security.Cryptography.X509Certificates> for Secure Socket Layer (SSL) connections. A client can select one or more certificates to authenticate itself to a server. A server can require that a client certificate have one or more specific attributes for authentication.  
  
## Definition  
 A certificate is an ASCII byte stream that contains a public key, attributes (such as version number, serial number, and expiration date) and a digital signature from a Certificate Authority. Certificates are used to establish an encrypted connection or to authenticate a client to a server.  
  
## Client Certificate Selection and Validation  
 A client can select one or more certificates for a specific SSL connection. Client certificates can be associated with the SSL connection to a web server or an SMTP mail server. A client adds certificates to a collection of <xref:System.Security.Cryptography.X509Certificates.X509Certificate> or <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> class objects. Using email as an example, the certificate collection is an instance of a <xref:System.Security.Cryptography.X509Certificates.X509CertificateCollection>) associated with the <xref:System.Net.Mail.SmtpClient.ClientCertificates%2A> property of the <xref:System.Net.Mail.SmtpClient> class. The <xref:System.Net.HttpWebRequest> class has a similar <xref:System.Net.HttpWebRequest.ClientCertificates%2A> property.  
  
 The primary difference between the <xref:System.Security.Cryptography.X509Certificates.X509Certificate> and the <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> class is that the private key must reside in the certificate store for the <xref:System.Security.Cryptography.X509Certificates.X509Certificate> class.  
  
 Even if certificates are added to a collection and associated with a specific SSL connection, no certificates will be sent to the server unless the server requests them. If multiple client certificates are set on a connection, the best one will be used based on an algorithm that considers the match between the list of certificate issuers provided by the server and the client certificate issuer name.  
  
 The <xref:System.Net.Security.SslStream> class provides even more control over the SSL handshake. A client can specify a delegate to pick which client certificate to use.  
  
 A remote server can verify that a client certificate is valid, current, and signed by the appropriate Certificate Authority. A delegate can be added to the <xref:System.Net.ServicePointManager.ServerCertificateValidationCallback%2A> to enforce certificate validation.  
  
## Client Certificate Selection  
 The .NET Framework selects the client certificate to present to the server in the following manner:  
  
1.  If a client certificate was presented previously to the server, the certificate is cached when first presented and is reused for subsequent client certificate requests.  
  
2.  If a delegate is present, always use the result from the delegate as the client certificate to select. Try to use a cached certificate when possible, but do not use cached anonymous credentials if the delegate has returned null and the certificate collection is not empty.  
  
3.  If this is the first challenge for a client certificate, the Framework enumerates the certificates in <xref:System.Security.Cryptography.X509Certificates.X509Certificate> or the <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> class objects associated with the connection, looking for a match between the list of certificate issuers provided by the server and the client certificate issuer name. The first certificate that matches is sent to the server. If no certificate matches or the certificate collection is empty, then an anonymous credential is sent to the server.  
  
## Tools for Certificate Configuration  
 A number of tools are available for client and server certificate configuration.  
  
 The *Winhttpcertcfg.exe* tool can be used to configure client certificates. The *Winhttpcertcfg.exe* tool is provided as one of the tools with the Windows Server 2003 Resource Kit. This tool is also available as a download as part of the Windows Server 2003 Resource Kit Tools at www.microsoft.com.  
  
 *The HttpCfg.exe* tool can be used to configure server certificates for the <xref:System.Net.HttpListener> class. The *HttpCfg.exe* tool is provided as one of the support tools for Windows Server 2003 and Windows XP Service Pack 2. *HttpCfg.exe* and the other support tools are not installed by default on either Windows Server 2003 or Windows XP. On Windows Server 2003. the support tools are installed separately from the following folder and file on the Windows Server 2003 CD-ROM:  
  
 \Support\Tools\Suptools.msi  
  
 For use with Windows XP Service Pack 2, the Windows XP Support Tools are available as a download from www.microsoft.com.  
  
 The source code to a version of the *HttpCfg.exe* tool is also provided as a sample with the Windows Server SDK. The source code to the *HttpCfg.exe* sample is installed by default with the networking samples as part of the Windows SDK under the following folder:  
  
 *C:\Program Files\Microsoft SDKs\Windows\v1.0\Samples\NetDS\http\serviceconfig*  
  
 In addition to these tools, the <xref:System.Security.Cryptography.X509Certificates.X509Certificate> and <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> classes provides methods for loading a certificate from the file system.  
  
## See Also  
 [Security in Network Programming](../../../docs/framework/network-programming/security-in-network-programming.md)  
 [Network Programming in the .NET Framework](../../../docs/framework/network-programming/index.md)
