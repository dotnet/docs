---
title: "do - C# Reference"
ms.custom: seodec18

ms.date: 05/28/2018
f1_keywords: 
  - "do_CSharpKeyword"
  - "do"
helpviewer_keywords: 
  - "do keyword [C#]"
ms.assetid: 50725f79-9ba6-4898-aa78-6e331568a1bb
---
# do (C# Reference)

The `do` statement executes a statement or a block of statements while a specified Boolean expression evaluates to `true`. Because that expression is evaluated after each execution of the loop, a `do-while` loop executes one or more times. This differs from the [while](while.md) loop, which executes zero or more times.

At any point within the `do` statement block, you can break out of the loop by using the [break](break.md) statement.

You can step directly to the evaluation of the `while` expression by using the [continue](continue.md) statement. If the expression evaluates to `true`, execution continues at the first statement in the loop. Otherwise, execution continues at the first statement after the loop.

You also can exit a `do-while` loop by the [goto](goto.md), [return](return.md), or [throw](throw.md) statements.

## Example

The following example shows the usage of the `do` statement. Select **Run** to run the example code. After that you can modify the code and run it again.

[!code-csharp-interactive[do loop example](~/samples/snippets/csharp/keywords/IterationKeywordsExamples.cs#4)]

## C# language specification

For more information, see [The do statement](~/_csharplang/spec/statements.md#the-do-statement) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [while statement](while.md)
