---
title: "Breaking change: ZipArchive.CreateAsync eagerly loads ZIP archive entries"
description: "Learn about the breaking change in .NET 11 where ZipArchive.CreateAsync eagerly loads all ZIP archive entries to avoid synchronous reads on the stream."
ms.date: 02/03/2026
ai-usage: ai-assisted
---
# ZipArchive.CreateAsync eagerly loads ZIP archive entries

<xref:System.IO.Compression.ZipArchive.CreateAsync%2A?displayProperty=nameWithType> now eagerly loads all ZIP archive entries during the method call. This change ensures that accessing the <xref:System.IO.Compression.ZipArchive.Entries?displayProperty=nameWithType> property doesn't perform synchronous reads on the underlying stream, which aligns with asynchronous programming patterns.

## Version introduced

.NET 11 Preview 1

## Previous behavior

Previously, when you created a `ZipArchive` using `CreateAsync`, accessing the `Entries` property could result in synchronous (blocking) read operations being performed on the underlying stream. This behavior was inconsistent with the asynchronous nature of the `CreateAsync` method and could cause issues with streams that don't support synchronous reads.

```csharp
using System.IO;
using System.IO.Compression;

using var stream = new FileStream("archive.zip", FileMode.Open);
using var archive = await ZipArchive.CreateAsync(stream, ZipArchiveMode.Read);

// This call performs synchronous reads on the stream.
// Might throw if the file entries are malformed
// or if the stream doesn't support synchronous reads.
var entries = archive.Entries;
```

## New behavior

Starting in .NET 11, the central directory of the ZIP archive is read asynchronously as part of the `ZipArchive.CreateAsync` method call. Any exceptions related to malformed entries or issues reading the central directory are now thrown during the `CreateAsync` call. Subsequent access to the `Entries` property doesn't perform any read operations on the underlying stream.

```csharp
using System.IO;
using System.IO.Compression;

using var stream = new FileStream("archive.zip", FileMode.Open);

// This call eagerly loads the ZIP archive entries.
// Any exceptions related to malformed entries are surfaced here.
using var archive = await ZipArchive.CreateAsync(stream, ZipArchiveMode.Read);

// Accessing Entries no longer performs stream read operations.
var entries = archive.Entries;
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made to improve consistency and reliability when working with asynchronous streams. By eagerly loading entries during the `CreateAsync` call, the API avoids unexpected synchronous read operations later. Avoiding synchronous reads is especially important for streams that might end up blocking until data are available (such as network streams). This aligns with the approved API design and provides a more predictable programming experience.

For more information, see [dotnet/runtime#121938](https://github.com/dotnet/runtime/pull/121938), [dotnet/runtime#121624](https://github.com/dotnet/runtime/issues/121624), and the [API design discussion](https://github.com/dotnet/runtime/issues/1541#issuecomment-2715269236).

## Recommended action

If your code uses `ZipArchive.CreateAsync`, ensure that you handle <xref:System.IO.InvalidDataException> exceptions from the `CreateAsync` method call. This exception could already be thrown in previous .NET versions (for example, when the ZIP central directory can't be found), but now it's also thrown for malformed entries that were previously only discovered when accessing the `Entries` property.

## Affected APIs

- <xref:System.IO.Compression.ZipArchive.CreateAsync(System.IO.Stream,System.IO.Compression.ZipArchiveMode,System.Boolean,System.Text.Encoding,System.Threading.CancellationToken)?displayProperty=fullName>
- <xref:System.IO.Compression.ZipArchive.Entries?displayProperty=fullName>
