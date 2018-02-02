---
title: "How to: Create a Key In the Registry (Visual C#)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "registry, adding keys and values [C#]"
  - "registry keys, creating [C#]"
  - "keys, creating in registry"
ms.assetid: 8fa475b0-e01f-483a-9327-fd03488fdf5d
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Create a Key In the Registry (Visual C#)
This example adds the value pair, "Name" and "Isabella", to the current user's registry, under the key "Names".  
  
## Example  
  
```  
Microsoft.Win32.RegistryKey key;  
key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Names");  
key.SetValue("Name", "Isabella");  
key.Close();  
```  
  
## Compiling the Code  
  
-   Copy the code and paste it into the `Main` method of a console application.  
  
-   Replace the `Names` parameter with the name of a key that exists directly under the HKEY_CURRENT_USER node of the registry.  
  
-   Replace the `Name` parameter with the name of a value that exists directly under the Names node.  
  
## Robust Programming  
 Examine the registry structure to find a suitable location for your key. For example, you might want to open the Software key of the current user, and create a key with your company's name. Then add the registry values to your company's key.  
  
 The following conditions might cause an exception:  
  
-   The name of the key is null.  
  
-   The user does not have permissions to create registry keys.  
  
-   The key name exceeds the 255-character limit.  
  
-   The key is closed.  
  
-   The registry key is read-only.  
  
## .NET Framework Security  
 It is more secure to write data to the user folder — `Microsoft.Win32.Registry.CurrentUser` — rather than to the local computer — `Microsoft.Win32.Registry.LocalMachine`.  
  
 When you create a registry value, you need to decide what to do if that value already exists. Another process, perhaps a malicious one, may have already created the value and have access to it. When you put data in the registry value, the data is available to the other process. To prevent this, use the.`Overload:Microsoft.Win32.RegistryKey.GetValue` method. It returns null if the key does not already exist.  
  
 It is not secure to store secrets, such as passwords, in the registry as plain text, even if the registry key is protected by access control lists (ACL).  
  
## See Also  
 <xref:System.IO?displayProperty=nameWithType>  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [File System and the Registry (C# Programming Guide)](../../../csharp/programming-guide/file-system/index.md)  
 [Read, write and delete from the registry with C#](http://www.codeproject.com/Articles/3389/Read-write-and-delete-from-registry-with-C)
