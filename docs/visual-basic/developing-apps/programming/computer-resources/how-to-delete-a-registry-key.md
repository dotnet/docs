---
title: "How to: Delete a Registry Key in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.DeleteSetting"
helpviewer_keywords: 
  - "GetSetting function [Visual Basic]"
  - "registry [Visual Basic], deleting values"
  - "GetAllSettings function"
  - "registry keys [Visual Basic], deleting"
  - "registry [Visual Basic], deleting keys"
  - "examples [Visual Basic], registry"
ms.assetid: ab9aca0e-42b0-4ff7-8ff9-845a4bfdf9f2
caps.latest.revision: 28
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Delete a Registry Key in Visual Basic
The <xref:Microsoft.Win32.RegistryKey.DeleteSubKey%28System.String%29> and <xref:Microsoft.Win32.RegistryKey.DeleteSubKey%28System.String%2CSystem.Boolean%29> methods can be used to delete registry keys.  
  
## Procedure  
  
#### To delete a registry key  
  
-   Use the `DeleteSubKey` method to delete a registry key. This example deletes the key Software/TestApp in the CurrentUser hive. You can change this in the code to the appropriate string, or have it rely on user-supplied information.  
  
     [!code-vb[VbResourceTasks#19](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/how-to-delete-a-registry-key_1.vb)]  
  
## Robust Programming  
 The `DeleteSubKey` method returns an empty string if the key/value pair does not exist.  
  
 The following conditions may cause an exception:  
  
-   The name of the key is `Nothing` (<xref:System.ArgumentNullException>).  
  
-   The user does not have permissions to delete registry keys (<xref:System.Security.SecurityException>).  
  
-   The key name exceeds the 255-character limit (<xref:System.ArgumentException>).  
  
-   The registry key is read-only (<xref:System.UnauthorizedAccessException>).  
  
## .NET Framework Security  
 Registry calls fail if either sufficient run-time permissions are not granted (<xref:System.Security.Permissions.RegistryPermission>) or if the user does not have the correct access (as determined by the ACLs) for creating or writing to settings. For example, a local application that has the code access security permission might not have operating system permission.  
  
## See Also  
 <xref:Microsoft.Win32.RegistryKey.DeleteSubKey%2A>  
 <xref:Microsoft.Win32.RegistryKey.DeleteSubKey%2A>  
 <xref:Microsoft.Win32.RegistryKey>  
 [Security and the Registry](../../../../visual-basic/developing-apps/programming/computer-resources/security-and-the-registry.md)  
 [Reading from and Writing to the Registry](../../../../visual-basic/developing-apps/programming/computer-resources/reading-from-and-writing-to-the-registry.md)
