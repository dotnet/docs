---
title: Deconstructing tuples and other types
description: Learn how C# deconstruction assigns tuple elements or object components to individual variables.
ms.date: 09/29/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Deconstruct tuples and other types

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. Start with the [pattern matching overview](pattern-matching.md) if patterns are new to you.

A *deconstruction* assigns the individual parts of a value — its *components* — to multiple variables in a single operation. A tuple's components are its elements, exposed by position. Another type can expose components by defining a `Deconstruct` method. [Positional records](../types/records.md), which declare their properties as constructor-like parameters, get a `Deconstruct` method automatically.

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

A class, struct, or interface can support deconstruction by declaring a `Deconstruct` method. Each component becomes an [`out` parameter](../../language-reference/keywords/method-parameters.md#out-parameter-modifier), which lets the method assign a value back to the caller's variable without returning it. Because every component is returned through an `out` parameter, the method itself returns `void`:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="PersonDeconstructMethod":::

You can then deconstruct an instance directly:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="PersonDeconstructUse":::

A type can provide multiple `Deconstruct` overloads with different *arity* — the number of `out` parameters the method declares — so callers can choose how many components to retrieve:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="PersonDeconstructOverloads":::

Two overloads with the same number of `out` parameters are ambiguous. The compiler reports an error for the ambiguous call, so distinguish overloads by arity, not only by parameter types.

Discards work with user-defined deconstruction too. For more on discards in general, see [Discards and the discard pattern](discards.md):

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="PersonDeconstructDiscards":::

## Deconstruct records

A [positional `record` or `record struct`](../types/records.md) declares its properties as parameters on the type declaration itself, similar to a constructor. The compiler generates a `Deconstruct` method for you, with `out` parameters matching those positional parameters:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="RecordDeconstruction":::

Only the positional parameters participate in that generated deconstruction. Additional properties you declare elsewhere on the record are not added automatically.

## Deconstruct types you don't own

If you cannot modify a type, you can still support deconstruction by writing an *extension method* — a static method that adds a `Deconstruct` method to a type you don't own, as if it were a member of that type. After you add the method, any `Uri` value can use deconstruction syntax:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="UriDeconstructExample":::

The same ambiguity rule applies here: two extension `Deconstruct` methods with the same arity are ambiguous. Ambiguity can also arise between an instance `Deconstruct` method and an extension method of the same arity. In either case, the compiler reports an error for the ambiguous call.

## Built-in deconstruction on system types

Some system types already define a `Deconstruct` method, using the same mechanism you'd use for your own types. For example, <xref:System.Collections.Generic.KeyValuePair`2?displayProperty=nameWithType> supports deconstruction, which makes dictionary iteration concise:

:::code language="csharp" source="snippets/patterns/DeconstructSamples.cs" ID="KeyValuePair":::

## Deconstruction and pattern matching

A `Deconstruct` method also enables [positional patterns](../../language-reference/operators/patterns.md#positional-pattern) for that type. A positional pattern tests and deconstructs a value in one step, using the same parenthesized syntax as a deconstruction: `person is ("Alice", 30)` matches a `Person` whose deconstructed components equal those values. This is different from a [property pattern](property-positional-patterns.md), which tests named properties directly, such as `person is { Name: "Alice", Age: 30 }`. Property patterns are usually clearer for object shapes because member names explain the test. Positional patterns are strongest when order already carries the meaning, such as with tuples or other small ordered values.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Property and positional patterns](property-positional-patterns.md)
- [Discards and the discard pattern](discards.md)
- [Tuple types](../types/tuples.md)
- [Record types](../types/records.md)
- [`out` parameter modifier](../../language-reference/keywords/method-parameters.md#out-parameter-modifier)
