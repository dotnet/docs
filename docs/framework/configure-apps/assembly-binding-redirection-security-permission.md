---
title: "Assembly Binding Redirection Security Permission"
description: Learn about the security permission required for explicit assembly binding redirection in an application configuration file in .NET.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "side-by-side execution, assembly binding redirection"
  - "assemblies [.NET Framework], binding redirection"
ms.assetid: 24a5cdff-7ed9-4195-93f3-edf6899019fc
---
# Assembly Binding Redirection Security Permission

Explicit assembly binding redirection in an application configuration file requires a security permission. This applies to redirection of .NET Framework assemblies and assemblies from third parties. The permission is granted by setting the <xref:System.Security.Permissions.SecurityPermissionFlag> flag on the <xref:System.Security.Permissions.SecurityPermission>. Managed assemblies have no permissions by default.  
  
 The security permission is granted to applications running in the Trusted Zone (local machine) and Intranet Zone. Applications running in the Internet Zone are strictly prohibited from performing assembly binding redirection.  
  
 The permission is not required if assembly redirection is performed in a publisher policy file that is controlled by the component publisher, or in the machine configuration file that is controlled by the administrator. However, the permission is required for an application to explicitly ignore publisher policy using the [\<publisherPolicy apply="no"/>](./file-schema/runtime/publisherpolicy-element.md) element in the application configuration file.  
  
 The following table shows the default security settings for the **BindingRedirects** flag.  
  
|Zone|BindingRedirects flag setting|  
|----------|-----------------------------------|  
|Trusted Zone (local machine)|**ON**|  
|Intranet Zone|**ON**|  
|Internet Zone|**OFF**|  
|Untrusted zones|**OFF**|  
  
 An administrator can change these security settings to support or restrict specific scenarios on a given computer. There are no tools for changing the **BindingRedirects** flag setting from the default; an administrator must manually edit the Security.config file on a user's computer.  
  
## See also

- [Publisher Policy Files and Side-by-Side Execution](/previous-versions/dotnet/netframework-4.0/06d2bae3(v=vs.100))
- [How to: Enable and Disable Automatic Binding Redirection](how-to-enable-and-disable-automatic-binding-redirection.md)
- [Side-by-Side Execution](../deployment/side-by-side-execution.md)
