---
title: What's new in .NET libraries for .NET 11
description: Learn about the updates to the .NET libraries for .NET 11.
titleSuffix: ""
ms.date: 02/10/2026
ai-usage: ai-generated
ms.update-cycle: 3650-days
---

# What's new in .NET libraries for .NET 11

This article describes new features in the .NET libraries for .NET 11. It was last updated for Preview 1.

## String and character enhancements

.NET 11 introduces significant enhancements to string and character manipulation APIs, making it easier to work with Unicode characters and runes.

### Rune support in String methods

The <xref:System.String> class now includes methods that accept <xref:System.Text.Rune> parameters, enabling you to search, replace, and manipulate strings using Unicode scalar values directly. These new methods include:

- `Contains` - Check if a string contains a specific rune: <xref:System.String.Contains(System.Text.Rune)?displayProperty=nameWithType> and <xref:System.String.Contains(System.Text.Rune,System.StringComparison)?displayProperty=nameWithType>.
- `StartsWith` and `EndsWith` - Check if a string starts or ends with a specific rune: <xref:System.String.StartsWith(System.Text.Rune)?displayProperty=nameWithType>, <xref:System.String.StartsWith(System.Text.Rune,System.StringComparison)?displayProperty=nameWithType>, <xref:System.String.EndsWith(System.Text.Rune)?displayProperty=nameWithType>, and <xref:System.String.EndsWith(System.Text.Rune,System.StringComparison)?displayProperty=nameWithType>.
- `IndexOf` and `LastIndexOf` - Find the position of a rune in a string: <xref:System.String.IndexOf(System.Text.Rune)?displayProperty=nameWithType>, <xref:System.String.IndexOf(System.Text.Rune,System.StringComparison)?displayProperty=nameWithType>, <xref:System.String.LastIndexOf(System.Text.Rune)?displayProperty=nameWithType>, and <xref:System.String.LastIndexOf(System.Text.Rune,System.StringComparison)?displayProperty=nameWithType>.
- `Replace` - Replace occurrences of one rune with another: <xref:System.String.Replace(System.Text.Rune,System.Text.Rune)?displayProperty=nameWithType>.
- `Split` - Split a string using a rune as the separator: <xref:System.String.Split(System.Text.Rune,System.StringSplitOptions)?displayProperty=nameWithType> and <xref:System.String.Split(System.Text.Rune,System.Int32,System.StringSplitOptions)?displayProperty=nameWithType>.
- `Trim`, `TrimStart`, and `TrimEnd` - Trim runes from strings: <xref:System.String.Trim(System.Text.Rune)?displayProperty=nameWithType>, <xref:System.String.TrimStart(System.Text.Rune)?displayProperty=nameWithType>, and <xref:System.String.TrimEnd(System.Text.Rune)?displayProperty=nameWithType>.

Many of these methods include overloads that accept a <xref:System.StringComparison> parameter for culture-aware comparisons.

### Char.Equals with StringComparison

The <xref:System.Char> struct now includes an <xref:System.Char.Equals(System.Char,System.StringComparison)?displayProperty=nameWithType> method that accepts a <xref:System.StringComparison> parameter, allowing you to compare characters using culture-aware or ordinal comparisons.

### Rune support in TextInfo

The <xref:System.Globalization.TextInfo> class now provides <xref:System.Globalization.TextInfo.ToLower(System.Text.Rune)?displayProperty=nameWithType> and <xref:System.Globalization.TextInfo.ToUpper(System.Text.Rune)?displayProperty=nameWithType> methods that accept <xref:System.Text.Rune> parameters, enabling you to perform case conversions on individual Unicode scalar values.

## Base64 encoding improvements

.NET 11 adds new APIs and overloads to the existing <xref:System.Buffers.Text.Base64> type, providing comprehensive support for Base64 encoding and decoding. These additions offer improved performance and flexibility compared to existing methods.

### New Base64 APIs

The new APIs support encoding and decoding operations with various input and output formats:

- **Encoding to chars**: <xref:System.Buffers.Text.Base64.EncodeToChars%2A> and <xref:System.Buffers.Text.Base64.EncodeToString%2A>
- **Encoding to UTF-8**: <xref:System.Buffers.Text.Base64.EncodeToUtf8%2A>
- **Decoding from chars**: <xref:System.Buffers.Text.Base64.DecodeFromChars%2A>
- **Decoding from UTF-8**: <xref:System.Buffers.Text.Base64.DecodeFromUtf8%2A>

