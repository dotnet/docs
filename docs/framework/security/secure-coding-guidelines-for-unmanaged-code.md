---
title: "Secure Coding Guidelines for Unmanaged Code"
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
  - "code security, unmanaged code"
  - "unmanaged code, securing"
  - "security [.NET Framework], unmanaged code"
  - "secure coding, unmanaged code"
ms.assetid: a8d15139-d368-4c9c-a747-ba757781117c
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Secure Coding Guidelines for Unmanaged Code
Some library code needs to call into unmanaged code (for example, native code APIs, such as Win32). Because this means going outside the security perimeter for managed code, due caution is required. If your code is security-neutral, both your code and any code that calls it must have unmanaged code permission (<xref:System.Security.Permissions.SecurityPermission> with the <xref:System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode> flag specified).  
  
 However, it is often unreasonable for your caller to have such powerful permissions. In such cases, your trusted code can be the go-between, similar to the managed wrapper or library code described in [Securing Wrapper Code](../../../docs/framework/misc/securing-wrapper-code.md). If the underlying unmanaged code functionality is totally safe, it can be directly exposed; otherwise, a suitable permission check (demand) is required first.  
  
 When your code calls into unmanaged code but you do not want to require your callers to have permission to access unmanaged code, you must assert that right. An assertion blocks the stack walk at your frame. You must be careful that you do not create a security hole in this process. Usually, this means that you must demand a suitable permission of your callers and then use unmanaged code to perform only what that permission allows and no more. In some cases (for example, a get time-of-day function), unmanaged code can be directly exposed to callers without any security checks. In any case, any code that asserts must take responsibility for security.  
  
 Because any managed code that provides a code path into native code is a potential target for malicious code, determining which unmanaged code can be safely used and how it must be used requires extreme care. Generally, unmanaged code should never be directly exposed to partially trusted callers. There are two primary considerations in evaluating the safety of unmanaged code use in libraries that are callable by partially trusted code:  
  
-   **Functionality**. Does the unmanaged API provide functionality that does not allow callers to perform potentially dangerous operations? Code access security uses permissions to enforce access to resources, so consider whether the API uses files, a user interface, or threading, or whether it exposes protected information. If it does, the managed code wrapping it must demand the necessary permissions before allowing it to be entered. Additionally, while not protected by a permission, memory access must be confined to strict type safety.  
  
-   **Parameter checking**. A common attack passes unexpected parameters to exposed unmanaged code API methods in an attempt to cause them to operate out of specification. Buffer overruns using out-of-range index or offset values are one common example of this type of attack, as are any parameters that might exploit a bug in the underlying code. Thus, even if the unmanaged code API is functionally safe (after necessary demands) for partially trusted callers, managed code must also check parameter validity exhaustively to ensure that no unintended calls are possible from malicious code using the managed code wrapper layer.  
  
## Using SuppressUnmanagedCodeSecurityAttribute  
 There is a performance aspect to asserting and then calling unmanaged code. For every such call, the security system automatically demands unmanaged code permission, resulting in a stack walk each time. If you assert and immediately call unmanaged code, the stack walk can be meaningless: it consists of your assert and your unmanaged code call.  
  
 A custom attribute called <xref:System.Security.SuppressUnmanagedCodeSecurityAttribute> can be applied to unmanaged code entry points to disable the normal security check that demands <xref:System.Security.Permissions.SecurityPermission> with the <xref:System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode> permission specified. Extreme caution must always be taken when doing this, because this action creates an open door into unmanaged code with no runtime security checks. It should be noted that even with **SuppressUnmanagedCodeSecurityAttribute** applied, there is a one-time security check that happens at just-in-time (JIT) compilation to ensure that the immediate caller has permission to call unmanaged code.  
  
 If you use the **SuppressUnmanagedCodeSecurityAttribute**, check the following points:  
  
-   Make the unmanaged code entry point internal or otherwise inaccessible outside your code.  
  
-   Any call into unmanaged code is a potential security hole. Make sure your code is not a portal for malicious code to indirectly call into unmanaged code and avoid a security check. Demand permissions, if appropriate.  
  
-   Use a naming convention to explicitly identify when you are creating a dangerous path into unmanaged code, as described in the section below..  
  
## Naming convention for unmanaged code methods  
 A useful and highly recommended convention has been established for naming unmanaged code methods. All unmanaged code methods are separated into three categories: **safe**, **native**, and **unsafe**. These keywords can be used as class names within which the various kinds of unmanaged code entry points are defined. In source code, these keywords should be added to the class name, as in `Safe.GetTimeOfDay`, `Native.Xyz`, or `Unsafe.DangerousAPI`, for example. Each of these keywords provides useful security information for developers using that class, as described in the following table.  
  
|Keyword|Security considerations|  
|-------------|-----------------------------|  
|**safe**|Completely harmless for any code, even malicious code, to call. Can be used just like other managed code. For example, a function that gets the time of day is typically safe.|  
|**native**|Security-neutral; that is, unmanaged code that requires unmanaged code permission to call. Security is checked, which stops an unauthorized caller.|  
|**unsafe**|Potentially dangerous unmanaged code entry point with security suppressed. Developers should use the greatest caution when using such unmanaged code, making sure that other protections are in place to prevent a security vulnerability. Developers must be responsible, as this keyword overrides the security system.|  
  
## See Also  
 [Secure Coding Guidelines](../../../docs/standard/security/secure-coding-guidelines.md)
