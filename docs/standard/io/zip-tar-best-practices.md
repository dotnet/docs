---
title: Best practices for ZIP and TAR archives
description: Learn best practices for working with ZIP and TAR archives in .NET, including API selection, trusted and untrusted extraction patterns, memory management, and platform considerations.
ms.topic: best-practice
ms.date: 04/10/2026
ai-usage: ai-assisted
dev_langs:
  - "csharp"
helpviewer_keywords:
  - "I/O [.NET], compression"
  - "compression"
  - "ZIP"
  - "TAR"
  - "zip bomb"
  - "path traversal"
  - "Zip Slip"
  - "archive security"
---

# Best practices for working with ZIP and TAR archives in .NET

This article covers best practices for working with ZIP and TAR archives in .NET. You'll learn how to choose the right API for your scenario, use the convenience methods effectively for trusted input, and safely handle untrusted archives to protect against common attacks like path traversal and zip bombs.

.NET provides built-in support for two of the most common archive formats:

- **ZIP** (`System.IO.Compression`): A compressed archive format that bundles multiple files and directories into a single file. ZIP supports per-entry compression (Deflate, Deflate64, Stored). The primary types are <xref:System.IO.Compression.ZipArchive?displayProperty=fullName> for reading and writing archives, <xref:System.IO.Compression.ZipFile?displayProperty=fullName> for file-based convenience methods, and <xref:System.IO.Compression.ZipFileExtensions?displayProperty=fullName> for extraction helpers.

- **TAR** (`System.Formats.Tar`): A Unix-origin archive format that stores files, directories, and metadata (permissions, ownership, timestamps) without compression. .NET supports the V7, UStar, PAX, and GNU formats. The primary types are <xref:System.Formats.Tar.TarReader?displayProperty=fullName> and <xref:System.Formats.Tar.TarWriter?displayProperty=fullName> for streaming access, and <xref:System.Formats.Tar.TarFile?displayProperty=fullName> for file-based convenience methods. TAR is often combined with a compression layer (for example, <xref:System.IO.Compression.GZipStream?displayProperty=fullName> for `.tar.gz` files).

## Choose the right API

.NET offers two categories of archive APIs. Pick the category that matches your scenario.

