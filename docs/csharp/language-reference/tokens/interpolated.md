---
title: "$ - string interpolation - format string output"
description: String interpolation using the `$` token provides a more readable and convenient syntax to format string output than traditional string composite formatting.
ms.date: 11/29/2022
f1_keywords:
    - "$_CSharpKeyword"
    - "$"
helpviewer_keywords:
    - "$ special character [C#]"
    - "string interpolation [C#]"
    - "interpolated string [C#]"
author: pkulikov
---

# String interpolation using `$`

The `$` special character identifies a string literal as an _interpolated string_. An interpolated string is a string literal that might contain _interpolation expressions_. When an interpolated string is resolved to a result string, items with interpolation expressions are replaced by the string representations of the expression results.

String interpolation provides a more readable, convenient syntax to format strings. It's easier to read than [string composite formatting](../../../standard/base-types/composite-formatting.md). Compare the following example that uses both features to produce the same output:

:::code language="csharp" source="./snippets/string-interpolation.cs" id="Snippet1":::

## Structure of an interpolated string

To identify a string literal as an interpolated string, prepend it with the `$` symbol. You cannot have any white space between the `$` and the `"` that starts a string literal. To concatenate multiple interpolated strings, add the `$` special character to each string literal.

The structure of an item with an interpolation expression is as follows:

```csharp
{<interpolationExpression>[,<alignment>][:<formatString>]}
```

Elements in square brackets are optional. The following table describes each element:

