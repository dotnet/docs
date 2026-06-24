---
title: "Compare strings in C#"
description: Learn how to compare strings in C# for equality and sort order, how ordinal and culture-aware comparisons differ, and how to choose a StringComparison value.
ms.date: 06/24/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Compare strings in C\#

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../../tour-of-csharp/tutorials/index.md) tutorials first.
>
> **Coming from another language?** C# `==` on strings compares *values*, not references, much like Java's `equals` or JavaScript's `===`. The key difference is that C# lets you choose between **ordinal** (binary) and **culture-aware** comparison through a <xref:System.StringComparison> value.

You compare strings to answer one of two questions: *Are these two strings equal?* or *In what order do these strings sort?* C# lets you control two independent factors when you answer either question:

- **Case sensitivity** — whether `"Hello"` and `"hello"` are treated as equal.
- **Comparison kind** — *ordinal* (compare the binary value of each character) or *culture-aware* (apply the linguistic rules of a culture).

The <xref:System.StringComparison> enumeration combines these factors into a single value you pass to comparison methods.

## Compare for equality

The <xref:System.String.Equals*?displayProperty=nameWithType> method and the `==` operator both perform a **case-sensitive, ordinal** comparison by default. Ordinal comparison checks the binary value of each character, so it's fast and gives the same result on every machine. You can make your intent explicit by calling the overload that takes a <xref:System.StringComparison> value:

:::code language="csharp" source="snippets/compare/Program.cs" id="DefaultEquality":::

To ignore case while keeping ordinal semantics, pass <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType>:

:::code language="csharp" source="snippets/compare/Program.cs" id="IgnoreCase":::

## Compare for sort order

To determine sort order rather than equality, use <xref:System.String.Compare*?displayProperty=nameWithType>. It returns a negative number, zero, or a positive number to indicate whether the first string sorts before, at the same position as, or after the second:

:::code language="csharp" source="snippets/compare/Program.cs" id="Order":::

> [!IMPORTANT]
> `Compare` and `CompareTo` default to a *culture-aware* comparison, while `Equals` and `==` default to *ordinal*. To avoid surprises, pass an explicit <xref:System.StringComparison> value so your code states which behavior it wants.

## Compare against constants with pattern matching `is` or `switch`

When the value you compare against is a constant, you can use the [`is` operator](../../../language-reference/operators/is.md) with a [constant pattern](../../../language-reference/operators/patterns.md#constant-pattern) as a readable alternative to `==`:

:::code language="csharp" source="snippets/compare/Program.cs" id="ConstantPattern":::

To compare a string against several constants, use a [`switch` expression](../../../language-reference/operators/switch-expression.md). Each arm tests a [constant pattern](../../../language-reference/operators/patterns.md#constant-pattern), and the discard pattern (`_`) handles every value that doesn't match. The next example maps a direction keyword to a travel instruction:

:::code language="csharp" source="snippets/compare/Program.cs" id="SwitchExpression":::

A `switch` expression that tests string constants performs the same case-sensitive, ordinal comparison as `==`, so `"north"` doesn't match the `"North"` arm.

## Choose the right comparison

Pick the comparison kind based on the data, not out of habit:

- For identifiers, file paths, protocol tokens, and other machine-defined text, use <xref:System.StringComparison.Ordinal> (or <xref:System.StringComparison.OrdinalIgnoreCase> to ignore case). Ordinal comparison is fast and consistent across cultures.
- For text that users read and sort, such as names or product titles, use <xref:System.StringComparison.CurrentCulture> so the order matches the user's expectations.

Culture-aware comparison applies linguistic rules that vary by culture and can produce surprising results. For example, some cultures treat `"ss"` and `"ß"` as equal, and the order of strings can change between machines. Because of that variability, reserve culture-aware comparison for genuine natural-language text, and use the same comparison kind whenever you both sort and search a collection.

For an in-depth treatment of culture-sensitive comparison, including globalization considerations and platform differences, see [Best practices for comparing strings in .NET](../../../../standard/base-types/best-practices-strings.md).

## See also

- [Best practices for comparing strings in .NET](../../../../standard/base-types/best-practices-strings.md)
- [Search strings in C#](search.md)
- <xref:System.StringComparison>
- <xref:System.String.Compare*?displayProperty=nameWithType>