- [Convenience APIs (one-shot operations)](#convenience-apis-one-shot-operations)
- [Streaming APIs (entry-by-entry control)](#streaming-apis-entry-by-entry-control)

If you control the archive source (your own build output, known-safe backups), the convenience APIs are the simplest choice. If the archive comes from an external source (user uploads, downloads, network transfers), use the streaming APIs with the safety checks described in this article.

> [!CAUTION]
> ZIP and TAR archives differ significantly in what they store. ZIP primarily transmits files, while TAR transmits a complete filesystem topology, including file types, symbolic links, hard links, permissions, and other metadata. This difference has important security implications: TAR's richer structure gives an adversary more ways to influence how data is represented on disk, well beyond just filenames and file contents. Exercise extra caution when processing untrusted TAR archives.

### Convenience APIs (one-shot operations)

Use these APIs to create or extract an entire archive in a single call. They're ideal for simple, trusted scenarios.

- <xref:System.IO.Compression.ZipFile.CreateFromDirectory*?displayProperty=fullName>
- <xref:System.IO.Compression.ZipFile.ExtractToDirectory*?displayProperty=fullName>
- <xref:System.Formats.Tar.TarFile.CreateFromDirectory*?displayProperty=fullName>
- <xref:System.Formats.Tar.TarFile.ExtractToDirectory*?displayProperty=fullName>

Best for: simple workflows with trusted input, quick scripts, and build tooling.

### Streaming APIs (entry-by-entry control)

Use these APIs for full control over each archive entry. They're essential for large archives or untrusted input.

- **ZIP:** Use <xref:System.IO.Compression.ZipArchive?displayProperty=fullName> to open an archive and iterate, read, or write entries selectively. Use <xref:System.IO.Compression.ZipFileExtensions.ExtractToFile*> to extract individual entries, or <xref:System.IO.Compression.ZipFileExtensions.ExtractToDirectory*> to extract all entries from an already-opened archive.

- **TAR:** Use <xref:System.Formats.Tar.TarReader?displayProperty=fullName> and <xref:System.Formats.Tar.TarWriter> for sequential entry-by-entry access. Use <xref:System.Formats.Tar.TarEntry.ExtractToFile*?displayProperty=fullName> to extract individual entries.

Best for: large archives, selective extraction, untrusted input, and custom processing.

> [!TIP]
> Import the `System.IO.Compression` namespace to access the extension methods on <xref:System.IO.Compression.ZipArchive> and <xref:System.IO.Compression.ZipArchiveEntry>.

## Work with trusted archives

When the archive source is known and trusted, the [convenience methods](#convenience-apis-one-shot-operations) give you a safe, one-line extraction path:

- <xref:System.IO.Compression.ZipFile.ExtractToDirectory*?displayProperty=nameWithType> and <xref:System.Formats.Tar.TarFile.ExtractToDirectory*?displayProperty=nameWithType> handle path validation automatically. They sanitize entry names, resolve each entry's full path, and verify the resolved path stays inside the destination directory.

- <xref:System.IO.Compression.ZipFile.ExtractToDirectory*?displayProperty=nameWithType> has overloads that default to not overwriting existing files. All <xref:System.Formats.Tar.TarFile.ExtractToDirectory*?displayProperty=nameWithType> overloads require the `overwriteFiles` parameter, so you must always choose explicitly.

- When overwriting is enabled during ZIP extraction, .NET extracts to a temporary file first and only replaces the target after successful extraction. This prevents partial corruption if the extraction fails.

- TAR extraction handles overwriting differently: it deletes the existing file before writing the replacement. If extraction fails after deletion (for example, due to an I/O error or process interruption), the original file is lost and the replacement might be incomplete. Consider backing up critical files before overwriting with TAR extraction.

> [!NOTE]
> The convenience methods don't enforce size limits, entry count limits, or other policies needed for safe extraction of untrusted archives. If that matters even for trusted input (for example, very large archives), use the streaming approach described in [Handle untrusted archives safely](#handle-untrusted-archives-safely).

## Handle untrusted archives safely

For untrusted input—user uploads, third-party downloads, or network transfers—iterate over entries manually and enforce your own safety checks. The following subsections describe what you need to enforce and why.

- [What the convenience methods don't protect you from](#what-the-convenience-methods-dont-protect-you-from)
- [Enforce size and entry count limits](#enforce-size-and-entry-count-limits)
- [Validate destination paths](#validate-destination-paths)
- [Handle symbolic and hard links (TAR)](#handle-symbolic-and-hard-links-tar)
- [Complete safe extraction examples](#complete-safe-extraction-examples)

### What the convenience methods don't protect you from

`ExtractToDirectory` protects against *path traversal*—an attack where a malicious entry name like `../../etc/passwd` tries to write outside the destination directory. The method resolves each entry's full path and rejects any that fall outside the target directory (for TAR, this check also covers symbolic link targets). However, `ExtractToDirectory` doesn't enforce size limits or entry count limits.

### Enforce size and entry count limits

Neither <xref:System.IO.Compression.ZipArchive> nor <xref:System.Formats.Tar.TarReader> limits the total uncompressed size or the number of entries extracted, and neither do the `ExtractToDirectory` convenience methods. You must enforce these limits yourself.

> [!IMPORTANT]
> A small compressed file can expand to terabytes of data—this is known as a *zip bomb*. Zip bombs come in two forms:
>
> - **Flat (non-recursive):** A single archive contains many entries that each decompress to a large size. DEFLATE achieves ratios up to ~1032×, so 100 KB of compressed data can expand to ~100 MB. Scaling up the entry count or entry size produces terabytes of output in a single extraction pass. These bombs are effective against any zip parser, including .NET.
> - **Recursive (nested):** An archive contains inner archives, each containing more archives, multiplying the expansion at every layer. The classic `42.zip` uses five layers of 16 nested zips to reach 4.5 PB. However, .NET's `ExtractToDirectory` doesn't recursively extract inner archives—it treats them as opaque files—so recursive bombs aren't a concern unless your code opens the extracted archives again.
>
> Always enforce limits on decompressed size and entry count when extracting untrusted archives.

- Enforce per-entry size limits

  :::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="SafeExtractEntry":::

- Track aggregate size and entry count

  :::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="SafeExtractArchive":::

> [!TIP]
> The same approach applies to TAR archives. Since TAR files are read entry-by-entry via <xref:System.Formats.Tar.TarReader.GetNextEntry*>, track both the cumulative data size and entry count as you iterate.

### Validate destination paths

When you use the streaming APIs, you're responsible for validating every entry's destination path. They perform no path validation at all.

For every entry, resolve the destination to an absolute path and verify it falls within your target directory:

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="PathValidation":::

Key points:

- `Path.GetFullPath()` resolves relative segments like `../` into an absolute path.
- The `StartsWith` check ensures the resolved path is still inside the destination.
- The trailing directory separator on `fullDestDir` is critical—without it, a path like `/safe-dir-evil/file` would incorrectly match `/safe-dir`.

> [!WARNING]
> The following APIs leave you completely unprotected against path traversal. You must validate paths yourself before calling them.

- <xref:System.IO.Compression.ZipFileExtensions.ExtractToFile*?displayProperty=nameWithType> writes to whatever path you give it—no sanitization, no boundary check.
- <xref:System.IO.Compression.ZipArchiveEntry.Open*?displayProperty=nameWithType> returns a raw `Stream`—the caller decides where to write.
- <xref:System.Formats.Tar.TarEntry.ExtractToFile*?displayProperty=nameWithType> writes to the given path without validating it against any directory boundary.

**Vulnerable pattern—DO NOT USE without validation:**

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="VulnerablePattern":::

### Handle symbolic and hard links (TAR)

TAR archives support symbolic links and hard links, which introduce attack vectors beyond basic path traversal:

- **Symlink escape:** A symlink entry points to an arbitrary location (for example, `/etc/`), then a subsequent file entry relative to the symlink directory writes through the link to that external location.
- **Hard link to sensitive file:** A hard link target references a file outside the extraction directory. Because a hard link shares the same inode as the original, any code that later opens the hard link for writing (for example, with `File.Create` or `File.WriteAllText`) modifies the original file's contents.

The safest approach for untrusted archives is to skip link entries entirely:

```csharp
if (entry.EntryType is TarEntryType.SymbolicLink or TarEntryType.HardLink)
    continue; // Skip link entries for untrusted input
```

If you need to preserve links, validate that the link target resolves within your destination directory before creating it:

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="ValidateSymlink":::

If your use case requires extracting archives with hard links but you want to avoid hard links on disk, <xref:System.Formats.Tar.TarHardLinkMode.CopyContents?displayProperty=nameWithType> copies the file content instead of creating a hard link. This eliminates hard-link-based attacks and produces more portable output on Windows.

For reference, <xref:System.Formats.Tar.TarFile.ExtractToDirectory*?displayProperty=nameWithType> validates both the entry path and link target path against the destination directory boundary. If either resolves outside, an <xref:System.IO.IOException> is thrown. <xref:System.Formats.Tar.TarEntry.ExtractToFile*?displayProperty=nameWithType> rejects symbolic and hard link entries entirely—it throws <xref:System.InvalidOperationException>.

### Complete safe extraction examples

Combine path traversal validation, size limits, entry count limits, and link handling in a single extraction loop.

- **ZIP**

  The following method extracts a ZIP archive while enforcing all recommended safety checks:

  :::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="SafeExtractZip":::

- **TAR**

  TAR extraction differs from ZIP in several ways: entries are read sequentially (there's no central directory), link entries need explicit handling, and the `DataStream` must be consumed before advancing to the next entry.

  :::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="SafeExtractTar":::

## Memory and performance considerations

Understanding how .NET manages memory for ZIP and TAR operations helps you avoid unexpected issues with large or untrusted archives.

- [ZipArchive memory usage](#ziparchive-memory-usage)
- [TAR streaming model](#tar-streaming-model)
- [Thread safety](#thread-safety)

### ZipArchive memory usage

Don't use <xref:System.IO.Compression.ZipArchiveMode.Update?displayProperty=nameWithType> for large or untrusted archives. When you open a <xref:System.IO.Compression.ZipArchive> in `Update` mode and call <xref:System.IO.Compression.ZipArchiveEntry.Open*> or <xref:System.IO.Compression.ZipArchiveEntry.OpenAsync*> on an entry, its uncompressed data is loaded into a <xref:System.IO.MemoryStream> to support in-place modifications. Accessing entry metadata (such as <xref:System.IO.Compression.ZipArchiveEntry.FullName>, <xref:System.IO.Compression.ZipArchiveEntry.Length>, or <xref:System.IO.Compression.ZipArchiveEntry.ExternalAttributes>) does not trigger decompression. For large or malicious archives, opening entry content streams can cause <xref:System.OutOfMemoryException>. Check <xref:System.IO.Compression.ZipArchiveEntry.Length> before calling <xref:System.IO.Compression.ZipArchiveEntry.Open*> to avoid decompressing unexpectedly large entries.

Additionally, when you open a <xref:System.IO.Compression.ZipArchive> in <xref:System.IO.Compression.ZipArchiveMode.Read?displayProperty=nameWithType> mode with an **unseekable** stream (for example, a network stream), the runtime buffers the entire archive contents in memory to enable seeking through the central directory.

**Recommendation:** Only use `Update` mode for archives you trust and know are small enough to fit in memory. <xref:System.IO.Compression.ZipArchiveMode.Read?displayProperty=nameWithType> and <xref:System.IO.Compression.ZipArchiveMode.Create?displayProperty=nameWithType> modes are safer because they stream entry data rather than buffering it entirely in memory. To modify a large archive, open the original in `Read` mode, create a new archive in `Create` mode, and selectively copy entries:

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="StreamingApproach":::

### TAR streaming model

<xref:System.Formats.Tar.TarReader?displayProperty=fullName> reads entries one at a time and doesn't buffer the entire archive. However, for unseekable streams, each entry's <xref:System.Formats.Tar.TarEntry.DataStream?displayProperty=nameWithType> is only valid until the next <xref:System.Formats.Tar.TarReader.GetNextEntry*?displayProperty=nameWithType> call. If you need to retain entry data, either copy it immediately or pass `copyContents: true` to <xref:System.Formats.Tar.TarReader.GetNextEntry*?displayProperty=nameWithType>, which copies the entry data into a separate <xref:System.IO.MemoryStream> that remains valid after advancing. Like <xref:System.IO.Compression.ZipArchiveMode.Update?displayProperty=nameWithType>, `copyContents: true` loads the full entry into memory, so check entry sizes before using it with untrusted archives.

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="TarStreaming":::

### Thread safety

<xref:System.IO.Compression.ZipArchive?displayProperty=fullName>, <xref:System.Formats.Tar.TarReader?displayProperty=fullName>, and <xref:System.Formats.Tar.TarWriter?displayProperty=fullName> are not thread-safe. Don't access an instance from multiple threads concurrently. If you need to read multiple archives in parallel, open a separate instance per thread. For writing, synchronize access externally—multiple writers can't safely target the same archive file concurrently.

## Platform considerations

Archive behavior can vary between Windows and Unix. Keep these differences in mind when writing cross-platform code.

- [Unix file permissions](#unix-file-permissions)
- [Special entry types (TAR)](#special-entry-types-tar)
- [File name sanitization differs by platform](#file-name-sanitization-differs-by-platform)

### Unix file permissions

- **ZIP:** Unix permissions are stored in the upper 16 bits of <xref:System.IO.Compression.ZipArchiveEntry.ExternalAttributes?displayProperty=nameWithType>. When extracting on Unix via `ExtractToDirectory` or `ExtractToFile`, the runtime restores ownership permissions (read/write/execute for user/group/other), subject to the process umask. SetUID, SetGID, and StickyBit are stripped. Permissions are not applied if the upper bits are zero. This happens when the ZIP was created on Windows, because .NET on Windows sets `DefaultFileExternalAttributes` to `0`. On Windows, these attributes are always ignored during extraction.
- **TAR:** The <xref:System.Formats.Tar.TarEntry.Mode?displayProperty=nameWithType> property represents `UnixFileMode` and can store all 12 permission bits (read/write/execute for user/group/other, plus SetUID, SetGID, and StickyBit). When extracting on Unix via `ExtractToDirectory` or `ExtractToFile`, the runtime applies only the 9 ownership bits (rwx for user/group/other), subject to the process umask. SetUID, SetGID, and StickyBit are stripped for security.

When processing untrusted archives, be aware that extracted files may have executable permissions set by the archive author. Untrusted archives could contain malicious executable files.

### Special entry types (TAR)

Block devices, character devices, and FIFOs can only be created on Unix. Extracting these on Windows throws an exception. Elevated privileges are required to create block and character device entries.

### File name sanitization differs by platform

On Windows, when using `ExtractToDirectory`, the runtime replaces control characters and `"*:<>?|` with underscores in entry names. On Unix, only null characters are replaced. Archive entries with names like `file:name.txt` are renamed to `file_name.txt` on Windows but extracted as-is on Unix. The per-entry APIs (`Open()`, `ExtractToFile()`) do not perform any name sanitization, so when using them with entry names from untrusted archives, validate the name and path before extracting (as shown in the [Validate destination paths](#validate-destination-paths) section).

## Data integrity

ZIP and TAR archives use different integrity checks. ZIP stores CRC-32 values for entry data. TAR stores a header checksum for each entry header.

Starting with .NET 11, the runtime validates ZIP CRC-32 values automatically when reading ZIP entries. When you read an entry's data stream to completion, the runtime compares the computed CRC-32 value of the decompressed data against the value stored in the archive. If the values don't match, an <xref:System.IO.InvalidDataException> is thrown. Starting with .NET 11, the runtime also validates TAR header checksums when reading TAR entry headers.

> [!NOTE]
> In versions earlier than .NET 11, the runtime didn't validate ZIP CRC-32 values on read. The runtime computed CRC-32 values when writing ZIP entries for storage in the archive, but didn't verify them during extraction. If you target a runtime earlier than .NET 11, corrupt or tampered ZIP entries might be accepted silently.
>
> CRC-32 isn't a cryptographic hash—it detects accidental corruption but doesn't protect against intentional tampering by a sophisticated attacker.

## Untrusted metadata

### ZIP comments and extra fields

- **Archive and entry comments** are arbitrary strings. If your application displays or processes comments, sanitize them appropriately.
- **Extra fields** are binary key-value pairs attached to each entry. The runtime preserves unknown extra fields and trailing data when reading and writing archives in <xref:System.IO.Compression.ZipArchiveMode.Update?displayProperty=nameWithType> mode and round-trips them as-is. If your application reads or interprets extra fields, validate their contents.
- **Entry name encoding:** when writing, the runtime uses ASCII for entry names that contain only ASCII printable characters (32-126) and UTF-8 (with the language encoding flag set) for names that contain other characters. When reading without a custom encoding, entries with or without the language encoding flag are decoded as UTF-8 (which also correctly decodes ASCII). Use the `entryNameEncoding` parameter on <xref:System.IO.Compression.ZipArchive> to override encoding when needed, but be aware the override affects all entries uniformly.

## Encryption considerations (.NET 11+)

.NET 11 adds support for reading and writing encrypted ZIP archives. The following subsections explain how to choose an encryption method, read encrypted entries, and use encrypted archives with the convenience APIs.

- [Choose AES-256 for new archives](#choose-aes-256-for-new-archives)
- [Read encrypted entries](#read-encrypted-entries)
- [Convenience methods with encryption](#convenience-methods-with-encryption)

> [!NOTE]
> ZIP encryption support (ZipCrypto and WinZip AES) is new in .NET 11.

The `ZipEncryptionMethod` enum specifies the encryption method:

| Value | Description |
|-------|-------------|
| `None` | No encryption. |
| `ZipCrypto` | Legacy ZIP encryption. Use only for backward compatibility—vulnerable to known-plaintext attacks. |
| `Aes128` | WinZip AES-128. |
| `Aes192` | WinZip AES-192. |
| `Aes256` | WinZip AES-256. **Recommended**—strongest available option. |
| `Unknown` | Returned when the entry uses an encryption method that .NET does not support. |

### Choose AES-256 for new archives

When creating encrypted entries, always prefer `Aes256`. `ZipCrypto` is a legacy method with known cryptographic weaknesses and shouldn't be relied upon for security—use it only when interoperating with tools that don't support WinZip AES.

```csharp
string password = "your-password-here";

// ⚠️ Weak encryption — use only for backward compatibility
archive.CreateEntry("file.txt", password, ZipEncryptionMethod.ZipCrypto);

// ✅ Prefer AES-256
archive.CreateEntry("file.txt", password, ZipEncryptionMethod.Aes256);
```

### Read encrypted entries

Use `ZipArchiveEntry.EncryptionMethod` to check the encryption method, and provide a password to `Open`:

```csharp
using ZipArchive archive = ZipFile.OpenRead("encrypted.zip");

foreach (ZipArchiveEntry entry in archive.Entries)
{
    if (entry.EncryptionMethod == ZipEncryptionMethod.Unknown)
    {
        // Unsupported encryption method, skip this entry
        continue;
    }

    using Stream stream = entry.Open("myPassword");
    // ... read the decrypted data
}
```

Attempting to open an entry that uses an unsupported encryption method (`ZipEncryptionMethod.Unknown`) throws <xref:System.NotSupportedException>.

### Convenience methods with encryption

New option types let you pass a password and encryption method to the convenience APIs:

```csharp
// Extract an encrypted archive
ZipFile.ExtractToDirectory("encrypted.zip", destDir, new ZipExtractionOptions
{
    Password = "myPassword".AsMemory(),
    OverwriteFiles = false
});

// Create an encrypted archive
ZipFile.CreateFromDirectory(sourceDir, "encrypted.zip", new ZipFileCreationOptions
{
    Password = "myPassword".AsMemory(),
    EncryptionMethod = ZipEncryptionMethod.Aes256,
    CompressionLevel = CompressionLevel.Optimal
});
```

## Best practices checklist

Before deploying code that handles archives from untrusted sources, verify you've addressed each of the following:

- **Manual iteration:** Don't use `ExtractToDirectory` for untrusted input—iterate entries manually to enforce all limits.
- **Path traversal:** Validate all destination paths with `Path.GetFullPath()` + `StartsWith()`.
- **Decompression bombs:** Enforce limits on decompressed size (per-entry and total) and entry count.
- **Symlink/hardlink attacks (TAR):** Validate link targets resolve within the destination, or skip link entries entirely.
- **Memory limits:** Avoid <xref:System.IO.Compression.ZipArchiveMode.Update?displayProperty=nameWithType> for large untrusted archives. Avoid <xref:System.IO.Compression.ZipArchiveMode.Read?displayProperty=nameWithType> mode with unseekable streams from untrusted sources.
- **Thread safety:** Don't share <xref:System.IO.Compression.ZipArchive>, <xref:System.Formats.Tar.TarReader?displayProperty=fullName>, or <xref:System.Formats.Tar.TarWriter?displayProperty=fullName> instances across threads.
- **Untrusted metadata:** Treat entry names, comments, and extra fields as untrusted input. Sanitize before display or processing.
- **Overwrite behavior:** Default to `overwrite: false`.
- **Resource disposal:** Always dispose <xref:System.IO.Compression.ZipArchive?displayProperty=fullName>, <xref:System.Formats.Tar.TarReader>, <xref:System.Formats.Tar.TarWriter>, and their streams.

## Related content

- <xref:System.IO.Compression>
- <xref:System.Formats.Tar>
- <xref:System.IO.Compression.ZipFile>
- <xref:System.Formats.Tar.TarFile>
