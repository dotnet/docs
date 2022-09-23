---
title: "Ref Struct types - C# reference"
description: Learn about the ref struct type in C#
ms.date: 09/15/2022
---
# `ref` Structure types (C# reference)

Beginning with C# 7.2, you can use the `ref` modifier in the declaration of a value type. Instances of a `ref struct` type are allocated on the stack and can't escape to the managed heap. To ensure that, the compiler limits the usage of `ref struct` types as follows:

- A `ref struct` can't be the element type of an array.
- A `ref struct` can't be a declared type of a field of a class or a non-`ref struct`.
- A `ref struct` can't implement interfaces.
- A `ref struct` can't be boxed to <xref:System.ValueType?displayProperty=nameWithType> or <xref:System.Object?displayProperty=nameWithType>.
- A `ref struct` can't be a type argument.
- A `ref struct` variable can't be captured by a [lambda expression](../operators/lambda-expressions.md) or a [local function](../../programming-guide/classes-and-structs/local-functions.md).
- A `ref struct` variable can't be used in an [`async`](../keywords/async.md) method. However, you can use `ref struct` variables in synchronous methods, for example, in methods that return <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601>.
- A `ref struct` variable can't be used in [iterators](../../iterators.md).

Beginning with C# 8.0, you can define a disposable `ref struct`. To do that, ensure that a `ref struct` fits the [disposable pattern](~/_csharplang/proposals/csharp-8.0/using.md#pattern-based-using). That is, it has an instance or extension `Dispose` method, which is accessible, parameterless and has a `void` return type.

Beginning with C# 11.0, a `ref struct` may contain `ref` fields. A `ref` field may be assigned or reassigned to refer to another object. Ref fields are declared using the same syntax as [`ref` local variables](../statements/declarations.md#ref-locals). The compiler enforces scope rules on `ref` fields in `ref struct` types. The rules ensure that a reference doesn't outlive the object to which it refers. See the section on scoping rules in the article on [method parameters](../keywords/method-parameters.md#scope-of-references-and-values).

Typically, you define a `ref struct` type when you need a type that also includes data members of `ref struct` types:

:::code language="csharp" source="snippets/shared/StructType.cs" id="SnippetRefStruct":::

To declare a `ref struct` as `readonly`, combine the `readonly` and `ref` modifiers in the type declaration (the `readonly` modifier must come before the `ref` modifier):

:::code language="csharp" source="snippets/shared/StructType.cs" id="SnippetReadonlyRef":::

In .NET, examples of a `ref struct` are <xref:System.Span%601?displayProperty=nameWithType> and <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>.

## C# language specification

For more information, see the [Structs](~/_csharpstandard/standard/structs.md) section of the [C# language specification](~/_csharpstandard/standard/README.md).

For more information about features introduced in C# 7.2 and later, see the following feature proposal notes:

- [Compile-time safety for ref-like types](~/_csharplang/proposals/csharp-7.2/span-safety.md)
