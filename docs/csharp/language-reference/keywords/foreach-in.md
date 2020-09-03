---
description: "foreach, in (C# reference)"
title: C# foreach statement
ms.date: 07/22/2020
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

The `foreach` statement executes a statement or a block of statements for each element in an instance of the type that implements the <xref:System.Collections.IEnumerable?displayProperty=nameWithType> or <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> interface, as the following example shows:

:::code language="csharp" source="snippets/IterationKeywordsExamples.cs" id="1" interactive="try-dotnet-method" :::

The `foreach` statement isn't limited to those types. You can use it with an instance of any type that satisfies the following conditions:

- a type has the public parameterless `GetEnumerator` method whose return type is either class, struct, or interface type,
- the return type of the `GetEnumerator` method has the public `Current` property and the public parameterless `MoveNext` method whose return type is <xref:System.Boolean>.

The following example uses the `foreach` statement with an instance of the <xref:System.Span%601?displayProperty=nameWithType> type, which doesn't implement any interfaces:

:::code language="csharp" source="snippets/IterationKeywordsExamples.cs" id="2" :::

Beginning with C# 7.3, if the enumerator's `Current` property returns a [reference return value](ref.md#reference-return-values) (`ref T` where `T` is the type of a collection element), you can declare an iteration variable with the `ref` or `ref readonly` modifier, as the following example shows:

:::code language="csharp" source="snippets/IterationKeywordsExamples.cs" id="RefSpan" :::

Beginning with C# 8.0, you can use the `await foreach` statement to consume an asynchronous stream of data, that is, the collection type that implements the <xref:System.Collections.Generic.IAsyncEnumerable%601> interface. Each iteration of the loop may be suspended while the next element is retrieved asynchronously. The following example shows how to use the `await foreach` statement:

:::code language="csharp" source="snippets/IterationKeywordsExamples.cs" id="AwaitForeach" :::

By default, stream elements are processed in the captured context. If you want to disable capturing of the context, use the <xref:System.Threading.Tasks.TaskAsyncEnumerableExtensions.ConfigureAwait%2A?displayProperty=nameWithType> extension method. For more information about synchronization contexts and capturing the current context, see [Consuming the Task-based asynchronous pattern](../../../standard/asynchronous-programming-patterns/consuming-the-task-based-asynchronous-pattern.md). For more information about asynchronous streams, see the [Asynchronous streams](../../whats-new/csharp-8.md#asynchronous-streams) section of the [What's new in C# 8.0](../../whats-new/csharp-8.md) article.

At any point within the `foreach` statement block, you can break out of the loop by using the [break](break.md) statement, or step to the next iteration in the loop by using the [continue](continue.md) statement. You can also exit a `foreach` loop by the [goto](goto.md), [return](return.md), or [throw](throw.md) statements.

If the `foreach` statement is applied to `null`, a <xref:System.NullReferenceException> is thrown. If the source collection of the `foreach` statement is empty, the body of the `foreach` loop isn't executed and skipped.

## Type of an iteration variable

You can use the `var` keyword to let the compiler infer the type of an iteration variable in the `foreach` statement, as the following code shows:

```csharp
foreach (var item in collection) { }
```

You can also explicitly specify the type of an iteration variable, as the following code shows:

```csharp
IEnumerable<T> collection = new T[5];
foreach (V item in collection) { }
```

In the preceding form, type `T` of a collection element must be implicitly or explicitly convertible to type `V` of an iteration variable. If an explicit conversion from `T` to `V` fails at run time, the `foreach` statement throws an <xref:System.InvalidCastException>. For example, if `T` is a non-sealed class type, `V` can be any interface type, even the one that `T` doesn't implement. At run time, the type of a collection element may be the one that derives from `T` and actually implements `V`. If that's not the case, an <xref:System.InvalidCastException> is thrown.

## C# language specification

For more information, see [The foreach statement](~/_csharplang/spec/statements.md#the-foreach-statement) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# keywords](index.md)
- [Using foreach with arrays](../../programming-guide/arrays/using-foreach-with-arrays.md)
- [for statement](for.md)
