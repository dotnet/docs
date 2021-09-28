---
description: "Learn more about: Reading from and Writing to the Registry (Visual Basic)"
title: "Reading from and Writing to the Registry"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "My.Computer.Registry object, tasks"
  - "registry [Visual Basic], writing to"
  - "registry [Visual Basic], reading"
ms.assetid: a13da106-185b-41d7-b23c-416da65e21e4
---
# Reading from and Writing to the Registry (Visual Basic)

This topic describes task and conceptual topics that are associated with the registry.  
  
 When programming in Visual Basic, you can choose to access the registry by means of either the functions provided by Visual Basic or the registry classes of .NET. The registry hosts information from the operating system as well as information from applications hosted on the machine. Working with the registry may compromise security by allowing inappropriate access to system resources or protected information.  
  
## In This Section  

 [How to: Create a Registry Key and Set Its Value](how-to-create-a-registry-key-and-set-its-value.md)  
 Describes how to use the `CreateSubKey` and `SetValue` methods of the `My.Computer.Registry` object to create a registry key and set its value.  
  
 [How to: Read a Value from a Registry Key](how-to-read-a-value-from-a-registry-key.md)  
 Describes how to use the `GetValue` method of the `My.Computer.Registry` object to read a value from a registry key.  
  
 [How to: Delete a Registry Key](how-to-delete-a-registry-key.md)  
 Describes how to use the `DeleteSubKey` method of the `My.Computer.Registry.CurrentUser` property to delete a registry key.  
  
 [Reading from and Writing to the Registry Using the Microsoft.Win32 Namespace](reading-from-and-writing-to-the-registry-using-the-microsoft-win32-namespace.md)  
 Describes how to use the `Registry` and `RegistryKey` classes of .NET to access the registry.  
  
 [Security and the Registry](security-and-the-registry.md)  
 Discusses security issues involving the registry.  
  
## Related Sections  

 <xref:Microsoft.VisualBasic.MyServices.RegistryProxy>  
 Lists and explains members of the `My.Computer.Registry` object.  
  
 <xref:Microsoft.Win32.Registry>  
 Presents an overview of the `Registry` class, along with links to individual keys and members.
