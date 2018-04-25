---
title: "File and Stream I-O"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "IO namespace"
  - "files, I/O"
  - "System.IO namespace"
  - "I/O [.NET Framework]"
  - "streams, I/O"
  - "data streams, I/O"
ms.assetid: 4f4a33a9-66b7-4cd7-a285-4ad3e4276cd2
caps.latest.revision: 33
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# File and Stream I/O
File and stream I/O (input/output) refers to the transfer of data either to or from a storage medium. In the .NET Framework, the `System.IO` namespaces contain types that enable reading and writing, both synchronously and asynchronously, on data streams and files. These namespaces also contain types that perform compression and decompression on files, and types that enable communication through pipes and serial ports.  
  
 A file is an ordered and named collection of bytes that has persistent storage. When you work with files, you work with directory paths, disk storage, and file and directory names. In contrast, a stream is a sequence of bytes that you can use to read from and write to a backing store, which can be one of several storage mediums (for example, disks or memory). Just as there are several backing stores other than disks, there are several kinds of streams other than file streams, such as network, memory, and pipe streams.  
  
## Files and Directories  
 You can use the types in the <xref:System.IO?displayProperty=nameWithType> namespace to interact with files and directories. For example, you can get and set properties for files and directories, and retrieve collections of files and directories based on search criteria.  
  
 Here are some commonly used file and directory classes:  
  
-   <xref:System.IO.File> - provides static methods for creating, copying, deleting, moving, and opening files, and helps create a <xref:System.IO.FileStream> object.  
  
-   <xref:System.IO.FileInfo> - provides instance methods for creating, copying, deleting, moving, and opening files, and helps create a <xref:System.IO.FileStream> object.  
  
-   <xref:System.IO.Directory> - provides static methods for creating, moving, and enumerating through directories and subdirectories.  
  
-   <xref:System.IO.DirectoryInfo> - provides instance methods for creating, moving, and enumerating through directories and subdirectories.  
  
