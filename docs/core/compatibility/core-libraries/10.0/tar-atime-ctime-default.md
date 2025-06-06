---
title: "Breaking change: GnuTarEntry and PaxTarEntry no longer includes atime and ctime by default"
description: "Learn about the breaking change in .NET 10 where GnuTarEntry and PaxTarEntry no longer automatically set access time and change time fields."
ms.date: 01/30/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/46465
---
# GnuTarEntry and PaxTarEntry no longer includes atime and ctime by default

Starting in .NET 10, <xref:System.Formats.Tar.GnuTarEntry> and <xref:System.Formats.Tar.PaxTarEntry> no longer automatically set access time (`atime`) and change time (`ctime`) fields when creating new entries. These fields are problematic in tar entries because not all tar readers support them.

## Version introduced

.NET 10 Preview 5

## Previous behavior

Previously, `GnuTarEntry` and `PaxTarEntry` always added `atime` and `ctime` values when creating new entries.

## New behavior

Starting in .NET 10, `GnuTarEntry` and `PaxTarEntry` only set `atime` and `ctime` if:

- The entry was read from a tar archive that already contained these fields
- The user explicitly sets them using the appropriate properties

The behavior of <xref:System.Formats.Tar.TarEntry.ModificationTime?displayProperty=nameWithType> remains unchanged. It's initialized to <xref:System.DateTime.UtcNow?displayProperty=nameWithType> for tar entries created with a constructor, and uses the file modification time for entries created from files.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Better compatibility with other tar readers and improved round-tripping of tar files without modification. The `atime` and `ctime` fields create tar files that aren't readable by many tar clients.

## Recommended action

No action required for most users. If you require these fields to be set, you can do so directly:

- For `GnuTarEntry`: Use <xref:System.Formats.Tar.GnuTarEntry.AccessTime?displayProperty=nameWithType> and <xref:System.Formats.Tar.GnuTarEntry.ChangeTime?displayProperty=nameWithType> properties
- For `PaxTarEntry`: Use the constructor that accepts extended attributes: <xref:System.Formats.Tar.PaxTarEntry.%23ctor(System.Formats.Tar.TarEntryType,System.String,System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.String}})?displayProperty=nameWithType>

However, be aware that setting these fields creates a tar file that might not be readable by many tar clients.

## Affected APIs

- <xref:System.Formats.Tar.GnuTarEntry?displayProperty=fullName>
- <xref:System.Formats.Tar.PaxTarEntry?displayProperty=fullName>
- <xref:System.Formats.Tar.TarReader?displayProperty=fullName>
- <xref:System.Formats.Tar.TarWriter?displayProperty=fullName>
