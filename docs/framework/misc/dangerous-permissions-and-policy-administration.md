---
title: "Dangerous Permissions and Policy Administration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "permissions [.NET Framework], policy administration"
  - "security [.NET Framework], dangerous permissions"
  - "code security, dangerous permissions"
  - "secure coding, dangerous permissions"
  - "permissions [.NET Framework], dangerous"
ms.assetid: 1929e854-23a0-4bb1-94be-e8aa3b609e32
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Dangerous Permissions and Policy Administration
Several of the protected operations for which the .NET Framework provides permissions can potentially allow the security system to be circumvented. These dangerous permissions should be given only to trustworthy code, and then only as necessary. There is usually no defense against malicious code if it is granted these permissions.  
  
> [!NOTE]
>  In the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], there have been important changes to the .NET Framework security model and terminology. For more information about these changes, see [Security Changes](../../../docs/framework/security/security-changes.md).  
  
 The dangerous permissions are explained in the following table.  
  
|Permission|Potential risk|  
|----------------|--------------------|  
|<xref:System.Security.Permissions.SecurityPermission>||  
|<xref:System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode>|Allows managed code to call into unmanaged code, which is often dangerous.|  
|<xref:System.Security.Permissions.SecurityPermissionFlag.SkipVerification>|Without verification, the code can do anything.|  
|<xref:System.Security.Permissions.SecurityPermissionFlag.ControlEvidence>|Invalidated evidence can fool security policy.|  
|<xref:System.Security.Permissions.SecurityPermissionFlag.ControlPolicy>|The ability to modify security policy can disable security.|  
|<xref:System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter>|The use of serialization can circumvent accessibility mechanisms. For details, see [Security and Serialization](../../../docs/framework/misc/security-and-serialization.md).|  
|<xref:System.Security.Permissions.SecurityPermissionFlag.ControlPrincipal>|The ability to set the current principal can trick role-based security.|  
|<xref:System.Security.Permissions.SecurityPermissionFlag.ControlThread>|Manipulation of threads is dangerous because of the security state associated with threads.|  
|<xref:System.Security.Permissions.ReflectionPermission>||  
|<xref:System.MemberAccessException>|Can use private members to defeat accessibility mechanisms.|  
  
## See Also  
 [Secure Coding Guidelines](../../../docs/standard/security/secure-coding-guidelines.md)
