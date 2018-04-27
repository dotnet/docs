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

The Windows operating system has a unified object model that points to all resources, including files. These object paths are not directly accessible from the Windows APIs (such as the Console windows and Windows Explorer). They are, however, exposed to the Win32 layer through a special folder of symbolic links that legacy DOS and UNC paths are mapped to. This special folder is accessed via the DOS Device path syntax, which is one of:

\\.\C:\Test\Foo.txt   
\\?\C:\Test\Foo.txt

The DOS device path consists of the following components:

- \\\\.\\ or \\\\?\\, which identifies the path as a DOS device path.
- A symbolic link to the "real" device object (C: in this case). 

   There is a specific link for UNCs that is called, not surprisingly, "UNC". For example:

      \\.\UNC\Server\Share\Test\Foo.txt   
      \\?\UNC\Server\Share\Test\Foo.txt

Like UNCs, DOS device paths are fully qualified by definition. Current directories never enter into their usage.

## Path normalization

Almost all paths passed to Windows APIs are normalized. During normalization, Windows does the following:

- Canonicalizes component and directory separators.
- Applies the current directory to partially qualified (relative) paths.
- Evaluates relative directory components (`.` for the current directory and `..` for the parent directory).
- Trims certain characters.

This normalization happens implicitly, but you can do it explicitly by calling the Windows [GetFullPathName() function](https://msdn.microsoft.com/en-us/library/windows/desktop/aa364963(v=vs.85).aspx).

### Identifying the path

The first step in path normalization is identifying the type of path. Paths fall into one of a few categories:

- They are device paths; that is, they begin with two separators and a question mark or period (`\\?,` or `\\.`).
- They are UNC paths; that is, they begin with two separators without a question mark or period. 
- They are fully qualified DOS paths; that is, they begin with a drive letter, a volume separator, and a component separator (`C:\`).
- They designate a legacy device (`CON`, `LPT1`).
- They are relative to the root of the current drive; that is, they begin with a single component separator (`\`).
- They are relative to the current directory of a specified drive; that is, they begin with a drive letter, a volume separator, and no component separator (`C:`).
- They are relative to the current directory; that is, they begin with anything else (`temp\testfile.txt`).

The type of the path determines whether or not a current directory is applied in some way. It also determines what the "root" of the path is.

### Handling legacy devices

If the path is a legacy DOS device such as `CON`, `COM1`, or `LPT1`, it is converted into a device path by prepending `\\.\` and returned.

### Applying the current directory

If a path isn't fully qualified, Windows applies the current directory to it. UNCs and device paths do not have the current directory applied. Neither does a full drive with separator C:\.

If the path starts with a single component separator, the drive from the current directory is applied. If the file path is `\utilities` and the current directory is `C:\temp\`, normalization produces `C:\utilities`.

If the path starts with a drive letter, volume separator, and no component separator, the last current directory set from the command shell for the specified drive is applied, or the drive alone if none is set. If you pass D:bar and the current directory is C:\foo\ and the last current directory on D: was D:\bar\ you would get D:\bar\bar. These "Drive Relative" paths are a common source of program and script logic errors. Assuming that a path beginning with a letter and a colon isn't relative is obviously not correct.
The last case is starts with something other than a separator (7). If you pass bar and the current directory is C:\foo\ you would get C:\foo\bar.
Note that relative paths are dangerous in multithreaded programs (e.g. most programs) as the current directory is a process-wide setting. Any thread can change the current directory at any time. I'll discuss ways to deal with this in a future post.
Canonicalizing Separators
All forward slashes (/) are converted into the standard Windows separator- the back slash (\). Runs of slashes are collapsed into a single slash, after the first two slashes if present.
When identifying paths for normalization purposes, the initial direction of the slash does not matter. It is important to recognize, however, that forward slashes are not supported in Windows outside of this normalization step. This is critically important when it comes to skipping normalization, which we'll discuss shortly.
Evaluating Relative Components
As the path is processed, any components/segments that are comprised of a single or double period are evaluated. For a single period (.) the current segment is removed (as it means current directory). For a double period (..) the current segment and the parent segment are removed (as it means parent directory).
Parent directories are only removed if they aren't past the "root" of the path. The root of the path depends on the type of path. It is the drive (C:\) for DOS paths, the server/share for UNCs (\\Server\Share), and the device path prefix for device paths (\\?\ or \\.\).
Trimming Characters
Some characters will be removed (other than runs of separators and relative segments).
If a segment ends in a single period, that period will be removed. A segment of a single or double period falls under the relative component rule above. A segment of three periods (or more) doesn't hit any of these rules and is actually a valid file/directory name.
If the path doesn't end in a separator, all trailing periods and spaces (charater code 32 only) will be removed. If the last segment is simply a single or double period it falls under the relative components rule above. This rule leads to the possibly surprising ability to create a directory with a trailing space. You simply need to add a trailing separator to do so.
Skipping Normalization
Normally any path passed to a Windows API is (effectively) passed to GetFullPathName() and normalized. There is one important exception- if you have a device path that begins with a question mark instead of a period.  It must use the canonical backslash- if the path does not start with exactly \\?\ it will be normalized.
Why would you want to skip normalization? One reason is to get access to paths that are normally unavailable, but legal in NTFS/FAT/etc. A file or directory called "foo." for example, is impossible to access any other way. You also get to avoid some cycles by skipping normalization if you've already normalized.
The last reason is that the MAX_PATH check for path length is skipped as well, allowing for paths that are greater than 259 characters long. Most APIs will allow this, with some notable exceptions, such as Get/SetCurrentDirectory.
Skipping normalization and max path checks is the only difference between the two device path syntaxes- they are otherwise identical. Tread carefully with skipping normalization as you can easily create paths that are difficult for "normal" applications to deal with.
Paths that start with \\?\ are normalized if you explicitly pass them to GetFullPathName(). Don't forget, however, that rooting is different with device syntax (C:\.. does not normalize the same as \\?\C:\..). Note that you can pass > MAX_PATH paths to GetFullPathName() without \\?\. It supports arbitrary length paths (well, currently up to the maximum string size that Windows can handle, see UNICODE_STRING).




## Long file paths

.NET Core and the .NET Framework (starting with version 4.6.2) support long file paths.

## Example: Ways to refer to the same file

The following example illustrates some of the ways in which you can refer to a file when using the APIs in the <xref:System.IO> namespace. The example instantiates a <xref:System.IO.FileInfo> object and uses its <xref:System.IO.FileInfo.Name> and <xref:System.IO.FileInfo.Length> properties to display the filename and the length of the file.

[!code-csharp[referring-to-the-same-file](~/samples/snippets/standard/io/file-names/cs/file-refs.cs)]
[!code-vb[referring-to-the-same-file](~/samples/snippets/standard/io/file-names/vb/file-refs.vb)]


