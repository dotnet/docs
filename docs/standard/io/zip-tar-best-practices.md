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

- `ZipFile.ExtractToDirectory` and `TarFile.ExtractToDirectory` handle path validation automatically—they sanitize entry names, resolve paths, and check directory boundaries.
- Default overwrite behavior is `false`. Always be explicit:

```csharp
// ✅ Explicit — default is safe
ZipFile.ExtractToDirectory("archive.zip", destDir, overwriteFiles: false);
TarFile.ExtractToDirectory("archive.tar", destDir, overwriteFiles: false);
```

- When overwriting is enabled during ZIP extraction, .NET extracts to a temporary file first and only replaces the target after successful extraction—this approach prevents partial corruption if the extraction fails.

> [!NOTE]
> The convenience methods don't limit decompressed size or entry count. If that matters even for trusted input (for example, very large archives), use the streaming approach described in [Handle untrusted archives safely](#handle-untrusted-archives-safely).

## Handle untrusted archives safely

For untrusted input—user uploads, third-party downloads, or network transfers—iterate over entries manually and enforce your own safety checks. The following subsections describe what you need to enforce and why.

### What the convenience methods don't protect you from

`ExtractToDirectory` handles path traversal validation, but it doesn't enforce size limits, entry count limits, or filter dangerous TAR entry types. A small compressed file can expand to terabytes of data (known as a *zip bomb*), and TAR archives can contain symbolic links that escape the extraction directory. You must handle these yourself when processing untrusted input.

### Enforce size and entry count limits

Neither `ZipArchive` nor `TarReader` limits the total uncompressed size or the number of entries extracted, and neither do the `ExtractToDirectory` convenience methods. You must enforce these limits yourself.

> [!IMPORTANT]
> A small compressed file can expand to terabytes of data—this is known as a *zip bomb*. Always enforce limits on decompressed size and entry count when extracting untrusted archives.

#### Track decompressed size during extraction

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="SafeExtractEntry":::

#### Track aggregate size and entry count

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="SafeExtractArchive":::

> [!TIP]
> The same approach applies to TAR archives. Since TAR files are read entry-by-entry via `TarReader.GetNextEntry()`, track both the cumulative data size and entry count as you iterate.

### Validate destination paths (low-level APIs only)

When you use the streaming APIs, you're responsible for validating every entry's destination path. The low-level APIs perform no path validation at all.

For every entry, resolve the destination to an absolute path and verify it falls within your target directory:

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="PathValidation":::

Key points:

- `Path.GetFullPath()` resolves relative segments like `../` into an absolute path.
- The `StartsWith` check ensures the resolved path is still inside the destination.
- The trailing directory separator on `fullDestDir` is critical—without it, a path like `/safe-dir-evil/file` would incorrectly match `/safe-dir`.

> [!NOTE]
> `ExtractToDirectory` handles path traversal for you—the runtime sanitizes entry names, resolves paths with `Path.GetFullPath()`, and verifies them with `StartsWith`. You're using the streaming APIs here because of the size-limits issue described above.

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
- **Hard link to sensitive file:** A hard link target references a file outside the extraction directory, allowing reads or overwrites.

The safest approach for untrusted archives is to skip link entries entirely:

```csharp
if (entry.EntryType is TarEntryType.SymbolicLink or TarEntryType.HardLink)
    continue; // Skip link entries for untrusted input
```

If your use case requires hard links but you want to avoid filesystem-level hard links, `TarHardLinkMode.CopyContents` copies the file content instead of creating a real hard link. This approach eliminates hard-link-based attacks and produces more portable output on Windows.

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

Don't use `ZipArchiveMode.Update` for large or untrusted archives. When you open a `ZipArchive` in `Update` mode, each entry's uncompressed data is loaded into a `MemoryStream` when that entry is accessed. The runtime requires a seekable stream for Update mode and decompresses each entry fully into memory to support in-place modifications. For large or malicious archives, this behavior can cause `OutOfMemoryException`.

Additionally, when you open a `ZipArchive` in `Read` mode with an **unseekable** stream (for example, a network stream), the runtime copies the entire stream into a `MemoryStream` up front to enable seeking through the central directory.

```csharp
// ⚠️ In Update mode, each entry is decompressed into memory when accessed
using var archive = new ZipArchive(stream, ZipArchiveMode.Update);
```

**Recommendation:** Only use `Update` mode for archives you trust and know are small enough to fit in memory. For large archives, create a new archive and selectively copy entries:

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="StreamingApproach":::

### TAR streaming model

`TarReader` reads entries one at a time and doesn't buffer the entire archive. However, for unseekable streams, each entry's `DataStream` is only valid until the next `GetNextEntry()` call. If you need to retain entry data, copy it immediately:

:::code language="csharp" source="./snippets/zip-tar-best-practices/csharp/Program.cs" id="TarStreaming":::

### Thread safety

`ZipArchive` isn't thread-safe. The internal state—entry lists, stream positions, and disposal flags—isn't synchronized. Don't read or write entries from multiple threads concurrently. If you need parallel processing, open a separate `ZipArchive` instance per thread, or synchronize access externally.

`TarReader` and `TarWriter` are likewise not designed for concurrent use. Each operates on a single underlying stream with sequential access semantics.

## Platform considerations

### Unix file permissions

