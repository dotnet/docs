---
title: "while - C# Reference"
ms.custom: seodec18

ms.date: 05/28/2018
f1_keywords: 
  - "while_CSharpKeyword"
  - "while"
helpviewer_keywords: 
  - "while keyword [C#]"
ms.assetid: 72a0765c-6852-4aca-b327-4a11cb7f5c59
---
# while (C# Reference)

The `while` statement executes a statement or a block of statements while a specified Boolean expression evaluates to `true`. Because that expression is evaluated before each execution of the loop, a `while` loop executes zero or more times. This differs from the [do](do.md) loop, which executes one or more times.

At any point within the `while` statement block, you can break out of the loop by using the [break](break.md) statement.

You can step directly to the evaluation of the `while` expression by using the [continue](continue.md) statement. If the expression evaluates to `true`, execution continues at the first statement in the loop. Otherwise, execution continues at the first statement after the loop.

You also can exit a `while` loop by the [goto](goto.md), [return](return.md), or [throw](throw.md) statements.

## Example

The following example shows the usage of the `while` statement. Select **Run** to run the example code. After that you can modify the code and run it again.

[!code-csharp-interactive[while loop example](~/samples/snippets/csharp/keywords/IterationKeywordsExamples.cs#3)]

## C# language specification

For more information, see [The while statement](~/_csharplang/spec/statements.md#the-while-statement) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)  
- [C# Programming Guide](../../programming-guide/index.md)  
- [C# Keywords](index.md)  
- [Iteration Statements](iteration-statements.md)  
- [do statement](do.md)  
