using System.Formats.Tar;
using System.IO.Compression;
// <SafeExtractEntry>
void SafeExtractEntry(ZipArchiveEntry entry, string destinationPath, long maxDecompressedSize)
{
    // Check the declared uncompressed size first (can be spoofed, but is a fast first check).
    if (entry.Length > maxDecompressedSize)
    {
        throw new InvalidOperationException(
            $"Entry '{entry.FullName}' declares size {entry.Length}, exceeding limit {maxDecompressedSize}.");
    }

    using Stream source = entry.Open();
    using FileStream destination = File.Create(destinationPath);

    byte[] buffer = new byte[81920];
    long totalBytesRead = 0;
    int bytesRead;

    while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
    {
        totalBytesRead += bytesRead;
        if (totalBytesRead > maxDecompressedSize)
        {
            throw new InvalidOperationException(
                $"Extraction of '{entry.FullName}' exceeded limit of {maxDecompressedSize} bytes.");
        }
        destination.Write(buffer, 0, bytesRead);
    }
}
// </SafeExtractEntry>

// <SafeExtractArchive>
void SafeExtractArchive(ZipArchive archive, string destinationDir,
    long maxTotalSize, int maxEntryCount)
{
    // Some zip bombs contain millions of tiny entries (e.g., "42.zip").
    if (archive.Entries.Count > maxEntryCount)
    {
        throw new InvalidOperationException("Archive contains an excessive number of entries.");
    }

    long totalExtracted = 0;
    foreach (ZipArchiveEntry entry in archive.Entries)
    {
        totalExtracted += entry.Length;
        if (totalExtracted > maxTotalSize)
        {
            throw new InvalidOperationException(
                $"Archive total decompressed size exceeds the allowed limit of {maxTotalSize} bytes.");
        }
        // ... extract each entry with per-entry limits too
    }
}
// </SafeExtractArchive>

// <PathValidation>
void ValidatePaths(ZipArchive archive, string destinationDir)
{
    string fullDestDir = Path.GetFullPath(destinationDir);
    if (!fullDestDir.EndsWith(Path.DirectorySeparatorChar))
        fullDestDir += Path.DirectorySeparatorChar;

    foreach (ZipArchiveEntry entry in archive.Entries)
    {
        string destPath = Path.GetFullPath(Path.Combine(fullDestDir, entry.FullName));

        if (!destPath.StartsWith(fullDestDir, StringComparison.Ordinal))
            throw new IOException(
                $"Entry '{entry.FullName}' would extract outside the destination directory.");

        // ... safe to extract
    }
}
// </PathValidation>

// <VulnerablePattern>
void DangerousExtract(string extractDir)
{
    // ⚠️ DANGEROUS: entry.FullName could contain "../" sequences
    using ZipArchive archive = ZipFile.OpenRead("archive.zip");
    foreach (ZipArchiveEntry entry in archive.Entries)
    {
        string destinationPath = Path.Combine(extractDir, entry.FullName);
        entry.ExtractToFile(destinationPath, overwrite: true); // NO path validation!
    }
}
// </VulnerablePattern>

// <SafeExtractZip>
void SafeExtractZip(string archivePath, string destinationDir,
    long maxTotalSize, long maxEntrySize, int maxEntryCount)
{
    // Resolve the destination to an absolute path and ensure it ends with a
    // directory separator. This trailing separator is essential — without it,
    // the StartsWith check below could be tricked by paths like
    // "/safe-dir-evil/" matching "/safe-dir".
    string fullDestDir = Path.GetFullPath(destinationDir);
    if (!fullDestDir.EndsWith(Path.DirectorySeparatorChar))
        fullDestDir += Path.DirectorySeparatorChar;

    Directory.CreateDirectory(fullDestDir);

    using var archive = new ZipArchive(File.OpenRead(archivePath), ZipArchiveMode.Read);

    // Check the entry count up front. ZIP central directory is read eagerly,
    // so archive.Entries.Count is available immediately without iterating.
    if (archive.Entries.Count > maxEntryCount)
        throw new InvalidOperationException("Archive contains too many entries.");

    long totalSize = 0;
    foreach (ZipArchiveEntry entry in archive.Entries)
    {
        // Enforce per-entry and cumulative size limits using the declared
        // uncompressed size. Note: this value is read from the archive header
        // and could be spoofed by a malicious archive — for defense in depth,
        // also monitor actual bytes read during decompression (see the zip
        // bomb section for a streaming size check example).
        totalSize += entry.Length;
        if (entry.Length > maxEntrySize)
            throw new InvalidOperationException(
                $"Entry '{entry.FullName}' exceeds per-entry size limit.");
        if (totalSize > maxTotalSize)
            throw new InvalidOperationException("Archive exceeds total size limit.");

        // Resolve the full destination path using Path.GetFullPath, which
        // normalizes away any "../" segments. Then verify the result still
        // starts with the destination directory.
        string destPath = Path.GetFullPath(Path.Combine(fullDestDir, entry.FullName));
        if (!destPath.StartsWith(fullDestDir, StringComparison.Ordinal))
            throw new IOException(
                $"Entry '{entry.FullName}' would extract outside the destination.");

        // ZIP uses a convention where directory entries have names ending in '/'.
        // Path.GetFileName returns empty for these, so we use that to
        // distinguish directories from files.
        if (string.IsNullOrEmpty(Path.GetFileName(destPath)))
        {
            Directory.CreateDirectory(destPath);
        }
        else
        {
            // Ensure the parent directory exists before extracting the file.
            Directory.CreateDirectory(Path.GetDirectoryName(destPath)!);
            entry.ExtractToFile(destPath, overwrite: false);
        }
    }
}
// </SafeExtractZip>

