---
title: "$ - string interpolation - C# Reference"
ms.custom: seodec18
description: String interpolation provides a more readable and convenient syntax to format string output than traditional string composite formatting.
ms.date: 04/29/2019
f1_keywords: 
  - "$_CSharpKeyword"
  - "$"
helpviewer_keywords: 
  - "$ special character [C#]"
  - "$ language element [C#]"
  - "string interpolation [C#]"
  - "interpolated string [C#]"
author: pkulikov
ms.author: ronpet
---
# $ - string interpolation (C# Reference)

The `$` special character identifies a string literal as an *interpolated string*. An interpolated string is a string literal that might contain *interpolation expressions*. When an interpolated string is resolved to a result string, items with interpolation expressions are replaced by the string representations of the expression results. This feature is available in C# 6 and later versions of the language.

String interpolation provides a more readable and convenient syntax to create formatted strings than a [string composite formatting](../../../standard/base-types/composite-formatting.md) feature. The following example uses both features to produce the same output:

[!code-csharp-interactive[compare with composite formatting](~/samples/snippets/csharp/language-reference/tokens/string-interpolation.cs#1)]

## Structure of an interpolated string

To identify a string literal as an interpolated string, prepend it with the `$` symbol. You cannot have any white space between the `$` and the `"` that starts a string literal. Doing so causes a compile-time error.

The structure of an item with an interpolation expression is as follows:

```csharp
{<interpolationExpression>[,<alignment>][:<formatString>]}
```

Elements in square brackets are optional. The following table describes each element:    

|Element|Description|
|-------------|-----------------|
|`interpolationExpression`|The expression that produces a result to be formatted. String representation of the `null` result is <xref:System.String.Empty?displayProperty=nameWithType>.|
|`alignment`|The constant expression whose value defines the minimum number of characters in the string representation of the result of the interpolation expression. If positive, the string representation is right-aligned; if negative, it's left-aligned. For more information, see [Alignment Component](../../../standard/base-types/composite-formatting.md#alignment-component).|
|`formatString`|A format string that is supported by the type of the expression result. For more information, see [Format String Component](../../../standard/base-types/composite-formatting.md#format-string-component).|

The following example uses optional formatting components described above:

[!code-csharp-interactive[specify alignment and format string](~/samples/snippets/csharp/language-reference/tokens/string-interpolation.cs#2)]

## Special characters

To include a brace, "{" or "}", in the text produced by an interpolated string, use two braces, "{{" or "}}". For more information, see [Escaping Braces](../../../standard/base-types/composite-formatting.md#escaping-braces).

As the colon (":") has special meaning in an interpolation expression item, in order to use a [conditional operator](../operators/conditional-operator.md) in an interpolation expression, enclose that expression in parentheses.

The following example shows how to include a brace in a result string and how to use a conditional operator in an interpolation expression:

[!code-csharp-interactive[example with ternary conditional operator](~/samples/snippets/csharp/language-reference/tokens/string-interpolation.cs#3)]

A verbatim interpolated string starts with the `$` character followed by the `@` character. For more information about verbatim strings, see the [string](../keywords/string.md) and [verbatim identifier](verbatim.md) topics.

> [!NOTE]
> The `$` token must appear before the `@` token in a verbatim interpolated string.

## Implicit conversions and specifying `IFormatProvider` implementation

There are three implicit conversions from an interpolated string:

1. Conversion of an interpolated string to a <xref:System.String> instance that is the result of interpolated string resolution with interpolation expression items being replaced with the properly formatted string representations of their results. This conversion uses the current culture.

1. Conversion of an interpolated string to a <xref:System.FormattableString> instance that represents a composite format string along with the expression results to be formatted. That allows you to create multiple result strings with culture-specific content from a single <xref:System.FormattableString> instance. To do that call one of the following methods:

      - A <xref:System.FormattableString.ToString> overload that produces a result string for the <xref:System.Globalization.CultureInfo.CurrentCulture>.
      - An <xref:System.FormattableString.Invariant%2A> method that produces a result string for the <xref:System.Globalization.CultureInfo.InvariantCulture>.
      - A <xref:System.FormattableString.ToString(System.IFormatProvider)> method that produces a result string for a specified culture.

    You also can use the <xref:System.FormattableString.ToString(System.IFormatProvider)> method to provide a user-defined implementation of the <xref:System.IFormatProvider> interface that supports custom formatting. For more information, see [Custom Formatting with ICustomFormatter](../../../standard/base-types/formatting-types.md#custom-formatting-with-icustomformatter).

1. Conversion of an interpolated string to an <xref:System.IFormattable> instance that also allows you to create multiple result strings with culture-specific content from a single <xref:System.IFormattable> instance.

The following example uses implicit conversion to <xref:System.FormattableString> to create culture-specific result strings:

[!code-csharp-interactive[create culture-specific result strings](~/samples/snippets/csharp/language-reference/tokens/string-interpolation.cs#4)]

## Additional resources

If you are new to string interpolation, see the [String interpolation in C#](../../tutorials/exploration/interpolated-strings.yml) interactive tutorial. You also can check another [String interpolation in C#](../../tutorials/string-interpolation.md) tutorial that demonstrates how to use interpolated strings to produce formatted strings.

## Compilation of interpolated strings

If an interpolated string has the type `string`, it's typically transformed into a <xref:System.String.Format%2A?displayProperty=nameWithType> method call. The compiler may replace <xref:System.String.Format%2A?displayProperty=nameWithType> with <xref:System.String.Concat%2A?displayProperty=nameWithType> if the analyzed behavior would be equivalent to concatenation.

If an interpolated string has the type <xref:System.IFormattable> or <xref:System.FormattableString>, the compiler generates a call to the <xref:System.Runtime.CompilerServices.FormattableStringFactory.Create%2A?displayProperty=nameWithType> method.

## C# language specification

For more information, see the [Interpolated strings](~/_csharplang/spec/expressions.md#interpolated-strings) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- <xref:System.String.Format%2A?displayProperty=nameWithType>
- <xref:System.FormattableString?displayProperty=nameWithType>
- <xref:System.IFormattable?displayProperty=nameWithType>
- [Composite formatting](../../../standard/base-types/composite-formatting.md)
- [Formatting numeric results table](../keywords/formatting-numeric-results-table.md)
- [Strings](../../programming-guide/strings/index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Special Characters](index.md)
- [C# Reference](../index.md)
