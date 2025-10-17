---
title: "Breaking change - BufferedStream.WriteByte no longer performs implicit flush"
description: "Learn about the breaking change in .NET 10 where BufferedStream.WriteByte no longer performs an implicit flush when the internal buffer is full."
ms.date: 10/13/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/496356
dev_langs:
  - "csharp"
  - "vb"
---

# BufferedStream.WriteByte no longer performs implicit flush

The <xref:System.IO.BufferedStream.WriteByte(System.Byte)?displayProperty=nameWithType> method no longer performs an implicit flush when the internal buffer is full. This change aligns the behavior of `BufferedStream.WriteByte` with other `Write` methods in the <xref:System.IO.BufferedStream> class, such as <xref:System.IO.BufferedStream.Write(System.Byte[],System.Int32,System.Int32)?displayProperty=nameWithType> and <xref:System.IO.BufferedStream.WriteAsync(System.Byte[],System.Int32,System.Int32,System.Threading.CancellationToken)?displayProperty=nameWithType>, which don't perform an implicit flush.

## Version introduced

.NET 10 Preview 4

## Previous behavior

Previously, when the internal buffer of a `BufferedStream` was full, calling `WriteByte` automatically flushed the buffer to the underlying stream. This behavior was inconsistent with other `Write` methods in `BufferedStream`.

The following example demonstrates the previous behavior:

:::code language="csharp" source="./snippets/bufferedstream-writebyte-flush/csharp/Program.cs" id="PreviousBehavior":::
:::code language="vb" source="./snippets/bufferedstream-writebyte-flush/vb/Program.vb" id="PreviousBehavior":::

## New behavior

Starting in .NET 10, the `WriteByte` method no longer performs an implicit flush when the internal buffer is full. The buffer is only flushed when the <xref:System.IO.BufferedStream.Flush?displayProperty=nameWithType> method is explicitly called or when the `BufferedStream` is disposed.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The implicit flush behavior of <xref:System.IO.BufferedStream.WriteByte(System.Byte)?displayProperty=nameWithType> was inconsistent with other `Write` methods in the `BufferedStream` class, such as `Write` and `WriteAsync`. This inconsistency could lead to unexpected performance issues or unintended side effects when working with streams that are sensitive to flush operations. Removing the implicit flush ensures consistent behavior across all `Write` methods in `BufferedStream`.

## Recommended action

If your application relies on the implicit flush behavior of `BufferedStream.WriteByte`, update your code to explicitly call the `Flush` method when needed. For example:

**Before:**

:::code language="csharp" source="./snippets/bufferedstream-writebyte-flush/csharp/Program.cs" id="Before":::
:::code language="vb" source="./snippets/bufferedstream-writebyte-flush/vb/Program.vb" id="Before":::

**After:**

:::code language="csharp" source="./snippets/bufferedstream-writebyte-flush/csharp/Program.cs" id="After":::
:::code language="vb" source="./snippets/bufferedstream-writebyte-flush/vb/Program.vb" id="After":::

## Affected APIs

- <xref:System.IO.BufferedStream.WriteByte(System.Byte)?displayProperty=fullName>