// <SafeExtractTar>
void SafeExtractTar(Stream archiveStream, string destinationDir,
    long maxTotalSize, long maxEntrySize, int maxEntryCount)
{
    // Same trailing-separator technique as the ZIP example.
    string fullDestDir = Path.GetFullPath(destinationDir);
    if (!fullDestDir.EndsWith(Path.DirectorySeparatorChar))
        fullDestDir += Path.DirectorySeparatorChar;

    Directory.CreateDirectory(fullDestDir);

    using var reader = new TarReader(archiveStream);
    TarEntry? entry;
    long totalSize = 0;
    int entryCount = 0;

    // TAR has no central directory — entries are read one at a time.
    // GetNextEntry() returns null when the archive is exhausted.
    while ((entry = reader.GetNextEntry()) is not null)
    {
        if (++entryCount > maxEntryCount)
            throw new InvalidOperationException("Archive contains too many entries.");

        if (entry.Length > maxEntrySize)
            throw new InvalidOperationException(
                $"Entry '{entry.Name}' exceeds per-entry size limit.");
        totalSize += entry.Length;
        if (totalSize > maxTotalSize)
            throw new InvalidOperationException("Archive exceeds total size limit.");

        // Symbolic links and hard links can be used to write files outside the
        // extraction directory or to overwrite sensitive files. The safest
        // approach for untrusted input is to skip them entirely.
        if (entry.EntryType is TarEntryType.SymbolicLink or TarEntryType.HardLink)
            continue;

        // Global extended attributes are PAX metadata entries that apply to all
        // subsequent entries. They contain no file data and should be skipped.
        if (entry.EntryType is TarEntryType.GlobalExtendedAttributes)
            continue;

        // Normalize and validate the path, same as the ZIP example.
        string destPath = Path.GetFullPath(Path.Join(fullDestDir, entry.Name));
        if (!destPath.StartsWith(fullDestDir, StringComparison.Ordinal))
            throw new IOException(
                $"Entry '{entry.Name}' would extract outside the destination.");

        if (entry.EntryType is TarEntryType.Directory)
        {
            Directory.CreateDirectory(destPath);
        }
        else if (entry.DataStream is not null)
        {
            // For file entries, copy the data stream to a new file.
            // We use entry.DataStream directly instead of ExtractToFile because
            // ExtractToFile rejects symbolic and hard link entries (already
            // filtered above) and requires a file path rather than a stream.
            Directory.CreateDirectory(Path.GetDirectoryName(destPath)!);
            using var fileStream = File.Create(destPath);
            entry.DataStream.CopyTo(fileStream);
        }
    }
}
// </SafeExtractTar>

// <StreamingApproach>
void StreamingModify()
{
    // ✅ Streaming approach for large archives
    using var input = new ZipArchive(File.OpenRead("large.zip"), ZipArchiveMode.Read);
    using var output = new ZipArchive(File.Create("modified.zip"), ZipArchiveMode.Create);

    foreach (var entry in input.Entries)
    {
        if (ShouldKeep(entry))
        {
            var newEntry = output.CreateEntry(entry.FullName);
            using var src = entry.Open();
            using var dst = newEntry.Open();
            src.CopyTo(dst);
        }
    }
}

bool ShouldKeep(ZipArchiveEntry entry) => true;
// </StreamingApproach>

// <TarStreaming>
void TarStreamingRead(Stream archiveStream)
{
    using var reader = new TarReader(archiveStream);
    TarEntry? entry;
    while ((entry = reader.GetNextEntry()) is not null)
    {
        if (entry.DataStream is not null)
        {
            string safePath = "output.bin";
            // Copy now — the stream becomes invalid after the next GetNextEntry() call
            using var fileStream = File.Create(safePath);
            entry.DataStream.CopyTo(fileStream);
        }
    }
}
// </TarStreaming>