| Element                   | Description                                                                                                                                                                                                                                                                                                                                             |
| ------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `interpolationExpression` | The expression that produces a result to be formatted. String representation of `null` is <xref:System.String.Empty?displayProperty=nameWithType>.                                                                                                                                                                                                      |
| `alignment`               | The constant expression whose value defines the minimum number of characters in the string representation of the expression result. If positive, the string representation is right-aligned; if negative, it's left-aligned. For more information, see [Alignment Component](../../../standard/base-types/composite-formatting.md#alignment-component). |
| `formatString`            | A format string that is supported by the type of the expression result. For more information, see [Format String Component](../../../standard/base-types/composite-formatting.md#format-string-component).                                                                                                                                              |

The following example uses optional formatting components described above:

:::code language="csharp" source="./snippets/string-interpolation.cs" id="Snippet2":::

Beginning with C# 10, you can use string interpolation to initialize a constant string. All expressions used for placeholders must be constant strings. In other words, every _interpolation expression_ must be a string, and it must be a compile time constant.

Beginning with C# 11, the interpolated expressions can include newlines. The text between the `{` and `}` must be valid C#, therefore it can include newlines that improve readability. The following example shows how newlines can improve the readability of an expression involving pattern matching:

:::code language="csharp" source="./snippets/string-interpolation.cs" id="Newlines":::

Also, beginning in C# 11, you can use a [raw string literal](../builtin-types/reference-types.md#string-literals) for the format string:

:::code language="csharp" source="./snippets/string-interpolation.cs" id="RawInterpolatedLiteralString":::

You can use multiple `$` characters in an interpolated raw string literal to embed `{` and `}` characters in the output string without escaping them:

:::code language="csharp" source="./snippets/string-interpolation.cs" id="RawInterpolatedLiteralStringWithBraces":::

If your output string should contain repeated `{` or `}` characters, you can add more `$` to designate the interpolated string. Any sequence of `{` or `}` shorter than the number of `$` will be embedded in the output string. As shown in the preceding example, sequences longer than the sequence of `$` characters embed the additional `{` or `}` characters in the output. The compiler issues an error if the sequence of brace characters is equal to or greater than double the length of the sequence of `$` characters.

You can try these features using the .NET 7 SDK. Or, if you have the .NET SDK 6.00.200 or later, you can set the `<LangVersion>` element in your _csproj_ file to `preview`.

## Special characters

To include a brace, "{" or "}", in the text produced by an interpolated string, use two braces, "{{" or "}}". For more information, see [Escaping Braces](../../../standard/base-types/composite-formatting.md#escaping-braces).

As the colon (":") has special meaning in an interpolation expression item, to use a [conditional operator](../operators/conditional-operator.md) in an interpolation expression, enclose that expression in parentheses.

The following example shows how to include a brace in a result string. It also shows how to use a conditional operator:

:::code language="csharp" source="./snippets/string-interpolation.cs" id="Snippet3":::

An interpolated verbatim string starts with the `$` character followed by the `@` character. You can use the `$` and `@` tokens in any order: both `$@"..."` and `@$"..."` are valid interpolated verbatim strings. For more information about verbatim strings, see the [string](../builtin-types/reference-types.md) and [verbatim identifier](verbatim.md) articles.

## Implicit conversions and how to specify `IFormatProvider` implementation

There are three implicit conversions from an interpolated string:

1. Conversion of an interpolated string to a <xref:System.String> instance. The string is the result of interpolated string resolution. All interpolation expression items are replaced with the properly formatted string representations of their results. This conversion uses the <xref:System.Globalization.CultureInfo.CurrentCulture> to format expression results.

1. Conversion of an interpolated string to a <xref:System.FormattableString> instance that represents a composite format string along with the expression results to be formatted. That allows you to create multiple result strings with culture-specific content from a single <xref:System.FormattableString> instance. To do that, call one of the following methods:

    - A <xref:System.FormattableString.ToString> overload that produces a result string for the <xref:System.Globalization.CultureInfo.CurrentCulture>.
    - An <xref:System.FormattableString.Invariant%2A> method that produces a result string for the <xref:System.Globalization.CultureInfo.InvariantCulture>.
    - A <xref:System.FormattableString.ToString(System.IFormatProvider)> method that produces a result string for a specified culture.

    The <xref:System.FormattableString.ToString(System.IFormatProvider)> provides a user-defined implementation of the <xref:System.IFormatProvider> interface that supports custom formatting. For more information, see the [Custom formatting with ICustomFormatter](../../../standard/base-types/formatting-types.md#custom-formatting-with-icustomformatter) section of the [Formatting types in .NET](../../../standard/base-types/formatting-types.md) article.

1. Conversion of an interpolated string to an <xref:System.IFormattable> instance that also allows you to create multiple result strings with culture-specific content from a single <xref:System.IFormattable> instance.

The following example uses implicit conversion to <xref:System.FormattableString> to create culture-specific result strings:

:::code language="csharp" source="./snippets/string-interpolation.cs" id="Snippet4":::

## Other resources

If you're new to string interpolation, see the [String interpolation in C#](../../tutorials/exploration/interpolated-strings.yml) interactive tutorial. You can also check another [String interpolation in C#](../../tutorials/string-interpolation.md) tutorial. That tutorial demonstrates how to use interpolated strings to produce formatted strings.

## Compilation of interpolated strings

If an interpolated string has the type `string`, it's typically transformed into a <xref:System.String.Format%2A?displayProperty=nameWithType> method call. The compiler may replace <xref:System.String.Format%2A?displayProperty=nameWithType> with <xref:System.String.Concat%2A?displayProperty=nameWithType> if the analyzed behavior would be equivalent to concatenation.

If an interpolated string has the type <xref:System.IFormattable> or <xref:System.FormattableString>, the compiler generates a call to the <xref:System.Runtime.CompilerServices.FormattableStringFactory.Create%2A?displayProperty=nameWithType> method.

Beginning with C# 10, when an interpolated string is used, the compiler checks if the interpolated string is assigned to a type that satisfies the _interpolated string handler pattern_. An _interpolated string handler_ is a custom type that converts the interpolated string into a string. An interpolated string handler is an advanced scenario, typically used for performance reasons. You can learn about the requirements to build an interpolated string handler in the language specification for [interpolated string improvements](~/_csharplang/proposals/csharp-10.0/improved-interpolated-strings.md#the-handler-pattern). You can build one following the [interpolated string handler tutorial](../../whats-new/tutorials/interpolated-string-handler.md) in the What's new in C# section. In .NET 6, when you use an interpolated string for an argument of type `string`, the interpolated string is processed by the <xref:System.Runtime.CompilerServices.DefaultInterpolatedStringHandler?displayProperty=fullName>.

> [!NOTE]
> One side effect of interpolated string handlers is that a custom handler, including <xref:System.Runtime.CompilerServices.DefaultInterpolatedStringHandler?displayProperty=nameWithType>, may not evaluate all the expressions used as placeholders in the interpolated string under all conditions. That means side-effects in those expressions may not occur.

## C# language specification

For more information, see the [Interpolated strings](~/_csharpstandard/standard/expressions.md#1173-interpolated-string-expressions) section of the [C# language specification](~/_csharpstandard/standard/README.md), the [C# 11 - Raw string literals](~/_csharplang/proposals/csharp-11.0/raw-string-literal.md) feature specification and the [C# 11 - Newlines in string interpolations](~/_csharplang/proposals/csharp-11.0/new-line-in-interpolation.md) feature specification.

## See also

- [Simplify interpolation (style rule IDE0071)](../../../fundamentals/code-analysis/style-rules/ide0071.md)
- [C# reference](../index.md)
- [C# special characters](index.md)
- [Strings](../../programming-guide/strings/index.md)
- [Standard numeric format strings](../../../standard/base-types/standard-numeric-format-strings.md)
- [Composite formatting](../../../standard/base-types/composite-formatting.md)
- <xref:System.String.Format%2A?displayProperty=nameWithType>
