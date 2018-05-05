---
title: String interpolation in C#
description: Learn how to perform common string formatting tasks in C# using the string interpolation feature
author: pkulikov
ms.date: 05/07/2018
---
# String interpolation in C# #

The [string interpolation](../language-reference/tokens/interpolated.md) feature is built on top of the [composite formatting](../../standard/base-types/composite-formatting.md) feature and provides a more readable and convenient syntax to format string output.

To identify a string literal as an interpolated string, prepend it with the `$` symbol. You can embed any valid C# expression that returns a value into an interpolated string:

[!code-csharp-interactive[string interpolation example](~/samples/snippets/csharp/tutorials/string-interpolation/Program.cs#1)]

As the example above shows, you include an expression into an interpolated string by surrounding it with braces:

```
{<interpolatedExpression>}
```

At compile time an interpolated string is typically transformed to the <xref:System.String.Format%2A?displayProperty=nameWithType> method call. That makes all the capabilities of the [string composite formatting](../../standard/base-types/composite-formatting.md) feature available to you to use with interpolated strings as well. If an interpolated string is implicitly converted to either <xref:System.FormattableString?displayProperty=nameWithType> or <xref:System.IFormattable?displayProperty=nameWithType>, at compile time it's transformed to the expression that produces a <xref:System.FormattableString> instance. That allows you to provide the <xref:Syste.IFormatProvider> implementation to be used during the resolution of an interpolated string into the result string.

## How to specify a format string for an interpolated expression

You specify a format string that is supported by the type of the expression result by following the interpolated expression with a colon (":") and the format string:

```
{<interpolatedExpression>:<formatString>}
```

The following example shows how to specify standard and custom format strings for expressions that produce date and time or numeric results:

[!code-csharp-interactive[format string example](~/samples/snippets/csharp/tutorials/string-interpolation/Program.cs#2)]

For more information, see the [Format String Component](../../standard/base-types/composite-formatting.md#format-string-component) section of the [Composite Formatting](../../standard/base-types/composite-formatting.md) topic. That section provides links to the topics that describe standard and custom format strings supported by .NET base types.

## How to control the field width and alignment of the formatted interpolated expression

You specify the minimum field width in which string representation of the expression result is inserted and the text alignment within that field by following the interpolated expression with a comma (",") and the constant expression that defines alignment:

```
{<interpolatedExpression>,<alignment>}
```

If the alignment value is positive, the formatted string representation of the expression result is right-aligned; if negative, it's left-aligned.

If you need to specify both alignment and a format string, start with the alignment component:

```
{<interpolatedExpression>,<alignment>:<formatString>}
```

The following example shows how to specify alignment:

[!code-csharp-interactive[alignment example](~/samples/snippets/csharp/tutorials/string-interpolation/Program.cs#3)]

For more information, see the [Alignment Component](../../standard/base-types/composite-formatting.md#alignment-component) section of the [Composite Formatting](../../standard/base-types/composite-formatting.md) topic.

## How to use escape sequences in an interpolated string

Interpolated strings support all escape sequences that can be used in ordinary string literals. For more information, see [String escape sequences](../programming-guide/strings/index.md#string-escape-sequences). To include a brace, "{" or "}", in the result string, use two braces, "{{" or "}}". For more information, see the [Escaping Braces](../../standard/base-types/composite-formatting.md#escaping-braces) section of the [Composite Formatting](../../standard/base-types/composite-formatting.md) topic.

[Verbatim](../language-reference/tokens/verbatim.md) interpolated strings start with the `$` character followed by the `@` character.

The following example shows how to include braces into the result string and construct a verbatim interpolated string:

[!code-csharp-interactive[escape sequence example](~/samples/snippets/csharp/tutorials/string-interpolation/Program.cs#4)]

## How to use a ternary conditional operator in an interpolated expression

As the colon (":") has special meaning in an item with an interpolated expression, in order to use a [conditional operator](../language-reference/operators/conditional-operator.md) in an expression, enclose it in parentheses, as the following example shows:

[!code-csharp-interactive[conditional operator example](~/samples/snippets/csharp/tutorials/string-interpolation/Program.cs#5)]

## How to create a culture-specific result string with string interpolation

By default, an interpolated string resolves to the result string with the use of the current culture defined by the <xref:System.Globalization.CultureInfo.CurrentCulture> property. Use implicit conversion of an interpolated string to a <xref:System.FormattableString?displayProperty=nameWithType> instance and its <xref:System.FormattableString.ToString(System.IFormatProvider)> method to create a culture-specific result string. The following example shows how to do that:

[!code-csharp-interactive[specify different cultures](~/samples/snippets/csharp/tutorials/string-interpolation/Program.cs#6)]

You can use one <xref:System.FormattableString> instance to generate multiple result strings for various cultures.

## How to create the result string for the invariant culture

Along with the <xref:System.FormattableString.ToString(System.IFormatProvider)?displayProperty=nameWithType> method, you can use the static <xref:System.FormattableString.Invariant%2A?displayProperty=nameWithType> method to resolve an interpolated string into the result string for the <xref:System.Globalization.CultureInfo.InvariantCulture>. The following example shows how to do that:

[!code-csharp-interactive[format with invariant culture](~/samples/snippets/csharp/tutorials/string-interpolation/Program.cs#7)]

## Conclusion

This tutorial describes the most common scenarios of the string interpolation usage. For more information about string interpolation, see the [String interpolation](../language-reference/tokens/interpolated.md) topic. For more information about formatting types in .NET, see the [Formatting Types in .NET](../../standard/base-types/formatting-types.md) and [Composite formatting](../../standard/base-types/composite-formatting.md) topics.

## See also

<xref:System.String.Format%2A?displayProperty=nameWithType>  
<xref:System.FormattableString?displayProperty=nameWithType>  
<xref:System.IFormattable?displayProperty=nameWithType>  
[Strings](../programming-guide/strings/index.md)  
