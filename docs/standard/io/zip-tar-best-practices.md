---
title: Best practices for ZIP and TAR archives
description: Learn best practices for working with ZIP and TAR archives in .NET, including API selection, trusted and untrusted extraction patterns, memory management, and platform considerations.
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

.NET provides built-in support for two of the most common archive formats:

- **ZIP** (`System.IO.Compression`): A compressed archive format that bundles multiple files and directories into a single file. ZIP supports per-entry compression (Deflate, Deflate64, Stored). The primary types are <xref:System.IO.Compression.ZipArchive> for reading and writing archives, <xref:System.IO.Compression.ZipFile> for file-based convenience methods, and `ZipFileExtensions` for extraction helpers.
- **TAR** (`System.Formats.Tar`): A Unix-origin archive format that stores files, directories, and metadata (permissions, ownership, timestamps) without compression. .NET supports the V7, UStar, PAX, and GNU formats. The primary types are <xref:System.Formats.Tar.TarReader> and <xref:System.Formats.Tar.TarWriter> for streaming access, and <xref:System.Formats.Tar.TarFile> for file-based convenience methods. TAR is often combined with a compression layer (for example, `GZipStream` for `.tar.gz` files).

This article helps you choose the right API, use the convenience methods effectively for trusted input, and safely handle untrusted archives.

## Choose the right API

.NET offers two tiers of archive APIs. Pick the tier that matches your scenario.

### Convenience APIs (one-shot operations)

- `ZipFile.CreateFromDirectory` / `ZipFile.ExtractToDirectory`—create or extract an entire archive in one call.
- `TarFile.CreateFromDirectory` / `TarFile.ExtractToDirectory`—same for TAR.
- Best for: simple workflows with trusted input, quick scripts, build tooling.

### Streaming APIs (entry-by-entry control)

- `ZipArchive`—open an archive, iterate entries, read or write selectively.
- `TarReader` / `TarWriter`—sequential entry-by-entry access.
- Best for: large archives, selective extraction, untrusted input, custom processing.

If you control the archive source (your own build output, known-safe backups), the convenience APIs are the simplest choice. If the archive comes from an external source (user uploads, downloads, network transfers), use the streaming APIs with the safety checks described in this article.

## Work with trusted archives

When the archive source is known and trusted, the convenience methods give you a safe, one-line extraction path:

- `ZipFile.ExtractToDirectory` and `TarFile.ExtractToDirectory` handle path validation automatically. They sanitize entry names, resolve paths, and check directory boundaries.
- `ZipFile.ExtractToDirectory` has overloads that default to not overwriting existing files. All `TarFile.ExtractToDirectory` overloads require the `overwriteFiles` parameter, so you must always choose explicitly.
- When overwriting is enabled during ZIP extraction, .NET extracts to a temporary file first and only replaces the target after successful extraction. This prevents partial corruption if the extraction fails.

> [!NOTE]
> The convenience methods don't limit decompressed size or entry count. If that matters even for trusted input (for example, very large archives), use the streaming approach described in [Handle untrusted archives safely](#handle-untrusted-archives-safely).

## Handle untrusted archives safely

For untrusted input—user uploads, third-party downloads, or network transfers—iterate over entries manually and enforce your own safety checks. The following subsections describe what you need to enforce and why.

### What the convenience methods don't protect you from

`ExtractToDirectory` handles path traversal validation (including symbolic link targets in TAR), but it doesn't enforce size limits or entry count limits. A small compressed file can expand to terabytes of data (known as a *zip bomb*). You must enforce these limits yourself when processing untrusted input.

### Enforce size and entry count limits

Neither `ZipArchive` nor `TarReader` limits the total uncompressed size or the number of entries extracted, and neither do the `ExtractToDirectory` convenience methods. You must enforce these limits yourself.

> [!IMPORTANT]
> A small compressed file can expand to terabytes of data—this is known as a *zip bomb*. Always enforce limits on decompressed size and entry count when extracting untrusted archives.

#### Enforce per-entry size limits

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="SafeExtractEntry":::

#### Track aggregate size and entry count

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="SafeExtractArchive":::

> [!TIP]
> The same approach applies to TAR archives. Since TAR files are read entry-by-entry via `TarReader.GetNextEntry()`, track both the cumulative data size and entry count as you iterate.

### Validate destination paths

When you use the streaming APIs, you're responsible for validating every entry's destination path. The low-level APIs perform no path validation at all.

For every entry, resolve the destination to an absolute path and verify it falls within your target directory:

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="PathValidation":::

Key points:

- `Path.GetFullPath()` resolves relative segments like `../` into an absolute path.
- The `StartsWith` check ensures the resolved path is still inside the destination.
- The trailing directory separator on `fullDestDir` is critical—without it, a path like `/safe-dir-evil/file` would incorrectly match `/safe-dir`.

