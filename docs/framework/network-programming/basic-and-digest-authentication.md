---
title: "Basic and Digest Authentication"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
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
ms.assetid: 8cce2742-8d52-4643-9dd2-64ddf38aa878
caps.latest.revision: 11
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Basic and Digest Authentication
The <xref:System.Net> implementation of basic and digest authentication complies with RFC2617 – HTTP Authentication: Basic and Digest Authentication (available on the World Wide Web Consortium's Web site at www.w3.org).  
  
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
>  Data sent with Basic and Digest Authentication is not encrypted, so the data can be seen by an adversary. Additionally, Basic Authentication credentials (user name and password) are sent in the clear and can be intercepted.  
  
## See Also  
 [NTLM and Kerberos Authentication](../../../docs/framework/network-programming/ntlm-and-kerberos-authentication.md)  
 [Internet Authentication](../../../docs/framework/network-programming/internet-authentication.md)
