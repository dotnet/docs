---
title: "System.IO namespaces1 | Microsoft Docs"
ms.custom: ""
ms.date: "12/16/2016"
ms.prod: "windows-client-threshold"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - ".net-for-windows-store-apps"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 85d85936-33a7-4576-b992-968629f37ee6
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# System.IO namespaces1
The `System.IO` and `System.IO.Compression` namespaces contain types that support reading and writing data to streams, and basic compression and decompression services for streams.  
  
 This topic displays the types in the `System.IO` and `System.IO.Compression` namespaces that are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]. Note that the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)].  
  
## System.IO namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.IO.BinaryReader>|Reads primitive data types as binary values in a specific encoding.|  
|<xref:System.IO.BinaryWriter>|Writes primitive types in binary to a stream and supports writing strings in a specific encoding.|  
|<xref:System.IO.EndOfStreamException>|The exception that is thrown when reading is attempted past the end of a stream.|  
|<xref:System.IO.FileNotFoundException>|The exception that is thrown when an attempt to access a file that does not exist on disk fails.|  
|<xref:System.IO.InvalidDataException>|The exception that is thrown when a data stream is in an invalid format.|  
|<xref:System.IO.IOException>|The exception that is thrown when an I/O error occurs.|  
|<xref:System.IO.MemoryStream>|Creates a stream whose backing store is memory.|  
|<xref:System.IO.Path>|Performs operations on String instances that contain file or directory path information. These operations are performed in a cross-platform manner.|  
|<xref:System.IO.SeekOrigin>|Provides the fields that represent reference points in streams for seeking.|  
|<xref:System.IO.Stream>|Provides a generic view of a sequence of bytes.|  
|<xref:System.IO.StreamReader>|Implements a TextReader that reads characters from a byte stream in a particular encoding.|  
|<xref:System.IO.StreamWriter>|Implements a TextWriter for writing characters to a stream in a particular encoding.|  
|<xref:System.IO.StringReader>|Implements a TextReader that reads from a string.|  
|<xref:System.IO.StringWriter>|Implements a TextWriter for writing information to a string. The information is stored in an underlying StringBuilder.|  
|<xref:System.IO.TextReader>|Represents a reader that can read a sequential series of characters.|  
|<xref:System.IO.TextWriter>|Represents a writer that can write a sequential series of characters. This class is abstract.|  
|<xref:System.IO.WindowsRuntimeStorageExtensions>|Contains extension methods for the IStorageFile and IStorageFolder interfaces in the [!INCLUDE[wrt](../net-uwp/includes/wrt-md.md)] when developing [!INCLUDE[win8_appname_long](../net-uwp/includes/win8-appname-long-md.md)] apps.|  
|<xref:System.IO.WindowsRuntimeStreamExtensions>|Contains extension methods for converting between streams in the [!INCLUDE[wrt](../net-uwp/includes/wrt-md.md)] and managed streams in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)].|  
  
## System.IO.Compression namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.IO.Compression.CompressionLevel>|Specifies values that indicate whether a compression operation emphasizes speed or compression size.|  
|<xref:System.IO.Compression.CompressionMode>|Specifies whether to compress or decompress the underlying stream.|  
|<xref:System.IO.Compression.DeflateStream>|Provides methods and properties for compressing and decompressing streams using the Deflate algorithm.|  
|<xref:System.IO.Compression.GZipStream>|Provides methods and properties used to compress and decompress streams.|  
|<xref:System.IO.Compression.ZipArchive>|Represents a zip archive.|  
|<xref:System.IO.Compression.ZipArchiveEntry>|Represents an entry in the zip archive.|  
|<xref:System.IO.Compression.ZipArchiveMode>|Specifies values for interacting with zip archive entries.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)