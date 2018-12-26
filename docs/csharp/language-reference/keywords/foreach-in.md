---
title: C# foreach statement
ms.date: 06/29/2018
f1_keywords:
  - "foreach"
  - "foreach_CSharpKeyword"
helpviewer_keywords:
  - "foreach keyword [C#]"
  - "foreach statement [C#]"
  - "in keyword [C#]"
ms.assetid: 5a9c5ddc-5fd3-457a-9bb6-9abffcd874ec
---
# foreach, in (C# reference)

The `foreach` statement executes a statement or a block of statements for each element in an instance of the type that implements the <xref:System.Collections.IEnumerable?displayProperty=nameWithType> or <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> interface. The `foreach` statement is not limited to those types and can be applied to an instance of any type that satisfies the following conditions:

- has the public parameterless `GetEnumerator` method whose return type is either class, struct, or interface type,
- the return type of the `GetEnumerator` method has the public `Current` property and the public parameterless `MoveNext` method whose return type is <xref:System.Boolean>.

Beginning with C# 7.3, if the enumerator's `Current` property returns a [reference return value](ref.md#reference-return-values) (`ref T` where `T` is the type of the collection element), you can declare the iteration variable with the `ref` or `ref readonly` modifier.

At any point within the `foreach` statement block, you can break out of the loop by using the [break](break.md) statement, or step to the next iteration in the loop by using the [continue](continue.md) statement. You also can exit a `foreach` loop by the [goto](goto.md), [return](return.md), or [throw](throw.md) statements.

## Examples

[!INCLUDE[interactive-note](~/includes/csharp-interactive-note.md)]

The following example shows usage of the `foreach` statement with an instance of the <xref:System.Collections.Generic.List%601> type that implements the <xref:System.Collections.Generic.IEnumerable%601> interface:

[!code-csharp-interactive[list example](~/samples/snippets/csharp/keywords/IterationKeywordsExamples.cs#1)]

The next example uses the `foreach` statement with an instance of the <xref:System.Span%601?displayProperty=nameWithType> type, which doesn't implement any interfaces:

[!code-csharp-interactive[span example](~/samples/snippets/csharp/keywords/IterationKeywordsExamples.cs#2)]

The following example uses a `ref` iteration variable to set the value of each item in a stackalloc array. The `ref readonly` version iterates the collection to print all the values. The `readonly` declaration uses an implicit local variable declaration. Implicit variable declarations can be used with either `ref` or `ref readonly` declarations, as can explicitly typed variable declarations.

[!code-csharp-interactive[ref span example](~/samples/snippets/csharp/keywords/IterationKeywordsExamples.cs#RefSpan)]

## C# language specification

For more information, see [The foreach statement](~/_csharplang/spec/statements.md#the-foreach-statement) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Iteration Statements](iteration-statements.md)
- [Using foreach with arrays](../../programming-guide/arrays/using-foreach-with-arrays.md)
- [for statement](for.md)
