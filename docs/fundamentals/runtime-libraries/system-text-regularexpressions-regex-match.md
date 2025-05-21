---
title: System.Text.RegularExpressions.Regex.Match method
description: Learn about the System.Text.RegularExpressions.Regex.Match method.
ms.date: 01/24/2024
ms.topic: article
---
# System.Text.RegularExpressions.Regex.Match method

[!INCLUDE [context](includes/context.md)]

The <xref:System.Text.RegularExpressions.Regex.Match(System.String,System.Int32)> method returns the first substring that matches a regular expression pattern, starting at or after the `startat` character position, in an input string. The regular expression pattern for which the <xref:System.Text.RegularExpressions.Regex.Match(System.String,System.Int32)> method searches is defined by the call to one of the <xref:System.Text.RegularExpressions.Regex> class constructors. For information about the language elements used to build a regular expression pattern, see [Regular Expression Language - Quick Reference](../../standard/base-types/regular-expression-language-quick-reference.md).

## The `startat` parameter

You can optionally specify a starting position in the string by using the `startat` parameter. Any matches starting before `startat` in the string are ignored. If you don't specify a starting position, the search begins at the default position, which is the left end of `input` in a left-to-right search, and the right end of `input` in a right-to-left search. Despite starting at `startat`, the index of any returned match is relative to the start of the string.

Although the regular expression engine doesn't return any match starting before `startat`, it doesn't ignore the string before `startat`. This means that assertions such as [anchors](../../standard/base-types/anchors-in-regular-expressions.md) or [lookbehind assertions](../../standard/base-types/backtracking-in-regular-expressions.md#lookbehind-assertions) still apply to the input as a whole. For example, the following code includes a pattern with a lookbehind assertion that's satisfied even though it occurs before the `startat` index of 5 in the input string.

:::code language="csharp" source="./snippets/System.Text.RegularExpressions/Regex/Match/csharp/startat.cs" interactive="try-dotnet":::

> [!TIP]
>
> - If a pattern starts with the `^` anchor but `startat` is greater than 0, no matches will ever be found in a single-line search since they are constrained by `^` to start at index 0.
> - The [`\G` anchor](../../standard/base-types/anchors-in-regular-expressions.md#contiguous-matches-g) is satisfied at `startat`. Because of this, if you want to restrict a match so that it begins exactly at a particular character position in the string, anchor the regular expression with a `\G` on the left for a left-to-right pattern. This restricts the match so it must start exactly at `startat` (or, when multiple matches are desired, so the matches are contiguous).

## Right-to-left searches

A right-to-left search, that is, when the regular expression pattern is constructed with the <xref:System.Text.RegularExpressions.RegexOptions.RightToLeft?displayProperty=nameWithType> option, behaves in the following ways:

- The scan moves in the opposite direction and the pattern is matched from back (right) to front (left).
- The default starting position is the right end of the input string.
- If `startat` is specified, the right-to-left scan begins at the character at `startat` - 1 (not `startat`).
- When the `\G` anchor is specified at the right end of a pattern, it restricts the (first) match to end exactly at `startat` - 1.

For more information about right-to-left searches, see [Right-to-left mode](../../standard/base-types/regular-expression-options.md#right-to-left-mode).

## Determine whether a match is found

You can determine whether the regular expression pattern has been found in the input string by checking the value of the returned <xref:System.Text.RegularExpressions.Match> object's <xref:System.Text.RegularExpressions.Group.Success> property. If a match is found, the returned <xref:System.Text.RegularExpressions.Match> object's <xref:System.Text.RegularExpressions.Capture.Value> property contains the substring from `input` that matches the regular expression pattern. If no match is found, its value is <xref:System.String.Empty?displayProperty=nameWithType>.

## First or multiple matches

This method returns the first substring found at or after the `startat` character position in `input` that matches the regular expression pattern. You can retrieve subsequent matches by repeatedly calling the returned <xref:System.Text.RegularExpressions.Match> object's <xref:System.Text.RegularExpressions.Match.NextMatch%2A?displayProperty=nameWithType> method. You can also retrieve all matches in a single method call by calling the <xref:System.Text.RegularExpressions.Regex.Matches(System.String,System.Int32)?displayProperty=nameWithType> method.

## Time-out exceptions

The <xref:System.Text.RegularExpressions.RegexMatchTimeoutException> exception is thrown if the execution time of the matching operation exceeds the time-out interval specified by the <xref:System.Text.RegularExpressions.Regex.%23ctor(System.String,System.Text.RegularExpressions.RegexOptions,System.TimeSpan)?displayProperty=nameWithType> constructor. If you do not set a time-out interval when you call the constructor, the exception is thrown if the operation exceeds any time-out value established for the application domain in which the <xref:System.Text.RegularExpressions.Regex> object is created. If no time-out is defined in the <xref:System.Text.RegularExpressions.Regex> constructor call or in the application domain's properties, or if the time-out value is <xref:System.Text.RegularExpressions.Regex.InfiniteMatchTimeout?displayProperty=nameWithType>, no exception is thrown.
