---
title: "-platform (Visual Basic)"
ms.date: 03/13/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "platform compiler option [Visual Basic]"
  - "/platform compiler option [Visual Basic]"
  - "-platform compiler option [Visual Basic]"
ms.assetid: f9bc61e6-e854-4ae1-87b9-d6244de23fd1
author: rpetrusha
ms.author: ronpet
---
# -platform (Visual Basic)
Specifies which platform version of common language runtime (CLR) can run the output file.  
  
## Syntax  
  
```  
-platform:{ x86 | x64 | Itanium | arm | anycpu | anycpu32bitpreferred }  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`x86`|Compiles your assembly to be run by the 32-bit, x86-compatible CLR.|  
|`x64`|Compiles your assembly to be run by the 64-bit CLR on a computer that supports the AMD64 or EM64T instruction set.|  
|`Itanium`|Compiles your assembly to be run by the 64-bit CLR on a computer with an Itanium processor.|  
|`arm`|Compiles your assembly to be run on a computer with an ARM (Advanced RISC Machine) processor.|  
|`anycpu`|Compiles your assembly to run on any platform. The application will run as a 32-bit application on 32-bit versions of Windows and as a 64-bit application on 64-bit versions of Windows. This flag is the default value.|  
|`anycpu32bitpreferred`|Compiles your assembly to run on any platform. The application will run as a 32-bit application on both 32-bit and 64-bit versions of Windows. This flag is valid only for executables (.EXE) and requires [!INCLUDE[net_v45](~/includes/net-v45-md.md)].|  
  
## Remarks  
 Use the `-platform` option to specify the type of processor targeted by the output file.  
  
 In general, .NET Framework assemblies written in Visual Basic will run the same regardless of the platform. However, there are some cases that behave differently on different platforms. These common cases are:  
  
-   Structures that contain members that change size depending on the platform, such as any pointer type.  
  
-   Pointer arithmetic that includes constant sizes.  
  
-   Incorrect platform invoke or COM declarations that use `Integer` for handles instead of <xref:System.IntPtr>.  
  
-   Casting <xref:System.IntPtr> to `Integer`.  
  
-   Using platform invoke or COM interop with components that do not exist on all platforms.  
  
 The **-platform** option will mitigate some issues if you know you have made assumptions about the architecture your code will run on. Specifically:  
  
-   If you decide to target a 64-bit platform, and the application is run on a 32-bit machine, the error message comes much earlier and is more targeted at the problem than the error that occurs without using this switch.  
  
-   If you set the `x86` flag on the option and the application is subsequently run on a 64-bit machine, the application will run in the WOW subsystem instead of running natively.  
  
 On a 64-bit Windows operating system:  
  
-   Assemblies compiled with `-platform:x86` will execute on the 32-bit CLR running under WOW64.  
  
-   Executables compiled with the `-platform:anycpu` will execute on the 64-bit CLR.  
  
-   A DLL compiled with the `-platform:anycpu` will execute on the same CLR as the process into which it loaded.  
  
-   Executables that are compiled with `-platform:anycpu32bitpreferred` will execute on the 32-bit CLR.  
  
 For more information about how to develop an application to run on a 64-bit version of Windows, see [64-bit Applications](../../../framework/64-bit-apps.md).  
  
### To set -platform in the Visual Studio IDE  
  
1.  In **Solution Explorer**, choose the project, open the **Project** menu, and then click **Properties**.  
  
2.  On the **Compile** tab, select or clear the **Prefer 32-bit** check box, or, in the **Target CPU** list, choose a value.  
  
     For more information, see [Compile Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/compile-page-project-designer-visual-basic).  
  
## Example  
 The following example illustrates how to use the `-platform` compiler option.  
  
```console
vbc -platform:x86 myFile.vb  
```  
  
## See Also  
 [/target (Visual Basic)](target.md)  
 [Visual Basic Command-Line Compiler](index.md)  
 [Sample Compilation Command Lines](sample-compilation-command-lines.md)
