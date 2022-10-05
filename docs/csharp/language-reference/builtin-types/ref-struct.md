---
title: "ref struct types - C# reference"
description: Learn about the ref struct type in C#
ms.date: 09/15/2022
---
# `ref` structure types (C# reference)

You can use the `ref` modifier in the declaration of a [structure type](struct.md). Instances of a `ref struct` type are allocated on the stack and can't escape to the managed heap. To ensure that, the compiler limits the usage of `ref struct` types as follows:

- A `ref struct` can't be the element type of an array.
- A `ref struct` can't be a declared type of a field of a class or a non-`ref struct`.
- A `ref struct` can't implement interfaces.
- A `ref struct` can't be boxed to <xref:System.ValueType?displayProperty=nameWithType> or <xref:System.Object?displayProperty=nameWithType>.
- A `ref struct` can't be a type argument.
- A `ref struct` variable can't be captured by a [lambda expression](../operators/lambda-expressions.md) or a [local function](../../programming-guide/classes-and-structs/local-functions.md).
- A `ref struct` variable can't be used in an [`async`](../keywords/async.md) method. However, you can use `ref struct` variables in synchronous methods, for example, in methods that return <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601>.
- A `ref struct` variable can't be used in [iterators](../../iterators.md).

You can define a disposable `ref struct`. To do that, ensure that a `ref struct` fits the [disposable pattern](~/_csharplang/proposals/csharp-8.0/using.md#pattern-based-using). That is, it has an instance or extension `Dispose` method, which is accessible, parameterless and has a `void` return type.

Beginning with C# 11, a `ref struct` may contain `ref` fields. To declare a `ref` field, use the same syntax as for declaring a [`ref` local variable](../statements/declarations.md#ref-locals). A `ref` field may be reassigned after it's initialized. The compiler ensures that a reference stored in a `ref` field doesn't outlive the value to which it refers. For information about the scope rules, see the [Scope of reference and values](../keywords/method-parameters.md#scope-of-references-and-values) section of the [Method parameters](../keywords/method-parameters.md) article.

Typically, you define a `ref struct` type when you need a type that also includes data members of `ref struct` types:

:::code language="csharp" source="snippets/shared/StructType.cs" id="SnippetRefStruct":::

To declare a `ref struct` as `readonly`, combine the `readonly` and `ref` modifiers in the type declaration (the `readonly` modifier must come before the `ref` modifier):

:::code language="csharp" source="snippets/shared/StructType.cs" id="SnippetReadonlyRef":::

In .NET, examples of a `ref struct` are <xref:System.Span%601?displayProperty=nameWithType> and <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>.

## C# language specification

For more information, see the [Structs](~/_csharpstandard/standard/structs.md) section of the [C# language specification](~/_csharpstandard/standard/README.md).

For more information about features introduced in C# 7.2 and later, see the following feature proposal notes:

- [Compile-time safety for ref-like types](~/_csharplang/proposals/csharp-7.2/span-safety.md)

## See also

- [C# reference](../index.md)
- [The C# type system](../../fundamentals/types/index.md)
