---
title: "Type conversions, casting, and boxing"
description: Learn how to convert between C# types by using implicit and explicit conversions, safe casting patterns, boxing and unboxing, and Parse and TryParse APIs.
ms.date: 04/10/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Type conversions, casting, and boxing

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. You practice basic types there before you make conversion choices.
>
> **Experienced in another language?** C# conversions work like most statically typed languages: widening conversions are implicit, narrowing conversions need explicit casts, and parsing text should favor `TryParse` in user-facing code.

When you write C# code, you often move values from one type to another. For example, you might convert from `int` to `long`, read text and convert it to a number, or cast a base type to a derived type.

Choose the conversion style based on risk:

- Use an implicit conversion when the compiler proves the conversion is safe.
- Use an explicit cast when data might be lost or the conversion might fail.
- Use pattern matching or `as` when you need safe reference-type conversions.
- Use parsing APIs when your source value is text.

## Use implicit and explicit numeric conversions

Use implicit conversions when the destination type can represent the full source range. Use explicit casts when the destination type has a smaller range or less precision.

:::code language="csharp" source="snippets/conversions/Program.cs" ID="ImplicitAndExplicitNumeric":::

An explicit cast tells readers that the conversion might lose information. In the sample, the `double` value is truncated when converted to `int`.

For full conversion tables, see [Built-in numeric conversions](../../language-reference/builtin-types/numeric-conversions.md).

## Convert references safely

For reference types, you often start with a base type and need to access members from a derived type. Prefer pattern matching so the test and assignment happen together.

:::code language="csharp" source="snippets/conversions/Program.cs" ID="ReferenceConversions":::

Pattern matching keeps the successful cast variable in the smallest practical scope, which improves readability.

If you need a nullable result instead of a conditional branch, use `as`:

:::code language="csharp" source="snippets/conversions/Program.cs" ID="AsOperator":::

Use `as` only with reference types and nullable value types. It returns `null` when conversion fails.

## Understand boxing and unboxing

Boxing converts a value type to `object` or to an implemented interface type. Unboxing extracts the value type from that object reference.

:::code language="csharp" source="snippets/conversions/Program.cs" ID="BoxingAndUnboxing":::

Boxing allocates memory on the managed heap, and unboxing requires a type check. In hot paths, avoid unnecessary boxing because it adds allocations and extra work.

## Parse text by using Parse and TryParse

When you convert user input or file content, start with `TryParse`. It avoids exceptions for expected invalid input and makes failure handling explicit.

:::code language="csharp" source="snippets/conversions/Program.cs" ID="ParseAndTryParse":::

Use `Parse` when input is guaranteed to be valid, such as controlled test data. Use `TryParse` for user input, network payloads, and file data.

## Core conversion APIs

Use these APIs most often in everyday code:

- <xref:System.Int32.Parse(System.String)?displayProperty=nameWithType>
- <xref:System.Int32.TryParse*?displayProperty=nameWithType>
- <xref:System.Double.TryParse*?displayProperty=nameWithType>
- <xref:System.Decimal.TryParse*?displayProperty=nameWithType>
- <xref:System.IConvertible?displayProperty=nameWithType>

For advanced conversion behavior and all overloads, review the API reference for the specific target type.

## See also

- [Type system overview](index.md)
- [Built-in types and literals](built-in-types.md)
- [Pattern matching](../functional/pattern-matching.md)
- [How to safely cast by using pattern matching and the is and as operators](../tutorials/safely-cast-using-pattern-matching-is-and-as-operators.md)
