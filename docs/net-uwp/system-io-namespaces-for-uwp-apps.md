---
title: "System.IO namespaces for UWP apps | Microsoft Docs"
ms.custom: ""
ms.date: "12/14/2016"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ac2d71f5-0af3-4002-92ec-01122d71f583
caps.latest.revision: 6
author: "msatranjr"
ms.author: "misatran"
manager: "markl"
---
# System.IO namespaces for UWP apps
The `System.IO`, `System.IO.Compression`, and `System.IO.IsolatedStorage` namespaces contain types that support reading and writing data to streams; basic compression and decompression services for streams; and allow the creation and use of isolated stores.  
  
 This topic displays the types in the `System.IO` and `System.IO.Compression` namespaces that are included in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]. Note that [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)].  
  
## System.IO namespace  
  
|Types supported in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.IO.BinaryReader>|Reads primitive data types as binary values in a specific encoding.|  
|<xref:System.IO.BinaryWriter>|Writes primitive types in binary to a stream and supports writing strings in a specific encoding.|  
|<xref:System.IO.Directory>|Exposes static methods for creating; moving; and enumerating through directories and subdirectories. This class cannot be inherited.To browse the .NET Framework source code for this type; see the Reference Source.|  
|<xref:System.IO.DirectoryInfo>|Exposes instance methods for creating; moving; and enumerating through directories and subdirectories. This class cannot be inherited.To browse the .NET Framework source code for this type; see the Reference Source.|  
|<xref:System.IO.DirectoryNotFoundException>|The exception that is thrown when part of a file or directory cannot be found.|  
|<xref:System.IO.EndOfStreamException>|The exception that is thrown when reading is attempted past the end of a stream.|  
|<xref:System.IO.File>|Provides static methods for the creation; copying; deletion; moving; and opening of a single file; and aids in the creation of FileStream objects.To browse the .NET Framework source code for this type; see the Reference Source.|  
|<xref:System.IO.FileAccess>|Defines constants for read; write; or read/write access to a file.|  
|<xref:System.IO.FileAttributes>|Provides attributes for files and directories.|  
|<xref:System.IO.FileInfo>|Provides properties and instance methods for the creation; copying; deletion; moving; and opening of files; and aids in the creation of FileStream objects. This class cannot be inherited.To browse the .NET Framework source code for this type; see the Reference Source.|  
|<xref:System.IO.FileLoadException>|The exception that is thrown when a managed assembly is found but cannot be loaded.|  
|<xref:System.IO.FileMode>|Specifies how the operating system should open a file.|  
|<xref:System.IO.FileNotFoundException>|The exception that is thrown when an attempt to access a file that does not exist on disk fails.|  
|<xref:System.IO.FileOptions>|Represents advanced options for creating a FileStream object.|  
|<xref:System.IO.FileShare>|Contains constants for controlling the kind of access other FileStream objects can have to the same file.|  
|<xref:System.IO.FileStream>|Provides a Stream for a file; supporting both synchronous and asynchronous read and write operations.To browse the .NET Framework source code for this type; see the Reference Source.|  
|<xref:System.IO.FileSystemInfo>|Provides the base class for both FileInfo and DirectoryInfo objects.|  
|<xref:System.IO.HandleInheritability>|Specifies whether the underlying handle is inheritable by child processes.|  
|<xref:System.IO.InvalidDataException>|The exception that is thrown when a data stream is in an invalid format.|  
|<xref:System.IO.IOException>|The exception that is thrown when an I/O error occurs.|  
|<xref:System.IO.MemoryStream>|Creates a stream whose backing store is memory.|  
|<xref:System.IO.Path>|Performs operations on String instances that contain file or directory path information. These operations are performed in a cross-platform manner.|  
|<xref:System.IO.PathTooLongException>|The exception that is thrown when a path or file name is longer than the system-defined maximum length.|  
|<xref:System.IO.SearchOption>|Specifies whether to search the current directory; or the current directory and all subdirectories.|  
|<xref:System.IO.SeekOrigin>|Provides the fields that represent reference points in streams for seeking.|  
|<xref:System.IO.Stream>|Provides a generic view of a sequence of bytes.|  
|<xref:System.IO.StreamReader>|Implements a TextReader that reads characters from a byte stream in a particular encoding.|  
|<xref:System.IO.StreamWriter>|Implements a TextWriter for writing characters to a stream in a particular encoding.|  
|<xref:System.IO.StringReader>|Implements a TextReader that reads from a string.|  
|<xref:System.IO.StringWriter>|Implements a TextWriter for writing information to a string. The information is stored in an underlying StringBuilder.|  
|<xref:System.IO.TextReader>|Represents a reader that can read a sequential series of characters.|  
|<xref:System.IO.TextWriter>|Represents a writer that can write a sequential series of characters. This class is abstract.|  
|<xref:System.IO.UnmanagedMemoryAccessor>|Provides random access to unmanaged blocks of memory from managed code.|  
|<xref:System.IO.UnmanagedMemoryStream>|Provides access to unmanaged blocks of memory from managed code.|  
|<xref:System.IO.WindowsRuntimeStorageExtensions>|Contains extension methods for the IStorageFile and IStorageFolder interfaces in the wrt when developing win8_appname_long apps.|  
|<xref:System.IO.WindowsRuntimeStreamExtensions>|Contains extension methods for converting between streams in the wrt and managed streams in the net_win8_profile.|  
  
## System.IO.Compression namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.IO.Compression.CompressionLevel>|Specifies values that indicate whether a compression operation emphasizes speed or compression size.|  
|<xref:System.IO.Compression.CompressionMode>|Specifies whether to compress or decompress the underlying stream.|  
|<xref:System.IO.Compression.DeflateStream>|Provides methods and properties for compressing and decompressing streams using the Deflate algorithm.|  
|<xref:System.IO.Compression.GZipStream>|Provides methods and properties used to compress and decompress streams.|  
|<xref:System.IO.Compression.ZipArchive>|Represents a zip archive.|  
|<xref:System.IO.Compression.ZipArchiveEntry>|Represents an entry in the zip archive.|  
|<xref:System.IO.Compression.ZipArchiveMode>|Specifies values for interacting with zip archive entries.|  
|<xref:System.IO.Compression.ZipFile>|Provides static methods for creating; extracting; and opening zip archives.|  
|<xref:System.IO.Compression.ZipFileExtensions>|Provides extension methods for the ZipArchive and ZipArchiveEntry classes.|  
  
## System.IO.IsolatedStorage namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.IO.IsolatedStorage.IsolatedStorageException>|The exception that is thrown when an operation in isolated storage fails.|  
|<xref:System.IO.IsolatedStorage.IsolatedStorageFile>|Represents an isolated storage area containing files and directories.|  
|<xref:System.IO.IsolatedStorage.IsolatedStorageFileStream>|Exposes a file within isolated storage.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)