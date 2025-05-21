---
title: ".NET 7 breaking change: Time fields on symbolic links"
description: Learn about the .NET 7 breaking change in core .NET libraries where updating CreationTime[Utc], LastAccessTime[Utc], and LastWriteTime[Utc] on a symbolic link no longer affects the target.
ms.date: 10/04/2022
ms.topic: how-to
---
# Time fields on symbolic links

When changes are made to the following time-related fields on a symbolic link ("symlink"), the updates now affect the symlink itself and not the target:

- <xref:System.IO.FileSystemInfo.CreationTime>
- <xref:System.IO.FileSystemInfo.CreationTimeUtc>
- <xref:System.IO.FileSystemInfo.LastAccessTime>
- <xref:System.IO.FileSystemInfo.LastAccessTimeUtc>
- <xref:System.IO.FileSystemInfo.LastWriteTime>
- <xref:System.IO.FileSystemInfo.LastWriteTimeUtc>

## Previous behavior

Previously, updating any of the time-related fields on a symlink affected the fields of the symlink's target.

Consider the following program that prints the various time field values on a file and its symbolic link, updates the symlink's time field values to 1 day later, and then reprints the time field values on both the file and symlink.

```csharp
string filename = "file";
string linkname = "link";

// Create a file and symlink.
File.Create(filename).Dispose();
File.CreateSymbolicLink(linkname, filename);

Console.WriteLine("Before update:");
PrintMetadata(filename);
PrintMetadata(linkname);

UpdateMetadata(linkname);

Console.WriteLine("\nAfter update:");
PrintMetadata(filename);
PrintMetadata(linkname);

static void UpdateMetadata(string filename)
{
    DateTime tomorrow = DateTime.Now.AddDays(1);
    
    File.SetCreationTime(filename, tomorrow);
    File.SetLastAccessTime(filename, tomorrow);
    File.SetLastWriteTime(filename, tomorrow);
    File.SetAttributes(filename, File.GetAttributes(filename) | FileAttributes.Offline);
}

static void PrintMetadata(string filename)
{
    Console.WriteLine($"---{filename}---");
    Console.WriteLine("Creation:\t" + File.GetCreationTime(filename));
    Console.WriteLine("Last access:\t" + File.GetLastAccessTime(filename));
    Console.WriteLine("Last write:\t" + File.GetLastWriteTime(filename));
    Console.WriteLine("Attributes:\t" + File.GetAttributes(filename));
}
```

Previously, after updating the values on the symlink, only the target file's time fields were updated. The output of the preceding program was as follows:

```output
Before update:
---file---
Creation:       9/29/2022 10:35:40 AM
Last access:    9/29/2022 10:35:40 AM
Last write:     9/29/2022 10:35:40 AM
Attributes:     Archive
---link---
Creation:       9/29/2022 10:35:40 AM
Last access:    9/29/2022 10:35:40 AM
Last write:     9/29/2022 10:35:40 AM
Attributes:     Archive, ReparsePoint

After update:
---file---
Creation:       9/30/2022 10:35:40 AM
Last access:    9/30/2022 10:35:40 AM
Last write:     9/30/2022 10:35:40 AM
Attributes:     Archive
---link---
Creation:       9/29/2022 10:35:40 AM
Last access:    9/29/2022 10:35:40 AM
Last write:     9/29/2022 10:35:40 AM
Attributes:     Archive, ReparsePoint, Offline
```

## New behavior

Starting in .NET 7, updating any of the time-related fields on a symlink affects the fields of the symlink itself and not the target file.

The output of the program shown in the [Previous behavior](#previous-behavior) section is as follows:

```output
Before update:
---file---
Creation:       9/29/2022 10:33:39 AM
Last access:    9/29/2022 10:33:39 AM
Last write:     9/29/2022 10:33:39 AM
Attributes:     Archive
---link---
Creation:       9/29/2022 10:33:39 AM
Last access:    9/29/2022 10:33:39 AM
Last write:     9/29/2022 10:33:39 AM
Attributes:     Archive, ReparsePoint

After update:
---file---
Creation:       9/29/2022 10:33:39 AM
Last access:    9/29/2022 10:33:39 AM
Last write:     9/29/2022 10:33:39 AM
Attributes:     Archive
---link---
Creation:       9/30/2022 10:33:39 AM
Last access:    9/30/2022 10:33:39 AM
Last write:     9/30/2022 10:33:39 AM
Attributes:     Archive, ReparsePoint, Offline
```

## Version introduced

.NET 7 Preview 1

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The previous behavior was unexpected and undesirable in some cases:

- It was inconsistent with the behavior of the properties and methods that get the same fields.
- It was also impossible to actually update the fields in the symlink itself using .NET APIs.

## Recommended action

If you were relying on this behavior to set values on the symlink's target, setting one of the `*Time` fields in a symlink will no longer affect the target. You can use the new symbolic link APIs to obtain the target of a symlink and then update that file system object instead.

```csharp
FileSystemInfo? targetInfo = linkInfo.ResolveLinkTarget(returnFinalTarget: true);
if (targetInfo  != null)
{
    // Update the properties accordingly.
    targetInfo.LastWriteTime = DateTime.Now;
}
```

## Affected APIs

- <xref:System.IO.Directory.SetCreationTime(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.Directory.SetCreationTimeUtc(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.Directory.SetLastAccessTime(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.Directory.SetLastAccessTimeUtc(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.Directory.SetLastWriteTime(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.Directory.SetLastWriteTimeUtc(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.File.SetCreationTime(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.File.SetCreationTimeUtc(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.File.SetLastAccessTime(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.File.SetLastAccessTimeUtc(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.File.SetLastWriteTime(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.File.SetLastWriteTimeUtc(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.FileSystemInfo.CreationTime?displayProperty=fullName>
- <xref:System.IO.FileSystemInfo.CreationTimeUtc?displayProperty=fullName>
- <xref:System.IO.FileSystemInfo.LastAccessTime?displayProperty=fullName>
- <xref:System.IO.FileSystemInfo.LastAccessTimeUtc?displayProperty=fullName>
- <xref:System.IO.FileSystemInfo.LastWriteTime?displayProperty=fullName>
- <xref:System.IO.FileSystemInfo.LastWriteTimeUtc?displayProperty=fullName>
