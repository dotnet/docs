---
title: "break statement (C# Reference)"
ms.date: 07/20/2015
f1_keywords: 
  - "break"
  - "break_CSharpKeyword"
helpviewer_keywords: 
  - "break keyword [C#]"
ms.assetid: be2571ed-efb0-4965-b122-81e5b09db0b9
---
# break (C# Reference)

The `break` statement terminates the closest enclosing loop or [switch](../../../csharp/language-reference/keywords/switch.md) statement in which it appears. Control is passed to the statement that follows the terminated statement, if any.

## Example

In this example, the conditional statement contains a counter that is supposed to count from 1 to 100; however, the `break` statement terminates the loop after 4 counts.

[!code-csharp[csrefKeywordsJump#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsJump/CS/csrefKeywordsJump.cs#1)]

## Example

In this example, the `break` statement is used to break out of an inner nested loop, and return control to the outer loop.

[!code-csharp[csrefKeywordsJump#7](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsJump/CS/csrefKeywordsJump.cs#7)]

## Example

This example demonstrates the use of `break` in a [switch](../../../csharp/language-reference/keywords/switch.md) statement.

[!code-csharp[csrefKeywordsJump#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsJump/CS/csrefKeywordsJump.cs#2)]

If you entered `4`, the output would be:

```console
Enter your selection (1, 2, or 3): 4
Sorry, invalid selection.
```

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See Also

- [C# Reference](../../../csharp/language-reference/index.md)  
- [C# Programming Guide](../../../csharp/programming-guide/index.md)  
- [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
- [switch](../../../csharp/language-reference/keywords/switch.md)  
- [Jump Statements](../../../csharp/language-reference/keywords/jump-statements.md)  
- [Iteration Statements](../../../csharp/language-reference/keywords/iteration-statements.md)
