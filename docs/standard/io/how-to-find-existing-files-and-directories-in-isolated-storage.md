---
title: "How to: Find Existing Files and Directories in Isolated Storage"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "stores, finding files and directories"
  - "locating files in isolated storage file"
  - "directories [.NET Framework], isolated storage"
  - "isolated storage, finding files and directories"
  - "data storage using isolated storage, finding files and directories"
  - "files [.NET Framework], isolated storage"
  - "data stores, finding files and directories"
  - "locating directories in isolated storage file"
  - "storing data using isolated storage, finding files and directories"
ms.assetid: eb28458a-6161-4e7a-9ada-30ef93761b5c
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Find Existing Files and Directories in Isolated Storage
To search for a directory in isolated storage, use the <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetDirectoryNames%2A?displayProperty=nameWithType> method. This method takes a string that represents a search pattern. You can use both single-character (?) and multi-character (*) wildcard characters in the search pattern, but the wildcard characters must appear in the final portion of the name. For example, `directory1/*ect*` is a valid search string, but `*ect*/directory2` is not.  
  
 To search for a file, use the <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetFileNames%2A?displayProperty=nameWithType> method. The restriction for wildcard characters in search strings that applies to <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetDirectoryNames%2A> also applies to <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetFileNames%2A>.  
  
 Neither of these methods is recursive; the <xref:System.IO.IsolatedStorage.IsolatedStorageFile> class does not supply any methods for listing all directories or files in your store. However, recursive methods are shown in the following code example.  
  
## Example  
 The following code example illustrates how to create files and directories in an isolated store. First, a store that is isolated for user, domain, and assembly is retrieved and placed in the `isoStore` variable. The <xref:System.IO.IsolatedStorage.IsolatedStorageFile.CreateDirectory%2A> method is used to set up a few different directories, and the <xref:System.IO.IsolatedStorage.IsolatedStorageFileStream.%23ctor%28System.String%2CSystem.IO.FileMode%2CSystem.IO.IsolatedStorage.IsolatedStorageFile%29> constructor creates some files in these directories. The code then loops through the results of the `GetAllDirectories` method. This method uses <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetDirectoryNames%2A> to find all the directory names in the current directory. These names are stored in an array, and then `GetAllDirectories` calls itself, passing in each directory it has found. As a result, all the directory names are returned in an array. Next, the code calls the `GetAllFiles` method. This method calls `GetAllDirectories` to find out the names of all the directories, and then it checks each directory for files by using the <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetFileNames%2A> method. The result is returned in an array for display.  
  
 [!code-cpp[Conceptual.IsolatedStorage#9](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.isolatedstorage/cpp/source8.cpp#9)]
 [!code-csharp[Conceptual.IsolatedStorage#9](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.isolatedstorage/cs/source8.cs#9)]
 [!code-vb[Conceptual.IsolatedStorage#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.isolatedstorage/vb/source8.vb#9)]  
  
## See Also  
 <xref:System.IO.IsolatedStorage.IsolatedStorageFile>  
 [Isolated Storage](../../../docs/standard/io/isolated-storage.md)
