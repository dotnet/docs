---
title: "How to: Obtain Stores for Isolated Storage"
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
  - "stores, obtaining"
  - "storing data using isolated storage, obtaining stores"
  - "isolated storage, obtaining stores"
  - "data stores, obtaining"
  - "data storage using isolated storage, obtaining stores"
ms.assetid: fcb6b178-d526-47c4-b029-e946f880f9db
caps.latest.revision: 19
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Obtain Stores for Isolated Storage
An isolated store exposes a virtual file system within a data compartment. The <xref:System.IO.IsolatedStorage.IsolatedStorageFile> class supplies a number of methods for interacting with an isolated store. To create and retrieve stores, <xref:System.IO.IsolatedStorage.IsolatedStorageFile> provides three static methods:  
  
-   <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForAssembly%2A> returns storage that is isolated by user and assembly.  
  
-   <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForDomain%2A> returns storage that is isolated by domain and assembly.  
  
     Both methods retrieve a store that belongs to the code from which they are called.  
  
-   The static method <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetStore%2A> returns an isolated store that is specified by passing in a combination of scope parameters.  
  
 The following code returns a store that is isolated by user, assembly, and domain.  
  
 [!code-cpp[Conceptual.IsolatedStorage#6](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.isolatedstorage/cpp/source6.cpp#6)]
 [!code-csharp[Conceptual.IsolatedStorage#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.isolatedstorage/cs/source6.cs#6)]
 [!code-vb[Conceptual.IsolatedStorage#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.isolatedstorage/vb/source6.vb#6)]  
  
 You can use the <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetStore%2A> method to specify that a store should roam with a roaming user profile. For details on how to set this up, see [Types of Isolation](../../../docs/standard/io/types-of-isolation.md).  
  
 Isolated stores obtained from within different assemblies are, by default, different stores. You can access the store of a different assembly or domain by passing in the assembly or domain evidence in the parameters of the <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetStore%2A> method. This requires permission to access isolated storage by application domain identity. For more information, see the <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetStore%2A> method overloads.  
  
 The <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForAssembly%2A>, <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForDomain%2A>, and <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetStore%2A> methods return an <xref:System.IO.IsolatedStorage.IsolatedStorageFile> object. To help you decide which isolation type is most appropriate for your situation, see [Types of Isolation](../../../docs/standard/io/types-of-isolation.md). When you have an isolated storage file object, you can use the isolated storage methods to read, write, create, and delete files and directories.  
  
 There is no mechanism that prevents code from passing an <xref:System.IO.IsolatedStorage.IsolatedStorageFile> object to code that does not have sufficient access to get the store itself. Domain and assembly identities and isolated storage permissions are checked only when a reference to an <xref:System.IO.IsolatedStorage.IsolatedStorage> object is obtained, typically in the <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForAssembly%2A>, <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForDomain%2A>, or <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetStore%2A> method. Protecting references to <xref:System.IO.IsolatedStorage.IsolatedStorageFile> objects is, therefore, the responsibility of the code that uses these references.  
  
## Example  
 The following code provides a simple example of a class obtaining a store that is isolated by user and assembly. The code can be changed to retrieve a store that is isolated by user, domain, and assembly by adding <xref:System.IO.IsolatedStorage.IsolatedStorageScope.Domain?displayProperty=nameWithType> to the arguments that the <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetStore%2A> method passes.  
  
 After you run the code, you can confirm that a store was created by typing **StoreAdm /LIST** at the command line. This runs the [Isolated Storage tool (Storeadm.exe)](../../../docs/framework/tools/storeadm-exe-isolated-storage-tool.md) and lists all the current isolated stores for the user.  
  
 [!code-cpp[Conceptual.IsolatedStorage#7](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.isolatedstorage/cpp/source6.cpp#7)]
 [!code-csharp[Conceptual.IsolatedStorage#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.isolatedstorage/cs/source6.cs#7)]
 [!code-vb[Conceptual.IsolatedStorage#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.isolatedstorage/vb/source6.vb#7)]  
  
## See Also  
 <xref:System.IO.IsolatedStorage.IsolatedStorageFile>  
 <xref:System.IO.IsolatedStorage.IsolatedStorageScope>  
 [Isolated Storage](../../../docs/standard/io/isolated-storage.md)  
 [Types of Isolation](../../../docs/standard/io/types-of-isolation.md)  
 [Assemblies in the Common Language Runtime](../../../docs/framework/app-domains/assemblies-in-the-common-language-runtime.md)
