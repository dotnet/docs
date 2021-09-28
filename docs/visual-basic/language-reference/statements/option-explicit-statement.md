---
description: "Learn more about: Option Explicit Statement (Visual Basic)"
title: "Option Explicit Statement"
ms.date: 07/20/2015
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
---
# Option Explicit Statement (Visual Basic)

Forces explicit declaration of all variables in a file, or allows implicit declarations of variables.  
  
## Syntax  
  
```vb  
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
> Setting `Option Explicit` to `Off` is generally not a good practice. You could misspell a variable name in one or more locations, which would cause unexpected results when the program is run.  
  
## When an Option Explicit Statement Is Not Present  

 If the source code does not contain an `Option Explicit` statement, the **Option Explicit** setting on the [Compile Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/compile-page-project-designer-visual-basic) is used. If the command-line compiler is used, the [-optionexplicit](../../reference/command-line-compiler/optionexplicit.md) compiler option is used.  
  
#### To set Option Explicit in the IDE  
  
1. In **Solution Explorer**, select a project. On the **Project** menu, click **Properties**.  
  
2. Click the **Compile** tab.  
  
3. Set the value in the **Option Explicit** box.  
  
 When you create a new project, the **Option Explicit** setting on the **Compile** tab is set to the **Option Explicit** setting in the **VB Defaults** dialog box. To access the **VB Defaults** dialog box, on the **Tools** menu, click **Options**. In the **Options** dialog box, expand **Projects and Solutions**, and then click **VB Defaults**. The initial default setting in **VB Defaults** is `On`.  
  
#### To set Option Explicit on the command line  
  
- Include the [-optionexplicit](../../reference/command-line-compiler/optionexplicit.md) compiler option in the **vbc** command.  
  
## Example  

 The following example uses the `Option Explicit` statement to force explicit declaration of all variables. Attempting to use an undeclared variable causes an error at compile time.  
  
 [!code-vb[VbVbalrStatements#47](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#47)]  
  
 [!code-vb[VbVbalrStatements#48](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class2.vb#48)]  
  
## See also

- [Dim Statement](dim-statement.md)
- [ReDim Statement](redim-statement.md)
- [Option Compare Statement](option-compare-statement.md)
- [Option Strict Statement](option-strict-statement.md)
- [-optioncompare](../../reference/command-line-compiler/optioncompare.md)
- [-optionexplicit](../../reference/command-line-compiler/optionexplicit.md)
- [-optionstrict](../../reference/command-line-compiler/optionstrict.md)
- [Visual Basic Defaults, Projects, Options Dialog Box](/visualstudio/ide/reference/visual-basic-defaults-projects-options-dialog-box)
