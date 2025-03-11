---
title: "Divide strings using String.Split"
description: The Split method returns an array of strings split from a set of delimiters. It's an easy way to extract substrings from a string.
ms.date: 02/18/2025
helpviewer_keywords:
  - "splitting strings [C#]"
  - "Split method [C#]"
  - "strings [C#], splitting"
  - "parse strings"
ms.custom: copilot-scenario-highlight
ms.collection: ce-skilling-ai-copilot
---
# How to separate strings using String.Split in C\#

The <xref:System.String.Split%2A?displayProperty=nameWithType> method creates an array of substrings by splitting the input string based on one or more delimiters. This method is often the easiest way to separate a string on word boundaries.

[!INCLUDE[interactive-note](~/includes/csharp-interactive-note.md)]

> [!TIP]
> You can use AI assistance to [split a string with GitHub Copilot](#use-github-copilot-to-split-a-string).

## Split a string into words

The following code splits a common phrase into an array of strings for each word.

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/ParseStringsUsingSplit.cs" id="Snippet1":::

Every instance of a separator character produces a value in the returned array. Since arrays in C# are zero-indexed, each string in the array is indexed from 0 to the value returned by the <xref:System.Array.Length%2A?displayProperty=nameWithType> property minus 1:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/ParseStringsUsingSplit.cs" id="Snippet1.5":::

The <xref:System.String.Split*?displayProperty=nameWithType> has many overloads. These overloads customize the behavior for splitting strings:

- You can specify separators as `char` values or `string` values.
- You can specify one separator or multiple separators. If you specify multiple separators, they must all be the same type (either `char` or `string`).
- You can specify the maximum number of substrings to return.
- You can specify if repeated separator characters are ignored, or produce empty substrings in the return value.
- You can specify if leading and trailing whitespace is removed from the returned substrings.

The remaining examples use different overloads to show each of these behaviors.

## Specify multiple separators

<xref:System.String.Split%2A?displayProperty=nameWithType> can use multiple separator characters. The following example uses spaces, commas, periods, colons, and tabs as separating characters, which are passed to <xref:System.String.Split%2A> in an array. The loop at the bottom of the code displays each of the words in the returned array.

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/ParseStringsUsingSplit.cs" id="Snippet3":::

Consecutive instances of any separator produce the empty string in the output array:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/ParseStringsUsingSplit.cs" id="Snippet4":::

<xref:System.String.Split%2A?displayProperty=nameWithType> can take an array of strings (character sequences that act as separators for parsing the target string, instead of single characters).

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/ParseStringsUsingSplit.cs" id="Snippet5":::

## Limit output size

The following example shows how to limit the output to the first four substrings in the source string.

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/ParseStringsUsingSplit.cs" id="Snippet6":::

## Remove empty substrings

Consecutive separator characters produce the empty string as a value in the returned array. You can see how an empty string is created in the following example, which uses the space character as a separator.

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/ParseStringsUsingSplit.cs" id="Snippet2":::

This behavior makes it easier for formats like comma-separated values (CSV) files representing tabular data. Consecutive commas represent a blank column.

You can pass an optional <xref:System.StringSplitOptions.RemoveEmptyEntries?displayProperty=nameWithType> parameter to exclude any empty strings in the returned array. For more complicated processing of the returned collection, you can use [LINQ](/dotnet/csharp/linq/) to manipulate the result sequence.

## Trim whitespace

The following example shows the effect of trimming entries:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/ParseStringsUsingSplit.cs" id="Snippet7":::

The untrimmed entries have extra whitespace before the numerals.

## Use GitHub Copilot to split a string

You can use GitHub Copilot in your IDE to generate code to split strings using `String.Split` in C#. You can customize the prompt to use strings and delimiters per your requirements.

The following text shows an example prompt for Copilot Chat:

```copilot-prompt
Generate C# code to use Split.String to split a string into substrings.
Input string is "You win some. You lose some." Delimiters are space and period.
Provide example output.
```

GitHub Copilot is powered by AI, so surprises and mistakes are possible. For more information, see [Copilot FAQs](https://aka.ms/copilot-general-use-faqs).

Learn more about [GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states) and [GitHub Copilot in VS Code](https://code.visualstudio.com/docs/copilot/overview).

## See also

- [Extract elements from a string](../../standard/base-types/divide-up-strings.md)
- [Strings](../programming-guide/strings/index.md)
- [.NET regular expressions](../../standard/base-types/regular-expressions.md)
