---
title: "-netcf"
ms.date: 03/13/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "/netcf"
  - "-netcf"
helpviewer_keywords: 
  - "-netcf compiler option [Visual Basic]"
  - "netcf compiler option [Visual Basic]"
  - "/netcf compiler option [Visual Basic]"
ms.assetid: db7cfa59-c315-401c-a59b-0daf355343d6
author: rpetrusha
ms.author: ronpet
---
# -netcf
Sets the compiler to target the [!INCLUDE[Compact](~/includes/compact-md.md)].  
  
## Syntax  
  
```  
-netcf  
```  
  
## Remarks  
 The `-netcf` option causes the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler to target the [!INCLUDE[Compact](~/includes/compact-md.md)] rather than the full [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)]. Language functionality that is present only in the full [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] is disabled.  
  
 The `-netcf` option is designed to be used with [-sdkpath](../../../visual-basic/reference/command-line-compiler/sdkpath.md). The language features disabled by `-netcf` are the same language features not present in the files targeted with `-sdkpath`.  
  
> [!NOTE]
>  The `-netcf` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line. The `-netcf` option is set when a [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] device project is loaded.  
  
 The `-netcf` option changes the following language features:  
  
-   The [End \<keyword> Statement](../../../visual-basic/language-reference/statements/end-keyword-statement.md) keyword, which terminates execution of a program, is disabled. The following program compiles and runs without `-netcf` but fails at compile time with `-netcf`.  
  
     [!code-vb[VbVbalrCompiler#34](../../../visual-basic/reference/command-line-compiler/codesnippet/VisualBasic/netcf_1.vb)]  
  
-   Late binding, in all forms, is disabled. Compile-time errors are generated when recognized late-binding scenarios are encountered. The following program compiles and runs without `-netcf` but fails at compile time with `-netcf`.  
  
     [!code-vb[VbVbalrCompiler#35](../../../visual-basic/reference/command-line-compiler/codesnippet/VisualBasic/netcf_2.vb)]  
  
-   The [Auto](../../../visual-basic/language-reference/modifiers/auto.md), [Ansi](../../../visual-basic/language-reference/modifiers/ansi.md), and [Unicode](../../../visual-basic/language-reference/modifiers/unicode.md) modifiers are disabled. The syntax of the [Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md) statement is also modified to `Declare Sub|Function name Lib "library" [Alias "alias"] [([arglist])]`. The following code shows the effect of `-netcf` on a compilation.  
  
     [!code-vb[VbVbalrCompiler#36](../../../visual-basic/reference/command-line-compiler/codesnippet/VisualBasic/netcf_3.vb)]  
  
-   Using Visual Basic 6.0 keywords that were removed from [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] generates a different error when `-netcf` is used. This affects the error messages for the following keywords:  
  
    -   `Open`  
  
    -   `Close`  
  
    -   `Put`  
  
    -   `Print`  
  
    -   `Write`  
  
    -   `Input`  
  
    -   `Lock`  
  
    -   `Unlock`  
  
    -   `Seek`  
  
    -   `Width`  
  
    -   `Name`  
  
    -   `FreeFile`  
  
    -   `EOF`  
  
    -   `Loc`  
  
    -   `LOF`  
  
    -   `Line`  
  
## Example  
 The following code compiles `Myfile.vb` with the [!INCLUDE[Compact](~/includes/compact-md.md)], using the versions of mscorlib.dll and Microsoft.VisualBasic.dll found in the default installation directory of the [!INCLUDE[Compact](~/includes/compact-md.md)] on the C drive. Typically, you would use the most recent version of the [!INCLUDE[Compact](~/includes/compact-md.md)].  
  
```console  
vbc -netcf -sdkpath:"c:\Program Files\Microsoft Visual Studio .NET 2003\CompactFrameworkSDK\v1.0.5000\Windows CE " myfile.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)  
 [-sdkpath](../../../visual-basic/reference/command-line-compiler/sdkpath.md)
