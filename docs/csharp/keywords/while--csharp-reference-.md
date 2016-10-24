---
title: "while (C# Reference)"
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
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# while (C# Reference)
The `while` statement executes a statement or a block of statements until a specified expression evaluates to `false`.  
  
## Example  
 [!code[csrefKeywordsIteration#5](../keywords/codesnippet/CSharp/while--csharp-reference-_1.cs)]  
  
## Example  
 [!code[csrefKeywordsIteration#6](../keywords/codesnippet/CSharp/while--csharp-reference-_2.cs)]  
  
## Example  
 Because the test of the `while` expression takes place before each execution of the loop, a `while` loop executes zero or more times. This differs from the [do](../keywords/do--csharp-reference-.md) loop, which executes one or more times.  
  
 A `while` loop can be terminated when a [break](../keywords/break--csharp-reference-.md), [goto](../keywords/goto--csharp-reference-.md), [return](../keywords/return--csharp-reference-.md), or [throw](../keywords/throw--csharp-reference-.md) statement transfers control outside the loop. To pass control to the next iteration without exiting the loop, use the [continue](../keywords/continue--csharp-reference-.md) statement. Notice the difference in output in the three previous examples, depending on where `int n` is incremented. In the example below no output is generated.  
  
 [!code[csrefKeywordsIteration#7](../keywords/codesnippet/CSharp/while--csharp-reference-_3.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [while Statement (C++)](../Topic/while%20Statement%20\(C++\).md)   
 [Iteration Statements](../keywords/iteration-statements--csharp-reference-.md)