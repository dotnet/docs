---
title: "while (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "while_CSharpKeyword"
  - "while"
helpviewer_keywords: 
  - "while keyword [C#]"
ms.assetid: 72a0765c-6852-4aca-b327-4a11cb7f5c59
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
---
# while (C# Reference)
The `while` statement executes a statement or a block of statements until a specified expression evaluates to `false`.  
  
## Example  
 [!code-csharp[csrefKeywordsIteration#5](../../../csharp/language-reference/keywords/codesnippet/CSharp/while_1.cs)]  
  
## Example  
 [!code-csharp[csrefKeywordsIteration#6](../../../csharp/language-reference/keywords/codesnippet/CSharp/while_2.cs)]  
  
## Example  
 Because the test of the `while` expression takes place before each execution of the loop, a `while` loop executes zero or more times. This differs from the [do](../../../csharp/language-reference/keywords/do.md) loop, which executes one or more times.  
  
 A `while` loop can be terminated when a [break](../../../csharp/language-reference/keywords/break.md), [goto](../../../csharp/language-reference/keywords/goto.md), [return](../../../csharp/language-reference/keywords/return.md), or [throw](../../../csharp/language-reference/keywords/throw.md) statement transfers control outside the loop. To pass control to the next iteration without exiting the loop, use the [continue](../../../csharp/language-reference/keywords/continue.md) statement. Notice the difference in output in the three previous examples, depending on where `int n` is incremented. In the example below no output is generated.  
  
 [!code-csharp[csrefKeywordsIteration#7](../../../csharp/language-reference/keywords/codesnippet/CSharp/while_3.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [while Statement (C++)](/cpp/cpp/while-statement-cpp)  
 [Iteration Statements](../../../csharp/language-reference/keywords/iteration-statements.md)
