---
title: "Security and the Registry (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "security [Visual Basic], registry"
  - "registry [Visual Basic], security issues"
ms.assetid: 9980aff7-2f69-492b-8f66-29a9a76d3df5
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# Security and the Registry (Visual Basic)
This page discusses the security implications of storing data in the registry.  
  
## Permissions  
 It is not secure to store secrets, such as passwords, in the registry as plain text, even if the registry key is protected by ACLs (access control lists).  
  
 Working with the registry may compromise security by allowing inappropriate access to system resources or protected information. To use these properties, you must have read and write permissions from the <xref:System.Security.Permissions.RegistryPermissionAccess> enumeration, which controls access to registry variables. Any code running with full trust (under the default security policy, this is any code installed on the user's local hard disk) has the necessary permissions to access the registry. For more information, see <xref:System.Security.Permissions.RegistryPermission> class.  
  
 Registry variables should not be stored in memory locations where code without <xref:System.Security.Permissions.RegistryPermission> can access them. Similarly, when granting permissions, grant the minimum privileges necessary to get the job done.  
  
 Registry permission access values are defined by the <xref:System.Security.Permissions.RegistryPermissionAccess> enumeration. The following table details its members.  
  
|Value|Access to Registry Variables|  
|-----------|----------------------------------|  
|`AllAccess`|Create, read, and write|  
|`Create`|Create|  
|`NoAccess`|No access|  
|`Read`|Read|  
|`Write`|Write|  
  
## Checking Values in Registry Keys  
 When you create a registry value, you need to decide what to do if that value already exists. Another process, perhaps a malicious one, may have already created the value and have access to it. When you put data in the registry value, the data is available to the other process. To prevent this, use the `GetValue` method. It returns `Nothing` if the key does not already exist.  
  
> [!IMPORTANT]
>  When reading the registry from a Web application, the identity of current user depends on the authentication and impersonation implemented in the Web application.  
  
## See Also  
 <xref:Microsoft.VisualBasic.MyServices.RegistryProxy>  
 [Reading from and Writing to the Registry](../../../../visual-basic/developing-apps/programming/computer-resources/reading-from-and-writing-to-the-registry.md)