These methods provide both high-level convenience methods (that allocate and return arrays or strings) and low-level span-based methods (for zero-allocation scenarios).

## Compression enhancements

.NET 11 includes several improvements to compression APIs.

### ZIP archive entry access modes

The <xref:System.IO.Compression.ZipArchiveEntry> class now supports opening entries with specific file access modes through new overloads: <xref:System.IO.Compression.ZipArchiveEntry.Open(System.IO.FileAccess)?displayProperty=nameWithType> and <xref:System.IO.Compression.ZipArchiveEntry.OpenAsync(System.IO.FileAccess,System.Threading.CancellationToken)?displayProperty=nameWithType>. These overloads accept a <xref:System.IO.FileAccess> parameter and allow you to open ZIP entries for read, write, or read-write access.

Additionally, a new <xref:System.IO.Compression.ZipArchiveEntry.CompressionMethod> property exposes the compression method used for an entry through the <xref:System.IO.Compression.ZipCompressionMethod> enum, which includes values for `Stored`, `Deflate`, and `Deflate64`.

### DeflateStream and GZipStream behavior change

Starting in .NET 11, <xref:System.IO.Compression.DeflateStream> and <xref:System.IO.Compression.GZipStream> always write format headers and footers to the output stream, even when no data is written. This ensures the output is a valid compressed stream according to the Deflate and GZip specifications.

Previously, these streams didn't produce any output if no data was written, resulting in an empty output stream. This change ensures compatibility with tools that expect properly formatted compressed streams.

For more information, see [DeflateStream and GZipStream write headers and footers for empty payload](../../compatibility/core-libraries/11/deflatestream-gzipstream-empty-payload.md).

## BFloat16 support in BitConverter

The <xref:System.BitConverter> class now includes methods for converting between <xref:System.Numerics.BFloat16> values and byte arrays or bit representations. These new methods include:

- <xref:System.BitConverter.GetBytes(System.Numerics.BFloat16)?displayProperty=nameWithType> - Convert a BFloat16 value to a byte array.
- <xref:System.BitConverter.ToBFloat16(System.Byte[],System.Int32)?displayProperty=nameWithType> and <xref:System.BitConverter.ToBFloat16(System.ReadOnlySpan{System.Byte})?displayProperty=nameWithType> - Convert a byte array to a BFloat16 value.
- <xref:System.BitConverter.BFloat16ToInt16Bits(System.Numerics.BFloat16)?displayProperty=nameWithType>, <xref:System.BitConverter.BFloat16ToUInt16Bits(System.Numerics.BFloat16)?displayProperty=nameWithType>, <xref:System.BitConverter.Int16BitsToBFloat16(System.Int16)?displayProperty=nameWithType>, and <xref:System.BitConverter.UInt16BitsToBFloat16(System.UInt16)?displayProperty=nameWithType> - Methods for converting between BFloat16 and its bit representation as `short` or `ushort`.

BFloat16 (Brain Floating Point) is a 16-bit floating-point format that's commonly used in machine learning and scientific computing.

## Collections improvements

### BitArray.PopCount

The <xref:System.Collections.BitArray> class now includes a <xref:System.Collections.BitArray.PopCount?displayProperty=nameWithType> method that returns the number of bits set to `true` in the array. This provides an efficient way to count set bits without manually iterating through the array.

### IReadOnlySet support in JSON serialization

The <xref:System.Text.Json.Serialization.Metadata.JsonMetadataServices> class now includes a <xref:System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreateIReadOnlySetInfo%2A?displayProperty=nameWithType> method, enabling JSON serialization support for <xref:System.Collections.Generic.IReadOnlySet%601> collections.

## URI data scheme constant

A new <xref:System.Uri.UriSchemeData?displayProperty=nameWithType> constant has been added, representing the `data:` URI scheme. This constant provides a standardized way to reference data URIs.

## StringSyntax attribute enhancements

The <xref:System.Diagnostics.CodeAnalysis.StringSyntaxAttribute> class now includes constants for common programming languages:

- `CSharp` - Indicates C# syntax.
- `FSharp` - Indicates F# syntax.
- `VisualBasic` - Indicates Visual Basic syntax.

These constants can be used with the `StringSyntax` attribute to provide better tooling support for string literals containing code in these languages.

## See also

- [What's new in the .NET 11 runtime](runtime.md)
- [What's new in the SDK for .NET 11](sdk.md)
- [Breaking changes in .NET 11](../../compatibility/11.md)
