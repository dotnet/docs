---
title: "Breaking change: Ambiguous overload resolution affecting StringValues implicit operators"
description: Learn about the .NET 9 breaking change in core .NET libraries where ambiguous overload resolution now throws error CS0121.
ms.date: 02/24/2025
ai-usage: ai-assisted
---

# Ambiguous overload resolution affecting StringValues implicit operators

In .NET 9, a breaking change in the [`params Span<T>` lang feature](../../../whats-new/dotnet-9/libraries.md#params-readonlyspant-overloads) creates ambiguity with the implicit operators of <xref:Microsoft.Extensions.Primitives.StringValues>. This change results in the compiler throwing error `CS0121` when it encounters ambiguous method calls.

## Previous behavior

The APIs mentioned in the [Affected APIs](#affected-apis) section previously had no overloads ambiguous with the implicit operators of <xref:Microsoft.Extensions.Primitives.StringValues>. As a result, the compiler would resolve the overloads without any issues.

## New behavior

The compiler throws error `CS0121` for ambiguous overloads. The same code will now result in the following error:

```output
CS0121: The call is ambiguous between the following methods or properties: 'Program.Join(string, params string[])' and 'Program.Join(string, params ReadOnlySpan<string>)'
```

## Version introduced

.NET 9

## Type of breaking change

This change is a [source compatibility](../../categories.md#source-compatibility) change.

## Reason for change

<xref:Microsoft.Extensions.Primitives.StringValues> has implicit operators for `string` and `string[]` that cause conflicts with the [`params Span<T>` lang feature](../../../whats-new/dotnet-9/libraries.md#params-readonlyspant-overloads).

## Recommended action

Explicitly specify the method you intend to call by casting the arguments to the appropriate type or apply named parameters.

## Affected APIs

- <xref:System.String.Concat(System.ReadOnlySpan{System.String})?displayProperty=fullName>
- <xref:System.String.Join(System.Char,System.ReadOnlySpan{System.String})?displayProperty=fullName>
- <xref:System.String.Join(System.String,System.ReadOnlySpan{System.String})?displayProperty=fullName>
- <xref:System.IO.Path.Combine(System.ReadOnlySpan{System.String})?displayProperty=fullName>
- <xref:System.IO.Path.Join(System.ReadOnlySpan{System.String})?displayProperty=fullName>
- <xref:System.Text.StringBuilder.AppendJoin(System.String,System.ReadOnlySpan{System.String})?displayProperty=fullName>
- <xref:System.Text.StringBuilder.AppendJoin(System.Char,System.ReadOnlySpan{System.Object})?displayProperty=fullName>
