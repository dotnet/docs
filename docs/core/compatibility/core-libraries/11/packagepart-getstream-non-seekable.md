---
title: "Breaking change: PackagePart.GetStream() returns a non-seekable stream for compressed parts in ReadWrite packages"
description: "Learn about the breaking change in .NET 11 where PackagePart.GetStream() returns a forward-only stream instead of a seekable MemoryStream for compressed parts of a ReadWrite package."
ms.date: 08/04/2026
ai-usage: ai-assisted
---
# PackagePart.GetStream() returns a non-seekable stream for compressed parts in ReadWrite packages

When you open a <xref:System.IO.Packaging.Package> with <System.IO.FileAccess.ReadWrite?displayProperty=nameWithType> and then open a compressed part for reading that hasn't been modified in the current session, <xref:System.IO.Packaging.PackagePart.GetStream*?displayProperty=nameWithType> now returns a forward-only stream instead of a seekable <xref:System.IO.MemoryStream>.

## Version introduced

.NET 11 Preview 7

## Previous behavior

Previously, when you opened a `Package` with `FileAccess.ReadWrite` (which maps internally to `ZipArchiveMode.Update`), opening a compressed part for reading returned a seekable `MemoryStream` that contained the fully decompressed entry content.

```csharp
using Package package = Package.Open("file.docx", FileMode.Open, FileAccess.ReadWrite);
PackagePart part = package.GetPart(new Uri("/word/document.xml", UriKind.Relative));

// Returned a seekable MemoryStream.
using Stream stream = part.GetStream(FileMode.Open, FileAccess.Read);
Console.WriteLine(stream.CanSeek);   // true
stream.Seek(0, SeekOrigin.Begin);    // succeeded
Console.WriteLine(stream.Position);  // 0
```

## New behavior

Starting in .NET 11, the same call returns a forward-only (non-seekable) stream for compressed parts that haven't been modified in the current session.

```csharp
using Package package = Package.Open("file.docx", FileMode.Open, FileAccess.ReadWrite);
PackagePart part = package.GetPart(new Uri("/word/document.xml", UriKind.Relative));

// Returns a forward-only (non-seekable) stream.
using Stream stream = part.GetStream(FileMode.Open, FileAccess.Read);
Console.WriteLine(stream.CanSeek);   // false
stream.Seek(0, SeekOrigin.Begin);    // throws NotSupportedException
stream.Position = 0;                 // throws NotSupportedException
Console.WriteLine(stream.Length);    // still works (reported from entry metadata)
```

All the following conditions must be true simultaneously for you to observe this change:

- The package is opened with `FileAccess.ReadWrite` (`Package.Open(..., FileAccess.ReadWrite)`).
- The part is opened for reading only (`GetStream(FileMode.Open, FileAccess.Read)`).
- The part is compressed (`CompressionOption` other than `NotCompressed`).
- The part wasn't written or modified earlier in the same session.
- The consumer unconditionally seeks the stream or reads `Position`.

The following scenarios aren't affected:

- Read-only packages (`FileAccess.Read`): Their compressed part streams were already forward-only.
- Uncompressed (`Stored`) parts: They remain seekable.
- Parts modified earlier in the current session: They're served from an in-memory snapshot, so they remain seekable.
- Accessing `Stream.Length`.
- Forward-only consumers (the common case, such as `XmlReader`, `XDocument.Load`, the Open XML SDK, and `CopyTo`).
- Target frameworks earlier than .NET 11: The optimization is gated behind `NET11_0_OR_GREATER`.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Previously, opening a compressed part for reading from a `ReadWrite` package always decompressed the entire entry into a `MemoryStream` before it returned the stream. This approach produced a seekable stream, but it imposed unnecessary memory allocations and CPU overhead for the common case where callers only read the stream sequentially (for example, `XmlReader` or the Open XML SDK). The new behavior streams directly from the underlying ZIP archive entry for forward-only reads, which avoids the up-front decompression.

For more information, see [dotnet/runtime#129698](https://github.com/dotnet/runtime/pull/129698).

## Recommended action

If your code requires a seekable stream from a compressed part of a `ReadWrite` package, copy it into a `MemoryStream` manually:

```csharp
using Stream partStream = part.GetStream(FileMode.Open, FileAccess.Read);
using MemoryStream seekable = new();
partStream.CopyTo(seekable);
seekable.Position = 0;
// Use 'seekable'. It's fully buffered and seekable.
```

Alternatively, if your use case doesn't require `ReadWrite` access to the package, open it with `FileAccess.Read` instead. Read-only packages already returned forward-only streams before this change, so this mode avoids any surprise for seek-sensitive code.

## Affected APIs

- <xref:System.IO.Packaging.PackagePart.GetStream?displayProperty=fullName>
- <xref:System.IO.Packaging.PackagePart.GetStream(System.IO.FileMode)?displayProperty=fullName>
- <xref:System.IO.Packaging.PackagePart.GetStream(System.IO.FileMode,System.IO.FileAccess)?displayProperty=fullName>
