---
title: "Tuple types - C# reference"
description: "Learn about C# tuples: lightweight data structures that you can use to group loosely related data elements"
ms.date: 07/09/2020
helpviewer_keywords: 
  - "value tuples [C#]"
---
# Tuple types (C# reference)

Available in C# 7.0 and later, the *tuples* feature provides concise syntax to group multiple data elements in a lightweight data structure. The following example shows how you can declare a tuple variable, initialize it, and access its data members:

[!code-csharp-interactive[tuple intro](snippets/shared/ValueTuples.cs#Introduction)]

As the preceding example shows, to define a tuple type, you specify types of all its data members and, optionally, the [field names](#tuple-field-names). You cannot define methods in a tuple type, but you can use the methods provided by .NET, as the following example shows:

[!code-csharp-interactive[tuple methods](snippets/shared/ValueTuples.cs#MethodOnTuples)]

Beginning with C# 7.3, tuple types support [equality operators](../operators/equality-operators.md) `==` and `!=`. For more information, see the [Tuple equality](#tuple-equality) section.

Tuple types are [value types](value-types.md); tuple elements are public fields. That makes tuples *mutable* value types.

> [!NOTE]
> The tuples feature requires the <xref:System.ValueTuple?displayProperty=nameWithType> type and related generic types (for example, <xref:System.ValueTuple%602?displayProperty=nameWithType>), which are available in .NET Core and .NET Framework 4.7 and later. To use tuples in a project that targets .NET Framework 4.6.2 or earlier, add the NuGet package [`System.ValueTuple`](https://www.nuget.org/packages/System.ValueTuple/) to the project.

You can define tuples with an arbitrary large number of elements:

[!code-csharp-interactive[large tuple](snippets/shared/ValueTuples.cs#LargeTuple)]

## Use cases of tuples

One of the most common use cases of tuples is as a method return type. That is, instead of defining [`out` method parameters](../keywords/out-parameter-modifier.md), you can group method results in a tuple return type, as the following example shows:

[!code-csharp-interactive[multiple method outputs](snippets/shared/ValueTuples.cs#MultipleReturns)]

As the preceding example shows, you can work with the returned tuple instance directly or [deconstruct](#tuple-assignment-and-deconstruction) it in separate variables.

You can also use tuple types instead of [anonymous types](../../fundamentals/types/anonymous-types.md); for example, in LINQ queries. For more information, see [Choosing between anonymous and tuple types](../../../standard/base-types/choosing-between-anonymous-and-tuple.md).

Typically, you use tuples to group loosely related data elements. That is usually useful within private and internal utility methods. In the case of public API, consider defining a [class](../keywords/class.md) or a [structure](struct.md) type.

## Tuple field names

You can explicitly specify the names of tuple fields either in a tuple initialization expression or in the definition of a tuple type, as the following example shows:

[!code-csharp-interactive[explicit field names](snippets/shared/ValueTuples.cs#ExplicitFieldNames)]

Beginning with C# 7.1, if you don't specify a field name, it may be inferred from the name of the corresponding variable in a tuple initialization expression, as the following example shows:

[!code-csharp-interactive[inferred field names](snippets/shared/ValueTuples.cs#InferFieldNames)]

That's known as tuple projection initializers. The name of a variable isn't projected onto a tuple field name in the following cases:

- The candidate name is a member name of a tuple type, for example, `Item3`, `ToString`, or `Rest`.
- The candidate name is a duplicate of another tuple field name, either explicit or implicit.

In those cases you either explicitly specify the name of a field or access a field by its default name.

The default names of tuple fields are `Item1`, `Item2`, `Item3` and so on. You can always use the default name of a field, even when a field name is specified explicitly or inferred, as the following example shows:

[!code-csharp-interactive[default field names](snippets/shared/ValueTuples.cs#DefaultFieldNames)]

[Tuple assignment](#tuple-assignment-and-deconstruction) and [tuple equality comparisons](#tuple-equality) don't take field names into account.

At compile time, the compiler replaces non-default field names with the corresponding default names. As a result, explicitly specified or inferred field names aren't available at run time.

## Tuple assignment and deconstruction

C# supports assignment between tuple types that satisfy both of the following conditions:

- both tuple types have the same number of elements
- for each tuple position, the type of the right-hand tuple element is the same as or implicitly convertible to the type of the corresponding left-hand tuple element

Tuple element values are assigned following the order of tuple elements. The names of tuple fields are ignored and not assigned, as the following example shows:

[!code-csharp-interactive[tuple assignment](snippets/shared/ValueTuples.cs#Assignment)]

You can also use the assignment operator `=` to *deconstruct* a tuple instance in separate variables. You can do that in one of the following ways:

- Explicitly declare the type of each variable inside parentheses:

  [!code-csharp-interactive[specify types of variables](snippets/shared/ValueTuples.cs#DeconstructExplicit)]

- Use the `var` keyword outside the parentheses to declare implicitly typed variables and let the compiler infer their types:

  [!code-csharp-interactive[implicitly typed variables](snippets/shared/ValueTuples.cs#DeconstructVar)]

- Use existing variables:

  [!code-csharp-interactive[existing variables](snippets/shared/ValueTuples.cs#DeconstructExisting)]

For more information about deconstruction of tuples and other types, see [Deconstructing tuples and other types](../../fundamentals/functional/deconstruct.md).

## Tuple equality

Beginning with C# 7.3, tuple types support the `==` and `!=` operators. These operators compare members of the left-hand operand with the corresponding members of the right-hand operand following the order of tuple elements.

[!code-csharp-interactive[tuple equality](snippets/shared/ValueTuples.cs#TupleEquality)]

As the preceding example shows, the `==` and `!=` operations don't take into account tuple field names.

Two tuples are comparable when both of the following conditions are satisfied:

- Both tuples have the same number of elements. For example, `t1 != t2` doesn't compile if `t1` and `t2` have different numbers of elements.
- For each tuple position, the corresponding elements from the left-hand and right-hand tuple operands are comparable with the `==` and `!=` operators. For example, `(1, (2, 3)) == ((1, 2), 3)` doesn't compile because `1` is not comparable with `(1, 2)`.

The `==` and `!=` operators compare tuples in short-circuiting way. That is, an operation stops as soon as it meets a pair of non equal elements or reaches the ends of tuples. However, before any comparison, *all* tuple elements are evaluated, as the following example shows:

[!code-csharp-interactive[tuple element evaluation](snippets/shared/ValueTuples.cs#TupleEvaluationForEquality)]

## Tuples as out parameters

Typically, you refactor a method that has [`out` parameters](../keywords/out-parameter-modifier.md) into a method that returns a tuple. However, there are cases in which an `out` parameter can be of a tuple type. The following example shows how to work with tuples as `out` parameters:

[!code-csharp-interactive[tuple as out parameter](snippets/shared/ValueTuples.cs#TupleAsOutParameter)]

## Tuples vs `System.Tuple`

C# tuples, which are backed by <xref:System.ValueTuple?displayProperty=nameWithType> types, are different from tuples that are represented by <xref:System.Tuple?displayProperty=nameWithType> types. The main differences are as follows:

- `System.ValueTuple` types are [value types](value-types.md). `System.Tuple` types are [reference types](../keywords/reference-types.md).
- `System.ValueTuple` types are mutable. `System.Tuple` types are immutable.
- Data members of `System.ValueTuple` types are fields. Data members of `System.Tuple` types are properties.

## C# language specification

For more information, see the following feature proposal notes:

- [Infer tuple names (aka. tuple projection initializers)](~/_csharplang/proposals/csharp-7.1/infer-tuple-names.md)
- [Support for `==` and `!=` on tuple types](~/_csharplang/proposals/csharp-7.3/tuple-equality.md)

## See also

- [C# reference](../index.md)
- [Value types](value-types.md)
- [Choosing between anonymous and tuple types](../../../standard/base-types/choosing-between-anonymous-and-tuple.md)
- <xref:System.ValueTuple?displayProperty=nameWithType>