-   <xref:System.IO.Path> - provides methods and properties for processing directory strings in a cross-platform manner.  
  
 In addition to using these classes, Visual Basic users can use the methods and properties provided by the <xref:Microsoft.VisualBasic.FileIO.FileSystem?displayProperty=nameWithType> class for file I/O.  
  
 See [How to: Copy Directories](../../../docs/standard/io/how-to-copy-directories.md), [How to: Create a Directory Listing](https://msdn.microsoft.com/library/4d2772b1-b991-4532-a8a6-6ef733277e69), and [How to: Enumerate Directories and Files](../../../docs/standard/io/how-to-enumerate-directories-and-files.md).  
  
## Streams  
 The abstract base class <xref:System.IO.Stream> supports reading and writing bytes. All classes that represent streams inherit from the <xref:System.IO.Stream> class. The <xref:System.IO.Stream> class and its derived classes provide a common view of data sources and repositories, and isolate the programmer from the specific details of the operating system and underlying devices.  
  
 Streams involve three fundamental operations:  
  
-   Reading - transferring data from a stream into a data structure, such as an array of bytes.  
  
-   Writing - transferring data to a stream from a data source.  
  
-   Seeking - querying and modifying the current position within a stream.  
  
 Depending on the underlying data source or repository, a stream might support only some of these capabilities. For example, the <xref:System.IO.Pipes.PipeStream> class does not support seeking. The <xref:System.IO.Stream.CanRead%2A>, <xref:System.IO.Stream.CanWrite%2A>, and <xref:System.IO.Stream.CanSeek%2A> properties of a stream specify the operations that the stream supports.  
  
 Here are some commonly used stream classes:  
  
-   <xref:System.IO.FileStream> – for reading and writing to a file.  
  
-   <xref:System.IO.IsolatedStorage.IsolatedStorageFileStream> – for reading and writing to a file in isolated storage.  
  
-   <xref:System.IO.MemoryStream> – for reading and writing to memory as the backing store.  
  
-   <xref:System.IO.BufferedStream> – for improving performance of read and write operations.  
  
-   <xref:System.Net.Sockets.NetworkStream> – for reading and writing over network sockets.  
  
-   <xref:System.IO.Pipes.PipeStream> – for reading and writing over anonymous and named pipes.  
  
-   <xref:System.Security.Cryptography.CryptoStream> – for linking data streams to cryptographic transformations.  
  
 For an example of working with streams asynchronously, see [Asynchronous File I/O](../../../docs/standard/io/asynchronous-file-i-o.md).  
  
## Readers and Writers  
 The <xref:System.IO?displayProperty=nameWithType> namespace also provides types for reading encoded characters from streams and writing them to streams. Typically, streams are designed for byte input and output. The reader and writer types handle the conversion of the encoded characters to and from bytes so the stream can complete the operation. Each reader and writer class is associated with a stream, which can be retrieved through the class's `BaseStream` property.  
  
 Here are some commonly used reader and writer classes:  
  
-   <xref:System.IO.BinaryReader> and <xref:System.IO.BinaryWriter> – for reading and writing primitive data types as binary values.  
  
-   <xref:System.IO.StreamReader> and <xref:System.IO.StreamWriter> – for reading and writing characters by using an encoding value to convert the characters to and from bytes.  
  
-   <xref:System.IO.StringReader> and <xref:System.IO.StringWriter> – for reading and writing characters to and from strings.  
  
-   <xref:System.IO.TextReader> and <xref:System.IO.TextWriter> – serve as the abstract base classes for other readers and writers that read and write characters and strings, but not binary data.  
  
 See [How to: Read Text from a File](../../../docs/standard/io/how-to-read-text-from-a-file.md), [How to: Write Text to a File](../../../docs/standard/io/how-to-write-text-to-a-file.md), [How to: Read Characters from a String](../../../docs/standard/io/how-to-read-characters-from-a-string.md), and [How to: Write Characters to a String](../../../docs/standard/io/how-to-write-characters-to-a-string.md).  
  
## Asynchronous I/O Operations  
 Reading or writing a large amount of data can be resource-intensive. You should perform these tasks asynchronously if your application needs to remain responsive to the user. With synchronous I/O operations, the UI thread is blocked until the resource-intensive operation has completed.  Use asynchronous I/O operations when developing [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps to prevent creating the impression that your app has stopped working.  
  
 The asynchronous members contain `Async` in their names, such as the <xref:System.IO.Stream.CopyToAsync%2A>, <xref:System.IO.Stream.FlushAsync%2A>,  <xref:System.IO.Stream.ReadAsync%2A>, and <xref:System.IO.Stream.WriteAsync%2A> methods. You use these methods with the `async` and `await` keywords.  
  
 For more information, see [Asynchronous File I/O](../../../docs/standard/io/asynchronous-file-i-o.md).  
  
## Compression  
 Compression refers to the process of reducing the size of a file for storage. Decompression is the process of extracting the contents of a compressed file so they are in a usable format. The <xref:System.IO.Compression?displayProperty=nameWithType> namespace contains types for compressing and decompressing files and streams.  
  
 The following classes are frequently used when compressing and decompressing files and streams:  
  
-   <xref:System.IO.Compression.ZipArchive> – for creating and retrieving entries in the zip archive.  
  
-   <xref:System.IO.Compression.ZipArchiveEntry> – for representing a compressed file.  
  
-   <xref:System.IO.Compression.ZipFile> – for creating,  extracting, and opening a compressed package.  
  
-   <xref:System.IO.Compression.ZipFileExtensions> – for creating and extracting entries in a compressed package.  
  
-   <xref:System.IO.Compression.DeflateStream> – for compressing and decompressing streams using the Deflate algorithm.  
  
-   <xref:System.IO.Compression.GZipStream> – for compressing and decompressing streams in gzip data format.  
  
 See [How to: Compress and Extract Files](../../../docs/standard/io/how-to-compress-and-extract-files.md).  
  
## Isolated Storage  
 Isolated storage is a data storage mechanism that provides isolation and safety by defining standardized ways of associating code with saved data. The storage provides a virtual file system that is isolated by user, assembly, and (optionally) domain. Isolated storage is particularly useful when your application does not have permission to access user files. You can save settings or files for your application in a manner that is controlled by the computer's security policy.  
  
 Isolated storage is not available for [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps; instead, use application data classes in the [Windows.Storage](/uwp/api/Windows.Storage) namespace. For more information, see [Application data](/previous-versions/windows/apps/hh464917(v=win.10)) in the Windows Dev Center.  
  
 The following classes are frequently used when implementing isolated storage:  
  
-   <xref:System.IO.IsolatedStorage.IsolatedStorage> – provides the base class for isolated storage implementations.  
  
-   <xref:System.IO.IsolatedStorage.IsolatedStorageFile> – provides an isolated storage area that contains files and directories.  
  
-   <xref:System.IO.IsolatedStorage.IsolatedStorageFileStream> - exposes a file within isolated storage.  
  
 See [Isolated Storage](../../../docs/standard/io/isolated-storage.md).  
  
## I/O Operations in Windows Store apps  
 The [!INCLUDE[net_win8_profile](../../../includes/net-win8-profile-md.md)] contains many of the types for reading from and writing to streams; however, this set does not include all the .NET Framework I/O types.  
  
 Some important differences to note when using I/O operations in [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps:  
  
-   Types specifically related to file operations, such as <xref:System.IO.File>, <xref:System.IO.FileInfo>, <xref:System.IO.Directory> and <xref:System.IO.DirectoryInfo>, are not included in the [!INCLUDE[net_win8_profile](../../../includes/net-win8-profile-md.md)]. Instead, use the types in the [Windows.Storage](http://msdn.microsoft.com/library/windows/apps/windows.storage.aspx) namespace of the [!INCLUDE[wrt](../../../includes/wrt-md.md)], such as [StorageFile](http://msdn.microsoft.com/library/windows/apps/windows.storage.storagefile.aspx) and [StorageFolder](http://msdn.microsoft.com/library/windows/apps/windows.storage.storagefolder.aspx).  
  
-   Isolated storage is not available; instead, use [application data](/previous-versions/windows/apps/hh464917(v=win.10)).  
  
-   Use asynchronous methods, such as <xref:System.IO.Stream.ReadAsync%2A> and <xref:System.IO.Stream.WriteAsync%2A>, to prevent blocking the UI thread.  
  
-   The path-based compression types <xref:System.IO.Compression.ZipFile> and <xref:System.IO.Compression.ZipFileExtensions> are not available. Instead, use the types in the [Windows.Storage.Compression](http://msdn.microsoft.com/library/windows/apps/windows.storage.compression.aspx) namespace.  
  
 You can convert between .NET Framework streams and Windows Runtime streams, if necessary. For more information, see [How to: Convert Between .NET Framework Streams and Windows Runtime Streams](../../../docs/standard/io/how-to-convert-between-dotnet-streams-and-winrt-streams.md) or [System.IO.WindowsRuntimeStreamExtensions](https://msdn.microsoft.com/library/system.io.windowsruntimestreamextensions.aspx). <!--zz TODO: <xref:System.IO.WindowsRuntimeStreamExtensions>--> 
  
 For more information about I/O operations in a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app, see [Quickstart: Reading and writing files](/previous-versions/windows/apps/hh758325(v=win.10)).  
  
## I/O and Security  
 When you use the classes in the <xref:System.IO?displayProperty=nameWithType> namespace, you must follow operating system security requirements such as access control lists (ACLs) to control access to files and directories. This requirement is in addition to any <xref:System.Security.Permissions.FileIOPermission> requirements. You can manage ACLs programmatically. For more information, see [How to: Add or Remove Access Control List Entries](../../../docs/standard/io/how-to-add-or-remove-access-control-list-entries.md).  
  
 Default security policies prevent Internet or intranet applications from accessing files on the user’s computer. Therefore, do not use the I/O classes that require a path to a physical file when writing code that will be downloaded over the Internet or intranet. Instead, use [isolated storage](../../../docs/standard/io/isolated-storage.md) for traditional .NET Framework applications, or use [application data](/previous-versions/windows/apps/hh464917(v=win.10)) for [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps.  
  
 A security check is performed only when the stream is constructed. Therefore, do not open a stream and then pass it to less-trusted code or application domains.  
  
## Related Topics  
  
-   [Common I/O Tasks](../../../docs/standard/io/common-i-o-tasks.md)  
  
 Provides a list of I/O tasks associated with files, directories, and streams, and links to relevant content and examples for each task.  
  
-   [Asynchronous File I/O](../../../docs/standard/io/asynchronous-file-i-o.md)  
  
 Describes the performance advantages and basic operation of asynchronous I/O.  
  
-   [Isolated Storage](../../../docs/standard/io/isolated-storage.md)  
  
 Describes a data storage mechanism that provides isolation and safety by defining standardized ways of associating code with saved data.  
  
-   [Pipes](../../../docs/standard/io/pipe-operations.md)  
  
 Describes anonymous and named pipe operations in the .NET Framework.  
  
-   [Memory-Mapped Files](../../../docs/standard/io/memory-mapped-files.md)  
  
 Describes memory-mapped files, which contain the contents of files on disk in virtual memory. You can use memory-mapped files to edit very large files and to create shared memory for interprocess communication.