- **ZIP:** Unix permissions are stored in the upper 16 bits of `ExternalAttributes`. When extracting on Unix, the runtime restores ownership permissions (read/write/execute for user/group/other), subject to the process umask. Permissions aren't applied if the upper bits are zero—this happens when the ZIP was created on Windows, because the Windows runtime sets `DefaultFileExternalAttributes` to `0`. On Windows, these attributes are always ignored during extraction.
- **TAR:** The `TarEntry.Mode` property represents `UnixFileMode` and can store all 12 permission bits (read/write/execute for user/group/other, plus SetUID, SetGID, and StickyBit). However, during **regular file extraction**, only the 9 ownership bits (rwx for user/group/other) are applied—SetUID, SetGID, and StickyBit are explicitly stripped for security. Directories, block devices, character devices, and FIFOs receive the full `Mode` value including SetUID, SetGID, and StickyBit.

### Special entry types (TAR)

Block devices, character devices, and FIFOs can only be created on Unix. Extracting these on Windows throws an exception. Elevated privileges are required to create block and character device entries.

### File name sanitization differs by platform

On Windows, the runtime replaces control characters and `"*:<>?|` with underscores via `ArchivingUtils.SanitizeEntryFilePath()`. On Unix, only null characters are replaced. Archive entries with names like `file:name.txt` are renamed to `file_name.txt` on Windows but extracted as-is on Unix.

## Data integrity

ZIP entries include a CRC-32 checksum that you can use to verify data hasn't been corrupted or tampered with.

Starting with .NET 11, the runtime validates CRC-32 checksums automatically when reading ZIP entries. When you read an entry's data stream to completion, the runtime compares the computed CRC of the decompressed data against the checksum stored in the archive. If they don't match, an `InvalidDataException` is thrown.

> [!NOTE]
> In prior versions of .NET, no CRC validation was performed on read. The runtime computed CRC values when writing entries (for storage in the archive), but never verified them during extraction. If you're targeting a runtime older than .NET 11, be aware that corrupt or tampered entries are silently accepted.

> [!NOTE]
> CRC-32 isn't a cryptographic hash—it detects accidental corruption but doesn't protect against intentional tampering by a sophisticated attacker.

## Untrusted metadata

### ZIP comments and extra fields

Treat all archive metadata as untrusted input. ZIP archives can contain attacker-controlled metadata beyond entry names:

- **Archive and entry comments** are arbitrary strings encoded using either Code Page 437 or UTF-8 (depending on the language encoding flag). If your application displays or processes comments, sanitize them appropriately.
- **Extra fields** are binary key-value pairs attached to each entry. The runtime preserves unknown extra fields and trailing data when reading and writing archives in `Update` mode—they're round-tripped as-is. If your application reads or interprets extra fields, validate their contents.
- **Entry name encoding** defaults to the system codepage for entries without the language encoding flag (EFS) set, and UTF-8 when EFS is set. The ZIP specification defines Code Page 437 as the default, but in practice, most tools (including the Windows Shell zip tool) use the local system codepage instead, and .NET follows the same behavior. When interoperating with archives from other tools, mismatched encodings can produce garbled file names. Use the `entryNameEncoding` parameter on `ZipArchive` to override encoding when needed, but be aware the override affects all entries uniformly.

### TAR header-driven memory allocation

TAR entry headers contain size fields that the parser uses to allocate buffers. A malicious TAR archive can declare an extremely large size for a PAX extended attributes block or a GNU long-path entry, causing the parser to attempt a large memory allocation. The runtime does include a `ValidateSize()` guard that rejects allocations exceeding `Array.MaxLength` (~2 GB), so allocations aren't completely unbounded—but values up to ~2 GB can still cause significant memory pressure. Your entry-count and per-entry-size limits (described in [Enforce size and entry count limits](#enforce-size-and-entry-count-limits)) also help mitigate this risk, since these metadata entries are counted and sized like regular entries.

## Encryption considerations (preview)

> [!NOTE]
> ZIP encryption support (ZipCrypto and WinZip AES) is a preview feature that isn't yet publicly available. The APIs described in this section are subject to change.

.NET 11 adds support for reading and writing encrypted ZIP archives using WinZip-compatible encryption. The `ZipEncryptionMethod` enum specifies the encryption method:

| Value | Description |
|-------|-------------|
| `None` | No encryption. |
| `ZipCrypto` | Legacy ZIP encryption. Use only for backward compatibility—vulnerable to known-plaintext attacks. |
| `Aes128` | WinZip AES-128. |
| `Aes192` | WinZip AES-192. |
| `Aes256` | WinZip AES-256. **Recommended**—strongest available option. |
| `Unknown` | Returned when the entry uses PKWare strong encryption, which .NET doesn't support. |

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
        // PKWare strong encryption — not supported by .NET
        continue;
    }

    using Stream stream = entry.Open("myPassword");
    // ... read the decrypted data
}
```

Attempting to open an entry that uses PKWare strong encryption (`ZipEncryptionMethod.Unknown`) throws `NotSupportedException`.

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
- [ ] **File name validation:** On Windows, guard against reserved names (`CON`, `PRN`, `AUX`, `NUL`).
- [ ] **Overwrite behavior:** Default to `overwrite: false`.
- [ ] **Resource disposal:** Always dispose `ZipArchive`, `TarReader`, `TarWriter`, and their streams.

## See also

- <xref:System.IO.Compression>
- <xref:System.Formats.Tar>
- <xref:System.IO.Compression.ZipFile>
- <xref:System.Formats.Tar.TarFile>
