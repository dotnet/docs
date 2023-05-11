---
title: ".NET 7 breaking change: BrotliStream no longer allows undefined CompressionLevel values"
description: Learn about the .NET 7 breaking change in core .NET libraries where the BrotliStream constructors no longer allow undefined CompressionLevel values.
ms.date: 11/18/2022
---
# BrotliStream no longer allows undefined CompressionLevel values

The <xref:System.IO.Compression.BrotliStream> constructors that take a <xref:System.IO.Compression.CompressionLevel> argument no longer allow values that aren't defined in the <xref:System.IO.Compression.CompressionLevel> enumeration. If you pass an invalid value, an <xref:System.ArgumentException> is thrown.

## Previous behavior

<xref:System.IO.Compression.BrotliStream> allowed you to pass an arbitrary compression level to the constructor by casting the desired level directly to <xref:System.IO.Compression.CompressionLevel>. For example:

```csharp
BrotliStream brotli = new BrotliStream(baseStream,
                                       (CompressionLevel)5); // Use level 5
```

However, if an arbitrary level was provided, that was passed through as-is to the underlying library, resulting in inconsistent and potentially unexpected behavior.

## New behavior

<xref:System.IO.Compression.BrotliStream> only allows the values defined in <xref:System.IO.Compression.CompressionLevel>. If you pass an undefined value to the constructor, an <xref:System.ArgumentException> is thrown.

## Version introduced

.NET 7

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The purpose of the <xref:System.IO.Compression.CompressionLevel> enumeration is to let developers use compression algorithms without needing to understand the meaning of their tuning parameters.

If an arbitrary level was provided, that was passed through as-is to the underlying library, resulting in inconsistent and potentially unexpected behavior. With this change, the behavior is aligned with other compression streams, for example, <xref:System.IO.Compression.DeflateStream>.

With the new tuning of the <xref:System.IO.Compression.CompressionLevel> values and the addition of <xref:System.IO.Compression.CompressionLevel.SmallestSize?displayProperty=nameWithType>, it's now possible to have a variety of trade-offs in the compression algorithms. Users can continue to rely on <xref:System.IO.Compression.CompressionLevel> values as being abstractions of such trade-offs.

## Recommended action

If you were relying on passing undefined values as the <xref:System.IO.Compression.CompressionLevel>, revisit your use case and decide which documented value is the most optimal for it.

## Affected APIs

- <xref:System.IO.Compression.BrotliStream.%23ctor(System.IO.Stream,System.IO.Compression.CompressionLevel,System.Boolean)>
- <xref:System.IO.Compression.BrotliStream.%23ctor(System.IO.Stream,System.IO.Compression.CompressionLevel)>
