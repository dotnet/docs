---
title: "Using Impersonation with Transport Security"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 426df8cb-6337-4262-b2c0-b96c2edf21a9
caps.latest.revision: 12
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Using Impersonation with Transport Security
*Impersonation* is the ability of a server application to take on the identity of the client. It is common for services to use impersonation when validating access to resources. The server application runs using a service account, but when the server accepts a client connection, it impersonates the client so that access checks are performed using the client's credentials. Transport security is a mechanism both for passing credentials and securing communication using those credentials. This topic describes using transport security in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] with the impersonation feature. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] impersonation using message security, see [Delegation and Impersonation](../../../../docs/framework/wcf/feature-details/delegation-and-impersonation-with-wcf.md).  
  
## Five Impersonation Levels  
 Transport security makes use of five levels of impersonation, as described in the following table.  
  
|Impersonation level|Description|  
|-------------------------|-----------------|  
|None|The server application does not attempt to impersonate the client.|  
|Anonymous|The server application can perform access checks against the client's credentials, but does not receive any information about the client's identity. This impersonation level is meaningful only for on-machine communication, such as named pipes. Using `Anonymous` with a remote connection promotes the impersonation level to Identify.|  
|Identify|The server application knows the client's identity and can perform access validation against the client's credentials, but cannot impersonate the client. Identify is the default impersonation level used with SSPI credentials in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] unless the token provider provides a different impersonation level.|  
|Impersonate|The server application can access resources on the server machine as the client in addition to performing access checks. The server application cannot access resources on remote machines using the client's identity because the impersonated token does not have network credentials|  
|Delegate|In addition to having the same capabilities as `Impersonate`, the Delegate impersonation level also enables the server application to access resources on remote machines using the client's identity and to pass the identity to other applications.<br /><br /> **Important** The server domain account must be marked as trusted for delegation on the domain controller to use these additional features. This level of impersonation cannot be used with client domain accounts marked as sensitive.|  
  
 The levels most commonly used with transport security are `Identify` and `Impersonate`. The levels `None` and `Anonymous` are not recommended for typical use, and many transports do not support using those levels with authentication. The `Delegate` level is a powerful feature that should be used with care. Only trusted server applications should be given the permission to delegate credentials.  
  
 Using impersonation at the `Impersonate` or `Delegate` levels requires the server application to have the `SeImpersonatePrivilege` privilege. An application has this privilege by default if it is running on an account in the Administrators group or on an account with a Service SID (Network Service, Local Service, or Local System). Impersonation does not require mutual authentication of the client and server. Some authentication schemes that support impersonation, such as NTLM, cannot be used with mutual authentication.  
  
## Transport-Specific Issues with Impersonation  
 The choice of a transport in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] affects the possible choices for impersonation. This section describes issues affecting the standard HTTP and named pipe transports in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. Custom transports have their own restrictions on support for impersonation.  
  
### Named Pipe Transport  
 The following items are used with the named pipe transport:  
  
-   The named pipe transport is intended for use only on the local machine. The named pipe transport in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] explicitly disallows cross-machine connections.  
  
-   Named pipes cannot be used with the `Impersonate` or `Delegate` impersonation level. The named pipe cannot enforce the on-machine guarantee at these impersonation levels.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] named pipes, see [Choosing a Transport](../../../../docs/framework/wcf/feature-details/choosing-a-transport.md).  
  
### HTTP Transport  
 The bindings that use the HTTP transport (<xref:System.ServiceModel.WSHttpBinding> and <xref:System.ServiceModel.BasicHttpBinding>) support several authentication schemes, as explained in [Understanding HTTP Authentication](../../../../docs/framework/wcf/feature-details/understanding-http-authentication.md). The impersonation level supported depends on the authentication scheme. The following items are used with the HTTP transport:  
  
-   The `Anonymous` authentication scheme ignores impersonation.  
  
-   The `Basic` authentication scheme supports only the `Delegate` level. All lower impersonation levels are upgraded.  
  
-   The `Digest` authentication scheme supports only the `Impersonate` and `Delegate` levels.  
  
-   The `NTLM` authentication scheme, selectable either directly or through negotiation, supports only the `Delegate` level on the local machine.  
  
-   The Kerberos authentication scheme, which can only be selected through negotiation, can be used with any supported impersonation level.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the HTTP transport, see [Choosing a Transport](../../../../docs/framework/wcf/feature-details/choosing-a-transport.md).  
  
## See Also  
 [Delegation and Impersonation](../../../../docs/framework/wcf/feature-details/delegation-and-impersonation-with-wcf.md)  
 [Authorization](../../../../docs/framework/wcf/feature-details/authorization-in-wcf.md)  
 [How to: Impersonate a Client on a Service](../../../../docs/framework/wcf/how-to-impersonate-a-client-on-a-service.md)  
 [Understanding HTTP Authentication](../../../../docs/framework/wcf/feature-details/understanding-http-authentication.md)
