---
title: "Breaking change: New StringBuilder.Append overloads"
description: Learn about the .NET 6 breaking change where new overloads were added to StringBuilder.Append and StringBuilder.AppendLine that may result in different run-time behavior.
ms.date: 10/14/2021
---
# StringBuilder.Append overloads and evaluation order

C# 10 adds support for [better string interpolation](https://devblogs.microsoft.com/dotnet/string-interpolation-in-c-10-and-net-6/), including the ability to target custom "handlers" in addition to strings. <xref:System.Text.StringBuilder> takes advantage of this with new overloads of <xref:System.Text.StringBuilder.Append%2A> and <xref:System.Text.StringBuilder.AppendLine%2A> that accept a custom interpolated string handler. Existing calls to these methods may now start binding to the new overloads. In general, behavior is identical but with improved performance. For example, rather than a string first being created and then that string appended, the individual components of the interpolated string are appended directly to the builder. However, this can change the evaluation order of objects used as format items, which can manifest as a difference in behavior.

## Previous behavior

In previous versions, a call to:

```csharp
stringBuilder.Append($"{a} {b}");
```

compiled to the equivalent of:

```csharp
stringBuilder.Append(string.Format("{0} {1}", a, b));
```

This means `a` is evaluated, then `b` is evaluated, then a string is created from the results of those evaluations, and then that string is appended to the builder.

## New behavior

Starting in .NET 6, a call to:

```csharp
stringBuilder.Append($"{a} {b}");
```

compiles to the equivalent of:

```csharp
var handler = new StringBuilder.AppendInterpolatedStringHandler(1, 2, stringBuilder);
handler.AppendFormatted(a);
handler.AppendLiteral(" ");
handler.AppendFormatted(b);
stringBuilder.Append(ref handler);
```

This means `a` is evaluated and appended to the builder, and then `b` is evaluated and appended to the builder.

If, for example, either `a` or `b` is itself the builder, as shown in the following code, the new evaluation order can result in different behavior at run time.

```csharp
stringBuilder.Append($"{a} {stringBuilder}");
```

## Version introduced

6.0 RC 1

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

It's common for developers to pass interpolated strings to <xref:System.Text.StringBuilder>, as it's more convenient than manually splitting the string up and calling <xref:System.Text.StringBuilder.Append%2A?displayProperty=nameWithType> for each part. These new overloads enable the concise syntax and most of the performance of doing the individual calls.

## Recommended action

In most cases where <xref:System.Text.StringBuilder.Append%2A?displayProperty=nameWithType> and <xref:System.Text.StringBuilder.AppendLine%2A?displayProperty=nameWithType> are used, you won't notice a functional difference. If you find a difference that proves to be problematic, you can restore the previous behavior by adding a cast to `(string)` prior to the interpolated string. For example:

```csharp
stringBuilder.Append((string)$"{a} {b}")
```

This is not recommended, however, unless it's actually required for compatibility.

## Affected APIs

- <xref:System.Text.StringBuilder.Append%2A?displayProperty=fullName>
- <xref:System.Text.StringBuilder.AppendLine%2A?displayProperty=fullName>

## See also

- [String Interpolation in C# 10 and .NET 6](https://devblogs.microsoft.com/dotnet/string-interpolation-in-c-10-and-net-6/)
