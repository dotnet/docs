---
title: "Internet Authentication"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "authentication [.NET Framework], classes"
  - "IAuthenticationModule interface"
  - "ICredentialLookup interface"
  - "CredentialCache class, about CredentialCache class"
  - "receiving data, authentication"
  - "AuthenticationManager class, about AuthenticationManager class"
  - "Internet, authentication"
  - "sending data, authentication"
  - "network resources, authentication"
  - "user authentication, classes for authentication"
  - "NetworkCredential class, about NetworkCredential class"
  - "client authentication, classes for authentication"
ms.assetid: d342e87c-f672-4660-a513-41a2f2b80c4a
caps.latest.revision: 11
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Internet Authentication
The <xref:System.Net> classes support a variety of client authentication mechanisms, including the standard Internet authentication methods basic, digest, negotiate, NTLM, and Kerberos authentication, as well as custom methods that you can create.  
  
 Authentication credentials are stored in the <xref:System.Net.NetworkCredential> and <xref:System.Net.CredentialCache> classes, which implement the <xref:System.Net.ICredentials> interface. When one of these classes is queried for credentials, it returns an instance of the **NetworkCredential** class. The authentication process is managed by the <xref:System.Net.AuthenticationManager> class, and the actual authentication process is performed by an authentication module class that implements the <xref:System.Net.IAuthenticationModule> interface. You must register a custom authentication module with the **AuthenticationManager** before it can be used; modules for the basic, digest, negotiate, NTLM, and Kerberos authentication methods are registered by default.  
  
 **NetworkCredential** stores a set of credentials associated with a single Internet resource identified by a URI and returns them in response to any call to the <xref:System.Net.NetworkCredential.GetCredential%2A> method. The **NetworkCredential** class is typically used by applications that access a limited number of Internet resources or by applications that use the same set of credentials in all cases.  
  
 The **CredentialCache** class stores a collection of credentials for various Web resources. When the <xref:System.Net.CredentialCache.GetCredential%2A> method is called, **CredentialCache** returns the proper set of credentials, as determined by the URI of the Web resource and the requested authentication scheme. Applications that use a variety of Internet resources with different authentication schemes benefit from using the **CredentialCache** class, since it stores all the credentials and provides them as requested.  
  
 When an Internet resource requests authentication, the <xref:System.Net.WebRequest.GetResponse%2A?displayProperty=nameWithType> method sends the <xref:System.Net.WebRequest> to the **AuthenticationManager** along with the request for credentials. The request is then authenticated according to the following process:  
  
1.  The **AuthenticationManager** calls the <xref:System.Net.IAuthenticationModule.Authenticate%2A> method on each of the registered authentication modules in the order they were registered. The **AuthenticationManager** uses the first module that does not return **null** to carry out the authentication process. The details of the process vary depending on the type of authentication module involved.  
  
2.  When the authentication process is complete, the authentication module returns an <xref:System.Net.Authorization> to the **WebRequest** that contains the information needed to access the Internet resource.  
  
 Some authentication schemes can authenticate a user without first making a request for a resource. An application can save time by preauthenticating the user with the resource, thus eliminating at least one round trip to the server. Or, it can perform authentication during program startup in order to be more responsive to the user later. Authentication schemes that can use preauthentication set the <xref:System.Net.IAuthenticationModule.PreAuthenticate%2A> property to **true**.  
  
## See Also  
 [Basic and Digest Authentication](../../../docs/framework/network-programming/basic-and-digest-authentication.md)  
 [NTLM and Kerberos Authentication](../../../docs/framework/network-programming/ntlm-and-kerberos-authentication.md)  
 [Security in Network Programming](../../../docs/framework/network-programming/security-in-network-programming.md)
