---
title: "-win32manifest (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/win32manifest"
helpviewer_keywords: 
  - "/win32manifest compiler option [C#]"
  - "win32manifest compiler option [C#]"
  - "-win32manifest compiler option [C#]"
ms.assetid: 9460ea1b-6c9f-44b8-8f73-301b30a01de1
caps.latest.revision: 13
author: "BillWagner"
ms.author: "wiwagn"
---
# -win32manifest (C# Compiler Options)
Use the **-win32manifest** option to specify a user-defined Win32 application manifest file to be embedded into a project's portable executable (PE) file.  
  
## Syntax  
  
```console  
-win32manifest: filename  
```  
  
## Arguments  
 `filename`  
 The name and location of the custom manifest file.  
  
## Remarks  
 By default, the [!INCLUDE[csharp_current_short](~/includes/csharp-current-short-md.md)] compiler embeds an application manifest that specifies a requested execution level of "asInvoker." It creates the manifest in the same folder in which the executable is built, typically the bin\Debug or bin\Release folder when you use Visual Studio. If you want to supply a custom manifest, for example to specify a requested execution level of "highestAvailable" or "requireAdministrator," use this option to specify the name of the file.  
  
> [!NOTE]
>  This option and the [-win32res (C# Compiler Options)](../../../csharp/language-reference/compiler-options/win32res-compiler-option.md) option are mutually exclusive. If you try to use both options in the same command line you will get a build error.  
  
 An application that has no application manifest that specifies a requested execution level will be subject to file/registry virtualization under the User Account Control feature in Windows. For more information, see [User Account Control](/windows/access-protection/user-account-control/user-account-control-overview).  
  
 Your application will be subject to virtualization if either of these conditions is true:  
  
-   You use the **-nowin32manifest** option and you do not provide a manifest in a later build step or as part of a Windows Resource (.res) file by using the **-win32res** option.  
  
-   You provide a custom manifest that does not specify a requested execution level.  
  
 [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] creates a default .manifest file and stores it in the debug and release directories alongside the executable file. You can add a custom manifest by creating one in any text editor and then adding the file to the project. Alternatively, you can right-click the **Project** icon in **Solution Explorer**, click **Add New Item**, and then click **Application Manifest File**. After you have added your new or existing manifest file, it will appear in the **Manifest** drop down list. For more information, see [Application Page, Project Designer (C#)](/visualstudio/ide/reference/application-page-project-designer-csharp).  
  
 You can provide the application manifest as a custom post-build step or as part of a Win32 resource file by using the [-nowin32manifest (C# Compiler Options)](../../../csharp/language-reference/compiler-options/nowin32manifest-compiler-option.md) option. Use that same option if you want your application to be subject to file or registry virtualization on Windows Vista. This will prevent the compiler from creating and embedding a default manifest in the portable executable (PE) file.  
  
## Example  
 The following example shows the default manifest that the Visual C# compiler inserts into a PE.  
  
> [!NOTE]
>  The compiler inserts a standard application name " MyApplication.app " into the xml. This is a workaround to enable applications to run on Windows Server 2003 Service Pack 3.  
  
```xml  
<?xml version="1.0" encoding="utf-8" standalone="yes"?>  
<assembly xmlns="urn:schemas-microsoft-com:asm.v1" manifestVersion="1.0">  
  <assemblyIdentity version="1.0.0.0" name="MyApplication.app"/>  
  <trustInfo xmlns="urn:schemas-microsoft-com:asm.v2">  
    <security>  
      <requestedPrivileges xmlns="urn:schemas-microsoft-com:asm.v3">  
        <requestedExecutionLevel level="asInvoker"/>  
      </requestedPrivileges>  
    </security>  
  </trustInfo>  
</assembly>  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [-nowin32manifest (C# Compiler Options)](../../../csharp/language-reference/compiler-options/nowin32manifest-compiler-option.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
