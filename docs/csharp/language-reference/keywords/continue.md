---
title: "continue statement - C# Reference"
ms.date: 07/20/2015
f1_keywords: 
  - "continue_CSharpKeyword"
  - "continue"
helpviewer_keywords: 
  - "continue keyword [C#]"
ms.assetid: 8a5ac96f-f98a-4519-b32d-345847ed7be0
---
# continue (C# Reference)

The `continue` statement passes control to the next iteration of the enclosing [while](./while.md), [do](./do.md), [for](./for.md), or [foreach](./foreach-in.md) statement in which it appears.

## Example

In this example, a counter is initialized to count from 1 to 10. By using the `continue` statement in conjunction with the expression `(i < 9)`, the statements between `continue` and the end of the `for` body are skipped.

[!code-csharp[csrefKeywordsJump#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsJump/CS/csrefKeywordsJump.cs#3)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](./index.md)
- [break Statement](/cpp/cpp/break-statement-cpp)
