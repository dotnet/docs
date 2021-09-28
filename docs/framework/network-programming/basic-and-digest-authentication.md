---
title: "Basic and Digest Authentication"
description: Learn to use basic and digest authentication, where an application provides a user name and password in the WebRequest object that it uses to request data.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "authentication [.NET Framework], classes"
  - "Basic authentication"
  - "authentication [.NET Framework], basic"
  - "client authentication, basic"
  - "user authentication, basic"
  - "authentication [.NET Framework], digest"
  - "receiving data, authentication"
  - "client authentication, digest"
  - "Internet, authentication"
  - "digest authentication"
  - "sending data, authentication"
  - "network resources, authentication"
  - "user authentication, digest"
ms.topic: how-to
---
# Basic and Digest Authentication

The <xref:System.Net> implementation of basic and digest authentication complies with RFC2617 – HTTP Authentication: Basic and Digest Authentication (available on the [World Wide Web Consortium's](https://www.w3.org) website).  
  
 To use basic and digest authentication, an application must provide a user name and password in the <xref:System.Net.WebRequest.Credentials%2A> property of the <xref:System.Net.WebRequest> object that it uses to request data from the Internet, as shown in the following example.  
  
```vb  
Dim MyURI As String = "http://www.contoso.com/"  
Dim WReq As WebRequest = WebRequest.Create(MyURI)  
WReq.Credentials = New NetworkCredential(UserName, SecurelyStoredPassword)  
```  
  
```csharp  
String MyURI = "http://www.contoso.com/";  
WebRequest WReq = WebRequest.Create(MyURI);  
WReq.Credentials = new NetworkCredential(UserName, SecurelyStoredPassword);  
```  
  
> [!CAUTION]
> Data sent with Basic and Digest Authentication is not encrypted, so the data can be seen by an adversary. Additionally, Basic Authentication credentials (user name and password) are sent in the clear and can be intercepted.  
  
## See also

- [NTLM and Kerberos Authentication](ntlm-and-kerberos-authentication.md)
- [Internet Authentication](internet-authentication.md)
