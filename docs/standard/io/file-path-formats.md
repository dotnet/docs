---
title: "Supported file path formats on Windows systems"
ms.date: "04/25/2018"
ms.prod: ".net"
ms.technology: dotnet-standard
ms.topic: "article"
helpviewer_keywords: 
  - "I/O, long paths"
  - "long paths"
author: "rpetrusha"
ms.author: "ronpet"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Supported file path formats on Windows systems

Members of many of the types in the <xref:System.IO> namespace have include a `path` parameter that lets you specify an abolute or relative path to a file system resource. This topic discusses the formats for file paths that you can use on Windows systems.

## Traditional DOS paths

A standard DOS path can consist of three components: 

- A volume or drive letter followed by the volume separator (`:`).
- A directory name. The [directory separator character](<xref:System.IO.Path.DirectorySeparatorChar>) separates subdirectories within the nested directory hierarchy.  
- A optional filename. The [directory separator character](<xref:System.IO.Path.DirectorySeparatorChar>) separates the file path and the filename.

If all three components are present, the path is absolute. If no volume or drive letter is specified and the directory names begins with the [directory separator character](<xref:System.IO.Path.DirectorySeparatorChar>), the path is relative from the root of the current drive is assumed. Otherwise, the path is relative to the current directory. The following table shows some possible directory and file paths.


|Path  |Description  |
| -- | -- |
| C:\\\\Documents\Newsletters\Summer2018.pdf | An absolute file path from the root of drive C: |
| \Program Files\Custom Utilities\StringFinder.exe | An absolute path from the root of the current drive. |
| 2018\January.xlsx | A relative path to a file in a subdirectory of the current directory. |
| ..\Publications\TravelBrochure.pdf | A relative path to file in a directory that is a peer of the current directory. |

## UNC paths

Universal naming convention (UNC) paths, which are used to access network resources, have the following format:

- A server or host name, which is prefaced by \\\\.
- A share name, which is separated from the host name by \\.


.NET Core and the .NET Framework (starting with version 4.6.2) support long file paths.