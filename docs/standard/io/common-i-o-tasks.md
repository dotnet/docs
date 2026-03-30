---
title: "Common I/O Tasks"
description: Learn how to do common file tasks & common directory tasks using classes & methods in the System.IO namespace in .NET.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "I/O, common tasks"
---
# Common I/O Tasks

The <xref:System.IO> namespace provides several classes that allow for various actions, such as reading and writing, to be performed on files, directories, and streams. For more information, see [File and Stream I/O](index.md).

## Common File Tasks

|To do this...|See the example in this topic...|
|-------------------|--------------------------------------|
|Create a text file|<xref:System.IO.File.CreateText*?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.FileInfo.CreateText*?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.File.Create*?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.FileInfo.Create*?displayProperty=nameWithType> method|
|Write to a text file|[How to: Write Text to a File](how-to-write-text-to-a-file.md)<br /><br /> [How to: Write a Text File (C++/CLI)](/cpp/dotnet/how-to-write-a-text-file-cpp-cli)|
|Read from a text file|[How to: Read Text from a File](how-to-read-text-from-a-file.md)|
|Append text to a file|[How to: Open and Append to a Log File](how-to-open-and-append-to-a-log-file.md)<br /><br /> <xref:System.IO.File.AppendText*?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.FileInfo.AppendText*?displayProperty=nameWithType> method|
|Rename or move a file|<xref:System.IO.File.Move*?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.FileInfo.MoveTo*?displayProperty=nameWithType> method|
|Delete a file|<xref:System.IO.File.Delete*?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.FileInfo.Delete*?displayProperty=nameWithType> method|
|Copy a file|<xref:System.IO.File.Copy*?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.FileInfo.CopyTo*?displayProperty=nameWithType> method|
|Get the size of a file|<xref:System.IO.FileInfo.Length?displayProperty=nameWithType> property|
|Get the attributes of a file|<xref:System.IO.File.GetAttributes*?displayProperty=nameWithType> method|
|Set the attributes of a file|<xref:System.IO.File.SetAttributes*?displayProperty=nameWithType> method|
|Determine whether a file exists|<xref:System.IO.File.Exists*?displayProperty=nameWithType> method|
|Read from a binary file|[How to: Read and Write to a Newly Created Data File](how-to-read-and-write-to-a-newly-created-data-file.md)|
|Write to a binary file|[How to: Read and Write to a Newly Created Data File](how-to-read-and-write-to-a-newly-created-data-file.md)|
|Retrieve a file name extension|<xref:System.IO.Path.GetExtension*?displayProperty=nameWithType> method|
|Retrieve the fully qualified path of a file|<xref:System.IO.Path.GetFullPath*?displayProperty=nameWithType> method|
|Retrieve the file name and extension from a path|<xref:System.IO.Path.GetFileName*?displayProperty=nameWithType> method|
|Change the extension of a file|<xref:System.IO.Path.ChangeExtension*?displayProperty=nameWithType> method|

## Common Directory Tasks

|To do this...|See the example in this topic...|
|-------------------|--------------------------------------|
|Access a file in a special folder such as My Documents|[How to: Write Text to a File](how-to-write-text-to-a-file.md)|
|Create a directory|<xref:System.IO.Directory.CreateDirectory*?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.FileInfo.Directory?displayProperty=nameWithType> property|
|Create a subdirectory|<xref:System.IO.DirectoryInfo.CreateSubdirectory*?displayProperty=nameWithType> method|
|Rename or move a directory|<xref:System.IO.Directory.Move*?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.DirectoryInfo.MoveTo*?displayProperty=nameWithType> method|
|Copy a directory|[How to: Copy Directories](how-to-copy-directories.md)|
|Delete a directory|<xref:System.IO.Directory.Delete*?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.DirectoryInfo.Delete*?displayProperty=nameWithType> method|
|See the files and subdirectories in a directory|[How to: Enumerate Directories and Files](how-to-enumerate-directories-and-files.md)|
|Find the size of a directory|<xref:System.IO.Directory?displayProperty=nameWithType> class|
|Determine whether a directory exists|<xref:System.IO.Directory.Exists*?displayProperty=nameWithType> method|

## See also

- [File and Stream I/O](index.md)
- [Composing Streams](composing-streams.md)
- [Asynchronous File I/O](asynchronous-file-i-o.md)
