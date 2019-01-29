---
title: "How to: Compress and extract files"
ms.date: "06/06/2018"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "I/O [.NET Framework], compression"
  - "compression"
  - "compress files"
ms.assetid: e9876165-3c60-4c84-a272-513e47acf579
author: "mairaw"
ms.author: "mairaw"
---
# How to: Compress and extract files

The <xref:System.IO.Compression> namespace contains the following types for compressing and decompressing files and streams. You can also use these types to read and modify the contents of a compressed file:

- <xref:System.IO.Compression.ZipFile>

- <xref:System.IO.Compression.ZipArchive>

- <xref:System.IO.Compression.ZipArchiveEntry>

- <xref:System.IO.Compression.DeflateStream>

- <xref:System.IO.Compression.GZipStream>

The following examples show some of the functions you can perform when working with compressed files.

## Example 1 - Create and extract a .zip file

The following example shows how to create and extract a compressed file that has a .zip file name extension by using the <xref:System.IO.Compression.ZipFile> class. It compresses the contents of a folder into a new .zip file and then extracts that content to a new folder. To use the <xref:System.IO.Compression.ZipFile> class, you must reference the `System.IO.Compression.FileSystem` assembly in your project.

[!code-csharp[System.IO.Compression.ZipFile#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.io.compression.zipfile/cs/program1.cs#1)]
[!code-vb[System.IO.Compression.ZipFile#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.compression.zipfile/vb/program1.vb#1)]

## Example 2 - Extract specific file extensions

The next example shows how to iterate through the contents of an existing .zip file and extract files that have a .txt extension. It uses the <xref:System.IO.Compression.ZipArchive> class to access an existing .zip file, and the <xref:System.IO.Compression.ZipArchiveEntry> class to inspect the individual entries in the compressed file. It uses an extension method (<xref:System.IO.Compression.ZipFileExtensions.ExtractToFile%2A>) for the <xref:System.IO.Compression.ZipArchiveEntry> object. The extension method is available in the <xref:System.IO.Compression.ZipFileExtensions?displayProperty=nameWithType> class. To use the <xref:System.IO.Compression.ZipFileExtensions> class, you must reference the `System.IO.Compression.FileSystem` assembly in your project.

> [!IMPORTANT]
> When unzipping files, you must look for malicious file paths which can escape out of the directory where you want to unzip into. This is known as a path traversal attack.

The following example demonstrates how to check for malicious file paths and provides a safe way to unzip:

[!code-csharp[System.IO.Compression.ZipArchive#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.io.compression.ziparchive/cs/program1.cs#1)]
[!code-vb[System.IO.Compression.ZipArchive#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.compression.ziparchive/vb/program1.vb#1)]

## Example 3 - Add a new file to an existing .zip file

The following example uses the <xref:System.IO.Compression.ZipArchive> class to access an existing .zip file, and adds a new file to the compressed file. The new file gets compressed when you add it to the existing .zip file.

[!code-csharp[System.IO.Compression.ZipArchiveMode#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.io.compression.ziparchivemode/cs/program1.cs#1)]
[!code-vb[System.IO.Compression.ZipArchiveMode#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.compression.ziparchivemode/vb/program1.vb#1)]

## Example 4 - Compress and decompress a directory of .gz files

You can also use the <xref:System.IO.Compression.GZipStream> and <xref:System.IO.Compression.DeflateStream> classes to compress and decompress data. They use the same compression algorithm. Compressed <xref:System.IO.Compression.GZipStream> objects that are written to a file that has an extension of .gz can be decompressed by using many common tools in addition to the methods provided by <xref:System.IO.Compression.GZipStream>. The following example shows how to compress and decompress a directory of files by using the <xref:System.IO.Compression.GZipStream> class:

[!code-csharp[IO.Compression.GZip1#1](../../../samples/snippets/csharp/VS_Snippets_CLR/IO.Compression.GZip1/CS/gziptest.cs#1)]
[!code-vb[IO.Compression.GZip1#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/IO.Compression.GZip1/VB/gziptest.vb#1)]

## See also

- <xref:System.IO.Compression.ZipArchive>
- <xref:System.IO.Compression.ZipFile>
- <xref:System.IO.Compression.ZipArchiveEntry>
- <xref:System.IO.Compression.DeflateStream>
- <xref:System.IO.Compression.GZipStream>
- [File and Stream I/O](../../../docs/standard/io/index.md)
