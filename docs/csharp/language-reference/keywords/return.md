---
title: "return (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "return_CSharpKeyword"
  - "return"
helpviewer_keywords: 
  - "return statement [C#]"
  - "return keyword [C#]"
ms.assetid: 6da6e152-5b58-4448-8f3f-470dd0617ecd
caps.latest.revision: 18
author: "BillWagner"
ms.author: "wiwagn"
---
# return (C# Reference)
The `return` statement terminates execution of the method in which it appears and returns control to the calling method. It can also return an optional value. If the method is a `void` type, the `return` statement can be omitted.  
  
 If the return statement is inside a `try` block, the `finally` block, if one exists, will be executed before control returns to the calling method.  
  
## Example  
 In the following example, the method `CalculateArea()` returns the local variable `area` as a [double](../../../csharp/language-reference/keywords/double.md) value.  
  
 [!code-csharp[csrefKeywordsJump#6](../../../csharp/language-reference/keywords/codesnippet/CSharp/return_1.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [return Statement](/cpp/cpp/return-statement-cpp)  
 [Jump Statements](../../../csharp/language-reference/keywords/jump-statements.md)
