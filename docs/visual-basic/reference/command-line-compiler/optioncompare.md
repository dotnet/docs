---
title: "-optioncompare"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "/optioncompare"
  - "-optioncompare"
helpviewer_keywords: 
  - "optioncompare compiler option [Visual Basic]"
  - "-optioncompare compiler option [Visual Basic]"
  - "/optioncompare compiler option [Visual Basic]"
ms.assetid: 7237b766-b44d-4cc5-9a3c-885348a7d9e4
author: rpetrusha
ms.author: ronpet
---
# -optioncompare
Specifies how string comparisons are made.  
  
## Syntax  
  
```  
-optioncompare:{binary | text}  
```  
  
## Remarks  
 You can specify `-optioncompare` in one of two forms: `-optioncompare:binary` to use binary string comparisons, and `-optioncompare:text` to use text string comparisons. By default, the compiler uses `-optioncompare:binary`.  
  
 In Microsoft Windows, the current code page determines the binary sort order. A typical binary sort order is as follows:  
  
 `A < B < E < Z < a < b < e < z < À < Ê < Ø < à < ê < ø`  
  
 Text-based string comparisons are based on a case-insensitive text sort order determined by your system's locale. A typical text sort order is as follows:  
  
 `(A = a) < (À = à) < (B=b) < (E=e) < (Ê = ê) < (Z=z) < (Ø = ø)`  
  
### To set -optioncompare in the Visual Studio IDE  
  
1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**.   
  
2.  Click the **Compile** tab.  
  
3.  Modify the value in the **Option Compare** box.  
  
### To set -optioncompare programmatically  
  
-   See [Option Compare Statement](../../../visual-basic/language-reference/statements/option-compare-statement.md).  
  
## Example  
 The following code compiles `ProjFile.vb` and uses binary string comparisons.  
  
```console
vbc -optioncompare:binary projFile.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [-optionexplicit](../../../visual-basic/reference/command-line-compiler/optionexplicit.md)  
 [-optionstrict](../../../visual-basic/reference/command-line-compiler/optionstrict.md)  
 [-optioninfer](../../../visual-basic/reference/command-line-compiler/optioninfer.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)  
 [Option Compare Statement](../../../visual-basic/language-reference/statements/option-compare-statement.md)  
 [Visual Basic Defaults, Projects, Options Dialog Box](/visualstudio/ide/reference/visual-basic-defaults-projects-options-dialog-box)
