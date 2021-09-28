---
title: "Using Secure Sockets Layer"
description: Learn about how System.Net and extending classes use the Secure Sockets Layer to encrypt the connection for several network protocols in the .NET Framework.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Networking"
  - "SSL"
  - "Secure Sockets Layer"
  - "requesting data from Internet, Secure Sockets Layer"
  - "sending data, Secure Sockets Layer"
  - "Network Resources"
  - "data requests, Secure Sockets Layer"
  - "receiving data, Secure Sockets Layer"
  - "Internet, Secure Sockets Layer"
ms.assetid: 6e4289e6-d1b7-4e82-ab0d-e83e3b6063ed
---
# Using Secure Sockets Layer

The <xref:System.Net> classes use the Secure Sockets Layer (SSL) to encrypt the connection for several network protocols.  
  
 For http connections, the <xref:System.Net.WebRequest> and <xref:System.Net.WebResponse> classes use SSL to communicate with web hosts that support SSL. The decision to use SSL is made by the <xref:System.Net.WebRequest> class, based on the URI it is given. If the URI begins with "https:", SSL is used; if the URI begins with "http:", an unencrypted connection is used.  
  
 To use SSL with File Transfer Protocol (FTP), set the <xref:System.Net.FtpWebRequest.EnableSsl> property to true prior to calling <xref:System.Net.FtpWebRequest.GetResponse>. Similarly, to use SSL with Simple Mail Transport Protocol (SMTP), set the <xref:System.Net.Mail.SmtpClient.EnableSsl> property to true prior to sending the email.  
  
 The <xref:System.Net.Security.SslStream> class provides a stream-based abstraction for SSL, and offers many ways to configure the SSL handshake.  
  
## Example  
  
### Code  
  
```vb  
Dim MyURI As String = "https://www.contoso.com/"  
Dim Wreq As WebRequest = WebRequest.Create(MyURI)  
  
Dim serverUri As String = "ftp://ftp.contoso.com/file.txt"  
Dim request As FtpWebRequest = CType(WebRequest.Create(serverUri), FtpWebRequest)  
request.Method = WebRequestMethods.Ftp.DeleteFile  
request.EnableSsl = True  
Dim response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)  
```  
  
```csharp  
String MyURI = "https://www.contoso.com/";  
WebRequest WReq = WebRequest.Create(MyURI);  
  
String serverUri = "ftp://ftp.contoso.com/file.txt"  
FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);  
request.EnableSsl = true;  
request.Method = WebRequestMethods.Ftp.DeleteFile;  
FtpWebResponse response = (FtpWebResponse)request.GetResponse();  
```  
  
## Compiling the Code  

 This example requires:  
  
- References to the **System.Net** namespace.  
  
## See also

- [Security in Network Programming](security-in-network-programming.md)
- [Network Programming in the .NET Framework](index.md)
- [Certificate Selection and Validation](certificate-selection-and-validation.md)
