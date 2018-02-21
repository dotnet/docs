---
title: "Reading from and Writing to the Registry Using the Microsoft.Win32 Namespace (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "registry [Visual Basic]"
ms.assetid: 4a0dcce0-c27b-4199-baa8-ee4528da6a56
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
---
# Reading from and Writing to the Registry Using the Microsoft.Win32 Namespace (Visual Basic)
Although `My.Computer.Registry` should cover your basic needs when programming against the registry, you can also use the <xref:Microsoft.Win32.Registry> and <xref:Microsoft.Win32.RegistryKey> classes in the <xref:Microsoft.Win32> namespace of the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)].  
  
## Keys in the Registry Class  
 The <xref:Microsoft.Win32.Registry> class supplies the base registry keys that can be used to access subkeys and their values. The base keys themselves are read-only. The following table lists and describes the seven keys exposed by the <xref:Microsoft.Win32.Registry> class.  
  
|**Key**|**Description**|  
|-------------|---------------------|  
|<xref:Microsoft.Win32.Registry.ClassesRoot>|Defines the types of documents and the properties associated with those types.|  
|<xref:Microsoft.Win32.Registry.CurrentConfig>|Contains hardware configuration information that is not user-specific.|  
|<xref:Microsoft.Win32.Registry.CurrentUser>|Contains information about the current user preferences, such as environmental variables.|  
|<xref:Microsoft.Win32.Registry.DynData>|Contains dynamic registry data, such as that used by Virtual Device Drivers.|  
|<xref:Microsoft.Win32.Registry.LocalMachine>|Contains five subkeys (Hardware, SAM, Security, Software, and System) that hold the configuration data for the local computer.|  
|<xref:Microsoft.Win32.Registry.PerformanceData>|Contains performance information for software components.|  
|<xref:Microsoft.Win32.Registry.Users>|Contains information about the default user preferences.|  
  
> [!IMPORTANT]
>  It is more secure to write data to the current user (<xref:Microsoft.Win32.Registry.CurrentUser>) than to the local computer (<xref:Microsoft.Win32.Registry.LocalMachine>). A condition that's typically referred to as "squatting" occurs when the key you are creating was previously created by another, possibly malicious, process. To prevent this from occurring, use a method, such as <xref:Microsoft.Win32.RegistryKey.GetValue%2A>, that returns `Nothing` if the key does not already exist.  
  
## Reading a Value from the Registry  
 The following code shows how to read a string from HKEY_CURRENT_USER.  
  
 [!code-vb[VbResourceTasks#20](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/reading-from-and-writing-to-the-registry-using-the-microsoft-win32-namespace_1.vb)]  
  
 The following code reads, increments, and then writes a string to HKEY_CURRENT_USER.  
  
 [!code-vb[VbResourceTasks#21](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/reading-from-and-writing-to-the-registry-using-the-microsoft-win32-namespace_2.vb)]  
  
## See Also  
 <xref:System.SystemException>  
 <xref:System.ApplicationException>  
 <xref:Microsoft.VisualBasic.MyServices.RegistryProxy>  
 [Try...Catch...Finally Statement](../../../../visual-basic/language-reference/statements/try-catch-finally-statement.md)  
 [Reading from and Writing to the Registry](../../../../visual-basic/developing-apps/programming/computer-resources/reading-from-and-writing-to-the-registry.md)  
 [Security and the Registry](../../../../visual-basic/developing-apps/programming/computer-resources/security-and-the-registry.md)
