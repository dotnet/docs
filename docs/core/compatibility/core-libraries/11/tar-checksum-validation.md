---
title: "Breaking change: Tar reading APIs verify header checksums when reading"
description: "Learn about the breaking change in .NET 11 Preview 1 where TarReader validates checksums and throws InvalidDataException for invalid entries."
ms.date: 01/09/2026
ai-usage: ai-assisted
---

# Tar reading APIs verify header checksums when reading

Starting in .NET 11 Preview 1, the <xref:System.Formats.Tar.TarReader> class now validates the checksum of TAR archive entries during the reading process. If an entry's checksum is invalid, the `TarReader` throws an <xref:System.InvalidDataException>. This change improves data integrity by ensuring that corrupted or tampered TAR files are detected and flagged during processing.

## Version introduced

.NET 11 Preview 1

## Previous behavior

Previously, when reading a TAR archive with an invalid checksum, the `TarReader` would ignore the checksum mismatch and continue processing the archive without throwing an exception.

Example code:

```csharp
using System.Formats.Tar;
using System.IO;

using var stream = File.OpenRead("bad-cksum.tar");
using var reader = new TarReader(stream);

while (reader.GetNextEntry() is not null)
{
    // Process entries, even if the checksum is invalid
}
```

If the TAR file `bad-cksum.tar` contained an entry with an invalid checksum, the code would process the entry without any indication of the issue.

## New behavior

Starting in .NET 11, when reading a TAR archive with an invalid checksum, the `TarReader` throws an <xref:System.InvalidDataException> and stops processing the archive.

Example code:

```csharp
using System.Formats.Tar;
using System.IO;

try
{
    using var stream = File.OpenRead("bad-cksum.tar");
    using var reader = new TarReader(stream);

    while (reader.GetNextEntry() is not null)
    {
        // Process entries
    }
}
catch (InvalidDataException ex)
{
    Console.WriteLine($"Checksum validation failed: {ex.Message}");
}
```

If the TAR file `bad-cksum.tar` contains an entry with an invalid checksum, the code throws an exception with a message indicating the checksum validation failure.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was introduced to improve the reliability and security of the `System.Formats.Tar` library. By validating checksums, the `TarReader` can detect and prevent the use of corrupted or tampered TAR files, ensuring that only valid data is processed. For more information, see [dotnet/runtime#118577](https://github.com/dotnet/runtime/pull/118577) and [dotnet/runtime#117455](https://github.com/dotnet/runtime/issues/117455).

## Recommended action

If your application relies on the `TarReader` to process TAR archives, you should:

1. Update your code to handle the <xref:System.InvalidDataException> that might be thrown when a checksum validation fails.
2. Ensure that the TAR files being processed are valid and have correct checksums. If you encounter checksum failures, verify the integrity of the source TAR files.
3. If you need to process TAR files with invalid checksums for specific scenarios, consider implementing custom error handling or preprocessing the files to correct the checksums.

Updated example:

```csharp
using System.Formats.Tar;
using System.IO;

try
{
    using var stream = File.OpenRead("archive.tar");
    using var reader = new TarReader(stream);

    while (reader.GetNextEntry() is not null)
    {
        // Process entries
    }
}
catch (InvalidDataException ex)
{
    Console.WriteLine($"Error reading TAR archive: {ex.Message}");
    // Handle invalid checksum scenario
}
```

## Affected APIs

- <xref:System.Formats.Tar.TarReader.GetNextEntry?displayProperty=fullName>
- <xref:System.Formats.Tar.TarReader.GetNextEntryAsync(System.Threading.CancellationToken)?displayProperty=fullName>
- <xref:System.Formats.Tar.TarFile.ExtractToDirectory(System.IO.Stream,System.String,System.Boolean)?displayProperty=fullName>
- <xref:System.Formats.Tar.TarFile.ExtractToDirectoryAsync(System.IO.Stream,System.String,System.Boolean,System.Threading.CancellationToken)?displayProperty=fullName>
