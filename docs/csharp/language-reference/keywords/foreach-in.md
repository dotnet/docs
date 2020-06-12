---
title: C# foreach statement
ms.date: 06/03/2020
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

The `foreach` statement executes a statement or a block of statements for each element in an instance of the type that implements the <xref:System.Collections.IEnumerable?displayProperty=nameWithType> or <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> interface. The `foreach` statement isn't limited to those types and can be applied to an instance of any type that satisfies the following conditions:

- has the public parameterless `GetEnumerator` method whose return type is either class, struct, or interface type,
- the return type of the `GetEnumerator` method has the public `Current` property and the public parameterless `MoveNext` method whose return type is <xref:System.Boolean>.

In most uses, `foreach` iterates an `IEnumerable<T>` expression where each element is of type `T`. However, the elements may be any type that has an implicit or explicit conversion from the type of the `Current` property. If the `Current` property returns `SomeType`, the type of the elements may be:

- Any of the base classes of `SomeType`.
- Any of the interfaces implemented by `SomeType`.

Furthermore, if `SomeType` is a `class` or an `interface` and not `sealed`, the type of elements may include:

- Any type derived from `SomeType`.
- Any arbitrary interface. Any interface is allowed because any interface may be implemented by a class derived from or implementing `SomeType`.

You may declare the iteration variable using any type that matches the preceding rules. If the conversion from `SomeType` to the type of the iteration variable requires an explicit cast, that operation may throw an <xref:System.InvalidCastException> when the conversion fails.

Beginning with C# 7.3, if the enumerator's `Current` property returns a [reference return value](ref.md#reference-return-values) (`ref T` where `T` is the type of the collection element), you can declare the iteration variable with the `ref` or `ref readonly` modifier.

Beginning with C# 8.0, the `await` operator may be applied to the `foreach` statement when the collection type implements the <xref:System.Collections.Generic.IAsyncEnumerable%601> interface. Each iteration of the loop may be suspended while the next element is retrieved asynchronously. By default, stream elements are processed in the captured context. If you want to disable capturing of the context, use the <xref:System.Threading.Tasks.TaskAsyncEnumerableExtensions.ConfigureAwait%2A?displayProperty=nameWithType> extension method. For more information about synchronization contexts and capturing the current context, see the article on [consuming the Task-based asynchronous pattern](../../../standard/asynchronous-programming-patterns/consuming-the-task-based-asynchronous-pattern.md).

At any point within the `foreach` statement block, you can break out of the loop by using the [break](break.md) statement, or step to the next iteration in the loop by using the [continue](continue.md) statement. You can also exit a `foreach` loop by the [goto](goto.md), [return](return.md), or [throw](throw.md) statements.

If the `foreach` statement is applied to `null`, a <xref:System.NullReferenceException> is thrown. If the source collection of the `foreach` statement is empty, the body of the `foreach` loop isn't executed and skipped.

## Examples

[!INCLUDE[interactive-note](~/includes/csharp-interactive-note.md)]

The following example shows usage of the `foreach` statement with an instance of the <xref:System.Collections.Generic.List%601> type that implements the <xref:System.Collections.Generic.IEnumerable%601> interface:

:::code language="csharp" source="snippets/IterationKeywordsExamples.cs" id="1" interactive="try-dotnet-method" :::

The next example uses the `foreach` statement with an instance of the <xref:System.Span%601?displayProperty=nameWithType> type, which doesn't implement any interfaces:

:::code language="csharp" source="snippets/IterationKeywordsExamples.cs" id="2" :::

The following example uses a `ref` iteration variable to set the value of each item in a stackalloc array. The `ref readonly` version iterates the collection to print all the values. The `readonly` declaration uses an implicit local variable declaration. Implicit variable declarations can be used with either `ref` or `ref readonly` declarations, as can explicitly typed variable declarations.

:::code language="csharp" source="snippets/IterationKeywordsExamples.cs" id="RefSpan" :::

The following example uses `await foreach` to iterate a collection that generates each element asynchronously:

:::code language="csharp" source="snippets/IterationKeywordsExamples.cs" id="AwaitForeach"  :::

## C# language specification

For more information, see [The foreach statement](~/_csharplang/spec/statements.md#the-foreach-statement) section of the [C# language specification](/dotnet/csharp/language-reference/language-specification/introduction).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Using foreach with arrays](../../programming-guide/arrays/using-foreach-with-arrays.md)
- [for statement](for.md)
