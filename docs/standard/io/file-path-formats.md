---
title: "Supported file path formats on Windows systems"
ms.date: "04/25/2018"
ms.prod: ".net"
ms.technology: dotnet-standard
ms.topic: "article"
helpviewer_keywords: 
  - "I/O, long paths"
  - "long paths"
  - "path formats, Windows"
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
- An optional filename. The [directory separator character](<xref:System.IO.Path.DirectorySeparatorChar>) separates the file path and the filename.

If all three components are present, the path is absolute. If no volume or drive letter is specified and the directory names begins with the [directory separator character](<xref:System.IO.Path.DirectorySeparatorChar>), the path is relative from the root of the current drive is assumed. Otherwise, the path is relative to the current directory. The following table shows some possible directory and file paths.

|Path  |Description  |
| -- | -- |
| C:\\Documents\Newsletters\Summer2018.pdf | An absolute file path from the root of drive C: |
| \\Program Files\\Custom Utilities\\StringFinder.exe | An absolute path from the root of the current drive. |
| 2018\\January.xlsx | A relative path to a file in a subdirectory of the current directory. |
| ..\\Publications\\TravelBrochure.pdf | A relative path to file in a directory that is a peer of the current directory. |

## UNC paths

Universal naming convention (UNC) paths, which are used to access network resources, have the following format:

- A server or host name, which is prefaced by \\\\. The server name can be a NetBIOS machine name or an IP/FQDN address (IPv4 as well as v6 are supported).
- A share name, which is separated from the host name by \\. Together, the server and share name make up the volume.
- A directory name. The [directory separator character](<xref:System.IO.Path.DirectorySeparatorChar>) separates subdirectories within the nested directory hierarchy.
- An optional filename. The [directory separator character](<xref:System.IO.Path.DirectorySeparatorChar>) separates the file path and the filename.

The following are some examples of UNC paths:

|Path  |Description  |
| -- | -- |
| \\\\system07\\C$\\ | The root directory of the C: drive on `system07`. |
| \\Server2\\Share\\Test\\Foo.txt | The Foo.txt file in the Test directory of the \\\\Server2\\Share volume.|

UNC paths are always absolute. You can use relative paths only by mapping a UNC path to a drive letter.

## DOS Device Paths

The Windows operating system has a unified object model that points to all resources, including files. These object paths are not directly accessible from the Windows APIs (and consequently the CMD shell, file explorer, etc.). They are, however, exposed to the Win32 layer through a special folder of symbolic links that legacy DOS and UNC paths are mapped to. This special folder is accessed via the DOS Device path syntax, which is one of:

\\.\C:\Test\Foo.txt
\\?\C:\Test\Foo.txt
The \\.\ or \\?\ identifies the path as a DOS device path. The next component (C: in this case) is a symbolic link to the "real" NT device object. There is a specific link for UNCs called, not surprisingly, "UNC".
\\.\UNC\Server\Share\Test\Foo.txt
\\?\UNC\Server\Share\Test\Foo.txt
Like UNCs, DOS device paths are fully qualified by definition. Current directories never enter into their usage.
Terminology around DOS device paths and explanations of how they work are seriously lacking. I'll go into how these and all of the other path formats translate into the final NT path in later posts.
Up Next
Normalization. Most paths get normalized, which includes processing partially qualified paths and relative components (. and ..). Tune in next time for the deep dive.
References
Naming Files, Paths, and Namespaces (MSDN)
[MS-DTYP] 2.2.57 UNC
[MS-FCCC] 2.1.5 Pathname
[MS-FCCC] 2.1.5 Share name
[MS-FSA] 5 Appendix A: Product Behavior
MS-DOS 2.0: An Enhanced 16-Bit Operating System
Stupid DOS Tricks
A small fraction of the ways you can refer to the same file:
C:\>dir c:\test\foo.txt
 Volume in drive C is OS
 Volume Serial Number is 0000-0000

 Directory of c:\test

04/20/2016  07:00 PM                13 Foo.txt
               1 File(s)             13 bytes
               0 Dir(s)  56,278,192,128 bytes free
C:\>dir \\127.0.0.1\c$\test\foo.txt
 Volume in drive \\127.0.0.1\c$ is OS
 Volume Serial Number is 0000-0000

 Directory of \\127.0.0.1\c$\test

04/20/2016  07:00 PM                13 Foo.txt
               1 File(s)             13 bytes
               0 Dir(s)  56,278,192,128 bytes free
I'll spare you the output on the rest of these.
C:\>dir \\LOCALHOST\c$\test\foo.txt
C:\>dir \\.\c:\test\foo.txt
C:\>dir \\?\c:\test\foo.txt
C:\>dir \\.\UNC\LOCALHOST\c$\test\foo.txt
C:\>dir \\127.0.0.1\c$\test\foo.txt


.NET Core and the .NET Framework (starting with version 4.6.2) support long file paths.