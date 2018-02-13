---
title: "Windows Forms Security"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "designer access security [Windows Forms]"
  - "permissions [Windows Forms], Windows Forms"
  - "Windows Forms, security"
  - "security [Windows Forms]"
  - "access control [Windows Forms], Windows Forms"
  - "security policy [Windows Forms], Windows Forms"
ms.assetid: 932d438a-5285-46d8-a958-8c93d0ad6cae
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Windows Forms Security
Windows Forms features a security model that is code-based (security levels are set for code, regardless of the user running the code). This is in addition to any security schemas that may be in place already on your computer system. These can include those in the browser (such as the zone-based security available in Internet Explorer) or the operating system (such as the credential-based security of Windows NT).  
  
## In This Section  
 [Security in Windows Forms Overview](../../../docs/framework/winforms/security-in-windows-forms-overview.md)  
 Briefly explains the .NET Framework security model and the basic steps necessary to ensure the Windows Forms in your application are secure.  
  
 [More Secure File and Data Access in Windows Forms](../../../docs/framework/winforms/more-secure-file-and-data-access-in-windows-forms.md)  
 Describes how to access files and data in a semi-trusted environment.  
  
 [More Secure Printing in Windows Forms](../../../docs/framework/winforms/more-secure-printing-in-windows-forms.md)  
 Describes how to access printing features in a semi-trusted environment.  
  
 [Additional Security Considerations in Windows Forms](../../../docs/framework/winforms/additional-security-considerations-in-windows-forms.md)  
 Describes performing window manipulation, using the Clipboard, and making calls to unmanaged code in a semi-trusted environment.  
  
## Related Sections  
 [NIB: Default Security Policy](http://msdn.microsoft.com/library/2c086873-0894-4f4d-8f7e-47427c1a3b55)  
 Lists the default permissions granted in the Full Trust, Local Intranet, and Internet permission sets.  
  
 [NIB: General Security Policy Administration](http://msdn.microsoft.com/library/5121fe35-f0e3-402c-94ab-4f35b0a87b4b)  
 Gives information about the administering the .NET Framework security policy and elevating permissions.  
  
 [Dangerous Permissions and Policy Administration](../../../docs/framework/misc/dangerous-permissions-and-policy-administration.md)  
 Discusses some of the.NET Framework permissions that can potentially allow the security system to be circumvented.  
  
 [Secure Coding Guidelines](../../../docs/standard/security/secure-coding-guidelines.md)  
 Links to topics that explain the best practices for securely writing code against the .NET Framework.  
  
 [NIB: Requesting Permissions](http://msdn.microsoft.com/library/0447c49d-8cba-45e4-862c-ff0b59bebdc2)  
 Discusses the use of attributes to let the runtime know what permissions your code needs to run.  
  
 [Key Security Concepts](../../../docs/standard/security/key-security-concepts.md)  
 Links to topics that cover the basic aspects of code security.  
  
 [Code Access Security Basics](../../../docs/framework/misc/code-access-security-basics.md)  
 Discusses the basics of working with the .NET Framework run time security policy.  
  
 [NIB: Determining When to Modify Security Policy](http://msdn.microsoft.com/library/af749b17-e461-409d-84b9-a3d44789db16)  
 Explains how to determine when your applications need to diverge from the default security policy.  
  
 [NIB: Deploying Security Policy](http://msdn.microsoft.com/library/f936c1e5-033b-4bd9-a3bd-a39ba733a681)  
 Discusses the best manner for deploying security policy changes.
