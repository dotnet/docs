---
title: "Security-Transparent Code"
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
  - "transparent code"
  - "security-transparent code"
ms.assetid: 4f3dd841-82f7-4659-aab0-6d2db2166c65
caps.latest.revision: 24
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Security-Transparent Code
<a name="top"></a>
[!INCLUDE[net_security_note](../../../includes/net-security-note-md.md)]  
  
 Security involves three interacting pieces: sandboxing, permissions, and enforcement. Sandboxing refers to the practice of creating isolated domains where some code is treated as fully trusted and other code is restricted to the permissions in the grant set for the sandbox. The application code that runs within the grant set of the sandbox is considered to be transparent; that is, it cannot perform any operations that can affect security. The grant set for the sandbox is determined by evidence (<xref:System.Security.Policy.Evidence> class). Evidence identifies what specific permissions are required by sandboxes, and what kinds of sandboxes can be created. Enforcement refers to allowing transparent code to execute only within its grant set.  
  
> [!IMPORTANT]
>  Security policy was a key element in previous versions of the .NET Framework. Starting with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], security policy is obsolete. The elimination of security policy is separate from security transparency. For information about the effects of this change, see [Code Access Security Policy Compatibility and Migration](../../../docs/framework/misc/code-access-security-policy-compatibility-and-migration.md).  
  
 This topic describes the transparency model in more detail. It contains the following sections:  
  
-   [Purpose of the Transparency Model](#purpose)  
  
-   [Specifying the Transparency Level](#level)  
  
-   [Transparency Enforcement](#enforcement)  
  
<a name="purpose"></a>   
## Purpose of the Transparency Model  
 Transparency is an enforcement mechanism that separates code that runs as part of the application from code that runs as part of the infrastructure. Transparency draws a barrier between code that can do privileged things (critical code), such as calling native code, and code that cannot (transparent code). Transparent code can execute commands within the bounds of the permission set it is operating in, but cannot execute, derive from, or contain critical code.  
  
 The primary goal of transparency enforcement is to provide a simple, effective mechanism for isolating different groups of code based on privilege. Within the context of the sandboxing model, these privilege groups are either fully trusted (that is, not restricted) or partially trusted (that is, restricted to the permission set granted to the sandbox).  
  
> [!IMPORTANT]
>  The transparency model transcends code access security. Transparency is enforced by the just-in-time compiler and remains in effect regardless of the grant set for an assembly, including full trust.  
  
 Transparency was introduced in the .NET Framework version 2.0 to simplify the security model, and to make it easier to write and deploy secure libraries and applications. Transparent code is also used in Microsoft Silverlight, to simplify the development of partially trusted applications.  
  
> [!NOTE]
>  When you develop a partially trusted application, you have to be aware of the permission requirements for your target hosts. You can develop an application that uses resources that are not allowed by some hosts. This application will compile without error, but will fail when it is loaded into the hosted environment. If you have developed your application using Visual Studio, you can enable debugging in partial trust or in a restricted permission set from the development environment. For more information, see [How to: Debug a ClickOnce Application with Restricted Permissions](/visualstudio/deployment/how-to-debug-a-clickonce-application-with-restricted-permissions). The Calculate Permissions feature provided for ClickOnce applications is also available for any partially trusted application.  
  
 [Back to top](#top)  
  
<a name="level"></a>   
## Specifying the Transparency Level  
 The assembly-level <xref:System.Security.SecurityRulesAttribute> attribute explicitly selects the <xref:System.Security.SecurityRuleSet> rules that the assembly will follow. The rules are organized under a numeric level system, where higher levels mean tighter enforcement of security rules.  
  
 The levels are as follows:  
  
-   Level 2 (<xref:System.Security.SecurityRuleSet.Level2>) – the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] transparency rules.  
  
-   Level 1 (<xref:System.Security.SecurityRuleSet.Level1>) – the .NET Framework 2.0 transparency rules.  
  
 The primary difference between the two transparency levels is that level 1 does not enforce transparency rules for calls from outside the assembly and is intended only for compatibility.  
  
> [!IMPORTANT]
>  You should specify level 1 transparency for compatibility only; that is, specify level 1 only for code that was developed with the .NET Framework 3.5 or earlier that uses the <xref:System.Security.AllowPartiallyTrustedCallersAttribute> attribute or does not use the transparency model. For example, use level 1 transparency for .NET Framework 2.0 assemblies that allow calls from partially trusted callers (APTCA). For code that is developed for the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], always use level 2 transparency.  
  
### Level 2 Transparency  
 Level 2 transparency was introduced in the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)]. The three tenets of this model are transparent code, security-safe-critical code, and security-critical code.  
  
