---
title: "Understanding HTTP Authentication"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9376309a-39e3-4819-b47b-a73982b57620
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Understanding HTTP Authentication
Authentication is the process of identifying whether a client is eligible to access a resource. The HTTP protocol supports authentication as a means of negotiating access to a secure resource.  
  
 The initial request from a client is typically an anonymous request, not containing any authentication information. HTTP server applications can deny the anonymous request while indicating that authentication is required. The server application sends WWW-Authentication headers to indicate the supported authentication schemes. This document describes several authentication schemes for HTTP and discusses their support in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)].  
  
## HTTP Authentication Schemes  
 The server can specify multiple authentication schemes for the client to choose from. The following table describes some of the authentication schemes commonly found in Windows applications.  
  
|Authentication Scheme|Description|  
|---------------------------|-----------------|  
|Anonymous|An anonymous request does not contain any authentication information. This is equivalent to granting everyone access to the resource.|  
|Basic|Basic authentication sends a Base64-encoded string that contains a user name and password for the client. Base64 is not a form of encryption and should be considered the same as sending the user name and password in clear text. If a resource needs to be protected, strongly consider using an authentication scheme other than basic authentication.|  
|Digest|Digest authentication is a challenge-response scheme that is intended to replace Basic authentication. The server sends a string of random data called a *nonce* to the client as a challenge. The client responds with a hash that includes the user name, password, and nonce, among additional information. The complexity this exchange introduces and the data hashing make it more difficult to steal and reuse the user's credentials with this authentication scheme.<br /><br /> Digest authentication requires the use of Windows domain accounts. The digest *realm* is the Windows domain name. Therefore, you cannot use a server running on an operating system that does not support Windows domains, such as Windows XP Home Edition, with Digest authentication. Conversely, when the client runs on an operating system that does not support Windows domains, a domain account must be explicitly specified during the authentication.|  
|NTLM|NT LAN Manager (NTLM) authentication is a challenge-response scheme that is a securer variation of Digest authentication. NTLM uses Windows credentials to transform the challenge data instead of the unencoded user name and password. NTLM authentication requires multiple exchanges between the client and server. The server and any intervening proxies must support persistent connections to successfully complete the authentication.|  
|Negotiate|Negotiate authentication automatically selects between the Kerberos protocol and NTLM authentication, depending on availability. The Kerberos protocol is used if it is available; otherwise, NTLM is tried. Kerberos authentication significantly improves upon NTLM. Kerberos authentication is both faster than NTLM and allows the use of mutual authentication and delegation of credentials to remote machines.|  
|Windows Live ID|The underlying Windows HTTP service includes authentication using federated protocols. However, the standard HTTP transports in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] do not support the use of federated authentication schemes, such as Microsoft Windows Live ID. Support for this feature is currently available through the use of message security. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Federation and Issued Tokens](../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md).|  
  
## Choosing an Authentication Scheme  
 When selecting the potential authentication schemes for an HTTP server, a few items to consider include the following:  
  
-   Consider whether the resource needs to be protected. Using HTTP authentication requires transmitting more data and can limit interoperability with clients. Allow anonymous access to resources that do not need to be protected.  
  
-   If the resource needs to be protected, consider which authentication schemes provide the required level of security. The weakest standard authentication scheme discussed here is Basic authentication. Basic authentication does not protect the user's credentials. The strongest standard authentication scheme is Negotiate authentication, resulting in the Kerberos protocol.  
  
-   A server should not present (in the WWW-Authentication headers) any scheme that it is not prepared to accept or that does not adequately secure the protected resource. Clients are free to choose between any of the authentication schemes the server presents. Some clients default to a weak authentication scheme or the first authentication scheme in the server's list.  
  
## See Also  
 [Transport Security Overview](../../../../docs/framework/wcf/feature-details/transport-security-overview.md)  
 [Using Impersonation with Transport Security](../../../../docs/framework/wcf/feature-details/using-impersonation-with-transport-security.md)  
 [Delegation and Impersonation](../../../../docs/framework/wcf/feature-details/delegation-and-impersonation-with-wcf.md)
