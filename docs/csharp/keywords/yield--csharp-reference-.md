---
title: "yield (C# Reference)"
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
  - "yield"
  - "yield_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "yield keyword [C#]"
ms.assetid: 1089194f-9e53-46a2-8642-53ccbe9d414d
caps.latest.revision: 46
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
# yield (C# Reference)
When you use the `yield` keyword in a statement, you indicate that the method, operator, or `get` accessor in which it appears is an iterator. Using `yield` to define an iterator removes the need for an explicit extra class (the class that holds the state for an enumeration, see <xref:System.Collections.Generic.IEnumerator`1> for an example) when you implement the <xref:System.Collections.IEnumerable> and <xref:System.Collections.IEnumerator> pattern for a custom collection type.  
  
 The following example shows the two forms of the `yield` statement.  
  
<CodeContentPlaceHolder>0</CodeContentPlaceHolder>  
## Remarks  
 You use a `yield return` statement to return each element one at a time.  
  
 You consume an iterator method by using a [foreach](../keywords/foreach--in--csharp-reference-.md) statement or LINQ query. Each iteration of the `foreach` loop calls the iterator method. When a `yield return` statement is reached in the iterator method, `expression` is returned, and the current location in code is retained. Execution is restarted from that location the next time that the iterator function is called.  
  
 You can use a `yield break` statement to end the iteration.  
  
 For more information about iterators, see [Iterators](../Topic/Iterators%20\(C%23%20and%20Visual%20Basic\).md).  
  
## Iterator Methods and get Accessors  
 The declaration of an iterator must meet the following requirements:  
  
-   The return type must be <xref:System.Collections.IEnumerable>, <xref:System.Collections.Generic.IEnumerable`1>, <xref:System.Collections.IEnumerator>, or <xref:System.Collections.Generic.IEnumerator`1>.  
  
-   The declaration can't have any [ref](../keywords/ref--csharp-reference-.md) or [out](../keywords/out--csharp-reference-.md) parameters.  
  
 The `yield` type of an iterator that returns <xref:System.Collections.IEnumerable> or <xref:System.Collections.IEnumerator> is `object`.  If the iterator returns <xref:System.Collections.Generic.IEnumerable`1> or <xref:System.Collections.Generic.IEnumerator`1>, there must be an implicit conversion from the type of the expression in the `yield return` statement to the generic type parameter .  
  
 You can't include a `yield return` or `yield break` statement in methods that have the following characteristics:  
  
-   Anonymous methods. For more information, see [Anonymous Methods](../statements-expressions-operators/anonymous-methods--csharp-programming-guide-.md).  
  
-   Methods that contain unsafe blocks. For more information, see [unsafe](../keywords/unsafe--csharp-reference-.md).  
  
## Exception Handling  
 A `yield return` statement can't be located in a try-catch block. A `yield return` statement can be located in the try block of a try-finally statement.  
  
 A `yield break` statement can be located in a try block or a catch block but not a finally block.  
  
 If the `foreach` body (outside of the iterator method) throws an exception, a `finally` block in the iterator method is executed.  
  
## Technical Implementation  
 The following code returns an `IEnumerable<string>` from an iterator method and then iterates through its elements.  
  
<CodeContentPlaceHolder>1</CodeContentPlaceHolder>  
 The call to `MyIteratorMethod` doesn't execute the body of the method. Instead the call returns an `IEnumerable<string>` into the `elements` variable.  
  
 On an iteration of the `foreach` loop, the <xref:System.Collections.IEnumerator.MoveNext*> method is called for `elements`. This call executes the body of `MyIteratorMethod` until the next `yield return` statement is reached. The expression returned by the `yield return` statement determines not only the value of the `element` variable for consumption by the loop body but also the <xref:System.Collections.Generic.IEnumerator`1.Current*> property of elements, which is an `IEnumerable<string>`.  
  
 On each subsequent iteration of the `foreach` loop, the execution of the iterator body continues from where it left off, again stopping when it reaches a `yield return` statement. The `foreach` loop completes when the end of the iterator method or a `yield break` statement is reached.  
  
## Example  
 The following example has a `yield return` statement that's inside a `for` loop. Each iteration of the `foreach` statement body in `Process` creates a call to the `Power` iterator function. Each call to the iterator function proceeds to the next execution of the `yield return` statement, which occurs during the next iteration of the `for` loop.  
  
 The return type of the iterator method is <xref:System.Collections.IEnumerable>, which is an iterator interface type. When the iterator method is called, it returns an enumerable object that contains the powers of a number.  
  
 [!code[csrefKeywordsContextual#5](../keywords/codesnippet/CSharp/yield--csharp-reference-_1.cs)]  
  
## Example  
 The following example demonstrates a `get` accessor that is an iterator. In the example, each `yield return` statement returns an instance of a user-defined class.  
  
 [!code[csrefKeywordsContextual#21](../keywords/codesnippet/CSharp/yield--csharp-reference-_2.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [foreach, in](../keywords/foreach--in--csharp-reference-.md)   
 [Iterators](../Topic/Iterators%20\(C%23%20and%20Visual%20Basic\).md)