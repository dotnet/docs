---
title: "System.Security namespaces 1 | Microsoft Docs"
ms.custom: ""
ms.date: "12/16/2016"
ms.prod: "windows-client-threshold"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - ".net-for-windows-store-apps"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 17ed08be-2ff5-4517-aeb0-f230d1cb8118
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# System.Security namespaces 1
The `System.Security` and `System.Security.Principal` namespaces contain classes that represent the .NET Framework security system and permissions.  
  
 This topic displays the types in the `System.Security` and `System.Security.Principal` namespaces that are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]. Note that the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)].  
  
## System.Security namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Security.AllowPartiallyTrustedCallersAttribute>|Allows an assembly to be called by partially trusted code. Without this declaration, only fully trusted callers are able to use the assembly. This class cannot be inherited.|  
|<xref:System.Security.SecurityCriticalAttribute>|Specifies that code or an assembly performs security-critical operations.|  
|<xref:System.Security.SecurityException>|The exception that is thrown when a security error is detected.|  
|<xref:System.Security.SecuritySafeCriticalAttribute>|Identifies types or members as security-critical and safely accessible by transparent code.|  
|<xref:System.Security.SecurityTransparentAttribute>|Specifies that an assembly cannot cause an elevation of privilege.|  
|<xref:System.Security.VerificationException>|The exception that is thrown when the security policy requires code to be type safe and the verification process is unable to verify that the code is type safe.|  
  
## System.Security.Principal namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Security.Principal.IIdentity>|Defines the basic functionality of an identity object.|  
|<xref:System.Security.Principal.IPrincipal>|Defines the basic functionality of a principal object.|  
|<xref:System.Security.Principal.TokenImpersonationLevel>|Defines security impersonation levels. Security impersonation levels govern the degree to which a server process can act on behalf of a client process.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)