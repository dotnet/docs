---
title: String interpolation
description: Learn how to include formatted expression results in a result string in C# with string interpolation.
author: pkulikov
ms.subservice: fundamentals
ms.date: 08/28/2023
---
# String interpolation in C\#

This tutorial shows you how to use [string interpolation](../language-reference/tokens/interpolated.md) to format and include expression results in a result string. The examples assume that you are familiar with basic C# concepts and .NET type formatting. If you are new to string interpolation or .NET type formatting, check out the [interactive string interpolation tutorial](exploration/interpolated-strings.yml) first. For more information about formatting types in .NET, see [Formatting types in .NET](../../standard/base-types/formatting-types.md).

## Introduction

To identify a string literal as an interpolated string, prepend it with the `$` symbol. You can embed any valid C# expression that returns a value in an interpolated string. In the following example, as soon as an expression is evaluated, its result is converted into a string and included in a result string:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/StringInterpolation/Program.cs" id="General":::

As the example shows, you include an expression in an interpolated string by enclosing it with braces:

```csharp
{<interpolationExpression>}
```

Interpolated strings support all the capabilities of the [string composite formatting](../../standard/base-types/composite-formatting.md) feature. That makes them a more readable alternative to the use of the <xref:System.String.Format%2A?displayProperty=nameWithType> method.

## How to specify a format string for an interpolation expression

To specify a format string that's supported by the type of the expression result, follow the interpolation expression with a colon (":") and the format string:

```csharp
{<interpolationExpression>:<formatString>}
```

The following example shows how to specify standard and custom format strings for expressions that produce date and time or numeric results:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/StringInterpolation/Program.cs" id="FormatString":::

For more information, see the [Format string component](../../standard/base-types/composite-formatting.md#format-string-component) section of the [Composite formatting](../../standard/base-types/composite-formatting.md) article.

## How to control the field width and alignment of the formatted interpolation expression

To specify the minimum field width and the alignment of the formatted expression result, follow the interpolation expression with a comma (",") and the constant expression:

```csharp
{<interpolationExpression>,<width>}
```

If the *width* value is positive, the formatted expression result is right-aligned; if negative, it's left-aligned.

If you need to specify both width and a format string, start with the width component:

```csharp
{<interpolationExpression>,<width>:<formatString>}
```

The following example shows how to specify width and alignment, and uses pipe characters ("|") to delimit text fields:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/StringInterpolation/Program.cs" id="AlignmentAndFormatString":::

As the example output shows, if the length of the formatted expression result exceeds specified field width, the *width* value is ignored.

For more information, see the [Width component](../../standard/base-types/composite-formatting.md#alignment-component) section of the [Composite formatting](../../standard/base-types/composite-formatting.md) article.

## How to use escape sequences in an interpolated string

Interpolated strings support all escape sequences that can be used in ordinary string literals. For more information, see [String escape sequences](../programming-guide/strings/index.md#string-escape-sequences).

To interpret escape sequences literally, use a [verbatim](../language-reference/tokens/verbatim.md) string literal. An interpolated verbatim string starts with the both `$` and `@` characters. You can use `$` and `@` in any order: both `$@"..."` and `@$"..."` are valid interpolated verbatim strings.

To include a brace, "{" or "}", in a result string, use two braces, "{{" or "}}". For more information, see the [Escaping braces](../../standard/base-types/composite-formatting.md#escaping-braces) section of the [Composite formatting](../../standard/base-types/composite-formatting.md) article.

The following example shows how to include braces in a result string and construct a verbatim interpolated string:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/StringInterpolation/Program.cs" id="Escapes":::

Beginning with C# 11, you can use [interpolated raw string literals](../language-reference/tokens/interpolated.md#interpolated-raw-string-literals).

## How to use a ternary conditional operator `?:` in an interpolation expression

As the colon (":") has special meaning in an item with an interpolation expression, in order to use a [conditional operator](../language-reference/operators/conditional-operator.md) in an expression, enclose it in parentheses, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/StringInterpolation/Program.cs" id="ConditionalOperator":::

## How to create a culture-specific result string with string interpolation

By default, an interpolated string uses the current culture defined by the <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=nameWithType> property for all formatting operations.

Beginning with .NET 6, you can use the <xref:System.String.Create(System.IFormatProvider,System.Runtime.CompilerServices.DefaultInterpolatedStringHandler%40)?displayProperty=nameWithType> method to resolve an interpolated string to a culture-specific result string, as the following example shows:

:::code language="csharp" source="./snippets/StringInterpolation/Program.cs" id="CultureSensitive":::

In earlier versions of .NET, use implicit conversion of an interpolated string to a <xref:System.FormattableString?displayProperty=nameWithType> instance and call its <xref:System.FormattableString.ToString(System.IFormatProvider)> method to create a culture-specific result string. The following example shows how to do that:

:::code language="csharp" source="./snippets/StringInterpolation/Program.cs" id="CultureSensitiveOld":::

As the example shows, you can use one <xref:System.FormattableString> instance to generate multiple result strings for various cultures.

## How to create a result string using the invariant culture

Beginning with .NET 6, use the <xref:System.String.Create(System.IFormatProvider,System.Runtime.CompilerServices.DefaultInterpolatedStringHandler%40)?displayProperty=nameWithType> method to resolve an interpolated string to a result string for the <xref:System.Globalization.CultureInfo.InvariantCulture>, as the following example shows:

:::code language="csharp" source="./snippets/StringInterpolation/Program.cs" id="InvariantCulture":::

In earlier versions of .NET, along with the <xref:System.FormattableString.ToString(System.IFormatProvider)?displayProperty=nameWithType> method, you can use the static <xref:System.FormattableString.Invariant%2A?displayProperty=nameWithType> method, as the following example shows:

:::code language="csharp" source="./snippets/StringInterpolation/Program.cs" id="InvariantCultureOld":::

## Conclusion

This tutorial describes common scenarios of string interpolation usage. For more information about string interpolation, see [String interpolation](../language-reference/tokens/interpolated.md). For more information about formatting types in .NET, see the [Formatting types in .NET](../../standard/base-types/formatting-types.md) and [Composite formatting](../../standard/base-types/composite-formatting.md) articles.

## See also

- <xref:System.String.Format%2A?displayProperty=nameWithType>
- <xref:System.FormattableString?displayProperty=nameWithType>
- <xref:System.IFormattable?displayProperty=nameWithType>
- [Strings](../programming-guide/strings/index.md)
