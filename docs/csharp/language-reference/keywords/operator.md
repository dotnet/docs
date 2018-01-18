---
title: "operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "operator_CSharpKeyword"
  - "operator"
helpviewer_keywords: 
  - "operator keyword [C#]"
ms.assetid: 59218cce-e90e-42f6-a6bb-30300981b86a
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
---
# operator (C# Reference)
Use the `operator` keyword to overload a built-in operator or to provide a user-defined conversion in a class or struct declaration.  
  
## Example  
 The following is a very simplified class for fractional numbers. It overloads the `+` and `*` operators to perform fractional addition and multiplication, and also provides a conversion operator that converts a `Fraction` type to a `double` type.  
  
 [!code-csharp[csrefKeywordsConversion#6](../../../csharp/language-reference/keywords/codesnippet/CSharp/operator_1.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [implicit](../../../csharp/language-reference/keywords/implicit.md)  
 [explicit](../../../csharp/language-reference/keywords/explicit.md)  
 [How to: Implement User-Defined Conversions Between Structs](../../../csharp/programming-guide/statements-expressions-operators/how-to-implement-user-defined-conversions-between-structs.md)
