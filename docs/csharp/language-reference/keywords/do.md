---
title: "do (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "do_CSharpKeyword"
  - "do"
helpviewer_keywords: 
  - "do keyword [C#]"
ms.assetid: 50725f79-9ba6-4898-aa78-6e331568a1bb
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
---
# do (C# Reference)
The `do` statement executes a statement or a block of statements repeatedly until a specified expression evaluates to `false`. The body of the loop must be enclosed in braces, `{}`, unless it consists of a single statement. In that case, the braces are optional.  
  
## Example  
 In the following example, the `do-while` loop statements execute as long as the variable `x` is less than 5.  
  
 [!code-csharp[csrefKeywordsIteration#1](../../../csharp/language-reference/keywords/codesnippet/CSharp/do_1.cs)]  
  
 Unlike the [while](../../../csharp/language-reference/keywords/while.md) statement, a `do-while` loop is executed one time before the conditional expression is evaluated.  
  
 At any point in the `do-while` block, you can break out of the loop using the [break](../../../csharp/language-reference/keywords/break.md) statement. You can step directly to the `while` expression evaluation statement by using the [continue](../../../csharp/language-reference/keywords/continue.md) statement. If the `while` expression evaluates to true, execution continues at the first statement in the loop. If the expression evaluates to false, execution continues at the first statement after the `do-while` loop.  
  
 A `do-while` loop can also be exited by the [goto](../../../csharp/language-reference/keywords/goto.md), [return](../../../csharp/language-reference/keywords/return.md), or [throw](../../../csharp/language-reference/keywords/throw.md) statements.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [do-while Statement (C++)](/cpp/cpp/do-while-statement-cpp)  
 [Iteration Statements](../../../csharp/language-reference/keywords/iteration-statements.md)