> [!WARNING]
> The following APIs leave you completely unprotected against path traversal. You must validate paths yourself before calling them.

- `ZipArchiveEntry.ExtractToFile()` writes to whatever path you give it—no sanitization, no boundary check.
- `ZipArchiveEntry.Open()` returns a raw `Stream`—the caller decides where to write.
- `TarEntry.ExtractToFile()` writes to the given path without validating it against any directory boundary.

**Vulnerable pattern—DO NOT USE without validation:**

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="VulnerablePattern":::

### Handle symbolic and hard links (TAR)

TAR archives support symbolic links and hard links, which introduce attack vectors beyond basic path traversal:

- **Symlink escape:** A symlink entry points to an arbitrary location (for example, `/etc/`), then a subsequent file entry relative to the symlink directory writes through the link to that external location.
- **Hard link to sensitive file:** A hard link target references a file outside the extraction directory. Because a hard link shares the same inode as the original, any code that later opens the hard link for writing modifies the original file's contents. Simply overwriting the hard link (for example, with `File.Create`) replaces the directory entry and does not affect the original.

The safest approach for untrusted archives is to skip link entries entirely:

```csharp
if (entry.EntryType is TarEntryType.SymbolicLink or TarEntryType.HardLink)
    continue; // Skip link entries for untrusted input
```

If you need to preserve links, validate that the link target resolves within your destination directory before creating it:

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="ValidateSymlink":::

If your use case requires hard links but you want to avoid filesystem-level hard links, `TarHardLinkMode.CopyContents` copies the file content instead of creating a real hard link. This eliminates hard-link-based attacks and produces more portable output on Windows.

For reference, `TarFile.ExtractToDirectory` validates both the entry path and link target path against the destination directory boundary. If either resolves outside, an `IOException` is thrown. `TarEntry.ExtractToFile()` rejects symbolic and hard link entries entirely—it throws `InvalidOperationException`.

### Complete safe extraction examples

Combine path traversal validation, size limits, entry count limits, and link handling in a single extraction loop.

#### ZIP—complete safe extraction

The following method extracts a ZIP archive while enforcing all recommended safety checks:

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="SafeExtractZip":::

#### TAR—complete safe extraction

