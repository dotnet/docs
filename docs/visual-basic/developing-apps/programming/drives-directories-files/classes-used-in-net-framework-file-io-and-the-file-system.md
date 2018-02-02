---
title: "Classes Used in .NET Framework File I/O and the File System (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "file I/O classes"
ms.assetid: 4a5ca924-eea8-4a95-a5f0-6ac10de276a3
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# Classes Used in .NET Framework File I/O and the File System (Visual Basic)
The following tables list the classes commonly used for .NET Framework file I/O, categorized into file I/O classes, classes used for creating streams, and classes used to read and write to streams.  
  
 To enter the [!INCLUDE[dnprdnlong](~/includes/dnprdnlong-md.md)] documentation and find a more comprehensive listing, see [Class Library Overview](../../../../standard/class-library-overview.md).  
  
## Basic I/O Classes for Files, Drives, and Directories  
 The following table lists and describes the main classes used for file I/O.  
  
|Class|Description|  
|-----------|-----------------|  
|<xref:System.IO.Directory?displayProperty=nameWithType>|Provides static methods for creating, moving, and enumerating through directories and subdirectories.|  
|<xref:System.IO.DirectoryInfo?displayProperty=nameWithType>|Provides instance methods for creating, moving, and enumerating through directories and subdirectories.|  
|<xref:System.IO.DriveInfo?displayProperty=nameWithType>|Provides instance methods for creating, moving, and enumerating through drives.|  
|<xref:System.IO.File?displayProperty=nameWithType>|Provides static methods for creating, copying, deleting, moving, and opening files, and aids in the creation of a `FileStream`.|  
|<xref:System.IO.FileAccess?displayProperty=nameWithType>|Defines constants for read, write, or read/write access to a file.|  
|<xref:System.IO.FileAttributes?displayProperty=nameWithType>|Provides attributes for files and directories such as `Archive`, `Hidden`, and `ReadOnly`.|  
|<xref:System.IO.FileInfo?displayProperty=nameWithType>|Provides static methods for creating, copying, deleting, moving, and opening files, and aids in the creation of a `FileStream`.|  
|<xref:System.IO.FileMode?displayProperty=nameWithType>|Controls how a file is opened. This parameter is specified in many of the constructors for `FileStream` and `IsolatedStorageFileStream`, and for the `Open` methods of <xref:System.IO.File> and <xref:System.IO.FileInfo>.|  
|<xref:System.IO.FileShare?displayProperty=nameWithType>|Defines constants for controlling the type of access other file streams can have to the same file.|  
|<xref:System.IO.Path?displayProperty=nameWithType>|Provides methods and properties for processing directory strings.|  
|<xref:System.Security.Permissions.FileIOPermission?displayProperty=nameWithType>|Controls the access of files and folders by defining <xref:System.Security.Permissions.FileIOPermissionAttribute.Read%2A>, <xref:System.Security.Permissions.FileIOPermissionAttribute.Write%2A>, <xref:System.Security.Permissions.FileIOPermissionAttribute.Append%2A> and <xref:System.Security.Permissions.FileIOPermissionAttribute.PathDiscovery%2A> permissions.|  
  
## Classes Used to Create Streams  
 The following table lists and describes the main classes used to create streams.  
  
|Class|Description|  
|-----------|-----------------|  
|<xref:System.IO.BufferedStream?displayProperty=nameWithType>|Adds a buffering layer to read and write operations on another stream.|  
|<xref:System.IO.FileStream?displayProperty=nameWithType>|Supports random access to files through its <xref:System.IO.FileStream.Seek%2A> method. <xref:System.IO.FileStream> opens files synchronously by default but also supports asynchronous operation.|  
|<xref:System.IO.MemoryStream?displayProperty=nameWithType>|Creates a stream whose backing store is memory, rather than a file.|  
|<xref:System.Net.Sockets.NetworkStream?displayProperty=nameWithType>|Provides the underlying stream of data for network access.|  
|<xref:System.Security.Cryptography.CryptoStream?displayProperty=nameWithType>|Defines a stream that links data streams to cryptographic transformations.|  
  
## Classes Used to Read from and Write to Streams  
 The following table shows the specific classes used for reading from and writing to files with streams.  
  
|**Class**|**Description**|  
|---------------|---------------------|  
|<xref:System.IO.BinaryReader?displayProperty=nameWithType>|Reads encoded strings and primitive data types from a <xref:System.IO.FileStream>.|  
|<xref:System.IO.BinaryWriter?displayProperty=nameWithType>|Writes encoded strings and primitive data types to a <xref:System.IO.FileStream>.|  
|<xref:System.IO.StreamReader?displayProperty=nameWithType>|Reads characters from a <xref:System.IO.FileStream>, using <xref:System.IO.StreamReader.CurrentEncoding%2A> to convert characters to and from bytes. <xref:System.IO.StreamReader> has a constructor that attempts to ascertain the correct <xref:System.IO.StreamReader.CurrentEncoding%2A> for a given stream, based on the presence of a <xref:System.IO.StreamReader.CurrentEncoding%2A>-specific preamble, such as a byte order mark.|  
|<xref:System.IO.StreamWriter?displayProperty=nameWithType>|Writes characters to a `FileStream`, using <xref:System.IO.StreamWriter.Encoding%2A> to convert characters to bytes.|  
|<xref:System.IO.StringReader?displayProperty=nameWithType>|Reads characters from a `String`. Output can be either a stream in any encoding or a `String`.|  
|<xref:System.IO.StringWriter?displayProperty=nameWithType>|Writes characters to a `String`. Output can be either a stream in any encoding or a `String`.|  
  
## See Also  
 [Composing Streams](../../../../standard/io/composing-streams.md)  
 [File and Stream I/O](../../../../standard/io/index.md)  
 [Asynchronous File I/O](../../../../standard/io/asynchronous-file-i-o.md)  
 [Basics of .NET Framework File I/O and the File System (Visual Basic)](../../../../visual-basic/developing-apps/programming/drives-directories-files/basics-of-net-framework-file-io-and-the-file-system.md)
