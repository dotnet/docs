---
title: "How to: Read and Write to Files in Isolated Storage"
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
helpviewer_keywords: 
  - "files, isolated storage"
  - "reading data"
  - "storing data using isolated storage, reading and writing to files"
  - "writing to files within store"
  - "data storage using isolated storage, reading and writing to files"
  - "reading files within store"
  - "isolated storage, reading and writing to files"
  - "data stores, reading and writing to files"
  - "stores, reading and writing to files"
ms.assetid: f977ebdc-1b55-475a-bc3d-3376470b08ae
caps.latest.revision: 15
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Read and Write to Files in Isolated Storage
To read from, or write to, a file in an isolated store, use an <xref:System.IO.IsolatedStorage.IsolatedStorageFileStream> object with a stream reader (<xref:System.IO.StreamReader> object) or stream writer (<xref:System.IO.StreamWriter> object).  
  
## Example  
 The following code example obtains an isolated store and checks whether a file named TestStore.txt exists in the store. If it doesn't exist, it creates the file and writes "Hello Isolated Storage" to the file. If TestStore.txt already exists, the example code reads from the file.  
  
 [!code-csharp[Conceptual.IsolatedStorage#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.isolatedstorage/cs/source5.cs#5)]
 [!code-vb[Conceptual.IsolatedStorage#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.isolatedstorage/vb/source5.vb#5)]  
  
## See Also  
 <xref:System.IO.IsolatedStorage.IsolatedStorageFile>  
 <xref:System.IO.IsolatedStorage.IsolatedStorageFileStream>  
 <xref:System.IO.FileMode?displayProperty=nameWithType>  
 <xref:System.IO.FileAccess?displayProperty=nameWithType>  
 <xref:System.IO.StreamReader?displayProperty=nameWithType>  
 <xref:System.IO.StreamWriter?displayProperty=nameWithType>  
 [File and Stream I-O](../../../docs/standard/io/index.md)  
 [Isolated Storage](../../../docs/standard/io/isolated-storage.md)
