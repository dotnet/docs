---
title: "Type conversions, casting, and boxing"
description: Learn how to convert between C# types by using implicit and explicit conversions, safe casting patterns, boxing and unboxing, and Parse and TryParse APIs.
ms.date: 04/14/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Type conversions, casting, and boxing

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. You practice basic types there before you make conversion choices.
>
> **Experienced in another language?** C# conversions work like most statically typed languages: widening conversions are implicit, narrowing conversions need explicit casts, and parsing text should favor `TryParse` in user-facing code.

When you write C# code, you often convert values from one type to another. For example, you might convert from `int` to `long`, read text and convert it to a number, or cast a base type to a derived type.

Understanding key terms:

- A *conversion* is the process of changing a value from one type to another.
- A *cast* is the explicit syntax for conversion, written with parentheses like `(int)value`.
- An *implicit conversion* is a conversion that happens automatically when the compiler can guarantee it's safe.
- An *explicit cast* is a conversion you write in code, indicating the conversion might lose information or fail.

Match the conversion style to the situation:

- Implicit conversions happen automatically when the compiler can guarantee safety—no syntax required.
- Explicit casts are required when data might be lost or the conversion might fail.
- Pattern matching or `as` applies when you need a safe reference-type conversion that might not succeed.
- Parsing APIs apply when your source value is text.

## Implicit and explicit numeric conversions

An *implicit conversion* always succeeds. An *explicit conversion* might fail or lose information.

:::code language="csharp" source="snippets/conversions/Program.cs" ID="ImplicitAndExplicitNumeric":::

An explicit cast tells readers that the conversion might lose information. In the sample, the `double` value is truncated when converted to `int`.

For full conversion tables, see [Built-in numeric conversions](../../language-reference/builtin-types/numeric-conversions.md).

## Convert references

[Classes](classes.md) are reference types. Casts on them don't copy data. They change how you view the same object.

Some reference conversions are implicit. The compiler guarantees they're safe. Three situations always produce an implicit reference conversion: assigning a derived class instance to a base class variable (the derived type is a subtype of the base type), assigning a reference type instance to a variable of an interface the type implements, and assigning any reference type to an `object` variable.

:::code language="csharp" source="snippets/conversions/Program.cs" ID="ImplicitReferenceConversions":::

Going the other direction, from a base type back to a derived type, requires an explicit check, because the object might not actually be the derived type you expect. Prefer pattern matching so the test and assignment happen together.

:::code language="csharp" source="snippets/conversions/Program.cs" ID="ExplicitReferenceConversions":::

Pattern matching keeps the successful cast variable in the smallest practical scope, which improves readability.

If you need a nullable result instead of a conditional branch, use `as`:

:::code language="csharp" source="snippets/conversions/Program.cs" ID="AsOperator":::

Use `as` only with reference types and nullable value types. It returns `null` when conversion fails.

## Understand boxing and unboxing

Boxing converts a [struct](structs.md) or other value type to `object` or to an implemented interface type. Unboxing extracts the value type from that object reference.

:::code language="csharp" source="snippets/conversions/Program.cs" ID="BoxingAndUnboxing":::

Boxing allocates memory on the managed heap, and unboxing requires a type check. In hot paths, avoid unnecessary boxing because it adds allocations and extra work.

## Parse text by using Parse and TryParse

When you convert user input or file content, start with `TryParse`. It avoids exceptions for expected invalid input and makes failure handling explicit. All parsing APIs create a new object or value type instance from the source string; they don't modify the source.

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
