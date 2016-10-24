---
title: "foreach, in (C# Reference)"
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
  - "foreach"
  - "foreach_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "foreach keyword [C#]"
  - "foreach statement [C#]"
  - "in keyword [C#]"
ms.assetid: 5a9c5ddc-5fd3-457a-9bb6-9abffcd874ec
caps.latest.revision: 29
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
# foreach, in (C# Reference)
The `foreach` statement repeats a group of embedded statements for each element in an array or an object collection that implements the <xref:System.Collections.IEnumerable?displayProperty=fullName> or <xref:System.Collections.Generic.IEnumerable`1?displayProperty=fullName> interface. The `foreach` statement is used to iterate through the collection to get the information that you want, but can not be used to add or remove items from the source collection to avoid unpredictable side effects. If you need to add or remove items from the source collection, use a [for](../keywords/for--csharp-reference-.md) loop.  
  
 The embedded statements continue to execute for each element in the array or collection. After the iteration has been completed for all the elements in the collection, control is transferred to the next statement following the `foreach` block.  
  
 At any point within the `foreach` block, you can break out of the loop by using the [break](../keywords/break--csharp-reference-.md) keyword, or step to the next iteration in the loop by using the [continue](../keywords/continue--csharp-reference-.md) keyword.  
  
 A `foreach` loop can also be exited by the [goto](../keywords/goto--csharp-reference-.md), [return](../keywords/return--csharp-reference-.md), or [throw](../keywords/throw--csharp-reference-.md) statements.  
  
 For more information about the `foreach` keyword and code samples, see the following topics:  
  
 [Using foreach with Arrays](../arrays/using-foreach-with-arrays--csharp-programming-guide-.md)  
  
 [How to: Access a Collection Class with foreach](../classes-and-structs/how-to--access-a-collection-class-with-foreach--csharp-programming-guide-.md)  
  
## Example  
 The following code shows three examples:  
  
-   a typical `foreach` loop that displays the contents of an array of integers  
  
-   a [for](../keywords/for--csharp-reference-.md) loop that does the same thing  
  
-   a `foreach` loop that maintains a count of the number of elements in the array  
  
 [!code[csrefKeywordsIteration#4](../keywords/codesnippet/CSharp/foreach--in--csharp-reference-_1.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Iteration Statements](../keywords/iteration-statements--csharp-reference-.md)   
 [for](../keywords/for--csharp-reference-.md)