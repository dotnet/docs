---
title: "Option Compare Statement"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Compare"
  - "vb.OptionCompare"
helpviewer_keywords: 
  - "case sensitivity, Option Compare statement"
  - "Compare keyword [Visual Basic]"
  - "binary comparison [Visual Basic]"
  - "strings [Visual Basic], returning from functions"
  - "binary comparison [Visual Basic], Option Compare statement"
  - "strings [Visual Basic], comparing"
  - "string comparison [Visual Basic], Option Compare statement"
  - "Text keyword [Visual Basic], Option Compare statement"
  - "Binary keyword [Visual Basic], Option Compare statement"
  - "string comparison [Visual Basic], sorting data"
  - "Option Compare statement [Visual Basic]"
  - "text [Visual Basic], comparing"
ms.assetid: 54e8eeeb-3b0d-4fb9-acce-fbfbd5975f6e
caps.latest.revision: 37
author: dotnet-bot
ms.author: dotnetcontent
---
# Option Compare Statement
Declares the default comparison method to use when comparing string data.  
  
## Syntax  
  
```  
Option Compare { Binary | Text }  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`Binary`|Optional. Results in string comparisons based on a sort order derived from the internal binary representations of the characters.<br /><br /> This type of comparison is useful especially if the strings can contain characters that are not to be interpreted as text. In this case, you do not want to bias comparisons with alphabetical equivalences, such as case insensitivity.|  
|`Text`|Optional. Results in string comparisons based on a case-insensitive text sort order determined by your system's locale.<br /><br /> This type of comparison is useful if your strings contain all text characters, and you want to compare them taking into account alphabetic equivalences such as case insensitivity and closely related letters. For example, you might want to consider `A` and `a` to be equal, and `Ä` and `ä` to come before `B` and `b`.|  
  
## Remarks  
 If used, the `Option Compare` statement must appear in a file before any other source code statements.  
  
 The `Option Compare` statement specifies the string comparison method (`Binary` or `Text`).  The default text comparison method is `Binary`.  
  
 A `Binary` comparison compares the numeric Unicode value of each character in each string. A `Text` comparison compares each Unicode character based on its lexical meaning in the current culture.  
  
 In Microsoft Windows, sort order is determined by the code page. For more information, see [Code Pages](/cpp/c-runtime-library/code-pages).  
  
 In the following example, characters in the English/European code page (ANSI 1252) are sorted by using `Option Compare Binary`, which produces a typical binary sort order.  
  
 `A < B < E < Z < a < b < e < z < À < Ê < Ø < à < ê < ø`  
  
 When the same characters in the same code page are sorted by using `Option Compare Text`, the following text sort order is produced.  
  
 `(A=a) < (À = à) < (B=b) < (E=e) < (Ê = ê) < (Z=z) < (Ø = ø)`  
  
## When an Option Compare Statement Is Not Present  
 If the source code does not contain an `Option Compare` statement, the **Option Compare** setting on the [Compile Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/compile-page-project-designer-visual-basic) is used. If you use the command-line compiler, the setting specified by the [/optioncompare](../../../visual-basic/reference/command-line-compiler/optioncompare.md) compiler option is used.  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
#### To set Option Compare in the IDE  
  
1.  In **Solution Explorer**, select a project. On the **Project** menu, click **Properties**.  
  
2.  Click the **Compile** tab.  
  
3.  Set the value in the **Option Compare** box.  
  
 When you create a project, the **Option Compare** setting on the **Compile** tab is set to the **Option Compare** setting in the **Options** dialog box. To change this setting, on the **Tools** menu, click **Options**. In the **Options** dialog box, expand **Projects and Solutions**, and then click **VB Defaults**. The initial default setting in **VB Defaults** is **Binary**.  
  
#### To set Option Compare on the command line  
  
-   Include the [/optioncompare](../../../visual-basic/reference/command-line-compiler/optioncompare.md) compiler option in the **vbc** command.  
  
## Example  
 The following example uses the `Option Compare` statement to set the binary comparison as the default string comparison method. To use this code, uncomment the `Option Compare Binary` statement, and put it at the top of the source file.  
  
 [!code-vb[VbVbalrStatements#45](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/option-compare-statement_1.vb)]  
  
## Example  
 The following example uses the `Option Compare` statement to set the case-insensitive text sort order as the default string comparison method. To use this code, uncomment the `Option Compare Text` statement, and put it at the top of the source file.  
  
 [!code-vb[VbVbalrStatements#46](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/option-compare-statement_2.vb)]  
  
## See Also  
 <xref:Microsoft.VisualBasic.Strings.InStr%2A>  
 <xref:Microsoft.VisualBasic.Strings.InStrRev%2A>  
 <xref:Microsoft.VisualBasic.Strings.Replace%2A>  
 <xref:Microsoft.VisualBasic.Strings.Split%2A>  
 <xref:Microsoft.VisualBasic.Strings.StrComp%2A>  
 [/optioncompare](../../../visual-basic/reference/command-line-compiler/optioncompare.md)  
 [Comparison Operators](../../../visual-basic/language-reference/operators/comparison-operators.md)  
 [Comparison Operators in Visual Basic](../../../visual-basic/programming-guide/language-features/operators-and-expressions/comparison-operators.md)  
 [Like Operator](../../../visual-basic/language-reference/operators/like-operator.md)  
 [String Functions](../../../visual-basic/language-reference/functions/string-functions.md)  
 [Option Explicit Statement](../../../visual-basic/language-reference/statements/option-explicit-statement.md)  
 [Option Strict Statement](../../../visual-basic/language-reference/statements/option-strict-statement.md)
