---
title: "How to: Compress and extract files"
description: Compress & extract files using System.IO.Compression. See examples using ZipFile, ZipArchive, ZipArchiveEntry, DeflateStream, & GZipStream.
ms.date: "08/10/2022"
ms.custom: devdivchpfy22
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "I/O [.NET], compression"
  - "compression"
  - "compress files"
ms.assetid: e9876165-3c60-4c84-a272-513e47acf579
---
# How to: Compress and extract files

The <xref:System.IO.Compression> namespace contains the following classes for compressing and decompressing files and streams. You also can use these types to read and modify the contents of a compressed file:

- <xref:System.IO.Compression.ZipFile>
- <xref:System.IO.Compression.ZipArchive>
- <xref:System.IO.Compression.ZipArchiveEntry>
- <xref:System.IO.Compression.DeflateStream>
- <xref:System.IO.Compression.GZipStream>

The following examples show some of the operations you can perform with compressed files. These examples require the following NuGet packages to be added to your project:

- [System.IO.Compression](https://www.nuget.org/packages/System.IO.Compression)
- [System.IO.Compression.ZipFile](https://www.nuget.org/packages/System.IO.Compression.ZipFile)

If you're using .NET Framework, add references to these two libraries to your project:

- `System.IO.Compression`
- `System.IO.Compression.FileSystem`

## Example 1: Create and extract a .zip file

The following example shows how to create and extract a compressed *.zip* file by using the <xref:System.IO.Compression.ZipFile> class. The example compresses the contents of a folder into a new *.zip* file, and then extracts the file to a new folder.

To run the sample, create a *start* folder in your program folder and populate it with files to zip.

[!code-csharp[System.IO.Compression.ZipFile#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.io.compression.zipfile/cs/program1.cs#1)]
[!code-vb[System.IO.Compression.ZipFile#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.compression.zipfile/vb/program1.vb#1)]

## Example 2: Extract specific file extensions

The following example iterates through the contents of an existing *.zip* file and extracts files with a *.txt* extension. It uses the <xref:System.IO.Compression.ZipArchive> class to access the *.zip* file, and the <xref:System.IO.Compression.ZipArchiveEntry> class to inspect the individual entries. The extension method <xref:System.IO.Compression.ZipFileExtensions.ExtractToFile%2A> for the <xref:System.IO.Compression.ZipArchiveEntry> object is available in the <xref:System.IO.Compression.ZipFileExtensions?displayProperty=nameWithType> class.

To run the sample, place a *.zip* file called *result.zip* in your program folder. When prompted, provide a folder name to extract to.

> [!IMPORTANT]
> When unzipping files, you must look for malicious file paths, which can escape from the directory you unzip into. This is known as a path traversal attack. The following example demonstrates how to check for malicious file paths and provides a safe way to unzip.

[!code-csharp[System.IO.Compression.ZipArchive#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.io.compression.ziparchive/cs/program1.cs#1)]
[!code-vb[System.IO.Compression.ZipArchive#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.compression.ziparchive/vb/program1.vb#1)]

## Example 3: Add a file to an existing .zip file

The following example uses the <xref:System.IO.Compression.ZipArchive> class to access an existing *.zip* file, and adds a file to it. The new file gets compressed when you add it to the existing *.zip* file.

[!code-csharp[System.IO.Compression.ZipArchiveMode#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.io.compression.ziparchivemode/cs/program1.cs#1)]
[!code-vb[System.IO.Compression.ZipArchiveMode#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.compression.ziparchivemode/vb/program1.vb#1)]

## Example 4: Compress and decompress .gz files

You can also use the <xref:System.IO.Compression.GZipStream> and <xref:System.IO.Compression.DeflateStream> classes to compress and decompress data. They use the same compression algorithm. You can decompress <xref:System.IO.Compression.GZipStream> objects that are written to a *.gz* file by using many common tools. The following example shows how to compress and decompress a directory of files by using the <xref:System.IO.Compression.GZipStream> class:

[!code-csharp[IO.Compression.GZip1#1](../../../samples/snippets/csharp/VS_Snippets_CLR/IO.Compression.GZip1/CS/gziptest.cs#1)]
[!code-vb[IO.Compression.GZip1#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/IO.Compression.GZip1/VB/gziptest.vb#1)]

## See also

- <xref:System.IO.Compression.ZipArchive>  
- <xref:System.IO.Compression.ZipFile>  
- <xref:System.IO.Compression.ZipArchiveEntry>  
- <xref:System.IO.Compression.DeflateStream>  
- <xref:System.IO.Compression.GZipStream>  
- [File and stream I/O](index.md)
