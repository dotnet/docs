---
title: "Breaking change: DeflateStream and GZipStream encode empty payload into nonempty encoded payload"
description: "Learn about the breaking change in .NET 11 Preview 1 where DeflateStream and GZipStream always write headers and footers to the output, even for empty payloads."
ms.date: 01/09/2026
ai-usage: ai-assisted
---

# DeflateStream and GZipStream encode empty payload into nonempty encoded payload

<xref:System.IO.Compression.DeflateStream> and <xref:System.IO.Compression.GZipStream> now always write format headers and footers to the output stream, even when no data is written. This ensures the output is a valid compressed stream according to the Deflate and GZip specifications.

## Version introduced

.NET 11 Preview 1

## Previous behavior

Previously, `DeflateStream` and `GZipStream` would not produce any output if no data was written to the stream. This resulted in an empty output stream when compressing an empty input.

```csharp
using var output = new MemoryStream();
using (var deflate = new DeflateStream(output, CompressionMode.Compress))
{
    // No data written.
}
Console.WriteLine(output.Length); // Wrote: 0
```

## New behavior

Starting in .NET 11, `DeflateStream` and `GZipStream` always write the appropriate headers and footers to the output stream, even when no data is written. This ensures the output contains valid compressed data according to the format specifications.

```csharp
using var output = new MemoryStream();
using (var deflate = new DeflateStream(output, CompressionMode.Compress))
{
    // No data written.
}
Console.WriteLine(output.Length); // Writes: 2 (for Deflate) or 10 (for GZip)
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Deflate and GZip compression formats include delimiters for the start and end of compressed data. The correct way to compress an empty payload with these formats includes only those delimiters. Some tools don't correctly react to empty content and always expect the compressed content to contain at least the appropriate header and footer. This change ensures compatibility with such tools and produces properly formatted compressed streams according to the specifications.

## Recommended action

If the previous behavior is desired, special case empty content to not compress it via `DeflateStream` or `GZipStream`.

```csharp
byte[] dataToCompress = GetData();

if (dataToCompress.Length == 0)
{
    // Don't compress empty data.
    return Array.Empty<byte>();
}

using var output = new MemoryStream();
using (var deflate = new DeflateStream(output, CompressionMode.Compress))
{
    deflate.Write(dataToCompress);
}
return output.ToArray();
```

If you need to distinguish between empty and nonempty compressed streams, track whether any data was written or check the original uncompressed data length before compression.

## Affected APIs

- <xref:System.IO.Compression.DeflateStream?displayProperty=fullName>
- <xref:System.IO.Compression.GZipStream?displayProperty=fullName>
