---
title: ".NET 7 breaking change: Validate CompressionLevel for BrotliStream"
description: Learn about the .NET 7 breaking change in core .NET libraries where the CompressionLevel parameter to BrotliStream constructors is now validated.
ms.date: 01/04/2022
---
# Validate CompressionLevel for BrotliStream

The <xref:System.IO.Compression.CompressionLevel> argument that's passed to <xref:System.IO.Compression.BrotliStream> constructors is now validated to be one of the defined values of the enumeration.

## Previous behavior

Passing any value between 0 and 11 for the <xref:System.IO.Compression.CompressionLevel> parameter was considered valid. The value would either map to the one of the enumeration's defined values or passed as-is to the underlying Brotli implementation.

## New behavior

The only valid values for the <xref:System.IO.Compression.CompressionLevel> parameter of <xref:System.IO.Compression.BrotliStream> constructors are:

- <xref:System.IO.Compression.CompressionLevel.Optimal?displayProperty=nameWithType>
- <xref:System.IO.Compression.CompressionLevel.Fastest?displayProperty=nameWithType>
- <xref:System.IO.Compression.CompressionLevel.NoCompression?displayProperty=nameWithType>
- <xref:System.IO.Compression.CompressionLevel.SmallestSize?displayProperty=nameWithType>

If you pass any other value, an <xref:System.ArgumentException> is thrown at run time.

## Version introduced

.NET 7 Preview 1

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

Being able to pass arbitrary values that aren't defined by the <xref:System.IO.Compression.CompressionLevel> enumeration is unexpected and undocumented, and is likely to lead to mistakes.

## Recommended action

If necessary, change your code to pass in one of the valid <xref:System.IO.Compression.CompressionLevel> values.

## Affected APIs

- <xref:System.IO.Compression.BrotliStream.%23ctor(System.IO.Stream,System.IO.Compression.CompressionLevel,System.Boolean)>
- <xref:System.IO.Compression.BrotliStream.%23ctor(System.IO.Stream,System.IO.Compression.CompressionLevel)>
