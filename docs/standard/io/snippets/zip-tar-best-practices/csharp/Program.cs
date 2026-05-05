using System.Formats.Tar;
using System.IO.Compression;
// <SafeExtractEntry>
void SafeExtractEntry(ZipArchiveEntry entry, string destinationPath, long maxDecompressedSize)
{
    // The runtime enforces that entry.Open() will never produce more than
    // entry.Length bytes, so checking the declared size is sufficient.
    if (entry.Length > maxDecompressedSize)
    {
        throw new InvalidOperationException(
            $"Entry '{entry.FullName}' declares size {entry.Length}, exceeding limit {maxDecompressedSize}.");
    }

    entry.ExtractToFile(destinationPath, overwrite: false);
}
// </SafeExtractEntry>

// <SafeExtractArchive>
void SafeExtractArchive(ZipArchive archive, string destinationDir,
    long maxTotalSize, int maxEntryCount)
{
    // Flat zip bombs can contain many entries that each expand to large sizes.
    // Reject the archive early if the entry count exceeds your limit.
    if (archive.Entries.Count > maxEntryCount)
    {
        throw new InvalidOperationException("Archive contains an excessive number of entries.");
    }

    long totalExtracted = 0;
    foreach (ZipArchiveEntry entry in archive.Entries)
    {
        totalExtracted = checked(totalExtracted + entry.Length);
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
        string destPath = Path.GetFullPath(Path.Join(fullDestDir, entry.FullName));

        if (!destPath.StartsWith(fullDestDir, StringComparison.Ordinal))
            throw new IOException(
                $"Entry '{entry.FullName}' would extract outside the destination directory.");
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
        entry.ExtractToFile(destinationPath, overwrite: true); // Might write outside of `extractDir`
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
        // Enforce per-entry and cumulative size limits using the declared uncompressed size.
        totalSize += entry.Length;
        if (entry.Length > maxEntrySize)
            throw new InvalidOperationException(
                $"Entry '{entry.FullName}' exceeds per-entry size limit.");
        if (totalSize > maxTotalSize)
            throw new InvalidOperationException("Archive exceeds total size limit.");

        // Resolve the full destination path using Path.GetFullPath, which
        // normalizes away any "../" segments. Then verify the result still
        // starts with the destination directory.
        string destPath = Path.GetFullPath(Path.Join(fullDestDir, entry.FullName));
        if (!destPath.StartsWith(fullDestDir, StringComparison.Ordinal))
            throw new IOException(
                $"Entry '{entry.FullName}' would extract outside the destination.");

        // By convention, directory entries in ZIP archives have names ending
        // in '/'. Path.GetFileName returns empty for these, so we use that
        // to distinguish directories from files.
        if (string.IsNullOrEmpty(Path.GetFileName(destPath)))
        {
            Directory.CreateDirectory(destPath);
        }
        else
        {
            // Create the parent directory and any missing intermediate directories.
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

        // Allow-list of entry types to process. Any type not listed here is
        // silently skipped. We exclude symlinks, hard links (which can
        // escape the destination), and metadata types
        // (GlobalExtendedAttributes, ExtendedAttributes, LongLink, and
        // LongPath) that contain no file data.
        TarEntryType[] allowedTypes =
        [
            TarEntryType.RegularFile,
            TarEntryType.V7RegularFile,
            TarEntryType.ContiguousFile,
            TarEntryType.Directory
        ];

        if (!allowedTypes.Contains(entry.EntryType))
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
        else
        {
            // Create the parent directory and any missing intermediate directories.
            Directory.CreateDirectory(Path.GetDirectoryName(destPath)!);
            entry.ExtractToFile(destPath, overwrite: false);
        }
    }
}
// </SafeExtractTar>

// <ValidateSymlink>
bool IsLinkTargetSafe(TarEntry entry, string fullDestDir)
{
    // A symlink with an absolute (rooted) target is resolved from the filesystem root, not from the extraction directory.
    if (Path.IsPathRooted(entry.LinkName))
        return false;

    if (!fullDestDir.EndsWith(Path.DirectorySeparatorChar))
        fullDestDir += Path.DirectorySeparatorChar;

    string resolvedTarget;

    if (entry.EntryType is TarEntryType.SymbolicLink)
    {
        // Symlink targets are relative to the symlink's own parent directory, or absolute.
        string entryDir = Path.GetDirectoryName(
            Path.GetFullPath(Path.Join(fullDestDir, entry.Name)))!;
        resolvedTarget = Path.GetFullPath(Path.Join(entryDir, entry.LinkName));
    }
    else
    {
        // Hard link targets are relative to the destination directory root.
        resolvedTarget = Path.GetFullPath(Path.Join(fullDestDir, entry.LinkName));
    }

    return resolvedTarget.StartsWith(fullDestDir, StringComparison.Ordinal);
}
// </ValidateSymlink>

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
void TarStreamingRead(Stream archiveStream, string destDir)
{
    using var reader = new TarReader(archiveStream);
    TarEntry? entry;
    while ((entry = reader.GetNextEntry()) is not null)
    {
        // DataStream is only valid until the next GetNextEntry() call,
        // so consume or copy the data before advancing.
        if (entry.DataStream is not null)
        {
            string destPath = Path.Join(destDir, entry.Name);
            using var fileStream = File.Create(destPath);
            entry.DataStream.CopyTo(fileStream);
        }
    }

    // Alternatively, pass copyContents: true to retain entry data
    // in a separate MemoryStream that remains valid after advancing:
    // entry = reader.GetNextEntry(copyContents: true);
}
// </TarStreaming>
