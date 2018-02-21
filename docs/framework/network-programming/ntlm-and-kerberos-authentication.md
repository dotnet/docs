---
title: "NTLM and Kerberos Authentication"
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
  - "authentication [.NET Framework], NTLM"
  - "authentication [.NET Framework], Kerberos"
  - "user authentication, Kerberos"
  - "user authentication, NTLM"
  - "Kerberos authentication"
  - "receiving data, authentication"
  - "NTLM authentication"
  - "Internet, authentication"
  - "client authentication, Kerberos"
  - "sending data, authentication"
  - "network resources, authentication"
  - "classes [.NET Framework], authentication"
  - "client authentication, NTLM"
ms.assetid: 9ef65560-f596-4469-bcce-f4d5407b55cd
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# NTLM and Kerberos Authentication
Default NTLM authentication and Kerberos authentication use the Microsoft Windows NT user credentials associated with the calling application to attempt authentication with the server. When using non-default NTLM authentication, the application sets the authentication type to NTLM and uses a <xref:System.Net.NetworkCredential> object to pass the user name, password, and domain to the host, as shown in the following example.  
  
```vb  
Dim MyURI As String = "http://www.contoso.com/"  
Dim WReq As WebRequest = WebRequest.Create(MyURI)  
WReq.Credentials = _  
    New NetworkCredential(UserName, SecurelyStoredPassword, Domain)  
```  
  
```csharp  
String MyURI = "http://www.contoso.com/";  
WebRequest WReq = WebRequest.Create (MyURI);  
WReq.Credentials =   
    new NetworkCredential(UserName, SecurelyStoredPassword, Domain);  
```  
  
 Applications that need to connect to Internet services using the credentials of the application user can do so with the user's default credentials, as shown in the following example.  
  
```vb  
Dim MyURI As String = "http://www.contoso.com/"  
Dim WReq As WebRequest = WebRequest.Create(MyURI)  
WReq.Credentials = CredentialCache.DefaultCredentials  
```  
  
```csharp  
String MyURI = "http://www.contoso.com/";  
WebRequest WReq = WebRequest.Create (MyURI);  
WReq.Credentials = CredentialCache.DefaultCredentials;  
```  
  
 The negotiate authentication module determines whether the remote server is using NTLM or Kerberos authentication, and sends the appropriate response.  
  
> [!NOTE]
>  NTLM authentication does not work through a proxy server.  
  
## See Also  
 [Basic and Digest Authentication](../../../docs/framework/network-programming/basic-and-digest-authentication.md)  
 [Internet Authentication](../../../docs/framework/network-programming/internet-authentication.md)
