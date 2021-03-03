---
description: "Learn more about: -optioninfer"
title: "-optioninfer"
ms.date: 07/20/2015
f1_keywords: 
  - "-optioninfer"
helpviewer_keywords: 
  - "-optioninfer compiler option [Visual Basic]"
  - "/optioninfer compiler option [Visual Basic]"
  - "optioninfer compiler option [Visual Basic]"
ms.assetid: f6c09db1-0553-464a-abe3-d4510c61d6ed
---
# -optioninfer

Enables the use of local type inference in variable declarations.  
  
## Syntax  
  
```console  
-optioninfer[+ | -]  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`+` &#124; `-`|Optional. Specify `-optioninfer+` to enable local type inference, or `-optioninfer-` to block it. The `-optioninfer` option, with no value specified, is the same as `-optioninfer+`. The default value when the `-optioninfer` switch is not present is also `-optioninfer+`. The default value is set in the Vbc.rsp response file.|  
  
> [!NOTE]
> You can use the `-noconfig` option to retain the compiler's internal defaults instead of those specified in vbc.rsp. The compiler default for this option is `-optioninfer-`.  
  
## Remarks  

 If the source code file contains an [Option Infer Statement](../../language-reference/statements/option-infer-statement.md), the statement overrides the `-optioninfer` command-line compiler setting.  
  
### To set -optioninfer in the Visual Studio IDE  
  
1. Select a project in **Solution Explorer**. On the **Project** menu, click **Properties**.  
  
2. On the **Compile** tab, modify the value in the **Option infer** box.  
  
## Example  

 The following code compiles `test.vb` with local type inference enabled.  
  
```console
vbc -optioninfer+ test.vb  
```  
  
## See also

- [Visual Basic Command-Line Compiler](index.md)
- [-optioncompare](optioncompare.md)
- [-optionexplicit](optionexplicit.md)
- [-optionstrict](optionstrict.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
- [Option Infer Statement](../../language-reference/statements/option-infer-statement.md)
- [Local Type Inference](../../programming-guide/language-features/variables/local-type-inference.md)
- [Visual Basic Defaults, Projects, Options Dialog Box](/visualstudio/ide/reference/visual-basic-defaults-projects-options-dialog-box)
- [Compile Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/compile-page-project-designer-visual-basic)
- [-noconfig](noconfig.md)
- [Building from the Command Line](building-from-the-command-line.md)
