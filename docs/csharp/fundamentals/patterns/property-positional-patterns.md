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

Property and positional patterns test parts of a value. A *property pattern* names the properties or fields to test. A *positional pattern* tests values produced by deconstructing an object or tuple.

Both are *recursive patterns*: Each member or position has its own nested pattern. The input to the outer pattern is an expression. C# evaluates that expression, then applies each nested pattern to the corresponding part of the evaluated value.

## Test named members with a property pattern

A warehouse uses `Package` objects to decide which packages need careful handling. The `Destination` property identifies where a package is going, and `WeightKg` records its weight. The following test identifies heavy international packages so the shipping system can add special handling instructions:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="PropertyPattern":::

The `package` expression is the input to the outer pattern. The pattern matches only when its evaluated value is non-null and both nested patterns match:

- The constant pattern `"International"` tests the value of the named `Destination` property.
- The relational pattern `> 20` tests the value of the named `WeightKg` property.

Choose a property pattern when member names help explain the test. Unlike a series of Boolean expressions, the pattern groups the relevant shape and values in one description. For one simple comparison, such as `package.WeightKg > 20`, an ordinary relational expression is often clearer.

You can add a type test before the braces when the input expression can produce different types. The following order system receives an `Order` base type. `StorePickup` and `ShippedOrder` are specialized order types. A shipped order has an `Address`, and the address has a `CountryCode`. The system needs to choose the team that fulfills each order:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="NestedPropertyPattern":::

`ShippedOrder { Address.CountryCode: not "US" }` first tests that the evaluated value is a non-null `ShippedOrder`. It then follows the named `Address.CountryCode` member path. The pattern doesn't match if the outer value is `null`, if the type test fails, or if any object needed along that member path is `null`. Otherwise, the nested `not "US"` pattern tests the country code. This behavior makes the pattern suitable for selecting the correct fulfillment team without separate type, null, and member checks.

Choose named properties over positions when readers would need to memorize what each position means.

## Test a stable shape with a positional pattern

A *positional pattern* deconstructs a value and applies nested patterns in order. A type can define that order with a `Deconstruct` method. Positional records provide deconstruction automatically.

The following `GridPoint` record represents a location with an `X` coordinate followed by a `Y` coordinate. That two-value shape is intentional and familiar throughout the mapping code. The method classifies points so the map can choose where to draw their labels:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="PositionalPattern":::

The `point` expression is the pattern input. For `(0, 0)`, C# evaluates `point`, deconstructs the non-null value into its `X` and `Y` components, and applies a constant pattern to each component. The discard pattern `_` accepts a component that doesn't matter to that arm.

The positions must follow the type's deconstruction order. Choose a positional pattern when that order is a deliberate, stable part of the type's design, such as `(X, Y)`. Use a property pattern when names communicate the test better or when the deconstruction order is difficult to remember.

## Match a tuple of related inputs

A tuple combines multiple values into one value with a fixed positional shape. A traffic controller considers the pedestrian signal and whether the crossing is clear. It needs both results to decide whether a person should cross:

:::code language="csharp" source="snippets/patterns/PropertyPositionalPatterns.cs" ID="TuplePattern":::

The tuple expression `(signal, crossingIsClear)` is the input. Each switch arm applies a positional pattern to both tuple elements. This form keeps the combinations and their consequential results together.

Choose a tuple pattern when several small, related inputs jointly determine one result. If the positions need extensive explanation or the data belongs together throughout the program, define a type with named properties instead.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Relational, logical, and parenthesized patterns](relational-logical-patterns.md)
- [Deconstructing tuples and other types](../functional/deconstruct.md)
- [Property pattern reference](../../language-reference/operators/patterns.md#property-pattern)
- [Positional pattern reference](../../language-reference/operators/patterns.md#positional-pattern)
