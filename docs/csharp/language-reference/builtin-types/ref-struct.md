---
title: "ref struct types - C# reference"
description: Learn about the ref struct type in C#
ms.date: 10/12/2022
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

You can define a disposable `ref struct`. To do that, ensure that a `ref struct` fits the [disposable pattern](~/_csharplang/proposals/csharp-8.0/using.md#pattern-based-using). That is, it has an instance `Dispose` method, which is accessible, parameterless and has a `void` return type. You can use the [using statement or declaration](../statements/using.md) with an instance of a disposable `ref struct`.

Typically, you define a `ref struct` type when you need a type that also includes data members of `ref struct` types:

:::code language="csharp" source="snippets/shared/StructType.cs" id="SnippetRefStruct":::

To declare a `ref struct` as `readonly`, combine the `readonly` and `ref` modifiers in the type declaration (the `readonly` modifier must come before the `ref` modifier):

:::code language="csharp" source="snippets/shared/StructType.cs" id="SnippetReadonlyRef":::

In .NET, examples of a `ref struct` are <xref:System.Span%601?displayProperty=nameWithType> and <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>.

## `ref` fields

Beginning with C# 11, you can declare a `ref` field in a `ref struct`, as the following example shows:

:::code language="csharp" source="snippets/shared/StructType.cs" id="SnippetRefField":::

A `ref` field may have the `null` value. Use the <xref:System.Runtime.CompilerServices.Unsafe.IsNullRef%60%601(%60%600@)?displayProperty=nameWithType> method to determine if a `ref` field is `null`.

You can apply the `readonly` modifier to a `ref` field in the following ways:

- `readonly ref`: You can [ref reassign](../operators/assignment-operator.md#ref-assignment) such a field with the `= ref` operator only inside a constructor or an [`init` accessor](../keywords/init.md). You can assign a value with the `=` operator at any point allowed by the field access modifier.
- `ref readonly`: At any point, you cannot assign a value with the `=` operator to such a field. However, you can ref reassign a field with the `= ref` operator.
- `readonly ref readonly`: You can only ref reassign such a field in a constructor or an `init` accessor. At any point, you cannot assign a value to the field.

The compiler ensures that a reference stored in a `ref` field doesn't outlive its referent.

The `ref` fields feature enables a safe implementation of types like <xref:System.Span%601?displayProperty=fullName>:

```csharp
public readonly ref struct Span<T>
{
    internal readonly ref T _reference;
    private readonly int _length;

    // Omitted for brevity...
}
```

The `Span<T>` type stores a reference through which it accesses the contiguous elements in memory. The use of a reference enables a `Span<T>` instance to avoid copying the storage it refers to.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [Structs: Ref modifier](~/_csharpstandard/standard/structs.md#1623-ref-modifier)
- [Safe context constraint for ref struct types](~/_csharpstandard/standard/structs.md#16412-safe-context-constraint-for-ref-struct-types)

For more information about `ref` fields, see the [Low-level struct improvements](~/_csharplang/proposals/csharp-11.0/low-level-struct-improvements.md) proposal note.

## See also

- [C# reference](../index.md)
- [The C# type system](../../fundamentals/types/index.md)
