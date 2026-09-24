---
title: "Property and positional patterns"
description: Learn when to use C# property patterns to test named members and positional patterns to test ordered values.
ms.date: 09/24/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Property and positional patterns

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. Start with the [pattern matching overview](pattern-matching.md) if patterns are new to you. For complete language rules, see [property patterns](../../language-reference/operators/patterns.md#property-pattern) and [positional patterns](../../language-reference/operators/patterns.md#positional-pattern) in the language reference.

Property and positional patterns both test parts of a value. The difference is how they identify those parts:

- A *property pattern* names the properties or fields to test.
- A *positional pattern* identifies values by their order.

A *deconstruction* exposes an ordered set of component values. A tuple already has an element order; see [deconstruct tuples](../types/tuples.md#deconstruct-tuples). For another type, a [`Deconstruct` method](../functional/deconstruct.md#user-defined-types) defines which component values are exposed and their order.

## Compare names and positions

The following property pattern tests two named properties of a weather reading, with temperature values in degrees Celsius:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="PropertyPattern":::

The following positional pattern tests a signal value followed by a Boolean value:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="TuplePattern":::

The property pattern identifies its inputs by the names `TemperatureC` and `HumidityPercent`. The crossing code creates a tuple from the separate `signal` and `crossingIsClear` values. The tuple pattern then identifies those values by order: `signal` first and `crossingIsClear` second. A positional pattern is a strong fit because this newly created tuple has only two values, and their order has a clear meaning in the crossing decision.

Choose a property pattern when member names help explain the test. Property patterns are usually clearer for classes, structs, and records. Choose a positional pattern when order already gives the values an obvious meaning. Positional patterns are most useful with tuples, which combine multiple related values into one value with a fixed order.

## Follow nested inputs in recursive patterns

Property and positional patterns are *recursive patterns*: They can apply another pattern to each property, field, or position they select. The selected value becomes the input to that nested pattern.

In `IsHotAndHumid`, the `reading` expression is the input to the property pattern. C# evaluates that expression before matching. The pattern then gets two values from the resulting object:

- The relational pattern `> 30` tests the value of `TemperatureC`.
- The relational pattern `> 70` tests the value of `HumidityPercent`.

An outer type test is optional, and recursive pattern clauses can be empty. For example, the empty property pattern `{ }` matches any non-null evaluated value.

Property and positional patterns match only non-null evaluated values. When `null` is part of the input domain, choose a recursive pattern that checks for a non-null value first:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="NullRecursivePattern":::

The input expression is `value`. C# evaluates it, and the `{ }` property pattern tests the resulting value for non-null before assigning it to `nonNullValue`. The following switch expression can then test multiple possible runtime types. Its `DateTime` and `string` type patterns have no designation because the method only needs to identify each type, not capture its value.

When recursive pattern clauses contain nested patterns, each selected property, field, or position becomes the input to its nested pattern.

You can add a type test before the braces when the input expression can produce different types. You can also use a member path to test a nested property:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="NestedPropertyPattern":::

`value` is the input expression. C# first evaluates it and tests whether the resulting value is a <xref:System.DateTime>. The `Date` property value then becomes the input for the `DayOfWeek` member access. Finally, the `DayOfWeek` value becomes the input to the logical pattern that tests two constants. Matching succeeds when the outer value has the specified type and every object needed along the member path is non-null.

## Use names for object shapes

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="ObjectPropertyPattern":::

## Follow positional order

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="TuplePattern":::

## Compare patterns with branching statements

The earlier `DescribeDate` method expresses four results as patterns:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="NestedPropertyPattern":::

The following method produces the same results with a series of imperative branching statements:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="ImperativeDateBranches":::

The pattern-based version keeps the possible results together when several branches test a value's type and shape. The imperative version makes each test and return step explicit. For one condition, either form might look similar; as the number of related branches grows, patterns can make the alternatives easier to compare.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Relational, logical, and parenthesized patterns](relational-logical-patterns.md)
- [Deconstructing tuples and other types](../functional/deconstruct.md)
- [Property pattern reference](../../language-reference/operators/patterns.md#property-pattern)
- [Positional pattern reference](../../language-reference/operators/patterns.md#positional-pattern)
