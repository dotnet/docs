---
title: ".NET 8 breaking change: Base64.DecodeFromUtf8 methods ignore whitespace"
description: Learn about the .NET 8 breaking change in core .NET libraries where the Base64.DecodeFromUtf8 and Base64.DecodeFromUtf8InPlace methods ignore whitespace in the input.
ms.date: 06/08/2023
---
# Base64.DecodeFromUtf8 methods ignore whitespace

The <xref:System.Convert.FromBase64String(System.String)?displayProperty=nameWithType>, <xref:System.Convert.FromBase64CharArray(System.Char[],System.Int32,System.Int32)?displayProperty=nameWithType>, and corresponding `Try` methods on <xref:System.Convert?displayProperty=fullName> ignore the ASCII whitespace characters ' ', '\t', '\r', and '\n' and allow any amount of such whitespace to be in the input. However, when the <xref:System.Buffers.Text.Base64.DecodeFromUtf8(System.ReadOnlySpan{System.Byte},System.Span{System.Byte},System.Int32@,System.Int32@,System.Boolean)?displayProperty=nameWithType> and <xref:System.Buffers.Text.Base64.DecodeFromUtf8InPlace(System.Span{System.Byte},System.Int32@)?displayProperty=nameWithType> methods were added, they didn't ignore these whitespace characters and instead failed to decode any input that included whitespace. This makes the behavior when using the UTF16-based APIs different from that of the UTF8-based APIs. It also meant that:

- The `Base64.DecodeFromUtf8` and `Base64.DecodeFromUtf8InPlace` methods couldn't roundtrip the UTF-encoded base-64 encoded data produced by <xref:System.Convert.FromBase64String(System.String)?displayProperty=nameWithType> with the <xref:System.Base64FormattingOptions.InsertLineBreaks?displayProperty=nameWithType> option.
- The new <xref:System.Buffers.Text.Base64.IsValid(ReadOnlySpan{System.Char})> and <xref:System.Buffers.Text.Base64.IsValid(ReadOnlySpan{System.Byte})> methods would either need to have behavior inconsistent with each other or with their corresponding methods for UTF-16 and UTF-8 data on `Convert` and `Base64`.

With this change, the <xref:System.Buffers.Text.Base64.DecodeFromUtf8(System.ReadOnlySpan{System.Byte},System.Span{System.Byte},System.Int32@,System.Int32@,System.Boolean)> and <xref:System.Buffers.Text.Base64.DecodeFromUtf8InPlace(System.Span{System.Byte},System.Int32@)> methods now ignore whitespace in the input.

## Previous behavior

<xref:System.Buffers.Text.Base64.DecodeFromUtf8(System.ReadOnlySpan{System.Byte},System.Span{System.Byte},System.Int32@,System.Int32@,System.Boolean)?displayProperty=nameWithType> and <xref:System.Buffers.Text.Base64.DecodeFromUtf8InPlace(System.Span{System.Byte},System.Int32@)?displayProperty=nameWithType> failed to process input that contained whitespace and returned <xref:System.Buffers.OperationStatus.InvalidData?displayProperty=nameWithType> if any whitespace was encountered.

## New behavior

<xref:System.Buffers.Text.Base64.DecodeFromUtf8(System.ReadOnlySpan{System.Byte},System.Span{System.Byte},System.Int32@,System.Int32@,System.Boolean)?displayProperty=nameWithType> and <xref:System.Buffers.Text.Base64.DecodeFromUtf8InPlace(System.Span{System.Byte},System.Int32@)?displayProperty=nameWithType> now ignore whitespace (specifically ' ', '\t', '\r', and '\n') in the input, which matches the behavior of <xref:System.Convert.FromBase64String(System.String)?displayProperty=nameWithType>.

## Version introduced

.NET 8 Preview 5

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The change was made so that:

- The <xref:System.Buffers.Text.Base64> methods can decode a wider range of input data, including:
  - Data produced by <xref:System.Convert.ToBase64String%2A?displayProperty=nameWithType> with the <xref:System.Base64FormattingOptions.InsertLineBreaks?displayProperty=nameWithType> option.
  - Common formatting of data in configuration files and other real data sources.
- The <xref:System.Buffers.Text.Base64> methods are consistent with the corresponding decoding APIs on <xref:System.Convert>.
- The new <xref:System.Buffers.Text.Base64.IsValid(ReadOnlySpan{System.Char})?displayProperty=nameWithType> and <xref:System.Buffers.Text.Base64.IsValid(ReadOnlySpan{System.Byte})?displayProperty=nameWithType> APIs could be added in a manner where their behavior is consistent with each other and with the existing <xref:System.Convert> and <xref:System.Buffers.Text.Base64> APIs.

## Recommended action

If the new behavior is problematic for your code, you can call `IndexOfAny(" \t\r\n"u8)` to search the input for the whitespace that previously would have triggered an <xref:System.Buffers.OperationStatus.InvalidData> result.

## Affected APIs

- <xref:System.Buffers.Text.Base64.DecodeFromUtf8(System.ReadOnlySpan{System.Byte},System.Span{System.Byte},System.Int32@,System.Int32@,System.Boolean)?displayProperty=fullName>
- <xref:System.Buffers.Text.Base64.DecodeFromUtf8InPlace(System.Span{System.Byte},System.Int32@)?displayProperty=fullName>
