---
title: "-platform (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/platform"
helpviewer_keywords: 
  - "platform compiler option [C#]"
  - "-platform compiler option [C#]"
  - "/platform compiler option [C#]"
ms.assetid: c290ff5e-47f4-4a85-9bb3-9c2525b0be04
caps.latest.revision: 46
author: "BillWagner"
ms.author: "wiwagn"
---
# -platform (C# Compiler Options)
Specifies which version of the Common Language Runtime (CLR) can run the assembly.  
  
## Syntax  
  
```console  
-platform:string  
```  
  
#### Parameters  
 `string`  
 anycpu (default), anycpu32bitpreferred, ARM, x64, x86, or Itanium.  
  
## Remarks  
  
-   **anycpu** (default) compiles your assembly to run on any platform. Your application runs as a 64-bit process whenever possible and falls back to 32-bit when only that mode is available.  
  
-   **anycpu32bitpreferred** compiles your assembly to run on any platform. Your application runs in 32-bit mode on systems that support both 64-bit and 32-bit applications. You can specify this option only for projects that target the .NET Framework 4.5.  
  
-   **ARM** compiles your assembly to run on a computer that has an Advanced RISC Machine (ARM) processor.  
  
-   **x64** compiles your assembly to be run by the 64-bit CLR on a computer that supports the AMD64 or EM64T instruction set.  
  
-   **x86** compiles your assembly to be run by the 32-bit, x86-compatible CLR.  
  
-   **Itanium** compiles your assembly to be run by the 64-bit CLR on a computer with an Itanium processor.  
  
 On a 64-bit Windows operating system:  
  
-   Assemblies compiled with **-platform:x86** execute on the 32-bit CLR running under WOW64.  
  
-   A DLL compiled with the **-platform:anycpu** executes on the same CLR as the process into which it is loaded.  
  
-   Executables that are compiled with the **-platform:anycpu** execute on the 64-bit CLR.  
  
-   Executables compiled with **-platform:anycpu32bitpreferred** execute on the 32-bit CLR.  
  
 The **anycpu32bitpreferred** setting is valid only for executable (.EXE) files, and it requires the .NET Framework 4.5.  
  
 For more information about developing an application to run on a Windows 64-bit operating system, see [64-bit Applications](../../../framework/64-bit-apps.md).  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the **Properties** page for the project.  
  
2.  Click the **Build** property page.  
  
3.  Modify the **Platform target** property and, for projects that target the .NET Framework 4.5, select or clear the **Prefer 32-bit** check box.  
  
 **Note -platform** is not available in the development environment in Visual C# Express.  
  
 For information on how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.PlatformTarget%2A>.  
  
## Example  
 The following example shows how to use the **-platform** option to specify that the application should be run by the 64-bit CLR on a 64-bit Windows operating system.  
  
```console  
csc -platform:anycpu filename.cs  
```  
  
## See Also  
 [C# Compiler Options](index.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
