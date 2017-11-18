---
title: "goto (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "goto_CSharpKeyword"
  - "goto"
helpviewer_keywords: 
  - "goto keyword [C#]"
ms.assetid: 2c03c9c1-8119-44ef-b740-fb3d287a42fe
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
---
# goto (C# Reference)
The `goto` statement transfers the program control directly to a labeled statement.  
  
 A common use of `goto` is to transfer control to a specific switch-case label or the default label in a `switch` statement.  
  
 The `goto` statement is also useful to get out of deeply nested loops.  
  
## Example  
 The following example demonstrates using `goto` in a [switch](../../../csharp/language-reference/keywords/switch.md) statement.  
  
 [!code-csharp[csrefKeywordsJump#4](../../../csharp/language-reference/keywords/codesnippet/CSharp/goto_1.cs)]  
  
## Example  
 The following example demonstrates using `goto` to break out from nested loops.  
  
 [!code-csharp[csrefKeywordsJump#5](../../../csharp/language-reference/keywords/codesnippet/CSharp/goto_2.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [goto Statement](/cpp/cpp/goto-statement-cpp)  
 [Jump Statements](../../../csharp/language-reference/keywords/jump-statements.md)
