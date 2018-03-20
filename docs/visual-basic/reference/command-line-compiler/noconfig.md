---
title: "-noconfig"
ms.date: 03/13/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "noconfig compiler option [Visual Basic]"
  - "-noconfig compiler option [Visual Basic]"
  - "/noconfig compiler option [Visual Basic]"
ms.assetid: a7405067-bd21-4171-adf4-a126fa3ad6c3
author: dotnet-bot
ms.author: dotnetcontent
---
# -noconfig
Specifies that the compiler should not automatically reference the commonly used [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] assemblies or import the `System` and `Microsoft.VisualBasic` namespaces.  
  
## Syntax  
  
```  
-noconfig  
```  
  
## Remarks  
 The `-noconfig` option tells the compiler not to compile with the Vbc.rsp file, which is located in the same directory as the Vbc.exe file. The Vbc.rsp file references the commonly used [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] assemblies and imports the `System` and `Microsoft.VisualBasic` namespaces. The compiler implicitly references the System.dll assembly unless the `-nostdlib` option is specified. The `-nostdlib` option tells the compiler not to compile with Vbc.rsp or automatically reference the System.dll assembly.  
  
> [!NOTE]
>  The Mscorlib.dll and Microsoft.VisualBasic.dll assemblies are always referenced.  
  
 You can modify the Vbc.rsp file to specify additional compiler options that should be included in every Vbc.exe compilation (except when specifying the `-noconfig` option). For more information, see [@ (Specify Response File)](../../../visual-basic/reference/command-line-compiler/specify-response-file.md).  
  
 The compiler processes the options passed to the `vbc` command last. Therefore, any option on the command line overrides the setting of the same option in the Vbc.rsp file.  
  
> [!NOTE]
>  The `-noconfig` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## See Also  
 [-nostdlib (Visual Basic)](../../../visual-basic/reference/command-line-compiler/nostdlib.md)  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [@ (Specify Response File)](../../../visual-basic/reference/command-line-compiler/specify-response-file.md)  
 [-reference (Visual Basic)](../../../visual-basic/reference/command-line-compiler/reference.md)
