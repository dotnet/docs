---
title: Learn string interpolation
description: Build a small report in C# with string interpolation to format and align expression results in a result string.
author: pkulikov
ms.subservice: fundamentals
ms.date: 06/24/2026
ms.topic: tutorial
ai-usage: ai-assisted
---
# Tutorial: Use string interpolation to build a report in C\#

In this tutorial, you build a small [file-based app](../../../core/sdk/file-based-apps.md) that prints a formatted order summary. Along the way, you apply [string interpolation](../strings/interpolation.md) to insert values into text, format numbers and currency, line up columns, and produce culture-specific output.

This tutorial assumes that you're familiar with basic C# concepts. For a feature-by-feature reference of interpolation syntax, see [String interpolation](../strings/interpolation.md).

## Prerequisites

- The [.NET 10 SDK](https://dotnet.microsoft.com/download) or a later version. File-based apps require .NET 10 or later.
- A code editor, such as [Visual Studio Code](https://code.visualstudio.com/).

## Create the app

A file-based app is a single `.cs` file that you run without a project file. Create a folder for the app and move into it:

```dotnetcli
mkdir StringInterpolation
cd StringInterpolation
```

Create an empty file named *report.cs* in that folder and open it in your editor. You add code to it in the sections that follow, and you run the app at any point with `dotnet run report.cs`.

## Insert values into text

Prefix a string literal with `$` to make it an *interpolated string*. Inside the string, put any C# expression in braces (`{` and `}`); C# evaluates the expression, converts the result to a string, and inserts it.

Add the following code to *report.cs*, then run the app with `dotnet run report.cs`:

:::code language="csharp" source="snippets/string-interpolation/Program.cs" id="Greeting":::

The result combines the literal text with the values of `name` and `itemCount`.

## Format numbers and currency

An order summary shows money and rates, so raw numbers like `23.5` or `0.08` look unfinished and hard to read. Present each value the way a customer expects: a price with a currency symbol and a tax rate as a percentage. Format it as part of the interpolation.

To format a value, follow the expression with a colon (`:`) and a [format string](../../../standard/base-types/composite-formatting.md#format-string-component). The standard format strings `C` and `P0` produce currency and whole-number percentages. Add the following code to the end of the file:

:::code language="csharp" source="snippets/string-interpolation/Program.cs" id="Format":::

The format string applies the conventions of the current culture, so the currency symbol and separators match the machine's settings.

## Align values into columns

When you print several rows of data, values of different lengths leave the columns ragged and hard to scan. To line up each name and number under a consistent heading, give every field a fixed width so the columns stay straight no matter how long each value is.

To set a minimum field width, follow the expression with a comma (`,`) and the width. A positive width right-aligns the value; a negative width left-aligns it. Combine width and a format string as `{expression,width:format}`. Add the following code to print a tabular summary:

:::code language="csharp" source="snippets/string-interpolation/Program.cs" id="Align":::

The left-aligned name column and right-aligned numeric columns line up into a readable table.

## Produce culture-specific output

An interpolated string uses the [current culture](../../../standard/base-types/formatting-types.md) by default. When you need a specific culture, such as a fixed format for logs or a locale for a receipt, pass a culture to <xref:System.String.Create(System.IFormatProvider,System.Runtime.CompilerServices.DefaultInterpolatedStringHandler%40)?displayProperty=nameWithType>. Add the following code:

:::code language="csharp" source="snippets/string-interpolation/Program.cs" id="Culture":::

The German receipt uses a comma as the decimal separator and the euro symbol. The invariant log uses a period and no symbol, regardless of the machine's culture.

## Next steps

You used string interpolation to insert, format, align, and localize values. For the full set of interpolation features, including raw string literals, escaped braces, and constant interpolated strings, see the concept article:

> [!div class="nextstepaction"]
> [String interpolation in C#](../strings/interpolation.md)

## See also

- [String interpolation in C#](../strings/interpolation.md)
- [Composite formatting](../../../standard/base-types/composite-formatting.md)
- [Formatting types in .NET](../../../standard/base-types/formatting-types.md)
- <xref:System.String.Format*?displayProperty=nameWithType>