TAR extraction differs from ZIP in several ways: entries are read sequentially (there's no central directory), link entries need explicit handling, and the `DataStream` must be consumed before advancing to the next entry.

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="SafeExtractTar":::

## Memory and performance considerations

### ZipArchiveMode.Update loads entries into memory

Don't use `ZipArchiveMode.Update` for large or untrusted archives. When you open a `ZipArchive` in `Update` mode and call `Open()` or `OpenAsync()` on an entry, its uncompressed data is loaded into a `MemoryStream` to support in-place modifications. Accessing entry metadata (such as `FullName`, `Length`, or `ExternalAttributes`) does not trigger decompression. For large or malicious archives, opening entry content streams can cause `OutOfMemoryException`.

Additionally, when you open a `ZipArchive` in `Read` mode with an **unseekable** stream (for example, a network stream), the runtime copies the entire stream into a `MemoryStream` up front to enable seeking through the central directory.

```csharp
// Update mode: calling entry.Open() loads the full entry into memory
using var archive = new ZipArchive(stream, ZipArchiveMode.Update);
```

**Recommendation:** Only use `Update` mode for archives you trust and know are small enough to fit in memory. For large archives, create a new archive and selectively copy entries:

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="StreamingApproach":::

### TAR streaming model

`TarReader` reads entries one at a time and doesn't buffer the entire archive. However, for unseekable streams, each entry's `DataStream` is only valid until the next `GetNextEntry()` call. If you need to retain entry data, either copy it immediately or pass `copyContents: true` to `GetNextEntry()`, which copies the entry data into a separate `MemoryStream` that remains valid after advancing:

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="TarStreaming":::

### Thread safety

`ZipArchive`, `TarReader`, and `TarWriter` are not thread-safe. Don't access an instance from multiple threads concurrently. If you need parallel processing, use a separate instance per thread or synchronize access externally.

## Platform considerations

### Unix file permissions

- **ZIP:** Unix permissions are stored in the upper 16 bits of `ExternalAttributes`. When extracting on Unix via `ExtractToDirectory` or `ExtractToFile`, the runtime restores ownership permissions (read/write/execute for user/group/other), subject to the process umask. SetUID, SetGID, and StickyBit are stripped. Permissions are not applied if the upper bits are zero. This happens when the ZIP was created on Windows, because the Windows runtime sets `DefaultFileExternalAttributes` to `0`. On Windows, these attributes are always ignored during extraction.
- **TAR:** The `TarEntry.Mode` property represents `UnixFileMode` and can store all 12 permission bits (read/write/execute for user/group/other, plus SetUID, SetGID, and StickyBit). When extracting on Unix via `ExtractToDirectory` or `ExtractToFile`, the runtime applies only the 9 ownership bits (rwx for user/group/other), subject to the process umask. SetUID, SetGID, and StickyBit are stripped for security.

When processing untrusted archives, validate `TarEntry.Mode` before extracting. An archive could set executable permissions on files that should not be executable.

### Special entry types (TAR)

Block devices, character devices, and FIFOs can only be created on Unix. Extracting these on Windows throws an exception. Elevated privileges are required to create block and character device entries.

### File name sanitization differs by platform

On Windows, when using `ExtractToDirectory`, the runtime replaces control characters and ``"*:<>?|`` with underscores in entry names. On Unix, only null characters are replaced. Archive entries with names like `file:name.txt` are renamed to `file_name.txt` on Windows but extracted as-is on Unix. The per-entry APIs (`Open()`, `ExtractToFile()`) do not perform any name sanitization.

## Data integrity

ZIP entries include a CRC-32 checksum that you can use to verify data hasn't been corrupted or tampered with.

Starting with .NET 11, the runtime validates CRC-32 checksums automatically when reading ZIP entries. When you read an entry's data stream to completion, the runtime compares the computed CRC of the decompressed data against the checksum stored in the archive. If they don't match, an `InvalidDataException` is thrown. .NET 11 also validates CRC-32 checksums in TAR entry headers.

> [!NOTE]
> In prior versions of .NET, no CRC validation was performed on read. The runtime computed CRC values when writing entries (for storage in the archive), but never verified them during extraction. If you're targeting a runtime older than .NET 11, be aware that corrupt or tampered entries are silently accepted.

> [!NOTE]
> CRC-32 isn't a cryptographic hash—it detects accidental corruption but doesn't protect against intentional tampering by a sophisticated attacker.

## Untrusted metadata

### ZIP comments and extra fields

- **Archive and entry comments** are arbitrary strings. If your application displays or processes comments, sanitize them appropriately.
- **Extra fields** are binary key-value pairs attached to each entry. The runtime preserves unknown extra fields and trailing data when reading and writing archives in `Update` mode and round-trips them as-is. If your application reads or interprets extra fields, validate their contents.
- **Entry name encoding:** when writing, the runtime uses ASCII for entry names that contain only printable characters (32-126) and UTF-8 (with the language encoding flag set) for names that contain other characters. When reading without a custom encoding, entries with the language encoding flag are decoded as UTF-8, and entries without it are also decoded as UTF-8. Use the `entryNameEncoding` parameter on `ZipArchive` to override encoding when needed, but be aware the override affects all entries uniformly.

## Encryption considerations (.NET 11+)

> [!NOTE]
> ZIP encryption support (ZipCrypto and WinZip AES) is new in .NET 11.

.NET 11 adds support for reading and writing encrypted ZIP archives using WinZip-compatible encryption. The `ZipEncryptionMethod` enum specifies the encryption method:

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
// ⚠️ Weak encryption — use only for backward compatibility
archive.CreateEntry("file.txt", "password", ZipEncryptionMethod.ZipCrypto);

// ✅ Prefer AES-256
archive.CreateEntry("file.txt", "password", ZipEncryptionMethod.Aes256);
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

Attempting to open an entry that uses an unsupported encryption method (`ZipEncryptionMethod.Unknown`) throws `NotSupportedException`.

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

## Security checklist

Before deploying code that handles archives from untrusted sources, verify you've addressed each of the following:

- [ ] **Manual iteration:** Don't use `ExtractToDirectory` for untrusted input—iterate entries manually to enforce all limits.
- [ ] **Path traversal:** Validate all destination paths with `Path.GetFullPath()` + `StartsWith()`.
- [ ] **Decompression bombs:** Enforce limits on decompressed size (per-entry and total) and entry count.
- [ ] **Symlink/hardlink attacks (TAR):** Validate link targets resolve within the destination, or skip link entries entirely.
- [ ] **Memory limits:** Avoid `ZipArchiveMode.Update` for large untrusted archives. Avoid `Read` mode with unseekable streams from untrusted sources.
- [ ] **Thread safety:** Don't share `ZipArchive`, `TarReader`, or `TarWriter` instances across threads.
- [ ] **Untrusted metadata:** Treat entry names, comments, and extra fields as untrusted input. Sanitize before display or processing.
- [ ] **Overwrite behavior:** Default to `overwrite: false`.
- [ ] **Resource disposal:** Always dispose `ZipArchive`, `TarReader`, `TarWriter`, and their streams.

## See also

- <xref:System.IO.Compression>
- <xref:System.Formats.Tar>
- <xref:System.IO.Compression.ZipFile>
- <xref:System.Formats.Tar.TarFile>
