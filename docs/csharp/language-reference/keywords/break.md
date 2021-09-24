---
description: "break statement - C# Reference"
title: "break statement - C# Reference"
ms.date: 07/20/2015
f1_keywords: 
  - "break"
  - "break_CSharpKeyword"
helpviewer_keywords: 
  - "break keyword [C#]"
ms.assetid: be2571ed-efb0-4965-b122-81e5b09db0b9
---
# break (C# Reference)

The `break` statement terminates the closest enclosing loop or [`switch` statement](../statements/selection-statements.md#the-switch-statement) in which it appears. Control is passed to the statement that follows the terminated statement, if any.

## Example 1

In this example, the conditional statement contains a counter that is supposed to count from 1 to 100; however, the `break` statement terminates the loop after 4 counts.

[!code-csharp[csrefKeywordsJump#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsJump/CS/csrefKeywordsJump.cs#1)]

## Example 2

This example demonstrates the use of `break` in a `switch` statement.

[!code-csharp[csrefKeywordsJump#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsJump/CS/csrefKeywordsJump.cs#2)]

If you entered `4`, the output would be:

```console
Enter your selection (1, 2, or 3): 4
Sorry, invalid selection.
```

## Example 3

In this example, the `break` statement is used to break out of an inner nested loop, and return control to the outer loop. Control is _only_ returned one level up in the nested loops.

[!code-csharp[csrefKeywordsJump#7](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsJump/CS/csrefKeywordsJump.cs#7)]

## Example 4

In this example, the `break` statement is only used to break out of the current branch during each iteration of the loop. The loop itself is unaffected by the instances of `break` that belong to the nested `switch` statement.

[!code-csharp[csrefKeywordsJump#8](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsJump/CS/csrefKeywordsJump.cs#8)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](./index.md)
- [`switch` statement](../statements/selection-statements.md#the-switch-statement)
