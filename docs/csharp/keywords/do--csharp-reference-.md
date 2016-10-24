---
title: "do (C# Reference)"
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
  - "do_CSharpKeyword"
  - "do"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "do keyword [C#]"
ms.assetid: 50725f79-9ba6-4898-aa78-6e331568a1bb
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
# do (C# Reference)
The `do` statement executes a statement or a block of statements repeatedly until a specified expression evaluates to `false`. The body of the loop must be enclosed in braces, `{}`, unless it consists of a single statement. In that case, the braces are optional.  
  
## Example  
 In the following example, the `do-while` loop statements execute as long as the variable `x` is less than 5.  
  
 [!code[csrefKeywordsIteration#1](../keywords/codesnippet/CSharp/do--csharp-reference-_1.cs)]  
  
 Unlike the [while](../keywords/while--csharp-reference-.md) statement, a `do-while` loop is executed one time before the conditional expression is evaluated.  
  
 At any point in the `do-while` block, you can break out of the loop using the [break](../keywords/break--csharp-reference-.md) statement. You can step directly to the `while` expression evaluation statement by using the [continue](../keywords/continue--csharp-reference-.md) statement. If the `while` expression evaluates to true, execution continues at the first statement in the loop. If the expression evaluates to false, execution continues at the first statement after the `do-while` loop.  
  
 A `do-while` loop can also be exited by the [goto](../keywords/goto--csharp-reference-.md), [return](../keywords/return--csharp-reference-.md), or [throw](../keywords/throw--csharp-reference-.md) statements.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [do-while Statement (C++)](../Topic/do-while%20Statement%20\(C++\).md)   
 [Iteration Statements](../keywords/iteration-statements--csharp-reference-.md)