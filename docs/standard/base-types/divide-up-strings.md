---
title: Separate strings into substrings
description: Learn about different techniques to extract parts of a string, including String.Split, regular expressions, String.Substring, and the range operator.
ms.date: 03/20/2026
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "strings [.NET], breaking up"
ai-usage: ai-assisted
---
# Extract substrings from a string

This article covers some different techniques for extracting parts of a string.

- Use the [Split method](#stringsplit-method) when the substrings you want are separated by a known delimiting character (or characters).
- [Regular expressions](#regular-expressions) are useful when the string conforms to a fixed pattern.
- Use the [IndexOf and Substring methods](#stringindexof-and-stringsubstring-methods) in conjunction when you don't want to extract *all* of the substrings in a string.
- Use [ranges and indices](#ranges-and-indices) in C# to extract or trim characters at known positions.

## String.Split method

<xref:System.String.Split*?displayProperty=nameWithType> provides a handful of overloads to help you break up a string into a group of substrings based on one or more delimiting characters that you specify. You can choose to limit the total number of substrings in the final result, trim white-space characters from substrings, or exclude empty substrings.

The following examples show three different overloads of `String.Split()`. The first example calls the <xref:System.String.Split(System.Char[])> overload without passing any separator characters. When you don't specify any delimiting characters, `String.Split()` uses default delimiters, which are white-space characters, to split up the string.

[!code-csharp[Intro#1](snippets/parse-strings/csharp/intro.cs#1)]
:::code language="vb" source="snippets/parse-strings/vb/intro.vb" id="1":::

As you can see, the period characters (`.`) are included in two of the substrings. If you want to exclude the period characters, you can add the period character as an additional delimiting character. The next example shows how to do this.

[!code-csharp[Intro#1](snippets/parse-strings/csharp/intro.cs#2)]
:::code language="vb" source="snippets/parse-strings/vb/intro.vb" id="2":::

The periods are gone from the substrings, but now two extra empty substrings have been included. These empty substring represent the substring between the word and the period that follows it. To omit empty substrings from the resulting array, you can call the
<xref:System.String.Split(System.Char[],System.StringSplitOptions)> overload and specify
<xref:System.StringSplitOptions.RemoveEmptyEntries?displayProperty=nameWithType> for the `options` parameter.

[!code-csharp[Intro#1](snippets/parse-strings/csharp/intro.cs#3)]
:::code language="vb" source="snippets/parse-strings/vb/intro.vb" id="3":::

## Regular expressions

If your string conforms to a fixed pattern, you can use a regular expression to extract and handle its elements. For example, if strings take the form "*number* *operand* *number*", you can use a [regular expression](regular-expressions.md) to extract and handle the string's elements. Here's an example:

:::code language="csharp" source="snippets/parse-strings/csharp/regex.cs" id="1":::
:::code language="vb" source="snippets/parse-strings/vb/regex.vb" id="1":::

The regular expression pattern `(\d+)\s+([-+*/])\s+(\d+)` is defined like this:

|Pattern|Description|
|-------------|-----------------|
|`(\d+)`|Match one or more decimal digits. This is the first capturing group.|
|`\s+`|Match one or more white-space characters.|
|`([-+*/])`|Match an arithmetic operator sign (+, -, *, or /). This is the second capturing group.|
|`\s+`|Match one or more white-space characters.|
|`(\d+)`|Match one or more decimal digits. This is the third capturing group.|

You can also use a regular expression to extract substrings from a string based on a pattern rather than a fixed set of characters. This is a common scenario when either of these conditions occurs:

- One or more of the delimiter characters does not *always* serve as a delimiter in the <xref:System.String> instance.

- The sequence and number of delimiter characters is variable or unknown.

For example, the <xref:System.String.Split*> method cannot be used to split the following string, because the number of `\n` (newline) characters is variable, and they don't always serve as delimiters.

```text
[This is captured\ntext.]\n\n[\n[This is more captured text.]\n]
\n[Some more captured text:\n   Option1\n   Option2][Terse text.]
```

A regular expression can split this string easily, as the following example shows.

:::code language="csharp" source="snippets/parse-strings/csharp/regex.cs" id="2":::
:::code language="vb" source="snippets/parse-strings/vb/regex.vb" id="2":::

The regular expression pattern `\[([^\[\]]+)\]` is defined like this:

|Pattern|Description|
|-------------|-----------------|
|`\[`|Match an opening bracket.|
|`([^\[\]]+)`|Match any character that is not an opening or a closing bracket one or more times. This is the first capturing group.|
|`\]`|Match a closing bracket.|

The <xref:System.Text.RegularExpressions.Regex.Split*?displayProperty=nameWithType> method is almost identical to <xref:System.String.Split*?displayProperty=nameWithType>, except that it splits a string based on a regular expression pattern instead of a fixed character set. For example, the following example uses the <xref:System.Text.RegularExpressions.Regex.Split*?displayProperty=nameWithType> method to split a string that contains substrings delimited by various combinations of hyphens and other characters.

:::code language="csharp" source="snippets/parse-strings/csharp/regex.cs" id="3":::
:::code language="vb" source="snippets/parse-strings/vb/regex.vb" id="3":::

The regular expression pattern `\s-\s?[+*]?\s?-\s` is defined like this:

|Pattern|Description|
|-------------|-----------------|
|`\s-`|Match a white-space character followed by a hyphen.|
|`\s?`|Match zero or one white-space character.|
|`[+*]?`|Match zero or one occurrence of either the + or * character.|
|`\s?`|Match zero or one white-space character.|
|`-\s`|Match a hyphen followed by a white-space character.|

## String.IndexOf and String.Substring methods

If you aren't interested in all of the substrings in a string, you might prefer to work with one of the string comparison methods that returns the index at which the match begins. You can then call the <xref:System.String.Substring*> method to extract the substring that you want. The string comparison methods include:

- <xref:System.String.IndexOf*>, which returns the zero-based index of the first occurrence of a character or string in a string instance.

- <xref:System.String.IndexOfAny*>, which returns the zero-based index in the current string instance of the first occurrence of any character in a character array.

- <xref:System.String.LastIndexOf*>, which returns the zero-based index of the last occurrence of a character or string in a string instance.

- <xref:System.String.LastIndexOfAny*>, which returns a zero-based index in the current string instance of the last occurrence of any character in a character array.

The following example uses the <xref:System.String.IndexOf*> method to find the periods in a string. It then uses the <xref:System.String.Substring*> method to return full sentences.

:::code language="csharp" source="snippets/parse-strings/csharp/indexof.cs" id="1":::
:::code language="vb" source="snippets/parse-strings/vb/indexof.vb" id="1":::

## Ranges and indices

The C# [range operator `..`](../../csharp/language-reference/operators/member-access-operators.md#range-operator-) and the [index-from-end operator `^`](../../csharp/language-reference/operators/member-access-operators.md#index-from-end-operator-) let you extract substrings using a concise syntax. You can apply these operators directly to strings without calling <xref:System.String.Substring*>.

The following example shows several ways to extract parts of a string using ranges:

:::code language="csharp" source="snippets/parse-strings/csharp/range.cs" id="snippet1":::

The next example uses the index-from-end operator to remove a file extension (the last three characters) from a path:

:::code language="csharp" source="snippets/parse-strings/csharp/range.cs" id="snippet2":::

> [!NOTE]
> Ranges and the index-from-end operator are C# features. Visual Basic doesn't support this syntax; use <xref:System.String.Substring*> instead.

## See also

- [.NET regular expressions](regular-expressions.md)
- [How to parse strings using String.Split in C#](../../csharp/how-to/parse-strings-using-split.md)
- [Indices and ranges (C# guide)](../../csharp/tutorials/ranges-indexes.md)
