---
title: Deconstructing tuples and other types
description: Learn how C# deconstruction assigns tuple elements or object components to individual variables.
ms.date: 09/29/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Deconstructing tuples and other types

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. Start with the [pattern matching overview](pattern-matching.md) if patterns are new to you. Deconstruction also enables positional patterns. For guidance on when to choose property patterns or positional patterns, see [Property and positional patterns](property-positional-patterns.md).

A *deconstruction* assigns components from one value to multiple variables in a single operation. Tuples expose their components by position. Another type can expose components by defining a `Deconstruct` method. Positional records include one automatically.

Deconstruction is related to pattern matching because a `Deconstruct` method also enables positional patterns for that type. Even so, property patterns are usually clearer for object shapes because member names explain the test. Positional patterns are strongest when order already carries the meaning, such as with tuples or other small ordered values.

## Deconstruct tuples

Suppose a method returns a tuple with city data. You can read each component one at a time:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="TupleMemberAccess":::

A deconstruction assigns those components in one step:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="TupleTypedDeclaration":::

You can also let C# infer the variable types:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="TupleVarDeconstruction":::

A deconstruction can mix existing variables, newly declared variables, and discards in one assignment:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="MixedDeconstruction":::

Choose the form that makes the code easiest to read. A single `var` before the parentheses is often the clearest inferred form. You can also mix explicit types and `var` inside the parentheses, but that form is usually harder to scan. If you need only some values, use discards instead of omitting positions.

## Ignore unneeded values with discards

Every produced value must line up with a position on the left side of the assignment. When you do not need one or more positions, use `_` as a discard:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="TupleDiscards":::

Here, the tuple returns the city name, two years, and two population values. The deconstruction keeps only the population values because the calculation uses only those components.

## Deconstruct user-defined types

A class, struct, or interface can support deconstruction by declaring a `Deconstruct` method. Each produced value is an `out` parameter. The method itself returns `void`:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="PersonDeconstructMethod":::

You can then deconstruct an instance directly:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="PersonDeconstructUse":::

A type can provide multiple `Deconstruct` overloads with different arities so callers can choose how many components to retrieve:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="PersonDeconstructOverloads":::

Two overloads with the same number of `out` parameters are ambiguous. Distinguish overloads by arity, not only by parameter types.

Discards work with user-defined deconstruction too:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="PersonDeconstructDiscards":::

## Deconstruct records

A positional `record` or `record struct` gets a compiler-generated `Deconstruct` method whose `out` parameters match the positional parameters:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="RecordDeconstruction":::

Only the positional parameters participate in that generated deconstruction. Additional properties you declare elsewhere on the record are not added automatically.

## Deconstruct types you don't own

If you cannot modify a type, you can still support deconstruction by writing an extension method. After you add the method, any `Uri` value can use deconstruction syntax:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="UriDeconstructExample":::

## Use built-in deconstruction on system types

Some system types already define `Deconstruct`. For example, <xref:System.Collections.Generic.KeyValuePair`2?displayProperty=nameWithType> supports deconstruction, which makes dictionary iteration concise:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="KeyValuePair":::

## See also

- [Pattern matching overview](pattern-matching.md)
- [Property and positional patterns](property-positional-patterns.md)
- [Discards and the discard pattern](discards.md)
- [Tuple types](../types/tuples.md)
- [`out` parameter modifier](../../language-reference/keywords/method-parameters.md#out-parameter-modifier)
