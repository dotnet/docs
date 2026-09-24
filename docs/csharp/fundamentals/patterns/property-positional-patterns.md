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

A *deconstruction* exposes an ordered set of component values. A tuple already has an element order. For another type, a `Deconstruct` method defines which component values are exposed and their order.

## Compare names and positions

The following property pattern tests two named properties of a weather reading, with temperature values in degrees Celsius:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="PropertyPattern":::

The following positional pattern tests a signal value followed by a Boolean value:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="TuplePattern":::

The property pattern identifies its inputs by the names `TemperatureC` and `HumidityPercent`. The tuple pattern identifies its inputs by order: `signal` first and `crossingIsClear` second.

Choose a property pattern when member names help explain the test. Property patterns are usually clearer for classes, structs, and records. Choose a positional pattern when order already gives the values an obvious meaning. Positional patterns are most useful with tuples, which combine multiple related values into one value with a fixed order.

If positions need extensive explanation or the data belongs together throughout the program, define a type with named properties instead. For one simple comparison, such as `reading.TemperatureC > 30`, an ordinary relational expression can be as clear as a pattern.

## Follow nested inputs in recursive patterns

Property and positional patterns are *recursive patterns*: They can apply another pattern to each property, field, or position they select. The selected value becomes the input to that nested pattern.

In `IsHotAndHumid`, the `reading` expression is the input to the property pattern. C# evaluates that expression before matching. The pattern then gets two values from the resulting object:

- The relational pattern `> 30` tests the value of `TemperatureC`.
- The relational pattern `> 70` tests the value of `HumidityPercent`.

An outer type test is optional, and recursive pattern clauses can be empty. For example, the empty property pattern `{ }` matches any non-null evaluated value.

Property and positional patterns require a non-null input. When their clauses contain nested patterns, each selected property, field, or position becomes the input to its nested pattern.

You can add a type test before the braces when the input expression can produce different types. You can also use a member path to test a nested property:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="NestedPropertyPattern":::

`value` is the input expression. C# first evaluates it and tests whether the resulting value is a <xref:System.DateTime>. The `Date` property value then becomes the input for the `DayOfWeek` member access. Finally, the `DayOfWeek` value becomes the input to the logical pattern that tests two constants. Matching succeeds when the outer value has the specified type and every object needed along the member path is non-null.

## Use names for object shapes

The following `GridPoint` record has an `X` coordinate followed by a `Y` coordinate. The method classifies a point by its position relative to the axes:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="ObjectPropertyPattern":::

The property names make each arm readable because they identify the coordinates directly. Prefer property patterns for classes, structs, and records, even when the type provides a `Deconstruct` method.

## Follow positional order

For the earlier tuple pattern, the tuple expression `(signal, crossingIsClear)` is the input. Each switch arm applies a nested pattern to both tuple elements. For a tuple, positions follow tuple element order. For another type, positions follow the parameter order of its `Deconstruct` method. The runtime evaluation order for subpatterns is unspecified, so write them so the result is independent of evaluation order.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Relational, logical, and parenthesized patterns](relational-logical-patterns.md)
- [Deconstructing tuples and other types](../functional/deconstruct.md)
- [Property pattern reference](../../language-reference/operators/patterns.md#property-pattern)
- [Positional pattern reference](../../language-reference/operators/patterns.md#positional-pattern)
