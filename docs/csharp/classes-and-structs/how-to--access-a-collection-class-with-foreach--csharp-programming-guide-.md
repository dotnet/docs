---
title: "How to: Access a Collection Class with foreach (C# Programming Guide)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "collection classes [C#], foreach statement"
ms.assetid: a6b9cf5c-6c8d-4223-b12c-288949434493
caps.latest.revision: 21
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
# How to: Access a Collection Class with foreach (C# Programming Guide)
The following code example illustrates how to write a non-generic collection class that can be used with [foreach](../keywords/foreach--in--csharp-reference-.md). The example defines a string tokenizer class.  
  
> [!NOTE]
>  This example represents recommended practice only when you cannot use a generic collection class. For an example of how to implement a type-safe generic collection class that supports <xref:System.Collections.Generic.IEnumerable`1>, see [Iterators](../Topic/Iterators%20\(C%23%20and%20Visual%20Basic\).md).  
  
 In the example, the following code segment uses the `Tokens` class to break the sentence "This is a sample sentence." into tokens by using ' ' and '-' as separators. The code then displays those tokens by using a `foreach` statement.  
  
 [!code[csProgGuideCollections#3](../classes-and-structs/codesnippet/CSharp/how-to--access-a-collection-class-with-foreach--csharp-programming-guide-_1.cs)]  
  
## Example  
 Internally, the `Tokens` class uses an array to store the tokens. Because arrays implement <xref:System.Collections.IEnumerator> and <xref:System.Collections.IEnumerable>, the code example could have used the array's enumeration methods (<xref:System.Collections.IEnumerable.GetEnumerator*>, <xref:System.Collections.IEnumerator.MoveNext*>, <xref:System.Collections.IEnumerator.Reset*>, and <xref:System.Collections.IEnumerator.Current*>) instead of defining them in the `Tokens` class. The method definitions are included in the example to clarify how they are defined and what each does.  
  
 [!code[csProgGuideCollections#2](../classes-and-structs/codesnippet/CSharp/how-to--access-a-collection-class-with-foreach--csharp-programming-guide-_2.cs)]  
  
 In C#, it is not necessary for a collection class to implement <xref:System.Collections.IEnumerable> and <xref:System.Collections.IEnumerator> to be compatible with `foreach`. If the class has the required <xref:System.Collections.IEnumerable.GetEnumerator*>, <xref:System.Collections.IEnumerator.MoveNext*>, <xref:System.Collections.IEnumerator.Reset*>, and <xref:System.Collections.IEnumerator.Current*> members, it will work with `foreach`. Omitting the interfaces has the advantage of enabling you to define a return type for `Current` that is more specific than <xref:System.Object>. This provides type safety.  
  
 For example, change the following lines in the previous example.  
  
<CodeContentPlaceHolder>0</CodeContentPlaceHolder>  
 Because `Current` returns a string, the compiler can detect when an incompatible type is used in a `foreach` statement, as shown in the following code.  
  
<CodeContentPlaceHolder>1</CodeContentPlaceHolder>  
 The disadvantage of omitting <xref:System.Collections.IEnumerable> and <xref:System.Collections.IEnumerator> is that the collection class is no longer interoperable with the `foreach` statements, or equivalent statements, of other common language runtime languages.  
  
## See Also  
 <xref:System.Collections.Generic>   
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Arrays](../arrays/arrays--csharp-programming-guide-.md)   
 [Collections](../Topic/Collections%20\(C%23%20and%20Visual%20Basic\).md)