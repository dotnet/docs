---
title: "How to: Enumerate directories and files"
ms.date: "12/27/2018"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "I/O [.NET Framework], enumerating directories and files"
ms.assetid: 86b69a08-3bfa-4e5f-b4e1-3b7cb8478215
author: "mairaw"
ms.author: "mairaw"
---
# How to: Enumerate directories and files
Enumerable collections provide better performance than arrays when you work with large collections of directories and files. 

To enumerate directories and files, use methods that return an enumerable collection of their names, <xref:System.IO.DirectoryInfo>, <xref:System.IO.FileInfo>, or <xref:System.IO.FileSystemInfo>.  
  
If you only want to search and return the names of directories or files, use the enumeration methods of the <xref:System.IO.Directory> class. If you want to search and return other properties of directories or files, use the <xref:System.IO.DirectoryInfo> and <xref:System.IO.FileSystemInfo> classes.  
  
You can use enumerable collections from these methods as the <xref:System.Collections.Generic.IEnumerable%601> parameter for constructors of collection classes like <xref:System.Collections.Generic.List%601>.  
  
The following table summarizes the methods that return enumerable collections:  
  
|To search and return|Use method|  
|------------------|-------------------------------------|-------------------|  
|Directory names|<xref:System.IO.Directory.EnumerateDirectories%2A?displayProperty=nameWithType>|  
|Directory information (<xref:System.IO.DirectoryInfo>)|<xref:System.IO.DirectoryInfo.EnumerateDirectories%2A?displayProperty=nameWithType>|  
|File names|<xref:System.IO.Directory.EnumerateFiles%2A?displayProperty=nameWithType>|  
|File information (<xref:System.IO.FileInfo>)|<xref:System.IO.DirectoryInfo.EnumerateFiles%2A?displayProperty=nameWithType>|  
|File system entries|<xref:System.IO.Directory.EnumerateFileSystemEntries%2A?displayProperty=nameWithType>|  
|File system information (<xref:System.IO.FileSystemInfo>)|<xref:System.IO.DirectoryInfo.EnumerateFileSystemInfos%2A?displayProperty=nameWithType>|  
  
>[!NOTE]
>Although you can immediately enumerate all the files in the subdirectories of a parent directory by using the <xref:System.IO.SearchOption.AllDirectories> search option provided by the <xref:System.IO.SearchOption> enumeration, <xref:System.UnauthorizedAccessException> errors may make the enumeration incomplete. You can catch these exceptions by first enumerating directories and then enumerating files.  
  
## Use the Directory class  
  
The following example uses the <xref:System.IO.Directory.EnumerateDirectories%28System.String%29?displayProperty=nameWithType> method to get a list of the top-level directory names in a specified path.  
  
     [!code-csharp[System.IO.EnumDirs1#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.io.enumdirs1/cs/program.cs#1)]
     [!code-vb[System.IO.EnumDirs1#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.enumdirs1/vb/program.vb#1)]  
  
The following example uses the <xref:System.IO.Directory.EnumerateFiles%28System.String%2CSystem.String%2CSystem.IO.SearchOption%29?displayProperty=nameWithType> method to search a directory and its subdirectories for a certain filename pattern, and returns the file names and paths. 
  
```csharp
using System;
using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
 
            try
            {
                var msFiles = Directory.EnumerateFiles(@"c:\program files\common files", "Microsoft*", SearchOption.AllDirectories);

                foreach (string currentFile in msFiles)
                    {
                    Console.WriteLine(currentFile);
                    }
            }
            catch (UnauthorizedAccessException UAEx)
                {
                Console.WriteLine(UAEx.Message);
                }
            catch (PathTooLongException PathEx)
                {
                Console.WriteLine(PathEx.Message);
                }
        }
    }
```

The following example uses the <xref:System.IO.Directory.EnumerateFiles%28System.String%2CSystem.String%2CSystem.IO.SearchOption%29?displayProperty=nameWithType> method to recursively enumerate all files in the specified directory and subdirectories that match a certain pattern. It then reads each line of each file and displays the lines, with their filenames and paths, that contain a specified string.
  
     [!code-csharp[System.IO.Directory.EnumerateFiles#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.io.directory.enumeratefiles/cs/program.cs#1)]
     [!code-vb[System.IO.Directory.EnumerateFiles#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.directory.enumeratefiles/vb/program.vb#1)]  
  
## Use the DirectoryInfo class  
  
The following example uses the <xref:System.IO.DirectoryInfo.EnumerateDirectories%2A?displayProperty=nameWithType> method to list a collection of top-level directories whose FileInfo matches a certain pattern.  
  
     [!code-csharp[System.IO.DirectoryInfo.EnumDirs#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.io.directoryinfo.enumdirs/cs/program.cs)]
     [!code-vb[System.IO.DirectoryInfo.EnumDirs#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.directoryinfo.enumdirs/vb/module1.vb#1)]  
  
The following example uses the <xref:System.IO.DirectoryInfo.EnumerateFiles%2A?displayProperty=nameWithType> method to list files in all directories whose FileInfo matches a certain pattern. This example first enumerates the top-level directories to catch possible unauthorized access exceptions. It then enumerates the files that match the pattern.  
  
     [!code-csharp[System.IO.DirectoryInfo.EnumerateDirectories#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.io.directoryinfo.enumeratedirectories/cs/program.cs#1)]
     [!code-vb[System.IO.DirectoryInfo.EnumerateDirectories#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.directoryinfo.enumeratedirectories/vb/program.vb#1)]  
  
## See also

- [File and stream I/O](../../../docs/standard/io/index.md)
