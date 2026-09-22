---
title: "Property and positional patterns"
description: Learn when to use C# property patterns to test named members and positional patterns to test deconstructed or tuple values.
ms.date: 09/17/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Property and positional patterns

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. Start with the [pattern matching overview](pattern-matching.md) if patterns are new to you. For complete language rules, see [property patterns](../../language-reference/operators/patterns.md#property-pattern) and [positional patterns](../../language-reference/operators/patterns.md#positional-pattern) in the language reference.

Property and positional patterns test parts of a value and can apply nested patterns to those parts. A *property pattern* names the properties or fields to test. A *positional pattern* tests values produced by deconstructing an object or tuple.

Both are *recursive patterns*. Each member or position written in the pattern supplies the input to a nested pattern. An outer type test is optional, and recursive pattern clauses can be empty. For example, the empty property pattern `{ }` tests only that the evaluated value isn't `null`. Property and positional patterns don't match `null`.

## Test named members with a property pattern

The following method tests two named properties of a weather reading, with temperature values in degrees Celsius:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="PropertyPattern":::

The `reading` expression is the input to the outer pattern. The pattern matches only when its evaluated value is non-null and both nested patterns match:

- The relational pattern `> 30` tests the value of `TemperatureC`.
- The relational pattern `> 70` tests the value of `HumidityPercent`.

Choose a property pattern when member names help explain the test. Unlike a series of Boolean expressions, the pattern groups the relevant shape and values in one description. For one simple comparison, such as `reading.TemperatureC > 30`, an ordinary relational expression is often clearer.

You can add a type test before the braces when the input expression can produce different types. You can also use a member path to test a nested property:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="NestedPropertyPattern":::

`DateTime { Date.DayOfWeek: DayOfWeek.Saturday or DayOfWeek.Sunday }` first tests that the evaluated value is a <xref:System.DateTime>. It then follows the `Date.DayOfWeek` member path and tests the day against two constant patterns. The pattern doesn't match if the outer value is `null` or the type test fails. In general, a property pattern also doesn't match if an object needed along a member path is `null`.

Choose named properties over positions when readers would need to memorize what each position means.

## Prefer named members for object shapes

The following `GridPoint` record has an `X` coordinate followed by a `Y` coordinate. The method classifies a point by its position relative to the axes:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="ObjectPropertyPattern":::

The property names make each arm readable without requiring readers to remember a deconstruction order. Prefer property patterns for classes, structs, and records, even when the type provides a `Deconstruct` method.

## Match related inputs with a positional pattern

A *positional pattern* deconstructs its input and applies nested patterns by position. Positional patterns are most useful with tuples, which combine multiple values into one value with a fixed positional shape. The following method uses a signal value and a Boolean value to choose one result:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="TuplePattern":::

The tuple expression `(signal, crossingIsClear)` is the input. Each switch arm applies a positional pattern to both tuple elements. This form keeps each combination next to its result.

Choose a tuple pattern when several small, related inputs jointly determine one result. If the positions need extensive explanation or the data belongs together throughout the program, define a type with named properties instead.

Positions always follow the tuple element order or the order defined by a type's `Deconstruct` method. Named positional subpatterns can document those positions, but the names don't change their order. Evaluation order for the subpatterns isn't specified.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Relational, logical, and parenthesized patterns](relational-logical-patterns.md)
- [Deconstructing tuples and other types](../functional/deconstruct.md)
- [Property pattern reference](../../language-reference/operators/patterns.md#property-pattern)
- [Positional pattern reference](../../language-reference/operators/patterns.md#positional-pattern)
