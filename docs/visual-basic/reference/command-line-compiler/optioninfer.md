---
title: "-optioninfer"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "-optioninfer"
helpviewer_keywords: 
  - "-optioninfer compiler option [Visual Basic]"
  - "/optioninfer compiler option [Visual Basic]"
  - "optioninfer compiler option [Visual Basic]"
ms.assetid: f6c09db1-0553-464a-abe3-d4510c61d6ed
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# -optioninfer
Enables the use of local type inference in variable declarations.  
  
## Syntax  
  
```  
-optioninfer[+ | -]  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`+` &#124; `-`|Optional. Specify `-optioninfer+` to enable local type inference, or `-optioninfer-` to block it. The `-optioninfer` option, with no value specified, is the same as `-optioninfer+`. The default value when the `-optioninfer` switch is not present is also `-optioninfer+`. The default value is set in the Vbc.rsp response file.|  
  
> [!NOTE]
>  You can use the `-noconfig` option to retain the compiler's internal defaults instead of those specified in vbc.rsp. The compiler default for this option is `-optioninfer-`.  
  
## Remarks  
 If the source code file contains an [Option Infer Statement](../../../visual-basic/language-reference/statements/option-infer-statement.md), the statement overrides the `-optioninfer` command-line compiler setting.  
  
### To set -optioninfer in the Visual Studio IDE  
  
1.  Select a project in **Solution Explorer**. On the **Project** menu, click **Properties**.  
  
2.  On the **Compile** tab, modify the value in the **Option infer** box.  
  
## Example  
 The following code compiles `test.vb` with local type inference enabled.  
  
```console
vbc -optioninfer+ test.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [-optioncompare](../../../visual-basic/reference/command-line-compiler/optioncompare.md)  
 [-optionexplicit](../../../visual-basic/reference/command-line-compiler/optionexplicit.md)  
 [-optionstrict](../../../visual-basic/reference/command-line-compiler/optionstrict.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)  
 [Option Infer Statement](../../../visual-basic/language-reference/statements/option-infer-statement.md)  
 [Local Type Inference](../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md)  
 [Visual Basic Defaults, Projects, Options Dialog Box](/visualstudio/ide/reference/visual-basic-defaults-projects-options-dialog-box)  
 [Compile Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/compile-page-project-designer-visual-basic)  
 [/noconfig](../../../visual-basic/reference/command-line-compiler/noconfig.md)  
 [Building from the Command Line](../../../visual-basic/reference/command-line-compiler/building-from-the-command-line.md)
