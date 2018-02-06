---
title: "Option Explicit Statement (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Explicit"
  - "vb.OptionExplicit"
helpviewer_keywords: 
  - "declaring variables [Visual Basic], explicit"
  - "forced variable declaration in Option Explicit statement [Visual Basic]"
  - "Explicit keyword"
  - "explicit variable declaration"
  - "Option Explicit statement [Visual Basic]"
ms.assetid: e82ac1ad-2cd3-49b2-b985-8bcf016f3fcc
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# Option Explicit Statement (Visual Basic)
Forces explicit declaration of all variables in a file, or allows implicit declarations of variables.  
  
## Syntax  
  
```  
Option Explicit { On | Off }  
```  
  
## Parts  
 `On`  
 Optional. Enables `Option Explicit` checking. If `On` or `Off` is not specified, the default is `On`.  
  
 `Off`  
 Optional. Disables `Option Explicit` checking.  
  
## Remarks  
 When `Option Explicit On` or `Option Explicit` appears in a file, you must explicitly declare all variables by using the `Dim` or `ReDim` statements. If you try to use an undeclared variable name, an error occurs at compile time. The `Option Explicit Off` statement allows implicit declaration of variables.  
  
 If used, the `Option Explicit` statement must appear in a file before any other source code statements.  
  
> [!NOTE]
>  Setting `Option Explicit` to `Off` is generally not a good practice. You could misspell a variable name in one or more locations, which would cause unexpected results when the program is run.  
  
## When an Option Explicit Statement Is Not Present  
 If the source code does not contain an `Option Explicit` statement, the **Option Explicit** setting on the [Compile Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/compile-page-project-designer-visual-basic) is used. If the command-line compiler is used, the [/optionexplicit](../../../visual-basic/reference/command-line-compiler/optionexplicit.md) compiler option is used.  
  
#### To set Option Explicit in the IDE  
  
1.  In **Solution Explorer**, select a project. On the **Project** menu, click **Properties**.  
  
2.  Click the **Compile** tab.  
  
3.  Set the value in the **Option Explicit** box.  
  
 When you create a new project, the **Option Explicit** setting on the **Compile** tab is set to the **Option Explicit** setting in the **VB Defaults** dialog box. To access the **VB Defaults** dialog box, on the **Tools** menu, click **Options**. In the **Options** dialog box, expand **Projects and Solutions**, and then click **VB Defaults**. The initial default setting in **VB Defaults** is `On`.  
  
#### To set Option Explicit on the command line  
  
-   Include the [/optionexplicit](../../../visual-basic/reference/command-line-compiler/optionexplicit.md) compiler option in the **vbc** command.  
  
## Example  
 The following example uses the `Option Explicit` statement to force explicit declaration of all variables. Attempting to use an undeclared variable causes an error at compile time.  
  
 [!code-vb[VbVbalrStatements#47](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/option-explicit-statement_1.vb)]  
  
 [!code-vb[VbVbalrStatements#48](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/option-explicit-statement_2.vb)]  
  
## See Also  
 [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md)  
 [ReDim Statement](../../../visual-basic/language-reference/statements/redim-statement.md)  
 [Option Compare Statement](../../../visual-basic/language-reference/statements/option-compare-statement.md)  
 [Option Strict Statement](../../../visual-basic/language-reference/statements/option-strict-statement.md)  
 [/optioncompare](../../../visual-basic/reference/command-line-compiler/optioncompare.md)  
 [/optionexplicit](../../../visual-basic/reference/command-line-compiler/optionexplicit.md)  
 [/optionstrict](../../../visual-basic/reference/command-line-compiler/optionstrict.md)  
 [Visual Basic Defaults, Projects, Options Dialog Box](/visualstudio/ide/reference/visual-basic-defaults-projects-options-dialog-box)
