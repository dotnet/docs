---
title: "-win32manifest (Visual Basic)"
ms.date: 03/13/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "/win32manifest compiler option [Visual Basic]"
  - "win32manifest compiler option [Visual Basic]"
  - "-win32manifest compiler option [Visual Basic]"
ms.assetid: 9e3191b4-90db-41c8-966a-28036fd20005
author: rpetrusha
ms.author: ronpet
---
# -win32manifest (Visual Basic)
Identifies a user-defined Win32 application manifest file to be embedded into a project's portable executable (PE) file.  
  
## Syntax  
  
```  
-win32manifest: fileName  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`fileName`|The path of the custom manifest file.|  
  
## Remarks  
 By default, the Visual Basic compiler embeds an application manifest that specifies a requested execution level of asInvoker. It creates the manifest in the same folder in which the executable file is built, typically the bin\Debug or bin\Release folder when you use Visual Studio. If you want to supply a custom manifest, for example to specify a requested execution level of highestAvailable or requireAdministrator, use this option to specify the name of the file.  
  
> [!NOTE]
>  This option and the [-win32resource](../../../visual-basic/reference/command-line-compiler/win32resource.md) option are mutually exclusive. If you try to use both options in the same command line, you will get a build error.  
  
 An application that has no application manifest that specifies a requested execution level will be subject to file/registry virtualization under the User Account Control feature in Windows Vista. For more information about virtualization, see [ClickOnce Deployment on Windows Vista](/visualstudio/deployment/clickonce-deployment-on-windows-vista).  
  
 Your application will be subject to virtualization if either of the following conditions is true:  
  
1.  You use the `-nowin32manifest` option and you do not provide a manifest in a later build step or as part of a Windows Resource (.res) file by using the `-win32resource` option.  
  
2.  You provide a custom manifest that does not specify a requested execution level.  
  
 [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] creates a default .manifest file and stores it in the debug and release directories alongside the executable file. You can view or edit the default app.manifest file by clicking **View UAC Settings** on the **Application** tab in the Project Designer. For more information, see [Application Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/application-page-project-designer-visual-basic).  
  
 You can provide the application manifest as a custom post-build step or as part of a Win32 resource file by using the `-nowin32manifest` option. Use that same option if you want your application to be subject to file or registry virtualization on Windows Vista. This will prevent the compiler from creating and embedding a default manifest in the PE file.  
  
## Example  
 The following example shows the default manifest that the Visual Basic compiler inserts into a PE.  
  
> [!NOTE]
>  The compiler inserts a standard application name MyApplication.app into the manifest XML. This is a workaround to enable applications to run on Windows Server 2003 Service Pack 3.  
  
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
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [-nowin32manifest (Visual Basic)](../../../visual-basic/reference/command-line-compiler/nowin32manifest.md)
