---
title: "Concatenation Operators in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "& operator [Visual Basic], concatenation"
  - "concatenation operators [Visual Basic]"
  - "operators [Visual Basic], concatenation"
  - "Visual Basic code, operators"
  - "+ operator [Visual Basic], concatenation"
  - "concatenation operators [Visual Basic]"
ms.assetid: e59908c3-89e0-41ae-933d-3e8826c16a04
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# Concatenation Operators in Visual Basic
Concatenation operators join multiple strings into a single string. There are two concatenation operators, `+` and `&`. Both carry out the basic concatenation operation, as the following example shows.  
  
```vb
Dim x As String = "Mic" & "ro" & "soft" 
Dim y As String = "Mic" + "ro" + "soft" 
' The preceding statements set both x and y to "Microsoft".
```  
  
 These operators can also concatenate `String` variables, as the following example shows.  
  
 [!code-vb[VbVbalrOperators#76](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/concatenation-operators_1.vb)]  
  
## Differences Between the Two Concatenation Operators  
 The [+ Operator](../../../../visual-basic/language-reference/operators/addition-operator.md) has the primary purpose of adding two numbers. However, it can also concatenate numeric operands with string operands. The `+` operator has a complex set of rules that determine whether to add, concatenate, signal a compiler error, or throw a run-time <xref:System.InvalidCastException> exception.  
  
 The [& Operator](../../../../visual-basic/language-reference/operators/concatenation-operator.md) is defined only for `String` operands, and it always widens its operands to `String`, regardless of the setting of `Option Strict`. The `&` operator is recommended for string concatenation because it is defined exclusively for strings and reduces your chances of generating an unintended conversion.  
  
## Performance: String and StringBuilder  
 If you do a significant number of manipulations on a string, such as concatenations, deletions, and replacements, your performance might profit from the <xref:System.Text.StringBuilder> class in the <xref:System.Text> namespace. It takes an extra instruction to create and initialize a <xref:System.Text.StringBuilder> object, and another instruction to convert its final value to a `String`, but you might recover this time because <xref:System.Text.StringBuilder> can perform faster.  
  
## See Also  
 [Option Strict Statement](../../../../visual-basic/language-reference/statements/option-strict-statement.md)  
 [Types of String Manipulation Methods in Visual Basic](../../../../visual-basic/programming-guide/language-features/strings/types-of-string-manipulation-methods.md)  
 [Arithmetic Operators in Visual Basic](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/arithmetic-operators.md)  
 [Comparison Operators in Visual Basic](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/comparison-operators.md)  
 [Logical and Bitwise Operators in Visual Basic](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/logical-and-bitwise-operators.md)
