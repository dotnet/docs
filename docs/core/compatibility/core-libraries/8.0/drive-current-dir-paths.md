---
title: "Breaking change: Drive's current directory path enumeration"
description: Learn about the .NET 8 breaking change in core .NET libraries where files are enumerated without a separator after the path when the path is the drive's current directory.
ms.date: 02/09/2024
ms.topic: concept-article
---
# Drive's current directory path enumeration

File system entries obtained using a path argument in the shape of a "drive's current directory", for example, `C:`, were incorrectly formed by combining `directory path + separator + entry name`. To return the correct path for the entries, the separator is no longer added with such paths.

## Previous behavior

Previously, a separator character was added such that the enumerated file system entries appeared to be in the drive's root.

```csharp
string pathToEnumerate = "C:";

Console.WriteLine($"Full path of \"{pathToEnumerate}\" is {Path.GetFullPath(pathToEnumerate)}.");
Path.GetFullPath(pathToEnumerate);

Console.WriteLine($"Enumerating files and folders in \"{pathToEnumerate}\".");
foreach (string entry in Directory.GetFileSystemEntries(pathToEnumerate))
{
    Console.WriteLine(entry);
}
```

The output from running this code snippet was as follows.

```output
Full path of "C:" is C:\Users\myalias\consoleapps\Program

Enumerating files and folders in "C:".
C:\Program.csproj
C:\Program.sln
C:\bin
C:\obj
C:\Program.cs
```

## New behavior

Running the same code snippet in .NET 8 and later versions produces output without a separator character in each path.

```output
Full path of "C:" is C:\Users\myalias\consoleapps\Program.

Enumerating files and folders in "C:".
C:Program.csproj
C:Program.sln
C:bin
C:obj
C:Program.cs
```

## Version introduced

.NET 8

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Users reported that the previous behavior was incorrect. It was also a regression from .NET Framework.

## Recommended action

If you're a Windows user who relies on enumeration of paths like `C:`, you should re-evaluate your application's I/O operations. This is an unusual scenario that's unlikely to be used in production. Most users who want to enumerate the current directory use <xref:System.Environment.CurrentDirectory?displayProperty=nameWithType> instead.

## Affected APIs

- <xref:System.IO.Directory.EnumerateFiles%2A?displayProperty=fullName>
- <xref:System.IO.Directory.EnumerateDirectories%2A?displayProperty=fullName>
- <xref:System.IO.Directory.EnumerateFileSystemEntries%2A?displayProperty=fullName>
- <xref:System.IO.Directory.GetFiles%2A?displayProperty=fullName>
- <xref:System.IO.Directory.GetDirectories%2A?displayProperty=fullName>
- <xref:System.IO.Directory.GetFileSystemEntries%2A?displayProperty=fullName>
- <xref:System.IO.DirectoryInfo.EnumerateFiles%2A?displayProperty=fullName>
- <xref:System.IO.DirectoryInfo.EnumerateDirectories%2A?displayProperty=fullName>
- <xref:System.IO.DirectoryInfo.EnumerateFileSystemInfos%2A?displayProperty=fullName>
- <xref:System.IO.DirectoryInfo.GetFiles%2A?displayProperty=fullName>
- <xref:System.IO.DirectoryInfo.GetDirectories%2A?displayProperty=fullName>
- <xref:System.IO.DirectoryInfo.GetFileSystemInfos%2A?displayProperty=fullName>
- <xref:System.IO.Enumeration.FileSystemEnumerable%601.%23ctor(System.String,System.IO.Enumeration.FileSystemEnumerable{%600}.FindTransform,System.IO.EnumerationOptions)>
