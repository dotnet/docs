---
description: "Learn more about: -optionexplicit"
title: "-optionexplicit"
ms.date: 07/20/2015
f1_keywords: 
  - "/optionexplicit"
  - "-optionexplicit"
helpviewer_keywords: 
  - "/optionexplicit compiler option [Visual Basic]"
  - "optionexplicit compiler option [Visual Basic]"
  - "-optionexplicit compiler option [Visual Basic]"
ms.assetid: 5d296ab3-bafe-4c4d-9887-78f162ed86c7
---
# -optionexplicit

Causes the compiler to report errors if variables are not declared before they are used.  
  
## Syntax  
  
```console  
-optionexplicit[+ | -]  
```  
  
## Arguments  

 `+` &#124; `-`  
 Optional. Specify `-optionexplicit+` to require explicit declaration of variables. The `-optionexplicit+` option is the default and is the same as `-optionexplicit`. The `-optionexplicit-` option enables implicit declaration of variables.  
  
## Remarks  

 If the source code file contains an [Option Explicit statement](../../language-reference/statements/option-explicit-statement.md), the statement overrides the `-optionexplicit` command-line compiler setting.  
  
### To set -optionexplicit in the Visual Studio IDE  
  
1. Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**.
  
2. Click the **Compile** tab.  
  
3. Modify the value in the **Option Explicit** box.  
  
## Example  

 The following code compiles when `-optionexplicit-` is used.  
  
 [!code-vb[VbVbalrCompiler#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrCompiler/VB/OptionExplicitOff.vb#5)]  
  
## See also

- [Visual Basic Command-Line Compiler](index.md)
- [-optioncompare](optioncompare.md)
- [-optionstrict](optionstrict.md)
- [-optioninfer](optioninfer.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
- [Option Explicit Statement](../../language-reference/statements/option-explicit-statement.md)
- [Visual Basic Defaults, Projects, Options Dialog Box](/visualstudio/ide/reference/visual-basic-defaults-projects-options-dialog-box)