-   Transparent code, regardless of the permissions it is granted (including full trust), can call only other transparent code or security-safe-critical code. If the code is partially trusted, it can only perform actions that are allowed by the domain’s permission set. Transparent code cannot do the following:  
  
    -   Perform an <xref:System.Security.CodeAccessPermission.Assert%2A> operation or elevation of privilege.  
  
    -   Contain unsafe or unverifiable code.  
  
    -   Directly call critical code.  
  
    -   Call native code or code that has the <xref:System.Security.SuppressUnmanagedCodeSecurityAttribute> attribute.  
  
    -   Call a member that is protected by a <xref:System.Security.Permissions.SecurityAction.LinkDemand>.  
  
    -   Inherit from critical types.  
  
     In addition, transparent methods cannot override critical virtual methods or implement critical interface methods.  
  
-   Security-safe-critical code is fully trusted but is callable by transparent code. It exposes a limited surface area of full-trust code. Correctness and security verifications happen in safe-critical code.  
  
-   Security-critical code can call any code and is fully trusted, but it cannot be called by transparent code.  
  
### Level 1 Transparency  
 The level 1 transparency model was introduced in the .NET Framework version 2.0 to enable developers to reduce the amount of code that is subject to a security audit. Although level 1 transparency was publicly available in version 2.0, it was primarily used only within Microsoft for security auditing purposes. Through annotations, developers are able to declare which types and members can perform security elevations and other trusted actions (security-critical) and which cannot (security-transparent). Code that is identified as transparent does not require a high degree of security auditing. Level 1 transparency states that the transparency enforcement is limited to within the assembly. In other words, any public types or members that are identified as security-critical are security-critical only within the assembly. If you want to enforce security for those types and members when they are called from outside the assembly, you must use link demands for full trust. If you do not, publicly visible security-critical types and members are treated as security-safe-critical and can be called by partially trusted code outside the assembly.  
  
 The level 1 transparency model has the following limitations:  
  
-   Security-critical types and members that are public are accessible from security-transparent code.  
  
-   The transparency annotations are enforced only within an assembly.  
  
-   Security-critical types and members must use link demands to enforce security for calls from outside the assembly.  
  
-   Inheritance rules are not enforced.  
  
-   The potential exists for transparent code to do harmful things when run in full trust.  
  
 [Back to top](#top)  
  
<a name="enforcement"></a>   
## Transparency Enforcement  
 Transparency rules are not enforced until transparency is calculated. At that time, an <xref:System.InvalidOperationException> is thrown if a transparency rule is violated. The time that transparency is calculated depends on multiple factors and cannot be predicted. It is calculated as late as possible. In the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], assembly-level transparency calculation occurs sooner than it does in the .NET Framework 2.0. The only guarantee is that transparency calculation will occur by the time it is needed. This is similar to how the just-in-time (JIT) compiler can change the point when a method is compiled and any errors in that method are detected. Transparency calculation is invisible if your code does not have any transparency errors.  
  
## See Also  
 [Security-Transparent Code, Level 1](../../../docs/framework/misc/security-transparent-code-level-1.md)  
 [Security-Transparent Code, Level 2](../../../docs/framework/misc/security-transparent-code-level-2.md)
