---
title: "Sample Compilation Command Lines (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "command line, compilers"
  - "compilation, command-line"
  - "command-line compilers"
  - "compiling source code, from command line"
  - "Visual Basic compiler, sample command lines"
ms.assetid: 5bfbb487-5f47-4267-969a-39dfb917beeb
caps.latest.revision: 14
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Sample Compilation Command Lines (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

As an alternative to compiling [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] programs from within [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], you can compile from the command line to produce executable (.exe) files or dynamic-link library (.dll) files.  
  
 The [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] command-line compiler supports a complete set of options that control input and output files, assemblies, and debug and preprocessor options. Each option is available in two interchangeable forms: `-``option` and `/``option`. This documentation shows only the `/``option` form.  
  
 The following table lists some sample command lines you can modify for your own use.  
  
|To|Use|  
|--------|---------|  
|Compile File.vb and create File.exe|`vbc /reference:Microsoft.VisualBasic.dll File.vb`|  
|Compile File.vb and create File.dll|`vbc /target:library File.vb`|  
|Compile File.vb and create My.exe|`vbc /out:My.exe File.vb`|  
|Compile all [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] files in the current directory, with optimizations on and the `DEBUG` symbol defined, producing File2.exe|`vbc /define:DEBUG=1 /optimize /out:File2.exe *.vb`|  
|Compile all [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] files in the current directory, producing a debug version of File2.dll without displaying the logo or warnings|`vbc /target:library /out:File2.dll /nowarn /nologo /debug *.vb`|  
|Compile all [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] files in the current directory to Something.dll|`vbc /target:library /out:Something.dll *.vb`|  
  
 When compiling from the command line, you must explicitly reference the Microsoft [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] run-time library through the `/reference` compiler option.  
  
> [!TIP]
>  When you build a project by using the Visual Studio IDE, you can display information about the associated **vbc** command with its compiler options in the output window. To display this information, open the [Options Dialog Box,  Projects and Solutions, Build and Run](/visual-studio/ide/reference/options-dialog-box-projects-and-solutions-build-and-run), and then set the **MSBuild project build output verbosity** to **Normal** or a higher level of verbosity. For more information, see [How to: View, Save, and Configure Build Log Files](../Topic/How%20to:%20View,%20Save,%20and%20Configure%20Build%20Log%20Files.md).  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)   
 [Conditional Compilation](../../../visual-basic/programming-guide/program-structure/conditional-compilation.md)