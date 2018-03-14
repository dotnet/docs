---
title: "Common I-O Tasks"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "I/O, common tasks"
ms.assetid: bf00c380-706a-4e38-b829-454a480629fc
caps.latest.revision: 15
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Common I/O Tasks
The <xref:System.IO> namespace provides several classes that allow for various actions, such as reading and writing, to be performed on files, directories, and streams. For more information, see [File and Stream I-O](../../../docs/standard/io/index.md).  
  
## Common File Tasks  
  
|To do this...|See the example in this topic...|  
|-------------------|--------------------------------------|  
|Create a text file|<xref:System.IO.File.CreateText%2A?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.FileInfo.CreateText%2A?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.File.Create%2A?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.FileInfo.Create%2A?displayProperty=nameWithType> method|  
|Write to a text file|[How to: Write Text to a File](../../../docs/standard/io/how-to-write-text-to-a-file.md)<br /><br /> [How to: Write a Text File (C++/CLI)](/cpp/dotnet/how-to-write-a-text-file-cpp-cli)|  
|Read from a text file|[How to: Read Text from a File](../../../docs/standard/io/how-to-read-text-from-a-file.md)|  
|Append text to a file|[How to: Open and Append to a Log File](../../../docs/standard/io/how-to-open-and-append-to-a-log-file.md)<br /><br /> <xref:System.IO.File.AppendText%2A?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.FileInfo.AppendText%2A?displayProperty=nameWithType> method|  
|Rename or move a file|<xref:System.IO.File.Move%2A?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.FileInfo.MoveTo%2A?displayProperty=nameWithType> method|  
|Delete a file|<xref:System.IO.File.Delete%2A?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.FileInfo.Delete%2A?displayProperty=nameWithType> method|  
|Copy a file|<xref:System.IO.File.Copy%2A?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.FileInfo.CopyTo%2A?displayProperty=nameWithType> method|  
|Get the size of a file|<xref:System.IO.FileInfo.Length%2A?displayProperty=nameWithType> property|  
|Get the attributes of a file|<xref:System.IO.File.GetAttributes%2A?displayProperty=nameWithType> method|  
|Set the attributes of a file|<xref:System.IO.File.SetAttributes%2A?displayProperty=nameWithType> method|  
|Determine whether a file exists|<xref:System.IO.File.Exists%2A?displayProperty=nameWithType> method|  
|Read from a binary file|[How to: Read and Write to a Newly Created Data File](../../../docs/standard/io/how-to-read-and-write-to-a-newly-created-data-file.md)|  
|Write to a binary file|[How to: Read and Write to a Newly Created Data File](../../../docs/standard/io/how-to-read-and-write-to-a-newly-created-data-file.md)|  
|Retrieve a file name extension|<xref:System.IO.Path.GetExtension%2A?displayProperty=nameWithType> method|  
|Retrieve the fully qualified path of a file|<xref:System.IO.Path.GetFullPath%2A?displayProperty=nameWithType> method|  
|Retrieve the file name and extension from a path|<xref:System.IO.Path.GetFileName%2A?displayProperty=nameWithType> method|  
|Change the extension of a file|<xref:System.IO.Path.ChangeExtension%2A?displayProperty=nameWithType> method|  
  
## Common Directory Tasks  
  
|To do this...|See the example in this topic...|  
|-------------------|--------------------------------------|  
|Access a file in a special folder such as My Documents|[How to: Write Text to a File](../../../docs/standard/io/how-to-write-text-to-a-file.md)|  
|Create a directory|<xref:System.IO.Directory.CreateDirectory%2A?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.FileInfo.Directory%2A?displayProperty=nameWithType> property|  
|Create a subdirectory|<xref:System.IO.DirectoryInfo.CreateSubdirectory%2A?displayProperty=nameWithType> method|  
|Rename or move a directory|<xref:System.IO.Directory.Move%2A?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.DirectoryInfo.MoveTo%2A?displayProperty=nameWithType> method|  
|Copy a directory|[How to: Copy Directories](../../../docs/standard/io/how-to-copy-directories.md)|  
|Delete a directory|<xref:System.IO.Directory.Delete%2A?displayProperty=nameWithType> method<br /><br /> <xref:System.IO.DirectoryInfo.Delete%2A?displayProperty=nameWithType> method|  
|See the files and subdirectories in a directory|[How to: Enumerate Directories and Files](../../../docs/standard/io/how-to-enumerate-directories-and-files.md)|  
|Find the size of a directory|<xref:System.IO.Directory?displayProperty=nameWithType> class|  
|Determine whether a directory exists|<xref:System.IO.Directory.Exists%2A?displayProperty=nameWithType> method|  
  
## See Also  
 [File and Stream I-O](../../../docs/standard/io/index.md)  
 [Composing Streams](../../../docs/standard/io/composing-streams.md)  
 [Asynchronous File I/O](../../../docs/standard/io/asynchronous-file-i-o.md)
