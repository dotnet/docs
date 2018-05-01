---
title: String interpolation in C#
description: Learn how to perform common string formatting tasks in C# using the string interpolation feature
keywords: .NET, .NET Core, C#, string
author: "pkulikov"
ms.author: wiwagn
ms.date: 04/28/2018
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
---
# String interpolation in C# #

The [string interpolation](../language-reference/tokens/interpolated.md) feature is built on top of the [composite formatting](../../standard/base-types/composite-formatting.md) feature and provides a more readable and convenient syntax to format string output.

To identify a string literal as an interpolated string, prepend it with the `$` symbol. You can embed any valid C# expression that returns a value into an interpolated string:

[!code-csharp-interactive[string interpolation example](TODO#1)]

As the example above shows, you embed an expression into an interpolated string by surrounding it with braces:

```
{<interpolatedExpression>}
```

At compile time an interpolated string is transformed to the <xref:System.String.Format%2A?displayProperty=nameWithType> call or to the expression that produces a <xref:System.FormattableString?displayProperty=nameWithType> instance. That makes all the capabilities of the [string composite formatting](../../standard/base-types/composite-formatting.md) feature available to you to use with interpolated strings as well.

## How to specify a format string for interpolated expressions

You specify a format string that is supported by the type of the expression result by following the interpolated expression with a colon (":") and the format string:

```
{<interpolatedExpression>:<formatString>}
```

The following example shows how to specify standard and custom format strings for expressions that produce date and time or numeric results:

[!code-csharp-interactive[format string example](TODO#2)]

For more information, see the [Format String Component](../../standard/base-types/composite-formatting.md#format-string-component) section of the [Composite Formatting](../../standard/base-types/composite-formatting.md) topic. That section provides links to the topics that describe standard and custom format strings supported by .NET base types.

## How to control field width and alignment

You specify the minimum field width in which string representation of the expression result is inserted and the alignment within that field by following the interpolated expression with a comma (",") and the constant expression that defines alignment:

```
{<interpolatedExpression>,<alignment>}
```

If the alignment value is positive, the formatted string representation of the expression result is right-aligned; if negative, it's left-aligned.

When you need to specify both alignment and a format string, start with the alignment component:

```
{<interpolatedExpression>,<alignment>:<formatString>}
```

The following example shows how to specify alignment:

[!code-csharp-interactive[alignment example](TODO#2)]

For more information, see the [Alignment Component](../../standard/base-types/composite-formatting.md#alignment-component) section of the [Composite Formatting](../../standard/base-types/composite-formatting.md) topic.

## How to include special symbols into an interpolated string

Link to the string section on escaping.
Special case for braces.
Verbatim strings.

## How to use a conditional operator within an interpolated expression

Copy from the feature description and example.

## How to specify culture information of an interpolated string

Start with FormattableString. Then, mention IFormattable as well.

## How to use invariant culture for an interpolated string

FormattableString.Invariant(...);

## See also

[String interpolation](../language-reference/tokens/interpolated.md)  
[Composite formatting](../../standard/base-types/composite-formatting.md)  
[Formatting Types in .NET](../../standard/base-types/formatting-types.md)  
<xref:System.String.Format%2A?displayProperty=nameWithType>  
<xref:System.FormattableString?displayProperty=nameWithType>  
<xref:System.IFormattable?displayProperty=nameWithType>  
[Strings](../programming-guide/strings/index.md)  
