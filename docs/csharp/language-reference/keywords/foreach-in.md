---
title: "foreach, in (C# Reference)"
ms.date: 10/11/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "foreach"
  - "foreach_CSharpKeyword"
helpviewer_keywords: 
  - "foreach keyword [C#]"
  - "foreach statement [C#]"
  - "in keyword [C#]"
ms.assetid: 5a9c5ddc-5fd3-457a-9bb6-9abffcd874ec
caps.latest.revision: 29
author: "BillWagner"
ms.author: "wiwagn"
---
# foreach, in (C# Reference)
The `foreach` statement repeats a group of embedded statements for each element in an array or an object collection that implements the <xref:System.Collections.IEnumerable?displayProperty=nameWithType> or <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> interface. The `foreach` statement is used to iterate through the collection to get the information that you want, but can not be used to add or remove items from the source collection to avoid unpredictable side effects. If you need to add or remove items from the source collection, use a [for](for.md) loop.
  
 The embedded statements continue to execute for each element in the array or collection. After the iteration has been completed for all the elements in the collection, control is transferred to the next statement following the `foreach` block.
  
 At any point within the `foreach` block, you can break out of the loop by using the [break](break.md) keyword, or step to the next iteration in the loop by using the [continue](continue.md) keyword.

 A `foreach` loop can also be exited by the [goto](goto.md), [return](return.md), or [throw](throw.md) statements.

 For more information about the `foreach` keyword and code samples, see the following topics:  

 [Using foreach with Arrays](../../programming-guide/arrays/using-foreach-with-arrays.md)  

 [How to: Access a Collection Class with foreach](../../programming-guide/classes-and-structs/how-to-access-a-collection-class-with-foreach.md)  

## Example
 The following code shows three examples.

> [!TIP]
> You can modify the examples to experiment with the syntax and try different
> usages that are more similar to your use case. Press "Run" to run the code,
> then edit and press "Run" again.

-   a typical `foreach` loop that displays the contents of an array of integers

[!code-csharp-interactive[csrefKeywordsIteration#4](./codesnippet/CSharp/foreach-in_1.cs#L12-L26)]

-   a [for](../../../csharp/language-reference/keywords/for.md) loop that does the same thing

[!code-csharp-interactive[csrefKeywordsIteration#4](./codesnippet/CSharp/foreach-in_1.cs#L31-L46)]

-   a `foreach` loop that maintains a count of the number of elements in the array

[!code-csharp-interactive[csrefKeywordsIteration#4](./codesnippet/CSharp/foreach-in_1.cs#L51-L69)]
 
## C# Language Specification
[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See Also  

[C# Reference](../index.md)

[C# Programming Guide](../../programming-guide/index.md)

[C# Keywords](index.md)

[Iteration Statements](iteration-statements.md)

[for](for.md)
