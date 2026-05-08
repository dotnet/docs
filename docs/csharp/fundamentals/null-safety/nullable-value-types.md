---
title: "Nullable value types in C#"
description: Learn how to use nullable value types (T?) in C# to represent value types that can be absent or undefined.
ms.date: 04/30/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Nullable value types: C# Fundamentals

> [!TIP]
> This article is part of the **Fundamentals** section for developers who know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. For more details, see [Nullable value types](../../language-reference/builtin-types/nullable-value-types.md) in the language reference.

A *nullable value type* `T?` represents all values of its underlying value type `T`, plus an additional `null` value. A variable of type `int?` holds any integer or `null` to represent "no value."

Value types such as `int`, `bool`, and `DateTime` can't hold `null` by default. This behavior is efficient and prevents many errors. However, this limitation creates a problem when a value might genuinely be absent. A common scenario is reading from a database: an integer column might contain a number, or it might contain no value at all (`NULL` in SQL). A plain `int` can't represent that absence, but `int?` can.

## Declare a nullable value type

Append `?` to any value type to make it nullable:

:::code language="csharp" source="snippets/nullable-value-types/Program.cs" ID="Declaration":::

The default value of a nullable value type is `null`, not the underlying type's default.

## Check whether a value is present

The recommended way to check a nullable value type and extract its value is with a *type pattern*:

:::code language="csharp" source="snippets/nullable-value-types/Program.cs" ID="PatternMatching":::

The `is int degrees` pattern matches only when `temperature` is non-null, and it simultaneously binds the value to `degrees`. You get both the null check and the value extraction in one step.

Alternatively, use the `HasValue` and `Value` properties:

:::code language="csharp" source="snippets/nullable-value-types/Program.cs" ID="HasValue":::

Prefer the `is T value` pattern for new code. It introduces a new non-nullable variable scoped to the matched branch, which makes the intent clearer and eliminates any temptation to accidentally use `Value` outside a null check, where it would throw an <xref:System.InvalidOperationException>.

You can also compare directly with `null`:

:::code language="csharp" source="snippets/nullable-value-types/Program.cs" ID="NullCheck":::

## Get a value with a fallback

When you need a non-nullable value from a nullable, use `GetValueOrDefault` or the null-coalescing `??` operator:

:::code language="csharp" source="snippets/nullable-value-types/Program.cs" ID="GetValueOrDefault":::

The `??` operator is often cleaner inline:

:::code language="csharp" source="snippets/nullable-value-types/Program.cs" ID="NullCoalescing":::

Both approaches return the actual value when one is present, and the fallback you specify when it isn't.

## Arithmetic with nullable value types

Arithmetic and comparison operators on nullable value types are *lifted*: when either operand is `null`, the result is `null` rather than an error.

:::code language="csharp" source="snippets/nullable-value-types/Program.cs" ID="LiftedOperators":::

Null propagates through arithmetic by default. To prevent a null result from cascading further, extract the value with `??` or `GetValueOrDefault` before you use it in a calculation.

## See also

- [Null safety overview](index.md)
- [Null operators](null-operators.md)
- [Nullable value types (language reference)](../../language-reference/builtin-types/nullable-value-types.md)
- [Nullable reference types](../../nullable-references.md)
