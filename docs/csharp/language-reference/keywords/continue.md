---
description: "continue statement - C# Reference"
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

The `continue` statement passes control to the next iteration of the enclosing [iteration statement](../statements/iteration-statements.md) in which it appears.

## Example

In this example, a counter is initialized to count from 1 to 10. By using the `continue` statement in conjunction with the expression `(i < 9)`, the statements between `continue` and the end of the `for` body are skipped in the iterations where `i` is less than 9. In the last two iterations of the `for` loop (where i == 9 and i == 10), the `continue` statement is not executed and the value of `i` is printed to the console.

[!code-csharp[csrefKeywordsJump#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsJump/CS/csrefKeywordsJump.cs#3)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](./index.md)
- [break Statement](/cpp/cpp/break-statement-cpp)
