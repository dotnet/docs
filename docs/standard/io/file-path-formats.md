---
title: "File path formats on Windows systems"
ms.date: "06/28/2018"
ms.technology: dotnet-standard
ms.topic: "article"
helpviewer_keywords: 
  - "I/O, long paths"
  - "long paths"
  - "path formats, Windows"
author: "rpetrusha"
ms.author: "ronpet"
---
# File path formats on Windows systems

Members of many of the types in the <xref:System.IO> namespace include a `path` parameter that lets you specify an absolute or relative path to a file system resource. This path is then passed to [Windows file system APIs](https://msdn.microsoft.com/library/windows/desktop/aa364407(v=vs.85).aspx). This topic discusses the formats for file paths that you can use on Windows systems.

## Traditional DOS paths

A standard DOS path can consist of three components:

- A volume or drive letter followed by the volume separator (`:`).
- A directory name. The [directory separator character](<xref:System.IO.Path.DirectorySeparatorChar>) separates subdirectories within the nested directory hierarchy.
- An optional filename. The [directory separator character](<xref:System.IO.Path.DirectorySeparatorChar>) separates the file path and the filename.

If all three components are present, the path is absolute. If no volume or drive letter is specified and the directory names begins with the [directory separator character](<xref:System.IO.Path.DirectorySeparatorChar>), the path is relative from the root of the current drive. Otherwise, the path is relative to the current directory. The following table shows some possible directory and file paths.

|Path  |Description  |
| -- | -- |
| `C:\Documents\Newsletters\Summer2018.pdf` | An absolute file path from the root of drive C: |
| `\Program Files\Custom Utilities\StringFinder.exe` | An absolute path from the root of the current drive. |
| `2018\January.xlsx` | A relative path to a file in a subdirectory of the current directory. |
| `..\Publications\TravelBrochure.pdf` | A relative path to file in a directory that is a peer of the current directory. |
| `C:\Projects\apilibrary\apilibrary.sln` | An absolute path to a file from the root of drive C: |
| `C:Projects\apilibrary\apilibrary.sln` | A relative path from the current directory of the C: drive. |

> [!IMPORTANT]
> Note the difference between the last two paths. Both specify the optional volume specifier (C: in both cases), but the first begins with the root of the specified volume, whereas the second does not. As result, the first is an absolute path from the root directory of drive C:, whereas the second is a relative path from the current directory of drive C:. Use of the second form when the first is intended is a common source of bugs that involve Windows file paths.

You can determine whether a file path is fully qualified (that is, it the path is independent of the current directory and does not change when the current directory changes) by calling the <xref:System.IO.Path.IsPathFullyQualified%2A?displayProperty=nameWthType> method. Note that such a path can include relative directory segments (`.` and `..`) and still be fully qualified if the resolved path always points to the same location.

The following example illustrates the difference between absolute and relative paths. It assumes that the directory D:\FY2018\ exists, and that you haven't set any curent directory for D:\ from the command prompt before running the example.

[!code-csharp[absolute-and-relative-paths](~/samples/snippets/standard/io/file-names/cs/paths.cs)]
[!code-vb[absolute-and-relative-paths](~/samples/snippets/standard/io/file-names/vb/paths.vb)]

## UNC paths

Universal naming convention (UNC) paths, which are used to access network resources, have the following format:

- A server or host name, which is prefaced by \\\\. The server name can be a NetBIOS machine name or an IP/FQDN address (IPv4 as well as v6 are supported).
- A share name, which is separated from the host name by \\. Together, the server and share name make up the volume.
- A directory name. The [directory separator character](<xref:System.IO.Path.DirectorySeparatorChar>) separates subdirectories within the nested directory hierarchy.
- An optional filename. The [directory separator character](<xref:System.IO.Path.DirectorySeparatorChar>) separates the file path and the filename.

The following are some examples of UNC paths:

|Path  |Description  |
| -- | -- |
| `\\system07\C$\` | The root directory of the C: drive on `system07`. |
| `\\Server2\Share\Test\Foo.txt` | The Foo.txt file in the Test directory of the \\\\Server2\\Share volume.|

UNC paths must always be fully qualified. They can include relative directory segments (`.` and `..`), but these must be part of a fully qualified path. You can use relative paths only by mapping a UNC path to a drive letter.

## DOS device paths

The Windows operating system has a unified object model that points to all resources, including files. These object paths are accessible from the console window and are exposed to the Win32 layer through a special folder of symbolic links that legacy DOS and UNC paths are mapped to. This special folder is accessed via the DOS device path syntax, which is one of:

`\\.\C:\Test\Foo.txt`  
`\\?\C:\Test\Foo.txt`

> [!NOTE]
> DOS device path syntax is supported on .NET implementations running on Windows starting with .NET Core 1.1 and .NET Framework 4.6.2.

The DOS device path consists of the following components:

- The device path specifier (`\\.\` or `\\?\`), which identifies the path as a DOS device path.

   > [!NOTE]
   > The `\\?\` is supported in all versions of .NET Core and in the .NET Framework starting with version 4.6.2.
   
- A symbolic link to the "real" device object (C: in this case).

   The first segment of the DOS device path after the device path specifier identifies the volume or drive. (For example, `\\?\C:\` and `\\.\BootPartition\`.)

   There is a specific link for UNCs that is called, not surprisingly, `UNC`. For example:

  `\\.\UNC\Server\Share\Test\Foo.txt`  
  `\\?\UNC\Server\Share\Test\Foo.txt`

    For device UNCs, the server/share portion is forms the volume. For example, in `\\?\server1\e:\utilities\\filecomparer\`, the server/share portion is server1\utilities. This is significant when calling a method such as <xref:System.IO.Path.GetFullPath(System.String,System.String)?displayProperty=nameWithType> with relative directory segments; it is never possible to navigate past the volume. 

DOS device paths are fully qualified by definition. Relative directory segments (`.` and `..`) are not allowed. Current directories never enter into their usage.

## Example: Ways to refer to the same file

The following example illustrates some of the ways in which you can refer to a file when using the APIs in the <xref:System.IO> namespace. The example instantiates a <xref:System.IO.FileInfo> object and uses its <xref:System.IO.FileInfo.Name> and <xref:System.IO.FileInfo.Length> properties to display the filename and the length of the file.

[!code-csharp[referring-to-the-same-file](~/samples/snippets/standard/io/file-names/cs/file-refs.cs)]
[!code-vb[referring-to-the-same-file](~/samples/snippets/standard/io/file-names/vb/file-refs.vb)]

## Path normalization

Almost all paths passed to Windows APIs are normalized. During normalization, Windows performs the following steps:

- Identifies the path.
- Applies the current directory to partially qualified (relative) paths.
- Canonicalizes component and directory separators.
- Evaluates relative directory components (`.` for the current directory and `..` for the parent directory).
- Trims certain characters.

This normalization happens implicitly, but you can do it explicitly by calling the <xref:System.IO.Path.GetFullPath%2A?displayProperty=nameWithType> method, which wraps a call to the  [GetFullPathName() function](/windows/desktop/api/fileapi/nf-fileapi-getfullpathnamea). You can also call the Windows [GetFullPathName() function](/windows/desktop/api/fileapi/nf-fileapi-getfullpathnamea) directly using P/Invoke.

### Identifying the path

The first step in path normalization is identifying the type of path. Paths fall into one of a few categories:

- They are device paths; that is, they begin with two separators and a question mark or period (`\\?` or `\\.`).
- They are UNC paths; that is, they begin with two separators without a question mark or period. 
- They are fully qualified DOS paths; that is, they begin with a drive letter, a volume separator, and a component separator (`C:\`).
- They designate a legacy device (`CON`, `LPT1`).
- They are relative to the root of the current drive; that is, they begin with a single component separator (`\`).
- They are relative to the current directory of a specified drive; that is, they begin with a drive letter, a volume separator, and no component separator (`C:`).
- They are relative to the current directory; that is, they begin with anything else (`temp\testfile.txt`).

The type of the path determines whether or not a current directory is applied in some way. It also determines what the "root" of the path is.

### Handling legacy devices

If the path is a legacy DOS device such as `CON`, `COM1`, or `LPT1`, it is converted into a device path by prepending `\\.\` and returned. 

A path that begins with a legacy device name is always interpreted as a legacy device by the <xref:System.IO.Path.GetFullPath(System.String)?displayProperty=nameWithType> method. For example, the DOS device path for `CON.TXT` is `\\.\CON`, and the DOS device path for `COM1.TXT\file1.txt` is `\\.\COM1`.

### Applying the current directory

If a path isn't fully qualified, Windows applies the current directory to it. UNCs and device paths do not have the current directory applied. Neither does a full drive with separator C:\\.

If the path starts with a single component separator, the drive from the current directory is applied. For example, if the file path is `\utilities` and the current directory is `C:\temp\`, normalization produces `C:\utilities`.

If the path starts with a drive letter, volume separator, and no component separator, the last current directory set from the command shell for the specified drive is applied. If the last current directory was not set, the drive alone is applied. For example, if the file path is `D:sources`, the current directory is `C:\Documents\`, and the last current directory on drive D: was `D:\sources\`, the result is `D:\sources\sources`. These "drive relative" paths are a common source of program and script logic errors. Assuming that a path beginning with a letter and a colon isn't relative is obviously not correct.

If the path starts with something other than a separator, the current drive and current directory are applied. For example, if the path is `filecompare` and the current directory is `C:\utilities\`, the result is `C:\utilities\filecompare\`.

> [!IMPORTANT]
> Relative paths are dangerous in multithreaded applications (that is, most applications) because the current directory is a per-process setting. Any thread can change the current directory at any time. Starting with .NET Core 2.1, you can call the <xref:System.IO.Path.GetFullPath(System.String,System.String)?displayProperty=nameWithType> method to get an absolute path from a relative path and the base path (the current directory) that you want to resolve it against. 

### Canonicalizing separators

All forward slashes (`/`) are converted into the standard Windows separator, the back slash (`\`). If they are present, a series of slashes that follow the first two slashes are collapsed into a single slash.

### Evaluating relative components

As the path is processed, any components or segments that are composed of a single or a double period (`.` or `..`) are evaluated: 

- For a single period, the current segment is removed, since it refers to the current directory.

- For a double period, the current segment and the parent segment are removed, since the double period refers to the parent directory.

   Parent directories are only removed if they aren't past the root of the path. The root of the path depends on the type of path. It is the drive (`C:\`) for DOS paths, the server/share for UNCs (`\\Server\Share`), and the device path prefix for device paths (`\\?\` or `\\.\`).

### Trimming characters

Along with the runs of separators and relative segments removed earlier, some additional characters are removed during normalization:

- If a segment ends in a single period, that period is removed. (A segment of a single or double period is normalized in the previous step. A segment of three or more periods is not normalized and is actually a valid file/directory name.)

- If the path doesn't end in a separator, all trailing periods and spaces (U+0020) are removed. If the last segment is simply a single or double period, it falls under the relative components rule above. 

   This rule means that you can create a directory name with a trailing space by adding a trailing separator after the space.  

   > [!IMPORTANT]
   > You should **never** create a directory or filename with a trailing space. Trailing spaces can make it difficult or impossible to access a directory, and applications commonly fail when attempting to handle directories or files whose names include trailing spaces.

## Skipping normalization

Normally, any path passed to a Windows API is (effectively) passed to the [GetFullPathName function](/windows/desktop/api/fileapi/nf-fileapi-getfullpathnamea) and normalized. There is one important exception: a device path that begins with a question mark instead of a period. Unless the path starts exactly with `\\?\` (note the use of the canonical backslash), it is normalized.

Why would you want to skip normalization? There are three major reasons:

1. To get access to paths that are normally unavailable but are legal. A file or directory called `hidden.`, for example, is impossible to access in any other way. 

1. To improve performance by skipping normalization if you've already normalized.

1. On the .NET Framework only, to skip the `MAX_PATH` check for path length to allow for paths that are greater than 259 characters. Most APIs allow this, with some exceptions.

> [!NOTE]
> .NET Core handles long paths implicitly and does not perform a `MAX_PATH` check. The `MAX_PATH` check applies only to the .NET Framework.

Skipping normalization and max path checks is the only difference between the two device path syntaxes; they are otherwise identical. Be careful with skipping normalization, since you can easily create paths that are difficult for "normal" applications to deal with.

Paths that start with `\\?\` are still normalized if you explicitly pass them to the [GetFullPathName function](/windows/desktop/api/fileapi/nf-fileapi-getfullpathnamea).

Note that you can paths of more than `MAX_PATH` characters to [GetFullPathName](/windows/desktop/api/fileapi/nf-fileapi-getfullpathnamea) without `\\?\`. It supports arbitrary length paths up to the maximum string size that Windows can handle.

## Case and the Windows file system

A peculiarity of the Windows file system that non-Windows users and developers find confusing is that path and directory names are case-insensitive. That is, directory and file names reflect the casing of the strings used when they are created. For example, the method call

```csharp
Directory.Create("TeStDiReCtOrY");
```
creates a directory named TeStDiReCtOrY. If you rename a directory or file to change its case, the directory or file name reflects the case of the string used when you rename it. For example, the following code renames a file named test.txt to Test.txt:

```csharp
using System;
using System.IO;

class Example
{
   public static void Main()
   {
      var fi = new FileInfo(@".\test.txt");
      fi.MoveTo(@".\Test.txt");
   }
}
``` 
```vb
Imports System.IO

Module Example
   Public Sub Main()
      Dim fi As New FileInfo(".\test.txt")
      fi.MoveTo(".\Test.txt")
   End Sub
End Module
```

However, directory and file name comparisons are case-insensitive. If you search for a file named "test.txt", .NET file system APIs ignore case in the comparison. Test.txt, TEST.TXT, test.TXT, and any other combination of upper- and lowercase letters will match "test.txt".
