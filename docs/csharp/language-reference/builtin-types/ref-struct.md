---
title: "ref struct types"
description: Learn about the ref struct type in C#
ms.date: 01/27/2025
f1_keywords:
  - "refstruct"
  - "refstruct_CSharpKeyword"
helpviewer_keywords:
  - "ref struct [C#]"
---
# `ref` structure types (C# reference)

You can use the `ref` modifier in the declaration of a [structure type](struct.md). Instances of a `ref struct` type are allocated on the stack and can't escape to the managed heap. To ensure that, the compiler limits the usage of `ref struct` types as follows:

- A `ref struct` can't be the element type of an array.
- A `ref struct` can't be a declared type of a field of a class or a non-`ref struct`.
- A `ref struct` can't be boxed to <xref:System.ValueType?displayProperty=nameWithType> or <xref:System.Object?displayProperty=nameWithType>.
- A `ref struct` variable can't be captured in a [lambda expression](../operators/lambda-expressions.md) or a [local function](../../programming-guide/classes-and-structs/local-functions.md).
- Before C# 13, `ref struct` variables can't be used in an `async` method. Beginning with C# 13, a `ref struct` variable can't be used in the same block as the [`await`](../operators/await.md) expression in an [`async`](../keywords/async.md) method. However, you can use `ref struct` variables in synchronous methods, for example, in methods that return <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601>.
- Before C# 13, a `ref struct` variable can't be used in [iterators](../../iterators.md). Beginning with C# 13, `ref struct` types and `ref` locals can be used in iterators, provided they aren't in code segments with the `yield return` statement.
- Before C# 13, a `ref struct` can't implement interfaces. Beginning with C# 13, a `ref` struct can implement interfaces, but must adhere to the [ref safety](~/_csharpstandard/standard/structs.md#1623-ref-modifier) rules. For example, a `ref struct` type can't be converted to the interface type because that requires a boxing conversion.
- Before C# 13, a `ref struct` can't be a type argument. Beginning with C# 13, a `ref struct` can be the type argument when the type parameter specifies the `allows ref struct` in its `where` clause.

Typically, you define a `ref struct` type when you need a type that also includes data members of `ref struct` types:

:::code language="csharp" source="snippets/shared/StructType.cs" id="SnippetRefStruct":::

To declare a `ref struct` as `readonly`, combine the `readonly` and `ref` modifiers in the type declaration (the `readonly` modifier must come before the `ref` modifier):

:::code language="csharp" source="snippets/shared/StructType.cs" id="SnippetReadonlyRef":::

In .NET, examples of a `ref struct` are <xref:System.Span%601?displayProperty=nameWithType> and <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>.

## `ref` fields

Beginning with C# 11, you can declare a `ref` field in a `ref struct`, as the following example shows:

:::code language="csharp" source="snippets/shared/StructType.cs" id="SnippetRefField":::

A `ref` field can have the `null` value. Use the <xref:System.Runtime.CompilerServices.Unsafe.IsNullRef%60%601(%60%600@)?displayProperty=nameWithType> method to determine if a `ref` field is `null`.

You can apply the `readonly` modifier to a `ref` field in the following ways:

- `readonly ref`: You can [ref reassign](../operators/assignment-operator.md#ref-assignment) such a field with the `= ref` operator only inside a constructor or an [`init` accessor](../keywords/init.md). You can assign a value with the `=` operator at any point allowed by the field access modifier.
- `ref readonly`: At any point, you can't assign a value with the `=` operator to such a field. However, you can ref reassign a field with the `= ref` operator.
- `readonly ref readonly`: You can only ref reassign such a field in a constructor or an `init` accessor. At any point, you can't assign a value to the field.

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

## The disposable pattern

You can define a disposable `ref struct`. To do that, ensure that a `ref struct` fits the [disposable pattern](~/_csharplang/proposals/csharp-8.0/using.md#pattern-based-using). That is, it has an instance `Dispose` method, which is accessible, parameterless and has a `void` return type. You can use the [using statement or declaration](../statements/using.md) with an instance of a disposable `ref struct`.

Beginning with C# 13, you can also implement the <xref:System.IDisposable?displayName=nameWithType> on `ref struct` types. However, overload resolution prefers the disposable pattern to the interface method. The compiler resolves to an `IDisposable.Dispose` method only when a suitable `Dispose` method isn't found.

## Restrictions for `ref struct` types that implement an interface

These restrictions ensure that a `ref struct` type that implements an interface obeys the necessary [ref safety](~/_csharpstandard/standard/structs.md#1623-ref-modifier) rules.

- A `ref struct` can't be converted to an instance of an interface it implements. This restriction includes the implicit conversion when you use a `ref struct` type as an argument when the parameter is an interface type. The conversion results in a boxing conversion, which violates ref safety. A `ref struct` can declare methods as explicit interface declarations. However, those methods can be accessed only from generic methods where the type parameter [`allows ref struct`](../../programming-guide/generics/constraints-on-type-parameters.md#allows-ref-struct) types.
- A `ref struct` that implements an interface *must* implement all instance interface members. The `ref struct` must implement instance members even when the interface includes a default implementation.

The compiler enforces these restrictions. If you write `ref struct` types that implement interfaces, each new update might include new [default interface members](../keywords/interface.md#default-interface-members). Until you provide an implementation for any new instance methods, your application won't compile. You can't provide a specific implementation for a `static` interface method with a default implementation.

> [!IMPORTANT]
> A `ref struct` that implements an interface includes the potential for later source-breaking and binary-breaking changes. The break occurs if a `ref struct` implements an interface defined in another assembly, and that assembly provides an update which adds default members to that interface.
>
> The source-break happens when you recompile the `ref struct`: It must implement the new member, even though there's a default implementation.
>
> The binary-break happens if you upgrade the external assembly without recompiling the `ref struct` type *and* the updated code calls the default implementation of the new method. The runtime throws an exception when the default member is accessed.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [Structs: Ref modifier](~/_csharpstandard/standard/structs.md#1623-ref-modifier)
- [Safe context constraint for ref struct types](~/_csharpstandard/standard/structs.md#16415-safe-context-constraint)

For more information about `ref` fields, see the [Low-level struct improvements](~/_csharplang/proposals/csharp-11.0/low-level-struct-improvements.md) proposal note.

## See also

- [The C# type system](../../fundamentals/types/index.md)
