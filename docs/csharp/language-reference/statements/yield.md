---
title: "yield statement - provide the next element in an iterator"
description: "Use the yield statement in iterators to provide the next value or signal the end of an iteration"
ms.date: 06/28/2024
f1_keywords: 
  - "yield"
  - "yield_CSharpKeyword"
helpviewer_keywords: 
  - "yield keyword [C#]"
---
# yield statement - provide the next element

You use the `yield` statement in an [iterator](../../iterators.md) to provide the next value or signal the end of an iteration. The `yield` statement has the two following forms:

- `yield return`: to provide the next value in iteration, as the following example shows:

  :::code language="csharp" interactive="try-dotnet-method" source="snippets/yield/Program.cs" id="YieldReturn":::

- `yield break`: to explicitly signal the end of iteration, as the following example shows:

  :::code language="csharp" interactive="try-dotnet-method" source="snippets/yield/Program.cs" id="YieldBreak":::

  Iteration also finishes when control reaches the end of an iterator.

In the preceding examples, the return type of iterators is <xref:System.Collections.Generic.IEnumerable%601> (in nongeneric cases, use <xref:System.Collections.IEnumerable> as the return type of an iterator). You can also use <xref:System.Collections.Generic.IAsyncEnumerable%601> as the return type of an iterator. That makes an iterator async. Use the [`await foreach` statement](iteration-statements.md#await-foreach) to iterate over iterator's result, as the following example shows:

:::code language="csharp" source="snippets/yield/Program.cs" id="IteratorAsync":::

<xref:System.Collections.Generic.IEnumerator%601> or <xref:System.Collections.IEnumerator> can also be the return type of an iterator. Use those return types when you implement the `GetEnumerator` method in the following scenarios:

- You design the type that implements <xref:System.Collections.Generic.IEnumerable%601> or <xref:System.Collections.IEnumerable> interface.
- You add an instance or [extension](../../programming-guide/classes-and-structs/extension-methods.md) `GetEnumerator` method to enable iteration over the type's instance with the [`foreach` statement](iteration-statements.md#the-foreach-statement), as the following example shows:

  :::code language="csharp" source="snippets/yield/GetEnumeratorExample.cs" id="GetEnumeratorExample":::

You can't use the `yield` statements in:

- methods with [in](../keywords/method-parameters.md#in-parameter-modifier), [ref](../keywords/ref.md), or [out](../keywords/method-parameters.md#out-parameter-modifier) parameters
- [lambda expressions](../operators/lambda-expressions.md) and [anonymous methods](../operators/delegate-operator.md)
- [unsafe blocks](../keywords/unsafe.md). Before C# 13, `yield` was invalid in any method with an `unsafe` block. Beginning with C# 13, you can use `yield` in methods with `unsafe` blocks, but not in the `unsafe` block.
- `yield return` and `yield break` can not be used in [try](../statements/exception-handling-statements.md), [catch](../statements/exception-handling-statements.md) and [finally](../statements/exception-handling-statements.md) blocks.

## Execution of an iterator

The call of an iterator doesn't execute it immediately, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/yield/Program.cs" id="IteratorExecution":::

As the preceding example shows, when you start to iterate over an iterator's result, an iterator is executed until the first `yield return` statement is reached. Then, the execution of an iterator is suspended and the caller gets the first iteration value and processes it. On each subsequent iteration, the execution of an iterator resumes after the `yield return` statement that caused the previous suspension and continues until the next `yield return` statement is reached. The iteration completes when control reaches the end of an iterator or a `yield break` statement.

## C# language specification

For more information, see [The yield statement](~/_csharpstandard/standard/statements.md#1315-the-yield-statement) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [Iterators](../../iterators.md)
- [Iterate through collections in C#](../../programming-guide/concepts/iterators.md)
- [foreach](iteration-statements.md#the-foreach-statement)
- [await foreach](iteration-statements.md#await-foreach)
