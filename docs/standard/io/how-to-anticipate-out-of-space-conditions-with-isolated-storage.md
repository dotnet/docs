---
title: "How to: Anticipate Out-of-Space Conditions with Isolated Storage"
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
  - "data stores, quotas"
  - "isolated storage, quotas"
  - "quanitity of isolated storage used"
  - "limit on isolated storage used"
  - "stores, quotas"
  - "stores, out of space conditions"
  - "data storage using isolated storage, quotas"
  - "storing data using isolated storage, quotas"
  - "space remaining in isolated storage"
  - "data stores, out of space conditions"
  - "storing data using isolated storage, out of space conditions"
  - "quotas for isolated storage"
  - "isolated storage, out of space conditions"
  - "data storage using isolated storage, out of space conditions"
ms.assetid: e35d4535-3732-421e-b1a3-37412e036145
caps.latest.revision: 17
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Anticipate Out-of-Space Conditions with Isolated Storage
Code that uses isolated storage is constrained by a [quota](../../../docs/standard/io/isolated-storage.md#quotas) that specifies the maximum size for the data compartment in which isolated storage files and directories exist. The quota is defined by security policy and is configurable by administrators. If the maximum allowed size is exceeded when you try to write data, an <xref:System.IO.IsolatedStorage.IsolatedStorageException> exception is thrown and the operation fails. This helps prevent malicious denial-of-service attacks that could cause the application to refuse requests because data storage is filled.  
  
 To help you determine whether a given write attempt is likely to fail for this reason, the <xref:System.IO.IsolatedStorage.IsolatedStorage> class provides three read-only properties: <xref:System.IO.IsolatedStorage.IsolatedStorage.AvailableFreeSpace%2A>, <xref:System.IO.IsolatedStorage.IsolatedStorage.UsedSize%2A>, and <xref:System.IO.IsolatedStorage.IsolatedStorage.Quota%2A>. You can use these properties to determine whether writing to the store will cause the maximum allowed size of the store to be exceeded. Keep in mind that isolated storage can be accessed concurrently; therefore, when you compute the amount of remaining storage, the storage space could be consumed by the time you try to write to the store. However, you can use the maximum size of the store to help determine whether the upper limit on available storage is about to be reached.  
  
 The <xref:System.IO.IsolatedStorage.IsolatedStorage.Quota%2A> property depends on evidence from the assembly to work properly. For this reason, you should retrieve this property only on <xref:System.IO.IsolatedStorage.IsolatedStorageFile> objects that were created by using the <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForAssembly%2A>, <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForDomain%2A>, or <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetStore%2A> method. <xref:System.IO.IsolatedStorage.IsolatedStorageFile> objects that were created in any other way (for example, objects that were returned from the <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetEnumerator%2A> method) will not return an accurate maximum size.  
  
## Example  
 The following code example obtains an isolated store, creates a few files, and retrieves the <xref:System.IO.IsolatedStorage.IsolatedStorage.AvailableFreeSpace%2A> property. The remaining space is reported in bytes.  
  
 [!code-cpp[Conceptual.IsolatedStorage#8](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.isolatedstorage/cpp/source7.cpp#8)]
 [!code-csharp[Conceptual.IsolatedStorage#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.isolatedstorage/cs/source7.cs#8)]
 [!code-vb[Conceptual.IsolatedStorage#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.isolatedstorage/vb/source7.vb#8)]  
  
## See Also  
 <xref:System.IO.IsolatedStorage.IsolatedStorageFile>  
 [Isolated Storage](../../../docs/standard/io/isolated-storage.md)  
 [How to: Obtain Stores for Isolated Storage](../../../docs/standard/io/how-to-obtain-stores-for-isolated-storage.md)
