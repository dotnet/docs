---
title: "checked (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "checked_CSharpKeyword"
  - "checked"
helpviewer_keywords: 
  - "checked keyword [C#]"
ms.assetid: 718a1194-988d-48a3-b089-d6ee8bd1608d
caps.latest.revision: 24
author: "BillWagner"
ms.author: "wiwagn"
---
# checked (C# Reference)
The `checked` keyword is used to explicitly enable overflow checking for integral-type arithmetic operations and conversions.  
  
 By default, an expression that contains only constant values causes a compiler error if the expression produces a value that is outside the range of the destination type. If the expression contains one or more non-constant values, the compiler does not detect the overflow. Evaluating the expression assigned to `i2` in the following example does not cause a compiler error.  
  
 [!code-csharp[csrefKeywordsChecked#3](../../../csharp/language-reference/keywords/codesnippet/CSharp/checked_1.cs)]  
  
 By default, these non-constant expressions are not checked for overflow at run time either, and they do not raise overflow exceptions. The previous example displays -2,147,483,639 as the sum of two positive integers.  
  
 Overflow checking can be enabled by compiler options, environment configuration, or use of the `checked` keyword. The following examples demonstrate how to use a `checked` expression or a `checked` block to detect the overflow that is produced by the previous sum at run time. Both examples raise an overflow exception.  
  
 [!code-csharp[csrefKeywordsChecked#4](../../../csharp/language-reference/keywords/codesnippet/CSharp/checked_2.cs)]  
  
 The [unchecked](../../../csharp/language-reference/keywords/unchecked.md) keyword can be used to prevent overflow checking.  
  
## Example  
 This sample shows how to use `checked` to enable overflow checking at run time.  
  
 [!code-csharp[csrefKeywordsChecked#1](../../../csharp/language-reference/keywords/codesnippet/CSharp/checked_3.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Checked and Unchecked](../../../csharp/language-reference/keywords/checked-and-unchecked.md)  
 [unchecked](../../../csharp/language-reference/keywords/unchecked.md)
