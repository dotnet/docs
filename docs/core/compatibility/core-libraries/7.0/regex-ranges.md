---
title: ".NET 7 breaking change: Regex patterns with ranges corrected"
description: Learn about the .NET 7 breaking change in core .NET libraries where regular expressions that have ranges in the pattern and are used with the RegexOptions.IgnoreCase option might break.
ms.date: 12/08/2023
---
# Regex patterns with ranges corrected

Regex [incorrectly handles the casing of some ranges](https://github.com/dotnet/runtime/issues/36149) in .NET Framework, and in .NET 6 and earlier versions. This bug was fixed in .NET 7.

The fix for this bug could cause a breaking change if your regular expression has a bug that was hidden because of this bug or if you implemented a workaround for this bug.

## Previous behavior

In .NET 6 and earlier versions, the following two patterns produce different results. However, they should produce the same result (`false`), since the range `\xD7-\xD8` only includes the values `\xD7` and `\xD8` themselves.

```csharp
// Evaluates to false.
Regex.IsMatch("\xF7", @"^(?i:[\xD7\xD8])$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
// Evaluates to true.
Regex.IsMatch("\xF7", @"^(?i:[\xD7-\xD8])$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
```

## New behavior

Starting in .NET 7, the example patterns both evaluate to `false`.

```csharp
// Evaluates to false.
Regex.IsMatch("\xF7", @"^(?i:[\xD7\xD8])$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
// Evaluates to false.
Regex.IsMatch("\xF7", @"^(?i:[\xD7-\xD8])$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
```

## Version introduced

.NET 7

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous behavior was incorrect.

## Recommended action

If your regular expression has a hidden bug, fix it. If you had a workaround for this bug, you can remove the workaround.

## Affected APIs

- <xref:System.Text.RegularExpressions.Regex.Count%2A?displayProperty=fullName>
- <xref:System.Text.RegularExpressions.Regex.EnumerateMatches%2A?displayProperty=fullName>
- <xref:System.Text.RegularExpressions.Regex.IsMatch%2A?displayProperty=fullName>
- <xref:System.Text.RegularExpressions.Regex.Match%2A?displayProperty=fullName>
- <xref:System.Text.RegularExpressions.Regex.Matches%2A?displayProperty=fullName>
- <xref:System.Text.RegularExpressions.Regex.Replace%2A?displayProperty=fullName>
- <xref:System.Text.RegularExpressions.Regex.Split%2A?displayProperty=fullName>
