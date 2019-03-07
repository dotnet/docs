---
title: "How to: Compress and extract files"
ms.date: "01/14/2019"
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

The <xref:System.IO.Compression> namespace contains the following types for compressing and decompressing files and streams. You can also use these types to read and modify the contents of a compressed file.

- <xref:System.IO.Compression.ZipFile>
- <xref:System.IO.Compression.ZipArchive>
- <xref:System.IO.Compression.ZipArchiveEntry>
- <xref:System.IO.Compression.DeflateStream>
- <xref:System.IO.Compression.GZipStream>

The following examples show some of the operations you can perform with compressed files.

## Example 1: Create and extract a .zip file

The following example shows how to create and extract a compressed *.zip* file by using the <xref:System.IO.Compression.ZipFile> class. The example compresses the contents of a folder into a new *.zip* file, and then extracts the zip to a new folder. 

To run the sample, create a *start* folder in your program folder and populate it with files to zip. 

If you get the build error "The name 'ZipFile' does not exist in the current context," add a reference to the `System.IO.Compression.FileSystem` assembly to your project.

[!code-csharp[System.IO.Compression.ZipFile#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.io.compression.zipfile/cs/program1.cs#1)]
[!code-vb[System.IO.Compression.ZipFile#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.compression.zipfile/vb/program1.vb#1)]

## Example 2: Extract specific file extensions

The next example iterates through the contents of an existing *.zip* file and extracts files that have a *.txt* extension. It uses the <xref:System.IO.Compression.ZipArchive> class to access the zip, and the <xref:System.IO.Compression.ZipArchiveEntry> class to inspect the individual entries. The extension method <xref:System.IO.Compression.ZipFileExtensions.ExtractToFile%2A> for the <xref:System.IO.Compression.ZipArchiveEntry> object is available in the <xref:System.IO.Compression.ZipFileExtensions?displayProperty=nameWithType> class. 

To run the sample, place a *.zip* file called *result.zip* in your program folder. When prompted, provide a folder name to extract to. 

If you get the build error "The name 'ZipFile' does not exist in the current context," add a reference to the `System.IO.Compression.FileSystem` assembly to your project.

If you get the error "The type 'ZipArchive' is defined in an assembly that is not referenced," add a reference to the `System.IO.Compression` assembly to your project. 

> [!IMPORTANT]
> When unzipping files, you must look for malicious file paths, which can escape out of the directory you unzip into. This is known as a path traversal attack. The following example demonstrates how to check for malicious file paths and provides a safe way to unzip.

[!code-csharp[System.IO.Compression.ZipArchive#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.io.compression.ziparchive/cs/program1.cs#1)]
[!code-vb[System.IO.Compression.ZipArchive#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.compression.ziparchive/vb/program1.vb#1)]

## Example 3: Add a file to an existing zip

The following example uses the <xref:System.IO.Compression.ZipArchive> class to access an existing *.zip* file, and adds a file to it. The new file gets compressed when you add it to the existing zip.

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
- [File and stream I/O](../../../docs/standard/io/index.md)
