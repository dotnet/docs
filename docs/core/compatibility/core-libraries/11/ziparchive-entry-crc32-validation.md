---
title: "Breaking change: CRC32 validation added when reading ZIP archive entries"
description: "Learn about the breaking change in .NET 11 where reading ZIP archive entries now validates CRC32 checksums and throws InvalidDataException for corrupted data."
ms.date: 04/03/2026
ai-usage: ai-assisted
---

# CRC32 validation added when reading ZIP archive entries

Starting in .NET 11, the <xref:System.IO.Compression> library validates CRC32 checksums when reading ZIP archive entries. If the computed CRC32 checksum doesn't match the expected value stored in the ZIP file's metadata, an <xref:System.IO.InvalidDataException> is thrown.

## Version introduced

.NET 11 Preview 3

## Previous behavior

Previously, `System.IO.Compression` didn't validate CRC32 checksums when reading ZIP archive entries. Corrupted or tampered ZIP entries could be read without errors, potentially causing silent data corruption.

```csharp
using System.IO.Compression;

using var archive = ZipFile.OpenRead("corrupted.zip");
var entry = archive.GetEntry("file.txt") 
    ?? throw new FileNotFoundException("Entry 'file.txt' not found in archive.");

using var stream = entry.Open();

// Data read without any validation of its integrity.
byte[] buffer = new byte[entry.Length];
stream.ReadExactly(buffer);
```

## New behavior

Starting in .NET 11, the library verifies the integrity of ZIP entries during read operations. If the computed CRC32 checksum doesn't match the expected value from the ZIP file's metadata, an <xref:System.IO.InvalidDataException> is thrown.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change improves the reliability and security of `System.IO.Compression`. By validating CRC32 checksums, the library detects and prevents use of corrupted or tampered ZIP entries, ensuring applications don't inadvertently process invalid data. For more information, see [dotnet/runtime#124766](https://github.com/dotnet/runtime/pull/124766).

## Recommended action

If your application processes ZIP files that might be corrupted or tampered with, handle <xref:System.IO.InvalidDataException> appropriately:

```csharp
try
{
    using var archive = ZipFile.OpenRead("corrupted.zip");
    var entry = archive.GetEntry("file.txt") 
        ?? throw new FileNotFoundException("Entry 'file.txt' not found in archive.");

    using var stream = entry.Open();

    byte[] buffer = new byte[entry.Length];
    stream.ReadExactly(buffer);
}
catch (InvalidDataException ex)
{
    Console.WriteLine($"Error reading ZIP entry: {ex.Message}");
}
```

## Affected APIs

- <xref:System.IO.Compression.ZipArchiveEntry.Open?displayProperty=fullName>
