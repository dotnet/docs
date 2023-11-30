---
title: "Tuple types - C# reference"
description: "C# tuples: lightweight data structures that you can use to group loosely related data elements. Tuples introduce a type that contains multiple public members."
ms.date: 04/24/2023
helpviewer_keywords:
  - "value tuples [C#]"
---
# Tuple types (C# reference)

The *tuples* feature provides concise syntax to group multiple data elements in a lightweight data structure. The following example shows how you can declare a tuple variable, initialize it, and access its data members:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ValueTuples.cs" id="Introduction":::

As the preceding example shows, to define a tuple type, you specify types of all its data members and, optionally, the [field names](#tuple-field-names). You can't define methods in a tuple type, but you can use the methods provided by .NET, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ValueTuples.cs" id="MethodOnTuples":::

Tuple types support [equality operators](../operators/equality-operators.md) `==` and `!=`. For more information, see the [Tuple equality](#tuple-equality) section.

Tuple types are [value types](value-types.md); tuple elements are public fields. That makes tuples *mutable* value types.

You can define tuples with an arbitrary large number of elements:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ValueTuples.cs" id="LargeTuple":::

## Use cases of tuples

One of the most common use cases of tuples is as a method return type. That is, instead of defining [`out` method parameters](../keywords/method-parameters.md#out-parameter-modifier), you can group method results in a tuple return type, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ValueTuples.cs" id="MultipleReturns":::

As the preceding example shows, you can work with the returned tuple instance directly or [deconstruct](#tuple-assignment-and-deconstruction) it in separate variables.

You can also use tuple types instead of [anonymous types](../../fundamentals/types/anonymous-types.md); for example, in LINQ queries. For more information, see [Choosing between anonymous and tuple types](../../../standard/base-types/choosing-between-anonymous-and-tuple.md).

Typically, you use tuples to group loosely related data elements. In public APIs, consider defining a [class](../keywords/class.md) or a [structure](struct.md) type.

## Tuple field names

You explicitly specify tuple fields names in a tuple initialization expression or in the definition of a tuple type, as the following example shows:

[!code-csharp-interactive[explicit field names](snippets/shared/ValueTuples.cs#ExplicitFieldNames)]

If you don't specify a field name, it may be inferred from the name of the corresponding variable in a tuple initialization expression, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ValueTuples.cs" id="InferFieldNames":::

That's called tuple projection initializers. The name of a variable isn't projected onto a tuple field name in the following cases:

- The candidate name is a member name of a tuple type, for example, `Item3`, `ToString`, or `Rest`.
- The candidate name is a duplicate of another tuple field name, either explicit or implicit.

In the preceding cases, you either explicitly specify the name of a field or access a field by its default name.

The default names of tuple fields are `Item1`, `Item2`, `Item3` and so on. You can always use the default name of a field, even when a field name is specified explicitly or inferred, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ValueTuples.cs" id="DefaultFieldNames":::

[Tuple assignment](#tuple-assignment-and-deconstruction) and [tuple equality comparisons](#tuple-equality) don't take field names into account.

At compile time, the compiler replaces non-default field names with the corresponding default names. As a result, explicitly specified or inferred field names aren't available at run time.

> [!TIP]
> Enable .NET code style rule [IDE0037](../../../fundamentals/code-analysis/style-rules/ide0037.md) to set a preference on inferred or explicit tuple field names.

Beginning with C# 12, you can specify an alias for a tuple type with a [`using` directive](../keywords/using-directive.md#using-alias). The following example adds a `global using` alias for a tuple type with two integer values for an allowed `Min` and `Max` value:

:::code language="csharp" source="snippets/shared/ValueTuples.cs" id="AliasTupleType":::

After declaring the alias, you can use the `BandPass` name as an alias for that tuple type:

:::code language="csharp" source="snippets/shared/ValueTuples.cs" id="UseAliasType":::

An alias doesn't introduce a new *type*, but only creates a synonym for an existing type. You can deconstruct a tuple declared with the `BandPass` alias the same as you can with its underlying tuple type:

:::code language="csharp" source="snippets/shared/ValueTuples.cs" id="DeconstructAlias":::

As with tuple assignment or deconstruction, the tuple member names don't need to match; the types do.

Similarly, a second alias with the same arity and member types can be used interchangeably with the original alias. You could declare a second alias:

:::code language="csharp" source="snippets/shared/ValueTuples.cs" id="AliasSynonym":::

You can assign a `Range` tuple to a `BandPass` tuple. As with all tuple assignment, the field names need not match, only the types and the arity.

:::code language="csharp" source="snippets/shared/ValueTuples.cs" id="AliasSynonymUses":::

An alias for a tuple type provides more semantic information when you use tuples. It doesn't introduce a new type. To provide type safety, you should declare a positional [`record`](record.md) instead.

## Tuple assignment and deconstruction

C# supports assignment between tuple types that satisfy both of the following conditions:

- both tuple types have the same number of elements
- for each tuple position, the type of the right-hand tuple element is the same as or implicitly convertible to the type of the corresponding left-hand tuple element

Tuple element values are assigned following the order of tuple elements. The names of tuple fields are ignored and not assigned, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ValueTuples.cs" id="Assignment":::

You can also use the assignment operator `=` to *deconstruct* a tuple instance in separate variables. You can do that in many ways:

- Use the `var` keyword outside the parentheses to declare implicitly typed variables and let the compiler infer their types:

  :::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ValueTuples.cs" id="DeconstructVar":::

- Explicitly declare the type of each variable inside parentheses:

  :::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ValueTuples.cs" id="DeconstructExplicit":::

- Declare some types explicitly and other types implicitly (with `var`) inside the parentheses:

  :::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ValueTuples.cs" id="DeconstructMixed":::

- Use existing variables:

  :::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ValueTuples.cs" id="DeconstructExisting":::

The destination of a deconstruct expression can include both existing variables and variables declared in the deconstruction declaration.

You can also combine deconstruction with [pattern matching](../../fundamentals/functional/pattern-matching.md) to inspect the characteristics of fields in a tuple. The following example loops through several integers and prints those that are divisible by 3. It deconstructs the tuple result of <xref:System.Int32.DivRem%2A?displayProperty=nameWithType> and matches against a `Remainder` of 0:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ValueTuples.cs" id="DeconstructToPattern":::

For more information about deconstruction of tuples and other types, see [Deconstructing tuples and other types](../../fundamentals/functional/deconstruct.md).

## Tuple equality

Tuple types support the `==` and `!=` operators. These operators compare members of the left-hand operand with the corresponding members of the right-hand operand following the order of tuple elements.

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ValueTuples.cs" id="TupleEquality":::

As the preceding example shows, the `==` and `!=` operations don't take into account tuple field names.

Two tuples are comparable when both of the following conditions are satisfied:

- Both tuples have the same number of elements. For example, `t1 != t2` doesn't compile if `t1` and `t2` have different numbers of elements.
- For each tuple position, the corresponding elements from the left-hand and right-hand tuple operands are comparable with the `==` and `!=` operators. For example, `(1, (2, 3)) == ((1, 2), 3)` doesn't compile because `1` isn't comparable with `(1, 2)`.

The `==` and `!=` operators compare tuples in short-circuiting way. That is, an operation stops as soon as it meets a pair of non equal elements or reaches the ends of tuples. However, before any comparison, *all* tuple elements are evaluated, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ValueTuples.cs" id="TupleEvaluationForEquality":::

## Tuples as out parameters

Typically, you refactor a method that has [`out` parameters](../keywords/method-parameters.md#out-parameter-modifier) into a method that returns a tuple. However, there are cases in which an `out` parameter can be of a tuple type. The following example shows how to work with tuples as `out` parameters:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/ValueTuples.cs" id="TupleAsOutParameter":::

## Tuples vs `System.Tuple`

C# tuples, which are backed by <xref:System.ValueTuple?displayProperty=nameWithType> types, are different from tuples that are represented by <xref:System.Tuple?displayProperty=nameWithType> types. The main differences are as follows:

- `System.ValueTuple` types are [value types](value-types.md). `System.Tuple` types are [reference types](../keywords/reference-types.md).
- `System.ValueTuple` types are mutable. `System.Tuple` types are immutable.
- Data members of `System.ValueTuple` types are fields. Data members of `System.Tuple` types are properties.

## C# language specification

For more information, see:

- [Tuple types](/dotnet/csharp/language-reference/language-specification/types#8311-tuple-types)
- [Tuple equality operators](/dotnet/csharp/language-reference/language-specification/expressions#111211-tuple-equality-operators)

## See also

- [C# reference](../index.md)
- [Value types](value-types.md)
- [Choosing between anonymous and tuple types](../../../standard/base-types/choosing-between-anonymous-and-tuple.md)
- <xref:System.ValueTuple?displayProperty=nameWithType>
