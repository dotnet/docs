---
title: "while (C# Reference) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "while_CSharpKeyword"
  - "while"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "while keyword [C#]"
ms.assetid: 72a0765c-6852-4aca-b327-4a11cb7f5c59
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# while (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The `while` statement executes a statement or a block of statements until a specified expression evaluates to `false`.  
  
## Example  
 [!code-csharp[csrefKeywordsIteration#5](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsIteration/CS/csrefKeywordsIteration.cs#5)]  
  
## Example  
 [!code-csharp[csrefKeywordsIteration#6](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsIteration/CS/csrefKeywordsIteration.cs#6)]  
  
## Example  
 Because the test of the `while` expression takes place before each execution of the loop, a `while` loop executes zero or more times. This differs from the [do](../../../csharp/language-reference/keywords/do.md) loop, which executes one or more times.  
  
 A `while` loop can be terminated when a [break](../../../csharp/language-reference/keywords/break.md), [goto](../../../csharp/language-reference/keywords/goto.md), [return](../../../csharp/language-reference/keywords/return.md), or [throw](../../../csharp/language-reference/keywords/throw.md) statement transfers control outside the loop. To pass control to the next iteration without exiting the loop, use the [continue](../../../csharp/language-reference/keywords/continue.md) statement. Notice the difference in output in the three previous examples, depending on where `int n` is incremented. In the example below no output is generated.  
  
 [!code-csharp[csrefKeywordsIteration#7](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsIteration/CS/csrefKeywordsIteration.cs#7)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [while Statement (C++)](/visual-cpp/cpp/while-statement-cpp)   
 [Iteration Statements](../../../csharp/language-reference/keywords/iteration-statements.md)