---
title: "How to: Create a Registry Key and Set Its Value in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "RegistryKey.CreateSubKey"
  - "RegistryKey.SetValue"
helpviewer_keywords: 
  - "registry keys [Visual Basic], creating"
  - "registry [Visual Basic], adding values"
  - "registry [Visual Basic], adding keys"
  - "registry keys [Visual Basic], setting values"
  - "examples [Visual Basic], registry"
ms.assetid: d3e40f74-c283-480c-ab18-e5e9052cd814
caps.latest.revision: 30
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Create a Registry Key and Set Its Value in Visual Basic
The `CreateSubKey` method of the `My.Computer.Registry` object can be used to create a registry key.  
  
## Procedure  
  
#### To create a registry key  
  
-   Use the `CreateSubKey` method, specifying which hive to place the key under as well as the name of the key. The parameter `Subkey` is not case-sensitive. This example creates the registry key `MyTestKey` under HKEY_CURRENT_USER.  
  
     [!code-vb[VbResourceTasks#17](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/how-to-create-a-registry-key-and-set-its-value_1.vb)]  
  
#### To create a registry key and set a value in it  
  
1.  Use the `CreateSubkey` method, specifying which hive to place the key under as well as the name of the key. This example creates the registry key `MyTestKey` under HKEY_CURRENT_USER.  
  
     [!code-vb[VbResourceTasks#17](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/how-to-create-a-registry-key-and-set-its-value_1.vb)]  
  
2.  Set the value with the `SetValue` method. This example sets the string value. "MyTestKeyValue" to "This is a test value".  
  
     [!code-vb[VbResourceTasks#14](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/how-to-create-a-registry-key-and-set-its-value_2.vb)]  
  
## Example  
 This example creates the registry key `MyTestKey` under HKEY_CURRENT_USER and then sets the string value `MyTestKeyValue` to `This is a test value`.  
  
 [!code-vb[VbResourceTasks#15](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/how-to-create-a-registry-key-and-set-its-value_3.vb)]  
  
## Robust Programming  
 Examine the registry structure to find a suitable location for your key. For example, you may want to open the HKEY_CURRENT_USER\Software key of the current user, and create a key with your company's name. Then add the registry values to your company's key.  
  
 When reading the registry from a Web application, the current user depends on the authentication and impersonation implemented in the Web application.  
  
 It is more secure to write data to the user folder (<xref:Microsoft.Win32.Registry.CurrentUser>) rather than to the local computer (<xref:Microsoft.Win32.Registry.LocalMachine>).  
  
 When you create a registry value, you need to decide what to do if that value already exists. Another process, perhaps a malicious one, may have already created the value and have access to it. When you put data in the registry value, the data is available to the other process. To prevent this, use the <xref:Microsoft.Win32.RegistryKey.GetValue%2A> method. It returns `Nothing` if the key does not already exist.  
  
 It is not secure to store secrets, such as passwords, in the registry as plain text, even if the registry key is protected by ACLs (Access Control Lists).  
  
 The following conditions may cause an exception:  
  
-   The name of the key is `Nothing` (<xref:System.ArgumentNullException>).  
  
-   The user does not have permissions to create registry keys (<xref:System.Security.SecurityException>).  
  
-   The key name exceeds the 255-character limit (<xref:System.ArgumentException>).  
  
-   The key is closed (<xref:System.IO.IOException>).  
  
-   The registry key is read-only (<xref:System.UnauthorizedAccessException>).  
  
## .NET Framework Security  
 To run this process, your assembly requires a privilege level granted by the <xref:System.Security.Permissions.RegistryPermission> class. If you are running in a partial-trust context, the process might throw an exception due to insufficient privileges. Similarly, the user must have the correct ACLs for creating or writing to settings. For example, a local application that has the code access security permission might not have operating system permission. For more information, see [Code Access Security Basics](../../../../framework/misc/code-access-security-basics.md).  
  
## See Also  
 <xref:Microsoft.VisualBasic.MyServices.RegistryProxy>  
 <xref:Microsoft.VisualBasic.MyServices.RegistryProxy.CurrentUser%2A>  
 <xref:Microsoft.Win32.RegistryKey.CreateSubKey%2A>  
 [Reading from and Writing to the Registry](../../../../visual-basic/developing-apps/programming/computer-resources/reading-from-and-writing-to-the-registry.md)  
 [Code Access Security Basics](../../../../framework/misc/code-access-security-basics.md)
