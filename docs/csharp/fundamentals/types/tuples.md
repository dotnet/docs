---
title: "Tuples and deconstruction"
description: Learn how to use tuples to group related values, deconstruct tuples into separate variables, compare tuples for equality, and choose tuples over anonymous types.
ms.date: 04/07/2026
ms.topic: concept-article
ai-usage: ai-assisted
---
# Tuples and deconstruction

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. You'll encounter tuples once you need to return multiple values from a method or group values without defining a named type.
>
> **Experienced in another language?** C# tuples are value types similar to tuples in Python or Swift, but with optional named elements and full deconstruction support. Skim the [deconstruction](#deconstruct-tuples) and [equality](#tuple-equality) sections for C#-specific patterns.

A *tuple* groups multiple values into a single, lightweight structure without requiring you to define a named type. Tuples are value types that you can declare inline, return from methods, and deconstruct into individual variables. Use tuples when you need a quick, temporary grouping of related values—such as returning multiple results from a method or storing a coordinate pair.

The following example creates a tuple with named elements and accesses each element by name:

:::code language="csharp" source="snippets/tuples/Program.cs" ID="BasicTuple":::

Tuples work well for short-lived groupings where defining a class, struct, or record would add unnecessary ceremony. For long-lived domain concepts or types with behavior, prefer [records](records.md), [classes](classes.md), or [structs](structs.md). For a comparison of when to use each, see [Choose which kind of type](index.md#choose-which-kind-of-type).

## Declare and initialize tuples

Declare a tuple by listing the element types in parentheses. You can optionally name each element to make the code more readable:

:::code language="csharp" source="snippets/tuples/Program.cs" ID="DeclareTuples":::

When you don't provide names, elements use default names `Item1`, `Item2`, and so on. Named elements make your code self-documenting without requiring a separate type definition.

### Inferred element names

The compiler can infer element names from the variable names or property names you use to initialize the tuple. This feature avoids redundancy when the names match:

:::code language="csharp" source="snippets/tuples/Program.cs" ID="InferredNames":::

Inferred names keep your code concise. If you need a different element name, specify it explicitly.

## Return multiple values from a method

One of the most common uses for tuples is returning multiple values from a method. Instead of defining a class or using `out` parameters, return a tuple with named elements:

:::code language="csharp" source="snippets/tuples/Program.cs" ID="MethodReturn":::

Named tuple elements make the return values readable at both the call site and the method signature. The caller can access each value by name without needing to remember positional order.

## Deconstruct tuples

*Deconstruction* unpacks a tuple's elements into separate variables in a single statement. You can deconstruct tuples in several ways:

:::code language="csharp" source="snippets/tuples/Program.cs" ID="Deconstruction":::

Deconstruction is especially useful when you receive a tuple from a method call and immediately need to work with its individual values.

### Deconstruction in loops

You can deconstruct tuples directly in `foreach` loops, which makes iterating over collections of grouped values concise:

:::code language="csharp" source="snippets/tuples/Program.cs" ID="DeconstructionLoop":::

### Discards in deconstruction

When you don't need every element, use a *discard* (`_`) to ignore specific values. A single discard represents all ignored values:

:::code language="csharp" source="snippets/tuples/Program.cs" ID="Discards":::

For more about using discards across different contexts, see [Discards](../functional/discards.md).

### Deconstruct other types

Deconstruction isn't limited to tuples. Records automatically support deconstruction, and you can add a `Deconstruct` method to any class or struct. For user-defined deconstruction, extension methods, and record deconstruction, see [Deconstructing tuples and other types](../functional/deconstruct.md).

## Tuple equality

You can compare tuples using `==` and `!=`. These operators compare each element in order, so two tuples are equal when all their corresponding elements are equal:

:::code language="csharp" source="snippets/tuples/Program.cs" ID="TupleEquality":::

Tuple equality uses the `==` operator defined on each element type, which means the comparison works correctly for strings, numbers, and other types that define `==`. Element names don't affect equality—only values and positions matter.

## Nondestructive mutation with `with`

The `with` expression creates a copy of a tuple with one or more elements changed, leaving the original unchanged:

:::code language="csharp" source="snippets/tuples/Program.cs" ID="WithExpression":::

This pattern is useful when you want a variation of an existing tuple without modifying the original. The `with` expression works the same way on tuples as it does on [records](records.md).

## Tuples in dictionaries and lookups

Tuples make convenient dictionary values when you need to associate a key with multiple pieces of data:

:::code language="csharp" source="snippets/tuples/Program.cs" ID="DictionaryTuple":::

This pattern avoids needing a separate class for simple key-to-multiple-value mappings.

## Tuples vs. anonymous types

Tuples are the preferred choice when you need a lightweight unnamed data structure. Anonymous types remain available for expression tree scenarios and for code that requires reference types, but tuples offer better performance, deconstruction support, and more flexible syntax. For more about anonymous types, see [Anonymous types](../../programming-guide/classes-and-structs/anonymous-types.md) in the language reference.

## See also

- [Tuple types (C# reference)](../../language-reference/builtin-types/value-tuples.md) for complete syntax details
- [Deconstructing tuples and other types](../functional/deconstruct.md) for user-defined `Deconstruct` methods
- [Discards](../functional/discards.md)
- [Records](records.md)
